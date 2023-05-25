using System;

namespace Mm
{
    using ViConstBuf = IntPtr;
    using ViConstRsrc = IntPtr;
    using ViPBuf = IntPtr;
    using ViPEvent = IntPtr;
    using ViPEventType = IntPtr;
    using ViPSession = IntPtr;
    using ViPUInt16 = IntPtr;
    using ViPUInt32 = IntPtr;
    using _VI_PTR = IntPtr;

    using ViAccessMode = UInt32;
    using ViAttr = UInt32;
    using ViAttrState = IntPtr;
    using ViChar = Char;
    using ViConstKeyId = IntPtr;
    using ViEventType = UInt32; 
    using ViEventFilter = UInt32;
    using ViObject = UInt32;
    using ViSession = UInt32;
    using ViStatus = Int32;
    using ViUInt16 = UInt16;
    using ViUInt32 = UInt32;

    public class visa32
    {
        [DllExport]
        public static ViStatus viOpenDefaultRM(ViPSession sesn)
        {
            return 1;
        }
        [DllExport]
        public static ViStatus viOpen(ViSession sesn, ViConstRsrc name, ViAccessMode mode, ViUInt32 timeout, ViPSession vi)
        {
            return 2;
        }
        [DllExport]
        public static ViStatus viGetAttribute(ViObject vi, ViAttr attrName, _VI_PTR attrValue)
        {
            return 3;
        }
        [DllExport]
        public static ViStatus viSetAttribute(ViObject vi, ViAttr attrName, ViAttrState attrValue)
        {
            return 4;
        }
        [DllExport]
        public static ViStatus viLock(ViSession vi, ViAccessMode lockType, ViUInt32 timeout, ViConstKeyId requestedKey, ViChar accessKey)
        {
            return 5;
        }
        [DllExport]
        public static ViStatus viUnlock(ViSession vi)
        {
            return 6;
        }
        [DllExport]
        public static ViStatus viEnableEvent(ViSession vi, ViEventType eventType, ViUInt16 mechanism, ViEventFilter context)
        {
            return 7;
        }
        [DllExport]
        public static ViStatus viDisableEvent(ViSession vi, ViEventType eventType, ViUInt16 mechanism)
        {
            return 8;
        }
        [DllExport]
        public static ViStatus viWaitOnEvent(ViSession vi, ViEventType inEventType, ViUInt32 timeout, ViPEventType outEventType, ViPEvent outContext)
        {
            return 9;
        }
        [DllExport]
        public static ViStatus viRead(ViSession vi, ViPBuf buf, ViUInt32 cnt, ViPUInt32 retCnt)
        {
            return 10;
        }
        [DllExport]
        public static ViStatus viWrite(ViSession vi, ViConstBuf buf, ViUInt32 cnt, ViPUInt32 retCnt)
        {
            return 11;
        }
        [DllExport]
        public static ViStatus viAssertTrigger(ViSession vi, ViUInt16 protocol)
        {
            return 12;
        }
        [DllExport]
        public static ViStatus viReadSTB(ViSession vi, ViPUInt16 status)
        {
            return 13;
        }
        [DllExport]
        public static ViStatus viClear(ViSession vi)
        {
            return 14;
        }
    }
}
