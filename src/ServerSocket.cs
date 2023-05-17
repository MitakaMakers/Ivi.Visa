using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Vxi11Net
{
    public class ServerSocket
    {
        public int SendMsg(byte[] msg)
        {
            byte[] buffer = new byte[msg.Length+2];
            Buffer.BlockCopy(msg, 0, buffer, 0, msg.Length);
            buffer[msg.Length] = (byte)'\r';
            buffer[msg.Length+1] = (byte)'\n';
            int bytes = socket.Send(buffer, 0, buffer.Length, SocketFlags.None);
            return bytes;
        }
        public byte[] ReceiveMsg(int size)
        {
            if (socket.Connected == false)
            {
                socket = server.Accept();
            }
            byte[] buffer = new byte[size];
            int i = 0;
            for (i = 0; i < buffer.Length; i++)
            {
                socket.Receive(buffer, i, 1, SocketFlags.None);
                if (buffer[i] == 0x0a)
                {
                    break;
                }
            }
            byte[] recv = new byte[i];
            Buffer.BlockCopy(buffer, 0, recv, 0, i);
            return recv;
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

        private void CoreThread()
        {
            try
            {
                Console.WriteLine("  == Wait Message ==");
                byte[] data = ReceiveMsg(serverScpi.GetMaxRecvSize());
                Console.WriteLine("    received socket command.");
                Console.WriteLine("      size    = {0}", data.Length);
                serverScpi.bav(data);
                serverScpi.RMT_sent();
                if (serverScpi.IsMav())
                {
                    byte[] reply = serverScpi.GetResponse();
                    SendMsg(reply);
                }
            }
            catch (Exception)
            {
                socket.Close();
            }
        }
        public void RunThread(string host, int port, int count)
        {
            tokenSource.TryReset();
            Console.WriteLine("== Run Socket server(TCP, {0}, {1}) ==", host, port);
            Create(host, port);
            Console.WriteLine("  listen({0}:{1})...", host, port);
            Task.Run(() =>
            {

                while ((0 < count) && (!tokenSource.Token.IsCancellationRequested))
                {
                    CoreThread();
                    count--;
                }
            });
            Thread.Sleep(10);
        }

        private Socket server = new Socket(SocketType.Stream, ProtocolType.Tcp);
        private Socket socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
        private ServerScpi serverScpi = new ServerScpi();
        private CancellationTokenSource tokenSource = new CancellationTokenSource();

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