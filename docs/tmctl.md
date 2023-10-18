# Mm.tmctl.dll
## About
- Mm.tmctl.dll is open source C# library to communicate test and measurement instruments.
- Mm.tmctl.dll supports several communication protocols: VXI-11, HiSLIP and RawSokcet.
- Mm.tmctl.dll runs on .Net Framework 3.5. Windows XP or later support .Net Framework 2.0.
- Mm.tmctl.dll supports Yokogawa's TMCTL C ABI , So C/C++/ExcelVBA progam can use this library

## Package files
- tmctl.dll (for 32bit application)
- tmctl64.dll (for 64bit application)

## API
### Functions

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

### Error code
(T.B.D)
### Sample code
(T.B.D)
## Source code
(T.B.D)
## Debug
(T.B.D)
## Design
(T.B.D)
### Class diagram
(T.B.D)|
