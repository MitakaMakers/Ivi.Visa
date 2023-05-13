using System.Runtime.InteropServices;

namespace Vxi11Net
{
    public class Vxi11
    {
        // RPC define
        public const int DEVICE_CORE_PROG = 395183;
        public const int DEVICE_CORE_VERSION = 1;
        public const int CREATE_LINK = 10;
        public const int DEVICE_WRITE = 11;
        public const int DEVICE_READ = 12;
        public const int DEVICE_READSTB = 13;
        public const int DEVICE_TRIGGER = 14;
        public const int DEVICE_CLEAR = 15;
        public const int DEVICE_REMOTE = 16;
        public const int DEVICE_LOCAL = 17;
        public const int DEVICE_LOCK = 18;
        public const int DEVICE_UNLOCK = 19;
        public const int DEVICE_ENABLE_SRQ = 20;
        public const int DEVICE_DOCMD = 22;
        public const int DESTROY_LINK = 23;
        public const int CREATE_INTR_CHAN = 25;
        public const int DESTROY_INTR_CHAN = 26;
        public const int DEVICE_ABORT_PROG = 395184;
        public const int DEVICE_ABORT_VERSION = 1;
        public const int DEVICE_ABORT = 1;
        public const int DEVICE_INTR_PROG = 395185;
        public const int DEVICE_INTR_VERSION = 1;
        public const int DEVICE_INTR_SRQ = 30;
        public const int DEVICE_CORE = 395183;

        [Flags]
        public enum Flags
        {
            termchrset = 0x80,
            end = 0x08,
            waitlock = 0x01,
            none = 0x00
        }
        public enum TermChar
        {
            CR = 0x0A,
            LF = 0x0D,
            None = 0x00
        }
        [Flags]
        public enum Reason
        {
            END = 0x04,
            CHR = 0x02,
            REQCNT = 0x01,
            NONE = 0x00
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct CREATE_LINK_CALL
        {
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
        public struct CREATE_LINK_PARAMS
        {
            public int clientId;
            public int lockDevice;
            public int lock_timeout;
            public int handle_len;
        };
        public struct CREATE_LINK_REPLY
        {
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
        public struct DEVICE_WRITE_PARAMS
        {
            public int lid;
            public int flags;
            public int lock_timeout;
            public int io_timeout;
            public int data_len;
        };
        public struct DEVICE_WRITE_REPLY
        {
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
        public struct DEVICE_READ_PARAMS
        {
            public int lid;
            public int requestSize;
            public int io_timeout;
            public int lock_timeout;
            public int flags;
            public int termChar;
        };
        public struct DEVICE_READ_REPLY
        {
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
        public struct DEVICE_GENERIC_PARAMS
        {
            public int lid;
            public int flags;
            public int lock_timeout;
            public int io_timeout;
        };
        public struct DEVICE_GENERIC_REPLY
        {
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
        public struct DEVICE_LOCK_PARAMS
        {
            public int lid;
            public int flags;
            public int lock_timeout;
        };
        public struct DEVICE_UNLOCK_CALL
        {
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
        public struct CREATE_INTR_CHAN_PARAMS
        {
            public int hostaddr;
            public int hostport;
            public int prognum;
            public int progvers;
            public int progfamily;
        };
        public struct DEVICE_ENABLE_SRQ_CALL
        {
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
        public struct DEVICE_ENABLE_SRQ_PARAMS
        {
            public int lid;
            public int enable;
            public int handle_len;
        };
        public struct DEVICE_READSTB_REPLY
        {
            public int xid;
            public int msg_type;
            public int stat;
            public int verf_flavor;
            public int verf_len;
            public int accept_stat;
            public int error;
            public byte stb;
        };
        public struct DEVICE_DOCMD_CALL
        {
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
        public struct DEVICE_DOCMD_PARAMS
        {
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
            public int xid;
            public int msg_type;
            public int stat;
            public int verf_flavor;
            public int verf_len;
            public int accept_stat;
            public int error;
            public int data_out_len;
        };
        public struct DESTROY_INTR_CHAN_CALL
        {
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
    }
}