using System;
using System.Net;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Vxi11Net
{
    public class ClientVxi11
    {
        private CoreChannel coreChannel = new CoreChannel();
        private AbortChannel abortChannel = new AbortChannel();
        private InterruptChannel interruptChannel = new InterruptChannel();

        public void Create(string host, int port)
        {
            coreChannel.Create(host, port);
        }
        public void Destroy()
        {
            coreChannel.Destroy();
            abortChannel.Destroy();
            interruptChannel.Destroy();
        }
        public void DestroyAbortChannel()
        {
            abortChannel.Destroy();
        }
        public void CreateInterruptChannel(string host, int port)
        {
            interruptChannel.Create(host, port);
        }
        public void DestroyInterruptChannel()
        {
            interruptChannel.Destroy();
        }

        // call create_link
        public int CreateLink(int cliendId, int lockDevice, int lock_timeout, string handle, out int lid, out int abortPort, out int maxRecvSize)
        {
            int status = coreChannel.CreateLink(cliendId, lockDevice, lock_timeout, handle, out lid, out abortPort, out maxRecvSize);
            return status;
        }
        // call device_write
        public int DeviceWrite(int lid, Vxi11.Flags flags, int lock_timeout, int io_timeout, string data, out int data_len)
        {
            byte[] buff = System.Text.Encoding.ASCII.GetBytes(data);
            int status = coreChannel.DeviceWrite(lid, flags, lock_timeout, io_timeout, buff, out data_len);
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
            int status = coreChannel.DeviceRead(lid, requestSize, flags, lock_timeout, io_timeout, term, out reason, out data);
            return status;
        }
        // call device_readstb
        public int DeviceReadstb(int lid, Vxi11.Flags flags, int lock_timeout, int io_timeout, out char stb)
        {
            int status = coreChannel.DeviceReadstb(lid, flags, lock_timeout, io_timeout, out stb);
            return status;
        }
        // call device_trigger
        public int DeviceTrigger(int lid, Vxi11.Flags flags, int lock_timeout, int io_timeout)
        {
            int status = coreChannel.DeviceTrigger(lid, flags, lock_timeout, io_timeout);
            return status;
        }
        // call device_clear
        public int DeviceClear(int lid, Vxi11.Flags flags, int lock_timeout, int io_timeout)
        {
            int status = coreChannel.DeviceClear(lid, flags, lock_timeout, io_timeout);
            return status;
        }
        // call device_remote
        public int DeviceRemote(int lid, Vxi11.Flags flags, int lock_timeout, int io_timeout)
        {
            int status = coreChannel.DeviceRemote(lid, flags, lock_timeout, io_timeout);
            return status;
        }
        // call device_local
        public int DeviceLocal(int lid, Vxi11.Flags flags, int lock_timeout, int io_timeout)
        {
            int status = coreChannel.DeviceLocal(lid, flags, lock_timeout, io_timeout);
            return status;
        }
        // call device_lock
        public int DeviceLock(int lid, Vxi11.Flags flags, int lock_timeout)
        {
            int status = coreChannel.DeviceLock(lid, flags, lock_timeout);
            return status;
        }
        // call device_unlock
        public int DeviceUnlock(int lid)
        {
            int status = coreChannel.DeviceUnlock(lid);
            return status;
        }
        // call create_intr_chan
        public int CreateIntrChan(int hostaddr, int hostport, int prognum, int progvers, int progfamily)
        {
            int status = coreChannel.CreateIntrChan(hostaddr, hostport, prognum, progvers, progfamily);
            return status;
        }
        // call destroy_intr_chan
        public int DestroyIntrChan()
        {
            int status = coreChannel.DestroyIntrChan();
            return status;
        }
        // call device_enable_srq
        public int DeviceEnableSrq(int lid, int enable, string handle)
        {
            int status = coreChannel.DeviceEnableSrq(lid, enable, handle);
            return status;
        }
        // call device_docmd
        public void DeviceDocmd(int lid, Vxi11.Flags flags, int lock_timeout, int io_timeout, int cmd, int network_order, int datasize, byte[] data_in, out byte[] data_out)
        {
            coreChannel.DeviceDocmd(lid, flags, lock_timeout, io_timeout, cmd, network_order, datasize, data_in, out data_out);
        }
        // call destroy_link
        public int DestroyLink(int lid)
        {
            int status = coreChannel.DestroyLink(lid);
            return status;
        }
        // call device_abort
        public int DeviceAbort(int lid, Vxi11.Flags flags, int lock_timeout, int io_timeout)
        {
            int status = abortChannel.DeviceAbort(lid, flags, lock_timeout, io_timeout);
            return status;
        }
    }
    public class CoreChannel
    {
        private ClientRpc rpc = new ClientRpc();
        public Socket Create(string host, int port)
        {
            Socket socket = rpc.CreateTcp(host, port);
            return socket;
        }
        public void Destroy()
        {
            rpc.Destroy();
        }

        // call create_link
        public int CreateLink(int cliendId, int lockDevice, int lock_timeout, string handle, out int lid, out int abortPort, out int maxRecvSize)
        {
            byte[] str = System.Text.Encoding.ASCII.GetBytes(handle);
            int size = Marshal.SizeOf(typeof(Vxi11.CREATE_LINK_CALL)) + str.Length;
            size = ((size / 4) + 1) * 4;
            Vxi11.CREATE_LINK_CALL arg = new Vxi11.CREATE_LINK_CALL();
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
            arg.handle_len = IPAddress.HostToNetworkOrder(str.Length);
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(str, 0, packet, Marshal.SizeOf(typeof(Vxi11.CREATE_LINK_CALL)), str.Length);
            gchw.Free();
            rpc.Call(packet, true, true);

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.CREATE_LINK_REPLY))];
            rpc.GetReply(buffer);
            Vxi11.CREATE_LINK_REPLY reply = new Vxi11.CREATE_LINK_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));
            reply.lid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 32));
            reply.abortPort = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 36));
            reply.maxRecvSize = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 40));
            lid = reply.lid;
            abortPort = reply.abortPort;
            maxRecvSize = reply.maxRecvSize;

            return reply.error;
        }
        // call device_write
        public int DeviceWrite(int lid, Vxi11.Flags flags, int lock_timeout, int io_timeout, byte[] data, out int data_len)
        {
            int size = Marshal.SizeOf(typeof(Vxi11.DEVICE_WRITE_CALL)) + data.Length;
            size = ((size / 4) + 1) * 4;
            Vxi11.DEVICE_WRITE_CALL arg = new Vxi11.DEVICE_WRITE_CALL();
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
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(data, 0, packet, Marshal.SizeOf(typeof(Vxi11.DEVICE_WRITE_CALL)), data.Length);
            gchw.Free();
            rpc.Call(packet, true, true);

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_WRITE_REPLY))];
            rpc.GetReply(buffer);
            Vxi11.DEVICE_WRITE_REPLY reply = new Vxi11.DEVICE_WRITE_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));
            reply.data_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 32));
            data_len = reply.data_len;

            return reply.error;
        }
        // call device_read
        public int DeviceRead(int lid, int requestSize, Vxi11.Flags flags, int lock_timeout, int io_timeout, Vxi11.TermChar term, out int reason, out byte[] data)
        {
            Vxi11.DEVICE_READ_CALL arg = new Vxi11.DEVICE_READ_CALL();
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
            rpc.GetReply(buffer);
            Vxi11.DEVICE_READ_REPLY reply = new Vxi11.DEVICE_READ_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));
            reply.reason = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 32));
            reply.data_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 36));
            reason = reply.reason;
            data = new Byte[reply.data_len];
            rpc.GetReply(data);
            rpc.ClearReply();

            return reply.error;
        }
        // call device_readstb
        public int DeviceReadstb(int lid, Vxi11.Flags flags, int lock_timeout, int io_timeout, out char stb)
        {
            Vxi11.DEVICE_GENERIC_CALL arg = new Vxi11.DEVICE_GENERIC_CALL();
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
            rpc.GetReply(buffer);
            Vxi11.DEVICE_READSTB_REPLY reply = new Vxi11.DEVICE_READSTB_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));
            reply.stb = (byte)buffer[32];
            stb = (char)reply.stb;

            return reply.error;
        }
        // call device_trigger
        public int DeviceTrigger(int lid, Vxi11.Flags flags, int lock_timeout, int io_timeout)
        {
            Vxi11.DEVICE_GENERIC_CALL arg = new Vxi11.DEVICE_GENERIC_CALL();
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
            rpc.GetReply(buffer);
            Vxi11.DEVICE_GENERIC_REPLY reply = new Vxi11.DEVICE_GENERIC_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));

            return reply.error;
        }
        // call device_clear
        public int DeviceClear(int lid, Vxi11.Flags flags, int lock_timeout, int io_timeout)
        {
            Vxi11.DEVICE_GENERIC_CALL arg = new Vxi11.DEVICE_GENERIC_CALL();
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
            rpc.GetReply(buffer);
            Vxi11.DEVICE_GENERIC_REPLY reply = new Vxi11.DEVICE_GENERIC_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));

            return reply.error;
        }
        // call device_remote
        public int DeviceRemote(int lid, Vxi11.Flags flags, int lock_timeout, int io_timeout)
        {
            Vxi11.DEVICE_GENERIC_CALL arg = new Vxi11.DEVICE_GENERIC_CALL();
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
            rpc.GetReply(buffer);
            Vxi11.DEVICE_GENERIC_REPLY reply = new Vxi11.DEVICE_GENERIC_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));

            return reply.error;
        }
        // call device_local
        public int DeviceLocal(int lid, Vxi11.Flags flags, int lock_timeout, int io_timeout)
        {
            Vxi11.DEVICE_GENERIC_CALL arg = new Vxi11.DEVICE_GENERIC_CALL();
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
            rpc.GetReply(buffer);
            Vxi11.DEVICE_GENERIC_REPLY reply = new Vxi11.DEVICE_GENERIC_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));

            return reply.error;
        }
        // call device_lock
        public int DeviceLock(int lid, Vxi11.Flags flags, int lock_timeout)
        {
            Vxi11.DEVICE_LOCK_CALL arg = new Vxi11.DEVICE_LOCK_CALL();
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
            rpc.GetReply(buffer);
            Vxi11.DEVICE_GENERIC_REPLY reply = new Vxi11.DEVICE_GENERIC_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));

            return reply.error;
        }
        // call device_unlock
        public int DeviceUnlock(int lid)
        {
            Vxi11.DEVICE_UNLOCK_CALL arg = new Vxi11.DEVICE_UNLOCK_CALL();
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
            rpc.GetReply(buffer);
            Vxi11.DEVICE_GENERIC_REPLY reply = new Vxi11.DEVICE_GENERIC_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));

            return reply.error;
        }
        // call create_intr_chan
        public int CreateIntrChan(int hostaddr, int hostport, int prognum, int progvers, int progfamily)
        {
            Vxi11.CREATE_INTR_CHAN_CALL arg = new Vxi11.CREATE_INTR_CHAN_CALL();
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
            rpc.GetReply(buffer);
            Vxi11.DEVICE_GENERIC_REPLY reply = new Vxi11.DEVICE_GENERIC_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));

            return reply.error;
        }
        // call destroy_intr_chan
        public int DestroyIntrChan()
        {
            Vxi11.DESTROY_INTR_CHAN_CALL arg = new Vxi11.DESTROY_INTR_CHAN_CALL();
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
            rpc.GetReply(buffer);
            Vxi11.DEVICE_GENERIC_REPLY reply = new Vxi11.DEVICE_GENERIC_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));

            return reply.error;
        }
        // call device_enable_srq
        public int DeviceEnableSrq(int lid, int enable, string handle)
        {
            byte[] str = System.Text.Encoding.ASCII.GetBytes(handle);
            int size = Marshal.SizeOf(typeof(Vxi11.DEVICE_ENABLE_SRQ_CALL)) + str.Length;
            size = ((size / 4) + 1) * 4;
            Vxi11.DEVICE_ENABLE_SRQ_CALL arg = new Vxi11.DEVICE_ENABLE_SRQ_CALL();
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
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(str, 0, packet, Marshal.SizeOf(typeof(Vxi11.DEVICE_ENABLE_SRQ_CALL)), str.Length);
            gchw.Free();
            rpc.Call(packet, true, true);

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_REPLY))];
            rpc.GetReply(buffer);
            Vxi11.DEVICE_GENERIC_REPLY reply = new Vxi11.DEVICE_GENERIC_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));

            return reply.error;
        }
        // call device_docmd
        public void DeviceDocmd(int lid, Vxi11.Flags flags, int lock_timeout, int io_timeout, int cmd, int network_order, int datasize, byte[] data_in, out byte[] data_out)
        {
            Vxi11.DEVICE_DOCMD_CALL arg = new Vxi11.DEVICE_DOCMD_CALL();
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
            rpc.GetReply(buffer);
            Vxi11.DEVICE_DOCMD_REPLY reply = new Vxi11.DEVICE_DOCMD_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));
            reply.data_out_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 32));
            data_out = new Byte[reply.data_out_len];
            rpc.GetReply(data_out);
            rpc.ClearReply();
        }
        // call destroy_link
        public int DestroyLink(int lid)
        {
            Vxi11.DEVICE_GENERIC_CALL arg = new Vxi11.DEVICE_GENERIC_CALL();
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
            rpc.GetReply(buffer);
            Vxi11.DEVICE_GENERIC_REPLY reply = new Vxi11.DEVICE_GENERIC_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));

            return reply.error;
        }
    }
    public class AbortChannel
    {
        private ClientRpc rpc = new ClientRpc();
        public Socket Create(string host, int port)
        {
            Socket socket = rpc.CreateTcp(host, port);
            return socket;
        }
        public void Destroy()
        {
            rpc.Destroy();
        }
        public int DeviceAbort(int lid, Vxi11.Flags flags, int lock_timeout, int io_timeout)
        {
            Vxi11.DEVICE_GENERIC_CALL arg = new Vxi11.DEVICE_GENERIC_CALL();
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
            rpc.GetReply(buffer);
            Vxi11.DEVICE_GENERIC_REPLY reply = new Vxi11.DEVICE_GENERIC_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));

            return reply.error;
        }
    }
    public class InterruptChannel
    {
        private ServerRpc rpc = new ServerRpc();
        public Socket Create(string host, int port)
        {
            Socket socket = rpc.CreateTcp(host, port);
            return socket;
        }
        public void Destroy()
        {
            rpc.Destroy();
        }
    }
}