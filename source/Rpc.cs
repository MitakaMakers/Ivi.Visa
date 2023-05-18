using System.Runtime.InteropServices;

namespace Vxi11Net
{
    public class Rpc
    {
        public const int CALL = 0;
        public const int REPLY = 1;
        public const int MSG_ACCEPTED = 0;
        public const int MSG_DENIED = 1;
        public const int SUCCESS = 0;
        public const int PROG_UNAVAIL = 1;
        public const int PROG_MISMATCH = 2;
        public const int PROC_UNAVAIL = 3;
        public const int GARBAGE_ARGS = 4;
        public const int SYSTEM_ERR = 5;
        public const int RPC_MISMATCH = 0;
        public const int AUTH_ERROR = 1;
        public const int RPC_VER = 2;

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct RPC_MESSAGE_PARAMS
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
        public struct RPC_MESSAGE_RESP
        {
            public int xid;
            public int msg_type;
            public int stat;
            public int verf_flavor;
            public int verf_len;
            public int accept_stat;
        };

    }
}
