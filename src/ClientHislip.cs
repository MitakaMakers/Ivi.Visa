using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Vxi11Net
{
    public class ClientHislip
    {
        public int Initialization(string host, int port, short version, short vendorID, string sub_address)
        {
            s.Create(host, port);
            byte[] array = System.Text.Encoding.ASCII.GetBytes(sub_address);
            Hislip.Initialize call = new Hislip.Initialize();
            call.Prologue0 = 'H';
            call.Prologue1 = 'S';
            call.MessageType = Hislip.Initialize_;
            call.ControlCode = 0;
            call.Version = version;
            call.VendorID = vendorID;
            call.PayloadLength = IPAddress.HostToNetworkOrder((long)array.Length);
            int size = Marshal.SizeOf(typeof(Hislip.Initialize)) + array.Length;
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(call, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(array, 0, packet, Marshal.SizeOf(typeof(Hislip.Initialize)), array.Length);
            gchw.Free();
            s.Send(packet);

            byte[] buffer = new byte[size];
            s.Receive(buffer);
            Hislip.InitializeResponse reply = new Hislip.InitializeResponse();
            reply.Prologue0 = (char)buffer[0];
            reply.Prologue1 = (char)buffer[1];
            reply.MessageType = buffer[2];
            reply.ControlCode = buffer[3];
            reply.Protocol = IPAddress.HostToNetworkOrder(BitConverter.ToInt16(buffer, 4));
            reply.SessionID = IPAddress.HostToNetworkOrder(BitConverter.ToInt16(buffer, 6));
            reply.PayloadLength = IPAddress.HostToNetworkOrder(BitConverter.ToInt64(buffer, 8));

            a.Create(host, port);
            Hislip.Message acall = new Hislip.Message();
            acall.Prologue0 = 'H';
            acall.Prologue1 = 'S';
            acall.MessageType = Hislip.AsyncInitialize;
            acall.ControlCode = 0;
            acall.MessageParameter = 0;
            acall.PayloadLength = 0;
            size = Marshal.SizeOf(typeof(Hislip.Message));
            packet = new byte[size];
            gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(call, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            a.Send(packet);

            buffer = new byte[size];
            a.Receive(buffer);
            Hislip.AsyncInitializeResponse areply = new Hislip.AsyncInitializeResponse();
            areply.Prologue0 = (char)buffer[0];
            areply.Prologue1 = (char)buffer[1];
            areply.MessageType = buffer[2];
            areply.ControlCode = buffer[3];
            areply.dummy = IPAddress.HostToNetworkOrder(BitConverter.ToInt16(buffer, 4));
            areply.ServerID = IPAddress.HostToNetworkOrder(BitConverter.ToInt16(buffer, 6));
            areply.PayloadLength = IPAddress.HostToNetworkOrder(BitConverter.ToInt64(buffer, 8));

            return 0;
        }
        public int FatalErrorNotification(string message)
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
            s.Send(packet);
            return 0;
        }
        public int ErrorNotification(string message)
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
            s.Send(packet);
            return 0;
        }
        public int DataTransfer(byte controlcode, int messageID, byte[] data)
        {
            Hislip.Message call = new Hislip.Message();
            call.Prologue0 = 'H';
            call.Prologue1 = 'S';
            call.MessageType = Hislip.Data;
            call.ControlCode = controlcode;
            call.MessageParameter = messageID;
            call.PayloadLength = IPAddress.HostToNetworkOrder((long)data.Length);
            int size = Marshal.SizeOf(typeof(Hislip.Message))+data.Length;
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(call, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(data, 0, packet, Marshal.SizeOf(typeof(Hislip.Initialize)), data.Length);
            gchw.Free();
            s.Send(packet);
            return 0;
        }
        public int DataEndTransfer(byte controlcode, int messageID, byte[] data)
        {
            Hislip.Message call = new Hislip.Message();
            call.Prologue0 = 'H';
            call.Prologue1 = 'S';
            call.MessageType = Hislip.DataEnd;
            call.ControlCode = controlcode;
            call.MessageParameter = messageID;
            call.PayloadLength = IPAddress.HostToNetworkOrder((long)data.Length);
            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(call, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(data, 0, packet, Marshal.SizeOf(typeof(Hislip.Initialize)), data.Length);
            gchw.Free();
            s.Send(packet);
            return 0;
        }
        public int Lock(byte controlcode, int timeout, string lockstring)
        {
            byte[] array = System.Text.Encoding.ASCII.GetBytes(lockstring);
            Hislip.Message call = new Hislip.Message();
            call.Prologue0 = 'H';
            call.Prologue1 = 'S';
            call.MessageType = Hislip.AsyncLock;
            call.ControlCode = controlcode;
            call.MessageParameter = timeout;
            call.PayloadLength = IPAddress.HostToNetworkOrder((long)array.Length);
            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(call, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(array, 0, packet, Marshal.SizeOf(typeof(Hislip.Initialize)), array.Length);
            gchw.Free();
            a.Send(packet);

            byte[] buffer = new byte[size];
            a.Receive(buffer);
            Hislip.AsyncLockResponse reply = new Hislip.AsyncLockResponse();
            reply.Prologue0 = (char)buffer[0];
            reply.Prologue1 = (char)buffer[1];
            reply.MessageType = buffer[2];
            reply.ControlCode = buffer[3];
            reply.MessageParameter = IPAddress.HostToNetworkOrder(BitConverter.ToInt32(buffer, 4));
            reply.PayloadLength = IPAddress.HostToNetworkOrder(BitConverter.ToInt64(buffer, 8));
            return 0;
        }
        public int ReleaseLock(byte controlcode, int messageID)
        {
            Hislip.Message call = new Hislip.Message();
            call.Prologue0 = 'H';
            call.Prologue1 = 'S';
            call.MessageType = Hislip.AsyncLock;
            call.ControlCode = controlcode;
            call.MessageParameter = messageID;
            call.PayloadLength = 0;
            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(call, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            a.Send(packet);

            byte[] buffer = new byte[size];
            a.Receive(buffer);
            Hislip.AsyncLockResponse reply = new Hislip.AsyncLockResponse();
            reply.Prologue0 = (char)buffer[0];
            reply.Prologue1 = (char)buffer[1];
            reply.MessageType = buffer[2];
            reply.ControlCode = buffer[3];
            reply.MessageParameter = IPAddress.HostToNetworkOrder(BitConverter.ToInt32(buffer, 4));
            reply.PayloadLength = IPAddress.HostToNetworkOrder(BitConverter.ToInt64(buffer, 8));
            return 0;
        }
        public int LockInfo()
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
            a.Send(packet);

            byte[] buffer = new byte[size];
            a.Receive(buffer);
            Hislip.Message reply = new Hislip.Message();
            reply.Prologue0 = (char)buffer[0];
            reply.Prologue1 = (char)buffer[1];
            reply.MessageType = buffer[2];
            reply.ControlCode = buffer[3];
            reply.MessageParameter = IPAddress.HostToNetworkOrder(BitConverter.ToInt32(buffer, 4));
            reply.PayloadLength = IPAddress.HostToNetworkOrder(BitConverter.ToInt64(buffer, 8));
            return 0;
        }
        public int Remote(byte controlcode, int messageID)
        {
            Hislip.Message call = new Hislip.Message();
            call.Prologue0 = 'H';
            call.Prologue1 = 'S';
            call.MessageType = Hislip.AsyncRemoteLocalControl;
            call.ControlCode = controlcode;
            call.MessageParameter = messageID;
            call.PayloadLength = 0;
            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(call, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            a.Send(packet);

            byte[] buffer = new byte[size];
            a.Receive(buffer);
            Hislip.Message reply = new Hislip.Message();
            reply.Prologue0 = (char)buffer[0];
            reply.Prologue1 = (char)buffer[1];
            reply.MessageType = buffer[2];
            reply.ControlCode = buffer[3];
            reply.MessageParameter = IPAddress.HostToNetworkOrder(BitConverter.ToInt32(buffer, 4));
            reply.PayloadLength = IPAddress.HostToNetworkOrder(BitConverter.ToInt64(buffer, 8));
            return 0;
        }
        public int Local(byte controlcode, int messageID)
        {
            Hislip.Message call = new Hislip.Message();
            call.Prologue0 = 'H';
            call.Prologue1 = 'S';
            call.MessageType = Hislip.AsyncRemoteLocalControl;
            call.ControlCode = controlcode;
            call.MessageParameter = messageID;
            call.PayloadLength = 0;
            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(call, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            a.Send(packet);

            byte[] buffer = new byte[size];
            a.Receive(buffer);
            Hislip.Message reply = new Hislip.Message();
            reply.Prologue0 = (char)buffer[0];
            reply.Prologue1 = (char)buffer[1];
            reply.MessageType = buffer[2];
            reply.ControlCode = buffer[3];
            reply.MessageParameter = IPAddress.HostToNetworkOrder(BitConverter.ToInt32(buffer, 4));
            reply.PayloadLength = IPAddress.HostToNetworkOrder(BitConverter.ToInt64(buffer, 8));
            return 0;
        }
        public int DeviceClear(byte feature)
        {
            Hislip.Message acall = new Hislip.Message();
            acall.Prologue0 = 'H';
            acall.Prologue1 = 'S';
            acall.MessageType = Hislip.AsyncDeviceClear;
            acall.ControlCode = feature;
            acall.MessageParameter = 0;
            acall.PayloadLength = 0;
            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(acall, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            a.Send(packet);

            byte[] buffer = new byte[size];
            a.Receive(buffer);
            Hislip.Message areply = new Hislip.Message();
            areply.Prologue0 = (char)buffer[0];
            areply.Prologue1 = (char)buffer[1];
            areply.MessageType = buffer[2];
            areply.ControlCode = buffer[3];
            areply.MessageParameter = IPAddress.HostToNetworkOrder(BitConverter.ToInt32(buffer, 4));
            areply.PayloadLength = IPAddress.HostToNetworkOrder(BitConverter.ToInt64(buffer, 8));

            Hislip.Message call = new Hislip.Message();
            call.Prologue0 = 'H';
            call.Prologue1 = 'S';
            call.MessageType = Hislip.DeviceClearComplete;
            call.ControlCode = 0;
            call.MessageParameter = 0;
            call.PayloadLength = 0;
            size = Marshal.SizeOf(typeof(Hislip.Message));
            packet = new byte[size];
            gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(call, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            s.Send(packet);

            buffer = new byte[size];
            a.Receive(buffer);
            Hislip.Message reply = new Hislip.Message();
            reply.Prologue0 = (char)buffer[0];
            reply.Prologue1 = (char)buffer[1];
            reply.MessageType = buffer[2];
            reply.ControlCode = buffer[3];
            reply.MessageParameter = IPAddress.HostToNetworkOrder(BitConverter.ToInt32(buffer, 4));
            reply.PayloadLength = IPAddress.HostToNetworkOrder(BitConverter.ToInt64(buffer, 8));
            return 0;
        }
        public int Trigger(byte controlcode, int messageID)
        {
            Hislip.Message call = new Hislip.Message();
            call.Prologue0 = 'H';
            call.Prologue1 = 'S';
            call.MessageType = Hislip.Trigger;
            call.ControlCode = controlcode;
            call.MessageParameter = messageID;
            call.PayloadLength = 0;
            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(call, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            s.Send(packet);
            return 0;
        }
        public int MaximumMessageSize(long maxmsgsize)
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
            a.Send(packet);

            byte[] buffer = new byte[size];
            a.Receive(buffer);
            Hislip.Message reply = new Hislip.Message();
            reply.Prologue0 = (char)buffer[0];
            reply.Prologue1 = (char)buffer[1];
            reply.MessageType = buffer[2];
            reply.ControlCode = buffer[3];
            reply.MessageParameter = IPAddress.HostToNetworkOrder(BitConverter.ToInt32(buffer, 4));
            reply.PayloadLength = IPAddress.HostToNetworkOrder(BitConverter.ToInt64(buffer, 8));
            return 0;
        }
        public int StatusQuery(byte controlcode, int messageID)
        {
            Hislip.Message call = new Hislip.Message();
            call.Prologue0 = 'H';
            call.Prologue1 = 'S';
            call.MessageType = Hislip.AsyncStatusQuery;
            call.ControlCode = controlcode;
            call.MessageParameter = messageID;
            call.PayloadLength = 0;
            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(call, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            a.Send(packet);

            byte[] buffer = new byte[size];
            a.Receive(buffer);
            Hislip.Message reply = new Hislip.Message();
            reply.Prologue0 = (char)buffer[0];
            reply.Prologue1 = (char)buffer[1];
            reply.MessageType = buffer[2];
            reply.ControlCode = buffer[3];
            reply.MessageParameter = IPAddress.HostToNetworkOrder(BitConverter.ToInt32(buffer, 4));
            reply.PayloadLength = IPAddress.HostToNetworkOrder(BitConverter.ToInt64(buffer, 8));
            return 0;
        }

        ClientSynchronousChannel s = new ClientSynchronousChannel();
        ClientAsynchronousChannel a = new ClientAsynchronousChannel();
        private uint MessageID = 0xfffffefe;
        public void Create(string host)
        {
            //Initialization(host);
        }
        public void Destroy()
        {
            s.Destroy();
            a.Destroy();
        }
    }
    internal class ClientSynchronousChannel
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
    internal class ClientAsynchronousChannel
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