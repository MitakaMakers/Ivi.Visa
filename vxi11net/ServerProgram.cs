using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;

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
                    Vxi11Console();
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
        public static void Vxi11Console()
        {
            bool isLoop = true;
            ServerVxi11 server = new ServerVxi11();

            while (isLoop)
            {
                Console.WriteLine("Select VXI-11 server Function");
                Console.WriteLine("   1:create Vxi11 server (core channel)");
                Console.WriteLine("   2:receive message");
                Console.WriteLine("   3:reply to create_link");
                Console.WriteLine("   4:reply to device_write");
                Console.WriteLine("   5:reply to device_read");
                Console.WriteLine("   6:reply to device_readstb");
                Console.WriteLine("   7:reply to device_trigger");
                Console.WriteLine("   8:reply to device_clear");
                Console.WriteLine("   9:reply to device_remote");
                Console.WriteLine("  10:reply to device_local");
                Console.WriteLine("  11:reply to device_lock");
                Console.WriteLine("  12:reply to device_unlock");
                Console.WriteLine("  13:reply to device_enable_srq");
                Console.WriteLine("  14:reply to device_docmd");
                Console.WriteLine("  15:reply to destroy_link");
                Console.WriteLine("  16:reply to create_intr_chan");
                Console.WriteLine("  17:reply to destroy_intr_chan");
                Console.WriteLine("  18:reply to device_abort");
                //Console.WriteLine("  19:send device_intr_srq");
                //Console.WriteLine("  20:receive abort message");
                //Console.WriteLine("  21:create RPC client (interrupt channel)");
                //Console.WriteLine("  22:close RPC client (interrupt channel)");
                //Console.WriteLine("  23:unregister core channel with portmapper");
                Console.WriteLine("  24:close RPC server (core channel)");
                //Console.WriteLine("  25:close RPC server (abort channel)");
                Console.WriteLine("  26:run core server");
                Console.WriteLine("  27:shutdown server");
                Console.WriteLine("   B:back to Main menu");
                Console.WriteLine(" E/Q:Exit program");
                Console.WriteLine("");
                Console.Write("Input fuction number? : ");
                string a = new String(Console.ReadLine());
                if (a == "1")
                {
                    Console.Write("  port number? : ");
                    int port = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("== create RPC server (core channel) ==");
                    server.Create("127.0.0.1", port);
                    Console.WriteLine(" Call : create_core_channel : ret=0");
                }
                if (a == "2")
                {
                    Console.WriteLine("  == Wait RPC ==");
                    RPC.RPC_MESSAGE_PARAMS msg = server.ReceiveMsg();
                    Console.WriteLine("    received.");
                    Console.WriteLine("      xid     = {0}", msg.xid);
                    Console.WriteLine("      prog    = {0}", msg.prog);
                    Console.WriteLine("      proc    = {0}", msg.proc);
                    Console.WriteLine("      vers    = {0}", msg.vers);
                    if (msg.proc == Vxi11.CREATE_LINK)
                    {
                        string handle;
                        Vxi11.CREATE_LINK_PARAMS cre = server.ReceiveCreateLink(out handle);
                        Console.WriteLine("== CREATE_LINK ==");
                        Console.WriteLine("      lock_timeout = {0}", cre.lock_timeout);
                        Console.WriteLine("      clientId     = {0}", cre.clientId);
                        Console.WriteLine("      lockDevice   = {0}", cre.lockDevice);
                        Console.WriteLine("      handle       = {0}", handle);
                    }
                    else if (msg.proc == Vxi11.DEVICE_WRITE)
                    {
                        string data;
                        Vxi11.DEVICE_WRITE_PARAMS wrt = server.ReceiveDeviceWrite(out data);
                        Console.WriteLine("== DEVICE_WRITE ==");
                        Console.WriteLine("      lid          = {0}", wrt.lid);
                        Console.WriteLine("      flags        = {0}", wrt.flags);
                        Console.WriteLine("      lock_timeout = {0}", wrt.lock_timeout);
                        Console.WriteLine("      io_timeout   = {0}", wrt.io_timeout);
                        Console.WriteLine("      data         = {0}", data);
                    }
                    else if (msg.proc == Vxi11.DEVICE_READ)
                    {
                        Vxi11.DEVICE_READ_PARAMS red = server.ReceiveDeviceRead();
                        Console.WriteLine("== DEVICE_READ ==");
                        Console.WriteLine("      lid          = {0}", red.lid);
                        Console.WriteLine("      requestSize  = {0}", red.requestSize);
                        Console.WriteLine("      io_timeout   = {0}", red.io_timeout);
                        Console.WriteLine("      lock_timeout = {0}", red.lock_timeout);
                        Console.WriteLine("      flags        = {0}", red.flags);
                        Console.WriteLine("      termChar     = {0}", red.termChar);
                    }
                    else if (msg.proc == Vxi11.DEVICE_READSTB)
                    {
                        Vxi11.DEVICE_GENERIC_PARAMS gen = server.ReceiveGenericParams();
                        Console.WriteLine("== DEVICE_READSTB ==");
                        Console.WriteLine("      lid          = {0}", gen.lid);
                        Console.WriteLine("      flags        = {0}", gen.flags);
                        Console.WriteLine("      lock_timeout = {0}", gen.lock_timeout);
                        Console.WriteLine("      io_timeout   = {0}", gen.io_timeout);
                    }
                    else if (msg.proc == Vxi11.DEVICE_TRIGGER)
                    {
                        Vxi11.DEVICE_GENERIC_PARAMS gen = server.ReceiveGenericParams();
                        Console.WriteLine("== DEVICE_TRIGGER ==");
                        Console.WriteLine("      lid          = {0}", gen.lid);
                        Console.WriteLine("      flags        = {0}", gen.flags);
                        Console.WriteLine("      lock_timeout = {0}", gen.lock_timeout);
                        Console.WriteLine("      io_timeout   = {0}", gen.io_timeout);
                    }
                    else if (msg.proc == Vxi11.DEVICE_CLEAR)
                    {
                        Vxi11.DEVICE_GENERIC_PARAMS gen = server.ReceiveGenericParams();
                        Console.WriteLine("== DEVICE_CLEAR ==");
                        Console.WriteLine("      lid          = {0}", gen.lid);
                        Console.WriteLine("      flags        = {0}", gen.flags);
                        Console.WriteLine("      lock_timeout = {0}", gen.lock_timeout);
                        Console.WriteLine("      io_timeout   = {0}", gen.io_timeout);
                    }
                    else if (msg.proc == Vxi11.DEVICE_REMOTE)
                    {
                        Vxi11.DEVICE_GENERIC_PARAMS gen = server.ReceiveGenericParams();
                        Console.WriteLine("== DEVICE_REMOTE ==");
                        Console.WriteLine("      lid          = {0}", gen.lid);
                        Console.WriteLine("      flags        = {0}", gen.flags);
                        Console.WriteLine("      lock_timeout = {0}", gen.lock_timeout);
                        Console.WriteLine("      io_timeout   = {0}", gen.io_timeout);
                    }
                    else if (msg.proc == Vxi11.DEVICE_LOCAL)
                    {
                        Vxi11.DEVICE_GENERIC_PARAMS gen = server.ReceiveGenericParams();
                        Console.WriteLine("== DEVICE_LOCAL ==");
                        Console.WriteLine("      lid          = {0}", gen.lid);
                        Console.WriteLine("      flags        = {0}", gen.flags);
                        Console.WriteLine("      lock_timeout = {0}", gen.lock_timeout);
                        Console.WriteLine("      io_timeout   = {0}", gen.io_timeout);
                    }
                    else if (msg.proc == Vxi11.DEVICE_LOCK)
                    {
                        Vxi11.DEVICE_LOCK_PARAMS lck = server.ReceiveDeviceLock();
                        Console.WriteLine("== DEVICE_LOCK ==");
                        Console.WriteLine("      lid          = {0}", lck.lid);
                        Console.WriteLine("      flags        = {0}", lck.flags);
                        Console.WriteLine("      lock_timeout = {0}", lck.lock_timeout);
                    }
                    else if (msg.proc == Vxi11.DEVICE_UNLOCK)
                    {
                        long lnk = server.ReceiveDeviceLink();
                        Console.WriteLine("== DEVICE_UNLOCK ==");
                        Console.WriteLine("      device_link  = {0}", lnk);
                    }
                    else if (msg.proc == Vxi11.DEVICE_ENABLE_SRQ)
                    {
                        string handle;
                        Vxi11.DEVICE_ENABLE_SRQ_PARAMS ena = server.ReceiveDeviceEnableSrq(out handle);
                        Console.WriteLine("== DEVICE_ENABLE_SRQ ==");
                        Console.WriteLine("      lid          = {0}", ena.lid);
                        Console.WriteLine("      enable       = {0}", ena.enable);
                        Console.WriteLine("      handle       = {0}", handle);
                    }
                    else if (msg.proc == Vxi11.DEVICE_DOCMD)
                    {
                        byte[] data_in;
                        Vxi11.DEVICE_DOCMD_PARAMS dcm = server.ReceiveDeviceDoCmd(out data_in);
                        Console.WriteLine("== DEVICE_DOCMD ==");
                        Console.WriteLine("      lid           = {0}", dcm.lid);
                        Console.WriteLine("      flags         = {0}", dcm.flags);
                        Console.WriteLine("      io_timeout    = {0}", dcm.io_timeout);
                        Console.WriteLine("      lock_timeout  = {0}", dcm.lock_timeout);
                        Console.WriteLine("      cmd           = {0}", dcm.cmd);
                        Console.WriteLine("      network_order = {0}", dcm.network_order);
                        Console.WriteLine("      datasize      = {0}", dcm.datasize);
                    }
                    else if (msg.proc == Vxi11.DESTROY_LINK)
                    {
                        long lnk = server.ReceiveDeviceLink();
                        Console.WriteLine("== DESTROY_LINK ==");
                        Console.WriteLine("      device_link  = {0}", lnk);
                    }
                    else if (msg.proc == Vxi11.CREATE_INTR_CHAN)
                    {
                        Vxi11.CREATE_INTR_CHAN_PARAMS cic = server.ReceiveCreateIntrchan();
                        Console.WriteLine("== CREATE_INTR_CHAN ==");
                        Console.WriteLine("      hostaddr   = {0}", cic.hostaddr);
                        Console.WriteLine("      hostport   = {0}", cic.hostport);
                        Console.WriteLine("      prognum    = {0}", cic.prognum);
                        Console.WriteLine("      progvers   = {0}", cic.progvers);
                        Console.WriteLine("      progfamily = {0}", cic.progfamily);
                    }
                    else if (msg.proc == Vxi11.DESTROY_INTR_CHAN)
                    {
                        Console.WriteLine("== DESTROY_INTR_CHAN ==");
                    }
                    else if (msg.proc == Vxi11.DEVICE_ABORT)
                    {
                        long lnk = server.ReceiveDeviceLink();
                        Console.WriteLine("== DEVICE_ABORT ==");
                        Console.WriteLine("      device_link  = {0}", lnk);
                    }
                    else
                    {
                        server.Flush();
                        Console.WriteLine("== clear_buffer ==");
                    }
                }
                if (a == "3")
                {
                    server.ReplyCreateLink(123, 456, 789);
                    Console.WriteLine("== reply to create_link ==");
                }
                if (a == "4")
                {
                    Console.Write("  data_len? : ");
                    int data_len = Convert.ToInt32(Console.ReadLine());
                    server.ReplyDeviceWrite(data_len);
                    Console.WriteLine("== reply to device_write ==");
                }
                if (a == "5")
                {
                    server.ReplyDeviceRead(1, "XYZCO,246B,S000-0123-02,0");
                    Console.WriteLine("== reply to device_read ==");
                }
                if (a == "6")
                {
                    Console.Write("  stb? : ");
                    byte stb = Convert.ToByte(Console.ReadLine());
                    server.ReplyDeviceReadStb(stb);
                    Console.WriteLine("== reply to device_readstb ==");
                }
                if (a == "7")
                {
                    server.ReplyDeviceError(RPC.SUCCESS);
                    Console.WriteLine("== reply to device_trigger ==");
                }
                if (a == "8")
                {
                    server.ReplyDeviceError(RPC.SUCCESS);
                    Console.WriteLine("== reply to device_clear ==");
                }
                if (a == "9")
                {
                    server.ReplyDeviceError(RPC.SUCCESS);
                    Console.WriteLine("== reply to device_remote ==");
                }
                if (a == "10")
                {
                    server.ReplyDeviceError(RPC.SUCCESS);
                    Console.WriteLine("== reply to device_local ==");
                }
                if (a == "11")
                {
                    server.ReplyDeviceError(RPC.SUCCESS);
                    Console.WriteLine("== reply to device_lock ==");
                }
                if (a == "12")
                {
                    server.ReplyDeviceError(RPC.SUCCESS);
                    Console.WriteLine("== reply to device_unlock ==");
                }
                if (a == "13")
                {
                    server.ReplyDeviceError(RPC.SUCCESS);
                    Console.WriteLine("== reply to device_enable_srq ==");
                }
                if (a == "14")
                {
                    Console.Write("  data_in_len? : ");
                    int data_in_len = Convert.ToInt32(Console.ReadLine());
                    server.ReplyDeviceDoCmd(data_in_len);
                    Console.WriteLine("== reply to device_docmd ==");
                }
                if (a == "15")
                {
                    server.ReplyDeviceError(RPC.SUCCESS);
                    Console.WriteLine("== :reply to destroy_link ==");
                }
                if (a == "16")
                {
                    server.ReplyDeviceError(RPC.SUCCESS);
                    Console.WriteLine("== reply to create_intr_chan ==");
                }
                if (a == "17")
                {
                    server.ReplyDeviceError(RPC.SUCCESS);
                    Console.WriteLine("== reply to destroy_intr_chan ==");
                }
                if (a == "18")
                {
                    Console.WriteLine("  21:reply to device_abort");
                }
                if (a == "19")
                {
                    Console.WriteLine("  22:send device_intr_srq");
                }
                if (a == "20")
                {
                    Console.WriteLine("  23:receive abort message");
                }
                if (a == "21")
                {
                    Console.WriteLine("== create_interrupt_channel ==");
                }
                if (a == "22")
                {
                    Console.WriteLine("== close_interrupt_channel ==");
                }
                if (a == "23")
                {
                    Console.WriteLine("  26:unregister core channel with portmapper");
                }
                if (a == "24")
                {
                    Console.WriteLine("== close_coret_channel ==");
                }
                if (a == "25")
                {
                    Console.WriteLine("== close_abort_channel ==");
                }
                if (a == "26")
                {
                    Console.Write("  port number? : ");
                    int port = Convert.ToInt32(Console.ReadLine());
                    server.RunCoreChannel("127.0.0.1", port);
                }
                if (a == "27")
                {
                    server.Shutdown();
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
                    Console.WriteLine("  == Wait RPC ==");
                    RPC.RPC_MESSAGE_PARAMS msg = tcp_server.ReceiveMsg();
                    Console.WriteLine("    received--.");
                    Console.WriteLine("      xid     = {0}", msg.xid);
                    Console.WriteLine("      proc    = {0}", msg.proc);
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