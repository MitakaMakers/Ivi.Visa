

- Enumerations
- Functions
- Structures

## Functions
|Functions||
|----|----|
|ViStatus viOpenDefaultRM(ViPSession sesn)||
|ViStatus viOpen(ViSession sesn, ViConstRsrc name, ViAccessMode mode, ViUInt32 timeout, ViPSession vi)||
|ViStatus viGetAttribute(ViObject vi, ViAttr attrName, void _VI_PTR attrValue)||
|ViStatus viSetAttribute(ViObject vi, ViAttr attrName, ViAttrState  attrValue)||
|ViStatus viLock(ViSession vi, ViAccessMode lockType, ViUInt32 timeout, ViConstKeyId requestedKey, ViChar _VI_FAR accessKey[])||
|ViStatus viUnlock(ViSession vi)||
|ViStatus viEnableEvent(ViSession vi, ViEventType eventType, ViUInt16 mechanism, ViEventFilter context)||
|ViStatus viDisableEvent(ViSession vi, ViEventType eventType, ViUInt16 mechanism)||
|ViStatus viWaitOnEvent(ViSession vi, ViEventType inEventType, ViUInt32 timeout, ViPEventType outEventType, ViPEvent outContext)||
|ViStatus viRead(ViSession vi, ViPBuf buf, ViUInt32 cnt, ViPUInt32 retCnt)||
|ViStatus viWrite(ViSession vi, ViConstBuf buf, ViUInt32 cnt, ViPUInt32 retCnt)||
|ViStatus viAssertTrigger(ViSession vi, ViUInt16 protocol)||
|ViStatus viReadSTB(ViSession vi, ViPUInt16 status)||
|ViStatus viClear(ViSession vi)||
