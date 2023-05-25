using System;
using System.Runtime.InteropServices;

namespace Mm
{
    public static class tmctl
    {
        [DllExport(CallingConvention = CallingConvention.StdCall)]
        public static int TmInitialize(int wire, IntPtr adr, IntPtr id)
        {
            //string str = Marshal.PtrToStringUni(adr);
            //return (IntPtr)str.Length;
            return 1;
        }

        [DllExport(CallingConvention = CallingConvention.StdCall)]
        public static int TmFinish( int id )
        {
            return 2;
        }

        [DllExport(CallingConvention = CallingConvention.StdCall)]
        public static int TmSetTimeout( int id, int tmo )
        {
            return 3;
        }

        [DllExport(CallingConvention = CallingConvention.StdCall)]
        public static int TmSetTerm( int id, int eos, int eot )
        {
            return 4;
        }

        [DllExport(CallingConvention = CallingConvention.StdCall)]
        public static int TmSend( int id, IntPtr msg )
        {
//            string str = Marshal.PtrToStringUni(msg);
            return 5;
        }

        [DllExport(CallingConvention = CallingConvention.StdCall)]
        public static int TmReceive( int id, IntPtr buff, int blen, IntPtr rlen )
        {
      //      var str = $"Hello {name}";
//            Marshal.Copy(buff, rlen)
  //          var buff = new UnmanagedString(str, UnmanagedString.SType.Ansi);
    //        return unmanagedStr;
            return 6;
        }

        [DllExport(CallingConvention = CallingConvention.StdCall)]
        public static int TmReceiveOnly( int id, IntPtr buff, int blen, IntPtr rlen )
        {
            return 7;
        }

        [DllExport(CallingConvention = CallingConvention.StdCall)]
        public static int TmReceiveBlockHeader( int id, IntPtr length )
        {
            return 8;
        }

        [DllExport(CallingConvention = CallingConvention.StdCall)]
        public static int TmReceiveBlockData( int id, IntPtr buff, int blen, IntPtr rlen, IntPtr end )
        {
            return 9;
        }

        [DllExport(CallingConvention = CallingConvention.StdCall)]
        public static int TmCheckEnd( int id )
        {
            return 10;
        }
        [DllExport(CallingConvention = CallingConvention.StdCall)]
        public static int TmGetLastError( int id )
        {
            return 11;
        }

        [DllExport(CallingConvention = CallingConvention.StdCall)]
        public static int TmSetRen( int id, int flag )
        {
            return 12;
        }

        [DllExport(CallingConvention = CallingConvention.StdCall)]
        public static int TmDeviceClear( int id )
        {
            return 13;
        }
    }
}
