# Mm.visa32 implemented functions

|No.|Functions|TCPIP::VXI-11|TCPIP::HiSLIP|TCPIP::SOCKET|
|----|----|----|----|----|
|1|ViStatus viGetDefaultRM(ViPSession sesn)|N|N|N|
|2|ViStatus viOpenDefaultRM(ViPSession sesn)|N|N|N|
|3|ViStatus viFindRsrc(ViSession sesn, ViConstString expr, ViPFindList findList, ViPUInt32 retCnt, ViChar _VI_FAR desc[])|N|N|N|
|4|ViStatus viFindNext(ViFindList findList, ViChar _VI_FAR desc[])|N|N|N|
|5|ViStatus viParseRsrc(ViSession sesn, ViConstRsrc rsrcName, ViPUInt16 intfType, ViPUInt16 intfNum)|N|N|N|
|6|ViStatus viParseRsrcEx(ViSession sesn, ViConstRsrc rsrcName, ViPUInt16 intfType, ViPUInt16 intfNum, ViChar VI_FAR rsrcClass[], ViChar VI_FAR expandedUnaliasedName[], ViChar VI_FAR aliasIfExists[])|N|N|N|
|7|ViStatus viOpen(ViSession sesn, ViConstRsrc name, ViAccessMode mode, ViUInt32 timeout, ViPSession vi)|N|N|N|
|8|ViStatus viClose(ViObject vi)|N|N|N|
|9|ViStatus viGetAttribute(ViObject vi, ViAttr attrName, void _VI_PTR attrValue)|N|N|N|
|10|ViStatus viSetAttribute(ViObject vi, ViAttr attrName, ViAttrState  attrValue)|N|N|N|
|11|ViStatus viStatusDesc(ViObject vi, ViStatus status, ViChar _VI_FAR desc[])|N|N|N|
|12|ViStatus viTerminate(ViObject vi, ViUInt16 degree, ViJobId jobId)|N|N|N|
|13|ViStatus viLock(ViSession vi, ViAccessMode lockType, ViUInt32 timeout, ViConstKeyId requestedKey, ViChar _VI_FAR accessKey[])|N|N|N|
|14|ViStatus viUnlock(ViSession vi)|N|N|N|
|15|ViStatus viEnableEvent(ViSession vi, ViEventType eventType, ViUInt16 mechanism, ViEventFilter context)|N|N|N|
|16|ViStatus viDisableEvent(ViSession vi, ViEventType eventType, ViUInt16 mechanism)|N|N|N|
|17|ViStatus viDiscardEvents(ViSession vi, ViEventType eventType, ViUInt16 mechanism)|N|N|N|
|18|ViStatus viWaitOnEvent(ViSession vi, ViEventType inEventType, ViUInt32 timeout, ViPEventType outEventType, ViPEvent outContext)|N|N|N|
|19|ViStatus viInstallHandler(ViSession vi, ViEventType eventType, ViHndlr handler, ViAddr userHandle)|N|N|N|
|20|ViStatus viUninstallHandler(ViSession vi, ViEventType eventType, ViHndlr handler, ViAddr userHandle)|N|N|N|
|21|ViStatus viRead(ViSession vi, ViPBuf buf, ViUInt32 cnt, ViPUInt32 retCnt)|N|N|N|
|22|ViStatus viReadAsync(ViSession vi, ViPBuf buf, ViUInt32 cnt, ViPJobId  jobId) |N|N|N|
|23|ViStatus viReadToFile(ViSession vi, ViConstString filename, ViUInt32 cnt, ViPUInt32 retCnt)|N|N|N|
|24|ViStatus viWrite(ViSession vi, ViConstBuf buf, ViUInt32 cnt, ViPUInt32 retCnt)|N|N|N|
|25|ViStatus viWriteAsync(ViSession vi, ViConstBuf buf, ViUInt32 cnt, ViPJobId  jobId)|N|N|N|
|26|ViStatus viWriteFromFile(ViSession vi, ViConstString filename, ViUInt32 cnt, ViPUInt32 retCnt)|N|N|N|
|27|ViStatus viAssertTrigger(ViSession vi, ViUInt16 protocol)|N|N|N|
|28|ViStatus viReadSTB(ViSession vi, ViPUInt16 status)|N|N|N|
|29|ViStatus viClear(ViSession vi)|N|N|N|
|30|ViStatus viSetBuf(ViSession vi, ViUInt16 mask, ViUInt32 size)|N|N|N|
|31|ViStatus viFlush(ViSession vi, ViUInt16 mask)|N|N|N|
|32|ViStatus viBufWrite(ViSession vi, ViConstBuf buf, ViUInt32 cnt, ViPUInt32 retCnt)|N|N|N|
|33|ViStatus viBufRead(ViSession vi, ViPBuf buf, ViUInt32 cnt, ViPUInt32 retCnt)|N|N|N|
|34|ViStatus viPrintf(ViSession vi, ViConstString writeFmt, ...)|N|N|N|
|35|ViStatus viVPrintf(ViSession vi, ViConstString writeFmt, ViVAList params)|N|N|N|
|36|ViStatus viSPrintf(ViSession vi, ViPBuf buf, ViConstString writeFmt, ...)|N|N|N|
|37|ViStatus viVSPrintf(ViSession vi, ViPBuf buf, ViConstString writeFmt, ViVAList parms)|N|N|N|
|38|ViStatus viScanf(ViSession vi, ViConstString readFmt, ...)|N|N|N|
|39|ViStatus viVScanf(ViSession vi, ViConstString readFmt, ViVAList params)|N|N|N|
|40|ViStatus viSScanf(ViSession vi, ViConstBuf buf, ViConstString readFmt, ...)|N|N|N|
|41|ViStatus viVSScanf(ViSession vi, ViConstBuf buf, ViConstString readFmt, ViVAList parms)|N|N|N|
|42|ViStatus viQueryf(ViSession vi, ViConstString writeFmt, ViConstString readFmt, ...)|N|N|N|
|43|ViStatus viVQueryf(ViSession vi, ViConstString writeFmt, ViConstString readFmt, ViVAList params)|N|N|N|
|44|ViStatus viIn8(ViSession vi, ViUInt16 space, ViBusAddress offset, ViPUInt8 val8)|N|N|N|
|45|ViStatus viOut8(ViSession vi, ViUInt16 space, ViBusAddress offset, ViUInt8 val8)|N|N|N|
|46|ViStatus viIn16(ViSession vi, ViUInt16 space, ViBusAddress offset, ViPUInt16 val16)|N|N|N|
|47|ViStatus viOut16(ViSession vi, ViUInt16 space, ViBusAddress offset, ViUInt16 val16)|N|N|N|
|48|ViStatus viIn32(ViSession vi, ViUInt16 space, ViBusAddress offset, ViPUInt32 val32)|N|N|N|
|49|ViStatus viOut32(ViSession vi, ViUInt16 space, ViBusAddress offset, ViUInt32 val32)|N|N|N|
|50|ViStatus viIn64(ViSession vi, ViUInt16 space, ViBusAddress   offset, ViPUInt64 val64)|N|N|N|
|51|ViStatus viOut64(ViSession vi, ViUInt16 space, ViBusAddress   offset, ViUInt64  val64)|N|N|N|
|52|ViStatus viIn8Ex(ViSession vi, ViUInt16 space, ViBusAddress64 offset, ViPUInt8  val8)|N|N|N|
|53|ViStatus viOut8Ex(ViSession vi, ViUInt16 space, ViBusAddress64 offset, ViUInt8   val8)|N|N|N|
|54|ViStatus viIn16Ex(ViSession vi, ViUInt16 space, ViBusAddress64 offset, ViPUInt16 val16)|N|N|N|
|55|ViStatus viOut16Ex(ViSession vi, ViUInt16 space, ViBusAddress64 offset, ViUInt16  val16)|N|N|N|
|56|ViStatus viIn32Ex(ViSession vi, ViUInt16 space, ViBusAddress64 offset, ViPUInt32 val32)|N|N|N|
|57|ViStatus viOut32Ex(ViSession vi, ViUInt16 space, ViBusAddress64 offset, ViUInt32  val32)|N|N|N|
|58|ViStatus viIn64Ex(ViSession vi, ViUInt16 space, ViBusAddress64 offset, ViPUInt64 val64)|N|N|N|
|59|ViStatus viOut64Ex(ViSession vi, ViUInt16 space, ViBusAddress64 offset, ViUInt64  val64)|N|N|N|
|60|ViStatus viMoveIn8(ViSession vi, ViUInt16 space, ViBusAddress offset, ViBusSize length, ViAUInt8 buf8)|N|N|N|
|61|ViStatus viMoveOut8(ViSession vi, ViUInt16 space, ViBusAddress offset, ViBusSize length, ViAUInt8 buf8)|N|N|N|
|62|ViStatus viMoveIn16(ViSession vi, ViUInt16 space, ViBusAddress offset, ViBusSize length, ViAUInt16 buf16)|N|N|N|
|63|ViStatus viMoveOut16(ViSession vi, ViUInt16 space, ViBusAddress offset, ViBusSize length, ViAUInt16 buf16)|N|N|N|
|64|ViStatus viMoveIn32(ViSession vi, ViUInt16 space, ViBusAddress offset, ViBusSize length, ViAUInt32 buf32)|N|N|N|
|65|ViStatus viMoveOut32(ViSession vi, ViUInt16 space, ViBusAddress offset, ViBusSize length, ViAUInt32 buf32)|N|N|N|
|66|ViStatus viMoveIn64(ViSession vi, ViUInt16 space, ViBusAddress offset, ViBusSize length, ViAUInt64 buf64)|N|N|N|
|67|ViStatus viMoveOut64(ViSession vi, ViUInt16 space, ViBusAddress offset, ViBusSize length, ViAUInt64 buf64)|N|N|N|
|68|ViStatus viMoveIn8Ex(ViSession vi, ViUInt16 space, ViBusAddress64 offset, ViBusSize length, ViAUInt8  buf8)|N|N|N|
|69|ViStatus viMoveOut8Ex(ViSession vi, ViUInt16 space, ViBusAddress64 offset, ViBusSize length, ViAUInt8  buf8)|N|N|N|
|70|ViStatus viMoveIn16Ex(ViSession vi, ViUInt16 space, ViBusAddress64 offset, ViBusSize length, ViAUInt16 buf16)|N|N|N|
|71|ViStatus viMoveOut16Ex(ViSession vi, ViUInt16 space, ViBusAddress64 offset, ViBusSize length, ViAUInt16 buf16)|N|N|N|
|72|ViStatus viMoveIn32Ex(ViSession vi, ViUInt16 space, ViBusAddress64 offset, ViBusSize length, ViAUInt32 buf32)|N|N|N|
|73|ViStatus viMoveOut32Ex(ViSession vi, ViUInt16 space, ViBusAddress64 offset, ViBusSize length, ViAUInt32 buf32)|N|N|N|
|74|ViStatus viMoveIn64Ex(ViSession vi, ViUInt16 space, ViBusAddress64 offset, ViBusSize length, ViAUInt64 buf64)|N|N|N|
|75|ViStatus viMoveOut64Ex(ViSession vi, ViUInt16 space, ViBusAddress64 offset, ViBusSize length, ViAUInt64 buf64)|N|N|N|
|76|ViStatus viMove(ViSession vi, ViUInt16 srcSpace, ViBusAddress srcOffset, ViUInt16 srcWidth, ViUInt16 destSpace, ViBusAddress destOffset, ViUInt16 destWidth, ViBusSize srcLength)|N|N|N|
|77|ViStatus viMoveAsync(ViSession vi, ViUInt16 srcSpace, ViBusAddress srcOffset, ViUInt16 srcWidth, ViUInt16 destSpace, ViBusAddress destOffset, ViUInt16 destWidth, ViBusSize srcLength, ViPJobId jobId)|N|N|N|
|78|ViStatus viMoveEx(ViSession vi, ViUInt16 srcSpace, ViBusAddress64 srcOffset, ViUInt16 srcWidth, ViUInt16 destSpace, ViBusAddress64 destOffset, ViUInt16 destWidth,  ViBusSize srcLength) |N|N|N|
|79|ViStatus viMoveAsyncEx(ViSession vi, ViUInt16 srcSpace, ViBusAddress64 srcOffset, ViUInt16 srcWidth, ViUInt16 destSpace, ViBusAddress64 destOffset, ViUInt16 destWidth, ViBusSize srcLength, ViPJobId jobId)|N|N|N|
|80|ViStatus viMapAddress(ViSession vi, ViUInt16 mapSpace, ViBusAddress mapOffset, ViBusSize mapSize, ViBoolean access, ViAddr suggested, ViPAddr address)|N|N|N|
|81|ViStatus viUnmapAddress(ViSession vi)|N|N|N|
|82|ViStatus viMapAddressEx(ViSession vi, ViUInt16 mapSpace, ViBusAddress64 mapOffset, ViBusSize mapSize, ViBoolean access, ViAddr suggested, ViPAddr address)|N|N|N|
|83|void viPeek8(ViSession vi, ViAddr address, ViPUInt8 val8)|N|N|N|
|84|void viPoke8(ViSession vi, ViAddr address, ViUInt8 val8)|N|N|N|
|85|void viPeek16(ViSession vi, ViAddr address, ViPUInt16 val16)|N|N|N|
|86|void viPoke16(ViSession vi, ViAddr address, ViUInt16 val16)|N|N|N|
|87|void viPeek32(ViSession vi, ViAddr address, ViPUInt32 val32)|N|N|N|
|88|void viPoke32(ViSession vi, ViAddr address, ViUInt32 val32)|N|N|N|
|89|void viPeek64(ViSession vi, ViAddr address, ViPUInt64 val64)|N|N|N|
|90|void viPoke64(ViSession vi, ViAddr address, ViUInt64  val64)|N|N|N|
|91|ViStatus viMemAlloc(ViSession vi, ViBusSize size, ViPBusAddress offset)|N|N|N|
|92|ViStatus viMemFree(ViSession vi, ViBusAddress offset)|N|N|N|
|93|ViStatus viMemAllocEx(ViSession vi, ViBusSize size, ViPBusAddress64 offset)|N|N|N|
|94|ViStatus viMemFreeEx(ViSession vi, ViBusAddress64 offset) |N|N|N|
|95|ViStatus viGpibControlREN(ViSession vi, ViUInt16 mode)|N|N|N|
|96|ViStatus viGpibControlATN(ViSession vi, ViUInt16 mode)|N|N|N|
|97|ViStatus viGpibSendIFC(ViSession vi)|N|N|N|
|98|ViStatus viGpibCommand(ViSession vi, ViConstBuf cmd, ViUInt32 cnt, ViPUInt32 retCnt)|N|N|N|
|99|ViStatus viGpibPassControl(ViSession vi, ViUInt16 primAddr, ViUInt16 secAddr)|N|N|N|
|100|ViStatus viVxiCommandQuery(ViSession vi, ViUInt16 mode, ViUInt32 cmd, ViPUInt32 response)|N|N|N|
|101|ViStatus viAssertUtilSignal(ViSession vi, ViUInt16 line)|N|N|N|
|102|ViStatus viAssertIntrSignal(ViSession vi, ViInt16 mode, ViUInt32 statusID)|N|N|N|
|103|ViStatus viMapTrigger(ViSession vi, ViInt16 trigSrc, ViInt16 trigDest, ViUInt16 mode)|N|N|N|
|104|ViStatus viUnmapTrigger(ViSession vi, ViInt16 trigSrc, ViInt16 trigDest)|N|N|N|
|105|ViStatus viUsbControlOut(ViSession vi, ViInt16 bmRequestType, ViInt16 bRequest, ViUInt16 wValue, ViUInt16 wIndex, ViUInt16 wLength, ViConstBuf buf)|N|N|N|
|106|ViStatus viUsbControlIn(ViSession vi, ViInt16 bmRequestType, ViInt16 bRequest, ViUInt16 wValue, ViUInt16 wIndex, ViUInt16 wLength, ViPBuf buf, ViPUInt16 retCnt)|N|N|N|
|107|ViStatus viPxiReserveTriggers(ViSession vi, ViInt16 cnt, ViAInt16 trigBuses, ViAInt16 trigLines, ViPInt16 failureIndex)|N|N|N|
