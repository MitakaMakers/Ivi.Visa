using System.Net;
using System.Net.Sockets;
using System.Text;
using Ivi.Visa.Interop;
using TmctlAPINet;

namespace VXI11Net
{
    public class Clientconsole
    {
        public static void Main(string[] args)
        {
            bool isLoop = true;
            if (isLoop)
            {
                Console.WriteLine("Select Test target");
                Console.WriteLine("   1:Test VXI-11 Functions");
                Console.WriteLine("   2:Test VISA Functions");
                Console.WriteLine("   3:Test Tmctl Functions");
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
            if (isLoop)
            {
                Socket? socket = null;
                Console.WriteLine("Select VXI-11 client Function");
                Console.WriteLine("   1:create RPC client (core channel.)");
                Console.WriteLine("   2:create RPC client (abort chan., optional)");
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
                Console.WriteLine("  22:close RPC client (abort chan., optional)");
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
                        int xid = 123;
                        int lock_timeout = 456;
                        int cliendId = 0;
                        int lockDevice = 0;
                        string handle = "inst0";
                        int lid = 0;
                        int abortPort = 0;
                        int maxRecvSize = 0;
                        Client.create_link(socket, xid++, cliendId, lockDevice, lock_timeout, handle, out lid, out abortPort, out maxRecvSize);
                    }
                }
                if (a == "5")
                {
                    if (socket != null)
                    {
                        int xid = 123;
                        int lock_timeout = 456;
                        int io_timeout = 789;
                        int flags = 0;
                        int lid = 0;
                        string msg = "*IDN?";
                        int data_len;
                        Client.device_write(socket, xid++, lid, flags, lock_timeout, io_timeout, msg, out data_len);
                    }
                }
                if (a == "6")
                {
                    if (socket != null)
                    {
                        int xid = 123;
                        int lock_timeout = 456;
                        int io_timeout = 789;
                        int flags = 0;
                        int lid = 0;
                        int requestSize = 1000;
                        int termchar = 10;
                        int reason = 0;
                        byte[] data;
                        Client.device_read(socket, xid++, lid, requestSize, flags, lock_timeout, io_timeout, termchar, out reason, out data);
                        string str = Encoding.GetEncoding("ASCII").GetString(data);
                        StringBuilder buff = new StringBuilder(str);
                        int rlen = data.Length;
                    }
                }
                if (a == "7")
                {
                    if (socket != null)
                    {
                        int xid = 123;
                        int lid = 0;
                        Client.destroy_link(socket, xid++, lid);
                    }
                }
                if (a == "8")
                {
                }
                if (a == "9")
                {
                }
                if (a == "10")
                {
                }
                if (a == "11")
                {
                }
                if (a == "12")
                {
                }
                if (a == "13")
                {
                }
                if (a == "14")
                {
                }
                if (a == "15")
                {
                }
                if (a == "16")
                {
                }
                if (a == "17")
                {
                }
                if (a == "18")
                {
                }
                if (a == "19")
                {
                }
                if (a == "20")
                {
                }
                if (a == "21")
                {
                }
                if (a == "22")
                {
                }
                if (a == "23")
                {
                    if (socket != null)
                    {
                        socket.Close();
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
            if (isLoop)
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
                    Console.ReadLine();
                    Console.WriteLine("==viOpenDefaultRM==");
                    Console.WriteLine(" Call : viOpenDefaultRM : ret=0");
                }
                if (a == "2")
                {
                    Console.ReadLine();
                    Console.WriteLine("==viOpen==");
                    Console.WriteLine(" Call : viOpen : ret=0");
                }
                if (a == "3")
                {
                    Console.ReadLine();
                    Console.WriteLine("==viClose==");
                    Console.WriteLine(" Call : viClose : ret=0");
                }
                if (a == "4")
                {
                    Console.ReadLine();
                    Console.WriteLine("==viWrite==");
                    Console.WriteLine(" Call : viWrite : retCnt=5 ret=0");
                }
                if (a == "5")
                {
                    Console.ReadLine();
                    Console.WriteLine("==viRead==");
                    Console.WriteLine(" Call : viRead : retCnt=32 ret=0");
                    Console.WriteLine(" Response");
                    Console.WriteLine("        Message=XYZCO,246B,S000-0123-02,0");
                }
                if (a == "6")
                {
                    Console.ReadLine();
                    Console.WriteLine("==viAssertTrigger==");
                    Console.WriteLine(" Call : viAssertTrigger : ret=0");
                }
                if (a == "7")
                {
                    Console.ReadLine();
                    Console.WriteLine("==viReadSTB==");
                    Console.WriteLine(" Call : viReadSTB : ret=0");
                    Console.WriteLine(" Response");
                    Console.WriteLine("        status=68(0x44)");
                }
                if (a == "8")
                {
                    Console.ReadLine();
                    Console.WriteLine("==viClear==");
                    Console.WriteLine(" Call : viClear : ret=0");
                }
                if (a == "9")
                {
                    Console.ReadLine();
                    Console.WriteLine("==viGpibControlREN==");
                    Console.WriteLine(" Call : viGpibControlREN : ret=0");
                }
                if (a == "100")
                {
                    ResourceManager rm = new ResourceManager();
                    FormattedIO488 inst = new FormattedIO488();

                    string deviceResource = "TCPIP::XXX.XXX.XXX.XXX::INSTR";

                    inst.IO = (IMessage)rm.Open(deviceResource, AccessMode.NO_LOCK, 0, "");
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
            if (isLoop)
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
                    Console.WriteLine("==TmcInitialize==");
                    Console.WriteLine(" Call : TmcInitialize : ret=0,  id=0");
                }
                if (a == "2")
                {
                    Console.ReadLine();
                    Console.WriteLine("==TmcFinish==");
                    Console.WriteLine(" Call : TmcFinish : ret=0");
                }
                if (a == "3")
                {
                    Console.ReadLine();
                    Console.WriteLine("==TmcSend==");
                    Console.WriteLine(" Call : TmcSend : ret=0");
                }
                if (a == "4")
                {
                }
                if (a == "5")
                {
                }
                if (a == "6")
                {
                    Console.ReadLine();
                    Console.WriteLine("==TmcDeviceClear==");
                    Console.WriteLine(" Call : TmcDeviceClear : ret=0");
                }
                if (a == "7")
                {
                }
                if (a == "9")
                {
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
