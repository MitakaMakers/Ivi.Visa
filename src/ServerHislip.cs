using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Vxi11Net
{
    public class ServerHislip
    {
        public int ReplyInitialization(string host)
        {
            s.Create(host, Hislip.PORT);
            Hislip.MessageHeader msg = new Hislip.MessageHeader();
            msg.Prologue0 = 'H';
            msg.Prologue1 = 'S';
            msg.MessageType = Hislip.Initialize;
            msg.ControlCode = 0;
            msg.MessageParameter = 0;
            msg.PayloadLength = 0;
            msg.Data = 0;

            int size = Marshal.SizeOf(typeof(Hislip.MessageHeader));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(msg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            s.Send(packet);

            byte[] buffer = new byte[size];
            s.Receive(buffer);

            s.Create(host, Hislip.PORT);
            msg.Prologue0 = 'H';
            msg.Prologue1 = 'S';
            msg.MessageType = Hislip.AsyncInitialize;
            msg.ControlCode = 0;
            msg.MessageParameter = 0;
            msg.PayloadLength = 0;
            msg.Data = 0;

            size = Marshal.SizeOf(typeof(Hislip.MessageHeader));
            packet = new byte[size];
            gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(msg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            a.Send(packet);

            buffer = new byte[size];
            a.Receive(buffer);

            return 0;
        }
        public int FatalErrorNotification()
        {
            Hislip.MessageHeader msg = new Hislip.MessageHeader();
            msg.Prologue0 = 'H';
            msg.Prologue1 = 'S';
            msg.MessageType = Hislip.FatalError;
            msg.ControlCode = 0;
            msg.MessageParameter = 0;   
            msg.PayloadLength = 0;
            msg.Data = 0;

            int size = Marshal.SizeOf(typeof(Hislip.MessageHeader));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(msg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            s.Send(packet);
            return 0;
        }
        public int ErrorNotification()
        {
            Hislip.MessageHeader msg = new Hislip.MessageHeader();
            msg.Prologue0 = 'H';
            msg.Prologue1 = 'S';
            msg.MessageType = Hislip.Error;
            msg.ControlCode = 0;
            msg.MessageParameter = 0;
            msg.PayloadLength = 0;
            msg.Data = 0;

            int size = Marshal.SizeOf(typeof(Hislip.MessageHeader));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(msg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            s.Send(packet);
            return 0;
        }
        public int DataTransfer()
        {
            Hislip.MessageHeader msg = new Hislip.MessageHeader();
            msg.Prologue0 = 'H';
            msg.Prologue1 = 'S';
            msg.MessageType = Hislip.DataEnd;
            msg.ControlCode = 0;
            msg.MessageParameter = 0;
            msg.PayloadLength = 0;
            msg.Data = 0;

            int size = Marshal.SizeOf(typeof(Hislip.MessageHeader));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(msg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            s.Send(packet);
            return 0;
        }
        public int ReplyLock()
        {
            Hislip.MessageHeader msg = new Hislip.MessageHeader();
            msg.Prologue0 = 'H';
            msg.Prologue1 = 'S';
            msg.MessageType = Hislip.AsyncLock;
            msg.ControlCode = 0;
            msg.MessageParameter = 0;
            msg.PayloadLength = 0;
            msg.Data = 0;

            int size = Marshal.SizeOf(typeof(Hislip.MessageHeader));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(msg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            a.Send(packet);

            byte[] buffer = new byte[size];
            a.Receive(buffer);
            return 0;
        }
        public int ReplyReleaseLock()
        {
            Hislip.MessageHeader msg = new Hislip.MessageHeader();
            msg.Prologue0 = 'H';
            msg.Prologue1 = 'S';
            msg.MessageType = Hislip.AsyncLock;
            msg.ControlCode = 0;
            msg.MessageParameter = 0;
            msg.PayloadLength = 0;
            msg.Data = 0;

            int size = Marshal.SizeOf(typeof(Hislip.MessageHeader));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(msg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            a.Send(packet);

            byte[] buffer = new byte[size];
            a.Receive(buffer);
            return 0;
        }
        public int ReplyLockInfo()
        {
            Hislip.MessageHeader msg = new Hislip.MessageHeader();
            msg.Prologue0 = 'H';
            msg.Prologue1 = 'S';
            msg.MessageType = Hislip.AsyncLockInfo;
            msg.ControlCode = 0;
            msg.MessageParameter = 0;
            msg.PayloadLength = 0;
            msg.Data = 0;

            int size = Marshal.SizeOf(typeof(Hislip.MessageHeader));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(msg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            a.Send(packet);

            byte[] buffer = new byte[size];
            a.Receive(buffer);
            return 0;
        }
        public int ReplyRemote()
        {
            Hislip.MessageHeader msg = new Hislip.MessageHeader();
            msg.Prologue0 = 'H';
            msg.Prologue1 = 'S';
            msg.MessageType = Hislip.AsyncRemoteLocalControl;
            msg.ControlCode = 0;
            msg.MessageParameter = 0;
            msg.PayloadLength = 0;
            msg.Data = 0;

            int size = Marshal.SizeOf(typeof(Hislip.MessageHeader));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(msg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            a.Send(packet);

            byte[] buffer = new byte[size];
            a.Receive(buffer);
            return 0;
        }
        public int ReplyLocal()
        {
            Hislip.MessageHeader msg = new Hislip.MessageHeader();
            msg.Prologue0 = 'H';
            msg.Prologue1 = 'S';
            msg.MessageType = Hislip.AsyncRemoteLocalControl;
            msg.ControlCode = 0;
            msg.MessageParameter = 0;
            msg.PayloadLength = 0;
            msg.Data = 0;

            int size = Marshal.SizeOf(typeof(Hislip.MessageHeader));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(msg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            a.Send(packet);

            byte[] buffer = new byte[size];
            a.Receive(buffer);
            return 0;
        }
        public int Trigger()
        {
            Hislip.MessageHeader msg = new Hislip.MessageHeader();
            msg.Prologue0 = 'H';
            msg.Prologue1 = 'S';
            msg.MessageType = Hislip.Trigger;
            msg.ControlCode = 0;
            msg.MessageParameter = 0;
            msg.PayloadLength = 0;
            msg.Data = 0;

            int size = Marshal.SizeOf(typeof(Hislip.MessageHeader));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(msg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            s.Send(packet);
            return 0;
        }
        public int ReplyMaximumMessageSize()
        {
            Hislip.MessageHeader msg = new Hislip.MessageHeader();
            msg.Prologue0 = 'H';
            msg.Prologue1 = 'S';
            msg.MessageType = Hislip.AsyncMaximumMessageSize;
            msg.ControlCode = 0;
            msg.MessageParameter = 0;
            msg.PayloadLength = 0;
            msg.Data = 0;

            int size = Marshal.SizeOf(typeof(Hislip.MessageHeader));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(msg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            a.Send(packet);

            byte[] buffer = new byte[size];
            a.Receive(buffer);
            return 0;
        }
        public int ReplyDeviceClear()
        {
            Hislip.MessageHeader msg = new Hislip.MessageHeader();
            msg.Prologue0 = 'H';
            msg.Prologue1 = 'S';
            msg.MessageType = Hislip.AsyncDeviceClear;
            msg.ControlCode = 0;
            msg.MessageParameter = 0;
            msg.PayloadLength = 0;
            msg.Data = 0;

            int size = Marshal.SizeOf(typeof(Hislip.MessageHeader));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(msg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            a.Send(packet);

            byte[] buffer = new byte[size];
            a.Receive(buffer);

            msg.Prologue0 = 'H';
            msg.Prologue1 = 'S';
            msg.MessageType = Hislip.DeviceClearComplete;
            msg.ControlCode = 0;
            msg.MessageParameter = 0;
            msg.PayloadLength = 0;
            msg.Data = 0;

            size = Marshal.SizeOf(typeof(Hislip.MessageHeader));
            packet = new byte[size];
            gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(msg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            s.Send(packet);

            buffer = new byte[size];
            a.Receive(buffer);

            return 0;
        }
        public int ReplyStatusQuery()
        {
            Hislip.MessageHeader msg = new Hislip.MessageHeader();
            msg.Prologue0 = 'H';
            msg.Prologue1 = 'S';
            msg.MessageType = Hislip.AsyncStatusQuery;
            msg.ControlCode = 0;
            msg.MessageParameter = 0;
            msg.PayloadLength = 0;
            msg.Data = 0;

            int size = Marshal.SizeOf(typeof(Hislip.MessageHeader));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(msg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            a.Send(packet);

            byte[] buffer = new byte[size];
            a.Receive(buffer);
            return 0;
        }

        ServerSynchronousChannel s = new ServerSynchronousChannel();
        ServerAsynchronousChannel a = new ServerAsynchronousChannel();
        private uint MessageID = 0xfffffefe;
        private uint GetMessageID()
        {
            uint _MessageID = MessageID;
            MessageID = MessageID + 1;
            return _MessageID;
        }
        public void Create(string host)
        {
        }
        public void Destroy()
        {
            s.Destroy();
            a.Destroy();
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