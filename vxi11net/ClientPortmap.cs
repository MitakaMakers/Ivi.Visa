using System.Net;
using System.Runtime.InteropServices;

namespace Vxi11Net
{
    public class ClientPortmap
    {
        private ClientRpc rpc = new ClientRpc();

        public void Create(string host, int port, Pmap.IPPROTO prot)
        {
            if (prot == Pmap.IPPROTO.TCP)
            {
                rpc.CreateTcp(host, port);
            }
            else
            {
                rpc.CreateUdp(host, port);
            }
        }
        public void Destroy()
        {
            rpc.Destroy();
        }

        public int Set(int program, int version, Pmap.IPPROTO protocol, int port)
        {
            Pmap.PMAP_SET_CALL arg = new Pmap.PMAP_SET_CALL();
            arg.msg_type = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog = IPAddress.HostToNetworkOrder(Pmap.PMAP_PROG);
            arg.vers = IPAddress.HostToNetworkOrder(Pmap.PMAP_VERS);
            arg.proc = IPAddress.HostToNetworkOrder(Pmap.PROC_SET);
            arg.cred_flavor = IPAddress.HostToNetworkOrder(0);
            arg.cred_len = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor = IPAddress.HostToNetworkOrder(0);
            arg.verf_len = IPAddress.HostToNetworkOrder(0);
            arg.prognum = IPAddress.HostToNetworkOrder(program);
            arg.progvers = IPAddress.HostToNetworkOrder(version);
            arg.proto = IPAddress.HostToNetworkOrder((short)protocol);
            arg.port = IPAddress.HostToNetworkOrder(port);
            byte[] packet = new byte[Marshal.SizeOf(typeof(Pmap.PMAP_SET_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            rpc.Call(packet, true, true);

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Pmap.PMAP_SET_REPLY))];
            rpc.GetReply(buffer);
            Pmap.PMAP_SET_REPLY reply = new Pmap.PMAP_SET_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.boolean = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));

            return reply.boolean;
        }
        public int Unset(int program, int version, Pmap.IPPROTO protocol)
        {
            Pmap.PMAP_UNSET_CALL arg = new Pmap.PMAP_UNSET_CALL();
            arg.msg_type = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog = IPAddress.HostToNetworkOrder(Pmap.PMAP_PROG);
            arg.vers = IPAddress.HostToNetworkOrder(Pmap.PMAP_VERS);
            arg.proc = IPAddress.HostToNetworkOrder(Pmap.PROC_SET);
            arg.cred_flavor = IPAddress.HostToNetworkOrder(0);
            arg.cred_len = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor = IPAddress.HostToNetworkOrder(0);
            arg.verf_len = IPAddress.HostToNetworkOrder(0);
            arg.prognum = IPAddress.HostToNetworkOrder(program);
            arg.progvers = IPAddress.HostToNetworkOrder(version);
            arg.proto = IPAddress.HostToNetworkOrder((short)protocol);
            arg.port = IPAddress.HostToNetworkOrder(0);
            byte[] packet = new byte[Marshal.SizeOf(typeof(Pmap.PMAP_UNSET_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            rpc.Call(packet, true, true);

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Pmap.PMAP_UNSET_REPLY))];
            rpc.GetReply(buffer);
            Pmap.PMAP_UNSET_REPLY reply = new Pmap.PMAP_UNSET_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.boolean = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));

            return reply.boolean;
        }

        public int Getport(int program, int version, Pmap.IPPROTO protocol)
        {
            Pmap.PMAP_GETPORT_CALL arg = new Pmap.PMAP_GETPORT_CALL();
            arg.msg_type = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog = IPAddress.HostToNetworkOrder(Pmap.PMAP_PROG);
            arg.vers = IPAddress.HostToNetworkOrder(Pmap.PMAP_VERS);
            arg.proc = IPAddress.HostToNetworkOrder(Pmap.PROC_SET);
            arg.cred_flavor = IPAddress.HostToNetworkOrder(0);
            arg.cred_len = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor = IPAddress.HostToNetworkOrder(0);
            arg.verf_len = IPAddress.HostToNetworkOrder(0);
            arg.prognum = IPAddress.HostToNetworkOrder(program);
            arg.progvers = IPAddress.HostToNetworkOrder(version);
            arg.proto = IPAddress.HostToNetworkOrder((short)protocol);
            arg.port = IPAddress.HostToNetworkOrder(0);
            byte[] packet = new byte[Marshal.SizeOf(typeof(Pmap.PMAP_GETPORT_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            rpc.Call(packet, true, true);

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Pmap.PMAP_GETPORT_REPLY))];
            rpc.GetReply(buffer);
            Pmap.PMAP_GETPORT_REPLY reply = new Pmap.PMAP_GETPORT_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.port = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));

            return reply.port;
        }
        public List<Pmap.MAPPING> Dump()
        {
            Pmap.PMAP_DUMP_CALL arg = new Pmap.PMAP_DUMP_CALL();
            arg.msg_type = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog = IPAddress.HostToNetworkOrder(Pmap.PMAP_PROG);
            arg.vers = IPAddress.HostToNetworkOrder(Pmap.PMAP_VERS);
            arg.proc = IPAddress.HostToNetworkOrder(Pmap.PROC_SET);
            arg.cred_flavor = IPAddress.HostToNetworkOrder(0);
            arg.cred_len = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor = IPAddress.HostToNetworkOrder(0);
            arg.verf_len = IPAddress.HostToNetworkOrder(0);
            byte[] packet = new byte[Marshal.SizeOf(typeof(Pmap.PMAP_DUMP_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            rpc.Call(packet, true, true);

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Pmap.PMAP_DUMP_REPLY))];
            rpc.GetReply(buffer);
            Pmap.PMAP_DUMP_REPLY reply = new Pmap.PMAP_DUMP_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));

            return new List<Pmap.MAPPING>();
        }
    }
}