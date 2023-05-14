using System.Net;
using System.Net.Sockets;

namespace Vxi11Net
{
    public class ServerSocket
    {
        public int Send(byte[] buffer)
        {
            int bytes = socket.Send(buffer, 0, buffer.Length, SocketFlags.None);
            return bytes;
        }
        public int Receive(byte[] buffer)
        {
            int i = 0;
            for (i = 0; i < buffer.Length; i++)
            {
                socket.Receive(buffer, i, 1, SocketFlags.None);
                if (buffer[i] == 0x0a)
                {
                    break;
                }
            }
            return i;
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
            catch (Exception)
            {
            }
            socket.ReceiveTimeout = timeout;
        }

        private Socket server = new Socket(SocketType.Stream, ProtocolType.Tcp);
        private Socket socket = new Socket(SocketType.Stream, ProtocolType.Tcp);

        IPEndPoint endPoint = new IPEndPoint(IPAddress.IPv6Any, 0);

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
            server.Listen();
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
}