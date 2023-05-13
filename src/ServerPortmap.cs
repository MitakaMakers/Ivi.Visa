using System.Net;
using System.Runtime.InteropServices;

namespace Vxi11Net
{
    public class Portmap
    {
        private static List<Pmap.MAPPING> pmaplist = new List<Pmap.MAPPING>();
        public static bool AddPort(int prog, int vers, Pmap.IPPROTO prot, int port)
        {
            bool ret = false;
            Pmap.MAPPING? find = null;
            for (int i = 0; i < pmaplist.Count; i++)
            {
                Pmap.MAPPING map = pmaplist[i];
                if ((map.prog == prog) && (map.vers == vers) && (map.prot == prot))
                {
                    find = map;
                    break;
                }
            }
            if (find == null)
            {
                Pmap.MAPPING map = new Pmap.MAPPING();
                map.vers = vers;
                map.prog = prog;
                map.prot = prot;
                map.port = port;
                pmaplist.Add(map);
                ret = true;
            }
            return ret;
        }
        public static bool RemovePort(int prog, int vers, Pmap.IPPROTO prot)
        {
            bool ret = false;
            for (int i = 0; i < pmaplist.Count; i++)
            {
                Pmap.MAPPING map = pmaplist[i];
                if ((map.prog == prog) && (map.vers == vers) && (map.prot == prot))
                {
                    pmaplist.Remove(map);
                    ret = true;
                    break;
                }
            }
            return ret;
        }

