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
                Console.WriteLine("   2:Test VISA.Net Functions");
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
                    VisaConsole();
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
            bool isLoop = true;
            while (isLoop)
            {
                Socket? socket = null;
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
                    IPHostEntry ipHostInfo = Dns.GetHostEntry(address);
                    IPAddress ipAddress = ipHostInfo.AddressList[0];
                    IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);
                    socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    socket.Connect(remoteEP);
                    socket.NoDelay = true;
                }
                if (a == "2")
                {
                }
                if (a == "3")
                {
                }
                if (a == "4")
                {
                    if (socket != null)
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
                        Client.create_link(socket, xid, cliendId, lockDevice, lock_timeout, handle, out lid, out abortPort, out maxRecvSize);
                        Console.WriteLine("== create_link ==");
                        Console.WriteLine(" Call : create_link : ret=0");
                    }
                }
                if (a == "5")
                {
                    if (socket != null)
                    {
                        Console.Write("  xid? : ");
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  lid? : ");
                        int lid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  flags? : ");
                        int flags = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  lock_timeout? : ");
                        int lock_timeout = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  io_timeout? : ");
                        int io_timeout = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  msg? : ");
                        String msg = new String(Console.ReadLine());
                        int data_len;
                        Client.device_write(socket, xid, lid, flags, lock_timeout, io_timeout, msg, out data_len);
                        Console.WriteLine("== device_write ==");
                        Console.WriteLine(" Call : device_write : ret=0");
                    }
                }
                if (a == "6")
                {
                    if (socket != null)
                    {
                        Console.Write("  xid? : ");
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  lid? : ");
                        int lid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  flags? : ");
                        int flags = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  lock_timeout? : ");
                        int lock_timeout = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  io_timeout? : ");
                        int io_timeout = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  requestSize? : ");
                        int requestSize = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  termchar? : ");
                        int termchar = Convert.ToInt32(Console.ReadLine());
                        int reason = 0;
                        byte[] data;
                        Client.device_read(socket, xid, lid, requestSize, flags, lock_timeout, io_timeout, termchar, out reason, out data);
                        string str = Encoding.GetEncoding("ASCII").GetString(data);
                        StringBuilder buff = new StringBuilder(str);
                        int rlen = data.Length;
                        Console.WriteLine("== device_read ==");
                        Console.WriteLine(" Call : device_read : ret=0");
                    }
                }
                if (a == "7")
                {
                    if (socket != null)
                    {
                        Console.Write("  xid? : ");
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  lid? : ");
                        int lid = Convert.ToInt32(Console.ReadLine());
                        Client.destroy_link(socket, xid++, lid);
                        Console.WriteLine("== destroy_link ==");
                        Console.WriteLine(" Call : destroy_link : ret=0");
                    }
                }
                if (a == "8")
                {
                    if (socket != null)
                    {
                        Console.Write("  xid? : ");
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  lid? : ");
                        int lid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  flags? : ");
                        int flags = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  lock_timeout? : ");
                        int lock_timeout = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  io_timeout? : ");
                        int io_timeout = Convert.ToInt32(Console.ReadLine());
                        char stb;
                        Client.device_readstb(socket, xid, lid, flags, lock_timeout, io_timeout, out stb);
                        Console.WriteLine("== device_readstb ==");
                        Console.WriteLine(" Call : device_readstb : ret=0");
                    }
                }
                if (a == "9")
                {
                    if (socket != null)
                    {
                        Console.Write("  xid? : ");
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  lid? : ");
                        int lid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  flags? : ");
                        int flags = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  lock_timeout? : ");
                        int lock_timeout = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  io_timeout? : ");
                        int io_timeout = Convert.ToInt32(Console.ReadLine());
                        Client.device_trigger(socket, xid, lid, flags, lock_timeout, io_timeout);
                        Console.WriteLine("== device_trigger ==");
                        Console.WriteLine(" Call : device_trigger : ret=0");
                    }
                }
                if (a == "10")
                {
                    if (socket != null)
                    {
                        Console.Write("  xid? : ");
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  lid? : ");
                        int lid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  flags? : ");
                        int flags = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  lock_timeout? : ");
                        int lock_timeout = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  io_timeout? : ");
                        int io_timeout = Convert.ToInt32(Console.ReadLine());
                        Client.device_clear(socket, xid, lid, flags, lock_timeout, io_timeout);
                        Console.WriteLine("== device_clear ==");
                        Console.WriteLine(" Call : device_clear : ret=0");
                    }
                }
                if (a == "11")
                {
                    if (socket != null)
                    {
                        Console.Write("  xid? : ");
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  lid? : ");
                        int lid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  flags? : ");
                        int flags = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  lock_timeout? : ");
                        int lock_timeout = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  io_timeout? : ");
                        int io_timeout = Convert.ToInt32(Console.ReadLine());
                        Client.device_remote(socket, xid, lid, flags, lock_timeout, io_timeout);
                        Console.WriteLine("== device_remote ==");
                        Console.WriteLine(" Call : device_remote : ret=0");
                    }
                }
                if (a == "12")
                {
                    if (socket != null)
                    {
                        Console.Write("  xid? : ");
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  lid? : ");
                        int lid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  flags? : ");
                        int flags = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  lock_timeout? : ");
                        int lock_timeout = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  io_timeout? : ");
                        int io_timeout = Convert.ToInt32(Console.ReadLine());
                        Client.device_local(socket, xid, lid, flags, lock_timeout, io_timeout);
                        Console.WriteLine("== device_local ==");
                        Console.WriteLine(" Call : device_local : ret=0");
                    }
                }
                if (a == "13")
                {
                    if (socket != null)
                    {
                        Console.Write("  xid? : ");
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  lid? : ");
                        int lid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  flags? : ");
                        int flags = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  lock_timeout? : ");
                        int lock_timeout = Convert.ToInt32(Console.ReadLine());
                        Client.device_lock(socket, xid, lid, flags, lock_timeout);
                        Console.WriteLine("== device_lock ==");
                        Console.WriteLine(" Call : device_lock : ret=0");
                    }
                }
                if (a == "14")
                {
                    if (socket != null)
                    {
                        Console.Write("  xid? : ");
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  lid? : ");
                        int lid = Convert.ToInt32(Console.ReadLine());
                        Client.device_unlock(socket, xid, lid);
                        Console.WriteLine("== device_unlock ==");
                        Console.WriteLine(" Call : device_unlock : ret=0");
                    }
                }
                if (a == "15")
                {
                    if (socket != null)
                    {
                        Console.Write("  xid? : ");
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  lid? : ");
                        int lid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  enable? : ");
                        int enable = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  handle? : ");
                        string handle = new String(Console.ReadLine());
                        Client.device_enable_srq(socket, xid, lid, enable, handle);
                        Console.WriteLine("== device_enable_srq ==");
                        Console.WriteLine(" Call : device_enable_srq : ret=0");
                    }
                }
                if (a == "16")
                {
                    if (socket != null)
                    {
                        Console.Write("  xid? : ");
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  lid? : ");
                        int lid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  flags? : ");
                        int flags = Convert.ToInt32(Console.ReadLine());
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
                        byte[] data = System.Text.Encoding.ASCII.GetBytes(str);
                        Client.device_docmd(socket, xid++, lid, flags, lock_timeout, io_timeout, cmd, network_order, datasize, data);
                        Console.WriteLine("== device_docmd ==");
                        Console.WriteLine(" Call : device_docmd : ret=0");
                    }
                }
                if (a == "17")
                {
                    if (socket != null)
                    {
                        Console.Write("  xid? : ");
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  hostaddr? : ");
                        int hostaddr = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  hostport? : ");
                        int hostport = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  prognum? : ");
                        int prognum = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  progvers? : ");
                        int progvers = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  progfamily? : ");
                        int progfamily = Convert.ToInt32(Console.ReadLine());
                        Client.create_intr_chan(socket, xid, hostaddr, hostport, prognum, progvers, progfamily);
                        Console.WriteLine("== create_intr_chan ==");
                        Console.WriteLine(" Call : create_intr_chan : ret=0");
                    }
                }
                if (a == "18")
                {
                    if (socket != null)
                    {
                        Console.Write("  xid? : ");
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Client.destroy_intr_chan(socket, xid);
                        Console.WriteLine("== destroy_intr_chan ==");
                        Console.WriteLine(" Call : destroy_intr_chan : ret=0");
                    }
                }
                if (a == "19")
                {
                    if (socket != null)
                    {
                        Console.Write("  xid? : ");
                        int xid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  lid? : ");
                        int lid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  flags? : ");
                        int flags = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  lock_timeout? : ");
                        int lock_timeout = Convert.ToInt32(Console.ReadLine());
                        Console.Write("  io_timeout? : ");
                        int io_timeout = Convert.ToInt32(Console.ReadLine());
                        Client.device_abort(socket, xid, lid, flags, lock_timeout, io_timeout);
                        Console.WriteLine("== device_abort ==");
                        Console.WriteLine(" Call : device_abort : ret=0");
                    }
                }
                if (a == "20")
                {
                    if (socket != null)
                    {
                        Console.WriteLine("== device_intr_srq ==");
                        Console.WriteLine(" Call : device_intr_srq : ret=0");
                    }
                }
                if (a == "21")
                {
                    if (socket != null)
                    {
                        Console.WriteLine("== close RPC server (interrupt channel) ==");
                        Console.WriteLine(" Call : close RPC server (interrupt channel) : ret=0");
                    }
                }
                if (a == "22")
                {
                    if (socket != null)
                    {
                        Console.WriteLine("== close RPC client (abort channel) ==");
                        Console.WriteLine(" Call : close RPC client (abort channel) : ret=0");
                    }
                }
                if (a == "23")
                {
                    if (socket != null)
                    {
                        socket.Close();
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

        public static void VisaConsole()
        {
            bool isLoop = true;
            while (isLoop)
            {
                Console.WriteLine("Select VISA Function");
                Console.WriteLine("   1:viOpenDefaultRM");
                Console.WriteLine("   2:viOpen");
                Console.WriteLine("   3:viClose");
                Console.WriteLine("   4:viWrite");
                Console.WriteLine("   5:viRead");
                Console.WriteLine("   6:viAssertTrigger");
                Console.WriteLine("   7:viReadSTB");
                Console.WriteLine("   8:viClear");
                Console.WriteLine("   9:viGpibControlREN");
                Console.WriteLine("   B:back to Main menu");
                Console.WriteLine(" E/Q:Exit program");
                Console.Write("Input fuction number? : ");
                string a = new String(Console.ReadLine());
                if (a == "1")
                {
                    Console.WriteLine("==viOpenDefaultRM==");
                    Console.WriteLine(" Call : viOpenDefaultRM : ret=0");
                }
                if (a == "2")
                {
                    Console.WriteLine("== viOpen ==");
                    Console.WriteLine(" Call : viOpen : ret=0");
                }
                if (a == "3")
                {
                    Console.WriteLine("== viClose ==");
                    Console.WriteLine(" Call : viClose : ret=0");
                }
                if (a == "4")
                {
                    Console.WriteLine("== viWrite ==");
                    Console.WriteLine(" Call : viWrite : retCnt=5 ret=0");
                }
                if (a == "5")
                {
                    Console.WriteLine("== viRead ==");
                    Console.WriteLine(" Call : viRead : retCnt=32 ret=0");
                    Console.WriteLine(" Response");
                    Console.WriteLine("        Message=XYZCO,246B,S000-0123-02,0");
                }
                if (a == "6")
                {
                    Console.WriteLine("== viAssertTrigger ==");
                    Console.WriteLine(" Call : viAssertTrigger : ret=0");
                }
                if (a == "7")
                {
                    Console.WriteLine("== viReadSTB ==");
                    Console.WriteLine(" Call : viReadSTB : ret=0");
                    Console.WriteLine(" Response");
                    Console.WriteLine("        status=68(0x44)");
                }
                if (a == "8")
                {
                    Console.WriteLine("== viClear ==");
                    Console.WriteLine(" Call : viClear : ret=0");
                }
                if (a == "9")
                {
                    Console.WriteLine("== viGpibControlREN ==");
                    Console.WriteLine(" Call : viGpibControlREN : ret=0");
                }
                if (a == "100")
                {
                    ResourceManager rm = new ResourceManager();
                    FormattedIO488 inst = new FormattedIO488();

                    string deviceResource = "TCPIP::XXX.XXX.XXX.XXX::INSTR";

                    inst.IO = (IMessage)rm.Open(deviceResource, AccessMode.None, 0, "");
                    inst.IO.Timeout = 10000;
                    inst.WriteString("*IDN?");
                    string returnStr = inst.ReadString();
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
                    Console.WriteLine("== TmcInitialize ==");
                    Console.WriteLine(" Call : TmcInitialize : ret=0,  id=0");
                }
                if (a == "2")
                {
                    Console.ReadLine();
                    Console.WriteLine("== TmcFinish ==");
                    Console.WriteLine(" Call : TmcFinish : ret=0");
                }
                if (a == "3")
                {
                    Console.ReadLine();
                    Console.WriteLine("== TmcSend ==");
                    Console.WriteLine(" Call : TmcSend : ret=0");
                }
                if (a == "4")
                {
                    Console.WriteLine("== TmcReceive ==");
                    Console.WriteLine(" Call : TmcReceive : ret=0,  id=0");
                }
                if (a == "5")
                {
                    Console.WriteLine("== TmcSetRen ==");
                    Console.WriteLine(" Call : TmcSetRen : ret=0,  id=0");
                }
                if (a == "6")
                {
                    Console.ReadLine();
                    Console.WriteLine("== TmcDeviceClear ==");
                    Console.WriteLine(" Call : TmcDeviceClear : ret=0");
                }
                if (a == "7")
                {
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
