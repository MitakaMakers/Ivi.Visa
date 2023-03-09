using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Ivi.Visa;
using TmctlAPINet;

namespace VXI11Net
{
    public class Clientconsole
    {
        public static void Main(string[] args)
        {
            bool isLoop = true;
            while (isLoop)
            {
                Console.WriteLine("Select Test target");
                Console.WriteLine("   1:Test VXI-11 Functions");
                Console.WriteLine("   2:Test VISA.NET Functions");
                Console.WriteLine("   3:Test TmctlAPINet Functions");
                Console.WriteLine(" E/Q:exit program");
                Console.WriteLine("");
                Console.Write("Input fuction number? : ");
                string a = new String(Console.ReadLine());
                if (a == "1")
                {
                    ClientConsole();
                }
                if (a == "2")
                {
                    VisaNetConsole();
                }
                if (a == "3")
                {
                    TmctlConsole();
                }
                if ((a == "Q") || (a == "q") || (a == "E") || (a == "e"))
                {
                    Console.WriteLine("== Exit program ==");
                    Environment.Exit(0);
                }
            }
        }
        public static void ClientConsole()
        {
            Socket? core = null;
            Socket? abort = null;
            Socket? interrupt = null;
            bool isLoop = true;
            while (isLoop)
            {
                Console.WriteLine("Select VXI-11 client Function");
                Console.WriteLine("   1:create RPC client (core channel.)");
                Console.WriteLine("   2:create RPC client (abort channel)");
                Console.WriteLine("   3:create RPC server (interrupt channel)");
                Console.WriteLine("   4:create_link");
                Console.WriteLine("   5:device_write");
                Console.WriteLine("   6:device_read");
                Console.WriteLine("   7:destroy_link");
                Console.WriteLine("   8:device_readstb");
                Console.WriteLine("   9:device_trigger");
                Console.WriteLine("  10:device_clear");
                Console.WriteLine("  11:device_remote");
                Console.WriteLine("  12:device_local");
                Console.WriteLine("  13:device_lock");
                Console.WriteLine("  14:device_unlock");
                Console.WriteLine("  15:device_enable_srq");
                Console.WriteLine("  16:device_docmd");
                Console.WriteLine("  17:create_intr_chan");
                Console.WriteLine("  18:destroy_intr_chan");
                Console.WriteLine("  19:device_abort");
                Console.WriteLine("  20:device_intr_srq");
                Console.WriteLine("  21:close RPC server (interrupt channel)");
                Console.WriteLine("  22:close RPC client (abort channel)");
                Console.WriteLine("  23:close RPC client (core channel.)");
                Console.WriteLine("   B:back to Main menu");
                Console.WriteLine(" E/Q:exit program");
                Console.WriteLine("");
                Console.Write("Input fuction number? : ");
                string a = new String(Console.ReadLine());
                if (a == "1")
                {
                    Console.Write("  IP address? : ");
                    string address = new String(Console.ReadLine());
                    Console.Write("  port number? : ");
                    int port = Convert.ToInt32(Console.ReadLine());
                    core = Client.create_rpc_client_core_channel(address, port);
                    Console.WriteLine("== create RPC client (core channel.) ==");
                    Console.WriteLine(" Call : create_rpc_client_core_channel : ret=0");
                }
                if (a == "2")
                {
                    Console.Write("  IP address? : ");
                    string address = new String(Console.ReadLine());
                    Console.Write("  port number? : ");
                    int port = Convert.ToInt32(Console.ReadLine());
                    abort = Client.create_rpc_client_abort_channel(address, port);
                    Console.WriteLine("== create RPC client (abort channel.) ==");
                    Console.WriteLine(" Call : create_rpc_client_abort_channel : ret=0");
                }
                if (a == "3")
                {
                    Console.Write("  IP address? : ");
                    string address = new String(Console.ReadLine());
                    Console.Write("  port number? : ");
                    int port = Convert.ToInt32(Console.ReadLine());
                    interrupt = Client.create_rpc_server_interrupt_channel(address, port);
                    Console.WriteLine("== create RPC server (interrupt channel.) ==");
                    Console.WriteLine(" Call : create_rpc_server_interrupt_channel : ret=0");
                }
                if (a == "4")
                {
                    if (core != null)
                    {
                        Console.Write("  xid? : ");
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  lock_timeout? : ");
                        int lock_timeout = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  clientId? : ");
                        int cliendId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  lockDevice? : ");
                        int lockDevice = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  handle? : ");
                        String handle = new String(Console.ReadLine());
                        int lid = 0;
                        int abortPort = 0;
                        int maxRecvSize = 0;
                        Client.create_link(core, xid, cliendId, lockDevice, lock_timeout, handle, out lid, out abortPort, out maxRecvSize);
                        Console.WriteLine("== create_link ==");
                        Console.WriteLine(" Call : create_link : ret=0");
                    }
                }
                if (a == "5")
                {
                    if (core != null)
                    {
                        Console.Write("  xid? : ");
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  lid? : ");
                        int lid = Convert.ToInt32(Console.ReadLine());
                        Client.Flags flags = Client.Flags.none;
                        Console.Write("  lock_timeout? : ");
                        int lock_timeout = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  io_timeout? : ");
                        int io_timeout = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  msg? : ");
                        String msg = new String(Console.ReadLine());
                        int data_len;
                        Client.device_write(core, xid, lid, flags, lock_timeout, io_timeout, msg, out data_len);
                        Console.WriteLine("== device_write ==");
                        Console.WriteLine(" Call : device_write : ret=0");
                    }
                }
                if (a == "6")
                {
                    if (core != null)
                    {
                        Console.Write("  xid? : ");
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  lid? : ");
                        int lid = Convert.ToInt32(Console.ReadLine());
                        Client.Flags flags = Client.Flags.none;
                        Console.Write("  lock_timeout? : ");
                        int lock_timeout = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  io_timeout? : ");
                        int io_timeout = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  requestSize? : ");
                        int requestSize = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  terminate character? : ");
                        int ch = Convert.ToInt32(Console.ReadLine());
                        Client.TermChar term = (Client.TermChar)Enum.ToObject(typeof(Client.TermChar), ch);
                        int reason;
                        byte[] data;
                        Client.device_read(core, xid, lid, requestSize, flags, lock_timeout, io_timeout, term, out reason, out data);
                        string str = Encoding.GetEncoding("ASCII").GetString(data);
                        StringBuilder buff = new StringBuilder(str);
                        int rlen = data.Length;
                        Console.WriteLine("== device_read ==");
                        Console.WriteLine(" Call : device_read : ret=0");
                    }
                }
                if (a == "7")
                {
                    if (core != null)
                    {
                        Console.Write("  xid? : ");
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  lid? : ");
                        int lid = Convert.ToInt32(Console.ReadLine());
                        Client.destroy_link(core, xid, lid);
                        Console.WriteLine("== destroy_link ==");
                        Console.WriteLine(" Call : destroy_link : ret=0");
                    }
                }
                if (a == "8")
                {
                    if (core != null)
                    {
                        Console.Write("  xid? : ");
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  lid? : ");
                        int lid = Convert.ToInt32(Console.ReadLine());
                        Client.Flags flags = Client.Flags.none;
                        Console.Write("  lock_timeout? : ");
                        int lock_timeout = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  io_timeout? : ");
                        int io_timeout = Convert.ToInt32(Console.ReadLine());
                        char stb;
                        Client.device_readstb(core, xid, lid, flags, lock_timeout, io_timeout, out stb);
                        Console.WriteLine("== device_readstb ==");
                        Console.WriteLine(" Call : device_readstb : ret=0");
                    }
                }
                if (a == "9")
                {
                    if (core != null)
                    {
                        Console.Write("  xid? : ");
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  lid? : ");
                        int lid = Convert.ToInt32(Console.ReadLine());
                        Client.Flags flags = Client.Flags.none;
                        Console.Write("  lock_timeout? : ");
                        int lock_timeout = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  io_timeout? : ");
                        int io_timeout = Convert.ToInt32(Console.ReadLine());
                        Client.device_trigger(core, xid, lid, flags, lock_timeout, io_timeout);
                        Console.WriteLine("== device_trigger ==");
                        Console.WriteLine(" Call : device_trigger : ret=0");
                    }
                }
                if (a == "10")
                {
                    if (core != null)
                    {
                        Console.Write("  xid? : ");
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  lid? : ");
                        int lid = Convert.ToInt32(Console.ReadLine());
                        Client.Flags flags = Client.Flags.none;
                        Console.Write("  lock_timeout? : ");
                        int lock_timeout = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  io_timeout? : ");
                        int io_timeout = Convert.ToInt32(Console.ReadLine());
                        Client.device_clear(core, xid, lid, flags, lock_timeout, io_timeout);
                        Console.WriteLine("== device_clear ==");
                        Console.WriteLine(" Call : device_clear : ret=0");
                    }
                }
                if (a == "11")
                {
                    if (core != null)
                    {
                        Console.Write("  xid? : ");
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  lid? : ");
                        int lid = Convert.ToInt32(Console.ReadLine());
                        Client.Flags flags = Client.Flags.none;
                        Console.Write("  lock_timeout? : ");
                        int lock_timeout = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  io_timeout? : ");
                        int io_timeout = Convert.ToInt32(Console.ReadLine());
                        Client.device_remote(core, xid, lid, flags, lock_timeout, io_timeout);
                        Console.WriteLine("== device_remote ==");
                        Console.WriteLine(" Call : device_remote : ret=0");
                    }
                }
                if (a == "12")
                {
                    if (core != null)
                    {
                        Console.Write("  xid? : ");
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  lid? : ");
                        int lid = Convert.ToInt32(Console.ReadLine());
                        Client.Flags flags = Client.Flags.none;
                        Console.Write("  lock_timeout? : ");
                        int lock_timeout = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  io_timeout? : ");
                        int io_timeout = Convert.ToInt32(Console.ReadLine());
                        Client.device_local(core, xid, lid, flags, lock_timeout, io_timeout);
                        Console.WriteLine("== device_local ==");
                        Console.WriteLine(" Call : device_local : ret=0");
                    }
                }
                if (a == "13")
                {
                    if (core != null)
                    {
                        Console.Write("  xid? : ");
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  lid? : ");
                        int lid = Convert.ToInt32(Console.ReadLine());
                        Client.Flags flags = Client.Flags.none;
                        Console.Write("  lock_timeout? : ");
                        int lock_timeout = Convert.ToInt32(Console.ReadLine());
                        Client.device_lock(core, xid, lid, flags, lock_timeout);
                        Console.WriteLine("== device_lock ==");
                        Console.WriteLine(" Call : device_lock : ret=0");
                    }
                }
                if (a == "14")
                {
                    if (core != null)
                    {
                        Console.Write("  xid? : ");
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  lid? : ");
                        int lid = Convert.ToInt32(Console.ReadLine());
                        Client.device_unlock(core, xid, lid);
                        Console.WriteLine("== device_unlock ==");
                        Console.WriteLine(" Call : device_unlock : ret=0");
                    }
                }
                if (a == "15")
                {
                    if (core != null)
                    {
                        Console.Write("  xid? : ");
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  lid? : ");
                        int lid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  enable? : ");
                        int enable = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  handle? : ");
                        string handle = new String(Console.ReadLine());
                        Client.device_enable_srq(core, xid, lid, enable, handle);
                        Console.WriteLine("== device_enable_srq ==");
                        Console.WriteLine(" Call : device_enable_srq : ret=0");
                    }
                }
                if (a == "16")
                {
                    if (core != null)
                    {
                        Console.Write("  xid? : ");
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  lid? : ");
                        int lid = Convert.ToInt32(Console.ReadLine());
                        Client.Flags flags = Client.Flags.none;
                        Console.Write("  lock_timeout? : ");
                        int lock_timeout = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  io_timeout? : ");
                        int io_timeout = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  cmd? : ");
                        int cmd = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  network_order? : ");
                        int network_order = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  datasize? : ");
                        int datasize = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  data? : ");
                        String str = new String(Console.ReadLine());
                        byte[] data_in = System.Text.Encoding.ASCII.GetBytes(str);
                        byte[] data_out;
                        Client.device_docmd(core, xid++, lid, flags, lock_timeout, io_timeout, cmd, network_order, datasize, data_in, out data_out);
                        Console.WriteLine("== device_docmd ==");
                        Console.WriteLine(" Call : device_docmd : ret=0");
                    }
                }
                if (a == "17")
                {
                    if (core != null)
                    {
                        Console.Write("  xid? : ");
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  host address? : ");
                        int hostaddr = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  host port? : ");
                        int hostport = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  program number? : ");
                        int prognum = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  program version? : ");
                        int progvers = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  program family? : ");
                        int progfamily = Convert.ToInt32(Console.ReadLine());
                        Client.create_intr_chan(core, xid, hostaddr, hostport, prognum, progvers, progfamily);
                        Console.WriteLine("== create_intr_chan ==");
                        Console.WriteLine(" Call : create_intr_chan : ret=0");
                    }
                }
                if (a == "18")
                {
                    if (core != null)
                    {
                        Console.Write("  xid? : ");
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Client.destroy_intr_chan(core, xid);
                        Console.WriteLine("== destroy_intr_chan ==");
                        Console.WriteLine(" Call : destroy_intr_chan : ret=0");
                    }
                }
                if (a == "19")
                {
                    if (abort != null)
                    {
                        Console.Write("  xid? : ");
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  lid? : ");
                        int lid = Convert.ToInt32(Console.ReadLine());
                        Client.Flags flags = Client.Flags.none;
                        Console.Write("  lock_timeout? : ");
                        int lock_timeout = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  io_timeout? : ");
                        int io_timeout = Convert.ToInt32(Console.ReadLine());
                        Client.device_abort(abort, xid, lid, flags, lock_timeout, io_timeout);
                        Console.WriteLine("== device_abort ==");
                        Console.WriteLine(" Call : device_abort : ret=0");
                    }
                }
                if (a == "20")
                {
                    if (interrupt != null)
                    {
                        Console.WriteLine("== device_intr_srq ==");
                        Console.WriteLine(" Call : device_intr_srq : ret=0");
                    }
                }
                if (a == "21")
                {
                    if (interrupt != null)
                    {
                        Client.close_rpc_server_interrupt_channel(interrupt);
                        Console.WriteLine("== close RPC server (interrupt channel) ==");
                        Console.WriteLine(" Call : close RPC server (interrupt channel) : ret=0");
                    }
                }
                if (a == "22")
                {
                    if (abort != null)
                    {
                        Client.close_rpc_client_abort_channel(abort);
                        Console.WriteLine("== close RPC client (abort channel) ==");
                        Console.WriteLine(" Call : close RPC client (abort channel) : ret=0");
                    }
                }
                if (a == "23")
                {
                    if (core != null)
                    {
                        Client.close_rpc_client_core_channel(core);
                        Console.WriteLine("== close RPC client (core channel) ==");
                        Console.WriteLine(" Call : close RPC client (core channel) : ret=0");
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

        public static void VisaNetConsole()
        {
            ResourceManager rm = new ResourceManager();
            Ivi.Visa.IMessageBasedSession? session = null;

            bool isLoop = true;
            while (isLoop)
            {
                Console.WriteLine("Select VISA.NET Function");
                Console.WriteLine("   1:GlobalResourceManager.Open");
                Console.WriteLine("   2:FormattedIO.WriteLine");
                Console.WriteLine("   3:FormattedIO.ReadLine");
                Console.WriteLine("   B:back to Main menu");
                Console.WriteLine(" E/Q:Exit program");
                Console.Write("Input fuction number? : ");
                string a = new String(Console.ReadLine());
                if (a == "1")
                {
                    Console.Write("  rsrc? : ");
                    string rsrc = new String(Console.ReadLine());
                    session = (IMessageBasedSession)Ivi.Visa.GlobalResourceManager.Open(rsrc);
                    Console.WriteLine("== GlobalResourceManager.Open ==");
                    Console.WriteLine(" Call : GlobalResourceManager.Open : ret=(0");
                }
                if (a == "2")
                {
                    if (session != null)
                    {
                        Console.Write("  msg? : ");
                        string msg = new String(Console.ReadLine());
                        session.FormattedIO.WriteLine(msg);
                        Console.WriteLine("== FormattedIO.WriteLine ==");
                        Console.WriteLine(" Call : FormattedIO.WriteLine : ret=0");
                    }
                }
                if (a == "3")
                {
                    if (session != null)
                    {
                        string msg = session.FormattedIO.ReadLine();
                        Console.WriteLine("== FormattedIO.ReadLine ==");
                        Console.WriteLine(" Call : FormattedIO.ReadLine : ret=0");
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
        public static void TmctlConsole()
        {
            bool isLoop = true;
            while (isLoop)
            {
                TMCTL tmctl = new TMCTL();
                Console.WriteLine("Select Tmctl Function");
                Console.WriteLine("   1:TmcInitialize");
                Console.WriteLine("   2:TmcFinish");
                Console.WriteLine("   3:TmcSend");
                Console.WriteLine("   4:TmcReceive");
                Console.WriteLine("   5:TmcSetRen");
                Console.WriteLine("   6:TmcDeviceClear");
                Console.WriteLine("   7:TmcDeviceTrigger");
                Console.WriteLine("   B:back to Main menu");
                Console.WriteLine(" E/Q:Exit program");
                Console.Write("Input fuction number? : ");
                string a = new String(Console.ReadLine());
                if (a == "1")
                {
                    Console.Write("  wire? : ");
                    int wire = Convert.ToInt32(Console.ReadLine());
                    Console.Write("  adr? : ");
                    string adr = new String(Console.ReadLine());
                    int id;
                    int re = tmctl.Initialize(wire, adr, out id);
                    Console.WriteLine("== TmcInitialize ==");
                    Console.WriteLine(" Call : TmcInitialize : ret=0,  id=0");
                }
                if (a == "2")
                {
                    Console.Write("  id? : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    int re = tmctl.Finish(id);
                    Console.ReadLine();
                    Console.WriteLine("== TmcFinish ==");
                    Console.WriteLine(" Call : TmcFinish : ret=0");
                }
                if (a == "3")
                {
                    Console.Write("  id? : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("  msg? : ");
                    string msg = new String(Console.ReadLine());
                    int ret = tmctl.Send(id, msg);
                    Console.WriteLine("== TmcSend ==");
                    Console.WriteLine(" Call : TmcSend : ret=0");
                }
                if (a == "4")
                {
                    Console.Write("  id? : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("  blen? : ");
                    int blen = Convert.ToInt32(Console.ReadLine());
                    StringBuilder buff = new StringBuilder(blen);
                    int rlen = 0;
                    int ret = tmctl.Receive(id, ref  buff ,blen, ref rlen);
                    Console.WriteLine("== TmcReceive ==");
                    Console.WriteLine(" Call : TmcReceive : ret=0,  id=0");
                }
                if (a == "5")
                {
                    Console.Write("  id? : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("  flag? : ");
                    int flag = Convert.ToInt32(Console.ReadLine());
                    int ret = tmctl.SetRen(id, flag);
                    Console.WriteLine("== TmcSetRen ==");
                    Console.WriteLine(" Call : TmcSetRen : ret=0,  id=0");
                }
                if (a == "6")
                {
                    Console.Write("  id? : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    int ret = tmctl.DeviceClear(id);
                    Console.WriteLine("== TmcDeviceClear ==");
                    Console.WriteLine(" Call : TmcDeviceClear : ret=0");
                }
                if (a == "7")
                {
                    Console.Write("  id? : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    int ret = tmctl.DeviceTrigger(id);
                    Console.WriteLine("== TmcDeviceTrigger ==");
                    Console.WriteLine(" Call : TmcDeviceTrigger : ret=0,  id=0");
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
