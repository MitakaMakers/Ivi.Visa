# Mm.TmctlAPINet implemented functions

|No.|Functions|VXI-11|SOCKET|HiSLIP|
|----|----|----|----|----|
|1|int Initialize(int wire, string adr, ref int id)|Y|Y|Y|
|2|int InitializeEx(int wire, string adr, ref int id, int tmo)|N|N|N|
|3|int Finish( int id )|Y|Y|Y|
|4|int SearchDevices( int wire, DEVICELIST[] list, int max, ref int num, string option )|N|N|N|
|5|int SearchDevicesEx( int wire, DEVICELISTEx[] list, int max, ref int num, string option )|N|N|N|
|6|int EncodeSerialNumber( StringBuilder encode, int len, string src )|N|N|N|
|7|int DecodeSerialNumber( StringBuilder decode, int len, string src )|N|N|N|
|8|int SetTimeout( int id, int tmo )|N|N|N|
|9|int SetTerm( int id, int eos, int eot )|N|N|N|
|10|int Send( int id, string msg )|Y|Y|Y|
|11|int Send( int id, StringBuilder msg )|N|N|N|
|12|int SendByLength( int id, string msg, int len )|N|N|N|
|13|int SendByLength( int id, StringBuilder msg, int len )|N|N|N|
|14|int SendSetup( int id )|N|N|N|
|15|int SendOnly( int id, string msg, int len, int end )|N|N|N|
|16|int SendOnly( int id, StringBuilder msg, int len, int end )|N|N|N|
|17|int SendOnly( int id, ref sbyte data, int len, int end )|N|N|N|
|18|int SendOnly( int id, ref byte data, int len, int end )|N|N|N|
|19|int SendOnly( int id, ref short data, int len, int end )|N|N|N|
|20|int SendOnly( int id, ref ushort data, int len, int end )|N|N|N|
|21|int SendOnly( int id, ref int data, int len, int end )|N|N|N|
|22|int SendOnly( int id, ref uint data, int len, int end )|N|N|N|
|23|int SendOnly( int id, ref long data, int len, int end )|N|N|N|
|24|int SendOnly( int id, ref ulong data, int len, int end )|N|N|N|
|25|int SendOnly( int id, ref float data, int len, int end )|N|N|N|
|26|int SendOnly( int id, ref double data, int len, int end )|N|N|N|
|27|int Receive( int id, [Out] StringBuilder buff, int blen, ref int rlen)|Y|Y|Y|
|28|int ReceiveSetup( int id )|N|N|N|
|29|int ReceiveOnly( int id, StringBuilder buff, int blen, ref int rlen)|N|N|N|
|30|int ReceiveBlockHeader( int id, ref int length )|N|N|N|
|31|int ReceiveBlockData( int id, ref sbyte buff, int blen, ref int rlen, ref int end)|N|N|N|
|32|int ReceiveBlockData( int id, ref byte buff, int blen, ref int rlen, ref int end)|N|N|N|
|33|int ReceiveBlockData( int id, ref short buff, int blen, ref int rlen, ref int end)|N|N|N|
|34|int ReceiveBlockData( int id, ref ushort buff, int blen, ref int rlen, ref int end)|N|N|N|
|35|int ReceiveBlockData( int id, ref int buff, int blen, ref int rlen, ref int end)|N|N|N|
|36|int ReceiveBlockData( int id, ref uint buff, int blen, ref int rlen, ref int end)|N|N|N|
|37|int ReceiveBlockData( int id, ref long buff, int blen, ref int rlen, ref int end)|N|N|N|
|38|int ReceiveBlockData( int id, ref ulong buff, int blen, ref int rlen, ref int end)|N|N|N|
|39|int ReceiveBlockData( int id, ref float buff, int blen, ref int rlen, ref int end)|N|N|N|
|40|int ReceiveBlockData( int id, ref double buff, int blen, ref int rlen, ref int end)|N|N|N|
|41|int CheckEnd( int id )|N|N|N|
|42|int GetLastError( int id )|N|N|N|
|43|int SetRen( int id, int flag )|Y|Y|Y|
|44|int DeviceClear( int id )|Y|Y|Y|
|45|int DeviceTrigger( int id )|Y|Y|Y|
|46|int WaitSRQ( int id, ref byte stsbyte, int tmo)|N|N|N|
|47|int AbortWaitSRQ(int id)|N|N|N|
|48|int SetCallback(int id, Hndlr func, uint p1, uint p2)|N|N|N|
|49|int ResetCallback(int id)|N|N|N|
