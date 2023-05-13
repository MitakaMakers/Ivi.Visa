using System.Net;
using System.Net.Sockets;

namespace Vxi11Net
{
    public class ClientRpcTcp
    {
        private Socket socket = new Socket(SocketType.Stream, ProtocolType.Tcp);

        private const int UDPMSGSIZE = 2000;
        private byte[] raw_buf = new byte[UDPMSGSIZE];
        private bool last_fragment = true;
        private int recvsize = 0;
        private int readsize = 0;

        public void Create(string host, int port)
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(host);
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            EndPoint endPoint = (EndPoint)new IPEndPoint(ipAddress, port);
            socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(endPoint);

        }
        public void Destroy()
        {
            socket.Close();
        }
        // call message を受信する
        
        // TCP: frag_header が1になるまで受信する
        private int Receive(byte[] buffer, int offset, int buffsize, SocketFlags socketFlags, bool IsFirst)
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

        public int GetReply(byte[] buffer, bool IsFirst)
        {
            int rlen = 0;
            int pos = 0;
            int size = buffer.Length;
            while (size > 0)
            {
                int ret = Receive(buffer, pos, size, SocketFlags.None, IsFirst);
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
            return rlen;
        }
        public void ClearReply()
        {
            int ret;
            do
            {
                ret = Receive(raw_buf, 0, UDPMSGSIZE, SocketFlags.None, false);
            } while (ret > 0);
        }

        private int Send(byte[] buffer, int offset, int size, SocketFlags socketFlags, bool IsFirst, bool IsLast)
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

        public void Call(byte[] msg, bool IsFirst, bool IsLast)
        {
            Send(msg, 0, msg.Length, SocketFlags.None, IsFirst, IsLast);
            last_fragment = true;
            recvsize = 0;
            readsize = 0;
            return;
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
                    byteCount = socket.Receive(buffer, SocketFlags.None);
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
    public class ClientRpcUdp
    {
        private const int UDPMSGSIZE = 2000;

        private Socket socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
        private EndPoint endPoint = (EndPoint)new IPEndPoint(IPAddress.IPv6Any, 0);

        private byte[] raw_buf = new byte[UDPMSGSIZE];
        private int recvsize = 0;
        private int readsize = 0;

        public void Create(string host, int port)
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(host);
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            endPoint = (EndPoint)new IPEndPoint(ipAddress, port);
            socket = new Socket(endPoint.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
            socket.Connect(endPoint);
        }
        public void Destroy()
        {
            socket.Close();
        }
        // call message を受信する
        // UDP 1回分受信する
        private int Receive(byte[] buffer, int offset, int buffsize, bool IsFirst)
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
        public int GetReply(byte[] buffer, bool IsFirst)
        {
            int rlen = Receive(buffer, 0, buffer.Length, IsFirst);
            return rlen;
        }
        public void ClearReply()
        {
            readsize = 0;
            recvsize = 0;
        }

        // UDP 1回分受信する
        private int Send(byte[] buffer, int size, SocketFlags socketFlags)
        {
            return socket.SendTo(buffer, size, socketFlags, endPoint);
        }

        public void Call(byte[] msg, bool IsFirst, bool IsLast)
        {
            Send(msg, msg.Length, SocketFlags.None);
            recvsize = 0;
            readsize = 0;
            return;
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
                    byteCount = socket.ReceiveFrom(buffer, SocketFlags.None, ref endPoint);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            socket.ReceiveTimeout = timeout;
            recvsize = 0;
            readsize = 0;
        }
    }
}