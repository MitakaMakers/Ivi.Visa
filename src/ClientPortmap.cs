using System.Net;
using System.Runtime.InteropServices;

namespace Vxi11Net
{
    public class ClientPortmapTcp
    {
        private ClientRpcTcp clientRpcTcp = new ClientRpcTcp();
        private int xid = 1;

        public void Create(string host, int port)
        {
            clientRpcTcp.Create(host, port);
        }
        public void Destroy()
        {
            clientRpcTcp.Destroy();
        }

        private int GetXid()
        {
            int _xid = xid;
            xid = xid + 1;
            return _xid;
        }

        public int Set(int program, int version, int protocol, int port)
        {
            Portmap.PMAP_SET_CALL arg = new Portmap.PMAP_SET_CALL();
            arg.xid = IPAddress.HostToNetworkOrder(GetXid());
            arg.msg_type = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog = IPAddress.HostToNetworkOrder(Portmap.PMAP_PROG);
            arg.vers = IPAddress.HostToNetworkOrder(Portmap.PMAP_VERS);
            arg.proc = IPAddress.HostToNetworkOrder(Portmap.PMAPPROC_SET);
            arg.cred_flavor = IPAddress.HostToNetworkOrder(0);
            arg.cred_len = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor = IPAddress.HostToNetworkOrder(0);
            arg.verf_len = IPAddress.HostToNetworkOrder(0);
            arg.prognum = IPAddress.HostToNetworkOrder(program);
            arg.progvers = IPAddress.HostToNetworkOrder(version);
            arg.proto = IPAddress.HostToNetworkOrder(protocol);
            arg.port = IPAddress.HostToNetworkOrder(port);

            byte[] packet = new byte[Marshal.SizeOf(typeof(Portmap.PMAP_SET_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            clientRpcTcp.Call(packet, true, true);

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Portmap.PMAP_SET_REPLY))];
            clientRpcTcp.GetReply(buffer, true);

            Portmap.PMAP_SET_REPLY reply = new Portmap.PMAP_SET_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.boolean = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));

