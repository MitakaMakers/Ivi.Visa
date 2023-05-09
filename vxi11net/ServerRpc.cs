using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Vxi11Net
{
    public class ServerRPC
    {
        private const int UDPMSGSIZE = 2000;
        private int xid = 0;

        private Socket server = new Socket(SocketType.Stream, ProtocolType.Tcp);
        private Socket so = new Socket(SocketType.Stream, ProtocolType.Tcp);
        private EndPoint remoteEP = (EndPoint)new IPEndPoint(IPAddress.IPv6Any, 0);

        private byte[] raw_buf = new byte[UDPMSGSIZE];
        private bool last_fragment = true;
        private int recvsize = 0;
        private int readsize = 0;
        public int remain_count()
        {
            return (recvsize - readsize);
        }

        public Socket CreateTcp(string host, int port)
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(host);
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint ipEndPoint = new(ipAddress, port);
            server = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(ipEndPoint);
            server.Listen();
            return server;
        }
        public Socket CreateUdp(string host, int port)
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(host);
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint ipEndPoint = new(ipAddress, port);
            so = new Socket(ipEndPoint.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
            so.Bind(ipEndPoint);
            return so;
        }
        public void Destroy()
        {
            server.Close();
            so.Close();
        }
        // call message を受信する
        
        // TCP: frag_header が1になるまで受信する
        private int ReceiveTcp(byte[] buffer, int offset, int buffsize, System.Net.Sockets.SocketFlags socketFlags, bool IsFirst)
        {
            if ((IsFirst) || ((last_fragment == false) && (recvsize <= readsize)))
            {
                readsize = 0;
                so.Receive(raw_buf, 4, SocketFlags.None);
                int frag_header = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(raw_buf, 0));
                if (frag_header < 0)
                {
                    last_fragment = true;
                    recvsize = frag_header + int.MaxValue + 1;
                }
                else
                {
                    last_fragment = false;
                    recvsize = frag_header;
                }
            }

            int length = 0;
            if (buffsize <= (recvsize - readsize))
            {
                length = buffsize;
            }
            else
            {
                length = recvsize - readsize;
            }
            if (length > 0) {
                so.Receive(buffer, offset, length, socketFlags);
                readsize += length;
            }
            return length;
        }

        // UDP 1回分受信する
        private int ReceiveUdp(byte[] buffer, int offset, int buffsize, bool IsFirst)
        {
            if (IsFirst)
            {
                readsize = 0;
                recvsize = so.ReceiveFrom(raw_buf, ref remoteEP);
            }

            int length = 0;
            if (buffsize <= (recvsize - readsize))
            {
                length = buffsize;
            }
            else
            {
                length = recvsize - readsize;
            }

            Buffer.BlockCopy(raw_buf, readsize, buffer, offset, length);

            readsize += length;
            return length;
        }
        public RPC.RPC_MESSAGE_PARAMS ReceiveMsg()
        {
            int size = Marshal.SizeOf(typeof(RPC.RPC_MESSAGE_PARAMS));
            if (so.SocketType == SocketType.Stream)
            {
                if (so.Connected == false)
                {
                    so = server.Accept();
                }
                ReceiveTcp(raw_buf, 0, size, SocketFlags.None, true);
            }
            else
            {
                IPEndPoint sender = new IPEndPoint(IPAddress.IPv6Any, 0);
                EndPoint senderRemote = (EndPoint)sender;
                ReceiveUdp(raw_buf, 0, size, true);
            }

            RPC.RPC_MESSAGE_PARAMS msg = new RPC.RPC_MESSAGE_PARAMS();
            msg.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(raw_buf, 0));
            msg.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(raw_buf, 4));
            msg.rpcvers = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(raw_buf, 8));
            msg.prog = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(raw_buf, 12));
            msg.vers = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(raw_buf, 16));
            msg.proc = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(raw_buf, 20));
            msg.cred_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(raw_buf, 24));
            msg.cred_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(raw_buf, 28));
            msg.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(raw_buf, 32));
            msg.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(raw_buf, 36));

            xid = msg.xid;
            return msg;
        }
        public int GetArgs(byte[] buffer)
        {
            int rlen = 0;
            if (so.SocketType == SocketType.Stream)
            {
                int pos = 0;
                int size = buffer.Length;
                while (size > 0)
                {
                    int ret = ReceiveTcp(buffer, pos, size, SocketFlags.None, false);
                    if (ret > 0)
                    {
                        pos += ret;
                        size -= ret;
                        rlen += ret;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                IPEndPoint sender = new IPEndPoint(IPAddress.IPv6Any, 0);
                EndPoint senderRemote = (EndPoint)sender;
                rlen = ReceiveUdp(buffer, 0, buffer.Length, false);
            }
            return rlen;
        }
        public void ClearArgs()
        {
            if (so.SocketType == SocketType.Stream)
            {
                int ret;
                do
                {
                    ret = ReceiveTcp(raw_buf, 0, UDPMSGSIZE, SocketFlags.None, false);

                } while (ret > 0);
            }
            else
            {
                readsize = 0;
                recvsize = 0;
                last_fragment = true;
            }
        }

        public void Reply(byte[] reply, bool IsFirst, bool IsLast)
        {
            byte[] xid_array = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(xid));
            Array.Copy(xid_array, reply, 4); ;
            if (so.SocketType == SocketType.Stream)
            {
                SendTcp(reply, 0, reply.Length, SocketFlags.None, IsFirst, IsLast);
            }
            else
            {
                SendUdp(reply, reply.Length, SocketFlags.None);
            }
            last_fragment = true;
            recvsize = 0;
            readsize = 0;
            return;
        }
        private int SendTcp(byte[] buffer, int offset, int size, SocketFlags socketFlags, bool IsFirst, bool IsLast)
        {
            if (IsFirst)
            {
                int frag_header = size;
                if (IsLast == true)
                {
                    frag_header = frag_header + int.MinValue;
                }
                byte[] array = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(frag_header));
                so.Send(array);
            }

            int length = 0;
            length += so.Send(buffer, offset, size, socketFlags);
            return length;
        }

        // UDP 1回分受信する
        private int SendUdp(byte[] buffer, int size, SocketFlags socketFlags)
        { 
            return so.SendTo(buffer, size, socketFlags, remoteEP);
        }

        public void Flush()
        {
            byte[] buffer = new byte[UDPMSGSIZE];
            int byteCount = 1;
            int timeout = so.ReceiveTimeout;

            so.ReceiveTimeout = 1;
            try
            {
                while (1 <= byteCount)
                {
                    if (so.SocketType == SocketType.Stream)
                    {
                        byteCount = so.Receive(buffer, SocketFlags.None);
                    }
                    else if (so.ProtocolType == ProtocolType.Udp)
                    {
                        IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
                        EndPoint senderRemote = (EndPoint)sender;
                        byteCount = so.ReceiveFrom(buffer, SocketFlags.None, ref senderRemote);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            so.ReceiveTimeout = timeout;

            last_fragment = true;
            recvsize = 0;
            readsize = 0;
        }
    }
}