using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Vxi11Net
{
    public class ClientVxi11
    {
        public static Socket create_rpc_client_core_channel(string host, int port)
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(host);
            IPAddress   ipAddress  = ipHostInfo.AddressList[0];
            IPEndPoint  remoteEP   = new IPEndPoint(ipAddress, port);

            Socket socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(remoteEP);
            socket.NoDelay = true;
            return socket;
        }
        public static void close_rpc_client_core_channel(Socket socket)
        {
            socket.Close();
        }
        public static Socket create_rpc_client_abort_channel(string host, int port)
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(host);
            IPAddress   ipAddress  = ipHostInfo.AddressList[0];
            IPEndPoint  remoteEP   = new IPEndPoint(ipAddress, port);
            
            Socket socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(remoteEP);
            socket.NoDelay = true;
            return socket;
        }
        public static void close_rpc_client_abort_channel(Socket socket)
        {
            socket.Close();
        }
        public static Socket create_rpc_server_interrupt_channel(string host, int port)
        {
            throw new NotImplementedException();
        }
        public static void close_rpc_server_interrupt_channel(Socket socket)
        {
            socket.Close();
        }

        // call create_link
        public static int CreateLink(Socket so, int xid, int cliendId, int lockDevice, int lock_timeout, string handle, out int lid, out int abortPort, out int maxRecvSize)
        {
            Vxi11.CREATE_LINK_CALL arg = new Vxi11.CREATE_LINK_CALL();
            byte[] str = System.Text.Encoding.ASCII.GetBytes(handle);
            int size = Marshal.SizeOf(typeof(Vxi11.CREATE_LINK_CALL)) + str.Length;
            size = ((size / 4) + 1) * 4;
            arg.xid            = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type       = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers        = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE);
            arg.vers           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE_VERSION);
            arg.proc           = IPAddress.HostToNetworkOrder(Vxi11.CREATE_LINK);
            arg.cred_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.cred_len       = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.verf_len       = IPAddress.HostToNetworkOrder(0);
            arg.clientId       = IPAddress.HostToNetworkOrder(cliendId);
            arg.lockDevice     = IPAddress.HostToNetworkOrder(lockDevice);
            arg.lock_timeout   = IPAddress.HostToNetworkOrder(lock_timeout);
            arg.handle_len     = IPAddress.HostToNetworkOrder(str.Length);
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(str, 0, packet, Marshal.SizeOf(typeof(Vxi11.CREATE_LINK_CALL)), str.Length);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.CREATE_LINK_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            Vxi11.CREATE_LINK_REPLY reply = new Vxi11.CREATE_LINK_REPLY();
            reply.xid          = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.msg_type     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat         = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));
            reply.lid          = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 32));
            reply.abortPort    = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 36));
            reply.maxRecvSize  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 40));
            lid                = reply.lid;
            abortPort          = reply.abortPort;
            maxRecvSize        = reply.maxRecvSize;

            return reply.error;
        }
        // call device_write
        public static int DeviceWrite(Socket so, int xid, int lid, Vxi11.Flags flags, int lock_timeout, int io_timeout, string data, out int data_len)
        {
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(data);
            return DeviceWrite(so, xid, lid, flags, lock_timeout, io_timeout, bytes, out data_len);
        }
        public static int DeviceWrite(Socket so, int xid, int lid, Vxi11.Flags flags, int lock_timeout, int io_timeout, byte[] data, out int data_len)
        {
            Vxi11.DEVICE_WRITE_CALL arg = new Vxi11.DEVICE_WRITE_CALL();
            int size = Marshal.SizeOf(typeof(Vxi11.DEVICE_WRITE_CALL)) + data.Length;
            size = ((size / 4) + 1) * 4;
            arg.xid            = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type       = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers        = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE);
            arg.vers           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE_VERSION);
            arg.proc           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_WRITE);
            arg.cred_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.cred_len       = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.verf_len       = IPAddress.HostToNetworkOrder(0);
            arg.lid            = IPAddress.HostToNetworkOrder(lid);
            arg.flags          = IPAddress.HostToNetworkOrder((int)flags);
            arg.lock_timeout   = IPAddress.HostToNetworkOrder(lock_timeout);
            arg.io_timeout     = IPAddress.HostToNetworkOrder(io_timeout);
            arg.data_len       = IPAddress.HostToNetworkOrder(data.Length);
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(data, 0, packet, Marshal.SizeOf(typeof(Vxi11.DEVICE_WRITE_CALL)), data.Length);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_WRITE_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            Vxi11.DEVICE_WRITE_REPLY reply = new Vxi11.DEVICE_WRITE_REPLY();
            reply.xid          = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.msg_type     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat         = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));
            reply.data_len     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 32));
            data_len           = reply.data_len;

            return reply.error;
        }
        // call device_read
        public static int DeviceRead(Socket so, int xid, int lid, int requestSize, Vxi11.Flags flags, int lock_timeout, int io_timeout, Vxi11.TermChar term, out int reason, out string data)
        {
            byte[] buf;
            int ret = DeviceRead(so, xid, lid, requestSize, flags, lock_timeout, io_timeout, term, out reason, out buf);
            data = System.Text.Encoding.ASCII.GetString(buf);
            return ret;
        }
        public static int DeviceRead(Socket so, int xid, int lid, int requestSize, Vxi11.Flags flags, int lock_timeout, int io_timeout, Vxi11.TermChar term, out int reason, out byte[] data)
        {
            Vxi11.DEVICE_READ_CALL arg = new Vxi11.DEVICE_READ_CALL();
            int size = Marshal.SizeOf(typeof(Vxi11.DEVICE_READ_CALL));
            arg.xid            = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type       = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers        = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE);
            arg.vers           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE_VERSION);
            arg.proc           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_READ);
            arg.cred_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.cred_len       = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.verf_len       = IPAddress.HostToNetworkOrder(0);
            arg.lid            = IPAddress.HostToNetworkOrder(lid);
            arg.requestSize    = IPAddress.HostToNetworkOrder(requestSize);
            arg.io_timeout     = IPAddress.HostToNetworkOrder(io_timeout);
            arg.lock_timeout   = IPAddress.HostToNetworkOrder(lock_timeout);
            arg.flags          = IPAddress.HostToNetworkOrder((int)flags);
            arg.termChar       = IPAddress.HostToNetworkOrder((int)term);
            byte[] packet = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_READ_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_READ_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            Vxi11.DEVICE_READ_REPLY reply = new Vxi11.DEVICE_READ_REPLY();
            reply.xid          = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.msg_type     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat         = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));
            reply.reason       = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 32));
            reply.data_len     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 36));
            reason             = reply.reason;
            data               = new Byte[reply.data_len];
            byteCount          = so.Receive(data, SocketFlags.None);

            return reply.error;
        }
        // call device_readstb
        public static int DeviceReadstb(Socket so, int xid, int lid, Vxi11.Flags flags, int lock_timeout, int io_timeout, out char stb)
        {
            Vxi11.DEVICE_GENERIC_CALL arg = new Vxi11.DEVICE_GENERIC_CALL();
            int size = Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_CALL));
            arg.xid            = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type       = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers        = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE);
            arg.vers           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE_VERSION);
            arg.proc           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_READSTB);
            arg.cred_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.cred_len       = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.verf_len       = IPAddress.HostToNetworkOrder(0);
            arg.lid            = IPAddress.HostToNetworkOrder(lid);
            arg.flags          = IPAddress.HostToNetworkOrder((int)flags);
            arg.lock_timeout   = IPAddress.HostToNetworkOrder(lock_timeout);
            arg.io_timeout     = IPAddress.HostToNetworkOrder(io_timeout);
            byte[] packet = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_READSTB_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            Vxi11.DEVICE_READSTB_REPLY reply = new Vxi11.DEVICE_READSTB_REPLY();
            reply.xid          = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.msg_type     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat         = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));
            reply.stb          = (byte)buffer[32];
            stb                = (char)reply.stb;

            return reply.error;
        }
        // call device_trigger
        public static int DeviceTrigger(Socket so, int xid, int lid, Vxi11.Flags flags, int lock_timeout, int io_timeout)
        {
            Vxi11.DEVICE_GENERIC_CALL arg = new Vxi11.DEVICE_GENERIC_CALL();
            int size = Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_CALL));
            arg.xid            = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type       = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers        = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE);
            arg.vers           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE_VERSION);
            arg.proc           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_TRIGGER);
            arg.cred_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.cred_len       = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.verf_len       = IPAddress.HostToNetworkOrder(0);
            arg.lid            = IPAddress.HostToNetworkOrder(lid);
            arg.flags          = IPAddress.HostToNetworkOrder((int)flags);
            arg.lock_timeout   = IPAddress.HostToNetworkOrder(lock_timeout);
            arg.io_timeout     = IPAddress.HostToNetworkOrder(io_timeout);
            byte[] packet = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            Vxi11.DEVICE_GENERIC_REPLY reply = new Vxi11.DEVICE_GENERIC_REPLY();
            reply.xid          = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.msg_type     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat         = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));

            return reply.error;
        }
        // call device_clear
        public static int DeviceClear(Socket so, int xid, int lid, Vxi11.Flags flags, int lock_timeout, int io_timeout)
        {
            Vxi11.DEVICE_GENERIC_CALL arg = new Vxi11.DEVICE_GENERIC_CALL();
            int size = Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_CALL));
            arg.xid            = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type       = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers        = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE);
            arg.vers           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE_VERSION);
            arg.proc           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CLEAR);
            arg.cred_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.cred_len       = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.verf_len       = IPAddress.HostToNetworkOrder(0);
            arg.lid            = IPAddress.HostToNetworkOrder(lid);
            arg.flags          = IPAddress.HostToNetworkOrder((int)flags);
            arg.lock_timeout   = IPAddress.HostToNetworkOrder(lock_timeout);
            arg.io_timeout     = IPAddress.HostToNetworkOrder(io_timeout);
            byte[] packet = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            Vxi11.DEVICE_GENERIC_REPLY reply = new Vxi11.DEVICE_GENERIC_REPLY();
            reply.xid          = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.msg_type     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat         = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));

            return reply.error;
        }
        // call device_remote
        public static int DeviceRemote(Socket so, int xid, int lid, Vxi11.Flags flags, int lock_timeout, int io_timeout)
        {
            Vxi11.DEVICE_GENERIC_CALL arg = new Vxi11.DEVICE_GENERIC_CALL();
            int size = Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_CALL));
            arg.xid            = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type       = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers        = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE);
            arg.vers           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE_VERSION);
            arg.proc           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_REMOTE);
            arg.cred_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.cred_len       = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.verf_len       = IPAddress.HostToNetworkOrder(0);
            arg.lid            = IPAddress.HostToNetworkOrder(lid);
            arg.flags          = IPAddress.HostToNetworkOrder((int)flags);
            arg.lock_timeout   = IPAddress.HostToNetworkOrder(lock_timeout);
            arg.io_timeout     = IPAddress.HostToNetworkOrder(io_timeout);
            byte[] packet = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            Vxi11.DEVICE_GENERIC_REPLY reply = new Vxi11.DEVICE_GENERIC_REPLY();
            reply.xid          = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.msg_type     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat         = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));

            return reply.error;
        }
        // call device_local
        public static int DeviceLocal(Socket so, int xid, int lid, Vxi11.Flags flags, int lock_timeout, int io_timeout)
        {
            Vxi11.DEVICE_GENERIC_CALL arg = new Vxi11.DEVICE_GENERIC_CALL();
            int size = Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_CALL));
            arg.xid            = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type       = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers        = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE);
            arg.vers           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE_VERSION);
            arg.proc           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_LOCAL);
            arg.cred_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.cred_len       = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.verf_len       = IPAddress.HostToNetworkOrder(0);
            arg.lid            = IPAddress.HostToNetworkOrder(lid);
            arg.flags          = IPAddress.HostToNetworkOrder((int)flags);
            arg.lock_timeout   = IPAddress.HostToNetworkOrder(lock_timeout);
            arg.io_timeout     = IPAddress.HostToNetworkOrder(io_timeout);
            byte[] packet = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            Vxi11.DEVICE_GENERIC_REPLY reply = new Vxi11.DEVICE_GENERIC_REPLY();
            reply.xid          = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.msg_type     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat         = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));

            return reply.error;
        }
        // call device_lock
        public static int DeviceLock(Socket so, int xid, int lid, Vxi11.Flags flags, int lock_timeout)
        {
            Vxi11.DEVICE_LOCK_CALL arg = new Vxi11.DEVICE_LOCK_CALL();
            int size = Marshal.SizeOf(typeof(Vxi11.DEVICE_LOCK_CALL));
            arg.xid            = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type       = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers        = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE);
            arg.vers           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE_VERSION);
            arg.proc           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_LOCK);
            arg.cred_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.cred_len       = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.verf_len       = IPAddress.HostToNetworkOrder(0);
            arg.lid            = IPAddress.HostToNetworkOrder(lid);
            arg.flags          = IPAddress.HostToNetworkOrder((int)flags);
            arg.lock_timeout   = IPAddress.HostToNetworkOrder(lock_timeout);
            byte[] packet = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_LOCK_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            Vxi11.DEVICE_GENERIC_REPLY reply = new Vxi11.DEVICE_GENERIC_REPLY();
            reply.xid          = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.msg_type     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat         = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));

            return reply.error;
        }
        // call device_unlock
        public static int DeviceUnlock(Socket so, int xid, int lid)
        {
            Vxi11.DEVICE_UNLOCK_CALL arg = new Vxi11.DEVICE_UNLOCK_CALL();
            int size = Marshal.SizeOf(typeof(Vxi11.DEVICE_UNLOCK_CALL));
            arg.xid            = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type       = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers        = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE);
            arg.vers           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE_VERSION);
            arg.proc           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_UNLOCK);
            arg.cred_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.cred_len       = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.verf_len       = IPAddress.HostToNetworkOrder(0);
            arg.lid            = IPAddress.HostToNetworkOrder(lid);
            byte[] packet = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_UNLOCK_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            Vxi11.DEVICE_GENERIC_REPLY reply = new Vxi11.DEVICE_GENERIC_REPLY();
            reply.xid          = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.msg_type     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat         = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));

            return reply.error;
        }
        // call create_intr_chan
        public static int CreateIntrChan(Socket so, int xid, int hostaddr, int hostport, int prognum, int progvers, int progfamily)
        {
            Vxi11.CREATE_INTR_CHAN_CALL arg = new Vxi11.CREATE_INTR_CHAN_CALL();
            int size = Marshal.SizeOf(typeof(Vxi11.CREATE_INTR_CHAN_CALL));
            arg.xid            = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type       = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers        = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE);
            arg.vers           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE_VERSION);
            arg.proc           = IPAddress.HostToNetworkOrder(Vxi11.CREATE_INTR_CHAN);
            arg.cred_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.cred_len       = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.verf_len       = IPAddress.HostToNetworkOrder(0);
            arg.hostaddr       = IPAddress.HostToNetworkOrder(hostaddr);
            arg.hostport       = IPAddress.HostToNetworkOrder(hostport);
            arg.prognum        = IPAddress.HostToNetworkOrder(prognum);
            arg.progvers       = IPAddress.HostToNetworkOrder(progvers);
            arg.progfamily     = IPAddress.HostToNetworkOrder(progfamily);
            byte[] packet = new byte[Marshal.SizeOf(typeof(Vxi11.CREATE_INTR_CHAN_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            Vxi11.DEVICE_GENERIC_REPLY reply = new Vxi11.DEVICE_GENERIC_REPLY();
            reply.xid          = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.msg_type     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat         = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));

            return reply.error;
        }
        // call destroy_intr_chan
        public static int DestroyIntrChan(Socket so, int xid)
        {
            Vxi11.DESTROY_INTR_CHAN_CALL arg = new Vxi11.DESTROY_INTR_CHAN_CALL();
            int size = Marshal.SizeOf(typeof(Vxi11.DESTROY_INTR_CHAN_CALL));
            arg.xid            = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type       = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers        = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE);
            arg.vers           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE_VERSION);
            arg.proc           = IPAddress.HostToNetworkOrder(Vxi11.DESTROY_INTR_CHAN);
            arg.cred_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.cred_len       = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.verf_len       = IPAddress.HostToNetworkOrder(0);
            byte[] packet = new byte[Marshal.SizeOf(typeof(Vxi11.DESTROY_INTR_CHAN_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            Vxi11.DEVICE_GENERIC_REPLY reply = new Vxi11.DEVICE_GENERIC_REPLY();
            reply.xid          = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.msg_type     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat         = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));

            return reply.error;
        }
        // call device_enable_srq
        public static int DeviceEnableSrq(Socket so, int xid, int lid, int enable, string handle)
        {
            Vxi11.DEVICE_ENABLE_SRQ_CALL arg = new Vxi11.DEVICE_ENABLE_SRQ_CALL();
            byte[] str = System.Text.Encoding.ASCII.GetBytes(handle);
            int size = Marshal.SizeOf(typeof(Vxi11.DEVICE_ENABLE_SRQ_CALL)) + str.Length;
            size = ((size / 4) + 1) * 4;
            arg.xid            = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type       = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers        = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE);
            arg.vers           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE_VERSION);
            arg.proc           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_ENABLE_SRQ);
            arg.cred_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.cred_len       = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.verf_len       = IPAddress.HostToNetworkOrder(0);
            arg.lid            = IPAddress.HostToNetworkOrder(lid);
            arg.enable         = IPAddress.HostToNetworkOrder(enable);
            arg.handle_len     = IPAddress.HostToNetworkOrder(handle.Length);
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(str, 0, packet, Marshal.SizeOf(typeof(Vxi11.DEVICE_ENABLE_SRQ_CALL)), str.Length);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            Vxi11.DEVICE_GENERIC_REPLY reply = new Vxi11.DEVICE_GENERIC_REPLY();
            reply.xid          = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.msg_type     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat         = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));

            return reply.error;
        }
        // call device_docmd
        public static void DeviceDocmd(Socket so, int xid, int lid, Vxi11.Flags flags, int lock_timeout, int io_timeout, int cmd, int network_order, int datasize, byte[] data_in, out byte[] data_out)
        {
            Vxi11.DEVICE_DOCMD_CALL arg = new Vxi11.DEVICE_DOCMD_CALL();
            int size = Marshal.SizeOf(typeof(Vxi11.DEVICE_DOCMD_CALL)) + data_in.Length;
            size = ((size / 4) + 1) * 4;
            arg.xid            = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type       = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers        = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE);
            arg.vers           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE_VERSION);
            arg.proc           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_DOCMD);
            arg.cred_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.cred_len       = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.verf_len       = IPAddress.HostToNetworkOrder(0);
            arg.lid            = IPAddress.HostToNetworkOrder(lid);
            arg.flags          = IPAddress.HostToNetworkOrder((int)flags);
            arg.io_timeout     = IPAddress.HostToNetworkOrder(io_timeout);
            arg.lock_timeout   = IPAddress.HostToNetworkOrder(lock_timeout);
            arg.cmd            = IPAddress.HostToNetworkOrder(cmd);
            arg.network_order  = IPAddress.HostToNetworkOrder(network_order);
            arg.datasize       = IPAddress.HostToNetworkOrder(datasize);
            arg.data_in_len    = IPAddress.HostToNetworkOrder(data_in.Length);
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(data_in, 0, packet, Marshal.SizeOf(typeof(Vxi11.DEVICE_DOCMD_CALL)), data_in.Length);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_DOCMD_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            Vxi11.DEVICE_DOCMD_REPLY reply = new Vxi11.DEVICE_DOCMD_REPLY();
            reply.xid          = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.msg_type     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat         = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));
            reply.data_out_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 32));
            data_out           = new Byte[reply.data_out_len];
            byteCount          = so.Receive(data_out, SocketFlags.None);
        }
        // call destroy_link
        public static int DestroyLink(Socket so, int xid, int lid)
        {
            Vxi11.DEVICE_GENERIC_CALL arg = new Vxi11.DEVICE_GENERIC_CALL();
            int size = Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_CALL));
            arg.xid            = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type       = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers        = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE);
            arg.vers           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE_VERSION);
            arg.proc           = IPAddress.HostToNetworkOrder(Vxi11.DESTROY_LINK);
            arg.cred_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.cred_len       = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.verf_len       = IPAddress.HostToNetworkOrder(0);
            arg.lid            = IPAddress.HostToNetworkOrder(lid);
            byte[] packet = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            Vxi11.DEVICE_GENERIC_REPLY reply = new Vxi11.DEVICE_GENERIC_REPLY();
            reply.xid          = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.msg_type     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat         = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));

            return reply.error;
        }
        // call device_abort
        public static int DeviceAbort(Socket so, int xid, int lid, Vxi11.Flags flags, int lock_timeout, int io_timeout)
        {
            Vxi11.DEVICE_GENERIC_CALL arg = new Vxi11.DEVICE_GENERIC_CALL();
            int size = Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_CALL));
            arg.xid            = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type       = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers        = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_ABORT_PROG);
            arg.vers           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_ABORT_VERSION);
            arg.proc           = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_ABORT);
            arg.cred_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.cred_len       = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.verf_len       = IPAddress.HostToNetworkOrder(0);
            arg.lid            = IPAddress.HostToNetworkOrder(lid);
            arg.flags          = IPAddress.HostToNetworkOrder((int)flags);
            arg.lock_timeout   = IPAddress.HostToNetworkOrder(lock_timeout);
            arg.io_timeout     = IPAddress.HostToNetworkOrder(io_timeout);
            byte[] packet = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            Vxi11.DEVICE_GENERIC_REPLY reply = new Vxi11.DEVICE_GENERIC_REPLY();
            reply.xid          = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.msg_type     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat         = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));

            return reply.error;
        }
     }
}