using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

namespace VXI11Net
{
    public class Client
    {
        public const int CALL                 = 0;
        public const int RPC_PORT             = 111;
        public const int RPC_VER              = 2;
        public const int DEVICE_CORE          = 395183;
        public const int DEVICE_CORE_VERSION  = 1;
        public const int CREATE_LINK          = 10;
        public const int DEVICE_WRITE         = 11;
        public const int DEVICE_READ          = 12;
        public const int DEVICE_READSTB       = 13;
        public const int DEVICE_TRIGGER       = 14;
        public const int DEVICE_CLEAR         = 15;
        public const int DEVICE_REMOTE        = 16;
        public const int DEVICE_LOCAL         = 17;
        public const int DEVICE_LOCK          = 18;
        public const int DEVICE_UNLOCK        = 19;
        public const int DEVICE_ENABLE_SRQ    = 20;
        public const int DEVICE_DOCMD         = 22;
        public const int DESTROY_LINK         = 23;
        public const int CREATE_INTR_CHAN     = 25;
        public const int DESTROY_INTR_CHAN    = 26;
        public const int DEVICE_ASYNC         = 395184;
        public const int DEVICE_ASYNC_VERSION = 1;
        public const int DEVICE_ABORT         = 1;

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct CREATE_LINK_CALL
        {
            public int fheader;
            public int xid;
            public int mtype;
            public int rpcvers;
            public int prog;
            public int vers;
            public int proc;
            public int cred_flavor;
            public int cred_len;
            public int verf_flavor;
            public int verf_len;
            public int clientId;
            public int lockDevice;
            public int lock_timeout;
            public int handle_len;
        };
        public struct CREATE_LINK_REPLY
        {
            public int fheader;
            public int xid;
            public int mtype;
            public int stat;
            public int verf_flavor;
            public int verf_len;
            public int accept_stat;
            public int error;
            public int lid;
            public int abortPort;
            public int maxRecvSize;
        };
        public struct DEVICE_WRITE_CALL
        {
            public int fheader;
            public int xid;
            public int mtype;
            public int rpcvers;
            public int prog;
            public int vers;
            public int proc;
            public int cred_flavor;
            public int cred_len;
            public int verf_flavor;
            public int verf_len;
            public int lid;
            public int flags;
            public int lock_timeout;
            public int io_timeout;
            public int data_len;
        };
        public struct DEVICE_WRITE_REPLY
        {
            public int fheader;
            public int xid;
            public int mtype;
            public int stat;
            public int verf_flavor;
            public int verf_len;
            public int accept_stat;
            public int error;
            public int data_len;
        };
        public struct DEVICE_READ_CALL
        {
            public int fheader;
            public int xid;
            public int mtype;
            public int rpcvers;
            public int prog;
            public int vers;
            public int proc;
            public int cred_flavor;
            public int cred_len;
            public int verf_flavor;
            public int verf_len;
            public int lid;
            public int requestSize;
            public int io_timeout;
            public int lock_timeout;
            public int flags;
            public int termChar;
        };
        public struct DEVICE_READ_REPLY
        {
            public int fheader;
            public int xid;
            public int mtype;
            public int stat;
            public int verf_flavor;
            public int verf_len;
            public int accept_stat;
            public int error;
            public int reason;
            public int data_len;
        };
        public struct DEVICE_GENERIC_CALL
        {
            public int fheader;
            public int xid;
            public int mtype;
            public int rpcvers;
            public int prog;
            public int vers;
            public int proc;
            public int cred_flavor;
            public int cred_len;
            public int verf_flavor;
            public int verf_len;
            public int lid;
            public int flags;
            public int lock_timeout;
            public int io_timeout;
        };
        public struct DEVICE_GENERIC_REPLY
        {
            public int fheader;
            public int xid;
            public int mtype;
            public int stat;
            public int verf_flavor;
            public int verf_len;
            public int accept_stat;
            public int error;
        };
        public struct DEVICE_LOCK_CALL
        {
            public int fheader;
            public int xid;
            public int mtype;
            public int rpcvers;
            public int prog;
            public int vers;
            public int proc;
            public int cred_flavor;
            public int cred_len;
            public int verf_flavor;
            public int verf_len;
            public int lid;
            public int flags;
            public int lock_timeout;
        };
        public struct DEVICE_UNLOCK_CALL
        {
            public int fheader;
            public int xid;
            public int mtype;
            public int rpcvers;
            public int prog;
            public int vers;
            public int proc;
            public int cred_flavor;
            public int cred_len;
            public int verf_flavor;
            public int verf_len;
            public int lid;
        };
        public struct CREATE_INTR_CHAN_CALL
        {
            public int fheader;
            public int xid;
            public int mtype;
            public int rpcvers;
            public int prog;
            public int vers;
            public int proc;
            public int cred_flavor;
            public int cred_len;
            public int verf_flavor;
            public int verf_len;
            public int hostaddr;
            public int hostport;
            public int prognum;
            public int progvers;
            public int progfamily;
        };
        public struct DESTROY_INTR_CHAN_CALL
        {
            public int fheader;
            public int xid;
            public int mtype;
            public int rpcvers;
            public int prog;
            public int vers;
            public int proc;
            public int cred_flavor;
            public int cred_len;
            public int verf_flavor;
            public int verf_len;
        };
        public struct DEVICE_ENABLE_SRQ_CALL
        {
            public int fheader;
            public int xid;
            public int mtype;
            public int rpcvers;
            public int prog;
            public int vers;
            public int proc;
            public int cred_flavor;
            public int cred_len;
            public int verf_flavor;
            public int verf_len;
            public int lid;
            public int enable;
            public int handle_len;
        };
        public struct DEVICE_READSTB_REPLY
        {
            public int fheader;
            public int xid;
            public int mtype;
            public int stat;
            public int verf_flavor;
            public int verf_len;
            public int accept_stat;
            public int error;
            public char stb;
        };
        public struct DEVICE_DOCMD_CALL
        {
            public int fheader;
            public int xid;
            public int mtype;
            public int rpcvers;
            public int prog;
            public int vers;
            public int proc;
            public int cred_flavor;
            public int cred_len;
            public int verf_flavor;
            public int verf_len;
            public int lid;
            public int flags;
            public int io_timeout;
            public int lock_timeout;
            public int cmd;
            public int network_order;
            public int datasize;
            public int data_in_len;
        };
        public struct DEVICE_DOCMD_REPLY
        {
            public int fheader;
            public int xid;
            public int mtype;
            public int stat;
            public int verf_flavor;
            public int verf_len;
            public int accept_stat;
            public int error;
            public int data_out_len;
        };
         // call create_link
        public static void create_link(Socket so, int xid, int cliendId, int lockDevice, int lock_timeout, string handle, out int lid, out int abortPort, out int maxRecvSize)
        {
            CREATE_LINK_CALL args = new CREATE_LINK_CALL();
            byte[] str = System.Text.Encoding.ASCII.GetBytes(handle);
            int size = Marshal.SizeOf(typeof(CREATE_LINK_CALL)) + str.Length;
            size = ((size / 4) + 1) * 4;
            args.fheader       = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            args.xid           = IPAddress.HostToNetworkOrder(xid);
            args.mtype         = IPAddress.HostToNetworkOrder(CALL);
            args.rpcvers       = IPAddress.HostToNetworkOrder(RPC_VER);
            args.prog          = IPAddress.HostToNetworkOrder(DEVICE_CORE);
            args.vers          = IPAddress.HostToNetworkOrder(DEVICE_CORE_VERSION);
            args.proc          = IPAddress.HostToNetworkOrder(CREATE_LINK);
            args.cred_flavor   = IPAddress.HostToNetworkOrder(0);
            args.cred_len      = IPAddress.HostToNetworkOrder(0);
            args.verf_flavor   = IPAddress.HostToNetworkOrder(0);
            args.verf_len      = IPAddress.HostToNetworkOrder(0);
            args.clientId      = IPAddress.HostToNetworkOrder(cliendId);
            args.lockDevice    = IPAddress.HostToNetworkOrder(lockDevice);
            args.lock_timeout  = IPAddress.HostToNetworkOrder(lock_timeout);
            args.handle_len    = IPAddress.HostToNetworkOrder(str.Length);
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(args, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(str, 0, packet, Marshal.SizeOf(typeof(CREATE_LINK_CALL)), str.Length);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(CREATE_LINK_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            CREATE_LINK_REPLY reply = new CREATE_LINK_REPLY();
            reply.fheader      = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.xid          = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.mtype        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
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
        }
        // call device_write
        public static void device_write(Socket so, int xid, int lid, int flags, int lock_timeout, int io_timeout, string data, out int data_len)
        {
            DEVICE_WRITE_CALL args = new DEVICE_WRITE_CALL();
            byte[] str = System.Text.Encoding.ASCII.GetBytes(data);
            int size = Marshal.SizeOf(typeof(DEVICE_WRITE_CALL)) + str.Length;
            size = ((size / 4) + 1) * 4;
            args.fheader       = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            args.xid           = IPAddress.HostToNetworkOrder(xid);
            args.mtype         = IPAddress.HostToNetworkOrder(CALL);
            args.rpcvers       = IPAddress.HostToNetworkOrder(RPC_VER);
            args.prog          = IPAddress.HostToNetworkOrder(DEVICE_CORE);
            args.vers          = IPAddress.HostToNetworkOrder(DEVICE_CORE_VERSION);
            args.proc          = IPAddress.HostToNetworkOrder(DEVICE_WRITE);
            args.cred_flavor   = IPAddress.HostToNetworkOrder(0);
            args.cred_len      = IPAddress.HostToNetworkOrder(0);
            args.verf_flavor   = IPAddress.HostToNetworkOrder(0);
            args.verf_len      = IPAddress.HostToNetworkOrder(0);
            args.lid           = IPAddress.HostToNetworkOrder(lid);
            args.flags         = IPAddress.HostToNetworkOrder(flags);
            args.lock_timeout  = IPAddress.HostToNetworkOrder(lock_timeout);
            args.io_timeout    = IPAddress.HostToNetworkOrder(io_timeout);
            args.data_len      = IPAddress.HostToNetworkOrder(str.Length);
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(args, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(str, 0, packet, Marshal.SizeOf(typeof(DEVICE_WRITE_CALL)), str.Length);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(DEVICE_WRITE_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            DEVICE_WRITE_REPLY reply = new DEVICE_WRITE_REPLY();
            reply.fheader      = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.xid          = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.mtype        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat         = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));
            reply.data_len     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 32));
            data_len           = reply.data_len;
        }
        // call device_read
        public static void device_read(Socket so, int xid, int lid, int requestSize, int flags, int lock_timeout, int io_timeout, int termchar, out int reason, out byte[] data)
        {
            DEVICE_READ_CALL args = new DEVICE_READ_CALL();
            int size = Marshal.SizeOf(typeof(DEVICE_READ_CALL));
            args.fheader       = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            args.xid           = IPAddress.HostToNetworkOrder(xid);
            args.mtype         = IPAddress.HostToNetworkOrder(CALL);
            args.rpcvers       = IPAddress.HostToNetworkOrder(RPC_VER);
            args.prog          = IPAddress.HostToNetworkOrder(DEVICE_CORE);
            args.vers          = IPAddress.HostToNetworkOrder(DEVICE_CORE_VERSION);
            args.proc          = IPAddress.HostToNetworkOrder(DEVICE_READ);
            args.cred_flavor   = IPAddress.HostToNetworkOrder(0);
            args.cred_len      = IPAddress.HostToNetworkOrder(0);
            args.verf_flavor   = IPAddress.HostToNetworkOrder(0);
            args.verf_len      = IPAddress.HostToNetworkOrder(0);
            args.lid           = IPAddress.HostToNetworkOrder(lid);
            args.requestSize   = IPAddress.HostToNetworkOrder(requestSize);
            args.io_timeout    = IPAddress.HostToNetworkOrder(io_timeout);
            args.lock_timeout  = IPAddress.HostToNetworkOrder(lock_timeout);
            args.flags         = IPAddress.HostToNetworkOrder(flags);
            args.termChar      = IPAddress.HostToNetworkOrder(termchar);
            byte[] packet = new byte[Marshal.SizeOf(typeof(DEVICE_READ_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(args, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(DEVICE_READ_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            DEVICE_READ_REPLY reply = new DEVICE_READ_REPLY();
            reply.fheader      = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.xid          = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.mtype        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat         = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));
            reply.reason       = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 32));
            reply.data_len     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 36));
            byte[] reply_data = new Byte[reply.data_len];
            byteCount = so.Receive(reply_data, SocketFlags.None);
            reason             = reply.reason;
            data               = reply_data;
        }
        // call device_readstb
        public static void device_readstb(Socket so, int xid, int lid, int flags, int lock_timeout, int io_timeout, out char stb)
        {
            DEVICE_GENERIC_CALL args = new DEVICE_GENERIC_CALL();
            int size = Marshal.SizeOf(typeof(DEVICE_GENERIC_CALL));
            args.fheader       = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            args.xid           = IPAddress.HostToNetworkOrder(xid);
            args.mtype         = IPAddress.HostToNetworkOrder(CALL);
            args.rpcvers       = IPAddress.HostToNetworkOrder(RPC_VER);
            args.prog          = IPAddress.HostToNetworkOrder(DEVICE_CORE);
            args.vers          = IPAddress.HostToNetworkOrder(DEVICE_CORE_VERSION);
            args.proc          = IPAddress.HostToNetworkOrder(DEVICE_READSTB);
            args.cred_flavor   = IPAddress.HostToNetworkOrder(0);
            args.cred_len      = IPAddress.HostToNetworkOrder(0);
            args.verf_flavor   = IPAddress.HostToNetworkOrder(0);
            args.verf_len      = IPAddress.HostToNetworkOrder(0);
            args.lid           = IPAddress.HostToNetworkOrder(lid);
            args.flags         = IPAddress.HostToNetworkOrder(flags);
            args.lock_timeout  = IPAddress.HostToNetworkOrder(lock_timeout);
            args.io_timeout    = IPAddress.HostToNetworkOrder(io_timeout);
            byte[] packet = new byte[Marshal.SizeOf(typeof(DEVICE_GENERIC_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(args, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(DEVICE_READSTB_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            DEVICE_READSTB_REPLY reply = new DEVICE_READSTB_REPLY();
            reply.fheader      = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.xid          = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.mtype        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat         = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));
            reply.stb          = (char)buffer[32];
            stb                = reply.stb;
        }
        // call device_trigger
        public static int device_trigger(Socket so, int xid, int lid, int flags, int lock_timeout, int io_timeout)
        {
            DEVICE_GENERIC_CALL args = new DEVICE_GENERIC_CALL();
            int size = Marshal.SizeOf(typeof(DEVICE_GENERIC_CALL));
            args.fheader       = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            args.xid           = IPAddress.HostToNetworkOrder(xid);
            args.mtype         = IPAddress.HostToNetworkOrder(CALL);
            args.rpcvers       = IPAddress.HostToNetworkOrder(RPC_VER);
            args.prog          = IPAddress.HostToNetworkOrder(DEVICE_CORE);
            args.vers          = IPAddress.HostToNetworkOrder(DEVICE_CORE_VERSION);
            args.proc          = IPAddress.HostToNetworkOrder(DEVICE_TRIGGER);
            args.cred_flavor   = IPAddress.HostToNetworkOrder(0);
            args.cred_len      = IPAddress.HostToNetworkOrder(0);
            args.verf_flavor   = IPAddress.HostToNetworkOrder(0);
            args.verf_len      = IPAddress.HostToNetworkOrder(0);
            args.lid           = IPAddress.HostToNetworkOrder(lid);
            args.flags         = IPAddress.HostToNetworkOrder(flags);
            args.lock_timeout  = IPAddress.HostToNetworkOrder(lock_timeout);
            args.io_timeout    = IPAddress.HostToNetworkOrder(io_timeout);
            byte[] packet = new byte[Marshal.SizeOf(typeof(DEVICE_GENERIC_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(args, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(DEVICE_GENERIC_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            DEVICE_GENERIC_REPLY reply = new DEVICE_GENERIC_REPLY();
            reply.fheader      = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.xid          = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.mtype        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat         = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));

            return reply.error;
        }
        // call device_clear
        public static int device_clear(Socket so, int xid, int lid, int flags, int lock_timeout, int io_timeout)
        {
            DEVICE_GENERIC_CALL args = new DEVICE_GENERIC_CALL();
            int size = Marshal.SizeOf(typeof(DEVICE_GENERIC_CALL));
            args.fheader       = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            args.xid           = IPAddress.HostToNetworkOrder(xid);
            args.mtype         = IPAddress.HostToNetworkOrder(CALL);
            args.rpcvers       = IPAddress.HostToNetworkOrder(RPC_VER);
            args.prog          = IPAddress.HostToNetworkOrder(DEVICE_CORE);
            args.vers          = IPAddress.HostToNetworkOrder(DEVICE_CORE_VERSION);
            args.proc          = IPAddress.HostToNetworkOrder(DEVICE_CLEAR);
            args.cred_flavor   = IPAddress.HostToNetworkOrder(0);
            args.cred_len      = IPAddress.HostToNetworkOrder(0);
            args.verf_flavor   = IPAddress.HostToNetworkOrder(0);
            args.verf_len      = IPAddress.HostToNetworkOrder(0);
            args.lid           = IPAddress.HostToNetworkOrder(lid);
            args.flags         = IPAddress.HostToNetworkOrder(flags);
            args.lock_timeout  = IPAddress.HostToNetworkOrder(lock_timeout);
            args.io_timeout    = IPAddress.HostToNetworkOrder(io_timeout);
            byte[] packet = new byte[Marshal.SizeOf(typeof(DEVICE_GENERIC_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(args, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(DEVICE_GENERIC_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            DEVICE_GENERIC_REPLY reply = new DEVICE_GENERIC_REPLY();
            reply.fheader      = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.xid          = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.mtype        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat         = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));

            return reply.error;
        }
        // call device_remote
        public static int device_remote(Socket so, int xid, int lid, int flags, int lock_timeout, int io_timeout)
        {
            DEVICE_GENERIC_CALL args = new DEVICE_GENERIC_CALL();
            int size = Marshal.SizeOf(typeof(DEVICE_GENERIC_CALL));
            args.fheader       = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            args.xid           = IPAddress.HostToNetworkOrder(xid);
            args.mtype         = IPAddress.HostToNetworkOrder(CALL);
            args.rpcvers       = IPAddress.HostToNetworkOrder(RPC_VER);
            args.prog          = IPAddress.HostToNetworkOrder(DEVICE_CORE);
            args.vers          = IPAddress.HostToNetworkOrder(DEVICE_CORE_VERSION);
            args.proc          = IPAddress.HostToNetworkOrder(DEVICE_REMOTE);
            args.cred_flavor   = IPAddress.HostToNetworkOrder(0);
            args.cred_len      = IPAddress.HostToNetworkOrder(0);
            args.verf_flavor   = IPAddress.HostToNetworkOrder(0);
            args.verf_len      = IPAddress.HostToNetworkOrder(0);
            args.lid           = IPAddress.HostToNetworkOrder(lid);
            args.flags         = IPAddress.HostToNetworkOrder(flags);
            args.lock_timeout  = IPAddress.HostToNetworkOrder(lock_timeout);
            args.io_timeout    = IPAddress.HostToNetworkOrder(io_timeout);
            byte[] packet = new byte[Marshal.SizeOf(typeof(DEVICE_GENERIC_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(args, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(DEVICE_GENERIC_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            DEVICE_GENERIC_REPLY reply = new DEVICE_GENERIC_REPLY();
            reply.fheader      = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.xid          = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.mtype        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat         = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));

            return reply.error;
        }
        // call device_local
        public static int device_local(Socket so, int xid, int lid, int flags, int lock_timeout, int io_timeout)
        {
            DEVICE_GENERIC_CALL args = new DEVICE_GENERIC_CALL();
            int size = Marshal.SizeOf(typeof(DEVICE_GENERIC_CALL));
            args.fheader       = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            args.xid           = IPAddress.HostToNetworkOrder(xid);
            args.mtype         = IPAddress.HostToNetworkOrder(CALL);
            args.rpcvers       = IPAddress.HostToNetworkOrder(RPC_VER);
            args.prog          = IPAddress.HostToNetworkOrder(DEVICE_CORE);
            args.vers          = IPAddress.HostToNetworkOrder(DEVICE_CORE_VERSION);
            args.proc          = IPAddress.HostToNetworkOrder(DEVICE_LOCAL);
            args.cred_flavor   = IPAddress.HostToNetworkOrder(0);
            args.cred_len      = IPAddress.HostToNetworkOrder(0);
            args.verf_flavor   = IPAddress.HostToNetworkOrder(0);
            args.verf_len      = IPAddress.HostToNetworkOrder(0);
            args.lid           = IPAddress.HostToNetworkOrder(lid);
            args.flags         = IPAddress.HostToNetworkOrder(flags);
            args.lock_timeout  = IPAddress.HostToNetworkOrder(lock_timeout);
            args.io_timeout    = IPAddress.HostToNetworkOrder(io_timeout);
            byte[] packet = new byte[Marshal.SizeOf(typeof(DEVICE_GENERIC_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(args, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(DEVICE_GENERIC_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            DEVICE_GENERIC_REPLY reply = new DEVICE_GENERIC_REPLY();
            reply.fheader      = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.xid          = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.mtype        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat         = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));

            return reply.error;
        }
        // call device_lock
        public static int device_lock(Socket so, int xid, int lid, int flags, int lock_timeout)
        {
            DEVICE_LOCK_CALL args = new DEVICE_LOCK_CALL();
            int size = Marshal.SizeOf(typeof(DEVICE_LOCK_CALL));
            args.fheader       = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            args.xid           = IPAddress.HostToNetworkOrder(xid);
            args.mtype         = IPAddress.HostToNetworkOrder(CALL);
            args.rpcvers       = IPAddress.HostToNetworkOrder(RPC_VER);
            args.prog          = IPAddress.HostToNetworkOrder(DEVICE_CORE);
            args.vers          = IPAddress.HostToNetworkOrder(DEVICE_CORE_VERSION);
            args.proc          = IPAddress.HostToNetworkOrder(DEVICE_LOCK);
            args.cred_flavor   = IPAddress.HostToNetworkOrder(0);
            args.cred_len      = IPAddress.HostToNetworkOrder(0);
            args.verf_flavor   = IPAddress.HostToNetworkOrder(0);
            args.verf_len      = IPAddress.HostToNetworkOrder(0);
            args.lid           = IPAddress.HostToNetworkOrder(lid);
            args.flags         = IPAddress.HostToNetworkOrder(flags);
            args.lock_timeout  = IPAddress.HostToNetworkOrder(lock_timeout);
            byte[] packet = new byte[Marshal.SizeOf(typeof(DEVICE_LOCK_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(args, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(DEVICE_GENERIC_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            DEVICE_GENERIC_REPLY reply = new DEVICE_GENERIC_REPLY();
            reply.fheader      = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.xid          = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.mtype        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat         = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));

            return reply.error;
        }
        // call device_unlock
        public static int device_unlock(Socket so, int xid, int lid)
        {
            DEVICE_UNLOCK_CALL args = new DEVICE_UNLOCK_CALL();
            int size = Marshal.SizeOf(typeof(DEVICE_UNLOCK_CALL));
            args.fheader       = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            args.xid           = IPAddress.HostToNetworkOrder(xid);
            args.mtype         = IPAddress.HostToNetworkOrder(CALL);
            args.rpcvers       = IPAddress.HostToNetworkOrder(RPC_VER);
            args.prog          = IPAddress.HostToNetworkOrder(DEVICE_CORE);
            args.vers          = IPAddress.HostToNetworkOrder(DEVICE_CORE_VERSION);
            args.proc          = IPAddress.HostToNetworkOrder(DEVICE_UNLOCK);
            args.cred_flavor   = IPAddress.HostToNetworkOrder(0);
            args.cred_len      = IPAddress.HostToNetworkOrder(0);
            args.verf_flavor   = IPAddress.HostToNetworkOrder(0);
            args.verf_len      = IPAddress.HostToNetworkOrder(0);
            args.lid           = IPAddress.HostToNetworkOrder(lid);
            byte[] packet = new byte[Marshal.SizeOf(typeof(DEVICE_UNLOCK_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(args, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(DEVICE_GENERIC_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            DEVICE_GENERIC_REPLY reply = new DEVICE_GENERIC_REPLY();
            reply.fheader      = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.xid          = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.mtype        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat         = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));

            return reply.error;
        }
        // call create_intr_chan
        public static int create_intr_chan(Socket so, int xid, int hostaddr, int hostport, int prognum, int progvers, int progfamily)
        {
            CREATE_INTR_CHAN_CALL args = new CREATE_INTR_CHAN_CALL();
            int size = Marshal.SizeOf(typeof(CREATE_INTR_CHAN_CALL));
            args.fheader       = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            args.xid           = IPAddress.HostToNetworkOrder(xid);
            args.mtype         = IPAddress.HostToNetworkOrder(CALL);
            args.rpcvers       = IPAddress.HostToNetworkOrder(RPC_VER);
            args.prog          = IPAddress.HostToNetworkOrder(DEVICE_CORE);
            args.vers          = IPAddress.HostToNetworkOrder(DEVICE_CORE_VERSION);
            args.proc          = IPAddress.HostToNetworkOrder(CREATE_INTR_CHAN);
            args.cred_flavor   = IPAddress.HostToNetworkOrder(0);
            args.cred_len      = IPAddress.HostToNetworkOrder(0);
            args.verf_flavor   = IPAddress.HostToNetworkOrder(0);
            args.verf_len      = IPAddress.HostToNetworkOrder(0);
            args.hostaddr      = IPAddress.HostToNetworkOrder(hostaddr);
            args.hostport      = IPAddress.HostToNetworkOrder(hostport);
            args.prognum       = IPAddress.HostToNetworkOrder(prognum);
            args.progvers      = IPAddress.HostToNetworkOrder(progvers);
            args.progfamily    = IPAddress.HostToNetworkOrder(progfamily);
            byte[] packet = new byte[Marshal.SizeOf(typeof(CREATE_INTR_CHAN_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(args, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(DEVICE_GENERIC_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            DEVICE_GENERIC_REPLY reply = new DEVICE_GENERIC_REPLY();
            reply.fheader      = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.xid          = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.mtype        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat         = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));

            return reply.error;
        }
        // call destroy_intr_chan
        public static int destroy_intr_chan(Socket so, int xid)
        {
            DESTROY_INTR_CHAN_CALL args = new DESTROY_INTR_CHAN_CALL();
            int size = Marshal.SizeOf(typeof(DESTROY_INTR_CHAN_CALL));
            args.fheader       = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            args.xid           = IPAddress.HostToNetworkOrder(xid);
            args.mtype         = IPAddress.HostToNetworkOrder(CALL);
            args.rpcvers       = IPAddress.HostToNetworkOrder(RPC_VER);
            args.prog          = IPAddress.HostToNetworkOrder(DEVICE_CORE);
            args.vers          = IPAddress.HostToNetworkOrder(DEVICE_CORE_VERSION);
            args.proc          = IPAddress.HostToNetworkOrder(DESTROY_INTR_CHAN);
            args.cred_flavor   = IPAddress.HostToNetworkOrder(0);
            args.cred_len      = IPAddress.HostToNetworkOrder(0);
            args.verf_flavor   = IPAddress.HostToNetworkOrder(0);
            args.verf_len      = IPAddress.HostToNetworkOrder(0);
            byte[] packet = new byte[Marshal.SizeOf(typeof(DESTROY_INTR_CHAN_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(args, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(DEVICE_GENERIC_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            DEVICE_GENERIC_REPLY reply = new DEVICE_GENERIC_REPLY();
            reply.fheader      = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.xid          = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.mtype        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat         = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));

            return reply.error;
        }
        // call device_enable_srq
        public static int device_enable_srq(Socket so, int xid, int lid, int enable, string handle)
        {
            DEVICE_ENABLE_SRQ_CALL args = new DEVICE_ENABLE_SRQ_CALL();
            byte[] str = System.Text.Encoding.ASCII.GetBytes(handle);
            int size = Marshal.SizeOf(typeof(DEVICE_ENABLE_SRQ_CALL)) + str.Length;
            size = ((size / 4) + 1) * 4;
            args.fheader       = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            args.xid           = IPAddress.HostToNetworkOrder(xid);
            args.mtype         = IPAddress.HostToNetworkOrder(CALL);
            args.rpcvers       = IPAddress.HostToNetworkOrder(RPC_VER);
            args.prog          = IPAddress.HostToNetworkOrder(DEVICE_CORE);
            args.vers          = IPAddress.HostToNetworkOrder(DEVICE_CORE_VERSION);
            args.proc          = IPAddress.HostToNetworkOrder(DEVICE_ENABLE_SRQ);
            args.cred_flavor   = IPAddress.HostToNetworkOrder(0);
            args.cred_len      = IPAddress.HostToNetworkOrder(0);
            args.verf_flavor   = IPAddress.HostToNetworkOrder(0);
            args.verf_len      = IPAddress.HostToNetworkOrder(0);
            args.lid           = IPAddress.HostToNetworkOrder(lid);
            args.enable        = IPAddress.HostToNetworkOrder(enable);
            args.handle_len    = IPAddress.HostToNetworkOrder(handle.Length);
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(args, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(str, 0, packet, Marshal.SizeOf(typeof(DEVICE_ENABLE_SRQ_CALL)), str.Length);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(DEVICE_GENERIC_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            DEVICE_GENERIC_REPLY reply = new DEVICE_GENERIC_REPLY();
            reply.fheader      = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.xid          = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.mtype        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat         = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));

            return reply.error;
        }
        // call device_docmd
        public static void device_docmd(Socket so, int xid, int lid, int flags, int lock_timeout, int io_timeout, int cmd, int network_order, int datasize, byte[] data)
        {
            DEVICE_DOCMD_CALL args = new DEVICE_DOCMD_CALL();
            int size = Marshal.SizeOf(typeof(DEVICE_DOCMD_CALL)) + data.Length;
            size = ((size / 4) + 1) * 4;
            args.fheader       = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            args.xid           = IPAddress.HostToNetworkOrder(xid);
            args.mtype         = IPAddress.HostToNetworkOrder(CALL);
            args.rpcvers       = IPAddress.HostToNetworkOrder(RPC_VER);
            args.prog          = IPAddress.HostToNetworkOrder(DEVICE_CORE);
            args.vers          = IPAddress.HostToNetworkOrder(DEVICE_CORE_VERSION);
            args.proc          = IPAddress.HostToNetworkOrder(DEVICE_DOCMD);
            args.cred_flavor   = IPAddress.HostToNetworkOrder(0);
            args.cred_len      = IPAddress.HostToNetworkOrder(0);
            args.verf_flavor   = IPAddress.HostToNetworkOrder(0);
            args.verf_len      = IPAddress.HostToNetworkOrder(0);
            args.lid           = IPAddress.HostToNetworkOrder(lid);
            args.flags         = IPAddress.HostToNetworkOrder(flags);
            args.io_timeout    = IPAddress.HostToNetworkOrder(io_timeout);
            args.lock_timeout  = IPAddress.HostToNetworkOrder(lock_timeout);
            args.cmd           = IPAddress.HostToNetworkOrder(cmd);
            args.network_order = IPAddress.HostToNetworkOrder(network_order);
            args.datasize      = IPAddress.HostToNetworkOrder(datasize);
            args.data_in_len   = IPAddress.HostToNetworkOrder(data.Length);
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(args, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(data, 0, packet, Marshal.SizeOf(typeof(DEVICE_DOCMD_CALL)), data.Length);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(DEVICE_DOCMD_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            DEVICE_DOCMD_REPLY reply = new DEVICE_DOCMD_REPLY();
            reply.fheader      = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.xid          = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.mtype        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat         = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));
            reply.data_out_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 32));
            byte[] reply_data = new Byte[reply.data_out_len];
            byteCount = so.Receive(reply_data, SocketFlags.None);
            data               = reply_data;
        }
        // call destroy_link
        public static int destroy_link(Socket so, int xid, int lid)
        {
            DEVICE_GENERIC_CALL args = new DEVICE_GENERIC_CALL();
            int size = Marshal.SizeOf(typeof(DEVICE_GENERIC_CALL));
            args.fheader       = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            args.xid           = IPAddress.HostToNetworkOrder(xid);
            args.mtype         = IPAddress.HostToNetworkOrder(CALL);
            args.rpcvers       = IPAddress.HostToNetworkOrder(RPC_VER);
            args.prog          = IPAddress.HostToNetworkOrder(DEVICE_CORE);
            args.vers          = IPAddress.HostToNetworkOrder(DEVICE_CORE_VERSION);
            args.proc          = IPAddress.HostToNetworkOrder(DESTROY_LINK);
            args.cred_flavor   = IPAddress.HostToNetworkOrder(0);
            args.cred_len      = IPAddress.HostToNetworkOrder(0);
            args.verf_flavor   = IPAddress.HostToNetworkOrder(0);
            args.verf_len      = IPAddress.HostToNetworkOrder(0);
            args.lid           = IPAddress.HostToNetworkOrder(lid);
            byte[] packet = new byte[Marshal.SizeOf(typeof(DEVICE_GENERIC_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(args, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(DEVICE_GENERIC_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            DEVICE_GENERIC_REPLY reply = new DEVICE_GENERIC_REPLY();
            reply.fheader      = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.xid          = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.mtype        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat         = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));

            return reply.error;
        }
        // call device_abort
        public static int device_abort(Socket so, int xid, int lid, int flags, int lock_timeout, int io_timeout)
        {
            DEVICE_GENERIC_CALL args = new DEVICE_GENERIC_CALL();
            int size = Marshal.SizeOf(typeof(DEVICE_GENERIC_CALL));
            args.fheader       = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            args.xid           = IPAddress.HostToNetworkOrder(xid);
            args.mtype         = IPAddress.HostToNetworkOrder(CALL);
            args.rpcvers       = IPAddress.HostToNetworkOrder(RPC_VER);
            args.prog          = IPAddress.HostToNetworkOrder(DEVICE_ASYNC);
            args.vers          = IPAddress.HostToNetworkOrder(DEVICE_ASYNC_VERSION);
            args.proc          = IPAddress.HostToNetworkOrder(DEVICE_ABORT);
            args.cred_flavor   = IPAddress.HostToNetworkOrder(0);
            args.cred_len      = IPAddress.HostToNetworkOrder(0);
            args.verf_flavor   = IPAddress.HostToNetworkOrder(0);
            args.verf_len      = IPAddress.HostToNetworkOrder(0);
            args.lid           = IPAddress.HostToNetworkOrder(lid);
            args.flags         = IPAddress.HostToNetworkOrder(flags);
            args.lock_timeout  = IPAddress.HostToNetworkOrder(lock_timeout);
            args.io_timeout    = IPAddress.HostToNetworkOrder(io_timeout);
            byte[] packet = new byte[Marshal.SizeOf(typeof(DEVICE_GENERIC_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(args, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(DEVICE_GENERIC_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            DEVICE_GENERIC_REPLY reply = new DEVICE_GENERIC_REPLY();
            reply.fheader      = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.xid          = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.mtype        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat         = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));

            return reply.error;
        }
     }
}