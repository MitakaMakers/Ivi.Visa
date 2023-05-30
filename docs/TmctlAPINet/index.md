# Mm.TmctlAPINet
## About
- Mm.TmctlAPINet is open source C# library to communicate test and measurement instruments.
- Mm.TmctlAPINet supports sevral communication protocols: VXI-11, HiSLIP and RawSokcet.
- Mm.TmctlAPINet runs on .Net 6
- Mm.TmctlAPINet supports TmctlAPINet API

## Package files
- TmctlAPINet.dll (Any CPU)

## API
### Functions

|C# Functions|VXI-11|SOCKET|HiSLIP|
|----|----|----|----|
|int Initialize(int wire, string adr, ref int id)|Y|Y|Y|
|int Finish( int id )|Y|Y|Y|
|int SetTimeout( int id, int tmo )|Y|Y|Y|
|int SetTerm( int id, int eos, int eot )|Y|Y|Y|
|int Send( int id, string msg )|Y|Y|Y|
|int Receive( int id, [Out] StringBuilder buff, int blen, ref int rlen)|Y|Y|Y|
|int ReceiveOnly( int id, StringBuilder buff, int blen, ref int rlen)|Y|Y|Y|
|int ReceiveBlockHeader( int id, ref int length )|Y|Y|Y|
|int ReceiveBlockData( int id, ref sbyte buff, int blen, ref int rlen, ref int end)|Y|Y|Y|
|int CheckEnd( int id )|Y|Y|Y|
|int GetLastError( int id )|Y|Y|Y|
|int SetRen( int id, int flag )|Y|N|Y|
|int DeviceClear( int id )|Y|N|Y|
