using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Vxi11Net
{
    public class ServerRpcTcp
    {
        private int Send(byte[] body, int offset, int size, SocketFlags socketFlags, bool IsFirst, bool IsLast)
        {
            int bytes = 0;
            if (IsFirst)
            {
                int frag_header = size;
                if (IsLast == true)
                {
                    frag_header = frag_header + int.MinValue;
                }
                byte[] header = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(frag_header));
                byte[] buffer = new byte[header.Length + body.Length];
                Buffer.BlockCopy(header, 0, buffer, 0, header.Length);
                Buffer.BlockCopy(body, 0, buffer, header.Length, body.Length);
                bytes = socket.Send(buffer);
            }
            else
            {
                bytes = socket.Send(body, offset, size, socketFlags);
            }
            return bytes;
        }
        // call message を受信する
        // TCP: frag_header が1になるまで受信する
        private int Receive(byte[] buffer, int offset, int buffsize, SocketFlags socketFlags, bool IsFirst)
        {
            int size = 0;
            while (size == 0)
            {
                if (IsFirst)
                {
                    if (socket.Connected == false)
                    {
                        socket = server.Accept();
                    }
                    last_fragment = false;
                }

                if ((last_fragment == false) && (remain <= 0))
                {
                    byte[] record_marking = new byte[4];
                    int bytes = socket.Receive(record_marking, 4, SocketFlags.None);
                    if (bytes == 0)
                    {
                        socket.Close();
                        continue;
                    }
                    Console.WriteLine("    == RPC(TCP:{0}):Received ({1}) ==", endPoint.Port, bytes);
                    int frag_header = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(record_marking, 0));
                    if (frag_header < 0)
                    {
                        last_fragment = true;
                        remain = frag_header + int.MaxValue + 1;
                    }
                    else
                    {
                        last_fragment = false;
                        remain = frag_header;
                    }
                }

                if (buffsize <= remain)
                {
                    size = buffsize;
                }
                else
                {
                    size = remain;
                }
                if (0 < size)
                {
                    int bytes = socket.Receive(buffer, offset, size, socketFlags);
                    Console.WriteLine("    == RPC(TCP:{0}):Received ({1}) ==", endPoint.Port, bytes);
                    remain = remain - bytes;
                }
            }
            return size;
        }
        public Rpc.RPC_MESSAGE_PARAMS ReceiveMsg()
        {
            int size = Marshal.SizeOf(typeof(Rpc.RPC_MESSAGE_PARAMS));
            byte[] buffer = new byte[size];
            int bytes = Receive(buffer, 0, size, SocketFlags.None, true);

            Rpc.RPC_MESSAGE_PARAMS msg = new Rpc.RPC_MESSAGE_PARAMS();
            msg.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            msg.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            msg.rpcvers = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            msg.prog = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            msg.vers = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            msg.proc = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            msg.cred_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            msg.cred_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));
            msg.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 32));
            msg.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 36));
            return msg;
        }
        public int GetArgs(byte[] buffer)
        {
            int bytes = 0;
            int pos = 0;
            int size = buffer.Length;
            while (0 < size)
            {
                int ret = Receive(buffer, pos, size, SocketFlags.None, false);
                if (0 < ret)
                {
                    pos += ret;
                    size -= ret;
                    bytes += ret;
                }
                else
                {
                    break;
                }
            }
            return bytes;
        }
        public void ClearArgs()
        {
            int bytes;
            int size;
            byte[] buffer = new byte[2000];
            while (remain > 0)
            {
                if (buffer.Length <= remain)
                {
                    size = buffer.Length;
                }
                else
                {
                    size = remain;
                }
                bytes = socket.Receive(buffer, 0, size, SocketFlags.None);
                Console.WriteLine("    == RPC(TCP:{0}):Received ({1}) ==", endPoint.Port, bytes);
                remain = remain - bytes;
            }
            last_fragment = false;
        }
        public void Reply(byte[] reply, bool IsFirst, bool IsLast)
        {
            Send(reply, 0, reply.Length, SocketFlags.None, IsFirst, IsLast);
            last_fragment = false;
            remain = 0;
        }
        public void Flush()
        {
            int timeout = socket.ReceiveTimeout;
            socket.ReceiveTimeout = 1;
            try
            {
                int bytes;
                byte[] buffer = new byte[1000];
                do
                {
                    bytes = socket.Receive(buffer, SocketFlags.None);
                } while (0 < bytes);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            socket.ReceiveTimeout = timeout;
            last_fragment = true;
            remain = 0;
        }

        private Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        IPEndPoint endPoint = new IPEndPoint(IPAddress.IPv6Any, 0);

        private bool last_fragment;
        private int remain;
        public void Create(string ipString, int port)
        {
            // get IP address from IPv4 address string
            IPAddress ipAddress = IPAddress.Parse(ipString);
            /* if get ipaddress from hostname, 　
            IPHostEntry ipHostInfo = Dns.GetHostEntry(host);
            int i = 0;
            for (i = 0;  i < ipHostInfo.AddressList.Length; i++)
            {
                if (ipHostInfo.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                    break;
            }
            IPAddress ipAddress = ipHostInfo.AddressList[i]; */
            endPoint = new IPEndPoint(ipAddress, port);
            server = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(endPoint);
            server.Listen(3);
        }
        public void Close()
        {
            socket.Close();
        }
        public void Destroy()
        {
            server.Close();
            socket.Close();
        }
    }
    public class ServerRpcUdp
    {
        // UDP 1回分受信する
        private int Send(byte[] buffer, int size, SocketFlags socketFlags)
        {
            return socket.SendTo(buffer, size, socketFlags, endPoint);
        }
        // call message を受信する
        // UDP 1回分受信する
        private int Receive(byte[] buffer, int offset, int buffsize, bool IsFirst)
        {
            if (IsFirst)
            {
                readsize = 0;
                raw_buf = new byte[UDPMSGSIZE];
                recvsize = socket.ReceiveFrom(raw_buf, ref endPoint);
            }

            int bytes = 0;
            if (buffsize <= (recvsize - readsize))
            {
                bytes = buffsize;
            }
            else
            {
                bytes = recvsize - readsize;
            }
            Buffer.BlockCopy(raw_buf, readsize, buffer, offset, bytes);

            readsize += bytes;
            return bytes;
        }
        public Rpc.RPC_MESSAGE_PARAMS ReceiveMsg()
        {
            int size = Marshal.SizeOf(typeof(Rpc.RPC_MESSAGE_PARAMS));
            byte[] buffer = new byte[size];
            Receive(buffer, 0, size, true);

            Rpc.RPC_MESSAGE_PARAMS msg = new Rpc.RPC_MESSAGE_PARAMS();
            msg.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            msg.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            msg.rpcvers = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            msg.prog = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            msg.vers = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            msg.proc = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            msg.cred_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            msg.cred_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));
            msg.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 32));
            msg.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 36));
            return msg;
        }
        public int GetArgs(byte[] buffer)
        {
            int bytes = Receive(buffer, 0, buffer.Length, false);
            return bytes;
        }
        public void ClearArgs()
        {
            readsize = 0;
            recvsize = 0;
        }
        public void Reply(byte[] reply)
        {
            Send(reply, reply.Length, SocketFlags.None);
            recvsize = 0;
            readsize = 0;
        }
        public void Flush()
        {
            int timeout = socket.ReceiveTimeout;
            socket.ReceiveTimeout = 1;
            try
            {
                int bytes;
                do
                {
                    bytes = socket.ReceiveFrom(raw_buf, SocketFlags.None, ref endPoint);
                } while (0 < bytes);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            socket.ReceiveTimeout = -1;
            recvsize = 0;
            readsize = 0;
        }

        private Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private EndPoint endPoint = (EndPoint)new IPEndPoint(IPAddress.IPv6Any, 0);

        private const int UDPMSGSIZE = 2000;
        private byte[] raw_buf = new byte[UDPMSGSIZE];
        private int recvsize = 0;
        private int readsize = 0;

        public void Create(string ipString, int port)
        {
            // get IP address from IPv4 address string
            IPAddress ipAddress = IPAddress.Parse(ipString);
            /* if get ipaddress from hostname, 　
            IPHostEntry ipHostInfo = Dns.GetHostEntry(host);
            int i = 0;
            for (i = 0;  i < ipHostInfo.AddressList.Length; i++)
            {
                if (ipHostInfo.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                    break;
            }
            IPAddress ipAddress = ipHostInfo.AddressList[i]; */
            endPoint = (EndPoint)new IPEndPoint(ipAddress, port);
            socket = new Socket(endPoint.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
            socket.Bind(endPoint);
        }
        public void Destroy()
        {
            socket.Close();
        }
    }
}