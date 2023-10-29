using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Vxi11Net
{
    public class ServerHislip
    {
        public static ushort HostToNetworkOrderUInt16(ushort v)
        {
            ushort u = 0;
            u += (ushort)((v & 0x00FF) << 8);
            u += (ushort)((v & 0xFF00) >> 8);
            return u;
        }
        public static uint HostToNetworkOrderUInt32(uint v)
        {
            uint u = 0;
            u += ((v & 0x000000FF) << 24);
            u += ((v & 0x0000FF00) << 8);
            u += ((v & 0x00FF0000) >> 8);
            u += ((v & 0xFF000000) >> 24);
            return u;
        }
        public static ulong HostToNetworkOrderUInt64(ulong v)
        {
            ulong u = 0;
            u += ((v & 0x00000000000000FF) << 56);
            u += ((v & 0x000000000000FF00) << 40);
            u += ((v & 0x0000000000FF0000) << 24);
            u += ((v & 0x00000000FF000000) << 8);
            u += ((v & 0x000000FF00000000) >> 8);
            u += ((v & 0x0000FF0000000000) >> 24);
            u += ((v & 0x00FF000000000000) >> 40);
            u += ((v & 0xFF00000000000000) >> 56);
            return u;
        }
        public int ReplyInitializeResponse(Socket socket, byte control, ushort ServerVersion, ushort SessionID)
        {
            Hislip.InitializeResponse reply = new Hislip.InitializeResponse();
            reply.Prologue0 = 'H';
            reply.Prologue1 = 'S';
            reply.MessageType = Hislip.InitializeResponse_;
            reply.ControlCode = control;
            reply.Protocol = HostToNetworkOrderUInt16(ServerVersion);
            reply.SessionID = HostToNetworkOrderUInt16(SessionID);
            reply.PayloadLength = 0;
            int size = Marshal.SizeOf(typeof(Hislip.InitializeResponse));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            socket.Send(packet);
            return 0;
        }
        public int ReplyAsyncInitializeResponse(Socket socket, byte control, ushort VendorID)
        {
            Hislip.AsyncInitializeResponse reply = new Hislip.AsyncInitializeResponse();
            reply.Prologue0 = 'H';
            reply.Prologue1 = 'S';
            reply.MessageType = Hislip.AsyncInitializeResponse_;
            reply.ControlCode = control;
            reply.dummy = 0;
            reply.ServerID = HostToNetworkOrderUInt16(VendorID);   
            reply.PayloadLength = 0;
            int size = Marshal.SizeOf(typeof(Hislip.AsyncInitializeResponse));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            socket.Send(packet);
            return 0;
        }
        public int ReplyFatalError(Socket socket, byte control, string message)
        {
            byte[] array = System.Text.Encoding.ASCII.GetBytes(message);
            Hislip.Data reply = new Hislip.Data();
            reply.Prologue0 = 'H';
            reply.Prologue1 = 'S';
            reply.MessageType = Hislip.FatalError;
            reply.ControlCode = control;
            reply.MessageID = 0;
            reply.PayloadLength = HostToNetworkOrderUInt64((ulong)array.Length);
            int size = Marshal.SizeOf(typeof(Hislip.Message))+ array.Length;
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(array, 0, packet, Marshal.SizeOf(typeof(Hislip.Message)), array.Length);
            gchw.Free();
            socket.Send(packet);
            return 0;
        }
        public int ReplyError(Socket socket, byte control, string message)
        {
            byte[] array = System.Text.Encoding.ASCII.GetBytes(message);
            Hislip.Data reply = new Hislip.Data();
            reply.Prologue0 = 'H';
            reply.Prologue1 = 'S';
            reply.MessageType = Hislip.Error;
            reply.ControlCode = control;
            reply.MessageID = 0;
            reply.PayloadLength = HostToNetworkOrderUInt64((ulong)array.Length);
            int size = Marshal.SizeOf(typeof(Hislip.Message)) + array.Length;
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(array, 0, packet, Marshal.SizeOf(typeof(Hislip.Message)), array.Length);
            gchw.Free();
            socket.Send(packet);
            return 0;
        }
        public int ReplyAsyncLockResponse(Socket socket, byte control)
        {
            Hislip.AsyncLockResponse reply = new Hislip.AsyncLockResponse();
            reply.Prologue0 = 'H';
            reply.Prologue1 = 'S';
            reply.MessageType = Hislip.AsyncLockResponse_;
            reply.ControlCode = control;
            reply.MessageParameter = 0;
            reply.PayloadLength = 0;
            int size = Marshal.SizeOf(typeof(Hislip.AsyncLockResponse));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            socket.Send(packet);
            return 0;
        }
        public int DataTransfer(Socket socket, byte control, uint messageID, byte[] message)
        {
            Hislip.Data reply = new Hislip.Data();
            reply.Prologue0 = 'H';
            reply.Prologue1 = 'S';
            reply.MessageType = Hislip.Data_;
            reply.ControlCode = control;
            reply.MessageID = HostToNetworkOrderUInt32(messageID);
            reply.PayloadLength = HostToNetworkOrderUInt64((ulong)message.Length);
            int size = Marshal.SizeOf(typeof(Hislip.Message))+ message.Length;
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(message, 0, packet, Marshal.SizeOf(typeof(Hislip.Message)), message.Length);
            gchw.Free();
            socket.Send(packet);
            return 0;
        }
        public int DataEndTransfer(Socket socket, byte control, uint messageID, byte[] message)
        {
            Hislip.Data reply = new Hislip.Data();
            reply.Prologue0 = 'H';
            reply.Prologue1 = 'S';
            reply.MessageType = Hislip.DataEnd;
            reply.ControlCode = control;
            reply.MessageID = HostToNetworkOrderUInt32(messageID);
            reply.PayloadLength = HostToNetworkOrderUInt64((ulong)message.Length);
            int size = Marshal.SizeOf(typeof(Hislip.Message))+ message.Length;
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(message, 0, packet, Marshal.SizeOf(typeof(Hislip.Message)), message.Length);
            gchw.Free();
            socket.Send(packet);
            return 0;
        }
        public int ReplyAsyncDeviceClearAcknowledge(Socket socket, byte feature)
        {
            Hislip.Message reply = new Hislip.Message();
            reply.Prologue0 = 'H';
            reply.Prologue1 = 'S';
            reply.MessageType = Hislip.AsyncDeviceClearAcknowledge;
            reply.ControlCode = feature;
            reply.MessageParameter = 0;
            reply.PayloadLength = 0;
            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            socket.Send(packet);
            return 0;
        }
        public int ReplyDeviceClearAcknowledge(Socket socket, byte feature)
        {
            Hislip.Message reply = new Hislip.Message();
            reply.Prologue0 = 'H';
            reply.Prologue1 = 'S';
            reply.MessageType = Hislip.DeviceClearAcknowledge;
            reply.ControlCode = feature;
            reply.MessageParameter = 0;
            reply.PayloadLength = 0;
            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            socket.Send(packet);
            return 0;
        }
        public int Interrupted(Socket socket, uint messageID)
        {
            Hislip.Data reply = new Hislip.Data();
            reply.Prologue0 = 'H';
            reply.Prologue1 = 'S';
            reply.MessageType = Hislip.Interrupted;
            reply.ControlCode = 0;
            reply.MessageID = HostToNetworkOrderUInt32(messageID);
            reply.PayloadLength = 0;
            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            socket.Send(packet);
            return 0;
        }
        public int AsyncInterrupted(Socket socket, uint messageID)
        {
            Hislip.Data reply = new Hislip.Data();
            reply.Prologue0 = 'H';
            reply.Prologue1 = 'S';
            reply.MessageType = Hislip.AsyncInterrupted;
            reply.ControlCode = 0;
            reply.MessageID = HostToNetworkOrderUInt32(messageID);
            reply.PayloadLength = 0;
            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            socket.Send(packet);
            return 0;
        }
        public int ReplyAsyncMaximumMessageSizeResponse(Socket socket, long MaximumMessageSize)
        {
            byte[] array = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(MaximumMessageSize));
            Hislip.Data reply = new Hislip.Data();
            reply.Prologue0 = 'H';
            reply.Prologue1 = 'S';
            reply.MessageType = Hislip.AsyncMaximumMessageSizeResponse;
            reply.ControlCode = 0;
            reply.MessageID = 0;
            reply.PayloadLength = HostToNetworkOrderUInt64((ulong)array.Length);
            int size = Marshal.SizeOf(typeof(Hislip.Message))+ array.Length;
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(array, 0, packet, Marshal.SizeOf(typeof(Hislip.Message)), array.Length);
            gchw.Free();
            socket.Send(packet);
            return 0;
        }
        public int ReplyAsyncRemoteLocalResponse(Socket socket)
        {
            Hislip.Message reply = new Hislip.Message();
            reply.Prologue0 = 'H';
            reply.Prologue1 = 'S';
            reply.MessageType = Hislip.AsyncRemoteLocalResponse;
            reply.ControlCode = 0;
            reply.MessageParameter = 0;
            reply.PayloadLength = 0;
            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            socket.Send(packet);
            return 0;
        }
        public int ReplyAsyncStatusResponse(Socket socket, byte status)
        {
            Hislip.Message reply = new Hislip.Message();
            reply.Prologue0 = 'H';
            reply.Prologue1 = 'S';
            reply.MessageType = Hislip.AsyncStatusResponse;
            reply.ControlCode = status;
            reply.MessageParameter = 0;
            reply.PayloadLength = 0;
            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            socket.Send(packet);
            return 0;
        }
        public int ReplyAsyncLockInfoResponse(Socket socket, byte control)
        {
            Hislip.Message reply = new Hislip.Message();
            reply.Prologue0 = 'H';
            reply.Prologue1 = 'S';
            reply.MessageType = Hislip.AsyncLockInfoResponse;
            reply.ControlCode = control;
            reply.MessageParameter = 0;
            reply.PayloadLength = 0;
            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            socket.Send(packet);
            return 0;
        }
        public static uint NetworkToHostOrderToUInt32(byte[] array, int index)
        {
            uint u = (uint)array[index] << 24;
            u += (uint)array[index + 1] << 16;
            u += (uint)array[index + 2] << 8;
            u += (uint)array[index + 3];
            return u;
        }
        public static ulong NetworkToHostOrderToUInt64(byte[] array, int index)
        {
            ulong u = (ulong)array[index] << 58;
            u += (ulong)array[index + 1] << 48;
            u += (ulong)array[index + 2] << 40;
            u += (ulong)array[index + 3] << 32;
            u += (ulong)array[index + 4] << 24;
            u += (ulong)array[index + 5] << 16;
            u += (ulong)array[index + 6] << 8;
            u += (ulong)array[index + 7];
            return u;
        }
        public Hislip.Data ReceiveMsg(Socket socket)
        {
            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] buffer = new byte[size];
            int bytes = socket.Receive(buffer, 0, size, SocketFlags.None);
            Hislip.Data call = new Hislip.Data();
            call.Prologue0 = (char)buffer[0];
            call.Prologue1 = (char)buffer[1];
            call.MessageType = buffer[2];
            call.ControlCode = buffer[3];
            call.MessageID = NetworkToHostOrderToUInt32(buffer, 4);
            call.PayloadLength = NetworkToHostOrderToUInt64(buffer, 8);
            return call;
        }
        public string ReceiveString(Socket socket, ulong size)
        {
            byte[] buffer = ReceiveData(socket, size);
            string data = System.Text.Encoding.ASCII.GetString(buffer);
            return data;
        }
        public byte[] ReceiveData(Socket socket, ulong size)
        {
            byte[] buffer = new byte[size];
            int bytes = socket.Receive(buffer, 0, buffer.Length, SocketFlags.None);
            return buffer;
        }
        internal void Flush(Socket socket)
        {
            int timeout = socket.ReceiveTimeout;
            try
            {
                socket.ReceiveTimeout = 1;
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
        internal void Create(string ipString, int port)
        {
            // get IP address from IPv4 address string
            IPAddress ipAddress = IPAddress.Parse(ipString);
            endPoint = new IPEndPoint(ipAddress, port);
            server = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(endPoint);
            server.Listen();
        }
        private Socket ChannelThread(Socket server, Socket socket)
        {
            try
            {
                Console.WriteLine("  == Wait RPC ==");
                Hislip.Data call = ReceiveMsg(socket);
                Console.WriteLine("    received HiSLIP synchronous channel.");
                Console.WriteLine("      Prologue0 = {0}", call.Prologue0);
                Console.WriteLine("      Prologue1 = {0}", call.Prologue1);
                Console.WriteLine("      MessageType = {0}", call.MessageType);
                Console.WriteLine("      ControlCode = {0}", call.ControlCode);
                Console.WriteLine("      MessageParameter = {0}", call.MessageID);
                Console.WriteLine("      PayloadLength = {0}", call.PayloadLength);
                if ((call.Prologue0 != 'H') || (call.Prologue1 != 'S'))
                {
                    socket.Close();
                }
                else if (call.MessageType == Hislip.Initialize_)
                {
                    Console.WriteLine("  == Initialize ==");
                    string data = ReceiveString(socket, call.PayloadLength);
                    ReplyInitializeResponse(socket, 0, Hislip.ServerVersion, SessionID);
                }
                if (call.MessageType == Hislip.AsyncInitialize)
                {
                    Console.WriteLine("  == AsyncInitialize ==");
                    ReplyAsyncInitializeResponse(socket, 0, Hislip.VendorID);
                }
                else if (call.MessageType == Hislip.FatalError)
                {
                    Console.WriteLine("  == FatalError ==");
                    string data = ReceiveString(socket, call.PayloadLength);
                }
                else if (call.MessageType == Hislip.Error)
                {
                    Console.WriteLine("  == Error ==");
                    string data = ReceiveString(socket, call.PayloadLength);
                }
                else if (call.MessageType == Hislip.Data_)
                {
                    Console.WriteLine("  == Data ==");
                    MessageID = call.MessageID;
                    IsRMTwasDelivered = Hislip.RMTwasNotDelivered;
                    byte[] data = ReceiveData(socket, call.PayloadLength);
                    serverScpi.bav(data);
                    if (serverScpi.IsMav())
                    {
                        byte[] reply = serverScpi.GetResponse();
                        DataTransfer(socket, IsRMTwasDelivered, MessageID, reply);
                    }
                }
                else if (call.MessageType == Hislip.DataEnd)
                {
                    Console.WriteLine("  == DataEnd ==");
                    MessageID = call.MessageID;
                    IsRMTwasDelivered = Hislip.RMTwasDelivered;
                    byte[] data = ReceiveData(socket, call.PayloadLength);
                    serverScpi.bav(data);
                    serverScpi.RMT_sent();
                    if (serverScpi.IsMav())
                    {
                        byte[] reply = serverScpi.GetResponse();
                        DataEndTransfer(socket, Hislip.RMTwasDelivered, MessageID, reply);
                    }
                }
                else if (call.MessageType == Hislip.AsyncLock)
                {
                    Console.WriteLine("  == AsyncLock ==");
                    if (call.ControlCode == Hislip.LockRequest)
                    {
                        if (call.PayloadLength > 0)
                        {
                            string data = ReceiveString(socket, call.PayloadLength);
                        }
                        ReplyAsyncLockResponse(socket, Hislip.LockSuccess);
                    }
                    else
                    {
                        ReplyAsyncLockResponse(socket, Hislip.UnlockSuccessShared);
                    }
                }
                else if (call.MessageType == Hislip.AsyncDeviceClear)
                {
                    Console.WriteLine("  == AsyncDeviceClear ==");
                    serverScpi.dcas();
                    ReplyAsyncDeviceClearAcknowledge(socket, Hislip.SynchronizedMode);
                }
                else if (call.MessageType == Hislip.DeviceClearComplete)
                {
                    Console.WriteLine("  == DeviceClearComplete ==");
                    ReplyDeviceClearAcknowledge(socket, Hislip.SynchronizedMode);
                }
                else if (call.MessageType == Hislip.Trigger)
                {
                    Console.WriteLine("  == Trigger ==");
                    MessageID = call.MessageID;
                    IsRMTwasDelivered = Hislip.RMTwasDelivered;
                    serverScpi.get();
                }
                else if (call.MessageType == Hislip.AsyncMaximumMessageSize)
                {
                    Console.WriteLine("  == AsyncMaximumMessageSize ==");
                    string data = ReceiveString(socket, call.PayloadLength);
                    long size = serverScpi.GetMaxRecvSize();
                    ReplyAsyncMaximumMessageSizeResponse(socket, size);
                }
                else if (call.MessageType == Hislip.AsyncRemoteLocalControl)
                {
                    Console.WriteLine("  == AsyncRemoteLocalControl ==");
                    ReplyAsyncRemoteLocalResponse(socket);
                }
                else if (call.MessageType == Hislip.AsyncStatusQuery)
                {
                    Console.WriteLine("  == AsyncStatusQuery ==");
                    byte stb = serverScpi.stb();
                    ReplyAsyncStatusResponse(socket, stb);
                }
                else if (call.MessageType == Hislip.AsyncLockInfo)
                {
                    Console.WriteLine("  == AsyncLockInfo ==");
                    ReplyAsyncLockInfoResponse(socket, lockCount);
                }
                else
                {
                    Console.WriteLine("  == clear buffer ==");
                }
            }
            catch (Exception)
            {
            }
            return socket;
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
                    if (synchronous.Connected == false)
                    {
                        synchronous = server.Accept();
                    }
                    ChannelThread(server, synchronous);
                    count--;
                }
            });
            Task.Run(() =>
            {
                while ((0 < count) && (!tokenSource.Token.IsCancellationRequested))
                {
                    while (synchronous.Connected == false)
                    {
                        Thread.Sleep(100);
                    }
                    if (asynchronous.Connected == false)
                    {
                        asynchronous = server.Accept();
                    }
                    ChannelThread(server, asynchronous);
                    count--;
                }
            });
            Thread.Sleep(10);
        }

        IPEndPoint endPoint = new IPEndPoint(IPAddress.IPv6Any, 0);

        private Socket server = new Socket(SocketType.Stream, ProtocolType.Tcp);
        private Socket synchronous = new Socket(SocketType.Stream, ProtocolType.Tcp);
        private Socket asynchronous = new Socket(SocketType.Stream, ProtocolType.Tcp);
        private ServerScpi serverScpi = new ServerScpi();
        private CancellationTokenSource tokenSource = new CancellationTokenSource();
        private ushort SessionID = 123;
        private uint MessageID = 123;
        private byte IsRMTwasDelivered = Hislip.RMTwasNotDelivered;
        private byte lockCount = 0;

        public void Destroy()
        {
            server.Close();
            synchronous.Close();
            asynchronous.Close();
        }
    }

}