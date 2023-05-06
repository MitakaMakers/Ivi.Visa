using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace VXI11Net
{
    public class Serverconsole
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
                    abort_server = Vxi11ServerHandler.create_abort_channel("127.0.0.1", port);
                    Console.WriteLine(" Call : create_abort_channel : ret=0");
                }
                if (a == "2")
                {
                    Console.Write("  port number? : ");
                    int port = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("== create RPC server (core channel) ==");
                    core_server = Vxi11ServerHandler.create_core_channel("127.0.0.1", port);
                    Console.WriteLine(" Call : create_core_channel : ret=0");
                }
                if (a == "3")
                {
                    Console.Write("  port number? : ");
                    int port = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("== register core channel with portmapper ==");
                    TcpPortmapServer tcp_server = new TcpPortmapServer();
                    UdpPortmapServer udp_server = new UdpPortmapServer();
                    tcp_server.Run("127.0.0.1", port);
                    udp_server.Run("127.0.0.1", port);
                    Thread.Sleep(100);
                    Console.WriteLine(" Call : run portmapper : ret=0");
                }
                if (a == "4")
                {
                    if (core_server != null)
                    {
                        Console.WriteLine("== accept_connection_requests ==");
                        core_channel = Vxi11ServerHandler.accept_connection_requests(core_server);
                        Console.WriteLine(" Call : accept_connection_requests : ret=0");
                    }
                }
                if (a == "5")
                {
                    if (core_channel != null)
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
                            string handle;
                            Vxi11ServerHandler.receive_create_link(core_channel, msg, size, out handle);
                            Console.WriteLine("== CREATE_LINK ==");
                        }
                        else if (msg.proc == Vxi11ServerHandler.DEVICE_WRITE)
                        {
                            string data;
                            Vxi11ServerHandler.DEVICE_WRITE_PARAMS wrt = Vxi11ServerHandler.receive_device_write(core_channel, msg, size, out data);
                            Console.WriteLine("== DEVICE_WRITE ==");
                        }
                        else if (msg.proc == Vxi11ServerHandler.DEVICE_READ)
                        {
                            Vxi11ServerHandler.receive_device_read(core_channel, msg, size);
                            Console.WriteLine("== DEVICE_READ ==");
                        }
                        else if (msg.proc == Vxi11ServerHandler.DEVICE_READSTB)
                        {
                            Vxi11ServerHandler.DEVICE_GENERIC_PARAMS gen = Vxi11ServerHandler.receive_generic_params(core_channel, msg, size);
                            Console.WriteLine("== DEVICE_READSTB ==");
                        }
                        else if (msg.proc == Vxi11ServerHandler.DEVICE_TRIGGER)
                        {
                            Vxi11ServerHandler.DEVICE_GENERIC_PARAMS gen = Vxi11ServerHandler.receive_generic_params(core_channel, msg, size);
                            Console.WriteLine("== DEVICE_TRIGGER ==");
                        }
                        else if (msg.proc == Vxi11ServerHandler.DEVICE_CLEAR)
                        {
                            Vxi11ServerHandler.DEVICE_GENERIC_PARAMS gen = Vxi11ServerHandler.receive_generic_params(core_channel, msg, size);
                            Console.WriteLine("== DEVICE_CLEAR ==");
                        }
                        else if (msg.proc == Vxi11ServerHandler.DEVICE_REMOTE)
                        {
                            Vxi11ServerHandler.DEVICE_GENERIC_PARAMS gen = Vxi11ServerHandler.receive_generic_params(core_channel, msg, size);
                            Console.WriteLine("== DEVICE_REMOTE ==");
                        }
                        else if (msg.proc == Vxi11ServerHandler.DEVICE_LOCAL)
                        {
                            Vxi11ServerHandler.DEVICE_GENERIC_PARAMS gen = Vxi11ServerHandler.receive_generic_params(core_channel, msg, size);
                            Console.WriteLine("== DEVICE_LOCAL ==");
                        }
                        else if (msg.proc == Vxi11ServerHandler.DEVICE_LOCK)
                        {
                            Vxi11ServerHandler.receive_device_lock(core_channel, msg, size);
                            Console.WriteLine("== DEVICE_LOCK ==");
                        }
                        else if (msg.proc == Vxi11ServerHandler.DEVICE_UNLOCK)
                        {
                            int link = Vxi11ServerHandler.receive_device_link(core_channel, msg, size);
                            Console.WriteLine("== DEVICE_UNLOCK ==");
                        }
                        else if (msg.proc == Vxi11ServerHandler.DEVICE_ENABLE_SRQ)
                        {
                            string handle;
                            Vxi11ServerHandler.receive_device_enable_srq(core_channel, msg, size, out handle);
                            Console.WriteLine("== DEVICE_ENABLE_SRQ ==");
                        }
                        else if (msg.proc == Vxi11ServerHandler.DEVICE_DOCMD)
                        {
                            byte[] data_in; 
                            Vxi11ServerHandler.DEVICE_DOCMD_PARAMS dcm = Vxi11ServerHandler.receive_device_docmd(core_channel, msg, size, out data_in);
                            Console.WriteLine("== DEVICE_DOCMD ==");
                        }
                        else if (msg.proc == Vxi11ServerHandler.DESTROY_LINK)
                        {
                            int link = Vxi11ServerHandler.receive_device_link(core_channel, msg, size);
                            Console.WriteLine("== DESTROY_LINK ==");
                        }
                        else if (msg.proc == Vxi11ServerHandler.CREATE_INTR_CHAN)
                        {
                            Vxi11ServerHandler.receive_create_intr_chan(core_channel, msg, size);
                            Console.WriteLine("== CREATE_INTR_CHAN ==");
                        }
                        else if (msg.proc == Vxi11ServerHandler.DESTROY_INTR_CHAN)
                        {
                            Console.WriteLine("== DESTROY_INTR_CHAN ==");
                        }
                        else if (msg.proc == Vxi11ServerHandler.DEVICE_ABORT)
                        {
                            int link = Vxi11ServerHandler.receive_device_link(core_channel, msg, size);
                            Console.WriteLine("== DEVICE_ABORT ==");
                        }
                        else
                        {
                            RPC.clear_buffer(core_channel);
                            Console.WriteLine("== clear_buffer ==");
                        }
                    }
                }
                if (a == "6")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Vxi11ServerHandler.reply_create_link(core_channel, xid, 123, 456, 789);
                        Console.WriteLine("== reply to create_link ==");
                    }
                }
                if (a == "7")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        int data_len = Convert.ToInt32(Console.ReadLine());
                        Vxi11ServerHandler.reply_device_write(core_channel, xid, data_len);
                        Console.WriteLine("== reply to device_write ==");
                    }
                }
                if (a == "8")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Vxi11ServerHandler.reply_device_read(core_channel, xid, 1, "XYZCO,246B,S000-0123-02,0");
                        Console.WriteLine("== reply to device_read ==");
                    }
                }
                if (a == "9")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Vxi11ServerHandler.reply_device_readstb(core_channel, xid, 8);
                        Console.WriteLine("== reply to device_readstb ==");
                    }
                }
                if (a == "10")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Vxi11ServerHandler.reply_device_error(core_channel, xid, RPC.SUCCESS);
                        Console.WriteLine("== reply to device_trigger ==");
                    }
                }
                if (a == "11")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Vxi11ServerHandler.reply_device_error(core_channel, xid, RPC.SUCCESS);
                        Console.WriteLine("== reply to device_clear ==");
                    }
                }
                if (a == "12")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Vxi11ServerHandler.reply_device_error(core_channel, xid, RPC.SUCCESS);
                        Console.WriteLine("== reply to device_remote ==");
                    }
                }
                if (a == "13")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Vxi11ServerHandler.reply_device_error(core_channel, xid, RPC.SUCCESS);
                        Console.WriteLine("== reply to device_local ==");
                    }
                }
                if (a == "14")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Vxi11ServerHandler.reply_device_error(core_channel, xid, RPC.SUCCESS);
                        Console.WriteLine("== reply to device_lock ==");
                    }
                }
                if (a == "15")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Vxi11ServerHandler.reply_device_error(core_channel, xid, RPC.SUCCESS);
                        Console.WriteLine("== reply to device_unlock ==");
                    }
                }
                if (a == "16")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Vxi11ServerHandler.reply_device_error(core_channel, xid, RPC.SUCCESS);
                        Console.WriteLine("== reply to device_enable_srq ==");
                    }
                }
                if (a == "17")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        int data_in_len = Convert.ToInt32(Console.ReadLine());
                        Vxi11ServerHandler.reply_device_docmd(core_channel, xid, data_in_len);
                        Console.WriteLine("== reply to device_docmd ==");
                    }
                }
                if (a == "18")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Vxi11ServerHandler.reply_device_error(core_channel, xid, RPC.SUCCESS);
                        Console.WriteLine("== :reply to destroy_link ==");
                    }
                }
                if (a == "19")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Vxi11ServerHandler.reply_device_error(core_channel, xid, RPC.SUCCESS);
                        Console.WriteLine("== reply to create_intr_chan ==");
                    }
                }
                if (a == "20")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Vxi11ServerHandler.reply_device_error(core_channel, xid, RPC.SUCCESS);
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
                    CoreServer server = new CoreServer();
                    server.Run("127.0.0.1", port);
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
            Socket? udp_server = null;
            Socket? tcp_server = null;
            Socket? tcp_channel = null;

            while (isLoop)
            {
                Console.WriteLine("Select Portmap Function");
                Console.WriteLine("   1:create portmap server (TCP)");
                Console.WriteLine("   2:create portmap server (UDP)");
                Console.WriteLine("   3:be ready to accept connection requests");
                Console.WriteLine("   4:receive tcp message");
                Console.WriteLine("   5:reply to pmap_null");
                Console.WriteLine("   6:reply to pmap_set");
                Console.WriteLine("   7:reply to pmap_unset");
                Console.WriteLine("   8:reply to pmap_getport");
                Console.WriteLine("   9:reply to pmap_dump");
                Console.WriteLine("  10:receive udp message");
                Console.WriteLine("  11:reply to pmap_null");
                Console.WriteLine("  12:reply to pmap_set");
                Console.WriteLine("  13:reply to pmap_unset");
                Console.WriteLine("  14:reply to pmap_getport");
                Console.WriteLine("  15:reply to pmap_dump");
                Console.WriteLine("  16:close portmap server (TCP)");
                Console.WriteLine("  17:close portmap server (UDP)");
                Console.WriteLine("   B:back to Main menu");
                Console.WriteLine(" E/Q:Exit program");
                Console.WriteLine("");
                Console.Write("Input fuction number? : ");
                string a = new String(Console.ReadLine());
                if (a == "1")
                {

                    Console.Write("  port number? : ");
                    int port = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("== create portmap server (TCP) ==");
                    tcp_server = PortmapHandler.create_tcp_channel("127.0.0.1", port);
                    Console.WriteLine(" Call : create_abort_channel : ret=0");
                }
                if (a == "2")
                {
                    Console.Write("  port number? : ");
                    int port = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("== create portmap server (UDP) ==");
                    udp_server = PortmapHandler.create_udp_channel("127.0.0.1", port);
                    Console.WriteLine(" Call : :create portmap server (UDP) : ret=0");
                }
                if (a == "3")
                {
                    if (tcp_server != null)
                    {
                        Console.WriteLine("== accept_connection_requests ==");
                        tcp_channel = PortmapHandler.accept_connection_requests(tcp_server);
                        Console.WriteLine(" Call : accept_connection_requests : ret=0");
                    }
                }
                if (a == "4")
                {
                    if (tcp_channel != null)
                    {
                        int size;
                        Console.WriteLine("  == Wait RPC ==");
                        RPC.RPC_MESSAGE_PARAMS msg = RPC.receive_message(tcp_channel, out size);
                        Console.WriteLine("    received--.");
                        Console.WriteLine("      xid     = {0}", msg.xid);
                        Console.WriteLine("      proc    = {0}", msg.proc);
                        Console.WriteLine("      size    = {0}", size);
                        if (msg.proc == PortmapHandler.PMAPPROC_NULL)
                        {
                            PortmapHandler.receive_pmapproc_null(tcp_channel, msg, size);
                            Console.WriteLine("== PMAPPROC_NULL ==");
                        }
                        else if (msg.proc == PortmapHandler.PMAPPROC_SET)
                        {
                            PortmapHandler.MAPPING map = PortmapHandler.receive_pmapproc_set(tcp_channel, msg, size);
                            Console.WriteLine("== PMAPPROC_SET ==");
                        }
                        else if (msg.proc == PortmapHandler.PMAPPROC_UNSET)
                        {
                            PortmapHandler.MAPPING map = PortmapHandler.receive_pmapproc_unset(tcp_channel, msg, size);
                            Console.WriteLine("== PMAPPROC_UNSET ==");
                        }
                        else if (msg.proc == PortmapHandler.PMAPPROC_GETPORT)
                        {
                            PortmapHandler.MAPPING map = PortmapHandler.receive_pmapproc_getport(tcp_channel, msg, size);
                            Console.WriteLine("== PMAPPROC_GETPORT ==");
                        }
                        else if (msg.proc == PortmapHandler.PMAPPROC_DUMP)
                        {
                            PortmapHandler.receive_pmapproc_dump(tcp_channel, msg, size);
                            Console.WriteLine("== PMAPPROC_DUMP ==");
                        }
                        else
                        {
                            RPC.clear_buffer(tcp_channel);
                            Console.WriteLine("== clear_buffer ==");
                        }
                    }
                }
                if (a == "5")
                {
                    if (tcp_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        PortmapHandler.reply_pmapproc_null(tcp_channel, xid, true);
                        Console.WriteLine("== reply to pmapproc_null ==");
                    }
                }
                if (a == "6")
                {
                    if (tcp_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        PortmapHandler.reply_pmapproc_set(tcp_channel, xid, true);
                        Console.WriteLine("== reply to pmapproc_set ==");
                    }
                }
                if (a == "7")
                {
                    if (tcp_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        PortmapHandler.reply_pmapproc_unset(tcp_channel, xid, true);
                        Console.WriteLine("== reply to pmapproc_unset ==");
                    }
                }
                if (a == "8")
                {
                    if (tcp_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        PortmapHandler.reply_pmapproc_getport(tcp_channel, xid, 1);
                        Console.WriteLine("== reply to pmapproc_getport ==");
                    }
                }
                if (a == "9")
                {
                    if (tcp_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        PortmapHandler.reply_pmapproc_dump(tcp_channel, xid, new List<PortmapHandler.MAPPING>());
                        Console.WriteLine("== reply to pmapproc_dump ==");
                    }
                }
                if (a == "10")
                {
                    if (udp_server != null)
                    {
                        int size;
                        Console.WriteLine("  == Wait RPC ==");
                        RPC.RPC_MESSAGE_PARAMS msg = RPC.receive_message(udp_server, out size);
                        Console.WriteLine("    received--.");
                        Console.WriteLine("      xid     = {0}", msg.xid);
                        Console.WriteLine("      proc    = {0}", msg.proc);
                        Console.WriteLine("      size    = {0}", size);
                        if (msg.proc == PortmapHandler.PMAPPROC_NULL)
                        {
                            PortmapHandler.receive_pmapproc_null(udp_server, msg, size);
                            Console.WriteLine("== PMAPPROC_NULL ==");
                        }
                        else if (msg.proc == PortmapHandler.PMAPPROC_SET)
                        {
                            PortmapHandler.MAPPING map = PortmapHandler.receive_pmapproc_set(udp_server, msg, size);
                            Console.WriteLine("== PMAPPROC_SET ==");
                        }
                        else if (msg.proc == PortmapHandler.PMAPPROC_UNSET)
                        {
                            PortmapHandler.MAPPING map = PortmapHandler.receive_pmapproc_unset(udp_server, msg, size);
                            Console.WriteLine("== PMAPPROC_UNSET ==");
                        }
                        else if (msg.proc == PortmapHandler.PMAPPROC_GETPORT)
                        {
                            PortmapHandler.MAPPING map = PortmapHandler.receive_pmapproc_getport(udp_server, msg, size);
                            Console.WriteLine("== PMAPPROC_GETPORT ==");
                        }
                        else if (msg.proc == PortmapHandler.PMAPPROC_DUMP)
                        {
                            PortmapHandler.receive_pmapproc_dump(udp_server, msg, size);
                            Console.WriteLine("== PMAPPROC_DUMP ==");
                        }
                        else
                        {
                            RPC.clear_buffer(udp_server);
                            Console.WriteLine("== clear_buffer ==");
                        }
                    }
                }
                if (a == "11")
                {
                    if (udp_server != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        PortmapHandler.reply_pmapproc_null(udp_server, xid, true);
                        Console.WriteLine("== reply to pmapproc_null ==");
                    }
                }
                if (a == "12")
                {
                    if (udp_server != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        PortmapHandler.reply_pmapproc_set(udp_server, xid, true);
                        Console.WriteLine("== reply to pmapproc_set ==");
                    }
                }
                if (a == "13")
                {
                    if (udp_server != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        PortmapHandler.reply_pmapproc_unset(udp_server, xid, true);
                        Console.WriteLine("== reply to pmapproc_unset ==");
                    }
                }
                if (a == "14")
                {
                    if (udp_server != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        PortmapHandler.reply_pmapproc_getport(udp_server, xid, 1);
                        Console.WriteLine("== reply to pmapproc_getport ==");
                    }
                }
                if (a == "15")
                {
                    if (udp_server != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        PortmapHandler.reply_pmapproc_dump(udp_server, xid, new List<PortmapHandler.MAPPING>());
                        Console.WriteLine("== reply to pmapproc_dump ==");
                    }
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