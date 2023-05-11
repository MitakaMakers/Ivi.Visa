using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Vxi11Net
{
    public class ServerRpc
    {
        private const int UDPMSGSIZE = 2000;
        private int xid = 0;

        private Socket server = new Socket(SocketType.Stream, ProtocolType.Tcp);
        private Socket socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
        private EndPoint endPoint = (EndPoint)new IPEndPoint(IPAddress.IPv6Any, 0);

        private byte[] raw_buf = new byte[UDPMSGSIZE];
        private bool last_fragment = true;
        private int recvsize = 0;
        private int readsize = 0;
        public int remain_count()
        {
            return (recvsize - readsize);
        }

        public void CreateTcp(string host, int port)
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(host);
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            endPoint = (EndPoint)new IPEndPoint(ipAddress, port);
            server = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(endPoint);
            server.Listen();
        }
        public void CreateUdp(string host, int port)
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(host);
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            endPoint = (EndPoint)new IPEndPoint(ipAddress, port);
            socket = new Socket(endPoint.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
            socket.Bind(endPoint);
        }
        public void Destroy()
        {
            server.Close();
            socket.Close();
        }
        // call message を受信する
        // TCP: frag_header が1になるまで受信する
        private int ReceiveTcp(byte[] buffer, int offset, int buffsize, System.Net.Sockets.SocketFlags socketFlags, bool IsFirst)
        {
            if ((IsFirst) || ((last_fragment == false) && (recvsize <= readsize)))
            {
                readsize = 0;
                socket.Receive(raw_buf, 4, SocketFlags.None);
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
                socket.Receive(buffer, offset, length, socketFlags);
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
                recvsize = socket.ReceiveFrom(raw_buf, ref endPoint);
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
        public Rpc.RPC_MESSAGE_PARAMS ReceiveMsg()
        {
            int size = Marshal.SizeOf(typeof(Rpc.RPC_MESSAGE_PARAMS));
            if (socket.SocketType == SocketType.Stream)
            {
                if (socket.Connected == false)
                {
                    socket = server.Accept();
                }
                ReceiveTcp(raw_buf, 0, size, SocketFlags.None, true);
            }
            else
            {
                IPEndPoint sender = new IPEndPoint(IPAddress.IPv6Any, 0);
                EndPoint senderRemote = (EndPoint)sender;
                ReceiveUdp(raw_buf, 0, size, true);
            }

            Rpc.RPC_MESSAGE_PARAMS msg = new Rpc.RPC_MESSAGE_PARAMS();
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
            if (socket.SocketType == SocketType.Stream)
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
            if (socket.SocketType == SocketType.Stream)
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
            if (socket.SocketType == SocketType.Stream)
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
            int length = 0;
            if (IsFirst)
            {
                int frag_header = size;
                if (IsLast == true)
                {
                    frag_header = frag_header + int.MinValue;
                }
                byte[] array = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(frag_header));
                byte[] tmp = new byte[array.Length + buffer.Length];
                Buffer.BlockCopy(array, 0, tmp, 0, array.Length);
                Buffer.BlockCopy(buffer, 0, tmp, array.Length, buffer.Length);
                length = socket.Send(tmp);
            }
            else
            {
                length = socket.Send(buffer, offset, size, socketFlags);
            }
            return length;
        }

        // UDP 1回分受信する
        private int SendUdp(byte[] buffer, int size, SocketFlags socketFlags)
        { 
            return socket.SendTo(buffer, size, socketFlags, endPoint);
        }

        public void Flush()
        {
            byte[] buffer = new byte[UDPMSGSIZE];
            int byteCount = 1;
            int timeout = socket.ReceiveTimeout;

            socket.ReceiveTimeout = 1;
            try
            {
                while (1 <= byteCount)
                {
                    if (socket.SocketType == SocketType.Stream)
                    {
                        byteCount = socket.Receive(buffer, SocketFlags.None);
                    }
                    else if (socket.ProtocolType == ProtocolType.Udp)
                    {
                        IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
                        EndPoint senderRemote = (EndPoint)sender;
                        byteCount = socket.ReceiveFrom(buffer, SocketFlags.None, ref senderRemote);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            socket.ReceiveTimeout = timeout;

            last_fragment = true;
            recvsize = 0;
            readsize = 0;
        }
    }
}