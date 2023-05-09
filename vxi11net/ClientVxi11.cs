using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Vxi11Net
{
    public class ClientPortmap
    {
        public const int CALL = 0;
        public const int RPC_VER = 2;
        public const int PMAP_PORT = 111;     /* port mapper port number     */
        public const int IPPROTO_TCP = 6;      /* protocol number for TCP/IP     */
        public const int IPPROTO_UDP = 17;     /* protocol number for UDP        */
        public const int PMAP_PROG = 100000;
        public const int PMAP_VERS = 2;
        public const int PMAPPROC_NULL = 0;
        public const int PMAPPROC_SET = 1;
        public const int PMAPPROC_UNSET = 2;
        public const int PMAPPROC_GETPORT = 3;
        public const int PMAPPROC_DUMP = 4;
        public const int PMAPPROC_CALLIT = 5;

        [StructLayout(LayoutKind.Sequential, Pack = 1)]

        public struct PMAP_SET_CALL
        {
            public int fheader;
            public int xid;
            public int msg_type;
            public int rpcvers;
            public int prog;
            public int vers;
            public int proc;
            public int cred_flavor;
            public int cred_len;
            public int verf_flavor;
            public int verf_len;
            public int prognum;
            public int progvers;
            public int proto;
            public int port;
        };
        public struct PMAP_SET_REPLY
        {
            public int fheader;
            public int xid;
            public int msg_type;
            public int stat;
            public int verf_flavor;
            public int verf_len;
            public int accept_stat;
            public int boolean;
        };
        public struct PMAP_GETPORT_CALL
        {
            public int fheader;
            public int xid;
            public int msg_type;
            public int rpcvers;
            public int prog;
            public int vers;
            public int proc;
            public int cred_flavor;
            public int cred_len;
            public int verf_flavor;
            public int verf_len;
            public int prognum;
            public int progvers;
            public int proto;
            public int port;
        };
        public struct PMAP_GETPORT_REPLY
        {
            public int fheader;
            public int xid;
            public int msg_type;
            public int stat;
            public int verf_flavor;
            public int verf_len;
            public int accept_stat;
            public int port;
        };
        public struct PMAP_DUMP_CALL
        {
            public int fheader;
            public int xid;
            public int msg_type;
            public int rpcvers;
            public int prog;
            public int vers;
            public int proc;
            public int cred_flavor;
            public int cred_len;
            public int verf_flavor;
            public int verf_len;
        };
        public struct PMAP_DUMP_REPLY
        {
            public int fheader;
            public int xid;
            public int msg_type;
            public int stat;
            public int verf_flavor;
            public int verf_len;
            public int accept_stat;
        };
        public struct MAPPING
        {
            public int prog;
            public int vers;
            public int prot;
            public int port;
        };

        public static int pmapproc_set(Socket so, int xid, int prognum, int progvers, int proto, int port)
        {
            PMAP_SET_CALL arg = new PMAP_SET_CALL();
            int size = Marshal.SizeOf(typeof(PMAP_SET_CALL));
            arg.fheader = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            arg.xid = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type = IPAddress.HostToNetworkOrder(CALL);
            arg.rpcvers = IPAddress.HostToNetworkOrder(RPC_VER);
            arg.prog = IPAddress.HostToNetworkOrder(PMAP_PROG);
            arg.vers = IPAddress.HostToNetworkOrder(PMAP_VERS);
            arg.proc = IPAddress.HostToNetworkOrder(PMAPPROC_SET);
            arg.cred_flavor = IPAddress.HostToNetworkOrder(0);
            arg.cred_len = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor = IPAddress.HostToNetworkOrder(0);
            arg.verf_len = IPAddress.HostToNetworkOrder(0);
            arg.prognum = IPAddress.HostToNetworkOrder(prognum);
            arg.progvers = IPAddress.HostToNetworkOrder(progvers);
            arg.proto = IPAddress.HostToNetworkOrder(proto);
            arg.port = IPAddress.HostToNetworkOrder(port);
            byte[] packet = new byte[Marshal.SizeOf(typeof(PMAP_SET_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();
        
            byte[] buffer = new byte[Marshal.SizeOf(typeof(PMAP_SET_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            PMAP_SET_REPLY reply = new PMAP_SET_REPLY();
            reply.fheader = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.boolean = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));

            return reply.boolean;
        }

        public static int pmapproc_unset(Socket so, int xid, int prognum, int progvers, int proto)
        {
            PMAP_SET_CALL arg = new PMAP_SET_CALL();
            int size = Marshal.SizeOf(typeof(PMAP_SET_CALL));
            arg.fheader = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            arg.xid = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type = IPAddress.HostToNetworkOrder(CALL);
            arg.rpcvers = IPAddress.HostToNetworkOrder(RPC_VER);
            arg.prog = IPAddress.HostToNetworkOrder(PMAP_PROG);
            arg.vers = IPAddress.HostToNetworkOrder(PMAP_VERS);
            arg.proc = IPAddress.HostToNetworkOrder(PMAPPROC_UNSET);
            arg.cred_flavor = IPAddress.HostToNetworkOrder(0);
            arg.cred_len = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor = IPAddress.HostToNetworkOrder(0);
            arg.verf_len = IPAddress.HostToNetworkOrder(0);
            arg.prognum = IPAddress.HostToNetworkOrder(prognum);
            arg.progvers = IPAddress.HostToNetworkOrder(progvers);
            arg.proto = IPAddress.HostToNetworkOrder(proto);
            arg.port = IPAddress.HostToNetworkOrder(0);
            byte[] packet = new byte[Marshal.SizeOf(typeof(PMAP_SET_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(PMAP_SET_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            PMAP_SET_REPLY reply = new PMAP_SET_REPLY();
            reply.fheader = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.boolean = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));

            return reply.boolean;
        }

        public static int pmapproc_getport(Socket so, int xid, int prognum, int progvers, int proto)
        {
            PMAP_GETPORT_CALL arg = new PMAP_GETPORT_CALL();
            int size = Marshal.SizeOf(typeof(PMAP_GETPORT_CALL));
            arg.fheader = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            arg.xid = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type = IPAddress.HostToNetworkOrder(CALL);
            arg.rpcvers = IPAddress.HostToNetworkOrder(RPC_VER);
            arg.prog = IPAddress.HostToNetworkOrder(PMAP_PROG);
            arg.vers = IPAddress.HostToNetworkOrder(PMAP_VERS);
            arg.proc = IPAddress.HostToNetworkOrder(PMAPPROC_UNSET);
            arg.cred_flavor = IPAddress.HostToNetworkOrder(0);
            arg.cred_len = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor = IPAddress.HostToNetworkOrder(0);
            arg.verf_len = IPAddress.HostToNetworkOrder(0);
            arg.prognum = IPAddress.HostToNetworkOrder(prognum);
            arg.progvers = IPAddress.HostToNetworkOrder(progvers);
            arg.proto = IPAddress.HostToNetworkOrder(proto);
            arg.port = IPAddress.HostToNetworkOrder(0);
            byte[] packet = new byte[Marshal.SizeOf(typeof(PMAP_GETPORT_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(PMAP_GETPORT_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            PMAP_GETPORT_REPLY reply = new PMAP_GETPORT_REPLY();
            reply.fheader = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.port = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));

            return reply.port;
        }

        public static List<MAPPING> pmapproc_dump(Socket so, int xid)
        {
            PMAP_DUMP_CALL arg = new PMAP_DUMP_CALL();
            int size = Marshal.SizeOf(typeof(PMAP_DUMP_CALL));
            arg.fheader = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            arg.xid = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type = IPAddress.HostToNetworkOrder(CALL);
            arg.rpcvers = IPAddress.HostToNetworkOrder(RPC_VER);
            arg.prog = IPAddress.HostToNetworkOrder(PMAP_PROG);
            arg.vers = IPAddress.HostToNetworkOrder(PMAP_VERS);
            arg.proc = IPAddress.HostToNetworkOrder(PMAPPROC_DUMP);
            arg.cred_flavor = IPAddress.HostToNetworkOrder(0);
            arg.cred_len = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor = IPAddress.HostToNetworkOrder(0);
            arg.verf_len = IPAddress.HostToNetworkOrder(0);
            byte[] packet = new byte[Marshal.SizeOf(typeof(PMAP_DUMP_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(PMAP_DUMP_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            PMAP_DUMP_REPLY reply = new PMAP_DUMP_REPLY();
            reply.fheader = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));

            throw new NotImplementedException();
        }
    }
    public class ClientVxi11
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
        public enum Flags
        {
            termchrset = 0x0080,
            end        = 0x0008,
            waitlock   = 0x0001,
            none       = 0x0000
        }
        public enum TermChar
        {
            CR         = 0x0A,
            LF         = 0x0D,
            None       = 0x00
        }
        public enum reason
        {
            END        = 0x04,
            CHR        = 0x02,
            REQCNT     = 0x01,
            NONE       = 0x00
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct GET_PORT_CALL
        {
            public int fheader;
            public int xid;
            public int msg_type;
            public int rpcvers;
            public int prog;
            public int vers;
            public int proc;
            public int cred_flavor;
            public int cred_len;
            public int verf_flavor;
            public int verf_len;
            public int prognum;
            public int progvers;
            public int proto;
            public int port;
        };
        public struct GET_PORT_REPLY
        {
            public int fheader;
            public int xid;
            public int msg_type;
            public int stat;
            public int verf_flavor;
            public int verf_len;
            public int accept_stat;
            public int port;
        };
        public struct CREATE_LINK_CALL
        {
            public int fheader;
            public int xid;
            public int msg_type;
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
            public int msg_type;
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
            public int msg_type;
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
            public int msg_type;
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
            public int msg_type;
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
            public int msg_type;
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
            public int msg_type;
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
            public int msg_type;
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
            public int msg_type;
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
            public int msg_type;
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
            public int msg_type;
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
            public int msg_type;
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
            public int msg_type;
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
            public int msg_type;
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
            public int msg_type;
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
            public int msg_type;
            public int stat;
            public int verf_flavor;
            public int verf_len;
            public int accept_stat;
            public int error;
            public int data_out_len;
        };

        public static Socket create_rpc_client_core_channel(string address, int port)
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(address);
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
        public static Socket create_rpc_client_abort_channel(string address, int port)
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(address);
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
        public static Socket create_rpc_server_interrupt_channel(string address, int port)
        {
            throw new NotImplementedException();
        }
        public static void close_rpc_server_interrupt_channel(Socket socket)
        {
            socket.Close();
        }

        // call create_link
        public static int create_link(Socket so, int xid, int cliendId, int lockDevice, int lock_timeout, string handle, out int lid, out int abortPort, out int maxRecvSize)
        {
            CREATE_LINK_CALL arg = new CREATE_LINK_CALL();
            byte[] str = System.Text.Encoding.ASCII.GetBytes(handle);
            int size = Marshal.SizeOf(typeof(CREATE_LINK_CALL)) + str.Length;
            size = ((size / 4) + 1) * 4;
            arg.fheader        = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            arg.xid            = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type       = IPAddress.HostToNetworkOrder(CALL);
            arg.rpcvers        = IPAddress.HostToNetworkOrder(RPC_VER);
            arg.prog           = IPAddress.HostToNetworkOrder(DEVICE_CORE);
            arg.vers           = IPAddress.HostToNetworkOrder(DEVICE_CORE_VERSION);
            arg.proc           = IPAddress.HostToNetworkOrder(CREATE_LINK);
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
            Buffer.BlockCopy(str, 0, packet, Marshal.SizeOf(typeof(CREATE_LINK_CALL)), str.Length);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(CREATE_LINK_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            CREATE_LINK_REPLY reply = new CREATE_LINK_REPLY();
            reply.fheader      = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
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
        public static int device_write(Socket so, int xid, int lid, Flags flags, int lock_timeout, int io_timeout, string data, out int data_len)
        {
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(data);
            return device_write(so, xid, lid, flags, lock_timeout, io_timeout, bytes, out data_len);
        }
        public static int device_write(Socket so, int xid, int lid, Flags flags, int lock_timeout, int io_timeout, byte[] data, out int data_len)
        {
            DEVICE_WRITE_CALL arg = new DEVICE_WRITE_CALL();
            int size = Marshal.SizeOf(typeof(DEVICE_WRITE_CALL)) + data.Length;
            size = ((size / 4) + 1) * 4;
            arg.fheader        = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            arg.xid            = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type       = IPAddress.HostToNetworkOrder(CALL);
            arg.rpcvers        = IPAddress.HostToNetworkOrder(RPC_VER);
            arg.prog           = IPAddress.HostToNetworkOrder(DEVICE_CORE);
            arg.vers           = IPAddress.HostToNetworkOrder(DEVICE_CORE_VERSION);
            arg.proc           = IPAddress.HostToNetworkOrder(DEVICE_WRITE);
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
            Buffer.BlockCopy(data, 0, packet, Marshal.SizeOf(typeof(DEVICE_WRITE_CALL)), data.Length);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(DEVICE_WRITE_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            DEVICE_WRITE_REPLY reply = new DEVICE_WRITE_REPLY();
            reply.fheader      = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
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
        public static int device_read(Socket so, int xid, int lid, int requestSize, Flags flags, int lock_timeout, int io_timeout, TermChar term, out int reason, out string data)
        {
            byte[] buf;
            int ret = device_read(so, xid, lid, requestSize, flags, lock_timeout, io_timeout, term, out reason, out buf);
            data = System.Text.Encoding.ASCII.GetString(buf);
            return ret;
        }
        public static int device_read(Socket so, int xid, int lid, int requestSize, Flags flags, int lock_timeout, int io_timeout, TermChar term, out int reason, out byte[] data)
        {
            DEVICE_READ_CALL arg = new DEVICE_READ_CALL();
            int size = Marshal.SizeOf(typeof(DEVICE_READ_CALL));
            arg.fheader        = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            arg.xid            = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type       = IPAddress.HostToNetworkOrder(CALL);
            arg.rpcvers        = IPAddress.HostToNetworkOrder(RPC_VER);
            arg.prog           = IPAddress.HostToNetworkOrder(DEVICE_CORE);
            arg.vers           = IPAddress.HostToNetworkOrder(DEVICE_CORE_VERSION);
            arg.proc           = IPAddress.HostToNetworkOrder(DEVICE_READ);
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
            byte[] packet = new byte[Marshal.SizeOf(typeof(DEVICE_READ_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(DEVICE_READ_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            DEVICE_READ_REPLY reply = new DEVICE_READ_REPLY();
            reply.fheader      = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
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
        public static int device_readstb(Socket so, int xid, int lid, Flags flags, int lock_timeout, int io_timeout, out char stb)
        {
            DEVICE_GENERIC_CALL arg = new DEVICE_GENERIC_CALL();
            int size = Marshal.SizeOf(typeof(DEVICE_GENERIC_CALL));
            arg.fheader        = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            arg.xid            = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type       = IPAddress.HostToNetworkOrder(CALL);
            arg.rpcvers        = IPAddress.HostToNetworkOrder(RPC_VER);
            arg.prog           = IPAddress.HostToNetworkOrder(DEVICE_CORE);
            arg.vers           = IPAddress.HostToNetworkOrder(DEVICE_CORE_VERSION);
            arg.proc           = IPAddress.HostToNetworkOrder(DEVICE_READSTB);
            arg.cred_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.cred_len       = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.verf_len       = IPAddress.HostToNetworkOrder(0);
            arg.lid            = IPAddress.HostToNetworkOrder(lid);
            arg.flags          = IPAddress.HostToNetworkOrder((int)flags);
            arg.lock_timeout   = IPAddress.HostToNetworkOrder(lock_timeout);
            arg.io_timeout     = IPAddress.HostToNetworkOrder(io_timeout);
            byte[] packet = new byte[Marshal.SizeOf(typeof(DEVICE_GENERIC_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(DEVICE_READSTB_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            DEVICE_READSTB_REPLY reply = new DEVICE_READSTB_REPLY();
            reply.fheader      = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.xid          = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.msg_type     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat         = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));
            reply.stb          = (char)buffer[32];
            stb                = reply.stb;

            return reply.error;
        }
        // call device_trigger
        public static int device_trigger(Socket so, int xid, int lid, Flags flags, int lock_timeout, int io_timeout)
        {
            DEVICE_GENERIC_CALL arg = new DEVICE_GENERIC_CALL();
            int size = Marshal.SizeOf(typeof(DEVICE_GENERIC_CALL));
            arg.fheader        = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            arg.xid            = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type       = IPAddress.HostToNetworkOrder(CALL);
            arg.rpcvers        = IPAddress.HostToNetworkOrder(RPC_VER);
            arg.prog           = IPAddress.HostToNetworkOrder(DEVICE_CORE);
            arg.vers           = IPAddress.HostToNetworkOrder(DEVICE_CORE_VERSION);
            arg.proc           = IPAddress.HostToNetworkOrder(DEVICE_TRIGGER);
            arg.cred_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.cred_len       = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.verf_len       = IPAddress.HostToNetworkOrder(0);
            arg.lid            = IPAddress.HostToNetworkOrder(lid);
            arg.flags          = IPAddress.HostToNetworkOrder((int)flags);
            arg.lock_timeout   = IPAddress.HostToNetworkOrder(lock_timeout);
            arg.io_timeout     = IPAddress.HostToNetworkOrder(io_timeout);
            byte[] packet = new byte[Marshal.SizeOf(typeof(DEVICE_GENERIC_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(DEVICE_GENERIC_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            DEVICE_GENERIC_REPLY reply = new DEVICE_GENERIC_REPLY();
            reply.fheader      = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
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
        public static int device_clear(Socket so, int xid, int lid, Flags flags, int lock_timeout, int io_timeout)
        {
            DEVICE_GENERIC_CALL arg = new DEVICE_GENERIC_CALL();
            int size = Marshal.SizeOf(typeof(DEVICE_GENERIC_CALL));
            arg.fheader        = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            arg.xid            = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type       = IPAddress.HostToNetworkOrder(CALL);
            arg.rpcvers        = IPAddress.HostToNetworkOrder(RPC_VER);
            arg.prog           = IPAddress.HostToNetworkOrder(DEVICE_CORE);
            arg.vers           = IPAddress.HostToNetworkOrder(DEVICE_CORE_VERSION);
            arg.proc           = IPAddress.HostToNetworkOrder(DEVICE_CLEAR);
            arg.cred_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.cred_len       = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.verf_len       = IPAddress.HostToNetworkOrder(0);
            arg.lid            = IPAddress.HostToNetworkOrder(lid);
            arg.flags          = IPAddress.HostToNetworkOrder((int)flags);
            arg.lock_timeout   = IPAddress.HostToNetworkOrder(lock_timeout);
            arg.io_timeout     = IPAddress.HostToNetworkOrder(io_timeout);
            byte[] packet = new byte[Marshal.SizeOf(typeof(DEVICE_GENERIC_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(DEVICE_GENERIC_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            DEVICE_GENERIC_REPLY reply = new DEVICE_GENERIC_REPLY();
            reply.fheader      = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
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
        public static int device_remote(Socket so, int xid, int lid, Flags flags, int lock_timeout, int io_timeout)
        {
            DEVICE_GENERIC_CALL arg = new DEVICE_GENERIC_CALL();
            int size = Marshal.SizeOf(typeof(DEVICE_GENERIC_CALL));
            arg.fheader        = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            arg.xid            = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type       = IPAddress.HostToNetworkOrder(CALL);
            arg.rpcvers        = IPAddress.HostToNetworkOrder(RPC_VER);
            arg.prog           = IPAddress.HostToNetworkOrder(DEVICE_CORE);
            arg.vers           = IPAddress.HostToNetworkOrder(DEVICE_CORE_VERSION);
            arg.proc           = IPAddress.HostToNetworkOrder(DEVICE_REMOTE);
            arg.cred_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.cred_len       = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.verf_len       = IPAddress.HostToNetworkOrder(0);
            arg.lid            = IPAddress.HostToNetworkOrder(lid);
            arg.flags          = IPAddress.HostToNetworkOrder((int)flags);
            arg.lock_timeout   = IPAddress.HostToNetworkOrder(lock_timeout);
            arg.io_timeout     = IPAddress.HostToNetworkOrder(io_timeout);
            byte[] packet = new byte[Marshal.SizeOf(typeof(DEVICE_GENERIC_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(DEVICE_GENERIC_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            DEVICE_GENERIC_REPLY reply = new DEVICE_GENERIC_REPLY();
            reply.fheader      = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
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
        public static int device_local(Socket so, int xid, int lid, Flags flags, int lock_timeout, int io_timeout)
        {
            DEVICE_GENERIC_CALL arg = new DEVICE_GENERIC_CALL();
            int size = Marshal.SizeOf(typeof(DEVICE_GENERIC_CALL));
            arg.fheader        = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            arg.xid            = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type       = IPAddress.HostToNetworkOrder(CALL);
            arg.rpcvers        = IPAddress.HostToNetworkOrder(RPC_VER);
            arg.prog           = IPAddress.HostToNetworkOrder(DEVICE_CORE);
            arg.vers           = IPAddress.HostToNetworkOrder(DEVICE_CORE_VERSION);
            arg.proc           = IPAddress.HostToNetworkOrder(DEVICE_LOCAL);
            arg.cred_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.cred_len       = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.verf_len       = IPAddress.HostToNetworkOrder(0);
            arg.lid            = IPAddress.HostToNetworkOrder(lid);
            arg.flags          = IPAddress.HostToNetworkOrder((int)flags);
            arg.lock_timeout   = IPAddress.HostToNetworkOrder(lock_timeout);
            arg.io_timeout     = IPAddress.HostToNetworkOrder(io_timeout);
            byte[] packet = new byte[Marshal.SizeOf(typeof(DEVICE_GENERIC_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(DEVICE_GENERIC_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            DEVICE_GENERIC_REPLY reply = new DEVICE_GENERIC_REPLY();
            reply.fheader      = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
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
        public static int device_lock(Socket so, int xid, int lid, Flags flags, int lock_timeout)
        {
            DEVICE_LOCK_CALL arg = new DEVICE_LOCK_CALL();
            int size = Marshal.SizeOf(typeof(DEVICE_LOCK_CALL));
            arg.fheader        = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            arg.xid            = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type       = IPAddress.HostToNetworkOrder(CALL);
            arg.rpcvers        = IPAddress.HostToNetworkOrder(RPC_VER);
            arg.prog           = IPAddress.HostToNetworkOrder(DEVICE_CORE);
            arg.vers           = IPAddress.HostToNetworkOrder(DEVICE_CORE_VERSION);
            arg.proc           = IPAddress.HostToNetworkOrder(DEVICE_LOCK);
            arg.cred_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.cred_len       = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.verf_len       = IPAddress.HostToNetworkOrder(0);
            arg.lid            = IPAddress.HostToNetworkOrder(lid);
            arg.flags          = IPAddress.HostToNetworkOrder((int)flags);
            arg.lock_timeout   = IPAddress.HostToNetworkOrder(lock_timeout);
            byte[] packet = new byte[Marshal.SizeOf(typeof(DEVICE_LOCK_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(DEVICE_GENERIC_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            DEVICE_GENERIC_REPLY reply = new DEVICE_GENERIC_REPLY();
            reply.fheader      = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
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
        public static int device_unlock(Socket so, int xid, int lid)
        {
            DEVICE_UNLOCK_CALL arg = new DEVICE_UNLOCK_CALL();
            int size = Marshal.SizeOf(typeof(DEVICE_UNLOCK_CALL));
            arg.fheader        = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            arg.xid            = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type       = IPAddress.HostToNetworkOrder(CALL);
            arg.rpcvers        = IPAddress.HostToNetworkOrder(RPC_VER);
            arg.prog           = IPAddress.HostToNetworkOrder(DEVICE_CORE);
            arg.vers           = IPAddress.HostToNetworkOrder(DEVICE_CORE_VERSION);
            arg.proc           = IPAddress.HostToNetworkOrder(DEVICE_UNLOCK);
            arg.cred_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.cred_len       = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.verf_len       = IPAddress.HostToNetworkOrder(0);
            arg.lid            = IPAddress.HostToNetworkOrder(lid);
            byte[] packet = new byte[Marshal.SizeOf(typeof(DEVICE_UNLOCK_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(DEVICE_GENERIC_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            DEVICE_GENERIC_REPLY reply = new DEVICE_GENERIC_REPLY();
            reply.fheader      = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
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
        public static int create_intr_chan(Socket so, int xid, int hostaddr, int hostport, int prognum, int progvers, int progfamily)
        {
            CREATE_INTR_CHAN_CALL arg = new CREATE_INTR_CHAN_CALL();
            int size = Marshal.SizeOf(typeof(CREATE_INTR_CHAN_CALL));
            arg.fheader        = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            arg.xid            = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type       = IPAddress.HostToNetworkOrder(CALL);
            arg.rpcvers        = IPAddress.HostToNetworkOrder(RPC_VER);
            arg.prog           = IPAddress.HostToNetworkOrder(DEVICE_CORE);
            arg.vers           = IPAddress.HostToNetworkOrder(DEVICE_CORE_VERSION);
            arg.proc           = IPAddress.HostToNetworkOrder(CREATE_INTR_CHAN);
            arg.cred_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.cred_len       = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.verf_len       = IPAddress.HostToNetworkOrder(0);
            arg.hostaddr       = IPAddress.HostToNetworkOrder(hostaddr);
            arg.hostport       = IPAddress.HostToNetworkOrder(hostport);
            arg.prognum        = IPAddress.HostToNetworkOrder(prognum);
            arg.progvers       = IPAddress.HostToNetworkOrder(progvers);
            arg.progfamily     = IPAddress.HostToNetworkOrder(progfamily);
            byte[] packet = new byte[Marshal.SizeOf(typeof(CREATE_INTR_CHAN_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(DEVICE_GENERIC_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            DEVICE_GENERIC_REPLY reply = new DEVICE_GENERIC_REPLY();
            reply.fheader      = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
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
        public static int destroy_intr_chan(Socket so, int xid)
        {
            DESTROY_INTR_CHAN_CALL arg = new DESTROY_INTR_CHAN_CALL();
            int size = Marshal.SizeOf(typeof(DESTROY_INTR_CHAN_CALL));
            arg.fheader        = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            arg.xid            = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type       = IPAddress.HostToNetworkOrder(CALL);
            arg.rpcvers        = IPAddress.HostToNetworkOrder(RPC_VER);
            arg.prog           = IPAddress.HostToNetworkOrder(DEVICE_CORE);
            arg.vers           = IPAddress.HostToNetworkOrder(DEVICE_CORE_VERSION);
            arg.proc           = IPAddress.HostToNetworkOrder(DESTROY_INTR_CHAN);
            arg.cred_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.cred_len       = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.verf_len       = IPAddress.HostToNetworkOrder(0);
            byte[] packet = new byte[Marshal.SizeOf(typeof(DESTROY_INTR_CHAN_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(DEVICE_GENERIC_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            DEVICE_GENERIC_REPLY reply = new DEVICE_GENERIC_REPLY();
            reply.fheader      = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
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
        public static int device_enable_srq(Socket so, int xid, int lid, int enable, string handle)
        {
            DEVICE_ENABLE_SRQ_CALL arg = new DEVICE_ENABLE_SRQ_CALL();
            byte[] str = System.Text.Encoding.ASCII.GetBytes(handle);
            int size = Marshal.SizeOf(typeof(DEVICE_ENABLE_SRQ_CALL)) + str.Length;
            size = ((size / 4) + 1) * 4;
            arg.fheader        = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            arg.xid            = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type       = IPAddress.HostToNetworkOrder(CALL);
            arg.rpcvers        = IPAddress.HostToNetworkOrder(RPC_VER);
            arg.prog           = IPAddress.HostToNetworkOrder(DEVICE_CORE);
            arg.vers           = IPAddress.HostToNetworkOrder(DEVICE_CORE_VERSION);
            arg.proc           = IPAddress.HostToNetworkOrder(DEVICE_ENABLE_SRQ);
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
            Buffer.BlockCopy(str, 0, packet, Marshal.SizeOf(typeof(DEVICE_ENABLE_SRQ_CALL)), str.Length);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(DEVICE_GENERIC_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            DEVICE_GENERIC_REPLY reply = new DEVICE_GENERIC_REPLY();
            reply.fheader      = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
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
        public static void device_docmd(Socket so, int xid, int lid, Flags flags, int lock_timeout, int io_timeout, int cmd, int network_order, int datasize, byte[] data_in, out byte[] data_out)
        {
            DEVICE_DOCMD_CALL arg = new DEVICE_DOCMD_CALL();
            int size = Marshal.SizeOf(typeof(DEVICE_DOCMD_CALL)) + data_in.Length;
            size = ((size / 4) + 1) * 4;
            arg.fheader        = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            arg.xid            = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type       = IPAddress.HostToNetworkOrder(CALL);
            arg.rpcvers        = IPAddress.HostToNetworkOrder(RPC_VER);
            arg.prog           = IPAddress.HostToNetworkOrder(DEVICE_CORE);
            arg.vers           = IPAddress.HostToNetworkOrder(DEVICE_CORE_VERSION);
            arg.proc           = IPAddress.HostToNetworkOrder(DEVICE_DOCMD);
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
            Buffer.BlockCopy(data_in, 0, packet, Marshal.SizeOf(typeof(DEVICE_DOCMD_CALL)), data_in.Length);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(DEVICE_DOCMD_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            DEVICE_DOCMD_REPLY reply = new DEVICE_DOCMD_REPLY();
            reply.fheader      = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
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
        public static int destroy_link(Socket so, int xid, int lid)
        {
            DEVICE_GENERIC_CALL arg = new DEVICE_GENERIC_CALL();
            int size = Marshal.SizeOf(typeof(DEVICE_GENERIC_CALL));
            arg.fheader        = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            arg.xid            = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type       = IPAddress.HostToNetworkOrder(CALL);
            arg.rpcvers        = IPAddress.HostToNetworkOrder(RPC_VER);
            arg.prog           = IPAddress.HostToNetworkOrder(DEVICE_CORE);
            arg.vers           = IPAddress.HostToNetworkOrder(DEVICE_CORE_VERSION);
            arg.proc           = IPAddress.HostToNetworkOrder(DESTROY_LINK);
            arg.cred_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.cred_len       = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.verf_len       = IPAddress.HostToNetworkOrder(0);
            arg.lid            = IPAddress.HostToNetworkOrder(lid);
            byte[] packet = new byte[Marshal.SizeOf(typeof(DEVICE_GENERIC_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(DEVICE_GENERIC_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            DEVICE_GENERIC_REPLY reply = new DEVICE_GENERIC_REPLY();
            reply.fheader      = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
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
        public static int device_abort(Socket so, int xid, int lid, Flags flags, int lock_timeout, int io_timeout)
        {
            DEVICE_GENERIC_CALL arg = new DEVICE_GENERIC_CALL();
            int size = Marshal.SizeOf(typeof(DEVICE_GENERIC_CALL));
            arg.fheader        = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            arg.xid            = IPAddress.HostToNetworkOrder(xid);
            arg.msg_type       = IPAddress.HostToNetworkOrder(CALL);
            arg.rpcvers        = IPAddress.HostToNetworkOrder(RPC_VER);
            arg.prog           = IPAddress.HostToNetworkOrder(DEVICE_ASYNC);
            arg.vers           = IPAddress.HostToNetworkOrder(DEVICE_ASYNC_VERSION);
            arg.proc           = IPAddress.HostToNetworkOrder(DEVICE_ABORT);
            arg.cred_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.cred_len       = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor    = IPAddress.HostToNetworkOrder(0);
            arg.verf_len       = IPAddress.HostToNetworkOrder(0);
            arg.lid            = IPAddress.HostToNetworkOrder(lid);
            arg.flags          = IPAddress.HostToNetworkOrder((int)flags);
            arg.lock_timeout   = IPAddress.HostToNetworkOrder(lock_timeout);
            arg.io_timeout     = IPAddress.HostToNetworkOrder(io_timeout);
            byte[] packet = new byte[Marshal.SizeOf(typeof(DEVICE_GENERIC_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();

            byte[] buffer = new byte[Marshal.SizeOf(typeof(DEVICE_GENERIC_REPLY))];
            byteCount = so.Receive(buffer, SocketFlags.None);
            DEVICE_GENERIC_REPLY reply = new DEVICE_GENERIC_REPLY();
            reply.fheader      = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.xid          = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.msg_type     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.stat         = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_flavor  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.verf_len     = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.accept_stat  = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            reply.error        = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));

            return reply.error;
        }
        public static int pmapproc_set(Socket so, int xid, int lid, Flags flags, int lock_timeout, int io_timeout)
        {
            return 0;
        }
        public static int pmapproc_unset(Socket so, int xid, int lid, Flags flags, int lock_timeout, int io_timeout)
        {
            return 0;
        }
        public static int pmapproc_getport(Socket so, int xid, int lid, Flags flags, int lock_timeout, int io_timeout)
        {
            return 0;
        }
        public static int pmapproc_dump(Socket so, int xid, int lid, Flags flags, int lock_timeout, int io_timeout)
        {
            return 0;
        }
     }
}