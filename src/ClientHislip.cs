using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Vxi11Net
{
    public class ClientHislip
    {
        internal static int Initialize(Socket socket, short clientVersion, short vendorID, string sub_address)
        {
            byte[] array = System.Text.Encoding.ASCII.GetBytes(sub_address);
            Hislip.Initialize call = new Hislip.Initialize();
            call.Prologue0 = 'H';
            call.Prologue1 = 'S';
            call.MessageType = Hislip.Initialize_;
            call.ControlCode = 0;
            call.Version = IPAddress.HostToNetworkOrder(clientVersion);
            call.VendorID = IPAddress.HostToNetworkOrder(vendorID);
            call.PayloadLength = IPAddress.HostToNetworkOrder((long)array.Length);
            int size = Marshal.SizeOf(typeof(Hislip.Initialize)) + array.Length;
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(call, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(array, 0, packet, Marshal.SizeOf(typeof(Hislip.Initialize)), array.Length);
            gchw.Free();
            socket.Send(packet);

            byte[] buffer = new byte[size];
            socket.Receive(buffer);
            Hislip.InitializeResponse reply = new Hislip.InitializeResponse();
            reply.Prologue0 = (char)buffer[0];
            reply.Prologue1 = (char)buffer[1];
            reply.MessageType = buffer[2];
            reply.ControlCode = buffer[3];
            reply.Protocol = (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(buffer, 4));
            reply.SessionID = (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(buffer, 6));
            reply.PayloadLength = IPAddress.NetworkToHostOrder(BitConverter.ToInt64(buffer, 8));
            return reply.SessionID;
        }
        internal static int AsyncInitialization(Socket socket, short sessionID)
        {
            Hislip.Message call = new Hislip.Message();
            call.Prologue0 = 'H';
            call.Prologue1 = 'S';
            call.MessageType = Hislip.AsyncInitialize;
            call.ControlCode = 0;
            call.MessageParameter = IPAddress.HostToNetworkOrder(sessionID);
            call.PayloadLength = 0;
            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(call, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            socket.Send(packet);

            byte[] buffer = new byte[size];
            socket.Receive(buffer);
            Hislip.AsyncInitializeResponse reply = new Hislip.AsyncInitializeResponse();
            reply.Prologue0 = (char)buffer[0];
            reply.Prologue1 = (char)buffer[1];
            reply.MessageType = buffer[2];
            reply.ControlCode = buffer[3];
            reply.dummy = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(buffer, 4));
            reply.ServerID = (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(buffer, 6));
            reply.PayloadLength = IPAddress.NetworkToHostOrder(BitConverter.ToInt64(buffer, 8));
            return 0;
        }
        internal static int FatalErrorNotification(Socket socket, string message)
        {
            byte[] array = System.Text.Encoding.ASCII.GetBytes(message);
            Hislip.Message call = new Hislip.Message();
            call.Prologue0 = 'H';
            call.Prologue1 = 'S';
            call.MessageType = Hislip.FatalError;
            call.ControlCode = 0;
            call.MessageParameter = 0;   
            call.PayloadLength = IPAddress.HostToNetworkOrder((long)array.Length);
            int size = Marshal.SizeOf(typeof(Hislip.Message))+array.Length;
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(call, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(array, 0, packet, Marshal.SizeOf(typeof(Hislip.Initialize)), array.Length);
            gchw.Free();
            socket.Send(packet);
            return 0;
        }
        internal static int ErrorNotification(Socket socket, string message)
        {
            byte[] array = System.Text.Encoding.ASCII.GetBytes(message);
            Hislip.Message call = new Hislip.Message();
            call.Prologue0 = 'H';
            call.Prologue1 = 'S';
            call.MessageType = Hislip.Error;
            call.ControlCode = 0;
            call.MessageParameter = 0;
            call.PayloadLength = IPAddress.HostToNetworkOrder((long)array.Length);
            int size = Marshal.SizeOf(typeof(Hislip.Message))+array.Length;
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(call, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(array, 0, packet, Marshal.SizeOf(typeof(Hislip.Initialize)), array.Length);
            gchw.Free();
            socket.Send(packet);
            return 0;
        }
        internal static int DataTransfer(Socket socket, byte controlcode, int messageID, byte[] data)
        {
            Hislip.Message call = new Hislip.Message();
            call.Prologue0 = 'H';
            call.Prologue1 = 'S';
            call.MessageType = Hislip.Data_;
            call.ControlCode = controlcode;
            call.MessageParameter = IPAddress.HostToNetworkOrder(messageID);
            call.PayloadLength = IPAddress.HostToNetworkOrder((long)data.Length);
            int size = Marshal.SizeOf(typeof(Hislip.Message))+data.Length;
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(call, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(data, 0, packet, Marshal.SizeOf(typeof(Hislip.Initialize)), data.Length);
            gchw.Free();
            socket.Send(packet);
            return 0;
        }
        internal static int DataEndTransfer(Socket socket, byte controlcode, int messageID, byte[] data)
        {
            Hislip.Message call = new Hislip.Message();
            call.Prologue0 = 'H';
            call.Prologue1 = 'S';
            call.MessageType = Hislip.DataEnd;
            call.ControlCode = controlcode;
            call.MessageParameter = IPAddress.HostToNetworkOrder(messageID);
            call.PayloadLength = IPAddress.HostToNetworkOrder((long)data.Length);
            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(call, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(data, 0, packet, Marshal.SizeOf(typeof(Hislip.Initialize)), data.Length);
            gchw.Free();
            socket.Send(packet);
            return 0;
        }
        internal static int Lock(Socket socket, byte controlcode, int timeout, string lockstring)
        {
            byte[] array = System.Text.Encoding.ASCII.GetBytes(lockstring);
            Hislip.Message call = new Hislip.Message();
            call.Prologue0 = 'H';
            call.Prologue1 = 'S';
            call.MessageType = Hislip.AsyncLock;
            call.ControlCode = controlcode;
            call.MessageParameter = IPAddress.HostToNetworkOrder(timeout);
            call.PayloadLength = IPAddress.HostToNetworkOrder((long)array.Length);
            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(call, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(array, 0, packet, Marshal.SizeOf(typeof(Hislip.Initialize)), array.Length);
            gchw.Free();
            socket.Send(packet);

            byte[] buffer = new byte[size];
            socket.Receive(buffer);
            Hislip.AsyncLockResponse reply = new Hislip.AsyncLockResponse();
            reply.Prologue0 = (char)buffer[0];
            reply.Prologue1 = (char)buffer[1];
            reply.MessageType = buffer[2];
            reply.ControlCode = buffer[3];
            reply.MessageParameter = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.PayloadLength = IPAddress.NetworkToHostOrder(BitConverter.ToInt64(buffer, 8));
            return 0;
        }
        internal static int ReleaseLock(Socket socket, byte controlcode, int messageID)
        {
            Hislip.Message call = new Hislip.Message();
            call.Prologue0 = 'H';
            call.Prologue1 = 'S';
            call.MessageType = Hislip.AsyncLock;
            call.ControlCode = controlcode;
            call.MessageParameter = IPAddress.HostToNetworkOrder(messageID);
            call.PayloadLength = 0;
            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(call, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            socket.Send(packet);

            byte[] buffer = new byte[size];
            socket.Receive(buffer);
            Hislip.AsyncLockResponse reply = new Hislip.AsyncLockResponse();
            reply.Prologue0 = (char)buffer[0];
            reply.Prologue1 = (char)buffer[1];
            reply.MessageType = buffer[2];
            reply.ControlCode = buffer[3];
            reply.MessageParameter = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.PayloadLength = IPAddress.NetworkToHostOrder(BitConverter.ToInt64(buffer, 8));
            return 0;
        }
        internal static int LockInfo(Socket socket)
        {
            Hislip.Message call = new Hislip.Message();
            call.Prologue0 = 'H';
            call.Prologue1 = 'S';
            call.MessageType = Hislip.AsyncLockInfo;
            call.ControlCode = 0;
            call.MessageParameter = 0;
            call.PayloadLength = 0;
            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(call, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            socket.Send(packet);

            byte[] buffer = new byte[size];
            socket.Receive(buffer);
            Hislip.Message reply = new Hislip.Message();
            reply.Prologue0 = (char)buffer[0];
            reply.Prologue1 = (char)buffer[1];
            reply.MessageType = buffer[2];
            reply.ControlCode = buffer[3];
            reply.MessageParameter = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.PayloadLength = IPAddress.NetworkToHostOrder(BitConverter.ToInt64(buffer, 8));
            return 0;
        }
        internal static int Remote(Socket socket, byte controlcode, int messageID)
        {
            Hislip.Message call = new Hislip.Message();
            call.Prologue0 = 'H';
            call.Prologue1 = 'S';
            call.MessageType = Hislip.AsyncRemoteLocalControl;
            call.ControlCode = controlcode;
            call.MessageParameter = IPAddress.HostToNetworkOrder(messageID);
            call.PayloadLength = 0;
            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(call, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            socket.Send(packet);

            byte[] buffer = new byte[size];
            socket.Receive(buffer);
            Hislip.Message reply = new Hislip.Message();
            reply.Prologue0 = (char)buffer[0];
            reply.Prologue1 = (char)buffer[1];
            reply.MessageType = buffer[2];
            reply.ControlCode = buffer[3];
            reply.MessageParameter = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.PayloadLength = IPAddress.NetworkToHostOrder(BitConverter.ToInt64(buffer, 8));
            return 0;
        }
        internal static int Local(Socket socket, byte controlcode, int messageID)
        {
            Hislip.Message call = new Hislip.Message();
            call.Prologue0 = 'H';
            call.Prologue1 = 'S';
            call.MessageType = Hislip.AsyncRemoteLocalControl;
            call.ControlCode = controlcode;
            call.MessageParameter = IPAddress.HostToNetworkOrder(messageID);
            call.PayloadLength = 0;
            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(call, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            socket.Send(packet);

            byte[] buffer = new byte[size];
            socket.Receive(buffer);
            Hislip.Message reply = new Hislip.Message();
            reply.Prologue0 = (char)buffer[0];
            reply.Prologue1 = (char)buffer[1];
            reply.MessageType = buffer[2];
            reply.ControlCode = buffer[3];
            reply.MessageParameter = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.PayloadLength = IPAddress.NetworkToHostOrder(BitConverter.ToInt64(buffer, 8));
            return 0;
        }
        internal static int DeviceClear(Socket socket, byte feature)
        {
            Hislip.Message call = new Hislip.Message();
            call.Prologue0 = 'H';
            call.Prologue1 = 'S';
            call.MessageType = Hislip.AsyncDeviceClear;
            call.ControlCode = feature;
            call.MessageParameter = 0;
            call.PayloadLength = 0;
            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(call, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            socket.Send(packet);

            byte[] buffer = new byte[size];
            socket.Receive(buffer);
            Hislip.Message reply = new Hislip.Message();
            reply.Prologue0 = (char)buffer[0];
            reply.Prologue1 = (char)buffer[1];
            reply.MessageType = buffer[2];
            reply.ControlCode = buffer[3];
            reply.MessageParameter = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.PayloadLength = IPAddress.NetworkToHostOrder(BitConverter.ToInt64(buffer, 8));
            return 0;
        }
        internal static int DeviceClearComplete(Socket socket, byte feature)
        {
            Hislip.Message call = new Hislip.Message();
            call.Prologue0 = 'H';
            call.Prologue1 = 'S';
            call.MessageType = Hislip.DeviceClearComplete;
            call.ControlCode = 0;
            call.MessageParameter = 0;
            call.PayloadLength = 0;
            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(call, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            socket.Send(packet);

            byte[] buffer = new byte[size];
            socket.Receive(buffer);
            Hislip.Message reply = new Hislip.Message();
            reply.Prologue0 = (char)buffer[0];
            reply.Prologue1 = (char)buffer[1];
            reply.MessageType = buffer[2];
            reply.ControlCode = buffer[3];
            reply.MessageParameter = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.PayloadLength = IPAddress.NetworkToHostOrder(BitConverter.ToInt64(buffer, 8));
            return 0;
        }
        internal static int Trigger(Socket socket, byte controlcode, int messageID)
        {
            Hislip.Message call = new Hislip.Message();
            call.Prologue0 = 'H';
            call.Prologue1 = 'S';
            call.MessageType = Hislip.Trigger;
            call.ControlCode = controlcode;
            call.MessageParameter = IPAddress.HostToNetworkOrder(messageID);
            call.PayloadLength = 0;
            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(call, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            socket.Send(packet);
            return 0;
        }
        internal static int MaximumMessageSize(Socket socket, long maxmsgsize)
        {
            Hislip.Message call = new Hislip.Message();
            call.Prologue0 = 'H';
            call.Prologue1 = 'S';
            call.MessageType = Hislip.AsyncMaximumMessageSize;
            call.ControlCode = 0;
            call.MessageParameter = 0;
            call.PayloadLength = IPAddress.HostToNetworkOrder(maxmsgsize);
            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(call, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            socket.Send(packet);

            byte[] buffer = new byte[size];
            socket.Receive(buffer);
            Hislip.Message reply = new Hislip.Message();
            reply.Prologue0 = (char)buffer[0];
            reply.Prologue1 = (char)buffer[1];
            reply.MessageType = buffer[2];
            reply.ControlCode = buffer[3];
            reply.MessageParameter = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.PayloadLength = IPAddress.NetworkToHostOrder(BitConverter.ToInt64(buffer, 8));
            return 0;
        }
        internal static int StatusQuery(Socket socket, byte controlcode, int messageID)
        {
            Hislip.Message call = new Hislip.Message();
            call.Prologue0 = 'H';
            call.Prologue1 = 'S';
            call.MessageType = Hislip.AsyncStatusQuery;
            call.ControlCode = controlcode;
            call.MessageParameter = IPAddress.HostToNetworkOrder(messageID);
            call.PayloadLength = 0;
            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(call, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            socket.Send(packet);

            byte[] buffer = new byte[size];
            socket.Receive(buffer);
            Hislip.Message reply = new Hislip.Message();
            reply.Prologue0 = (char)buffer[0];
            reply.Prologue1 = (char)buffer[1];
            reply.MessageType = buffer[2];
            reply.ControlCode = buffer[3];
            reply.MessageParameter = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.PayloadLength = IPAddress.NetworkToHostOrder(BitConverter.ToInt64(buffer, 8));
            return 0;
        }

        private Socket synchronous = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private Socket asynchronous = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        
        private uint MessageID = 0xfffffefe;

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
            IPEndPoint endPoint = new IPEndPoint(ipAddress, port);
            Socket socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(endPoint);

        }
        public void Destroy()
        {
            synchronous.Close();
            asynchronous.Close();
        }
        internal int Send(Socket socket, byte[] buffer)
        {
            int bytes = socket.Send(buffer, 0, buffer.Length, SocketFlags.None);
            return bytes;
        }
        internal int Receive(Socket socket, byte[] buffer)
        {
            int bytes = socket.Receive(buffer, 0, buffer.Length, SocketFlags.None);
            return bytes;
        }
        internal void Flush(Socket socket)
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

    }

}