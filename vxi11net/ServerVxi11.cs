using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Vxi11Net
{
    public class ServerVxi11
    {
        private ServerRPC rpc = new ServerRPC();
        private int remain_count = 0;
        private CancellationTokenSource tokenSource = new CancellationTokenSource();
        public static Socket create_abort_channel(string host, int port)
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(host);
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint ipEndPoint = new(ipAddress, port);
            Socket server = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(ipEndPoint);
            server.Listen();
            return server;
        }
        public Socket Create(string host, int port)
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(host);
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
        public static Vxi11.CREATE_LINK_PARAMS receive_create_link(Socket so, RPC.RPC_MESSAGE_PARAMS msg, int size, out string handle)
        {
            byte[] buf;
            Vxi11.CREATE_LINK_PARAMS args = receive_create_link(so, msg, size, out buf);
            handle = System.Text.Encoding.ASCII.GetString(buf);
            return args;
        }
        public static Vxi11.CREATE_LINK_PARAMS receive_create_link(Socket so, RPC.RPC_MESSAGE_PARAMS msg, int size, out byte[] handle)
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.CREATE_LINK_PARAMS))];
            int byteCount = so.Receive(buffer, SocketFlags.None);
            Vxi11.CREATE_LINK_PARAMS args = new Vxi11.CREATE_LINK_PARAMS();
            args.clientId = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            args.lockDevice = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            args.lock_timeout = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            args.handle_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            handle = new Byte[args.handle_len];
            byteCount = so.Receive(handle, SocketFlags.None);

            int remain = size - Marshal.SizeOf(typeof(Vxi11.CREATE_LINK_PARAMS)) - args.handle_len;
            if (remain > 0)
            {
                buffer = new Byte[remain];
                byteCount = so.Receive(buffer, SocketFlags.None);
            }
            return args;
        }
        public static void reply_create_link(Socket so, int xid, int lid, int abortPort, int maxRecvSize)
        {
            Vxi11.CREATE_LINK_REPLY reply = new Vxi11.CREATE_LINK_REPLY();
            int size = Marshal.SizeOf(typeof(Vxi11.CREATE_LINK_REPLY));
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

            byte[] packet = new byte[Marshal.SizeOf(typeof(Vxi11.CREATE_LINK_REPLY))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();
        }
        // reply device_write
        public static Vxi11.DEVICE_WRITE_PARAMS receive_device_write(Socket so, RPC.RPC_MESSAGE_PARAMS msg, int size, out string data)
        {
            byte[] buf;
            Vxi11.DEVICE_WRITE_PARAMS args = receive_device_write(so, msg, size, out buf);
            data = System.Text.Encoding.ASCII.GetString(buf);
            return args;
        }
        public static Vxi11.DEVICE_WRITE_PARAMS receive_device_write(Socket so, RPC.RPC_MESSAGE_PARAMS msg, int size, out byte[] data)
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_WRITE_PARAMS))];
            int byteCount = so.Receive(buffer, SocketFlags.None);
            Vxi11.DEVICE_WRITE_PARAMS args = new Vxi11.DEVICE_WRITE_PARAMS();
            args.lid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            args.flags = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            args.lock_timeout = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            args.io_timeout = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            args.data_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            data = new Byte[args.data_len];
            byteCount = so.Receive(data, SocketFlags.None);

            int remain = size - Marshal.SizeOf(typeof(Vxi11.DEVICE_WRITE_PARAMS)) - args.data_len;
            if (remain > 0)
            {
                buffer = new Byte[remain];
                byteCount = so.Receive(buffer, SocketFlags.None);
            }
            return args;
        }
        public static void reply_device_write(Socket so, int xid, int data_len)
        {
            Vxi11.DEVICE_WRITE_REPLY reply = new Vxi11.DEVICE_WRITE_REPLY();
            int size = Marshal.SizeOf(typeof(Vxi11.DEVICE_WRITE_REPLY));
            reply.fheader = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            reply.xid = IPAddress.HostToNetworkOrder(xid);
            reply.msg_type = IPAddress.HostToNetworkOrder(RPC.REPLY);
            reply.stat = IPAddress.HostToNetworkOrder(RPC.MSG_ACCEPTED);
            reply.verf_flavor = IPAddress.HostToNetworkOrder(0);
            reply.verf_len = IPAddress.HostToNetworkOrder(0);
            reply.accept_stat = IPAddress.HostToNetworkOrder(RPC.SUCCESS);
            reply.error = IPAddress.HostToNetworkOrder(RPC.SUCCESS);
            reply.data_len = IPAddress.HostToNetworkOrder(data_len);

            byte[] packet = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_WRITE_REPLY))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();
        }
        // reply device_read
        public static Vxi11.DEVICE_READ_PARAMS receive_device_read(Socket so, RPC.RPC_MESSAGE_PARAMS msg, int size)
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_READ_PARAMS))];
            int byteCount = so.Receive(buffer, SocketFlags.None);
            Vxi11.DEVICE_READ_PARAMS args = new Vxi11.DEVICE_READ_PARAMS();
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
            Vxi11.DEVICE_READ_REPLY reply = new Vxi11.DEVICE_READ_REPLY();
            int size = Marshal.SizeOf(typeof(Vxi11.DEVICE_READ_REPLY)) + data.Length;
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
        public static Vxi11.DEVICE_GENERIC_PARAMS receive_generic_params(Socket so, RPC.RPC_MESSAGE_PARAMS msg, int size)
        {
            byte[] buffer = new byte[size];
            int byteCount = so.Receive(buffer, SocketFlags.None);

            Vxi11.DEVICE_GENERIC_PARAMS args = new Vxi11.DEVICE_GENERIC_PARAMS();
            args.lid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            args.flags = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            args.lock_timeout = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            args.io_timeout = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            return args;
        }
        public static void reply_device_readstb(Socket so, int xid, byte stb)
        {
            Vxi11.DEVICE_READSTB_REPLY reply = new Vxi11.DEVICE_READSTB_REPLY();
            int size = Marshal.SizeOf(typeof(Vxi11.DEVICE_READSTB_REPLY));
            reply.fheader = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            reply.xid = IPAddress.HostToNetworkOrder(xid);
            reply.msg_type = IPAddress.HostToNetworkOrder(RPC.REPLY);
            reply.stat = IPAddress.HostToNetworkOrder(RPC.MSG_ACCEPTED);
            reply.verf_flavor = IPAddress.HostToNetworkOrder(0);
            reply.verf_len = IPAddress.HostToNetworkOrder(0);
            reply.accept_stat = IPAddress.HostToNetworkOrder(RPC.SUCCESS);
            reply.error = IPAddress.HostToNetworkOrder(RPC.SUCCESS);
            reply.stb = stb;

            byte[] packet = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_READSTB_REPLY))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            int byteCount = so.Send(packet);
        }
        // reply device_lock
        public static Vxi11.DEVICE_LOCK_PARAMS receive_device_lock(Socket so, RPC.RPC_MESSAGE_PARAMS msg, int size)
        {
            byte[] buffer = new byte[size];
            int byteCount = so.Receive(buffer, SocketFlags.None);

            Vxi11.DEVICE_LOCK_PARAMS args = new Vxi11.DEVICE_LOCK_PARAMS();
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
        public static Vxi11.CREATE_INTR_CHAN_PARAMS receive_create_intr_chan(Socket so, RPC.RPC_MESSAGE_PARAMS msg, int size)
        {
            byte[] buffer = new byte[size];
            int byteCount = so.Receive(buffer, SocketFlags.None);

            Vxi11.CREATE_INTR_CHAN_PARAMS args = new Vxi11.CREATE_INTR_CHAN_PARAMS();
            args.hostaddr = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            args.hostport = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            args.prognum = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            args.progvers = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            args.progfamily = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            return args;
        }
        // reply device_enable_srq
        public static Vxi11.DEVICE_ENABLE_SRQ_PARAMS receive_device_enable_srq(Socket so, RPC.RPC_MESSAGE_PARAMS msg, int size, out string handle)
        {
            byte[] buf;
            Vxi11.DEVICE_ENABLE_SRQ_PARAMS args = receive_device_enable_srq(so, msg, size, out buf);
            handle = System.Text.Encoding.ASCII.GetString(buf);
            return args;
        }
        public static Vxi11.DEVICE_ENABLE_SRQ_PARAMS receive_device_enable_srq(Socket so, RPC.RPC_MESSAGE_PARAMS msg, int size, out byte[] handle)
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_ENABLE_SRQ_PARAMS))];
            int byteCount = so.Receive(buffer, SocketFlags.None);
            Vxi11.DEVICE_ENABLE_SRQ_PARAMS args = new Vxi11.DEVICE_ENABLE_SRQ_PARAMS();
            args.lid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            args.enable = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            args.handle_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            handle = new Byte[args.handle_len];
            byteCount = so.Receive(handle, SocketFlags.None);

            int remain = size - Marshal.SizeOf(typeof(Vxi11.DEVICE_ENABLE_SRQ_PARAMS)) - args.handle_len;
            if (remain > 0)
            {
                buffer = new Byte[remain];
                byteCount = so.Receive(buffer, SocketFlags.None);
            }
            return args;
        }
        // reply device_docmd
        public static Vxi11.DEVICE_DOCMD_PARAMS receive_device_docmd(Socket so, RPC.RPC_MESSAGE_PARAMS msg, int size, out byte[] data_in)
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_DOCMD_PARAMS))];
            int byteCount = so.Receive(buffer, SocketFlags.None);
            Vxi11.DEVICE_DOCMD_PARAMS args = new Vxi11.DEVICE_DOCMD_PARAMS();
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

            int remain = size - Marshal.SizeOf(typeof(Vxi11.DEVICE_DOCMD_PARAMS)) - args.data_in_len;
            if (remain > 0)
            {
                buffer = new Byte[remain];
                byteCount = so.Receive(buffer, SocketFlags.None);
            }
            return args;
        }
        public static void reply_device_docmd(Socket so, int xid, int data_out_len)
        {
            Vxi11.DEVICE_DOCMD_REPLY reply = new Vxi11.DEVICE_DOCMD_REPLY();
            int size = Marshal.SizeOf(typeof(Vxi11.DEVICE_DOCMD_REPLY));
            reply.fheader = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            reply.xid = IPAddress.HostToNetworkOrder(xid);
            reply.msg_type = IPAddress.HostToNetworkOrder(RPC.REPLY);
            reply.stat = IPAddress.HostToNetworkOrder(RPC.MSG_ACCEPTED);
            reply.verf_flavor = IPAddress.HostToNetworkOrder(0);
            reply.verf_len = IPAddress.HostToNetworkOrder(0);
            reply.accept_stat = IPAddress.HostToNetworkOrder(RPC.SUCCESS);
            reply.error = IPAddress.HostToNetworkOrder(RPC.SUCCESS);
            reply.data_out_len = IPAddress.HostToNetworkOrder(data_out_len);

            byte[] packet = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_DOCMD_REPLY))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();
        }
        // reply destroy_link
        public static void reply_device_error(Socket so, int xid, int error)
        {
            Vxi11.DEVICE_GENERIC_REPLY reply = new Vxi11.DEVICE_GENERIC_REPLY();
            int size = Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_REPLY));
            reply.fheader = IPAddress.HostToNetworkOrder(size - 4 + int.MinValue);
            reply.xid = IPAddress.HostToNetworkOrder(xid);
            reply.msg_type = IPAddress.HostToNetworkOrder(RPC.REPLY);
            reply.stat = IPAddress.HostToNetworkOrder(RPC.MSG_ACCEPTED);
            reply.verf_flavor = IPAddress.HostToNetworkOrder(0);
            reply.verf_len = IPAddress.HostToNetworkOrder(0);
            reply.accept_stat = IPAddress.HostToNetworkOrder(RPC.SUCCESS);
            reply.error = IPAddress.HostToNetworkOrder(error);

            byte[] packet = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_REPLY))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            int byteCount = so.Send(packet);
            gchw.Free();
        }
        public RPC.RPC_MESSAGE_PARAMS ReceiveMsg()
        {
            return rpc.ReceiveMsg();
        }

        public static void Clear()
        {

        }
        public static void Clear(Socket so)
        {

        }

        private Socket? core_server;
        private Socket? core_channel;

        public void RunCoreChannel(string address, int port)
        {
            ServerVxi11 core_server1 = new ServerVxi11();

            Console.WriteLine("== Run demo server ==");
            core_server = core_server1.Create(address, port);
            Console.WriteLine("  listen({0}:{1})...", address, port);
            core_channel = ServerVxi11.accept_connection_requests(core_server);
            Console.WriteLine("  accept()...");

            while (!tokenSource.Token.IsCancellationRequested)
            {
                int size = 0;
                Console.WriteLine("  == Wait RPC ==");
                RPC.RPC_MESSAGE_PARAMS msg = ReceiveMsg();
                Console.WriteLine("    received--.");
                Console.WriteLine("      xid     = {0}", msg.xid);
                Console.WriteLine("      proc    = {0}", msg.proc);
                Console.WriteLine("      size    = {0}", rpc.remain_count());
                if (msg.proc == Vxi11.CREATE_LINK)
                {
                    Console.WriteLine("  == CREATE_LINK ==");
                    string handle;
                    ServerVxi11.receive_create_link(core_channel, msg, size, out handle);
                    ServerVxi11.reply_create_link(core_channel, msg.xid, 123, 456, 789);
                }
                else if (msg.proc == Vxi11.DEVICE_WRITE)
                {
                    Console.WriteLine("  == DEVICE_WRITE ==");
                    string data;
                    Vxi11.DEVICE_WRITE_PARAMS wrt = ServerVxi11.receive_device_write(core_channel, msg, size, out data);
                    ServerVxi11.reply_device_write(core_channel, msg.xid, wrt.data_len);
                }
                else if (msg.proc == Vxi11.DEVICE_READ)
                {
                    Console.WriteLine("  == DEVICE_READ ==");
                    ServerVxi11.receive_device_read(core_channel, msg, size);
                    string data = "XYZCO,246B,S000-0123-02,0";
                    ServerVxi11.reply_device_read(core_channel, msg.xid, 1, data);
                }
                else if (msg.proc == Vxi11.DEVICE_READSTB)
                {
                    Console.WriteLine("  == DEVICE_READSTB ==");
                    Vxi11.DEVICE_GENERIC_PARAMS gen = ServerVxi11.receive_generic_params(core_channel, msg, size);
                    ServerVxi11.reply_device_readstb(core_channel, msg.xid, 8);
                }
                else if (msg.proc == Vxi11.DEVICE_TRIGGER)
                {
                    Console.WriteLine("  == DEVICE_TRIGGER ==");
                    Vxi11.DEVICE_GENERIC_PARAMS gen = ServerVxi11.receive_generic_params(core_channel, msg, size);
                    ServerVxi11.reply_device_error(core_channel, msg.xid, RPC.SUCCESS);
                }
                else if (msg.proc == Vxi11.DEVICE_CLEAR)
                {
                    Console.WriteLine("  == DEVICE_CLEAR ==");
                    Vxi11.DEVICE_GENERIC_PARAMS gen = ServerVxi11.receive_generic_params(core_channel, msg, size);
                    ServerVxi11.reply_device_error(core_channel, msg.xid, RPC.SUCCESS);
                }
                else if (msg.proc == Vxi11.DEVICE_REMOTE)
                {
                    Console.WriteLine("  == DEVICE_REMOTE ==");
                    Vxi11.DEVICE_GENERIC_PARAMS gen = ServerVxi11.receive_generic_params(core_channel, msg, size);
                    ServerVxi11.reply_device_error(core_channel, msg.xid, RPC.SUCCESS);
                }
                else if (msg.proc == Vxi11.DEVICE_LOCAL)
                {
                    Console.WriteLine("  == DEVICE_LOCAL ==");
                    Vxi11.DEVICE_GENERIC_PARAMS gen = ServerVxi11.receive_generic_params(core_channel, msg, size);
                    ServerVxi11.reply_device_error(core_channel, msg.xid, RPC.SUCCESS);
                }
                else if (msg.proc == Vxi11.DEVICE_LOCK)
                {
                    Console.WriteLine("  == DEVICE_LOCK ==");
                    ServerVxi11.receive_device_lock(core_channel, msg, size);
                    ServerVxi11.reply_device_error(core_channel, msg.xid, RPC.SUCCESS);
                }
                else if (msg.proc == Vxi11.DEVICE_UNLOCK)
                {
                    Console.WriteLine("  == DEVICE_UNLOCK ==");
                    int link = ServerVxi11.receive_device_link(core_channel, msg, size);
                    ServerVxi11.reply_device_error(core_channel, msg.xid, RPC.SUCCESS);
                }
                else if (msg.proc == Vxi11.DEVICE_ENABLE_SRQ)
                {
                    Console.WriteLine("  == DEVICE_ENABLE_SRQ ==");
                    string handle;
                    ServerVxi11.receive_device_enable_srq(core_channel, msg, size, out handle);
                    ServerVxi11.reply_device_error(core_channel, msg.xid, RPC.SUCCESS);
                }
                else if (msg.proc == Vxi11.DEVICE_DOCMD)
                {
                    Console.WriteLine("  == DEVICE_DOCMD ==");
                    byte[] data_in;
                    Vxi11.DEVICE_DOCMD_PARAMS dcm = ServerVxi11.receive_device_docmd(core_channel, msg, size, out data_in);
                    ServerVxi11.reply_device_docmd(core_channel, msg.xid, dcm.data_in_len);
                }
                else if (msg.proc == Vxi11.DESTROY_LINK)
                {
                    Console.WriteLine("  == DESTROY_LINK ==");
                    int link = ServerVxi11.receive_device_link(core_channel, msg, size);
                    ServerVxi11.reply_device_error(core_channel, msg.xid, RPC.SUCCESS);
                }
                else if (msg.proc == Vxi11.CREATE_INTR_CHAN)
                {
                    Console.WriteLine("  == CREATE_INTR_CHAN ==");
                    ServerVxi11.receive_create_intr_chan(core_channel, msg, size);
                    ServerVxi11.reply_device_error(core_channel, msg.xid, RPC.SUCCESS);
                }
                else if (msg.proc == Vxi11.DESTROY_INTR_CHAN)
                {
                    Console.WriteLine("  == DESTROY_INTR_CHAN ==");
                    ServerVxi11.reply_device_error(core_channel, msg.xid, RPC.SUCCESS);
                }
                else
                {
                    Console.WriteLine("  == clear buffer ==");
                    rpc.ClearArgs();
                }
            }
        }

        public void Shutdown()
        {
            tokenSource.Cancel();
            if (core_server != null)
            {
                core_server.Close();
            }
            if (core_channel != null)
            {
                core_channel.Close();
            }
        }

        private Socket? abort_server;
        private Socket? abort_channel;
        public void RunAbortChannel(string address, int port)
        {
            tokenSource = new CancellationTokenSource();

            Console.WriteLine("== Run demo server ==");
            abort_server = ServerVxi11.create_abort_channel(address, port);

            Console.WriteLine("  listen({0}:{1})...", address, port);
            abort_channel = ServerVxi11.accept_connection_requests(abort_server);
            Console.WriteLine("  accept()...");

            while (!tokenSource.Token.IsCancellationRequested)
            {
                int size = 0;
                Console.WriteLine("  == Wait RPC ==");
                RPC.RPC_MESSAGE_PARAMS msg = ReceiveMsg();
                Console.WriteLine("    received--.");
                Console.WriteLine("      xid     = {0}", msg.xid);
                Console.WriteLine("      proc    = {0}", msg.proc);
                Console.WriteLine("      size    = {0}", rpc.remain_count());
                if (msg.proc == Vxi11.DEVICE_ABORT)
                {
                    Console.WriteLine("  == DEVICE_ABORT ==");
                    int link = ServerVxi11.receive_device_link(abort_channel, msg, size);
                    ServerVxi11.reply_device_error(abort_channel, msg.xid, RPC.SUCCESS);
                }
                else
                {
                    Console.WriteLine("  == clear buffer ==");
                    rpc.ClearArgs();
                }
            }
        }
    }
}