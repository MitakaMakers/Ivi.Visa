using System;
using System.Xml;
using System.Data;
using TmctlAPINet;
using System.Runtime.InteropServices;

namespace tmctl
{
    public class tmctl
    {
        private static TMCTL tmc = new TMCTL();
        [DllExport]
        public static int TmcInitialize(int wire, IntPtr adr, IntPtr id)
        {
            return 1;
            //return tmc.Initialize(wire, adr, out id);
        }
        [DllExport]
        public static int TmcInitializeEx(int wire, IntPtr adr, IntPtr id, int tmo)
        {
            return 1;
        }
        [DllExport]
        public static int TmcSetIFC(int id, int tm)
        {
            return 2;
        }
        [DllExport]
        public static int TmcDeviceClear(int id)
        {
            return 3;
        }
        [DllExport]
        public static int TmcDeviceTrigger(int id)
        {
            return 4;
        }
        [DllExport]
        public static int TmcSend(int id, IntPtr msg)
        {
            return 5;
        }
        [DllExport]
        public static int TmcSendByLength(int id, IntPtr msg, int len)
        {
            return 6;
        }
        [DllExport]
        public static int TmcSendSetup(int id)
        {
            System.Console.WriteLine("This is a C++/CLI program.");
            return 0;
        }
        [DllExport]
        public static int TmcSendOnly(int id, IntPtr msg, int len, int end)
        {
            System.Console.WriteLine("This is a C++/CLI program.");
            return 0;
        }
        [DllExport]
        public static int TmcReceive(int id, IntPtr buff, int blen, IntPtr rlen)
        {
            System.Console.WriteLine("This is a C++/CLI program.");
            return 0;
        }
        [DllExport]
        public static int TmcReceiveSetup(int id)
        {
            System.Console.WriteLine("This is a C++/CLI program.");
            return 0;
        }
        [DllExport]
        public static int TmcReceiveOnly(int id, IntPtr buff, int blen, IntPtr rlen)
        {
            System.Console.WriteLine("This is a C++/CLI program.");
            return 0;
        }
        [DllExport]
        public static int TmcReceiveBlockHeader(int id, IntPtr len)
        {
            System.Console.WriteLine("This is a C++/CLI program.");
            return 0;
        }
        [DllExport]
        public static int TmcReceiveBlockData(int id, IntPtr buff, int blen, IntPtr rlen, IntPtr end)
        {
            System.Console.WriteLine("This is a C++/CLI program.");
            return 0;
        }
        [DllExport]
        public static int TmcCheckEnd(int id)
        {
            System.Console.WriteLine("This is a C++/CLI program.");
            return 0;
        }
        [DllExport]
        public static int TmcSetCmd(int id, IntPtr cmd)
        {
            System.Console.WriteLine("This is a C++/CLI program.");
            return 0;
        }
        [DllExport]
        public static int TmcSetRen(int id, int flag)
        {
            System.Console.WriteLine("This is a C++/CLI program.");
            return 0;
        }
        [DllExport]
        public static int TmcGetLastError(int id)
        {
            System.Console.WriteLine("This is a C++/CLI program.");
            return 0;
        }
    }
}
