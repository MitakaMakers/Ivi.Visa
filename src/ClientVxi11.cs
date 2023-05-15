using System.Net;
using System.Runtime.InteropServices;

namespace Vxi11Net
{
    internal class CoreChannel
    {
        // call create_link
        internal static int CreateLink(ClientRpcTcp rpc, int xid, int cliendId, int lockDevice, int lock_timeout, byte[] handle, out int lid, out int abortPort, out int maxRecvSize)
        {
            Vxi11.CREATE_LINK_CALL arg = new Vxi11.CREATE_LINK_CALL();
            arg.xid = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE);
            arg.vers = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE_VERSION);
            arg.proc = IPAddress.HostToNetworkOrder(Vxi11.CREATE_LINK);
            arg.cred_flavor = IPAddress.HostToNetworkOrder(0);
            arg.cred_len = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor = IPAddress.HostToNetworkOrder(0);
            arg.verf_len = IPAddress.HostToNetworkOrder(0);
            arg.clientId = IPAddress.HostToNetworkOrder(cliendId);
            arg.lockDevice = IPAddress.HostToNetworkOrder(lockDevice);
            arg.lock_timeout = IPAddress.HostToNetworkOrder(lock_timeout);
            arg.handle_len = IPAddress.HostToNetworkOrder(handle.Length);

