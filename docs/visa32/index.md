# Mm's visa32
## About
- Mm's visa32 is open source C# library to communicate test and measurement instruments.
- Mm's visa32 supports several communication protocols: VXI-11, HiSLIP and RawSokcet.
- Mm's visa32 runs on .Net Core 3 on Windows C ABI.
- Mm's visa32 supports several visa32 API

## Package files
- visa32.dll (for 64bit application)

## API
### Functions

|Functions|TCPIP::VXI-11|TCPIP::HiSLIP|TCPIP::SOCKET|
|----|----|----|----|
|ViStatus viOpenDefaultRM(ViPSession sesn)|Y|Y|Y|
|ViStatus viOpen(ViSession sesn, ViConstRsrc name, ViAccessMode mode, ViUInt32 timeout, ViPSession vi)|Y|Y|Y|
|ViStatus viGetAttribute(ViObject vi, ViAttr attrName, void _VI_PTR attrValue)|Y|Y|Y|
|ViStatus viSetAttribute(ViObject vi, ViAttr attrName, ViAttrState  attrValue)|Y|Y|Y|
|ViStatus viLock(ViSession vi, ViAccessMode lockType, ViUInt32 timeout, ViConstKeyId requestedKey, ViChar _VI_FAR accessKey[])|Y|Y|Y|
|ViStatus viUnlock(ViSession vi)|Y|Y|Y|
|ViStatus viEnableEvent(ViSession vi, ViEventType eventType, ViUInt16 mechanism, ViEventFilter context)|Y|Y|Y|
|ViStatus viDisableEvent(ViSession vi, ViEventType eventType, ViUInt16 mechanism)|Y|Y|Y|
|ViStatus viWaitOnEvent(ViSession vi, ViEventType inEventType, ViUInt32 timeout, ViPEventType outEventType, ViPEvent outContext)|Y|Y|Y|
|ViStatus viRead(ViSession vi, ViPBuf buf, ViUInt32 cnt, ViPUInt32 retCnt)|Y|Y|Y|
|ViStatus viWrite(ViSession vi, ViConstBuf buf, ViUInt32 cnt, ViPUInt32 retCnt)|Y|Y|Y|
|ViStatus viAssertTrigger(ViSession vi, ViUInt16 protocol)|Y|Y|Y|
|ViStatus viReadSTB(ViSession vi, ViPUInt16 status)|Y|Y|Y|
|ViStatus viClear(ViSession vi)|Y|Y|Y|