        public static int FindPort(int prog, int vers, Pmap.IPPROTO prot)
        {
            int port = 0; ;
            for (int i = 0; i < pmaplist.Count; i++)
            {
                Pmap.MAPPING map = pmaplist[i];
                if ((map.prog == prog) && (map.vers == vers) && (map.prot == prot))
                {
                    port = map.port;
                    break;
                }
            }
            return port;
        }
    }
    public class ServerPortmapTcp
    {
        private ServerRpcTcp serverRpcTcp = new ServerRpcTcp();
        private CancellationTokenSource tokenSource = new CancellationTokenSource();
        public void Create(string host, int port)
        {
            serverRpcTcp.Create(host, port);
            Portmap.AddPort(Pmap.PROG, Pmap.VERS, Pmap.IPPROTO.TCP, port);
        }
        public void Destroy()
        {
            tokenSource.Cancel();
            serverRpcTcp.Destroy();
            Portmap.RemovePort(Pmap.PROG, Pmap.VERS, Pmap.IPPROTO.TCP);
        }
        public Rpc.RPC_MESSAGE_PARAMS ReceiveMsg()
        {
            return serverRpcTcp.ReceiveMsg();
        }
        public Pmap.MAPPING ReceiveSet()
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(Pmap.MAPPING))];
            serverRpcTcp.GetArgs(buffer);

            Pmap.MAPPING map = new Pmap.MAPPING();
            map.prog = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            map.vers = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            map.prot = (Pmap.IPPROTO)IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            map.port = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            return map;
        }

        public void ReplySet(int xid, bool status)
        {
            Pmap.PMAP_UNSET_REPLY reply = new Pmap.PMAP_UNSET_REPLY();
            reply.xid = IPAddress.HostToNetworkOrder(xid);
            reply.msg_type = IPAddress.HostToNetworkOrder(Rpc.REPLY);
            reply.stat = IPAddress.HostToNetworkOrder(Rpc.MSG_ACCEPTED);
            reply.verf_flavor = IPAddress.HostToNetworkOrder(0);
            reply.verf_len = IPAddress.HostToNetworkOrder(0);
            reply.accept_stat = IPAddress.HostToNetworkOrder(Rpc.SUCCESS);
            reply.boolean = (status == true) ? 1 : 0;

            byte[] packet = new byte[Marshal.SizeOf(typeof(Pmap.PMAP_UNSET_REPLY))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            serverRpcTcp.Reply(packet, true, true);
        }
        public Pmap.MAPPING ReceiveUnset()
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(Pmap.MAPPING))];
            serverRpcTcp.GetArgs(buffer);

            Pmap.MAPPING map = new Pmap.MAPPING();
            map.prog = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            map.vers = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            map.prot = (Pmap.IPPROTO)IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            map.port = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            return map;
        }
        public void ReplyUnset(int xid, bool status)
        {
            Pmap.PMAP_UNSET_REPLY reply = new Pmap.PMAP_UNSET_REPLY();
            reply.xid = IPAddress.HostToNetworkOrder(xid);
            reply.msg_type = IPAddress.HostToNetworkOrder(Rpc.REPLY);
            reply.stat = IPAddress.HostToNetworkOrder(Rpc.MSG_ACCEPTED);
            reply.verf_flavor = IPAddress.HostToNetworkOrder(0);
            reply.verf_len = IPAddress.HostToNetworkOrder(0);
            reply.accept_stat = IPAddress.HostToNetworkOrder(Rpc.SUCCESS);
            reply.boolean = (status == true) ? 1 : 0;

            byte[] packet = new byte[Marshal.SizeOf(typeof(Pmap.PMAP_UNSET_REPLY))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            serverRpcTcp.Reply(packet, true, true);
        }
        public Pmap.MAPPING ReceiveGetPort()
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(Pmap.MAPPING))];
            serverRpcTcp.GetArgs(buffer);

            Pmap.MAPPING map = new Pmap.MAPPING();
            map.prog = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            map.vers = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            map.prot = (Pmap.IPPROTO)IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            map.port = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            return map;
        }
        public void ReplyGetPort(int xid, int port)
        {
            Pmap.PMAP_GETPORT_REPLY reply = new Pmap.PMAP_GETPORT_REPLY();
            reply.xid = IPAddress.HostToNetworkOrder(xid);
            reply.msg_type = IPAddress.HostToNetworkOrder(Rpc.REPLY);
            reply.stat = IPAddress.HostToNetworkOrder(Rpc.MSG_ACCEPTED);
            reply.verf_flavor = IPAddress.HostToNetworkOrder(0);
            reply.verf_len = IPAddress.HostToNetworkOrder(0);
            reply.accept_stat = IPAddress.HostToNetworkOrder(Rpc.SUCCESS);
            reply.port = IPAddress.HostToNetworkOrder(port);

            byte[] packet = new byte[Marshal.SizeOf(typeof(Pmap.PMAP_GETPORT_REPLY))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            serverRpcTcp.Reply(packet, true, true);
        }
        public void ClearArgs()
        {
            serverRpcTcp.ClearArgs();
        }
        public void TcpThread()
        {
            Rpc.RPC_MESSAGE_PARAMS msg;
            while (!tokenSource.Token.IsCancellationRequested)
            {
                try { 
                Console.WriteLine("  == Wait RPC ==");
                msg = serverRpcTcp.ReceiveMsg();
                Console.WriteLine("    received Portmap(TCP).");
                Console.WriteLine("      xid     = {0}", msg.xid);
                Console.WriteLine("      type    = {0}", msg.msg_type);
                Console.WriteLine("      prog    = {0}", msg.prog);
                Console.WriteLine("      proc    = {0}", msg.proc);
                Console.WriteLine("      vers    = {0}", msg.vers);
                if (msg.proc == Pmap.PROC_SET)
                {
                    Console.WriteLine("    == PMAPPROC_SET ==");
                    Pmap.MAPPING map = ReceiveSet();
                    Console.WriteLine("      prog    = {0}", map.prog);
                    Console.WriteLine("      vers    = {0}", map.vers);
                    Console.WriteLine("      prot    = {0}", map.prot);
                    Console.WriteLine("      port    = {0}", map.port);
                    Console.WriteLine("");
                    bool status = Portmap.AddPort(map.prog, map.vers, map.prot, map.port);
                    ReplySet(msg.xid, status);
                }
                else if (msg.proc == Pmap.PROC_UNSET)
                {
                    Console.WriteLine("    == PMAPPROC_UNSET ==");
                    Pmap.MAPPING map = ReceiveUnset();
                    Console.WriteLine("      prog    = {0}", map.prog);
                    Console.WriteLine("      vers    = {0}", map.vers);
                    Console.WriteLine("      prot    = {0}", map.prot);
                    Console.WriteLine("");
                    bool status = Portmap.RemovePort(map.prog, map.vers, map.prot);
                    ReplyUnset(msg.xid, status);
                }
                else if (msg.proc == Pmap.PROC_GETPORT)
                {
                    Console.WriteLine("    == PMAPPROC_GETPORT ==");
                    Pmap.MAPPING map = ReceiveGetPort();
                    Console.WriteLine("      prog    = {0}", map.prog);
                    Console.WriteLine("      vers    = {0}", map.vers);
                    Console.WriteLine("      prot    = {0}", map.prot);
                    Console.WriteLine("");
                    int prog_port = Portmap.FindPort(map.prog, map.vers, map.prot);
                    ReplyGetPort(msg.xid, prog_port);
                }
                else
                {
                    Console.WriteLine("    == clear buffer ==");
                    ClearArgs();
                }
                } catch (Exception e)
                {
                    serverRpcTcp.Close();
                }
            }
        }
        public void Run(string host, int port)
        {
            tokenSource.TryReset();

            Console.WriteLine("== Run PortmapServer(TCP, {0}, {1}) ==", host, port);
            Create(host, port);

            Task.Run(() =>
            {
                TcpThread();
            });
            Thread.Sleep(10);
        }
        public void Shutdown()
        {
            tokenSource.Cancel();
        }
    }
    public class ServerPortmapUdp
    {
        private ServerRpcUdp serverRpcUdp = new ServerRpcUdp();
        private CancellationTokenSource tokenSource = new CancellationTokenSource();

        public void Create(string host, int port)
        {
            serverRpcUdp.Create(host, port);
            Portmap.AddPort(Pmap.PROG, Pmap.VERS, Pmap.IPPROTO.UDP, port);
        }
        public void Destroy()
        {
            tokenSource.Cancel();
            serverRpcUdp.Destroy();
            Portmap.RemovePort(Pmap.PROG, Pmap.VERS, Pmap.IPPROTO.UDP);
        }
        public Rpc.RPC_MESSAGE_PARAMS ReceiveMsg()
        {
            return serverRpcUdp.ReceiveMsg();
        }

        public Pmap.MAPPING ReceiveSet()
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(Pmap.MAPPING))];
            serverRpcUdp.GetArgs(buffer);

            Pmap.MAPPING map = new Pmap.MAPPING();
            map.prog = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            map.vers = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            map.prot = (Pmap.IPPROTO)IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            map.port = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            return map;
        }

        public void ReplySet(int xid, bool status)
        {
            Pmap.PMAP_UNSET_REPLY reply = new Pmap.PMAP_UNSET_REPLY();
            reply.xid = IPAddress.HostToNetworkOrder(xid);
            reply.msg_type = IPAddress.HostToNetworkOrder(Rpc.REPLY);
            reply.stat = IPAddress.HostToNetworkOrder(Rpc.MSG_ACCEPTED);
            reply.verf_flavor = IPAddress.HostToNetworkOrder(0);
            reply.verf_len = IPAddress.HostToNetworkOrder(0);
            reply.accept_stat = IPAddress.HostToNetworkOrder(Rpc.SUCCESS);
            reply.boolean = (status == true) ? 1 : 0;

            byte[] packet = new byte[Marshal.SizeOf(typeof(Pmap.PMAP_UNSET_REPLY))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            serverRpcUdp.Reply(packet);
        }
        public Pmap.MAPPING ReceiveUnset()
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(Pmap.MAPPING))];
            serverRpcUdp.GetArgs(buffer);

            Pmap.MAPPING map = new Pmap.MAPPING();
            map.prog = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            map.vers = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            map.prot = (Pmap.IPPROTO)IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            map.port = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            return map;
        }
        public void ReplyUnset(int xid, bool status)
        {
            Pmap.PMAP_UNSET_REPLY reply = new Pmap.PMAP_UNSET_REPLY();
            reply.xid = IPAddress.HostToNetworkOrder(xid);
            reply.msg_type = IPAddress.HostToNetworkOrder(Rpc.REPLY);
            reply.stat = IPAddress.HostToNetworkOrder(Rpc.MSG_ACCEPTED);
            reply.verf_flavor = IPAddress.HostToNetworkOrder(0);
            reply.verf_len = IPAddress.HostToNetworkOrder(0);
            reply.accept_stat = IPAddress.HostToNetworkOrder(Rpc.SUCCESS);
            reply.boolean = (status == true) ? 1 : 0;

            byte[] packet = new byte[Marshal.SizeOf(typeof(Pmap.PMAP_UNSET_REPLY))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            serverRpcUdp.Reply(packet);
        }
        public Pmap.MAPPING ReceiveGetPort()
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(Pmap.MAPPING))];
            serverRpcUdp.GetArgs(buffer);

            Pmap.MAPPING map = new Pmap.MAPPING();
            map.prog = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            map.vers = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            map.prot = (Pmap.IPPROTO)IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            map.port = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            return map;
        }
        public void ReplyGetPort(int xid, int port)
        {
            Pmap.PMAP_GETPORT_REPLY reply = new Pmap.PMAP_GETPORT_REPLY();
            reply.xid = IPAddress.HostToNetworkOrder(xid);
            reply.msg_type = IPAddress.HostToNetworkOrder(Rpc.REPLY);
            reply.stat = IPAddress.HostToNetworkOrder(Rpc.MSG_ACCEPTED);
            reply.verf_flavor = IPAddress.HostToNetworkOrder(0);
            reply.verf_len = IPAddress.HostToNetworkOrder(0);
            reply.accept_stat = IPAddress.HostToNetworkOrder(Rpc.SUCCESS);
            reply.port = IPAddress.HostToNetworkOrder(port);

            byte[] packet = new byte[Marshal.SizeOf(typeof(Pmap.PMAP_GETPORT_REPLY))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            serverRpcUdp.Reply(packet);
        }
        public void ClearArgs()
        {
            serverRpcUdp.ClearArgs();
        }
        public void UdpThread()
        {
            Rpc.RPC_MESSAGE_PARAMS msg;
            while (!tokenSource.Token.IsCancellationRequested)
            {
                Console.WriteLine("  == Wait RPC ==");
                msg = serverRpcUdp.ReceiveMsg();
                Console.WriteLine("    received Portmap(UDP).");
                Console.WriteLine("      xid     = {0}", msg.xid);
                Console.WriteLine("      type    = {0}", msg.msg_type);
                Console.WriteLine("      prog    = {0}", msg.prog);
                Console.WriteLine("      proc    = {0}", msg.proc);
                Console.WriteLine("      vers    = {0}", msg.vers);
                if (msg.proc == Pmap.PROC_SET)
                {
                    Console.WriteLine("    == PMAPPROC_SET ==");
                    Pmap.MAPPING map = ReceiveSet();
                    Console.WriteLine("      prog    = {0}", map.prog);
                    Console.WriteLine("      vers    = {0}", map.vers);
                    Console.WriteLine("      prot    = {0}", map.prot);
                    Console.WriteLine("      port    = {0}", map.port);
                    Console.WriteLine("");
                    bool status = Portmap.AddPort(map.prog, map.vers, map.prot, map.port);
                    ReplySet(msg.xid, status);
                }
                else if (msg.proc == Pmap.PROC_UNSET)
                {
                    Console.WriteLine("    == PMAPPROC_UNSET ==");
                    Pmap.MAPPING map = ReceiveUnset();
                    Console.WriteLine("      prog    = {0}", map.prog);
                    Console.WriteLine("      vers    = {0}", map.vers);
                    Console.WriteLine("      prot    = {0}", map.prot);
                    Console.WriteLine("");
                    bool status = Portmap.RemovePort(map.prog, map.vers, map.prot);
                    ReplyUnset(msg.xid, status);
                }
                else if (msg.proc == Pmap.PROC_GETPORT)
                {
                    Console.WriteLine("    == PMAPPROC_GETPORT ==");
                    Pmap.MAPPING map = ReceiveGetPort();
                    Console.WriteLine("      prog    = {0}", map.prog);
                    Console.WriteLine("      vers    = {0}", map.vers);
                    Console.WriteLine("      prot    = {0}", map.prot);
                    Console.WriteLine("");
                    int prog_port = Portmap.FindPort(map.prog, map.vers, map.prot);
                    ReplyGetPort(msg.xid, prog_port);
                }
                else
                {
                    Console.WriteLine("    == clear buffer ==");
                    ClearArgs();
                }
            }
        }
        public void Run(string host, int port)
        {
            tokenSource.TryReset();

            Console.WriteLine("== Run PortmapServer(UDP, {0}, {1}) ==", host, port);
            Create(host, port);

            Task.Run(() =>
            {
                UdpThread();
            });
            Thread.Sleep(10);
        }
        public void Shutdown()
        {
            tokenSource.Cancel();
        }
    }
}