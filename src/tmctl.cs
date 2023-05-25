using System;

namespace Mm
{
    public class tmctl
    {
        [DllExport]
        public static int TmcInitialize(int wire, IntPtr adr, IntPtr id)
        {
            //string str = Marshal.PtrToStringUni(adr);
            //return (IntPtr)str.Length;
            return 1;
        }

        [DllExport]
        public static int TmcFinish( int id )
        {
            return 2;
        }

        [DllExport]
        public static int TmcSetTimeout( int id, int tmo )
        {
            return 3;
        }

        [DllExport]
        public static int TmcSetTerm( int id, int eos, int eot )
        {
            return 4;
        }

        [DllExport]
        public static int TmcSend( int id, IntPtr msg )
        {
//            string str = Marshal.PtrToStringUni(msg);
            return 5;
        }

        [DllExport]
        public static int TmcReceive( int id, IntPtr buff, int blen, IntPtr rlen )
        {
      //      var str = $"Hello {name}";
//            Marshal.Copy(buff, rlen)
  //          var buff = new UnmanagedString(str, UnmanagedString.SType.Ansi);
    //        return unmanagedStr;
            return 6;
        }

        [DllExport]
        public static int TmcReceiveOnly( int id, IntPtr buff, int blen, IntPtr rlen )
        {
            return 7;
        }

        [DllExport]
        public static int TmcReceiveBlockHeader( int id, IntPtr length )
        {
            return 8;
        }

        [DllExport]
        public static int TmcReceiveBlockData( int id, IntPtr buff, int blen, IntPtr rlen, IntPtr end )
        {
            return 9;
        }

        [DllExport]
        public static int TmcCheckEnd( int id )
        {
            return 10;
        }
        [DllExport]
        public static int TmcGetLastError( int id )
        {
            return 11;
        }

        [DllExport]
        public static int TmcSetRen( int id, int flag )
        {
            return 12;
        }

        [DllExport]
        public static int TmcDeviceClear( int id )
        {
            return 13;
        }
    }
}
