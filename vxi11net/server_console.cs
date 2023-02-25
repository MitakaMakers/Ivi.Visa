using System.Net.Sockets;

namespace VXI11Net
{
    public class Serverconsole
    {
        static void Main(string[] args)
        {
            bool isEnable = true;
            Socket? abort_server = null;
            Socket? core_server = null;
            Socket? core_channel = null;

            while (isEnable)
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
                Console.WriteLine("  29:Run demo server)");
                Console.WriteLine(" E/Q:Exit program");
                Console.WriteLine("");
                Console.Write("Input fuction number? : ");
                string a = new String(Console.ReadLine());
                if ((a == "Q") || (a == "q") || (a == "E") || (a == "e"))
                {
                    Console.WriteLine("== Exit program ==");
                    isEnable = false;
                }
                if (a == "1")
                {

                    Console.Write("  IP address? : ");
                    string address = new String(Console.ReadLine());
                    Console.Write("  port number? : ");
                    int port = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("== create_abort_channel ==");
                    abort_server = Server.create_abort_channel(address, port);
                    Console.WriteLine(" Call : create_abort_channel : ret=0");
                }
                if (a == "2")
                {
                    Console.Write("  IP address? : ");
                    string address = new String(Console.ReadLine());
                    Console.Write("  port number? : ");
                    int port = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("== create_core_channel ==");
                    core_server = Server.create_core_channel(address, port);
                    Console.WriteLine(" Call : create_core_channel : ret=0");
                }
                if (a == "4")
                {
                    if (core_server != null)
                    {
                        Console.WriteLine("== accept_connection_requests ==");
                        core_channel = Server.accept_connection_requests(core_server);
                        Console.WriteLine(" Call : accept_connection_requests : ret=0");
                    }
                }
                if (a == "5")
                {
                    if (core_channel != null)
                    {
                        int size;
                        Server.RPC_MESSAGE_PARAMS msg = Server.receive_message(core_channel, out size);
                        if (msg.proc == Server.CREATE_LINK)
                        {
                            Server.receive_create_link(core_channel, msg, size);
                            Console.WriteLine("== CREATE_LINK ==");
                        }
                        if (msg.proc == Server.DEVICE_WRITE)
                        {
                            Server.DEVICE_WRITE_PARAMS wrt = Server.receive_device_write(core_channel, msg, size);
                            Console.WriteLine("== DEVICE_WRITE ==");
                        }
                        if (msg.proc == Server.DEVICE_READ)
                        {
                            Server.receive_device_read(core_channel, msg, size);
                            Console.WriteLine("== DEVICE_READ ==");
                        }
                        if (msg.proc == Server.DEVICE_READSTB)
                        {
                            Server.DEVICE_GENERIC_PARAMS gen = Server.receive_generic_params(core_channel, msg, size);
                            Console.WriteLine("== DEVICE_READSTB ==");
                        }
                        if (msg.proc == Server.DEVICE_TRIGGER)
                        {
                            Server.DEVICE_GENERIC_PARAMS gen = Server.receive_generic_params(core_channel, msg, size);
                            Console.WriteLine("== DEVICE_TRIGGER ==");
                        }
                        if (msg.proc == Server.DEVICE_CLEAR)
                        {
                            Server.DEVICE_GENERIC_PARAMS gen = Server.receive_generic_params(core_channel, msg, size);
                            Console.WriteLine("== DEVICE_CLEAR ==");
                        }
                        if (msg.proc == Server.DEVICE_REMOTE)
                        {
                            Server.DEVICE_GENERIC_PARAMS gen = Server.receive_generic_params(core_channel, msg, size);
                            Console.WriteLine("== DEVICE_REMOTE ==");
                        }
                        if (msg.proc == Server.DEVICE_LOCAL)
                        {
                            Server.DEVICE_GENERIC_PARAMS gen = Server.receive_generic_params(core_channel, msg, size);
                            Console.WriteLine("== DEVICE_LOCAL ==");
                        }
                        if (msg.proc == Server.DEVICE_LOCK)
                        {
                            Server.receive_device_lock(core_channel, msg, size);
                            Console.WriteLine("== DEVICE_LOCK ==");
                        }
                        if (msg.proc == Server.DEVICE_UNLOCK)
                        {
                            int link = Server.receive_device_link(core_channel, msg, size);
                            Console.WriteLine("== DEVICE_UNLOCK ==");
                        }
                        if (msg.proc == Server.DEVICE_ENABLE_SRQ)
                        {
                            Server.receive_device_enable_srq(core_channel, msg, size);
                            Console.WriteLine("== DEVICE_ENABLE_SRQ ==");
                        }
                        if (msg.proc == Server.DEVICE_DOCMD)
                        {
                            Server.DEVICE_DOCMD_PARAMS dcm = Server.receive_device_docmd(core_channel, msg, size);
                            Console.WriteLine("== DEVICE_DOCMD ==");
                        }
                        if (msg.proc == Server.DESTROY_LINK)
                        {
                            int link = Server.receive_device_link(core_channel, msg, size);
                            Console.WriteLine("== DESTROY_LINK ==");
                        }
                        if (msg.proc == Server.CREATE_INTR_CHAN)
                        {
                            Server.receive_create_intr_chan(core_channel, msg, size);
                            Console.WriteLine("== CREATE_INTR_CHAN ==");
                        }
                        if (msg.proc == Server.DESTROY_INTR_CHAN)
                        {
                            Console.WriteLine("== DESTROY_INTR_CHAN ==");
                        }
                        if (msg.proc == Server.DEVICE_ABORT)
                        {
                            int link = Server.receive_device_link(core_channel, msg, size);
                            Console.WriteLine("== DEVICE_ABORT ==");
                        }
                        else
                        {
                            Server.clear_buffer(core_channel);
                            Console.WriteLine("== clear_buffer ==");
                        }
                    }
                }
                if (a == "6")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Server.reply_create_link(core_channel, xid, 123, 456, 789);
                    }
                }
                if (a == "7")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        int data_len = Convert.ToInt32(Console.ReadLine());
                        Server.reply_device_write(core_channel, xid, data_len);
                    }
                }
                if (a == "8")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Server.reply_device_read(core_channel, xid, 1, "XYZCO,246B,S000-0123-02,0");
                    }
                }
                if (a == "9")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Server.reply_device_readstb(core_channel, xid, 8);
                    }
                }
                if (a == "10")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Server.reply_device_error(core_channel, xid, Server.SUCCESS);
                    }
                }
                if (a == "11")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Server.reply_device_error(core_channel, xid, Server.SUCCESS);
                    }
                }
                if (a == "12")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Server.reply_device_error(core_channel, xid, Server.SUCCESS);
                    }
                }
                if (a == "13")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Server.reply_device_error(core_channel, xid, Server.SUCCESS);
                    }
                }
                if (a == "14")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Server.reply_device_error(core_channel, xid, Server.SUCCESS);
                    }
                }
                if (a == "15")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Server.reply_device_error(core_channel, xid, Server.SUCCESS);
                    }
                }
                if (a == "16")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Server.reply_device_error(core_channel, xid, Server.SUCCESS);
                    }
                }
                if (a == "17")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        int data_in_len = Convert.ToInt32(Console.ReadLine());
                        Server.reply_device_docmd(core_channel, xid, data_in_len);
                    }
                }
                if (a == "18")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Server.reply_device_error(core_channel, xid, Server.SUCCESS);
                    }
                }
                if (a == "19")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Server.reply_device_error(core_channel, xid, Server.SUCCESS);
                    }
                }
                if (a == "20")
                {
                    if (core_channel != null)
                    {
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Server.reply_device_error(core_channel, xid, Server.SUCCESS);
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
                    Console.Write("  IP address? : ");
                    string adress = new String(Console.ReadLine());
                    Console.Write("  port number? : ");
                    int port = Convert.ToInt32(Console.ReadLine());

                    core_server = Server.create_core_channel(adress, port);
                    core_channel = Server.accept_connection_requests(core_server);

                    Console.WriteLine("== Run demo server ==");
                    while (true)
                    {
                        int size;
                        Server.RPC_MESSAGE_PARAMS msg = Server.receive_message(core_channel, out size);
                        if (msg.proc == Server.CREATE_LINK)
                        {
                            Server.receive_create_link(core_channel, msg, size);
                            Server.reply_create_link(core_channel, msg.xid, 123, 456, 789);
                            Console.WriteLine("  == CREATE_LINK ==");
                        }
                        if (msg.proc == Server.DEVICE_WRITE)
                        {
                            Server.DEVICE_WRITE_PARAMS wrt = Server.receive_device_write(core_channel, msg, size);
                            Server.reply_device_write(core_channel, msg.xid, wrt.data_len);
                            Console.WriteLine("  == DEVICE_WRITE ==");
                        }
                        if (msg.proc == Server.DEVICE_READ)
                        {
                            Server.receive_device_read(core_channel, msg, size);
                            Server.reply_device_read(core_channel, msg.xid, 1, "XYZCO,246B,S000-0123-02,0");
                            Console.WriteLine("  == DEVICE_READ ==");
                        }
                        if (msg.proc == Server.DEVICE_READSTB)
                        {
                            Server.DEVICE_GENERIC_PARAMS gen = Server.receive_generic_params(core_channel, msg, size);
                            Server.reply_device_readstb(core_channel, msg.xid, 8);
                            Console.WriteLine("  == DEVICE_READSTB ==");
                        }
                        if (msg.proc == Server.DEVICE_TRIGGER)
                        {
                            Server.DEVICE_GENERIC_PARAMS gen = Server.receive_generic_params(core_channel, msg, size);
                            Server.reply_device_error(core_channel, msg.xid, Server.SUCCESS);
                            Console.WriteLine("  == DEVICE_TRIGGER ==");
                        }
                        if (msg.proc == Server.DEVICE_CLEAR)
                        {
                            Server.DEVICE_GENERIC_PARAMS gen = Server.receive_generic_params(core_channel, msg, size);
                            Server.reply_device_error(core_channel, msg.xid, Server.SUCCESS);
                            Console.WriteLine("  == DEVICE_CLEAR ==");
                        }
                        if (msg.proc == Server.DEVICE_REMOTE)
                        {
                            Server.DEVICE_GENERIC_PARAMS gen = Server.receive_generic_params(core_channel, msg, size);
                            Server.reply_device_error(core_channel, msg.xid, Server.SUCCESS);
                            Console.WriteLine("  == DEVICE_REMOTE ==");
                        }
                        if (msg.proc == Server.DEVICE_LOCAL)
                        {
                            Server.DEVICE_GENERIC_PARAMS gen = Server.receive_generic_params(core_channel, msg, size);
                            Server.reply_device_error(core_channel, msg.xid, Server.SUCCESS);
                            Console.WriteLine("  == DEVICE_LOCAL ==");
                        }
                        if (msg.proc == Server.DEVICE_LOCK)
                        {
                            Server.receive_device_lock(core_channel, msg, size);
                            Server.reply_device_error(core_channel, msg.xid, Server.SUCCESS);
                            Console.WriteLine("  == DEVICE_LOCK ==");
                        }
                        if (msg.proc == Server.DEVICE_UNLOCK)
                        {
                            int link = Server.receive_device_link(core_channel, msg, size);
                            Server.reply_device_error(core_channel, msg.xid, Server.SUCCESS);
                            Console.WriteLine("  == DEVICE_UNLOCK ==");
                        }
                        if (msg.proc == Server.DEVICE_ENABLE_SRQ)
                        {
                            Server.receive_device_enable_srq(core_channel, msg, size);
                            Server.reply_device_error(core_channel, msg.xid, Server.SUCCESS);
                            Console.WriteLine("  == DEVICE_ENABLE_SRQ ==");
                        }
                        if (msg.proc == Server.DEVICE_DOCMD)
                        {
                            Server.DEVICE_DOCMD_PARAMS dcm = Server.receive_device_docmd(core_channel, msg, size);
                            Server.reply_device_docmd(core_channel, msg.xid, dcm.data_in_len);
                            Console.WriteLine("  == DEVICE_DOCMD ==");
                        }
                        if (msg.proc == Server.DESTROY_LINK)
                        {
                            int link = Server.receive_device_link(core_channel, msg, size);
                            Server.reply_device_error(core_channel, msg.xid, Server.SUCCESS);
                            Console.WriteLine("  == DESTROY_LINK ==");
                        }
                        if (msg.proc == Server.CREATE_INTR_CHAN)
                        {
                            Server.receive_create_intr_chan(core_channel, msg, size);
                            Server.reply_device_error(core_channel, msg.xid, Server.SUCCESS);
                            Console.WriteLine("  == CREATE_INTR_CHAN ==");
                        }
                        if (msg.proc == Server.DESTROY_INTR_CHAN)
                        {
                            Server.reply_device_error(core_channel, msg.xid, Server.SUCCESS);
                            Console.WriteLine("  == DESTROY_INTR_CHAN ==");
                        }
                        if (msg.proc == Server.DEVICE_ABORT)
                        {
                            int link = Server.receive_device_link(core_channel, msg, size);
                            Server.reply_device_error(core_channel, msg.xid, Server.SUCCESS);
                            Console.WriteLine("  == DEVICE_ABORT ==");
                        }
                        else
                        {
                            Server.clear_buffer(core_channel);
                        }
                    }
                }
            }
        }
    }
}