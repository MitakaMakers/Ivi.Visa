using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Vxi11Net
{
    public class ServerPortmap
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

        private ServerRpc rpc = new ServerRpc();
        private CancellationTokenSource tokenSource = new CancellationTokenSource();

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
            tokenSource.Cancel();
            rpc.Destroy();
            pmaplist.Clear();
        }
        public Rpc.RPC_MESSAGE_PARAMS ReceiveMsg()
        {
            return rpc.ReceiveMsg();
        }

        public void ReceiveNull()
        {
            return;
        }
        public void ReplyNull()
        {
            return;
        }

        public Pmap.MAPPING ReceiveSet()
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(Pmap.MAPPING))];
            rpc.GetArgs(buffer);

            Pmap.MAPPING map = new Pmap.MAPPING();
            map.prog = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            map.vers = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            map.prot = (Pmap.IPPROTO)IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            map.port = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            return map;
        }

        public void ReplySet(bool status)
        {
            Pmap.PMAP_UNSET_REPLY reply = new Pmap.PMAP_UNSET_REPLY();
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
            rpc.Reply(packet, true, true);
        }
        public Pmap.MAPPING ReceiveUnset()
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(Pmap.MAPPING))];
            rpc.GetArgs(buffer);

            Pmap.MAPPING map = new Pmap.MAPPING();
            map.prog = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            map.vers = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            map.prot = (Pmap.IPPROTO)IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            map.port = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            return map;
        }
        public void ReplyUnset(bool status)
        {
            Pmap.PMAP_UNSET_REPLY reply = new Pmap.PMAP_UNSET_REPLY();
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
            rpc.Reply(packet, true, true);
        }
        public Pmap.MAPPING ReceiveGetport()
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(Pmap.MAPPING))];
            rpc.GetArgs(buffer);

            Pmap.MAPPING map = new Pmap.MAPPING();
            map.prog = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            map.vers = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            map.prot = (Pmap.IPPROTO)IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            map.port = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            return map;
        }
        public void ReplyGetport(int port)
        {
            Pmap.PMAP_GETPORT_REPLY reply = new Pmap.PMAP_GETPORT_REPLY();
            reply.msg_type = IPAddress.HostToNetworkOrder(Rpc.REPLY);
            reply.stat = IPAddress.HostToNetworkOrder(Rpc.MSG_ACCEPTED);
            reply.verf_flavor = IPAddress.HostToNetworkOrder(0);
            reply.verf_len = IPAddress.HostToNetworkOrder(0);
            reply.accept_stat = IPAddress.HostToNetworkOrder(Rpc.SUCCESS);
            reply.port = port;

            byte[] packet = new byte[Marshal.SizeOf(typeof(Pmap.PMAP_GETPORT_REPLY))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            rpc.Reply(packet, true, true);
        }
        public void ReceiveDump()
        {
            return;
        }
        public void ReplyDump(List<Pmap.MAPPING> pmaplist)
        {
            Pmap.PMAP_DUMP_REPLY reply = new Pmap.PMAP_DUMP_REPLY();
            reply.msg_type = IPAddress.HostToNetworkOrder(Rpc.REPLY);
            reply.stat = IPAddress.HostToNetworkOrder(Rpc.MSG_ACCEPTED);
            reply.verf_flavor = IPAddress.HostToNetworkOrder(0);
            reply.verf_len = IPAddress.HostToNetworkOrder(0);
            reply.accept_stat = IPAddress.HostToNetworkOrder(Rpc.SUCCESS);

            byte[] packet = new byte[Marshal.SizeOf(typeof(Pmap.MAPPING))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            rpc.Reply(packet, true, true);
            return;
        }
        public void ClearArgs()
        {
            rpc.ClearArgs();
        }
        public void Run(string host, int port, Pmap.IPPROTO type)
        {
            tokenSource.TryReset();

            Console.WriteLine("== Run PortmapServer ==");
            Create(host, port, type);
 
            AddPort(Pmap.PROG, Pmap.VERS, type, port);

            Task.Run(() =>
            {
                while (!tokenSource.Token.IsCancellationRequested)
                {
                    Console.WriteLine("  == Wait RPC ==");
                    Rpc.RPC_MESSAGE_PARAMS msg = rpc.ReceiveMsg();
                    Console.WriteLine("    received--.");
                    Console.WriteLine("      xid     = {0}", msg.xid);
                    Console.WriteLine("      proc    = {0}", msg.proc);
                    Console.WriteLine("      size    = {0}", rpc.remain_count());
                    if (msg.proc == Pmap.PROC_SET)
                    {
                        Console.WriteLine("  == PMAPPROC_SET ==");
                        Pmap.MAPPING map = ReceiveSet();
                        bool status = AddPort(map.prog, map.vers, map.prot, map.port);
                        ReplySet(status);
                    }
                    else if (msg.proc == Pmap.PROC_UNSET)
                    {
                        Console.WriteLine("  == PMAPPROC_UNSET ==");
                        Pmap.MAPPING map = ReceiveUnset();
                        bool status = RemovePort(map.prog, map.vers, map.prot);
                        ReplyUnset(status);
                    }
                    else if (msg.proc == Pmap.PROC_GETPORT)
                    {
                        Console.WriteLine("  == PMAPPROC_GETPORT ==");
                        Pmap.MAPPING map = ReceiveGetport();
                        int prog_port = FindPort(map.prog, map.vers, map.prot);
                        ReplyGetport(prog_port);
                    }
                    else if (msg.proc == Pmap.PROC_DUMP)
                    {
                        Console.WriteLine("  == PMAPPROC_DUMP ==");
                        ReplyDump(pmaplist);
                    }
                    else
                    {
                        Console.WriteLine("  == clear buffer ==");
                        rpc.ClearArgs();
                    }
                }
            });
        }

        public void Shutdown()
        {
            tokenSource.Cancel();
        }
    }
}