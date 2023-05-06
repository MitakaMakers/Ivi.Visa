using System.Net;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using static VXI11Net.PortmapHandler;

namespace VXI11Net
{
    public class RPC
    {
        public const int CALL = 0;
        public const int REPLY = 1;
        public const int MSG_ACCEPTED = 0;
        public const int SUCCESS = 0;
        public const int PORT = 111;
        public const int VERSION = 2;

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct RPC_MESSAGE_PARAMS
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
        public static RPC_MESSAGE_PARAMS receive_message(Socket so, out int size)
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(RPC.RPC_MESSAGE_PARAMS))];
            if (so.ProtocolType == ProtocolType.Tcp)
            {
                int byteCount = so.Receive(buffer, SocketFlags.None);
            }
            else if (so.ProtocolType == ProtocolType.Udp)
            {
                IPEndPoint sender = new IPEndPoint(IPAddress.IPv6Any, 0);
                EndPoint senderRemote = (EndPoint)sender;
                byte[] tmp = new byte[1024];
                int byteCount = so.ReceiveFrom(tmp, ref senderRemote);
                Buffer.BlockCopy(tmp, 0, buffer, 0, Marshal.SizeOf(typeof(RPC.RPC_MESSAGE_PARAMS)));
            }

            RPC.RPC_MESSAGE_PARAMS msg = new RPC.RPC_MESSAGE_PARAMS();
            msg.fheader = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            msg.xid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            msg.msg_type = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            msg.rpcvers = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            msg.prog = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            msg.vers = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            msg.proc = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            msg.cred_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));
            msg.cred_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 32));
            msg.verf_flavor = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 36));
            msg.verf_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 40));

            size = msg.fheader - Marshal.SizeOf(typeof(RPC.RPC_MESSAGE_PARAMS)) + 4;
            if (size <= -1)
            {
                size = size + int.MaxValue + 1;
            }
            return msg;
        }
        public static void clear_buffer(Socket so)
        {
            byte[] buffer = new byte[1000];
            int byteCount = 1;
            int timeout = so.ReceiveTimeout;
            so.ReceiveTimeout = 1;
            try
            {
                while (1 <= byteCount)
                {
                    if (so.ProtocolType == ProtocolType.Tcp)
                    {
                        byteCount = so.Receive(buffer, SocketFlags.None);
                    }
                    else if (so.ProtocolType == ProtocolType.Udp)
                    {
                        IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
                        EndPoint senderRemote = (EndPoint)sender;
                        byteCount = so.ReceiveFrom(buffer, SocketFlags.None, ref senderRemote);
                    }

                }
            }
            catch (Exception e) { Console.WriteLine(e); }
            so.ReceiveTimeout = timeout;
        }
    }

    public class PortmapHandler
    {
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
        public struct PMAP_NULL_REPLY
        {
            public int fheader;
            public int xid;
            public int msg_type;
            public int stat;
            public int verf_flavor;
            public int verf_len;
            public int accept_stat;
        };
        public struct PMAP_SETUNSET_REPLY
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

        public static Socket create_tcp_channel(string address, int port)
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(address);
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint ipEndPoint = new(ipAddress, port);
            Socket server = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(ipEndPoint);
            server.Listen();
            return server;
        }
        public static Socket create_udp_channel(string address, int port)
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(address);
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint ipEndPoint = new(ipAddress, port);
            Socket server = new Socket(ipEndPoint.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
            server.Bind(ipEndPoint);
            return server;
        }

        public static Socket accept_connection_requests(Socket server)
        {
            Socket socket = server.Accept();
            socket.NoDelay = true;
            return socket;
        }
        public static MAPPING receive_pmapproc_null(Socket so, RPC.RPC_MESSAGE_PARAMS msg, int size)
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(MAPPING))];
            int byteCount = 0;
            if (so.ProtocolType == ProtocolType.Tcp)
            {
                byteCount = so.Receive(buffer, SocketFlags.None);
            }
            else if (so.ProtocolType == ProtocolType.Udp)
            {
                IPEndPoint sender = new IPEndPoint(IPAddress.IPv6Any, 0);
                EndPoint senderRemote = (EndPoint)sender;
                byte[] tmp = new byte[1024];
                byteCount = so.ReceiveFrom(tmp, ref senderRemote);
                Buffer.BlockCopy(tmp, 0, buffer, 0, Marshal.SizeOf(typeof(MAPPING)));
            }
            MAPPING map = new MAPPING();
            map.prog = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            map.vers = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            map.prot = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            map.port = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));

            int remain = size - Marshal.SizeOf(typeof(MAPPING));
            if (remain > 0)
            {
                buffer = new Byte[remain];
                byteCount = so.Receive(buffer, SocketFlags.None);
            }
            return map;
        }
        public static void reply_pmapproc_null(Socket so, int xid, bool status)
        {
            PMAP_SETUNSET_REPLY reply = new PMAP_SETUNSET_REPLY();
            int size = Marshal.SizeOf(typeof(PMAP_SETUNSET_REPLY));
            reply.fheader = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            reply.xid = IPAddress.HostToNetworkOrder(xid);
            reply.msg_type = IPAddress.HostToNetworkOrder(RPC.REPLY);
            reply.stat = IPAddress.HostToNetworkOrder(RPC.MSG_ACCEPTED);
            reply.verf_flavor = IPAddress.HostToNetworkOrder(0);
            reply.verf_len = IPAddress.HostToNetworkOrder(0);
            reply.accept_stat = IPAddress.HostToNetworkOrder(RPC.SUCCESS);
            reply.boolean = (status == true) ? 1 : 0;

            byte[] packet = new byte[Marshal.SizeOf(typeof(PMAP_SETUNSET_REPLY))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            int byteCount = so.Send(packet);
        }

        public static MAPPING receive_pmapproc_set(Socket so, RPC.RPC_MESSAGE_PARAMS msg, int size)
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(MAPPING))];
            int byteCount = 0;
            if (so.ProtocolType == ProtocolType.Tcp)
            {
                byteCount = so.Receive(buffer, SocketFlags.None);
            }
            else if (so.ProtocolType == ProtocolType.Udp)
            {
                IPEndPoint sender = new IPEndPoint(IPAddress.IPv6Any, 0);
                EndPoint senderRemote = (EndPoint)sender;
                byte[] tmp = new byte[1024];
                byteCount = so.ReceiveFrom(tmp, ref senderRemote);
                Buffer.BlockCopy(tmp, 0, buffer, 0, Marshal.SizeOf(typeof(MAPPING)));
            }
            MAPPING map = new MAPPING();
            map.prog = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            map.vers = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            map.prot = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            map.port = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            return map;
        }

        public static bool pmapproc_set(int prog, int vers, int prot, int port, List<MAPPING> pmaplist)
        {
            bool ret = false;
            MAPPING? find = null;
            for (int i = 0; i < pmaplist.Count; i++)
            {
                MAPPING map = pmaplist[i];
                if ((map.prog == prog) && (map.vers == vers) && (map.prot == prot))
                {
                    find = map;
                    break;
                }
            }
            if (find == null)
            {
                MAPPING map = new MAPPING();
                map.prog = prog;
                map.vers = vers;
                map.prog = prot;
                map.port = port;
                pmaplist.Add(map);
                ret = true;
            }
            return ret;
        }

        public static void reply_pmapproc_set(Socket so, int xid, bool status)
        {
            PMAP_SETUNSET_REPLY reply = new PMAP_SETUNSET_REPLY();
            int size = Marshal.SizeOf(typeof(PMAP_SETUNSET_REPLY));
            reply.fheader = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            reply.xid = IPAddress.HostToNetworkOrder(xid);
            reply.msg_type = IPAddress.HostToNetworkOrder(RPC.REPLY);
            reply.stat = IPAddress.HostToNetworkOrder(RPC.MSG_ACCEPTED);
            reply.verf_flavor = IPAddress.HostToNetworkOrder(0);
            reply.verf_len = IPAddress.HostToNetworkOrder(0);
            reply.accept_stat = IPAddress.HostToNetworkOrder(RPC.SUCCESS);
            reply.boolean = (status == true) ? 1 : 0;

            byte[] packet = new byte[Marshal.SizeOf(typeof(PMAP_SETUNSET_REPLY))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            int byteCount = so.Send(packet);
        }
        public static MAPPING receive_pmapproc_unset(Socket so, RPC.RPC_MESSAGE_PARAMS msg, int size)
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(MAPPING))];
            int byteCount = 0;
            if (so.ProtocolType == ProtocolType.Tcp)
            {
                byteCount = so.Receive(buffer, SocketFlags.None);
            }
            else if (so.ProtocolType == ProtocolType.Udp)
            {
                IPEndPoint sender = new IPEndPoint(IPAddress.IPv6Any, 0);
                EndPoint senderRemote = (EndPoint)sender;
                byte[] tmp = new byte[1024];
                byteCount = so.ReceiveFrom(tmp, ref senderRemote);
                Buffer.BlockCopy(tmp, 0, buffer, 0, Marshal.SizeOf(typeof(MAPPING)));
            }
            MAPPING map = new MAPPING();
            map.prog = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            map.vers = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            map.prot = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            map.port = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            return map;
        }
        public static bool pmapproc_unset(int prog, int vers, int prot, List<MAPPING> pmaplist)
        {
            bool ret = false;
            for (int i = 0; i < pmaplist.Count; i++)
            {
                MAPPING map = pmaplist[i];
                if ((map.prog == prog) && (map.vers == vers) && (map.prot == prot))
                {
                    pmaplist.Remove(map);
                    ret = true;
                    break;
                }
            }
            return ret;
        }

        public static void reply_pmapproc_unset(Socket so, int xid, bool status)
        {
            PMAP_SETUNSET_REPLY reply = new PMAP_SETUNSET_REPLY();
            int size = Marshal.SizeOf(typeof(PMAP_SETUNSET_REPLY));
            reply.fheader = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            reply.xid = IPAddress.HostToNetworkOrder(xid);
            reply.msg_type = IPAddress.HostToNetworkOrder(RPC.REPLY);
            reply.stat = IPAddress.HostToNetworkOrder(RPC.MSG_ACCEPTED);
            reply.verf_flavor = IPAddress.HostToNetworkOrder(0);
            reply.verf_len = IPAddress.HostToNetworkOrder(0);
            reply.accept_stat = IPAddress.HostToNetworkOrder(RPC.SUCCESS);
            reply.boolean = (status == true) ? 1 : 0;

            byte[] packet = new byte[Marshal.SizeOf(typeof(PMAP_SETUNSET_REPLY))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            int byteCount = so.Send(packet);
        }
        public static MAPPING receive_pmapproc_getport(Socket so, RPC.RPC_MESSAGE_PARAMS msg, int size)
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(MAPPING))];
            int byteCount = 0;
            if (so.ProtocolType == ProtocolType.Tcp)
            {
                byteCount = so.Receive(buffer, SocketFlags.None);
            }
            else if (so.ProtocolType == ProtocolType.Udp)
            {
                IPEndPoint sender = new IPEndPoint(IPAddress.IPv6Any, 0);
                EndPoint senderRemote = (EndPoint)sender;
                byte[] tmp = new byte[1024];
                byteCount = so.ReceiveFrom(tmp, ref senderRemote);
                Buffer.BlockCopy(tmp, 0, buffer, 0, Marshal.SizeOf(typeof(MAPPING)));
            }
            MAPPING map = new MAPPING();
            map.prog = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            map.vers = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            map.prot = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            map.port = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            return map;
        }
        public static int pmapproc_getport(int prog, int vers, int prot, List<MAPPING> pmaplist)
        {
            int port = 0; ;
            for (int i = 0; i < pmaplist.Count; i++)
            {
                MAPPING map = pmaplist[i];
                if ((map.prog == prog) && (map.vers == vers) && (map.prot == prot))
                {
                    port = map.port;
                    break;
                }
            }
            return port;
        }
        public static void reply_pmapproc_getport(Socket so, int xid, int port)
        {
            PMAP_GETPORT_REPLY reply = new PMAP_GETPORT_REPLY();
            int size = Marshal.SizeOf(typeof(PMAP_GETPORT_REPLY));
            reply.fheader = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            reply.xid = IPAddress.HostToNetworkOrder(xid);
            reply.msg_type = IPAddress.HostToNetworkOrder(RPC.REPLY);
            reply.stat = IPAddress.HostToNetworkOrder(RPC.MSG_ACCEPTED);
            reply.verf_flavor = IPAddress.HostToNetworkOrder(0);
            reply.verf_len = IPAddress.HostToNetworkOrder(0);
            reply.accept_stat = IPAddress.HostToNetworkOrder(RPC.SUCCESS);
            reply.port = port;

            byte[] packet = new byte[Marshal.SizeOf(typeof(PMAP_GETPORT_REPLY))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            int byteCount = so.Send(packet);
            return;
        }
        public static void receive_pmapproc_dump(Socket so, RPC.RPC_MESSAGE_PARAMS msg, int size)
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(MAPPING))];
            int byteCount = 0;
            if (so.ProtocolType == ProtocolType.Tcp)
            {
                byteCount = so.Receive(buffer, SocketFlags.None);
            }
            else if (so.ProtocolType == ProtocolType.Udp)
            {
                IPEndPoint sender = new IPEndPoint(IPAddress.IPv6Any, 0);
                EndPoint senderRemote = (EndPoint)sender;
                byte[] tmp = new byte[1024];
                byteCount = so.ReceiveFrom(tmp, ref senderRemote);
                Buffer.BlockCopy(tmp, 0, buffer, 0, Marshal.SizeOf(typeof(MAPPING)));
            }
            MAPPING map = new MAPPING();
            map.prog = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            map.vers = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            map.prot = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            map.port = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));

            int remain = size - Marshal.SizeOf(typeof(MAPPING));
            if (remain > 0)
            {
                buffer = new Byte[remain];
                byteCount = so.Receive(buffer, SocketFlags.None);
            }
        }
        public static void reply_pmapproc_dump(Socket so, int xid, List<MAPPING> pmaplist)
        {
            PMAP_DUMP_REPLY reply = new PMAP_DUMP_REPLY();
            int size = Marshal.SizeOf(typeof(PMAP_DUMP_REPLY)) + pmaplist.Count * Marshal.SizeOf(typeof(MAPPING));
            reply.fheader = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            reply.xid = IPAddress.HostToNetworkOrder(xid);
            reply.msg_type = IPAddress.HostToNetworkOrder(RPC.REPLY);
            reply.stat = IPAddress.HostToNetworkOrder(RPC.MSG_ACCEPTED);
            reply.verf_flavor = IPAddress.HostToNetworkOrder(0);
            reply.verf_len = IPAddress.HostToNetworkOrder(0);
            reply.accept_stat = IPAddress.HostToNetworkOrder(RPC.SUCCESS);

            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            int byteCount = so.Send(packet);
            return;
        }
    }

    public class TcpPortmapServer
    {
        private CancellationTokenSource tokenSource = new CancellationTokenSource();
        private Socket? server;
        private Socket? core_channel;
        private List<MAPPING> pmaplist = new List<MAPPING>();

        public void Run(string address, int port)
        {
            tokenSource = new CancellationTokenSource();

            Console.WriteLine("== Run TcpPortmapServer ==");
            IPHostEntry ipHostInfo = Dns.GetHostEntry(address);
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint ipEndPoint = new(ipAddress, port);
            server = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(ipEndPoint);
            server.Listen();
            Console.WriteLine("  listen({0}:{1})...", address, port);

            pmaplist = new List<MAPPING>();
            Set(PortmapHandler.PMAP_PROG, PortmapHandler.PMAP_VERS, PortmapHandler.IPPROTO_TCP, PortmapHandler.PMAP_PORT);
            Set(PortmapHandler.PMAP_PROG, PortmapHandler.PMAP_VERS, PortmapHandler.IPPROTO_UDP, PortmapHandler.PMAP_PORT);
            Set(Vxi11ServerHandler.DEVICE_CORE_PROG, Vxi11ServerHandler.DEVICE_CORE_VERSION, PortmapHandler.IPPROTO_TCP, port);
            Set(Vxi11ServerHandler.DEVICE_CORE_PROG, Vxi11ServerHandler.DEVICE_CORE_VERSION, PortmapHandler.IPPROTO_UDP, port);

            Task.Run(() =>
            {
                while (!tokenSource.Token.IsCancellationRequested)
                {
                    core_channel = server.Accept();
                    core_channel.NoDelay = true;
                    Console.WriteLine("  accept()...");

                    while (!tokenSource.Token.IsCancellationRequested)
                    {
                        int size;
                        Console.WriteLine("  == Wait RPC ==");
                        RPC.RPC_MESSAGE_PARAMS msg = RPC.receive_message(core_channel, out size);
                        Console.WriteLine("    received--.");
                        Console.WriteLine("      xid     = {0}", msg.xid);
                        Console.WriteLine("      proc    = {0}", msg.proc);
                        Console.WriteLine("      size    = {0}", size);
                        if (msg.proc == PortmapHandler.PMAPPROC_SET)
                        {
                            Console.WriteLine("  == PMAPPROC_SET ==");
                            PortmapHandler.MAPPING map = PortmapHandler.receive_pmapproc_set(core_channel, msg, size);
                            bool status = PortmapHandler.pmapproc_set(map.prog, map.vers, map.prot, map.port, pmaplist);
                            PortmapHandler.reply_pmapproc_set(core_channel, msg.xid, status);
                        }
                        else if (msg.proc == PortmapHandler.PMAPPROC_UNSET)
                        {
                            Console.WriteLine("  == PMAPPROC_UNSET ==");
                            MAPPING map = PortmapHandler.receive_pmapproc_unset(core_channel, msg, size);
                            bool status = PortmapHandler.pmapproc_unset(map.prog, map.vers, map.prot, pmaplist);
                            PortmapHandler.reply_pmapproc_unset(core_channel, msg.xid, status);
                        }
                        else if (msg.proc == PortmapHandler.PMAPPROC_GETPORT)
                        {
                            Console.WriteLine("  == PMAPPROC_GETPORT ==");
                            PortmapHandler.MAPPING map = PortmapHandler.receive_pmapproc_getport(core_channel, msg, size);
                            int prog_port = PortmapHandler.pmapproc_getport(map.prog, map.vers, map.prot, pmaplist);
                            PortmapHandler.reply_pmapproc_getport(core_channel, msg.xid, prog_port);
                        }
                        else if (msg.proc == PortmapHandler.PMAPPROC_DUMP)
                        {
                            Console.WriteLine("  == PMAPPROC_DUMP ==");
                            PortmapHandler.reply_pmapproc_dump(core_channel, msg.xid, pmaplist);
                        }
                        else
                        {
                            Console.WriteLine("  == clear buffer ==");
                            RPC.clear_buffer(core_channel);
                        }
                    }
                }
            });
        }

        public void Shutdown()
        {
            tokenSource.Cancel();
            if (server != null)
            {
                server.Close();
            }
            if (core_channel != null)
            {
                core_channel.Close();
            }
        }
        public bool Set(int prog, int vers, int prot, int port)
        {
            return PortmapHandler.pmapproc_set(prog, vers, prot, port, pmaplist);
        }

        public bool Unset(int prog, int vers, int prot)
        {
            return PortmapHandler.pmapproc_unset(prog, vers, prot, pmaplist);
        }
    }
    public class UdpPortmapServer
    {
        private CancellationTokenSource tokenSource = new CancellationTokenSource();
        private Socket? server;
        private List<MAPPING> pmaplist = new List<MAPPING>();
        public void Run(string address, int port)
        {
            tokenSource = new CancellationTokenSource();

            Console.WriteLine("== Run UdpPortmapServer ==");
            IPHostEntry ipHostInfo = Dns.GetHostEntry(address);
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint ipEndPoint = new(ipAddress, port);
            server = new Socket(ipEndPoint.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
            server.Bind(ipEndPoint);

            pmaplist = new List<MAPPING>();
            Set(PortmapHandler.PMAP_PROG, PortmapHandler.PMAP_VERS, PortmapHandler.IPPROTO_TCP, PortmapHandler.PMAP_PORT);
            Set(PortmapHandler.PMAP_PROG, PortmapHandler.PMAP_VERS, PortmapHandler.IPPROTO_UDP, PortmapHandler.PMAP_PORT);
            Set(Vxi11ServerHandler.DEVICE_CORE_PROG, Vxi11ServerHandler.DEVICE_CORE_VERSION, PortmapHandler.IPPROTO_TCP, port);
            Set(Vxi11ServerHandler.DEVICE_CORE_PROG, Vxi11ServerHandler.DEVICE_CORE_VERSION, PortmapHandler.IPPROTO_UDP, port);

            Task.Run(() =>
            {
                while (!tokenSource.Token.IsCancellationRequested)
                {
                    while (!tokenSource.Token.IsCancellationRequested)
                    {
                        int size;
                        Console.WriteLine("  == Wait RPC ==");
                        RPC.RPC_MESSAGE_PARAMS msg = RPC.receive_message(server, out size);
                        Console.WriteLine("    received--.");
                        Console.WriteLine("      xid     = {0}", msg.xid);
                        Console.WriteLine("      proc    = {0}", msg.proc);
                        Console.WriteLine("      size    = {0}", size);
                        if (msg.proc == PortmapHandler.PMAPPROC_SET)
                        {
                            Console.WriteLine("  == PMAPPROC_SET ==");
                            MAPPING map = receive_pmapproc_set(server, msg, size);
                            bool status = pmapproc_set(map.prog, map.vers, map.prot, map.port, pmaplist);
                            reply_pmapproc_set(server, msg.xid, status);
                        }
                        else if (msg.proc == PortmapHandler.PMAPPROC_UNSET)
                        {
                            Console.WriteLine("  == PMAPPROC_UNSET ==");
                            MAPPING map = receive_pmapproc_unset(server, msg, size);
                            bool status = pmapproc_unset(map.prog, map.vers, map.prot, pmaplist);
                            reply_pmapproc_unset(server, msg.xid, status);
                        }
                        else if (msg.proc == PortmapHandler.PMAPPROC_GETPORT)
                        {
                            Console.WriteLine("  == PMAPPROC_GETPORT ==");
                            MAPPING map = receive_pmapproc_getport(server, msg, size);
                            int prog_port = pmapproc_getport(map.prog, map.vers, map.prot, pmaplist);
                            reply_pmapproc_getport(server, msg.xid, prog_port);
                        }
                        else if (msg.proc == PortmapHandler.PMAPPROC_DUMP)
                        {
                            Console.WriteLine("  == PMAPPROC_DUMP ==");
                            reply_pmapproc_dump(server, msg.xid, pmaplist);
                        }
                        else
                        {
                            Console.WriteLine("  == clear buffer ==");
                            RPC.clear_buffer(server);
                        }
                    }
                }
            });
        }
        public void Shutdown()
        {
            tokenSource.Cancel();
            if (server != null)
            {
                server.Close();
            }
        }
        public bool Set(int prog, int vers, int prot, int port)
        {
            return PortmapHandler.pmapproc_set(prog, vers, prot, port, pmaplist);
        }

        public bool Unset(int prog, int vers, int prot)
        {
            return PortmapHandler.pmapproc_unset(prog, vers, prot, pmaplist);
        }
    }
    public class Vxi11ServerHandler
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

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct CREATE_LINK_PARAMS
        {
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
        public struct DEVICE_GENERIC_PARAMS
        {
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
        public struct DEVICE_LOCK_PARAMS
        {
            public int lid;
            public int flags;
            public int lock_timeout;
        };
        public struct CREATE_INTR_CHAN_PARAMS
        {
            public int hostaddr;
            public int hostport;
            public int prognum;
            public int progvers;
            public int progfamily;
        };
        public struct DEVICE_ENABLE_SRQ_PARAMS
        {
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
            public byte stb;
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

        public static Socket create_abort_channel(string address, int port)
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(address);
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint ipEndPoint = new(ipAddress, port);
            Socket server = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(ipEndPoint);
            server.Listen();
            return server;
        }
        public static Socket create_core_channel(string address, int port)
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(address);
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint ipEndPoint = new(ipAddress, port);
            Socket server = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(ipEndPoint);
            server.Listen();
            return server;
        }

        public static Socket accept_connection_requests(Socket server)
        {
            Socket socket = server.Accept();
            socket.NoDelay = true;
            return socket;
        }
        // reply create_link
        public static CREATE_LINK_PARAMS receive_create_link(Socket so, RPC.RPC_MESSAGE_PARAMS msg, int size, out string handle)
        {
            byte[] buf;
            CREATE_LINK_PARAMS args = receive_create_link(so, msg, size, out buf);
            handle = System.Text.Encoding.ASCII.GetString(buf);
            return args;
        }
        public static CREATE_LINK_PARAMS receive_create_link(Socket so, RPC.RPC_MESSAGE_PARAMS msg, int size, out byte[] handle)
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(CREATE_LINK_PARAMS))];
            int byteCount = so.Receive(buffer, SocketFlags.None);
            CREATE_LINK_PARAMS args = new CREATE_LINK_PARAMS();
            args.clientId = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            args.lockDevice = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            args.lock_timeout = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            args.handle_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            handle = new Byte[args.handle_len];
            byteCount = so.Receive(handle, SocketFlags.None);

            int remain = size - Marshal.SizeOf(typeof(CREATE_LINK_PARAMS)) - args.handle_len;
            if (remain > 0)
            {
                buffer = new Byte[remain];
                byteCount = so.Receive(buffer, SocketFlags.None);
            }
            return args;
        }
        public static void reply_create_link(Socket so, int xid, int lid, int abortPort, int maxRecvSize)
        {
            CREATE_LINK_REPLY reply = new CREATE_LINK_REPLY();
            int size = Marshal.SizeOf(typeof(CREATE_LINK_REPLY));
            reply.fheader = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            reply.xid = IPAddress.HostToNetworkOrder(xid);
            reply.msg_type = IPAddress.HostToNetworkOrder(RPC.REPLY);
            reply.stat = IPAddress.HostToNetworkOrder(RPC.MSG_ACCEPTED);
            reply.verf_flavor = IPAddress.HostToNetworkOrder(0);
            reply.verf_len = IPAddress.HostToNetworkOrder(0);
            reply.accept_stat = IPAddress.HostToNetworkOrder(RPC.SUCCESS);
            reply.error = IPAddress.HostToNetworkOrder(RPC.SUCCESS);
            reply.lid = IPAddress.HostToNetworkOrder(lid);
            reply.abortPort = IPAddress.HostToNetworkOrder(abortPort);
            reply.maxRecvSize = IPAddress.HostToNetworkOrder(maxRecvSize);

            byte[] packet = new byte[Marshal.SizeOf(typeof(CREATE_LINK_REPLY))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();
        }
        // reply device_write
        public static DEVICE_WRITE_PARAMS receive_device_write(Socket so, RPC.RPC_MESSAGE_PARAMS msg, int size, out string data)
        {
            byte[] buf;
            DEVICE_WRITE_PARAMS args = receive_device_write(so, msg, size, out buf);
            data = System.Text.Encoding.ASCII.GetString(buf);
            return args;
        }
        public static DEVICE_WRITE_PARAMS receive_device_write(Socket so, RPC.RPC_MESSAGE_PARAMS msg, int size, out byte[] data)
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(DEVICE_WRITE_PARAMS))];
            int byteCount = so.Receive(buffer, SocketFlags.None);
            DEVICE_WRITE_PARAMS args = new DEVICE_WRITE_PARAMS();
            args.lid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            args.flags = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            args.lock_timeout = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            args.io_timeout = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            args.data_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            data = new Byte[args.data_len];
            byteCount = so.Receive(data, SocketFlags.None);

            int remain = size - Marshal.SizeOf(typeof(DEVICE_WRITE_PARAMS)) - args.data_len;
            if (remain > 0)
            {
                buffer = new Byte[remain];
                byteCount = so.Receive(buffer, SocketFlags.None);
            }
            return args;
        }
        public static void reply_device_write(Socket so, int xid, int data_len)
        {
            DEVICE_WRITE_REPLY reply = new DEVICE_WRITE_REPLY();
            int size = Marshal.SizeOf(typeof(DEVICE_WRITE_REPLY));
            reply.fheader = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            reply.xid = IPAddress.HostToNetworkOrder(xid);
            reply.msg_type = IPAddress.HostToNetworkOrder(RPC.REPLY);
            reply.stat = IPAddress.HostToNetworkOrder(RPC.MSG_ACCEPTED);
            reply.verf_flavor = IPAddress.HostToNetworkOrder(0);
            reply.verf_len = IPAddress.HostToNetworkOrder(0);
            reply.accept_stat = IPAddress.HostToNetworkOrder(RPC.SUCCESS);
            reply.error = IPAddress.HostToNetworkOrder(RPC.SUCCESS);
            reply.data_len = IPAddress.HostToNetworkOrder(data_len);

            byte[] packet = new byte[Marshal.SizeOf(typeof(DEVICE_WRITE_REPLY))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();
        }
        // reply device_read
        public static DEVICE_READ_PARAMS receive_device_read(Socket so, RPC.RPC_MESSAGE_PARAMS msg, int size)
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(DEVICE_READ_PARAMS))];
            int byteCount = so.Receive(buffer, SocketFlags.None);
            DEVICE_READ_PARAMS args = new DEVICE_READ_PARAMS();
            args.lid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            args.requestSize = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            args.io_timeout = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            args.lock_timeout = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            args.flags = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            args.termChar = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            return args;
        }
        public static void reply_device_read(Socket so, int xid, int reason, string data)
        {
            byte[] buf = System.Text.Encoding.ASCII.GetBytes(data);
            reply_device_read(so, xid, reason, buf);
        }
        public static void reply_device_read(Socket so, int xid, int reason, byte[] data)
        {
            DEVICE_READ_REPLY reply = new DEVICE_READ_REPLY();
            int size = Marshal.SizeOf(typeof(DEVICE_READ_REPLY)) + data.Length;
            size = ((size / 4) + 1) * 4;
            reply.fheader = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            reply.xid = IPAddress.HostToNetworkOrder(xid);
            reply.msg_type = IPAddress.HostToNetworkOrder(RPC.REPLY);
            reply.stat = IPAddress.HostToNetworkOrder(RPC.MSG_ACCEPTED);
            reply.verf_flavor = IPAddress.HostToNetworkOrder(0);
            reply.verf_len = IPAddress.HostToNetworkOrder(0);
            reply.accept_stat = IPAddress.HostToNetworkOrder(RPC.SUCCESS);
            reply.error = IPAddress.HostToNetworkOrder(RPC.SUCCESS);
            reply.reason = IPAddress.HostToNetworkOrder(reason);
            reply.data_len = IPAddress.HostToNetworkOrder(data.Length);

            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(data, 0, packet, 40, data.Length);
            gchw.Free();
            int byteCount = so.Send(packet);
        }
        // reply device_readstb
        // reply device_trigger
        // reply device_clear
        // reply device_remote
        // reply device_local
        // reply device_abort
        public static DEVICE_GENERIC_PARAMS receive_generic_params(Socket so, RPC.RPC_MESSAGE_PARAMS msg, int size)
        {
            byte[] buffer = new byte[size];
            int byteCount = so.Receive(buffer, SocketFlags.None);

            DEVICE_GENERIC_PARAMS args = new DEVICE_GENERIC_PARAMS();
            args.lid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            args.flags = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            args.lock_timeout = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            args.io_timeout = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            return args;
        }
        public static void reply_device_readstb(Socket so, int xid, byte stb)
        {
            DEVICE_READSTB_REPLY reply = new DEVICE_READSTB_REPLY();
            int size = Marshal.SizeOf(typeof(DEVICE_READSTB_REPLY));
            reply.fheader = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            reply.xid = IPAddress.HostToNetworkOrder(xid);
            reply.msg_type = IPAddress.HostToNetworkOrder(RPC.REPLY);
            reply.stat = IPAddress.HostToNetworkOrder(RPC.MSG_ACCEPTED);
            reply.verf_flavor = IPAddress.HostToNetworkOrder(0);
            reply.verf_len = IPAddress.HostToNetworkOrder(0);
            reply.accept_stat = IPAddress.HostToNetworkOrder(RPC.SUCCESS);
            reply.error = IPAddress.HostToNetworkOrder(RPC.SUCCESS);
            reply.stb = stb;

            byte[] packet = new byte[Marshal.SizeOf(typeof(DEVICE_READSTB_REPLY))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            int byteCount = so.Send(packet);
        }
        // reply device_lock
        public static DEVICE_LOCK_PARAMS receive_device_lock(Socket so, RPC.RPC_MESSAGE_PARAMS msg, int size)
        {
            byte[] buffer = new byte[size];
            int byteCount = so.Receive(buffer, SocketFlags.None);

            DEVICE_LOCK_PARAMS args = new DEVICE_LOCK_PARAMS();
            args.lid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            args.flags = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            args.lock_timeout = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            return args;
        }
        // reply device_unlock
        public static int receive_device_link(Socket so, RPC.RPC_MESSAGE_PARAMS msg, int size)
        {
            byte[] buffer = new byte[size];
            int byteCount = so.Receive(buffer, SocketFlags.None);
            int lid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            return lid;
        }
        // reply create_intr_chan
        public static CREATE_INTR_CHAN_PARAMS receive_create_intr_chan(Socket so, RPC.RPC_MESSAGE_PARAMS msg, int size)
        {
            byte[] buffer = new byte[size];
            int byteCount = so.Receive(buffer, SocketFlags.None);

            CREATE_INTR_CHAN_PARAMS args = new CREATE_INTR_CHAN_PARAMS();
            args.hostaddr = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            args.hostport = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            args.prognum = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            args.progvers = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            args.progfamily = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            return args;
        }
        // reply device_enable_srq
        public static DEVICE_ENABLE_SRQ_PARAMS receive_device_enable_srq(Socket so, RPC.RPC_MESSAGE_PARAMS msg, int size, out string handle)
        {
            byte[] buf;
            DEVICE_ENABLE_SRQ_PARAMS args = receive_device_enable_srq(so, msg, size, out buf);
            handle = System.Text.Encoding.ASCII.GetString(buf);
            return args;
        }
        public static DEVICE_ENABLE_SRQ_PARAMS receive_device_enable_srq(Socket so, RPC.RPC_MESSAGE_PARAMS msg, int size, out byte[] handle)
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(DEVICE_ENABLE_SRQ_PARAMS))];
            int byteCount = so.Receive(buffer, SocketFlags.None);
            DEVICE_ENABLE_SRQ_PARAMS args = new DEVICE_ENABLE_SRQ_PARAMS();
            args.lid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            args.enable = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            args.handle_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            handle = new Byte[args.handle_len];
            byteCount = so.Receive(handle, SocketFlags.None);

            int remain = size - Marshal.SizeOf(typeof(DEVICE_ENABLE_SRQ_PARAMS)) - args.handle_len;
            if (remain > 0)
            {
                buffer = new Byte[remain];
                byteCount = so.Receive(buffer, SocketFlags.None);
            }
            return args;
        }
        // reply device_docmd
        public static DEVICE_DOCMD_PARAMS receive_device_docmd(Socket so, RPC.RPC_MESSAGE_PARAMS msg, int size, out byte[] data_in)
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(DEVICE_DOCMD_PARAMS))];
            int byteCount = so.Receive(buffer, SocketFlags.None);
            DEVICE_DOCMD_PARAMS args = new DEVICE_DOCMD_PARAMS();
            args.lid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            args.flags = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            args.lock_timeout = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            args.io_timeout = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            args.cmd = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            args.network_order = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            args.datasize = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 24));
            args.data_in_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 28));
            data_in = new Byte[args.data_in_len];
            byteCount = so.Receive(data_in, SocketFlags.None);

            int remain = size - Marshal.SizeOf(typeof(DEVICE_DOCMD_PARAMS)) - args.data_in_len;
            if (remain > 0)
            {
                buffer = new Byte[remain];
                byteCount = so.Receive(buffer, SocketFlags.None);
            }
            return args;
        }
        public static void reply_device_docmd(Socket so, int xid, int data_out_len)
        {
            DEVICE_DOCMD_REPLY reply = new DEVICE_DOCMD_REPLY();
            int size = Marshal.SizeOf(typeof(DEVICE_DOCMD_REPLY));
            reply.fheader = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            reply.xid = IPAddress.HostToNetworkOrder(xid);
            reply.msg_type = IPAddress.HostToNetworkOrder(RPC.REPLY);
            reply.stat = IPAddress.HostToNetworkOrder(RPC.MSG_ACCEPTED);
            reply.verf_flavor = IPAddress.HostToNetworkOrder(0);
            reply.verf_len = IPAddress.HostToNetworkOrder(0);
            reply.accept_stat = IPAddress.HostToNetworkOrder(RPC.SUCCESS);
            reply.error = IPAddress.HostToNetworkOrder(RPC.SUCCESS);
            reply.data_out_len = IPAddress.HostToNetworkOrder(data_out_len);

            byte[] packet = new byte[Marshal.SizeOf(typeof(DEVICE_DOCMD_REPLY))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();
        }
        // reply destroy_link
        public static void reply_device_error(Socket so, int xid, int error)
        {
            DEVICE_GENERIC_REPLY reply = new DEVICE_GENERIC_REPLY();
            int size = Marshal.SizeOf(typeof(DEVICE_GENERIC_REPLY));
            reply.fheader = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            reply.xid = IPAddress.HostToNetworkOrder(xid);
            reply.msg_type = IPAddress.HostToNetworkOrder(RPC.REPLY);
            reply.stat = IPAddress.HostToNetworkOrder(RPC.MSG_ACCEPTED);
            reply.verf_flavor = IPAddress.HostToNetworkOrder(0);
            reply.verf_len = IPAddress.HostToNetworkOrder(0);
            reply.accept_stat = IPAddress.HostToNetworkOrder(RPC.SUCCESS);
            reply.error = IPAddress.HostToNetworkOrder(error);

            byte[] packet = new byte[Marshal.SizeOf(typeof(DEVICE_GENERIC_REPLY))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();
        }
    }
    public class CoreServer
    {
        private bool IsRunning;
        private Socket? core_server;
        private Socket? core_channel;
        public void Run(string address, int port)
        {
            Console.WriteLine("== Run demo server ==");
            core_server = Vxi11ServerHandler.create_core_channel(address, port);
            Console.WriteLine("  listen({0}:{1})...", address, port);
            core_channel = Vxi11ServerHandler.accept_connection_requests(core_server);
            Console.WriteLine("  accept()...");

            IsRunning = true;
            while (IsRunning)
            {
                int size;
                Console.WriteLine("  == Wait RPC ==");
                RPC.RPC_MESSAGE_PARAMS msg = RPC.receive_message(core_channel, out size);
                Console.WriteLine("    received--.");
                Console.WriteLine("      xid     = {0}", msg.xid);
                Console.WriteLine("      proc    = {0}", msg.proc);
                Console.WriteLine("      size    = {0}", size);
                if (msg.proc == Vxi11ServerHandler.CREATE_LINK)
                {
                    Console.WriteLine("  == CREATE_LINK ==");
                    string handle;
                    Vxi11ServerHandler.receive_create_link(core_channel, msg, size, out handle);
                    Vxi11ServerHandler.reply_create_link(core_channel, msg.xid, 123, 456, 789);
                }
                else if (msg.proc == Vxi11ServerHandler.DEVICE_WRITE)
                {
                    Console.WriteLine("  == DEVICE_WRITE ==");
                    string data;
                    Vxi11ServerHandler.DEVICE_WRITE_PARAMS wrt = Vxi11ServerHandler.receive_device_write(core_channel, msg, size, out data);
                    Vxi11ServerHandler.reply_device_write(core_channel, msg.xid, wrt.data_len);
                }
                else if (msg.proc == Vxi11ServerHandler.DEVICE_READ)
                {
                    Console.WriteLine("  == DEVICE_READ ==");
                    Vxi11ServerHandler.receive_device_read(core_channel, msg, size);
                    string data = "XYZCO,246B,S000-0123-02,0";
                    Vxi11ServerHandler.reply_device_read(core_channel, msg.xid, 1, data);
                }
                else if (msg.proc == Vxi11ServerHandler.DEVICE_READSTB)
                {
                    Console.WriteLine("  == DEVICE_READSTB ==");
                    Vxi11ServerHandler.DEVICE_GENERIC_PARAMS gen = Vxi11ServerHandler.receive_generic_params(core_channel, msg, size);
                    Vxi11ServerHandler.reply_device_readstb(core_channel, msg.xid, 8);
                }
                else if (msg.proc == Vxi11ServerHandler.DEVICE_TRIGGER)
                {
                    Console.WriteLine("  == DEVICE_TRIGGER ==");
                    Vxi11ServerHandler.DEVICE_GENERIC_PARAMS gen = Vxi11ServerHandler.receive_generic_params(core_channel, msg, size);
                    Vxi11ServerHandler.reply_device_error(core_channel, msg.xid, RPC.SUCCESS);
                }
                else if (msg.proc == Vxi11ServerHandler.DEVICE_CLEAR)
                {
                    Console.WriteLine("  == DEVICE_CLEAR ==");
                    Vxi11ServerHandler.DEVICE_GENERIC_PARAMS gen = Vxi11ServerHandler.receive_generic_params(core_channel, msg, size);
                    Vxi11ServerHandler.reply_device_error(core_channel, msg.xid, RPC.SUCCESS);
                }
                else if (msg.proc == Vxi11ServerHandler.DEVICE_REMOTE)
                {
                    Console.WriteLine("  == DEVICE_REMOTE ==");
                    Vxi11ServerHandler.DEVICE_GENERIC_PARAMS gen = Vxi11ServerHandler.receive_generic_params(core_channel, msg, size);
                    Vxi11ServerHandler.reply_device_error(core_channel, msg.xid, RPC.SUCCESS);
                }
                else if (msg.proc == Vxi11ServerHandler.DEVICE_LOCAL)
                {
                    Console.WriteLine("  == DEVICE_LOCAL ==");
                    Vxi11ServerHandler.DEVICE_GENERIC_PARAMS gen = Vxi11ServerHandler.receive_generic_params(core_channel, msg, size);
                    Vxi11ServerHandler.reply_device_error(core_channel, msg.xid, RPC.SUCCESS);
                }
                else if (msg.proc == Vxi11ServerHandler.DEVICE_LOCK)
                {
                    Console.WriteLine("  == DEVICE_LOCK ==");
                    Vxi11ServerHandler.receive_device_lock(core_channel, msg, size);
                    Vxi11ServerHandler.reply_device_error(core_channel, msg.xid, RPC.SUCCESS);
                }
                else if (msg.proc == Vxi11ServerHandler.DEVICE_UNLOCK)
                {
                    Console.WriteLine("  == DEVICE_UNLOCK ==");
                    int link = Vxi11ServerHandler.receive_device_link(core_channel, msg, size);
                    Vxi11ServerHandler.reply_device_error(core_channel, msg.xid, RPC.SUCCESS);
                }
                else if (msg.proc == Vxi11ServerHandler.DEVICE_ENABLE_SRQ)
                {
                    Console.WriteLine("  == DEVICE_ENABLE_SRQ ==");
                    string handle;
                    Vxi11ServerHandler.receive_device_enable_srq(core_channel, msg, size, out handle);
                    Vxi11ServerHandler.reply_device_error(core_channel, msg.xid, RPC.SUCCESS);
                }
                else if (msg.proc == Vxi11ServerHandler.DEVICE_DOCMD)
                {
                    Console.WriteLine("  == DEVICE_DOCMD ==");
                    byte[] data_in;
                    Vxi11ServerHandler.DEVICE_DOCMD_PARAMS dcm = Vxi11ServerHandler.receive_device_docmd(core_channel, msg, size, out data_in);
                    Vxi11ServerHandler.reply_device_docmd(core_channel, msg.xid, dcm.data_in_len);
                }
                else if (msg.proc == Vxi11ServerHandler.DESTROY_LINK)
                {
                    Console.WriteLine("  == DESTROY_LINK ==");
                    int link = Vxi11ServerHandler.receive_device_link(core_channel, msg, size);
                    Vxi11ServerHandler.reply_device_error(core_channel, msg.xid, RPC.SUCCESS);
                }
                else if (msg.proc == Vxi11ServerHandler.CREATE_INTR_CHAN)
                {
                    Console.WriteLine("  == CREATE_INTR_CHAN ==");
                    Vxi11ServerHandler.receive_create_intr_chan(core_channel, msg, size);
                    Vxi11ServerHandler.reply_device_error(core_channel, msg.xid, RPC.SUCCESS);
                }
                else if (msg.proc == Vxi11ServerHandler.DESTROY_INTR_CHAN)
                {
                    Console.WriteLine("  == DESTROY_INTR_CHAN ==");
                    Vxi11ServerHandler.reply_device_error(core_channel, msg.xid, RPC.SUCCESS);
                }
                else
                {
                    Console.WriteLine("  == clear buffer ==");
                    RPC.clear_buffer(core_channel);
                }
            }
        }

        public void Shutdown()
        {
            IsRunning = false;
            if (core_server != null)
            {
                core_server.Close();
            }
            if (core_channel != null)
            {
                core_channel.Close();
            }
        }
    }
    public class AbortServer
    {
        private CancellationTokenSource tokenSource = new CancellationTokenSource();
        private Socket? abort_server;
        private Socket? abort_channel;
        public void Run(string address, int port)
        {
            tokenSource = new CancellationTokenSource();

            Console.WriteLine("== Run demo server ==");
            abort_server = Vxi11ServerHandler.create_abort_channel(address, port);

            Console.WriteLine("  listen({0}:{1})...", address, port);
            abort_channel = Vxi11ServerHandler.accept_connection_requests(abort_server);
            Console.WriteLine("  accept()...");

            while (!tokenSource.Token.IsCancellationRequested)
            {
                int size;
                Console.WriteLine("  == Wait RPC ==");
                RPC.RPC_MESSAGE_PARAMS msg = RPC.receive_message(abort_channel, out size);
                Console.WriteLine("    received--.");
                Console.WriteLine("      xid     = {0}", msg.xid);
                Console.WriteLine("      proc    = {0}", msg.proc);
                Console.WriteLine("      size    = {0}", size);
                if (msg.proc == Vxi11ServerHandler.DEVICE_ABORT)
                {
                    Console.WriteLine("  == DEVICE_ABORT ==");
                    int link = Vxi11ServerHandler.receive_device_link(abort_channel, msg, size);
                    Vxi11ServerHandler.reply_device_error(abort_channel, msg.xid, RPC.SUCCESS);
                }
                else
                {
                    Console.WriteLine("  == clear buffer ==");
                    RPC.clear_buffer(abort_channel);
                }
            }
        }

        public void Shutdown()
        {
            tokenSource.Cancel();
            if (abort_server != null)
            {
                abort_server.Close();
            }
            if (abort_channel != null)
            {
                abort_channel.Close();
            }
        }
    }
}