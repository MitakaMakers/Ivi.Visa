using System.Runtime.InteropServices;

namespace Vxi11Net
{
    public class Pmap
    {
        public const ushort PMAPPORT = 111;
        public const int PROG = 100000;
        public const int VERS = 2;
        public const int PROC_NULL = 0;
        public const int PROC_SET = 1;
        public const int PROC_UNSET = 2;
        public const int PROC_GETPORT = 3;
        public const int PROC_DUMP = 4;
        public const int PROC_CALLIT = 5;
        public const int RPC_VER = 2;
        public const int PMAP_PROG = 100000;
        public const int PMAP_VERS = 2;
        public const int PMAPPROC_SET = 1;
        public const int PMAPPROC_UNSET = 2;
        public const int PMAPPROC_DUMP = 4;
        public enum IPPROTO
        {
            TCP = 6,      /* protocol number for TCP/IP     */
            UDP = 17     /* protocol number for UDP        */
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct PMAP_NULL_REPLY
        {
            public int xid;
            public int msg_type;
            public int stat;
            public int verf_flavor;
            public int verf_len;
            public int accept_stat;
        };
        public struct PMAP_SET_CALL
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
            public int prognum;
            public int progvers;
            public int proto;
            public int port;
        };
        public struct PMAP_SET_REPLY
        {
            public int xid;
            public int msg_type;
            public int stat;
            public int verf_flavor;
            public int verf_len;
            public int accept_stat;
            public int boolean;
        };
        public struct PMAP_UNSET_CALL
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
            public int prognum;
            public int progvers;
            public int proto;
            public int port;
        };
        public struct PMAP_UNSET_REPLY
        {
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
        public struct GET_PORT_CALL
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
            public int prognum;
            public int progvers;
            public int proto;
            public int port;
        };
        public struct PMAP_GETPORT_REPLY
        {
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
            public Pmap.IPPROTO prot;
            public int port;
        };
    }
}
