using System.Net.Sockets;

namespace Vxi11Net
{
    public class ServerProgram
    {
        public static void Main(string[] args)
        {
            bool isLoop = true;
            while (isLoop)
            {
                Console.WriteLine("Select Test target");
                Console.WriteLine("   1:Test VXI-11 server");
                Console.WriteLine("   2:Test Portmap server");
                Console.WriteLine(" E/Q:exit program");
                Console.WriteLine("");
                Console.Write("Input fuction number? : ");
                string a = new String(Console.ReadLine());
                if (a == "1")
                {
                    ServerConsole();
                }
                else if (a == "2")
                {
                    PortmapConsole();
                }
                else if ((a == "Q") || (a == "q") || (a == "E") || (a == "e"))
                {
                    Console.WriteLine("== Exit program ==");
                    Environment.Exit(0);
                }
            }
        }
        public static void ServerConsole()
        {
            bool isLoop = true;
            ServerVxi11 core_server1 = new ServerVxi11();
            ServerVxi11 abort_server2 = new ServerVxi11();

            Socket? abort_server = null;
            Socket? core_server = null;
            Socket? core_channel = null;

            while (isLoop)
            {
                Console.WriteLine("Select VXI-11 server Function");
                Console.WriteLine("   1:create RPC server (abort channel)");
                Console.WriteLine("   2:create RPC server (core channel)");
                Console.WriteLine("   3:register core channel with portmapper");
                Console.WriteLine("   4:be ready to accept connection requests");
                Console.WriteLine("   5:receive core message");
                Console.WriteLine("   6:reply to create_link");
                Console.WriteLine("   7:reply to device_write");
                Console.WriteLine("   8:reply to device_read");
                Console.WriteLine("   9:reply to device_readstb");
                Console.WriteLine("  10:reply to device_trigger");
                Console.WriteLine("  11:reply to device_clear");
                Console.WriteLine("  12:reply to device_remote");
                Console.WriteLine("  13:reply to device_local");
                Console.WriteLine("  14:reply to device_lock");
                Console.WriteLine("  15:reply to device_unlock");
                Console.WriteLine("  16:reply to device_enable_srq");
                Console.WriteLine("  17:reply to device_docmd");
                Console.WriteLine("  18:reply to destroy_link");
                Console.WriteLine("  19:reply to create_intr_chan");
                Console.WriteLine("  20:reply to destroy_intr_chan");
                Console.WriteLine("  21:reply to device_abort");
                Console.WriteLine("  22:send device_intr_srq");
                Console.WriteLine("  23:receive abort message");
                Console.WriteLine("  24:create RPC client (interrupt channel)");
                Console.WriteLine("  25:close RPC client (interrupt channel)");
                Console.WriteLine("  26:unregister core channel with portmapper");
                Console.WriteLine("  27:close RPC server (core channel)");
                Console.WriteLine("  28:close RPC server (abort channel)");
                Console.WriteLine("  29:run demo server");
                Console.WriteLine("  29:shutdown demo server");
                Console.WriteLine("   B:back to Main menu");
                Console.WriteLine(" E/Q:Exit program");
                Console.WriteLine("");
                Console.Write("Input fuction number? : ");
                string a = new String(Console.ReadLine());
                if (a == "1")
                {

                    Console.Write("  port number? : ");
                    int port = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("== create RPC server (abort channel) ==");
                    abort_server = abort_server2.Create("127.0.0.1", port);
                    Console.WriteLine(" Call : create_abort_channel : ret=0");
                }
                if (a == "2")
                {
                    Console.Write("  port number? : ");
                    int port = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("== create RPC server (core channel) ==");
                    core_server = core_server1.Create("127.0.0.1", port);
                    Console.WriteLine(" Call : create_core_channel : ret=0");
                }
                if (a == "3")
                {
                    Console.Write("  port number? : ");
                    int port = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("== register core channel with portmapper ==");
                    ServerPortmap tcp_server = new ServerPortmap();
                    ServerPortmap udp_server = new ServerPortmap();
                    tcp_server.Run("127.0.0.1", port, Pmap.IPPROTO.TCP);
                    udp_server.Run("127.0.0.1", port, Pmap.IPPROTO.UDP);
                    Thread.Sleep(100);
                    Console.WriteLine(" Call : run portmapper : ret=0");
                }
                if (a == "4")
                {
                    if (core_server != null)
                    {
                        Console.WriteLine("== accept_connection_requests ==");
                        core_channel = ServerVxi11.accept_connection_requests(core_server);
                        Console.WriteLine(" Call : accept_connection_requests : ret=0");
                    }
                }
                if (a == "5")
                {
                    if (core_channel != null)
                    {
                        int size = 0;
                        Console.WriteLine("  == Wait RPC ==");
                        RPC.RPC_MESSAGE_PARAMS msg = core_server1.ReceiveMsg();
                        Console.WriteLine("    received--.");
                        Console.WriteLine("      xid     = {0}", msg.xid);
                        Console.WriteLine("      proc    = {0}", msg.proc);
                        Console.WriteLine("      size    = {0}", size);
                        if (msg.proc == Vxi11.CREATE_LINK)
                        {
                            string handle;
                            ServerVxi11.receive_create_link(core_channel, msg, size, out handle);
                            Console.WriteLine("== CREATE_LINK ==");
                        }
                        else if (msg.proc == Vxi11.DEVICE_WRITE)
                        {
                            string data;
                            Vxi11.DEVICE_WRITE_PARAMS wrt = ServerVxi11.receive_device_write(core_channel, msg, size, out data);
                            Console.WriteLine("== DEVICE_WRITE ==");
                        }
                        else if (msg.proc == Vxi11.DEVICE_READ)
                        {
                            ServerVxi11.receive_device_read(core_channel, msg, size);
                            Console.WriteLine("== DEVICE_READ ==");
                        }
                        else if (msg.proc == Vxi11.DEVICE_READSTB)
                        {
                            Vxi11.DEVICE_GENERIC_PARAMS gen = ServerVxi11.receive_generic_params(core_channel, msg, size);
                            Console.WriteLine("== DEVICE_READSTB ==");
                        }
                        else if (msg.proc == Vxi11.DEVICE_TRIGGER)
                        {
                            Vxi11.DEVICE_GENERIC_PARAMS gen = ServerVxi11.receive_generic_params(core_channel, msg, size);
                            Console.WriteLine("== DEVICE_TRIGGER ==");
                        }
                        else if (msg.proc == Vxi11.DEVICE_CLEAR)
                        {
                            Vxi11.DEVICE_GENERIC_PARAMS gen = ServerVxi11.receive_generic_params(core_channel, msg, size);
                            Console.WriteLine("== DEVICE_CLEAR ==");
                        }
                        else if (msg.proc == Vxi11.DEVICE_REMOTE)
                        {
                            Vxi11.DEVICE_GENERIC_PARAMS gen = ServerVxi11.receive_generic_params(core_channel, msg, size);
                            Console.WriteLine("== DEVICE_REMOTE ==");
                        }
                        else if (msg.proc == Vxi11.DEVICE_LOCAL)
                        {
                            Vxi11.DEVICE_GENERIC_PARAMS gen = ServerVxi11.receive_generic_params(core_channel, msg, size);
                            Console.WriteLine("== DEVICE_LOCAL ==");
                        }
                        else if (msg.proc == Vxi11.DEVICE_LOCK)
                        {
                            ServerVxi11.receive_device_lock(core_channel, msg, size);
                            Console.WriteLine("== DEVICE_LOCK ==");
                        }
                        else if (msg.proc == Vxi11.DEVICE_UNLOCK)
                        {
                            int link = ServerVxi11.receive_device_link(core_channel, msg, size);
                            Console.WriteLine("== DEVICE_UNLOCK ==");
                        }
                        else if (msg.proc == Vxi11.DEVICE_ENABLE_SRQ)
                        {
                            string handle;
                            ServerVxi11.receive_device_enable_srq(core_channel, msg, size, out handle);
                            Console.WriteLine("== DEVICE_ENABLE_SRQ ==");
                        }
                        else if (msg.proc == Vxi11.DEVICE_DOCMD)
                        {
                            byte[] data_in; 
                            Vxi11.DEVICE_DOCMD_PARAMS dcm = ServerVxi11.receive_device_docmd(core_channel, msg, size, out data_in);
                            Console.WriteLine("== DEVICE_DOCMD ==");
                        }
                        else if (msg.proc == Vxi11.DESTROY_LINK)
                        {
                            int link = ServerVxi11.receive_device_link(core_channel, msg, size);
                            Console.WriteLine("== DESTROY_LINK ==");
                        }
                        else if (msg.proc == Vxi11.CREATE_INTR_CHAN)
                        {
                            ServerVxi11.receive_create_intr_chan(core_channel, msg, size);
                            Console.WriteLine("== CREATE_INTR_CHAN ==");
                        }
                        else if (msg.proc == Vxi11.DESTROY_INTR_CHAN)
                        {
                            Console.WriteLine("== DESTROY_INTR_CHAN ==");
                        }
                        else if (msg.proc == Vxi11.DEVICE_ABORT)
                        {
                            int link = ServerVxi11.receive_device_link(core_channel, msg, size);
                            Console.WriteLine("== DEVICE_ABORT ==");
                        }
                        else
                        {
                            ServerVxi11.Clear(core_channel);
                            Console.WriteLine("== clear_buffer ==");
                        }
                    }
                }
                if (a == "6")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        ServerVxi11.reply_create_link(core_channel, xid, 123, 456, 789);
                        Console.WriteLine("== reply to create_link ==");
                    }
                }
                if (a == "7")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        int data_len = Convert.ToInt32(Console.ReadLine());
                        ServerVxi11.reply_device_write(core_channel, xid, data_len);
                        Console.WriteLine("== reply to device_write ==");
                    }
                }
                if (a == "8")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        ServerVxi11.reply_device_read(core_channel, xid, 1, "XYZCO,246B,S000-0123-02,0");
                        Console.WriteLine("== reply to device_read ==");
                    }
                }
                if (a == "9")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        ServerVxi11.reply_device_readstb(core_channel, xid, 8);
                        Console.WriteLine("== reply to device_readstb ==");
                    }
                }
                if (a == "10")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        ServerVxi11.reply_device_error(core_channel, xid, RPC.SUCCESS);
                        Console.WriteLine("== reply to device_trigger ==");
                    }
                }
                if (a == "11")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        ServerVxi11.reply_device_error(core_channel, xid, RPC.SUCCESS);
                        Console.WriteLine("== reply to device_clear ==");
                    }
                }
                if (a == "12")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        ServerVxi11.reply_device_error(core_channel, xid, RPC.SUCCESS);
                        Console.WriteLine("== reply to device_remote ==");
                    }
                }
                if (a == "13")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        ServerVxi11.reply_device_error(core_channel, xid, RPC.SUCCESS);
                        Console.WriteLine("== reply to device_local ==");
                    }
                }
                if (a == "14")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        ServerVxi11.reply_device_error(core_channel, xid, RPC.SUCCESS);
                        Console.WriteLine("== reply to device_lock ==");
                    }
                }
                if (a == "15")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        ServerVxi11.reply_device_error(core_channel, xid, RPC.SUCCESS);
                        Console.WriteLine("== reply to device_unlock ==");
                    }
                }
                if (a == "16")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        ServerVxi11.reply_device_error(core_channel, xid, RPC.SUCCESS);
                        Console.WriteLine("== reply to device_enable_srq ==");
                    }
                }
                if (a == "17")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        int data_in_len = Convert.ToInt32(Console.ReadLine());
                        ServerVxi11.reply_device_docmd(core_channel, xid, data_in_len);
                        Console.WriteLine("== reply to device_docmd ==");
                    }
                }
                if (a == "18")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        ServerVxi11.reply_device_error(core_channel, xid, RPC.SUCCESS);
                        Console.WriteLine("== :reply to destroy_link ==");
                    }
                }
                if (a == "19")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        ServerVxi11.reply_device_error(core_channel, xid, RPC.SUCCESS);
                        Console.WriteLine("== reply to create_intr_chan ==");
                    }
                }
                if (a == "20")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        ServerVxi11.reply_device_error(core_channel, xid, RPC.SUCCESS);
                        Console.WriteLine("== reply to destroy_intr_chan ==");
                    }
                }
                if (a == "21")
                {
                    Console.WriteLine("  21:reply to device_abort");
                }
                if (a == "22")
                {
                    Console.WriteLine("  22:send device_intr_srq");
                }
                if (a == "23")
                {
                    Console.WriteLine("  23:receive abort message");
                }
                if (a == "24")
                {
                    Console.WriteLine("== create_interrupt_channel ==");
                }
                if (a == "25")
                {
                    Console.WriteLine("== close_interrupt_channel ==");
                }
                if (a == "26")
                {
                    Console.WriteLine("  26:unregister core channel with portmapper");
                }
                if (a == "27")
                {
                    Console.WriteLine("== close_coret_channel ==");
                }
                if (a == "28")
                {
                    Console.WriteLine("== close_abort_channel ==");
                }
                if (a == "29")
                {
                    Console.Write("  port number? : ");
                    int port = Convert.ToInt32(Console.ReadLine());
                    ServerVxi11 server = new ServerVxi11();
                    server.RunCoreChannel("127.0.0.1", port);
                }
                if ((a == "B") || (a == "b"))
                {
                    isLoop = false;
                }
                if ((a == "Q") || (a == "q") || (a == "E") || (a == "e"))
                {
                    Console.WriteLine("== Exit program ==");
                    Environment.Exit(0);
                }
            }
        }
        public static void PortmapConsole()
        {
            bool isLoop = true;
            ServerPortmap tcp_server = new ServerPortmap();
            ServerPortmap udp_server = new ServerPortmap();

            while (isLoop)
            {
                Console.WriteLine("Select Portmap Function");
                Console.WriteLine("   1:create portmap server");
                Console.WriteLine("   2:receive message");
                Console.WriteLine("   3:reply to pmap_set");
                Console.WriteLine("   4:reply to pmap_unset");
                Console.WriteLine("   5:reply to pmap_getport");
                Console.WriteLine("   6:reply to pmap_dump");
                Console.WriteLine("   7:close portmap server");
                Console.WriteLine("   B:back to Main menu");
                Console.WriteLine(" E/Q:Exit program");
                Console.WriteLine("");
                Console.Write("Input fuction number? : ");
                string a = new String(Console.ReadLine());
                if (a == "1")
                {
                    Console.Write("  port number? : ");
                    int port = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("== create portmap server ==");
                    tcp_server.Create("127.0.0.1", port, Pmap.IPPROTO.UDP);
                    Console.WriteLine(" Call : create_abort_channel : ret=0");
                }
                if (a == "2")
                {
                    int size = 0;
                    Console.WriteLine("  == Wait RPC ==");
                    RPC.RPC_MESSAGE_PARAMS msg = tcp_server.ReceiveMsg();
                    Console.WriteLine("    received--.");
                    Console.WriteLine("      xid     = {0}", msg.xid);
                    Console.WriteLine("      proc    = {0}", msg.proc);
                    Console.WriteLine("      size    = {0}", size);
                    if (msg.proc == Pmap.PROC_NULL)
                    {
                        tcp_server.ReceiveNull();
                        Console.WriteLine("== PMAPPROC_NULL ==");
                    }
                    else if (msg.proc == Pmap.PROC_SET)
                    {
                        Pmap.MAPPING map = tcp_server.ReceiveSet();
                        Console.WriteLine("== PMAPPROC_SET ==");
                    }
                    else if (msg.proc == Pmap.PROC_UNSET)
                    {
                        Pmap.MAPPING map = tcp_server.ReceiveUnset();
                        Console.WriteLine("== PMAPPROC_UNSET ==");
                    }
                    else if (msg.proc == Pmap.PROC_GETPORT)
                    {
                        Pmap.MAPPING map = tcp_server.ReceiveGetport();
                        Console.WriteLine("== PMAPPROC_GETPORT ==");
                    }
                    else if (msg.proc == Pmap.PROC_DUMP)
                    {
                        tcp_server.ReceiveDump();
                        Console.WriteLine("== PMAPPROC_DUMP ==");
                    }
                    else
                    {
                        tcp_server.ClearArgs();
                        Console.WriteLine("== clear_buffer ==");
                    }
                }
                if (a == "3")
                {
                    int xid = Convert.ToInt32(Console.ReadLine());
                    tcp_server.ReplySet(true);
                    Console.WriteLine("== reply to pmapproc_set ==");
                }
                if (a == "4")
                {
                    int xid = Convert.ToInt32(Console.ReadLine());
                    tcp_server.ReplyUnset(true);
                    Console.WriteLine("== reply to pmapproc_unset ==");
                }
                if (a == "5")
                {
                    int xid = Convert.ToInt32(Console.ReadLine());
                    tcp_server.ReplyGetport(1);
                    Console.WriteLine("== reply to pmapproc_getport ==");
                }
                if (a == "6")
                {
                    int xid = Convert.ToInt32(Console.ReadLine());
                    tcp_server.ReplyDump(new List<Pmap.MAPPING>());
                    Console.WriteLine("== reply to pmapproc_dump ==");
                }
                if (a == "7")
                {
                    int xid = Convert.ToInt32(Console.ReadLine());
                    tcp_server.Destroy();
                    Console.WriteLine("== close portmap server ==");
                }
                if ((a == "B") || (a == "b"))
                {
                    isLoop = false;
                }
                if ((a == "Q") || (a == "q") || (a == "E") || (a == "e"))
                {
                    Console.WriteLine("== Exit program ==");
                    Environment.Exit(0);
                }
            }
        }
    }
}