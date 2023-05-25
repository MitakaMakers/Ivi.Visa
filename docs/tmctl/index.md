# Mm.tmctl implemented functions

|C Functions|VXI-11|SOCKET|HiSLIP|
|----|----|----|----|
|int TmcInitialize(int wire, char* adr, int* id)|Y|Y|Y|
|int TmcFinish( int id )|Y|Y|Y|
|int TmcSetTimeout( int id, int tmo )|Y|Y|Y|
|int TmcSetTerm( int id, int eos, int eot )|Y|Y|Y|
|int TmcSend( int id, char* msg )|Y|Y|Y|
|int TmcReceive( int id, char* buff, int blen, int* rlen )|Y|Y|Y|
|int TmcReceiveOnly( int id, char* buff, int blen, int* rlen )|Y|Y|Y|
|int TmcReceiveBlockHeader( int id, int* length )|Y|Y|Y|
|int TmcReceiveBlockData( int id, char* buff, int blen, int* rlen, int* end )|Y|Y|Y|
|int TmcCheckEnd( int id )|Y|Y|Y|
|int TmcGetLastError( int id )|Y|Y|Y|
|int TmcSetRen( int id, int flag )|Y|N|Y|
|int TmcDeviceClear( int id )|Y|N|Y|
