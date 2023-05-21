# Mm.tmctl implemented functions

|No.|Functions|VXI-11|SOCKET|HiSLIP|
|----|----|----|----|----|
|1|int TmcInitialize(int wire, char* adr, int* id)|Y|Y|Y|
|2|int TmcInitializeEx(int wire, char* adr, int* id, int tmo)|N|N|N|
|3|int TmcFinish( int id )|Y|Y|Y|
|4|int TmcSearchDevices( int wire, DEVICELIST* list, int max, int* num, char* option)|N|N|N|
|5|int TmcSearchDevicesEx( int wire, DEVICELISTEX* list, int max, int* num, char* option)|N|N|N|
|6|int TmcEncodeSerialNumber(char* encode, size_t len, char* src)|N|N|N|
|7|int TmcDecodeSerialNumber(char* decode, size_t len, char* src)|N|N|N|
|8|int TmcSetTimeout( int id, int tmo )|N|N|N|
|9|int TmcSetTerm( int id, int eos, int eot )|N|N|N|
|10|int TmcSend( int id, char* msg )|Y|Y|Y|
|11|int TmcSendByLength( int id, char* msg, int len )|N|N|N|
|12|int TmcSendSetup( int id )|N|N|N|
|13|int TmcSendOnly( int id, char* msg, int len, int end )|N|N|N|
|14|int TmcReceive( int id, char* buff, int blen, int* rlen )|Y|Y|Y|
|15|int TmcReceiveSetup( int id )|N|N|N|
|16|int TmcReceiveOnly( int id, char* buff, int blen, int* rlen )|N|N|N|
|17|int TmcReceiveBlockHeader( int id, int* length )|N|N|N|
|18|int TmcReceiveBlockData( int id, char* buff, int blen, int* rlen, int* end )|N|N|N|
|19|int TmcCheckEnd( int id )|N|N|N|
|20|int TmcGetLastError( int id )|N|N|N|
|21|int TmcSetRen( int id, int flag )|Y|Y|Y|
|22|int TmcDeviceClear( int id )|Y|Y|Y|
|23|int TmcDeviceTrigger( int id )|Y|Y|Y|
|24|int TmcWaitSRQ( int id, char* stsbyte, int tmo)|N|N|N|
|25|int TmcAbortWaitSRQ( int id)|N|N|N|
|26|int TmcSetCallback(int id, Hndlr func, ULONG p1,ULONG p2)|N|N|N|
|27|int TmcResetCallback(int id)|N|N|N|