            return reply.boolean;
        }
        public int Unset(int program, int version, int protocol)
        {
            Portmap.PMAP_UNSET_CALL arg = new Portmap.PMAP_UNSET_CALL();
            arg.xid = IPAddress.HostToNetworkOrder(GetXid());
            arg.msg_type = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog = IPAddress.HostToNetworkOrder(Portmap.PMAP_PROG);
            arg.vers = IPAddress.HostToNetworkOrder(Portmap.PMAP_VERS);
            arg.proc = IPAddress.HostToNetworkOrder(Portmap.PMAPPROC_UNSET);
            arg.cred_flavor = IPAddress.HostToNetworkOrder(0);
            arg.cred_len = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor = IPAddress.HostToNetworkOrder(0);
            arg.verf_len = IPAddress.HostToNetworkOrder(0);
            arg.prognum = IPAddress.HostToNetworkOrder(program);
            arg.progvers = IPAddress.HostToNetworkOrder(version);
            arg.proto = IPAddress.HostToNetworkOrder(protocol);
            arg.port = IPAddress.HostToNetworkOrder(0);

            byte[] packet = new byte[Marshal.SizeOf(typeof(Portmap.PMAP_UNSET_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            clientRpcTcp.Call(packet, true, true);

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Portmap.PMAP_UNSET_REPLY))];
            clientRpcTcp.GetReply(buffer, true);

            Portmap.PMAP_UNSET_REPLY reply = new Portmap.PMAP_UNSET_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.boolean = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            return reply.boolean;
        }

        public int GetPort(int program, int version, Portmap.IPPROTO protocol)
        {
            Portmap.PMAP_GETPORT_CALL arg = new Portmap.PMAP_GETPORT_CALL();
            arg.xid = IPAddress.HostToNetworkOrder(GetXid());
            arg.msg_type = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog = IPAddress.HostToNetworkOrder(Portmap.PMAP_PROG);
            arg.vers = IPAddress.HostToNetworkOrder(Portmap.PMAP_VERS);
            arg.proc = IPAddress.HostToNetworkOrder(Portmap.PMAPPROC_GETPORT);
            arg.cred_flavor = IPAddress.HostToNetworkOrder(0);
            arg.cred_len = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor = IPAddress.HostToNetworkOrder(0);
            arg.verf_len = IPAddress.HostToNetworkOrder(0);
            arg.prognum = IPAddress.HostToNetworkOrder(program);
            arg.progvers = IPAddress.HostToNetworkOrder(version);
            arg.proto = IPAddress.HostToNetworkOrder((int)protocol);
            arg.port = IPAddress.HostToNetworkOrder(0);

            byte[] packet = new byte[Marshal.SizeOf(typeof(Portmap.PMAP_GETPORT_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            clientRpcTcp.Call(packet, true, true);

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Portmap.PMAP_GETPORT_REPLY))];
            clientRpcTcp.GetReply(buffer, true);

            Portmap.PMAP_GETPORT_REPLY reply = new Portmap.PMAP_GETPORT_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.port = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));

            return reply.port;
        }
    }
    public class ClientPortmapUdp
    {
        private ClientRpcUdp clientRpcUdp = new ClientRpcUdp();
        private int xid = 1;

        public void Create(string host, int port)
        {
            clientRpcUdp.Create(host, port);
        }
        public void Destroy()
        {
            clientRpcUdp.Destroy();
        }

        private int GetXid()
        {
            int _xid = xid;
            xid = xid + 1;
            return _xid;
        }

        public int Set(int program, int version, int protocol, int port)
        {
            Portmap.PMAP_SET_CALL arg = new Portmap.PMAP_SET_CALL();
            arg.xid = IPAddress.HostToNetworkOrder(GetXid());
            arg.msg_type = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog = IPAddress.HostToNetworkOrder(Portmap.PMAP_PROG);
            arg.vers = IPAddress.HostToNetworkOrder(Portmap.PMAP_VERS);
            arg.proc = IPAddress.HostToNetworkOrder(Portmap.PMAPPROC_SET);
            arg.cred_flavor = IPAddress.HostToNetworkOrder(0);
            arg.cred_len = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor = IPAddress.HostToNetworkOrder(0);
            arg.verf_len = IPAddress.HostToNetworkOrder(0);
            arg.prognum = IPAddress.HostToNetworkOrder(program);
            arg.progvers = IPAddress.HostToNetworkOrder(version);
            arg.proto = IPAddress.HostToNetworkOrder(protocol);
            arg.port = IPAddress.HostToNetworkOrder(port);

            byte[] packet = new byte[Marshal.SizeOf(typeof(Portmap.PMAP_SET_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            clientRpcUdp.Call(packet, true, true);

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Portmap.PMAP_SET_REPLY))];
            clientRpcUdp.GetReply(buffer, true);

            Portmap.PMAP_SET_REPLY reply = new Portmap.PMAP_SET_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.boolean = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));

            return reply.boolean;
        }
        public int Unset(int program, int version, int protocol)
        {
            Portmap.PMAP_UNSET_CALL arg = new Portmap.PMAP_UNSET_CALL();
            arg.xid = IPAddress.HostToNetworkOrder(GetXid());
            arg.msg_type = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog = IPAddress.HostToNetworkOrder(Portmap.PMAP_PROG);
            arg.vers = IPAddress.HostToNetworkOrder(Portmap.PMAP_VERS);
            arg.proc = IPAddress.HostToNetworkOrder(Portmap.PMAPPROC_UNSET);
            arg.cred_flavor = IPAddress.HostToNetworkOrder(0);
            arg.cred_len = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor = IPAddress.HostToNetworkOrder(0);
            arg.verf_len = IPAddress.HostToNetworkOrder(0);
            arg.prognum = IPAddress.HostToNetworkOrder(program);
            arg.progvers = IPAddress.HostToNetworkOrder(version);
            arg.proto = IPAddress.HostToNetworkOrder(protocol);
            arg.port = IPAddress.HostToNetworkOrder(0);

            byte[] packet = new byte[Marshal.SizeOf(typeof(Portmap.PMAP_UNSET_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            clientRpcUdp.Call(packet, true, true);

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Portmap.PMAP_UNSET_REPLY))];
            clientRpcUdp.GetReply(buffer, true);

            Portmap.PMAP_UNSET_REPLY reply = new Portmap.PMAP_UNSET_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.boolean = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            return reply.boolean;
        }

        public int GetPort(int program, int version, int protocol)
        {
            Portmap.PMAP_GETPORT_CALL arg = new Portmap.PMAP_GETPORT_CALL();
            arg.xid = IPAddress.HostToNetworkOrder(GetXid());
            arg.msg_type = IPAddress.HostToNetworkOrder(Rpc.CALL);
            arg.rpcvers = IPAddress.HostToNetworkOrder(Rpc.RPC_VER);
            arg.prog = IPAddress.HostToNetworkOrder(Portmap.PMAP_PROG);
            arg.vers = IPAddress.HostToNetworkOrder(Portmap.PMAP_VERS);
            arg.proc = IPAddress.HostToNetworkOrder(Portmap.PMAPPROC_GETPORT);
            arg.cred_flavor = IPAddress.HostToNetworkOrder(0);
            arg.cred_len = IPAddress.HostToNetworkOrder(0);
            arg.verf_flavor = IPAddress.HostToNetworkOrder(0);
            arg.verf_len = IPAddress.HostToNetworkOrder(0);
            arg.prognum = IPAddress.HostToNetworkOrder(program);
            arg.progvers = IPAddress.HostToNetworkOrder(version);
            arg.proto = IPAddress.HostToNetworkOrder(protocol);
            arg.port = IPAddress.HostToNetworkOrder(0);

            byte[] packet = new byte[Marshal.SizeOf(typeof(Portmap.PMAP_GETPORT_CALL))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(arg, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            clientRpcUdp.Call(packet, true, true);

            byte[] buffer = new byte[Marshal.SizeOf(typeof(Portmap.PMAP_GETPORT_REPLY))];
            clientRpcUdp.GetReply(buffer, true);

            Portmap.PMAP_GETPORT_REPLY reply = new Portmap.PMAP_GETPORT_REPLY();
            reply.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            reply.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            reply.stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            reply.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            reply.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            reply.accept_stat = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            reply.port = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));

            return reply.port;
        }
    }
}