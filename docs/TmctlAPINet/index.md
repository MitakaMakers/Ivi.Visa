# Mm.TmctlAPINet implemented functions

|Functions|VXI-11|SOCKET|HiSLIP|
|----|----|----|----|
|int Initialize(int wire, string adr, ref int id)|Y|Y|Y|
|int Finish( int id )|Y|Y|Y|
|int SearchDevices( int wire, DEVICELIST[] list, int max, ref int num, string option )|Y|Y|Y|
|int SetTimeout( int id, int tmo )|Y|Y|Y|
|int SetTerm( int id, int eos, int eot )|Y|Y|Y|
|int Send( int id, string msg )|Y|Y|Y|
|int Receive( int id, [Out] StringBuilder buff, int blen, ref int rlen)|Y|Y|Y|
|int ReceiveOnly( int id, StringBuilder buff, int blen, ref int rlen)|Y|Y|Y|
|int ReceiveBlockHeader( int id, ref int length )|Y|Y|Y|
|int ReceiveBlockData( int id, ref sbyte buff, int blen, ref int rlen, ref int end)|Y|Y|Y|
|int CheckEnd( int id )|Y|Y|Y|
|int GetLastError( int id )|Y|Y|Y|
|int SetRen( int id, int flag )|Y|Y|Y|
|int DeviceClear( int id )|Y|Y|Y|
|int DeviceTrigger( int id )|Y|Y|Y|
