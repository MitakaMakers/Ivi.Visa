using System.Net;
using System.Net.Sockets;

namespace Vxi11Net
{
    public class ClientRpcTcp
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
            if ((IsFirst) || ((last_fragment == false) && (remain <= 0)))
            {
                byte[] record_marking = new byte[4];
                socket.Receive(record_marking, 4, SocketFlags.None);
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
            int bytes;
            if (buffsize <= remain)
            {
                bytes = buffsize;
            }
            else
            {
                bytes = remain;
            }
            if (0 < bytes)
            {
                socket.Receive(buffer, offset, bytes, socketFlags);
                remain -= bytes;
            }
            return bytes;
        }
        public void Call(byte[] msg, bool IsFirst, bool IsLast)
        {
            Send(msg, 0, msg.Length, SocketFlags.None, IsFirst, IsLast);
            last_fragment = true;
            remain = 0;
            return;
        }
        public int GetReply(byte[] buffer, bool IsFirst)
        {
            int bytes = 0;
            int pos = 0;
            int size = buffer.Length;
            while (0 < size)
            {
                int ret = Receive(buffer, pos, size, SocketFlags.None, IsFirst);
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
        public void ClearReply()
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
        public void Flush()
        {
            int timeout = socket.ReceiveTimeout;
            socket.ReceiveTimeout = 1;
            try
            {
                int bytes = 1;
                byte[] buffer = new byte[1000];
                do
                {
                    bytes = socket.Receive(buffer, SocketFlags.None);
                }
                while (0 < bytes);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            socket.ReceiveTimeout = timeout;
            last_fragment = true;
            remain = 0;
        }

        private Socket socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint endPoint = new IPEndPoint(IPAddress.IPv6Any, 0);
        private bool last_fragment = true;
        private int remain = 0;

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
            socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(endPoint);

        }
        public void Destroy()
        {
            socket.Close();
        }
    }
    public class ClientRpcUdp
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
            int size;
            if (buffsize <= (recvsize - readsize))
            {
                size = buffsize;
            }
            else
            {
                size = recvsize - readsize;
            }
            Buffer.BlockCopy(raw_buf, readsize, buffer, offset, size);
            readsize += size;
            return size;
        }
        public void Call(byte[] msg, bool IsFirst, bool IsLast)
        {
            Send(msg, msg.Length, SocketFlags.None);
            recvsize = 0;
            readsize = 0;
            return;
        }
        public int GetReply(byte[] buffer, bool IsFirst)
        {
            int bytes = Receive(buffer, 0, buffer.Length, IsFirst);
            return bytes;
        }
        public void ClearReply()
        {
            readsize = 0;
            recvsize = 0;
        }
        public void Flush()
        {
            int timeout = socket.ReceiveTimeout;
            socket.ReceiveTimeout = 1;
            try
            {
                int byteCount;
                do
                {
                    byteCount = socket.ReceiveFrom(raw_buf, SocketFlags.None, ref endPoint);
                }
                while (0 < byteCount);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            socket.ReceiveTimeout = timeout;
            recvsize = 0;
            readsize = 0;
        }

        private const int UDPMSGSIZE = 2000;

        private Socket socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
        private EndPoint endPoint = (EndPoint)new IPEndPoint(IPAddress.IPv6Any, 0);

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
            socket.Connect(endPoint);
        }
        public void Destroy()
        {
            socket.Close();
        }
    }
}