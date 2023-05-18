using System.Net;
using System.Runtime.InteropServices;

namespace Vxi11Net
{
    public class ServerPortmapTcp
    {
        public Portmap.MAPPING ReceiveSet()
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(Portmap.MAPPING))];
            serverRpcTcp.GetArgs(buffer);

            Portmap.MAPPING map = new Portmap.MAPPING();
            map.prog = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            map.vers = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            map.prot = (Portmap.IPPROTO)IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            map.port = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            return map;
        }

        public void ReplySet(int xid, bool status)
        {
            Portmap.PMAP_UNSET_REPLY reply = new Portmap.PMAP_UNSET_REPLY();
            reply.xid = IPAddress.HostToNetworkOrder(xid);
            reply.msg_type = IPAddress.HostToNetworkOrder(Rpc.REPLY);
            reply.stat = IPAddress.HostToNetworkOrder(Rpc.MSG_ACCEPTED);
            reply.verf_flavor = IPAddress.HostToNetworkOrder(0);
            reply.verf_len = IPAddress.HostToNetworkOrder(0);
            reply.accept_stat = IPAddress.HostToNetworkOrder(Rpc.SUCCESS);
            reply.boolean = (status == true) ? 1 : 0;

            byte[] packet = new byte[Marshal.SizeOf(typeof(Portmap.PMAP_UNSET_REPLY))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            serverRpcTcp.Reply(packet, true, true);
        }
        public Portmap.MAPPING ReceiveUnset()
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(Portmap.MAPPING))];
            serverRpcTcp.GetArgs(buffer);

            Portmap.MAPPING map = new Portmap.MAPPING();
            map.prog = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            map.vers = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            map.prot = (Portmap.IPPROTO)IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            map.port = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            return map;
        }
        public void ReplyUnset(int xid, bool status)
        {
            Portmap.PMAP_UNSET_REPLY reply = new Portmap.PMAP_UNSET_REPLY();
            reply.xid = IPAddress.HostToNetworkOrder(xid);
            reply.msg_type = IPAddress.HostToNetworkOrder(Rpc.REPLY);
            reply.stat = IPAddress.HostToNetworkOrder(Rpc.MSG_ACCEPTED);
            reply.verf_flavor = IPAddress.HostToNetworkOrder(0);
            reply.verf_len = IPAddress.HostToNetworkOrder(0);
            reply.accept_stat = IPAddress.HostToNetworkOrder(Rpc.SUCCESS);
            reply.boolean = (status == true) ? 1 : 0;

            byte[] packet = new byte[Marshal.SizeOf(typeof(Portmap.PMAP_UNSET_REPLY))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            serverRpcTcp.Reply(packet, true, true);
        }
        public Portmap.MAPPING ReceiveGetPort()
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(Portmap.MAPPING))];
            serverRpcTcp.GetArgs(buffer);

            Portmap.MAPPING map = new Portmap.MAPPING();
            map.prog = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            map.vers = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            map.prot = (Portmap.IPPROTO)IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            map.port = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            return map;
        }
        public void ReplyGetPort(int xid, int port)
        {
            Portmap.PMAP_GETPORT_REPLY reply = new Portmap.PMAP_GETPORT_REPLY();
            reply.xid = IPAddress.HostToNetworkOrder(xid);
            reply.msg_type = IPAddress.HostToNetworkOrder(Rpc.REPLY);
            reply.stat = IPAddress.HostToNetworkOrder(Rpc.MSG_ACCEPTED);
            reply.verf_flavor = IPAddress.HostToNetworkOrder(0);
            reply.verf_len = IPAddress.HostToNetworkOrder(0);
            reply.accept_stat = IPAddress.HostToNetworkOrder(Rpc.SUCCESS);
            reply.port = IPAddress.HostToNetworkOrder(port);

            byte[] packet = new byte[Marshal.SizeOf(typeof(Portmap.PMAP_GETPORT_REPLY))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            serverRpcTcp.Reply(packet, true, true);
        }
        public void ClearArgs()
        {
            serverRpcTcp.ClearArgs();
        }
        public Rpc.RPC_MESSAGE_PARAMS ReceiveMsg()
        {
            return serverRpcTcp.ReceiveMsg();
        }
        public void TcpThread()
        {
            try
            {
                Console.WriteLine("  == Wait RPC ==");
                Rpc.RPC_MESSAGE_PARAMS msg = serverRpcTcp.ReceiveMsg();
                Console.WriteLine("    received Portmap(TCP).");
                Console.WriteLine("      xid     = {0}", msg.xid);
                Console.WriteLine("      type    = {0}", msg.msg_type);
                Console.WriteLine("      prog    = {0}", msg.prog);
                Console.WriteLine("      proc    = {0}", msg.proc);
                Console.WriteLine("      vers    = {0}", msg.vers);
                if (msg.proc == Portmap.PMAPPROC_SET)
                {
                    Console.WriteLine("    == PMAPPROC_SET ==");
                    Portmap.MAPPING map = ReceiveSet();
                    Console.WriteLine("      prog    = {0}", map.prog);
                    Console.WriteLine("      vers    = {0}", map.vers);
                    Console.WriteLine("      prot    = {0}", map.prot);
                    Console.WriteLine("      port    = {0}", map.port);
                    Console.WriteLine("");
                    bool status = ServerPortmap.AddPort(map.prog, map.vers, map.prot, map.port);
                    ReplySet(msg.xid, status);
                }
                else if (msg.proc == Portmap.PMAPPROC_UNSET)
                {
                    Console.WriteLine("    == PMAPPROC_UNSET ==");
                    Portmap.MAPPING map = ReceiveUnset();
                    Console.WriteLine("      prog    = {0}", map.prog);
                    Console.WriteLine("      vers    = {0}", map.vers);
                    Console.WriteLine("      prot    = {0}", map.prot);
                    Console.WriteLine("");
                    bool status = ServerPortmap.RemovePort(map.prog, map.vers, map.prot);
                    ReplyUnset(msg.xid, status);
                }
                else if (msg.proc == Portmap.PMAPPROC_GETPORT)
                {
                    Console.WriteLine("    == PMAPPROC_GETPORT ==");
                    Portmap.MAPPING map = ReceiveGetPort();
                    Console.WriteLine("      prog    = {0}", map.prog);
                    Console.WriteLine("      vers    = {0}", map.vers);
                    Console.WriteLine("      prot    = {0}", map.prot);
                    Console.WriteLine("");
                    int prog_port = ServerPortmap.FindPort(map.prog, map.vers, map.prot);
                    ReplyGetPort(msg.xid, prog_port);
                }
                else
                {
                    Console.WriteLine("    == clear buffer ==");
                    ClearArgs();
                }
            }
            catch (Exception)
            {
                serverRpcTcp.Close();
            }
        }
        private ServerRpcTcp serverRpcTcp = new ServerRpcTcp();
        private CancellationTokenSource tokenSource = new CancellationTokenSource();
        public void Create(string host, int port)
        {
            serverRpcTcp.Create(host, port);
            ServerPortmap.AddPort(Portmap.PMAP_PROG, Portmap.PMAP_VERS, Portmap.IPPROTO.TCP, port);
        }
        public void Destroy()
        {
            tokenSource.Cancel();
            serverRpcTcp.Destroy();
            ServerPortmap.RemovePort(Portmap.PMAP_PROG, Portmap.PMAP_VERS, Portmap.IPPROTO.TCP);
        }
        public void Run(string host, int port)
        {
            tokenSource.TryReset();

            Console.WriteLine("== Run PortmapServer(TCP, {0}, {1}) ==", host, port);
            Create(host, port);

            Task.Run(() =>
            {
                while (!tokenSource.Token.IsCancellationRequested)
                {
                    TcpThread();
                }
            });
            Thread.Sleep(10);
        }
        public void OneShot(string host, int port, int count)
        {
            tokenSource.TryReset();

            Console.WriteLine("== Run PortmapServer(TCP, {0}, {1}) ==", host, port);
            Create(host, port);

            Task.Run(() =>
            {
                while (0 < count)
                {
                    TcpThread();
                    count--;
                }
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
        public Portmap.MAPPING ReceiveSet()
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(Portmap.MAPPING))];
            serverRpcUdp.GetArgs(buffer);

            Portmap.MAPPING map = new Portmap.MAPPING();
            map.prog = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            map.vers = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            map.prot = (Portmap.IPPROTO)IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            map.port = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            return map;
        }

        public void ReplySet(int xid, bool status)
        {
            Portmap.PMAP_UNSET_REPLY reply = new Portmap.PMAP_UNSET_REPLY();
            reply.xid = IPAddress.HostToNetworkOrder(xid);
            reply.msg_type = IPAddress.HostToNetworkOrder(Rpc.REPLY);
            reply.stat = IPAddress.HostToNetworkOrder(Rpc.MSG_ACCEPTED);
            reply.verf_flavor = IPAddress.HostToNetworkOrder(0);
            reply.verf_len = IPAddress.HostToNetworkOrder(0);
            reply.accept_stat = IPAddress.HostToNetworkOrder(Rpc.SUCCESS);
            reply.boolean = (status == true) ? 1 : 0;

            byte[] packet = new byte[Marshal.SizeOf(typeof(Portmap.PMAP_UNSET_REPLY))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            serverRpcUdp.Reply(packet);
        }
        public Portmap.MAPPING ReceiveUnset()
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(Portmap.MAPPING))];
            serverRpcUdp.GetArgs(buffer);

            Portmap.MAPPING map = new Portmap.MAPPING();
            map.prog = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            map.vers = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            map.prot = (Portmap.IPPROTO)IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            map.port = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            return map;
        }
        public void ReplyUnset(int xid, bool status)
        {
            Portmap.PMAP_UNSET_REPLY reply = new Portmap.PMAP_UNSET_REPLY();
            reply.xid = IPAddress.HostToNetworkOrder(xid);
            reply.msg_type = IPAddress.HostToNetworkOrder(Rpc.REPLY);
            reply.stat = IPAddress.HostToNetworkOrder(Rpc.MSG_ACCEPTED);
            reply.verf_flavor = IPAddress.HostToNetworkOrder(0);
            reply.verf_len = IPAddress.HostToNetworkOrder(0);
            reply.accept_stat = IPAddress.HostToNetworkOrder(Rpc.SUCCESS);
            reply.boolean = (status == true) ? 1 : 0;

            byte[] packet = new byte[Marshal.SizeOf(typeof(Portmap.PMAP_UNSET_REPLY))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            serverRpcUdp.Reply(packet);
        }
        public Portmap.MAPPING ReceiveGetPort()
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(Portmap.MAPPING))];
            serverRpcUdp.GetArgs(buffer);

            Portmap.MAPPING map = new Portmap.MAPPING();
            map.prog = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            map.vers = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            map.prot = (Portmap.IPPROTO)IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            map.port = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            return map;
        }
        public void ReplyGetPort(int xid, int port)
        {
            Portmap.PMAP_GETPORT_REPLY reply = new Portmap.PMAP_GETPORT_REPLY();
            reply.xid = IPAddress.HostToNetworkOrder(xid);
            reply.msg_type = IPAddress.HostToNetworkOrder(Rpc.REPLY);
            reply.stat = IPAddress.HostToNetworkOrder(Rpc.MSG_ACCEPTED);
            reply.verf_flavor = IPAddress.HostToNetworkOrder(0);
            reply.verf_len = IPAddress.HostToNetworkOrder(0);
            reply.accept_stat = IPAddress.HostToNetworkOrder(Rpc.SUCCESS);
            reply.port = IPAddress.HostToNetworkOrder(port);

            byte[] packet = new byte[Marshal.SizeOf(typeof(Portmap.PMAP_GETPORT_REPLY))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            serverRpcUdp.Reply(packet);
        }
        public void ClearArgs()
        {
            serverRpcUdp.ClearArgs();
        }
        public Rpc.RPC_MESSAGE_PARAMS ReceiveMsg()
        {
            return serverRpcUdp.ReceiveMsg();
        }
        public void UdpThread()
        {
            try
            {
                Console.WriteLine("  == Wait RPC ==");
                Rpc.RPC_MESSAGE_PARAMS msg = serverRpcUdp.ReceiveMsg();
                Console.WriteLine("    received Portmap(UDP).");
                Console.WriteLine("      xid     = {0}", msg.xid);
                Console.WriteLine("      type    = {0}", msg.msg_type);
                Console.WriteLine("      prog    = {0}", msg.prog);
                Console.WriteLine("      proc    = {0}", msg.proc);
                Console.WriteLine("      vers    = {0}", msg.vers);
                if (msg.proc == Portmap.PMAPPROC_SET)
                {
                    Console.WriteLine("    == PMAPPROC_SET ==");
                    Portmap.MAPPING map = ReceiveSet();
                    Console.WriteLine("      prog    = {0}", map.prog);
                    Console.WriteLine("      vers    = {0}", map.vers);
                    Console.WriteLine("      prot    = {0}", map.prot);
                    Console.WriteLine("      port    = {0}", map.port);
                    Console.WriteLine("");
                    bool status = ServerPortmap.AddPort(map.prog, map.vers, map.prot, map.port);
                    ReplySet(msg.xid, status);
                }
                else if (msg.proc == Portmap.PMAPPROC_UNSET)
                {
                    Console.WriteLine("    == PMAPPROC_UNSET ==");
                    Portmap.MAPPING map = ReceiveUnset();
                    Console.WriteLine("      prog    = {0}", map.prog);
                    Console.WriteLine("      vers    = {0}", map.vers);
                    Console.WriteLine("      prot    = {0}", map.prot);
                    Console.WriteLine("");
                    bool status = ServerPortmap.RemovePort(map.prog, map.vers, map.prot);
                    ReplyUnset(msg.xid, status);
                }
                else if (msg.proc == Portmap.PMAPPROC_GETPORT)
                {
                    Console.WriteLine("    == PMAPPROC_GETPORT ==");
                    Portmap.MAPPING map = ReceiveGetPort();
                    Console.WriteLine("      prog    = {0}", map.prog);
                    Console.WriteLine("      vers    = {0}", map.vers);
                    Console.WriteLine("      prot    = {0}", map.prot);
                    Console.WriteLine("");
                    int prog_port = ServerPortmap.FindPort(map.prog, map.vers, map.prot);
                    ReplyGetPort(msg.xid, prog_port);
                }
                else
                {
                    Console.WriteLine("    == clear buffer ==");
                    ClearArgs();
                }
            }
            catch (Exception)
            {
                serverRpcUdp.Destroy();
            }
        }
        public void Run(string host, int port)
        {
            tokenSource.TryReset();

            Console.WriteLine("== Run PortmapServer(UDP, {0}, {1}) ==", host, port);
            Create(host, port);

            Task.Run(() =>
            {
                while (!tokenSource.Token.IsCancellationRequested)
                {
                    UdpThread();
                }
            });
            Thread.Sleep(10);
        }
        public void Shutdown()
        {
            tokenSource.Cancel();
        }
        private ServerRpcUdp serverRpcUdp = new ServerRpcUdp();
        private CancellationTokenSource tokenSource = new CancellationTokenSource();

        public void Create(string host, int port)
        {
            serverRpcUdp.Create(host, port);
            ServerPortmap.AddPort(Portmap.PMAP_PROG, Portmap.PMAP_VERS, Portmap.IPPROTO.UDP, port);
        }
        public void Destroy()
        {
            tokenSource.Cancel();
            serverRpcUdp.Destroy();
            ServerPortmap.RemovePort(Portmap.PMAP_PROG, Portmap.PMAP_VERS, Portmap.IPPROTO.UDP);
        }

    }
    public class ServerPortmap
    {
        private static List<Portmap.MAPPING> pmaplist = new List<Portmap.MAPPING>();
        public static bool AddPort(int prog, int vers, Portmap.IPPROTO prot, int port)
        {
            bool ret = false;
            Portmap.MAPPING? find = null;
            for (int i = 0; i < pmaplist.Count; i++)
            {
                Portmap.MAPPING map = pmaplist[i];
                if ((map.prog == prog) && (map.vers == vers) && (map.prot == prot))
                {
                    find = map;
                    break;
                }
            }
            if (find == null)
            {
                Portmap.MAPPING map = new Portmap.MAPPING();
                map.vers = vers;
                map.prog = prog;
                map.prot = prot;
                map.port = port;
                pmaplist.Add(map);
                ret = true;
            }
            return ret;
        }
        public static bool RemovePort(int prog, int vers, Portmap.IPPROTO prot)
        {
            bool ret = false;
            for (int i = 0; i < pmaplist.Count; i++)
            {
                Portmap.MAPPING map = pmaplist[i];
                if ((map.prog == prog) && (map.vers == vers) && (map.prot == prot))
                {
                    pmaplist.Remove(map);
                    ret = true;
                    break;
                }
            }
            return ret;
        }

        public static int FindPort(int prog, int vers, Portmap.IPPROTO prot)
        {
            int port = 0; ;
            for (int i = 0; i < pmaplist.Count; i++)
            {
                Portmap.MAPPING map = pmaplist[i];
                if ((map.prog == prog) && (map.vers == vers) && (map.prot == prot))
                {
                    port = map.port;
                    break;
                }
            }
            return port;
        }
    }
}