using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Vxi11Net
{
    public class ServerVxi11
    {
        private ServerRpc rpc = new ServerRpc();
        private CancellationTokenSource tokenSource = new CancellationTokenSource();

        public void Create(string host, int port)
        {
            rpc.CreateTcp(host, port);
        }
        public Rpc.RPC_MESSAGE_PARAMS ReceiveMsg()
        {
            return rpc.ReceiveMsg();
        }

        // reply create_link
        public Vxi11.CREATE_LINK_PARAMS ReceiveCreateLink(out string handle)
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.CREATE_LINK_PARAMS))];
            int byteCount = rpc.GetArgs(buffer);

            Vxi11.CREATE_LINK_PARAMS args = new Vxi11.CREATE_LINK_PARAMS();
            args.clientId = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            args.lockDevice = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            args.lock_timeout = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            args.handle_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));

            buffer = new Byte[args.handle_len];
            byteCount = rpc.GetArgs(buffer);
            handle = System.Text.Encoding.ASCII.GetString(buffer);

            rpc.ClearArgs();
            return args;
        }
        public void ReplyCreateLink(int lid, int abortPort, int maxRecvSize)
        {
            Vxi11.CREATE_LINK_REPLY reply = new Vxi11.CREATE_LINK_REPLY();
            int size = Marshal.SizeOf(typeof(Vxi11.CREATE_LINK_REPLY));
            reply.msg_type = IPAddress.HostToNetworkOrder(Rpc.REPLY);
            reply.stat = IPAddress.HostToNetworkOrder(Rpc.MSG_ACCEPTED);
            reply.verf_flavor = IPAddress.HostToNetworkOrder(0);
            reply.verf_len = IPAddress.HostToNetworkOrder(0);
            reply.accept_stat = IPAddress.HostToNetworkOrder(Rpc.SUCCESS);
            reply.error = IPAddress.HostToNetworkOrder(Rpc.SUCCESS);
            reply.lid = IPAddress.HostToNetworkOrder(lid);
            reply.abortPort = IPAddress.HostToNetworkOrder(abortPort);
            reply.maxRecvSize = IPAddress.HostToNetworkOrder(maxRecvSize);

            byte[] packet = new byte[Marshal.SizeOf(typeof(Vxi11.CREATE_LINK_REPLY))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            rpc.Reply(packet, true, true);
        }
        // reply device_write
        public Vxi11.DEVICE_WRITE_PARAMS ReceiveDeviceWrite(out string data)
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_WRITE_PARAMS))];
            int byteCount = rpc.GetArgs(buffer);

            Vxi11.DEVICE_WRITE_PARAMS args = new Vxi11.DEVICE_WRITE_PARAMS();
            args.lid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            args.flags = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            args.lock_timeout = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            args.io_timeout = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            args.data_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));

            buffer = new Byte[args.data_len];
            byteCount = rpc.GetArgs(buffer);
            data = System.Text.Encoding.ASCII.GetString(buffer);

            rpc.ClearArgs();
            return args;
        }
        public void ReplyDeviceWrite(int data_len)
        {
            Vxi11.DEVICE_WRITE_REPLY reply = new Vxi11.DEVICE_WRITE_REPLY();
            reply.msg_type = IPAddress.HostToNetworkOrder(Rpc.REPLY);
            reply.stat = IPAddress.HostToNetworkOrder(Rpc.MSG_ACCEPTED);
            reply.verf_flavor = IPAddress.HostToNetworkOrder(0);
            reply.verf_len = IPAddress.HostToNetworkOrder(0);
            reply.accept_stat = IPAddress.HostToNetworkOrder(Rpc.SUCCESS);
            reply.error = IPAddress.HostToNetworkOrder(Rpc.SUCCESS);
            reply.data_len = IPAddress.HostToNetworkOrder(data_len);

            byte[] packet = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_WRITE_REPLY))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            rpc.Reply(packet, true, true);
        }
        // reply device_read
        public Vxi11.DEVICE_READ_PARAMS ReceiveDeviceRead()
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_READ_PARAMS))];
            int byteCount = rpc.GetArgs(buffer);

            Vxi11.DEVICE_READ_PARAMS args = new Vxi11.DEVICE_READ_PARAMS();
            args.lid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            args.requestSize = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            args.io_timeout = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            args.lock_timeout = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            args.flags = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            args.termChar = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 20));
            return args;
        }
        public void ReplyDeviceRead(int reason, string data)
        {
            byte[] buf = System.Text.Encoding.ASCII.GetBytes(data);

            Vxi11.DEVICE_READ_REPLY reply = new Vxi11.DEVICE_READ_REPLY();
            reply.msg_type = IPAddress.HostToNetworkOrder(Rpc.REPLY);
            reply.stat = IPAddress.HostToNetworkOrder(Rpc.MSG_ACCEPTED);
            reply.verf_flavor = IPAddress.HostToNetworkOrder(0);
            reply.verf_len = IPAddress.HostToNetworkOrder(0);
            reply.accept_stat = IPAddress.HostToNetworkOrder(Rpc.SUCCESS);
            reply.error = IPAddress.HostToNetworkOrder(Rpc.SUCCESS);
            reply.reason = IPAddress.HostToNetworkOrder(reason);
            reply.data_len = IPAddress.HostToNetworkOrder(buf.Length);

            int size = Marshal.SizeOf(typeof(Vxi11.DEVICE_READ_REPLY)) + buf.Length;
            size = ((size / 4) + 1) * 4;
            byte[] packet = new byte[size];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            Buffer.BlockCopy(buf, 0, packet, Marshal.SizeOf(typeof(Vxi11.DEVICE_READ_REPLY)), buf.Length);
            gchw.Free();
            rpc.Reply(packet, true, true);
        }
        // reply device_readstb
        // reply device_trigger
        // reply device_clear
        // reply device_remote
        // reply device_local
        // reply device_abort
        public Vxi11.DEVICE_GENERIC_PARAMS ReceiveGenericParams()
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_PARAMS))];
            int byteCount = rpc.GetArgs(buffer);

            Vxi11.DEVICE_GENERIC_PARAMS args = new Vxi11.DEVICE_GENERIC_PARAMS();
            args.lid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            args.flags = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            args.lock_timeout = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            args.io_timeout = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            return args;
        }
        public void ReplyDeviceReadStb(byte stb)
        {
            Vxi11.DEVICE_READSTB_REPLY reply = new Vxi11.DEVICE_READSTB_REPLY();
            reply.msg_type = IPAddress.HostToNetworkOrder(Rpc.REPLY);
            reply.stat = IPAddress.HostToNetworkOrder(Rpc.MSG_ACCEPTED);
            reply.verf_flavor = IPAddress.HostToNetworkOrder(0);
            reply.verf_len = IPAddress.HostToNetworkOrder(0);
            reply.accept_stat = IPAddress.HostToNetworkOrder(Rpc.SUCCESS);
            reply.error = IPAddress.HostToNetworkOrder(Rpc.SUCCESS);
            reply.stb = stb;

            byte[] packet = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_READSTB_REPLY))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            rpc.Reply(packet, true, true);
        }
        // reply device_lock
        public Vxi11.DEVICE_LOCK_PARAMS ReceiveDeviceLock()
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_LOCK_PARAMS))];
            int byteCount = rpc.GetArgs(buffer);

            Vxi11.DEVICE_LOCK_PARAMS args = new Vxi11.DEVICE_LOCK_PARAMS();
            args.lid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            args.flags = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            args.lock_timeout = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            return args;
        }
        // reply device_unlock
        // reply create_intr_chan
        public Vxi11.CREATE_INTR_CHAN_PARAMS ReceiveCreateIntrchan()
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.CREATE_INTR_CHAN_PARAMS))];
            int byteCount = rpc.GetArgs(buffer);

            Vxi11.CREATE_INTR_CHAN_PARAMS args = new Vxi11.CREATE_INTR_CHAN_PARAMS();
            args.hostaddr = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            args.hostport = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            args.prognum = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));
            args.progvers = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 12));
            args.progfamily = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 16));
            return args;
        }
        // reply device_enable_srq
        public Vxi11.DEVICE_ENABLE_SRQ_PARAMS ReceiveDeviceEnableSrq(out string handle)
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_ENABLE_SRQ_PARAMS))];
            int byteCount = rpc.GetArgs(buffer);
            Vxi11.DEVICE_ENABLE_SRQ_PARAMS args = new Vxi11.DEVICE_ENABLE_SRQ_PARAMS();
            args.lid = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            args.enable = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 4));
            args.handle_len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 8));

            buffer = new Byte[args.handle_len];
            byteCount = rpc.GetArgs(buffer);
            handle = System.Text.Encoding.ASCII.GetString(buffer);

            rpc.ClearArgs();
            return args;
        }
        // reply device_docmd
        public Vxi11.DEVICE_DOCMD_PARAMS ReceiveDeviceDoCmd(out byte[] data_in)
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_DOCMD_PARAMS))];
            int byteCount = rpc.GetArgs(buffer);

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
            byteCount = rpc.GetArgs(data_in);

            rpc.ClearArgs();
            return args;
        }
        public void ReplyDeviceDoCmd(int data_out_len)
        {
            Vxi11.DEVICE_DOCMD_REPLY reply = new Vxi11.DEVICE_DOCMD_REPLY();
            reply.msg_type = IPAddress.HostToNetworkOrder(Rpc.REPLY);
            reply.stat = IPAddress.HostToNetworkOrder(Rpc.MSG_ACCEPTED);
            reply.verf_flavor = IPAddress.HostToNetworkOrder(0);
            reply.verf_len = IPAddress.HostToNetworkOrder(0);
            reply.accept_stat = IPAddress.HostToNetworkOrder(Rpc.SUCCESS);
            reply.error = IPAddress.HostToNetworkOrder(Rpc.SUCCESS);
            reply.data_out_len = IPAddress.HostToNetworkOrder(data_out_len);

            byte[] packet = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_DOCMD_REPLY))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            rpc.Reply(packet, true, true);
            gchw.Free();
        }
        // reply destroy_link
        public long ReceiveDeviceLink()
        {
            byte[] buffer = new byte[4];
            int byteCount = rpc.GetArgs(buffer);

            long Device_Link = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
            return Device_Link;
        }

        public void ReplyDeviceError(int error)
        {
            Vxi11.DEVICE_GENERIC_REPLY reply = new Vxi11.DEVICE_GENERIC_REPLY();
            reply.msg_type = IPAddress.HostToNetworkOrder(Rpc.REPLY);
            reply.stat = IPAddress.HostToNetworkOrder(Rpc.MSG_ACCEPTED);
            reply.verf_flavor = IPAddress.HostToNetworkOrder(0);
            reply.verf_len = IPAddress.HostToNetworkOrder(0);
            reply.accept_stat = IPAddress.HostToNetworkOrder(Rpc.SUCCESS);
            reply.error = IPAddress.HostToNetworkOrder(error);

            byte[] packet = new byte[Marshal.SizeOf(typeof(Vxi11.DEVICE_GENERIC_REPLY))];
            GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
            Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
            gchw.Free();
            rpc.Reply(packet, true, true);
        }
        public void Flush()
        {
            rpc.Flush();
        }

        public void RunCoreChannel(string host, int port)
        {
            tokenSource.TryReset();

            Console.WriteLine("== Run demo server ==");
            Create(host, port);
            ServerPortmap.AddPort(Vxi11.DEVICE_ABORT_PROG, Vxi11.DEVICE_ABORT_VERSION, Pmap.IPPROTO.TCP, port);

            Console.WriteLine("  listen({0}:{1})...", host, port);

            Task.Run(() =>
            {
                while (!tokenSource.Token.IsCancellationRequested)
                {
                    Console.WriteLine("  == Wait RPC ==");
                    Rpc.RPC_MESSAGE_PARAMS msg = ReceiveMsg();
                    Console.WriteLine("    received--.");
                    Console.WriteLine("      xid     = {0}", msg.xid);
                    Console.WriteLine("      prog    = {0}", msg.prog);
                    Console.WriteLine("      proc    = {0}", msg.proc);
                    Console.WriteLine("      vers    = {0}", msg.vers);
                    if (msg.proc == Vxi11.CREATE_LINK)
                    {
                        Console.WriteLine("  == CREATE_LINK ==");
                        string handle;
                        Vxi11.CREATE_LINK_PARAMS crt = ReceiveCreateLink(out handle);
                        ReplyCreateLink(123, 456, 789);
                    }
                    else if (msg.proc == Vxi11.DEVICE_WRITE)
                    {
                        Console.WriteLine("  == DEVICE_WRITE ==");
                        string data;
                        Vxi11.DEVICE_WRITE_PARAMS wrt = ReceiveDeviceWrite(out data);
                        ReplyDeviceWrite(wrt.data_len);
                    }
                    else if (msg.proc == Vxi11.DEVICE_READ)
                    {
                        Console.WriteLine("  == DEVICE_READ ==");
                        Vxi11.DEVICE_READ_PARAMS drd = ReceiveDeviceRead();
                        string data = "XYZCO,246B,S000-0123-02,0";
                        ReplyDeviceRead(1, data);
                    }
                    else if (msg.proc == Vxi11.DEVICE_READSTB)
                    {
                        Console.WriteLine("  == DEVICE_READSTB ==");
                        Vxi11.DEVICE_GENERIC_PARAMS gen = ReceiveGenericParams();
                        ReplyDeviceReadStb(8);
                    }
                    else if (msg.proc == Vxi11.DEVICE_TRIGGER)
                    {
                        Console.WriteLine("  == DEVICE_TRIGGER ==");
                        Vxi11.DEVICE_GENERIC_PARAMS gen = ReceiveGenericParams();
                        ReplyDeviceError(Rpc.SUCCESS);
                    }
                    else if (msg.proc == Vxi11.DEVICE_CLEAR)
                    {
                        Console.WriteLine("  == DEVICE_CLEAR ==");
                        Vxi11.DEVICE_GENERIC_PARAMS gen = ReceiveGenericParams();
                        ReplyDeviceError(Rpc.SUCCESS);
                    }
                    else if (msg.proc == Vxi11.DEVICE_REMOTE)
                    {
                        Console.WriteLine("  == DEVICE_REMOTE ==");
                        Vxi11.DEVICE_GENERIC_PARAMS gen = ReceiveGenericParams();
                        ReplyDeviceError(Rpc.SUCCESS);
                    }
                    else if (msg.proc == Vxi11.DEVICE_LOCAL)
                    {
                        Console.WriteLine("  == DEVICE_LOCAL ==");
                        Vxi11.DEVICE_GENERIC_PARAMS gen = ReceiveGenericParams();
                        ReplyDeviceError(Rpc.SUCCESS);
                    }
                    else if (msg.proc == Vxi11.DEVICE_LOCK)
                    {
                        Console.WriteLine("  == DEVICE_LOCK ==");
                        Vxi11.DEVICE_LOCK_PARAMS loc = ReceiveDeviceLock();
                        ReplyDeviceError(Rpc.SUCCESS);
                    }
                    else if (msg.proc == Vxi11.DEVICE_UNLOCK)
                    {
                        Console.WriteLine("  == DEVICE_UNLOCK ==");
                        long dlink = ReceiveDeviceLink();
                        ReplyDeviceError(Rpc.SUCCESS);
                    }
                    else if (msg.proc == Vxi11.DEVICE_ENABLE_SRQ)
                    {
                        Console.WriteLine("  == DEVICE_ENABLE_SRQ ==");
                        string handle;
                        ReceiveDeviceEnableSrq(out handle);
                        ReplyDeviceError(Rpc.SUCCESS);
                    }
                    else if (msg.proc == Vxi11.DEVICE_DOCMD)
                    {
                        Console.WriteLine("  == DEVICE_DOCMD ==");
                        byte[] data_in;
                        Vxi11.DEVICE_DOCMD_PARAMS dcm = ReceiveDeviceDoCmd(out data_in);
                        ReplyDeviceDoCmd(dcm.data_in_len);
                    }
                    else if (msg.proc == Vxi11.DESTROY_LINK)
                    {
                        Console.WriteLine("  == DESTROY_LINK ==");
                        long dlink = ReceiveDeviceLink();
                        ReplyDeviceError(Rpc.SUCCESS);
                    }
                    else if (msg.proc == Vxi11.CREATE_INTR_CHAN)
                    {
                        Console.WriteLine("  == CREATE_INTR_CHAN ==");
                        ReceiveCreateIntrchan();
                        ReplyDeviceError(Rpc.SUCCESS);
                    }
                    else if (msg.proc == Vxi11.DESTROY_INTR_CHAN)
                    {
                        Console.WriteLine("  == DESTROY_INTR_CHAN ==");
                        ReplyDeviceError(Rpc.SUCCESS);
                    }
                    else
                    {
                        Console.WriteLine("  == clear buffer ==");
                        rpc.ClearArgs();
                    }
                }
            });
        }
        public void RunAbortChannel(string host, int port)
        {
            tokenSource.TryReset();

            Console.WriteLine("== Run demo server ==");
            Create(host, port);
            ServerPortmap.AddPort(Vxi11.DEVICE_ABORT_PROG, Vxi11.DEVICE_ABORT_VERSION, Pmap.IPPROTO.TCP, port);

            Console.WriteLine("  listen({0}:{1})...", host, port);

            Task.Run(() =>
            {
                while (!tokenSource.Token.IsCancellationRequested)
                {
                    Console.WriteLine("  == Wait RPC ==");
                    Rpc.RPC_MESSAGE_PARAMS msg = ReceiveMsg();
                    Console.WriteLine("    received--.");
                    Console.WriteLine("      xid     = {0}", msg.xid);
                    Console.WriteLine("      proc    = {0}", msg.proc);
                    if (msg.proc == Vxi11.DEVICE_ABORT)
                    {
                        Console.WriteLine("  == DEVICE_ABORT ==");
                        long dlink = ReceiveDeviceLink();
                        ReplyDeviceError(Rpc.SUCCESS);
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
            rpc.Destroy();
        }
    }
}