            int size = Marshal.SizeOf(typeof(Vxi11.CREATE_LINK_CALL)) + handle.Length;
            size = ((size / 4) + 1) * 4;
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(handle, 0, packet, Marshal.SizeOf(typeof(Vxi11.CREATE_LINK_CALL)), handle.Length);
            gchw.Free();
            rpc.Call(packet, true, true);

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.CREATE_LINK_REPLY))];
            rpc.GetReply(buffer, true);

            Vxi11.CREATE_LINK_REPLY reply = new Vxi11.CREATE_LINK_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.error = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.lid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));
            reply.abortPort = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 32));
            reply.maxRecvSize = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 36));
            lid = reply.lid;
            abortPort = reply.abortPort;
            maxRecvSize = reply.maxRecvSize;
            return reply.error;
        }
        // call device_write
        internal static int DeviceWrite(ClientRpcTcp rpc, int xid, int lid, Vxi11.Flags flags, int lock_timeout, int io_timeout, byte[] data, out int data_len)
        {
            Vxi11.DEVICE_WRITE_CALL arg = new Vxi11.DEVICE_WRITE_CALL();
            arg.xid = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE);
            arg.vers = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE_VERSION);
            arg.proc = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_WRITE);
            arg.cred_flavor = IPAddress.HostToNetworkOrder(0);
            arg.cred_len = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor = IPAddress.HostToNetworkOrder(0);
            arg.verf_len = IPAddress.HostToNetworkOrder(0);
            arg.lid = IPAddress.HostToNetworkOrder(lid);
            arg.flags = IPAddress.HostToNetworkOrder((int)flags);
            arg.lock_timeout = IPAddress.HostToNetworkOrder(lock_timeout);
            arg.io_timeout = IPAddress.HostToNetworkOrder(io_timeout);
            arg.data_len = IPAddress.HostToNetworkOrder(data.Length);

            int size = Marshal.SizeOf(typeof(Vxi11.DEVICE_WRITE_CALL)) + data.Length;
            size = ((size / 4) + 1) * 4;
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(data, 0, packet, Marshal.SizeOf(typeof(Vxi11.DEVICE_WRITE_CALL)), data.Length);
            gchw.Free();
            rpc.Call(packet, true, true);

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_WRITE_REPLY))];
            rpc.GetReply(buffer, true);

            Vxi11.DEVICE_WRITE_REPLY reply = new Vxi11.DEVICE_WRITE_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.error = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.data_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));
            data_len = reply.data_len;
            return reply.error;
        }
        // call device_read
        internal static int DeviceRead(ClientRpcTcp rpc, int xid, int lid, int requestSize, Vxi11.Flags flags, int lock_timeout, int io_timeout, Vxi11.TermChar term, out int reason, out byte[] data)
        {
            Vxi11.DEVICE_READ_CALL arg = new Vxi11.DEVICE_READ_CALL();
            arg.xid = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE);
            arg.vers = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE_VERSION);
            arg.proc = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_READ);
            arg.cred_flavor = IPAddress.HostToNetworkOrder(0);
            arg.cred_len = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor = IPAddress.HostToNetworkOrder(0);
            arg.verf_len = IPAddress.HostToNetworkOrder(0);
            arg.lid = IPAddress.HostToNetworkOrder(lid);
            arg.requestSize = IPAddress.HostToNetworkOrder(requestSize);
            arg.io_timeout = IPAddress.HostToNetworkOrder(io_timeout);
            arg.lock_timeout = IPAddress.HostToNetworkOrder(lock_timeout);
            arg.flags = IPAddress.HostToNetworkOrder((int)flags);
            arg.termChar = IPAddress.HostToNetworkOrder((int)term);
            byte[] packet = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_READ_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            rpc.Call(packet, true, true);

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_READ_REPLY))];
            rpc.GetReply(buffer, true);

            Vxi11.DEVICE_READ_REPLY reply = new Vxi11.DEVICE_READ_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.error = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.reason = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));
            reply.data_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 32));

            reason = reply.reason;
            data = new Byte[reply.data_len];
            rpc.GetReply(data, false);
            rpc.ClearReply();
            return reply.error;
        }
        // call device_readstb
        internal static int DeviceReadstb(ClientRpcTcp rpc, int xid, int lid, Vxi11.Flags flags, int lock_timeout, int io_timeout, out char stb)
        {
            Vxi11.DEVICE_GENERIC_CALL arg = new Vxi11.DEVICE_GENERIC_CALL();
            arg.xid = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE);
            arg.vers = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE_VERSION);
            arg.proc = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_READSTB);
            arg.cred_flavor = IPAddress.HostToNetworkOrder(0);
            arg.cred_len = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor = IPAddress.HostToNetworkOrder(0);
            arg.verf_len = IPAddress.HostToNetworkOrder(0);
            arg.lid = IPAddress.HostToNetworkOrder(lid);
            arg.flags = IPAddress.HostToNetworkOrder((int)flags);
            arg.lock_timeout = IPAddress.HostToNetworkOrder(lock_timeout);
            arg.io_timeout = IPAddress.HostToNetworkOrder(io_timeout);

            byte[] packet = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            rpc.Call(packet, true, true);

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_READSTB_REPLY))];
            rpc.GetReply(buffer, true);

            Vxi11.DEVICE_READSTB_REPLY reply = new Vxi11.DEVICE_READSTB_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.error = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.stb = (byte)buffer[28];
            stb = (char)reply.stb;
            return reply.error;
        }
        // call device_trigger
        internal static int DeviceTrigger(ClientRpcTcp rpc, int xid, int lid, Vxi11.Flags flags, int lock_timeout, int io_timeout)
        {
            Vxi11.DEVICE_GENERIC_CALL arg = new Vxi11.DEVICE_GENERIC_CALL();
            arg.xid = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE);
            arg.vers = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE_VERSION);
            arg.proc = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_TRIGGER);
            arg.cred_flavor = IPAddress.HostToNetworkOrder(0);
            arg.cred_len = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor = IPAddress.HostToNetworkOrder(0);
            arg.verf_len = IPAddress.HostToNetworkOrder(0);
            arg.lid = IPAddress.HostToNetworkOrder(lid);
            arg.flags = IPAddress.HostToNetworkOrder((int)flags);
            arg.lock_timeout = IPAddress.HostToNetworkOrder(lock_timeout);
            arg.io_timeout = IPAddress.HostToNetworkOrder(io_timeout);

            byte[] packet = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            rpc.Call(packet, true, true);

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_REPLY))];
            rpc.GetReply(buffer, true);

            Vxi11.DEVICE_GENERIC_REPLY reply = new Vxi11.DEVICE_GENERIC_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.error = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            return reply.error;
        }
        // call device_clear
        internal static int DeviceClear(ClientRpcTcp rpc, int xid, int lid, Vxi11.Flags flags, int lock_timeout, int io_timeout)
        {
            Vxi11.DEVICE_GENERIC_CALL arg = new Vxi11.DEVICE_GENERIC_CALL();
            arg.xid = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE);
            arg.vers = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE_VERSION);
            arg.proc = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CLEAR);
            arg.cred_flavor = IPAddress.HostToNetworkOrder(0);
            arg.cred_len = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor = IPAddress.HostToNetworkOrder(0);
            arg.verf_len = IPAddress.HostToNetworkOrder(0);
            arg.lid = IPAddress.HostToNetworkOrder(lid);
            arg.flags = IPAddress.HostToNetworkOrder((int)flags);
            arg.lock_timeout = IPAddress.HostToNetworkOrder(lock_timeout);
            arg.io_timeout = IPAddress.HostToNetworkOrder(io_timeout);

            byte[] packet = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            rpc.Call(packet, true, true);

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_REPLY))];
            rpc.GetReply(buffer, true);

            Vxi11.DEVICE_GENERIC_REPLY reply = new Vxi11.DEVICE_GENERIC_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.error = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            return reply.error;
        }
        // call device_remote
        internal static int DeviceRemote(ClientRpcTcp rpc, int xid, int lid, Vxi11.Flags flags, int lock_timeout, int io_timeout)
        {
            Vxi11.DEVICE_GENERIC_CALL arg = new Vxi11.DEVICE_GENERIC_CALL();
            arg.xid = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE);
            arg.vers = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE_VERSION);
            arg.proc = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_REMOTE);
            arg.cred_flavor = IPAddress.HostToNetworkOrder(0);
            arg.cred_len = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor = IPAddress.HostToNetworkOrder(0);
            arg.verf_len = IPAddress.HostToNetworkOrder(0);
            arg.lid = IPAddress.HostToNetworkOrder(lid);
            arg.flags = IPAddress.HostToNetworkOrder((int)flags);
            arg.lock_timeout = IPAddress.HostToNetworkOrder(lock_timeout);
            arg.io_timeout = IPAddress.HostToNetworkOrder(io_timeout);

            byte[] packet = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            rpc.Call(packet, true, true);

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_REPLY))];
            rpc.GetReply(buffer, true);

            Vxi11.DEVICE_GENERIC_REPLY reply = new Vxi11.DEVICE_GENERIC_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.error = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            return reply.error;
        }
        // call device_local
        internal static int DeviceLocal(ClientRpcTcp rpc, int xid, int lid, Vxi11.Flags flags, int lock_timeout, int io_timeout)
        {
            Vxi11.DEVICE_GENERIC_CALL arg = new Vxi11.DEVICE_GENERIC_CALL();
            arg.xid = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE);
            arg.vers = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE_VERSION);
            arg.proc = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_LOCAL);
            arg.cred_flavor = IPAddress.HostToNetworkOrder(0);
            arg.cred_len = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor = IPAddress.HostToNetworkOrder(0);
            arg.verf_len = IPAddress.HostToNetworkOrder(0);
            arg.lid = IPAddress.HostToNetworkOrder(lid);
            arg.flags = IPAddress.HostToNetworkOrder((int)flags);
            arg.lock_timeout = IPAddress.HostToNetworkOrder(lock_timeout);
            arg.io_timeout = IPAddress.HostToNetworkOrder(io_timeout);

            byte[] packet = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            rpc.Call(packet, true, true);

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_REPLY))];
            rpc.GetReply(buffer, true);

            Vxi11.DEVICE_GENERIC_REPLY reply = new Vxi11.DEVICE_GENERIC_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.error = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            return reply.error;
        }
        // call device_lock
        internal static int DeviceLock(ClientRpcTcp rpc, int xid, int lid, Vxi11.Flags flags, int lock_timeout)
        {
            Vxi11.DEVICE_LOCK_CALL arg = new Vxi11.DEVICE_LOCK_CALL();
            arg.xid = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE);
            arg.vers = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE_VERSION);
            arg.proc = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_LOCK);
            arg.cred_flavor = IPAddress.HostToNetworkOrder(0);
            arg.cred_len = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor = IPAddress.HostToNetworkOrder(0);
            arg.verf_len = IPAddress.HostToNetworkOrder(0);
            arg.lid = IPAddress.HostToNetworkOrder(lid);
            arg.flags = IPAddress.HostToNetworkOrder((int)flags);
            arg.lock_timeout = IPAddress.HostToNetworkOrder(lock_timeout);

            byte[] packet = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_LOCK_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            rpc.Call(packet, true, true);

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_REPLY))];
            rpc.GetReply(buffer, true);

            Vxi11.DEVICE_GENERIC_REPLY reply = new Vxi11.DEVICE_GENERIC_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.error = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            return reply.error;
        }
        // call device_unlock
        internal static int DeviceUnlock(ClientRpcTcp rpc, int xid, int lid)
        {
            Vxi11.DEVICE_UNLOCK_CALL arg = new Vxi11.DEVICE_UNLOCK_CALL();
            arg.xid = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE);
            arg.vers = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE_VERSION);
            arg.proc = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_UNLOCK);
            arg.cred_flavor = IPAddress.HostToNetworkOrder(0);
            arg.cred_len = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor = IPAddress.HostToNetworkOrder(0);
            arg.verf_len = IPAddress.HostToNetworkOrder(0);
            arg.lid = IPAddress.HostToNetworkOrder(lid);

            byte[] packet = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_UNLOCK_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            rpc.Call(packet, true, true);

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_REPLY))];
            rpc.GetReply(buffer, true);

            Vxi11.DEVICE_GENERIC_REPLY reply = new Vxi11.DEVICE_GENERIC_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.error = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            return reply.error;
        }
        // call create_intr_chan
        internal static int CreateIntrChan(ClientRpcTcp rpc, int xid, int hostaddr, int hostport, int prognum, int progvers, int progfamily)
        {
            Vxi11.CREATE_INTR_CHAN_CALL arg = new Vxi11.CREATE_INTR_CHAN_CALL();
            arg.xid = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE);
            arg.vers = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE_VERSION);
            arg.proc = IPAddress.HostToNetworkOrder(Vxi11.CREATE_INTR_CHAN);
            arg.cred_flavor = IPAddress.HostToNetworkOrder(0);
            arg.cred_len = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor = IPAddress.HostToNetworkOrder(0);
            arg.verf_len = IPAddress.HostToNetworkOrder(0);
            arg.hostaddr = IPAddress.HostToNetworkOrder(hostaddr);
            arg.hostport = IPAddress.HostToNetworkOrder(hostport);
            arg.prognum = IPAddress.HostToNetworkOrder(prognum);
            arg.progvers = IPAddress.HostToNetworkOrder(progvers);
            arg.progfamily = IPAddress.HostToNetworkOrder(progfamily);

            byte[] packet = new byte[Marshal.SizeOf(typeof(Vxi11.CREATE_INTR_CHAN_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            rpc.Call(packet, true, true);

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_REPLY))];
            rpc.GetReply(buffer, true);

            Vxi11.DEVICE_GENERIC_REPLY reply = new Vxi11.DEVICE_GENERIC_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.error = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            return reply.error;
        }
        // call destroy_intr_chan
        internal static int DestroyIntrChan(ClientRpcTcp rpc, int xid)
        {
            Vxi11.DESTROY_INTR_CHAN_CALL arg = new Vxi11.DESTROY_INTR_CHAN_CALL();
            arg.xid = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE);
            arg.vers = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE_VERSION);
            arg.proc = IPAddress.HostToNetworkOrder(Vxi11.DESTROY_INTR_CHAN);
            arg.cred_flavor = IPAddress.HostToNetworkOrder(0);
            arg.cred_len = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor = IPAddress.HostToNetworkOrder(0);
            arg.verf_len = IPAddress.HostToNetworkOrder(0);

            byte[] packet = new byte[Marshal.SizeOf(typeof(Vxi11.DESTROY_INTR_CHAN_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            rpc.Call(packet, true, true);

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_REPLY))];
            rpc.GetReply(buffer, true);

            Vxi11.DEVICE_GENERIC_REPLY reply = new Vxi11.DEVICE_GENERIC_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.error = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            return reply.error;
        }
        // call device_enable_srq
        internal static int DeviceEnableSrq(ClientRpcTcp rpc, int xid, int lid, int enable, byte[] handle)
        {
            Vxi11.DEVICE_ENABLE_SRQ_CALL arg = new Vxi11.DEVICE_ENABLE_SRQ_CALL();
            arg.xid = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE);
            arg.vers = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE_VERSION);
            arg.proc = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_ENABLE_SRQ);
            arg.cred_flavor = IPAddress.HostToNetworkOrder(0);
            arg.cred_len = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor = IPAddress.HostToNetworkOrder(0);
            arg.verf_len = IPAddress.HostToNetworkOrder(0);
            arg.lid = IPAddress.HostToNetworkOrder(lid);
            arg.enable = IPAddress.HostToNetworkOrder(enable);
            arg.handle_len = IPAddress.HostToNetworkOrder(handle.Length);

            int size = Marshal.SizeOf(typeof(Vxi11.DEVICE_ENABLE_SRQ_CALL)) + handle.Length;
            size = ((size / 4) + 1) * 4;
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(handle, 0, packet, Marshal.SizeOf(typeof(Vxi11.DEVICE_ENABLE_SRQ_CALL)), handle.Length);
            gchw.Free();
            rpc.Call(packet, true, true);

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_REPLY))];
            rpc.GetReply(buffer, true);

            Vxi11.DEVICE_GENERIC_REPLY reply = new Vxi11.DEVICE_GENERIC_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.error = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            return reply.error;
        }
        // call device_docmd
        internal static void DeviceDocmd(ClientRpcTcp rpc, int xid, int lid, Vxi11.Flags flags, int lock_timeout, int io_timeout, int cmd, int network_order, int datasize, byte[] data_in, out byte[] data_out)
        {
            Vxi11.DEVICE_DOCMD_CALL arg = new Vxi11.DEVICE_DOCMD_CALL();
            arg.xid = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE);
            arg.vers = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE_VERSION);
            arg.proc = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_DOCMD);
            arg.cred_flavor = IPAddress.HostToNetworkOrder(0);
            arg.cred_len = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor = IPAddress.HostToNetworkOrder(0);
            arg.verf_len = IPAddress.HostToNetworkOrder(0);
            arg.lid = IPAddress.HostToNetworkOrder(lid);
            arg.flags = IPAddress.HostToNetworkOrder((int)flags);
            arg.io_timeout = IPAddress.HostToNetworkOrder(io_timeout);
            arg.lock_timeout = IPAddress.HostToNetworkOrder(lock_timeout);
            arg.cmd = IPAddress.HostToNetworkOrder(cmd);
            arg.network_order = IPAddress.HostToNetworkOrder(network_order);
            arg.datasize = IPAddress.HostToNetworkOrder(datasize);
            arg.data_in_len = IPAddress.HostToNetworkOrder(data_in.Length);

            int size = Marshal.SizeOf(typeof(Vxi11.DEVICE_DOCMD_CALL)) + data_in.Length;
            size = ((size / 4) + 1) * 4;
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(data_in, 0, packet, Marshal.SizeOf(typeof(Vxi11.DEVICE_DOCMD_CALL)), data_in.Length);
            gchw.Free();
            rpc.Call(packet, true, true);

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_DOCMD_REPLY))];
            rpc.GetReply(buffer, true);

            Vxi11.DEVICE_DOCMD_REPLY reply = new Vxi11.DEVICE_DOCMD_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.error = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.data_out_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));
            data_out = new Byte[reply.data_out_len];
            rpc.GetReply(data_out, false);
            rpc.ClearReply();
        }
        // call destroy_link
        internal static int DestroyLink(ClientRpcTcp rpc, int xid, int lid)
        {
            Vxi11.DEVICE_GENERIC_CALL arg = new Vxi11.DEVICE_GENERIC_CALL();
            arg.xid = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE);
            arg.vers = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_CORE_VERSION);
            arg.proc = IPAddress.HostToNetworkOrder(Vxi11.DESTROY_LINK);
            arg.cred_flavor = IPAddress.HostToNetworkOrder(0);
            arg.cred_len = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor = IPAddress.HostToNetworkOrder(0);
            arg.verf_len = IPAddress.HostToNetworkOrder(0);
            arg.lid = IPAddress.HostToNetworkOrder(lid);

            byte[] packet = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            rpc.Call(packet, true, true);

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_REPLY))];
            rpc.GetReply(buffer, true);

            Vxi11.DEVICE_GENERIC_REPLY reply = new Vxi11.DEVICE_GENERIC_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.error = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            return reply.error;
        }
    }
    internal class AbortChannel
    {
        internal static int DeviceAbort(ClientRpcTcp rpc, int xid, int lid, Vxi11.Flags flags, int lock_timeout, int io_timeout)
        {
            Vxi11.DEVICE_GENERIC_CALL arg = new Vxi11.DEVICE_GENERIC_CALL();
            arg.xid = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_ABORT_PROG);
            arg.vers = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_ABORT_VERSION);
            arg.proc = IPAddress.HostToNetworkOrder(Vxi11.DEVICE_ABORT);
            arg.cred_flavor = IPAddress.HostToNetworkOrder(0);
            arg.cred_len = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor = IPAddress.HostToNetworkOrder(0);
            arg.verf_len = IPAddress.HostToNetworkOrder(0);
            arg.lid = IPAddress.HostToNetworkOrder(lid);
            arg.flags = IPAddress.HostToNetworkOrder((int)flags);
            arg.lock_timeout = IPAddress.HostToNetworkOrder(lock_timeout);
            arg.io_timeout = IPAddress.HostToNetworkOrder(io_timeout);

            byte[] packet = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            rpc.Call(packet, true, true);

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_REPLY))];
            rpc.GetReply(buffer, true);

            Vxi11.DEVICE_GENERIC_REPLY reply = new Vxi11.DEVICE_GENERIC_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.error = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            return reply.error;
        }
    }
    internal class InterruptChannel
    {
    }

    public class ClientVxi11
    {
        // call create_link
        public int CreateLink(int cliendId, int lockDevice, int lock_timeout, string handle, out int lid, out int abortPort, out int maxRecvSize)
        {
            byte[] array = System.Text.Encoding.ASCII.GetBytes(handle);
            int status = CoreChannel.CreateLink(clientCore, xid, cliendId, lockDevice, lock_timeout, array, out lid, out abortPort, out maxRecvSize);
            return status;
        }
        // call device_write
        public int DeviceWrite(int lid, Vxi11.Flags flags, int lock_timeout, int io_timeout, string data, out int data_len)
        {
            byte[] buff = System.Text.Encoding.ASCII.GetBytes(data);
            int status = CoreChannel.DeviceWrite(clientCore, xid, lid, flags, lock_timeout, io_timeout, buff, out data_len);
            return status;
        }
        // call device_read
        public int DeviceRead(int lid, int requestSize, Vxi11.Flags flags, int lock_timeout, int io_timeout, Vxi11.TermChar term, out int reason, out string data)
        {
            byte[] buf;
            int status = DeviceRead(lid, requestSize, flags, lock_timeout, io_timeout, term, out reason, out buf);
            data = System.Text.Encoding.ASCII.GetString(buf);
            return status;
        }
        public int DeviceRead(int lid, int requestSize, Vxi11.Flags flags, int lock_timeout, int io_timeout, Vxi11.TermChar term, out int reason, out byte[] data)
        {
            int status = CoreChannel.DeviceRead(clientCore, xid++, lid, requestSize, flags, lock_timeout, io_timeout, term, out reason, out data);
            return status;
        }
        // call device_readstb
        public int DeviceReadstb(int lid, Vxi11.Flags flags, int lock_timeout, int io_timeout, out char stb)
        {
            int status = CoreChannel.DeviceReadstb(clientCore, xid++, lid, flags, lock_timeout, io_timeout, out stb);
            return status;
        }
        // call device_trigger
        public int DeviceTrigger(int lid, Vxi11.Flags flags, int lock_timeout, int io_timeout)
        {
            int status = CoreChannel.DeviceTrigger(clientCore, xid++, lid, flags, lock_timeout, io_timeout);
            return status;
        }
        // call device_clear
        public int DeviceClear(int lid, Vxi11.Flags flags, int lock_timeout, int io_timeout)
        {
            int status = CoreChannel.DeviceClear(clientCore, xid++, lid, flags, lock_timeout, io_timeout);
            return status;
        }
        // call device_remote
        public int DeviceRemote(int lid, Vxi11.Flags flags, int lock_timeout, int io_timeout)
        {
            int status = CoreChannel.DeviceRemote(clientCore, xid++, lid, flags, lock_timeout, io_timeout);
            return status;
        }
        // call device_local
        public int DeviceLocal(int lid, Vxi11.Flags flags, int lock_timeout, int io_timeout)
        {
            int status = CoreChannel.DeviceLocal(clientCore, xid++, lid, flags, lock_timeout, io_timeout);
            return status;
        }
        // call device_lock
        public int DeviceLock(int lid, Vxi11.Flags flags, int lock_timeout)
        {
            int status = CoreChannel.DeviceLock(clientCore, xid++, lid, flags, lock_timeout);
            return status;
        }
        // call device_unlock
        public int DeviceUnlock(int lid)
        {
            int status = CoreChannel.DeviceUnlock(clientCore, xid++, lid);
            return status;
        }
        // call create_intr_chan
        public int CreateIntrChan(int hostaddr, int hostport, int prognum, int progvers, int progfamily)
        {
            int status = CoreChannel.CreateIntrChan(clientCore, xid++, hostaddr, hostport, prognum, progvers, progfamily);
            return status;
        }
        // call destroy_intr_chan
        public int DestroyIntrChan()
        {
            int status = CoreChannel.DestroyIntrChan(clientCore, xid++);
            return status;
        }
        // call device_enable_srq
        public int DeviceEnableSrq(int lid, int enable, string handle)
        {
            byte[] array = System.Text.Encoding.ASCII.GetBytes(handle);
            int status = CoreChannel.DeviceEnableSrq(clientCore, xid++, lid, enable, array);
            return status;
        }
        // call device_docmd
        public void DeviceDocmd(int lid, Vxi11.Flags flags, int lock_timeout, int io_timeout, int cmd, int network_order, int datasize, byte[] data_in, out byte[] data_out)
        {
            CoreChannel.DeviceDocmd(clientCore, xid++, lid, flags, lock_timeout, io_timeout, cmd, network_order, datasize, data_in, out data_out);
        }
        // call destroy_link
        public int DestroyLink(int lid)
        {
            int status = CoreChannel.DestroyLink(clientCore, xid++, lid);
            return status;
        }
        // call device_abort
        public int DeviceAbort(int lid, Vxi11.Flags flags, int lock_timeout, int io_timeout)
        {
            int status = AbortChannel.DeviceAbort(clientAbort, xid++, lid, flags, lock_timeout, io_timeout);
            return status;
        }
        private ClientRpcTcp clientCore = new ClientRpcTcp();
        private ClientRpcTcp clientAbort = new ClientRpcTcp();
        private ServerRpcTcp serverInterrupt = new ServerRpcTcp();
        private int xid = 123;
        public void Create(string host, int port)
        {
            clientCore.Create(host, port);
        }
        public void CreateAbortChannel(string host, int port)
        {
            clientAbort.Create(host, port);
        }
        public void Destroy()
        {
            clientCore.Destroy();
            clientAbort.Destroy();
            serverInterrupt.Destroy();
        }
        public void DestroyAbortChannel()
        {
            clientAbort.Destroy();
        }
        public void CreateInterruptChannel(string host, int port)
        {
            serverInterrupt.Create(host, port);
        }
        public void DestroyInterruptChannel()
        {
            serverInterrupt.Destroy();
        }
    }
}