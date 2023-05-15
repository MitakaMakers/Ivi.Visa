using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Vxi11Net
{
    public class ServerHislip
    {
        public int ReplyInitializeResponse(byte control, short protocol, short SessionID)
        {
            Hislip.InitializeResponse reply = new Hislip.InitializeResponse();
            reply.Prologue0 = 'H';
            reply.Prologue1 = 'S';
            reply.MessageType = Hislip.InitializeResponse_;
            reply.ControlCode = control;
            reply.Protocol = protocol;
            reply.SessionID = SessionID;
            reply.PayloadLength = 0;

            int size = Marshal.SizeOf(typeof(Hislip.InitializeResponse));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            s.Send(packet);
            return 0;
        }
        public int ReplyAsyncInitializeResponse(byte control, short ServerID)
        {
            Hislip.AsyncInitializeResponse reply = new Hislip.AsyncInitializeResponse();
            reply.Prologue0 = 'H';
            reply.Prologue1 = 'S';
            reply.MessageType = Hislip.AsyncInitializeResponse_;
            reply.ControlCode = control;
            reply.dummy = 0;
            reply.ServerID = ServerID;   
            reply.PayloadLength = 0;

            int size = Marshal.SizeOf(typeof(Hislip.AsyncInitializeResponse));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            s.Send(packet);
            return 0;
        }
        public int ReplyFatalError(byte control, string message)
        {
            Hislip.Message reply = new Hislip.Message();
            reply.Prologue0 = 'H';
            reply.Prologue1 = 'S';
            reply.MessageType = Hislip.FatalError;
            reply.ControlCode = control;
            reply.MessageParameter = 0;
            reply.PayloadLength = (ulong)message.Length;

            int size = Marshal.SizeOf(typeof(Hislip.Message))+message.Length;
            byte[] packet = new byte[size];
            byte[] array = System.Text.Encoding.ASCII.GetBytes(message);
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(array, 0, packet, Marshal.SizeOf(typeof(Hislip.Message)), array.Length);
            gchw.Free();
            s.Send(packet);
            return 0;
        }
        public int ReplyErrorr(byte control, string message)
        {
            Hislip.Message reply = new Hislip.Message();
            reply.Prologue0 = 'H';
            reply.Prologue1 = 'S';
            reply.MessageType = Hislip.Error;
            reply.ControlCode = control;
            reply.MessageParameter = 0;
            reply.PayloadLength = (ulong)message.Length;

            int size = Marshal.SizeOf(typeof(Hislip.Message)) + message.Length;
            byte[] packet = new byte[size];
            byte[] array = System.Text.Encoding.ASCII.GetBytes(message);
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(array, 0, packet, Marshal.SizeOf(typeof(Hislip.Message)), array.Length);
            gchw.Free();
            s.Send(packet);
            return 0;
        }
        public int ReplyAsyncLockResponse(byte control)
        {
            Hislip.AsyncLockResponse msg = new Hislip.AsyncLockResponse();
            msg.Prologue0 = 'H';
            msg.Prologue1 = 'S';
            msg.MessageType = Hislip.AsyncLockResponse_;
            msg.ControlCode = control;
            msg.MessageParameter = 0;
            msg.PayloadLength = 0;

            int size = Marshal.SizeOf(typeof(Hislip.AsyncLockResponse));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(msg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            s.Send(packet);
            return 0;
        }
        public int DataTransfer(byte control, int messageID, string message)
        {
            Hislip.Message msg = new Hislip.Message();
            msg.Prologue0 = 'H';
            msg.Prologue1 = 'S';
            msg.MessageType = Hislip.Data;
            msg.ControlCode = control;
            msg.MessageParameter = messageID;
            msg.PayloadLength = (ulong)message.Length;

            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            byte[] array = System.Text.Encoding.ASCII.GetBytes(message);
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(msg, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(array, 0, packet, Marshal.SizeOf(typeof(Hislip.Message)), array.Length);
            gchw.Free();
            s.Send(packet);
            return 0;
        }
        public int DataEndTransfer(byte control, int messageID, string message)
        {
            Hislip.Message msg = new Hislip.Message();
            msg.Prologue0 = 'H';
            msg.Prologue1 = 'S';
            msg.MessageType = Hislip.DataEnd;
            msg.ControlCode = control;
            msg.MessageParameter = messageID;
            msg.PayloadLength = (ulong)message.Length;

            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            byte[] array = System.Text.Encoding.ASCII.GetBytes(message);
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(msg, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(array, 0, packet, Marshal.SizeOf(typeof(Hislip.Message)), array.Length);
            gchw.Free();
            s.Send(packet);
            return 0;
        }
        public int ReplyAsyncDeviceClearAcknowledge(byte feature)
        {
            Hislip.Message msg = new Hislip.Message();
            msg.Prologue0 = 'H';
            msg.Prologue1 = 'S';
            msg.MessageType = Hislip.AsyncDeviceClearAcknowledge;
            msg.ControlCode = feature;
            msg.MessageParameter = 0;
            msg.PayloadLength = 0;

            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(msg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            s.Send(packet);
            return 0;
        }
        public int ReplyDeviceClearAcknowledge(byte feature)
        {
            Hislip.Message msg = new Hislip.Message();
            msg.Prologue0 = 'H';
            msg.Prologue1 = 'S';
            msg.MessageType = Hislip.DeviceClearAcknowledge;
            msg.ControlCode = feature;
            msg.MessageParameter = 0;
            msg.PayloadLength = 0;

            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(msg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            s.Send(packet);
            return 0;
        }
        public int ReplyAsyncMaximumMessageSizeResponse()
        {
            Hislip.Message msg = new Hislip.Message();
            msg.Prologue0 = 'H';
            msg.Prologue1 = 'S';
            msg.MessageType = Hislip.AsyncMaximumMessageSizeResponse;
            msg.ControlCode = 0;
            msg.MessageParameter = 0;
            msg.PayloadLength = 0;

            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(msg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            a.Send(packet);
            return 0;
        }
        public int ReplyAsyncRemoteLocalResponse()
        {
            Hislip.Message msg = new Hislip.Message();
            msg.Prologue0 = 'H';
            msg.Prologue1 = 'S';
            msg.MessageType = Hislip.AsyncRemoteLocalResponse;
            msg.ControlCode = 0;
            msg.MessageParameter = 0;
            msg.PayloadLength = 0;

            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(msg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            a.Send(packet);
            return 0;
        }
        public int ReplyAsyncStatusResponse(byte status)
        {
            Hislip.Message msg = new Hislip.Message();
            msg.Prologue0 = 'H';
            msg.Prologue1 = 'S';
            msg.MessageType = Hislip.AsyncStatusResponse;
            msg.ControlCode = status;
            msg.MessageParameter = 0;
            msg.PayloadLength = 0;

            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(msg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            a.Send(packet);
            return 0;
        }
        public int ReplyAsyncLockInfoResponse(byte control)
        {
            Hislip.Message msg = new Hislip.Message();
            msg.Prologue0 = 'H';
            msg.Prologue1 = 'S';
            msg.MessageType = Hislip.AsyncLockInfoResponse;
            msg.ControlCode = control;
            msg.MessageParameter = 0;
            msg.PayloadLength = 0;

            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(msg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            a.Send(packet);
            return 0;
        }

        private void CoreThread()
        {
            try
            {
                Console.WriteLine("  == Wait RPC ==");
                Hislip.Message msg = ReceiveMsg();
                Console.WriteLine("    received HiSLIP synchronous core channel.");
                Console.WriteLine("      Prologue0 = {0}", msg.Prologue0);
                Console.WriteLine("      Prologue1 = {0}", msg.Prologue1);
                Console.WriteLine("      MessageType = {0}", msg.MessageType);
                Console.WriteLine("      ControlCode = {0}", msg.ControlCode);
                Console.WriteLine("      MessageParameter = {0}", msg.MessageParameter);
                Console.WriteLine("      PayloadLength = {0}", msg.PayloadLength);
                if (msg.MessageType == Hislip.Initialize)
                {
                    Console.WriteLine("  == Initialize ==");
                    string data = ReceiveString(msg.PayloadLength);
                    ReplyInitializeResponse(0, 0, 0);

                }
                else if (msg.MessageType == Hislip.AsyncInitialize)
                {
                    Console.WriteLine("  == AsyncInitialize ==");
                    ReplyAsyncInitializeResponse(0,0);
                }
                else if (msg.MessageType == Hislip.FatalError)
                {
                    Console.WriteLine("  == FatalError ==");
                    string data = ReceiveString(msg.PayloadLength);
                }
                else if (msg.MessageType == Hislip.Error)
                {
                    Console.WriteLine("  == Error ==");
                    string data = ReceiveString(msg.PayloadLength);
                }
                else if (msg.MessageType == Hislip.AsyncLock)
                {
                    Console.WriteLine("  == AsyncLock ==");
                    string data = ReceiveString(msg.PayloadLength);
                    ReplyAsyncLockResponse(0);
                }
                else if (msg.MessageType == Hislip.Data)
                {
                    Console.WriteLine("  == Data ==");
                    string data = ReceiveString(msg.PayloadLength);
                    serverScpi.bav(data);
                }
                else if (msg.MessageType == Hislip.DataEnd)
                {
                    Console.WriteLine("  == DataEnd ==");
                    string data = ReceiveString(msg.PayloadLength);
                    serverScpi.bav(data);
                    serverScpi.RMT_sent();
                }
                else if (msg.MessageType == Hislip.AsyncDeviceClear)
                {
                    Console.WriteLine("  == AsyncDeviceClear ==");
                    ReplyAsyncDeviceClearAcknowledge(0);
                    serverScpi.dcas();
                }
                else if (msg.MessageType == Hislip.DeviceClearComplete)
                {
                    Console.WriteLine("  == DeviceClearComplete ==");
                    ReplyDeviceClearAcknowledge(0);
                }
                else if (msg.MessageType == Hislip.AsyncMaximumMessageSize)
                {
                    Console.WriteLine("  == AsyncMaximumMessageSize ==");
                    ReplyAsyncMaximumMessageSizeResponse();
                }
                else if (msg.MessageType == Hislip.AsyncRemoteLocalControl)
                {
                    Console.WriteLine("  == AsyncRemoteLocalControl ==");
                    ReplyAsyncRemoteLocalResponse();
                }
                else if (msg.MessageType == Hislip.Trigger)
                {
                    Console.WriteLine("  == Trigger ==");
                    serverScpi.get();
                }
                else if (msg.MessageType == Hislip.AsyncStatusQuery)
                {
                    Console.WriteLine("  == AsyncStatusQuery ==");
                    byte stb = serverScpi.stb();
                    ReplyAsyncStatusResponse(stb);
                }
                else if (msg.MessageType == Hislip.AsyncLockInfo)
                {
                    Console.WriteLine("  == AsyncLockInfo ==");
                    ReplyAsyncLockInfoResponse(0);
                }
                else
                {
                    Console.WriteLine("  == clear buffer ==");
                }
            }
            catch (Exception)
            {
            }
        }
        public Hislip.Message ReceiveMsg()
        {
            Hislip.Message msg = s.ReceiveMsg();
            return msg;
        }
        public string ReceiveString(ulong size)
        {
            string msg = s.ReceiveString(size);
            return msg;
        }
        public byte[] ReceiveData(ulong size)
        {
            byte[] msg = s.ReceiveData(size);
            return msg;
        }
        ServerSynchronousChannel s = new ServerSynchronousChannel();
        ServerAsynchronousChannel a = new ServerAsynchronousChannel();
        private ServerScpi serverScpi = new ServerScpi();
        private CancellationTokenSource tokenSource = new CancellationTokenSource();
        public void Create(string host, int port)
        {
        }
        public void Destroy()
        {
            s.Destroy();
            a.Destroy();
        }
        public void RunThread(string host, int port, int count)
        {
            tokenSource.TryReset();

            Console.WriteLine("== Run Hislip synchronous channel(TCP, {0}, {1}) ==", host, port);
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
    }
    internal class ServerSynchronousChannel
    {
        internal int Send(byte[] buffer)
        {
            int bytes = socket.Send(buffer, 0, buffer.Length, SocketFlags.None);
            return bytes;
        }
        internal int Receive(byte[] buffer)
        {
            int bytes = socket.Receive(buffer, 0, buffer.Length, SocketFlags.None);
            return bytes;
        }
        public Hislip.Message ReceiveMsg()
        {
            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] buffer = new byte[size];
            int bytes = socket.Receive(buffer, 0, size, SocketFlags.None);

            Hislip.Message msg = new Hislip.Message();
            msg.Prologue0 = (char)buffer[0];
            msg.Prologue1 = (char)buffer[1];
            msg.MessageType = buffer[2];
            msg.ControlCode = buffer[3];
            msg.MessageParameter = BitConverter.ToInt32(buffer, 4);
            msg.PayloadLength = BitConverter.ToUInt64(buffer, 8);
            return msg;
        }
        public string ReceiveString(ulong size)
        {
            byte[] buffer = new byte[size];
            int bytes = socket.Receive(buffer, 0, buffer.Length, SocketFlags.None);
            string data = System.Text.Encoding.ASCII.GetString(buffer);
            return data;
        }
        public byte[] ReceiveData(ulong size)
        {
            byte[] buffer = new byte[size];
            int bytes = socket.Receive(buffer, 0, buffer.Length, SocketFlags.None);
            return buffer;
        }
        internal void Flush()
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
        }

        private Socket socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint endPoint = new IPEndPoint(IPAddress.IPv6Any, 0);

        internal void Create(string ipString, int port)
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
        internal void Destroy()
        {
            socket.Close();
        }
    }
    internal class ServerAsynchronousChannel
    {
        internal int Send(byte[] buffer)
        {
            int bytes = socket.Send(buffer, 0, buffer.Length, SocketFlags.None);
            return bytes;
        }
        internal int Receive(byte[] buffer)
        {
            int bytes = socket.Receive(buffer, 0, buffer.Length, SocketFlags.None);
            return bytes;
        }
        internal void Flush()
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
        }

        private Socket socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint endPoint = new IPEndPoint(IPAddress.IPv6Any, 0);

        internal void Create(string ipString, int port)
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
        internal void Destroy()
        {
            socket.Close();
        }
    }

}