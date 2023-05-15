using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Vxi11Net
{
    public class ClientHislip
    {
        public int Initialization(string host, short version, short vendorID, string sub_address)
        {
            s.Create(host, Hislip.PORT);
            Hislip.Initialize msg = new Hislip.Initialize();
            msg.Prologue0 = 'H';
            msg.Prologue1 = 'S';
            msg.MessageType = Hislip.Initialize_;
            msg.ControlCode = 0;
            msg.Version = version;
            msg.VendorID = vendorID;
            msg.PayloadLength = (ulong)sub_address.Length;

            byte[] array = System.Text.Encoding.ASCII.GetBytes(sub_address);
            int size = Marshal.SizeOf(typeof(Hislip.Initialize)) + array.Length;
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(msg, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(array, 0, packet, Marshal.SizeOf(typeof(Hislip.Initialize)), array.Length);
            gchw.Free();
            s.Send(packet);

            byte[] buffer = new byte[size];
            s.Receive(buffer);

            a.Create(host, Hislip.PORT);
            Hislip.Message msg1 = new Hislip.Message();
            msg1.Prologue0 = 'H';
            msg1.Prologue1 = 'S';
            msg1.MessageType = Hislip.AsyncInitialize;
            msg1.ControlCode = 0;
            msg1.MessageParameter = 0;
            msg1.PayloadLength = 0;

            size = Marshal.SizeOf(typeof(Hislip.Message));
            packet = new byte[size];
            gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(msg1, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            a.Send(packet);

            buffer = new byte[size];
            a.Receive(buffer);

            return 0;
        }
        public int FatalErrorNotification(string message)
        {
            Hislip.Message msg = new Hislip.Message();
            msg.Prologue0 = 'H';
            msg.Prologue1 = 'S';
            msg.MessageType = Hislip.FatalError;
            msg.ControlCode = 0;
            msg.MessageParameter = 0;   
            msg.PayloadLength = (ulong)message.Length;

            byte[] array = System.Text.Encoding.ASCII.GetBytes(message);
            int size = Marshal.SizeOf(typeof(Hislip.Message))+array.Length;
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(msg, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(array, 0, packet, Marshal.SizeOf(typeof(Hislip.Initialize)), array.Length);
            gchw.Free();
            s.Send(packet);
            return 0;
        }
        public int ErrorNotification(string message)
        {
            Hislip.Message msg = new Hislip.Message();
            msg.Prologue0 = 'H';
            msg.Prologue1 = 'S';
            msg.MessageType = Hislip.Error;
            msg.ControlCode = 0;
            msg.MessageParameter = 0;
            msg.PayloadLength = (ulong)message.Length;

            byte[] array = System.Text.Encoding.ASCII.GetBytes(message);
            int size = Marshal.SizeOf(typeof(Hislip.Message))+array.Length;
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(msg, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(array, 0, packet, Marshal.SizeOf(typeof(Hislip.Initialize)), array.Length);
            gchw.Free();
            s.Send(packet);
            return 0;
        }
        public int DataTransfer(byte controlcode, int messageID, byte[] data)
        {
            Hislip.Message msg = new Hislip.Message();
            msg.Prologue0 = 'H';
            msg.Prologue1 = 'S';
            msg.MessageType = Hislip.Data;
            msg.ControlCode = controlcode;
            msg.MessageParameter = messageID;
            msg.PayloadLength = (ulong)data.Length;

            int size = Marshal.SizeOf(typeof(Hislip.Message))+data.Length;
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(msg, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(data, 0, packet, Marshal.SizeOf(typeof(Hislip.Initialize)), data.Length);
            gchw.Free();
            s.Send(packet);
            return 0;
        }
        public int DataEndTransfer(byte controlcode, int messageID, byte[] data)
        {
            Hislip.Message msg = new Hislip.Message();
            msg.Prologue0 = 'H';
            msg.Prologue1 = 'S';
            msg.MessageType = Hislip.DataEnd;
            msg.ControlCode = controlcode;
            msg.MessageParameter = messageID;
            msg.PayloadLength = (ulong)data.Length;

            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(msg, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(data, 0, packet, Marshal.SizeOf(typeof(Hislip.Initialize)), data.Length);
            gchw.Free();
            s.Send(packet);
            return 0;
        }
        public int Lock(byte controlcode, int timeout, string lockstring)
        {
            Hislip.Message msg = new Hislip.Message();
            msg.Prologue0 = 'H';
            msg.Prologue1 = 'S';
            msg.MessageType = Hislip.AsyncLock;
            msg.ControlCode = controlcode;
            msg.MessageParameter = timeout;
            msg.PayloadLength = (ulong)lockstring.Length;

            byte[] array = System.Text.Encoding.ASCII.GetBytes(lockstring);
            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(msg, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(array, 0, packet, Marshal.SizeOf(typeof(Hislip.Initialize)), array.Length);
            gchw.Free();
            a.Send(packet);

            byte[] buffer = new byte[size];
            a.Receive(buffer);
            return 0;
        }
        public int ReleaseLock(byte controlcode, int messageID)
        {
            Hislip.Message msg = new Hislip.Message();
            msg.Prologue0 = 'H';
            msg.Prologue1 = 'S';
            msg.MessageType = Hislip.AsyncLock;
            msg.ControlCode = controlcode;
            msg.MessageParameter = messageID;
            msg.PayloadLength = 0;

            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(msg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            a.Send(packet);

            byte[] buffer = new byte[size];
            a.Receive(buffer);
            return 0;
        }
        public int LockInfo()
        {
            Hislip.Message msg = new Hislip.Message();
            msg.Prologue0 = 'H';
            msg.Prologue1 = 'S';
            msg.MessageType = Hislip.AsyncLockInfo;
            msg.ControlCode = 0;
            msg.MessageParameter = 0;
            msg.PayloadLength = 0;

            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(msg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            a.Send(packet);

            byte[] buffer = new byte[size];
            a.Receive(buffer);
            return 0;
        }
        public int Remote(byte controlcode, int messageID)
        {
            Hislip.Message msg = new Hislip.Message();
            msg.Prologue0 = 'H';
            msg.Prologue1 = 'S';
            msg.MessageType = Hislip.AsyncRemoteLocalControl;
            msg.ControlCode = controlcode;
            msg.MessageParameter = messageID;
            msg.PayloadLength = 0;

            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(msg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            a.Send(packet);

            byte[] buffer = new byte[size];
            a.Receive(buffer);
            return 0;
        }
        public int Local(byte controlcode, int messageID)
        {
            Hislip.Message msg = new Hislip.Message();
            msg.Prologue0 = 'H';
            msg.Prologue1 = 'S';
            msg.MessageType = Hislip.AsyncRemoteLocalControl;
            msg.ControlCode = controlcode;
            msg.MessageParameter = messageID;
            msg.PayloadLength = 0;

            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(msg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            a.Send(packet);

            byte[] buffer = new byte[size];
            a.Receive(buffer);
            return 0;
        }
        public int DeviceClear(byte feature)
        {
            Hislip.Message msg = new Hislip.Message();
            msg.Prologue0 = 'H';
            msg.Prologue1 = 'S';
            msg.MessageType = Hislip.AsyncDeviceClear;
            msg.ControlCode = feature;
            msg.MessageParameter = 0;
            msg.PayloadLength = 0;

            int size = Marshal.SizeOf(typeof(Hislip.Message));
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

            size = Marshal.SizeOf(typeof(Hislip.Message));
            packet = new byte[size];
            gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(msg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            s.Send(packet);

            buffer = new byte[size];
            a.Receive(buffer);

            return 0;
        }
        public int Trigger(byte controlcode, int messageID)
        {
            Hislip.Message msg = new Hislip.Message();
            msg.Prologue0 = 'H';
            msg.Prologue1 = 'S';
            msg.MessageType = Hislip.Trigger;
            msg.ControlCode = controlcode;
            msg.MessageParameter = messageID;
            msg.PayloadLength = 0;

            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(msg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            s.Send(packet);
            return 0;
        }
        public int MaximumMessageSize(ulong maxmsgsize)
        {
            Hislip.Message msg = new Hislip.Message();
            msg.Prologue0 = 'H';
            msg.Prologue1 = 'S';
            msg.MessageType = Hislip.AsyncMaximumMessageSize;
            msg.ControlCode = 0;
            msg.MessageParameter = 0;
            msg.PayloadLength = maxmsgsize;

            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(msg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            a.Send(packet);

            byte[] buffer = new byte[size];
            a.Receive(buffer);
            return 0;
        }
        public int StatusQuery(byte controlcode, int messageID)
        {
            Hislip.Message msg = new Hislip.Message();
            msg.Prologue0 = 'H';
            msg.Prologue1 = 'S';
            msg.MessageType = Hislip.AsyncStatusQuery;
            msg.ControlCode = controlcode;
            msg.MessageParameter = messageID;
            msg.PayloadLength = 0;

            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(msg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            a.Send(packet);

            byte[] buffer = new byte[size];
            a.Receive(buffer);
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