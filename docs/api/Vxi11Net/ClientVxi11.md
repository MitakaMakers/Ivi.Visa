# ClientVxi11 Class

## Definition
Namespace:[Vxi11Net](../Vxi11Net.md)<BR>
Assembly:TmctlAPINet.dll

## Properties

|Property Name|
|---|
|[clientCore](#clientCore-Property)|
|[clientAbort](#clientAbort-Property)|
|[serverInterrupt](#serverInterrupt-Property)|
|[xid](#xid-Property)|

## Methods

|Method Name|
|---|
|[CreateLink(int cliendId, int lockDevice, int lock_timeout, string handle, out int lid, out int abortPort, out int maxRecvSize)](#CreateLinkint-cliendId-int-lockDevice-int-lock_timeout-string-handle-out-int-lid-out-int-abortPort-out-int-maxRecvSize-Method)|
|[DeviceWrite(int lid, Vxi11.Flag flags, int lock_timeout, int io_timeout, string data, out int data_len)](#DeviceWriteint-lid-Vxi11Flag-flags-int-lock_timeout-int-io_timeout-string-data-out-int-data_len-Method)|
|[DeviceRead(int lid, int requestSize, Vxi11.Flag flags, int lock_timeout, int io_timeout, Vxi11.TermChar term, out int reason, out string data)](#DeviceReadint-lid-int-requestSize-Vxi11Flag-flags-int-lock_timeout-int-io_timeout-Vxi11TermChar-term-out-int-reason-out-string-data-Method)|
|[DeviceRead(int lid, int requestSize, Vxi11.Flag flags, int lock_timeout, int io_timeout, Vxi11.TermChar term, out int reason, out byte[] data)](#DeviceReadint-lid-int-requestSize-Vxi11Flag-flags-int-lock_timeout-int-io_timeout-Vxi11TermChar-term-out-int-reason-out-byte-data-Method)|
|[DeviceReadstb(int lid, Vxi11.Flag flags, int lock_timeout, int io_timeout, out char stb)](#DeviceReadstbint-lid-Vxi11Flag-flags-int-lock_timeout-int-io_timeout-out-char-stb-Method)|
|[DeviceTrigger(int lid, Vxi11.Flag flags, int lock_timeout, int io_timeout)](#DeviceTriggerint-lid-Vxi11Flag-flags-int-lock_timeout-int-io_timeout-Method)|
|[DeviceClear(int lid, Vxi11.Flag flags, int lock_timeout, int io_timeout)](#DeviceClearint-lid-Vxi11Flag-flags-int-lock_timeout-int-io_timeout-Method)|
|[DeviceRemote(int lid, Vxi11.Flag flags, int lock_timeout, int io_timeout)](#DeviceRemoteint-lid-Vxi11Flag-flags-int-lock_timeout-int-io_timeout-Method)|
|[DeviceLocal(int lid, Vxi11.Flag flags, int lock_timeout, int io_timeout)](#DeviceLocalint-lid-Vxi11Flag-flags-int-lock_timeout-int-io_timeout-Method)|
|[DeviceLock(int lid, Vxi11.Flag flags, int lock_timeout)](#DeviceLockint-lid-Vxi11Flag-flags-int-lock_timeout-Method)|
|[DeviceUnlock(int lid)](#DeviceUnlockint-lid-Method)|
|[CreateIntrChan(int hostaddr, int hostport, int prognum, int progvers, int progfamily)](#CreateIntrChanint-hostaddr-int-hostport-int-prognum-int-progvers-int-progfamily-Method)|
|[DestroyIntrChan()](#DestroyIntrChan-Method)|
|[DeviceEnableSrq(int lid, int enable, string handle)](#DeviceEnableSrqint-lid-int-enable-string-handle-Method)|
|[DeviceDocmd(int lid, Vxi11.Flag flags, int lock_timeout, int io_timeout, int cmd, int network_order, int datasize, byte[] data_in, out byte[] data_out)](#DeviceDocmdint-lid-Vxi11Flag-flags-int-lock_timeout-int-io_timeout-int-cmd-int-network_order-int-datasize-byte-data_in-out-byte-data_out-Method)|
|[DestroyLink(int lid)](#DestroyLinkint-lid-Method)|
|[DeviceAbort(int lid, Vxi11.Flag flags, int lock_timeout, int io_timeout)](#DeviceAbortint-lid-Vxi11Flag-flags-int-lock_timeout-int-io_timeout-Method)|
|[Create(string host, int port)](#Createstring-host-int-port-Method)|
|[CreateAbortChannel(string host, int port)](#CreateAbortChannelstring-host-int-port-Method)|
|[Destroy()](#Destroy-Method)|
|[DestroyAbortChannel()](#DestroyAbortChannel-Method)|
|[CreateInterruptChannel(string host, int port)](#CreateInterruptChannelstring-host-int-port-Method)|
|[DestroyInterruptChannel()](#DestroyInterruptChannel-Method)|

## clientCore Property
```C#
private ClientRpcTcp clientCore = new ClientRpcTcp();
```
## clientAbort Property
```C#
private ClientRpcTcp clientAbort = new ClientRpcTcp();
```
## serverInterrupt Property
```C#
private ServerRpcTcp serverInterrupt = new ServerRpcTcp();
```
## xid Property
```C#
private int xid = 123;
```
## CreateLink(int cliendId, int lockDevice, int lock_timeout, string handle, out int lid, out int abortPort, out int maxRecvSize) Method
```C#
public int CreateLink(int cliendId, int lockDevice, int lock_timeout, string handle, out int lid, out int abortPort, out int maxRecvSize)
```
## DeviceWrite(int lid, Vxi11.Flag flags, int lock_timeout, int io_timeout, string data, out int data_len) Method
```C#
public int DeviceWrite(int lid, Vxi11.Flag flags, int lock_timeout, int io_timeout, string data, out int data_len)
```
## DeviceRead(int lid, int requestSize, Vxi11.Flag flags, int lock_timeout, int io_timeout, Vxi11.TermChar term, out int reason, out string data) Method
```C#
public int DeviceRead(int lid, int requestSize, Vxi11.Flag flags, int lock_timeout, int io_timeout, Vxi11.TermChar term, out int reason, out string data)
```
## DeviceRead(int lid, int requestSize, Vxi11.Flag flags, int lock_timeout, int io_timeout, Vxi11.TermChar term, out int reason, out byte[] data) Method
```C#
public int DeviceRead(int lid, int requestSize, Vxi11.Flag flags, int lock_timeout, int io_timeout, Vxi11.TermChar term, out int reason, out byte[] data)
```
## DeviceReadstb(int lid, Vxi11.Flag flags, int lock_timeout, int io_timeout, out char stb) Method
```C#
public int DeviceReadstb(int lid, Vxi11.Flag flags, int lock_timeout, int io_timeout, out char stb)
```
## DeviceTrigger(int lid, Vxi11.Flag flags, int lock_timeout, int io_timeout) Method
```C#
public int DeviceTrigger(int lid, Vxi11.Flag flags, int lock_timeout, int io_timeout)
```
## DeviceClear(int lid, Vxi11.Flag flags, int lock_timeout, int io_timeout) Method
```C#
public int DeviceClear(int lid, Vxi11.Flag flags, int lock_timeout, int io_timeout)
```
## DeviceRemote(int lid, Vxi11.Flag flags, int lock_timeout, int io_timeout) Method
```C#
public int DeviceRemote(int lid, Vxi11.Flag flags, int lock_timeout, int io_timeout)
```
## DeviceLocal(int lid, Vxi11.Flag flags, int lock_timeout, int io_timeout) Method
```C#
public int DeviceLocal(int lid, Vxi11.Flag flags, int lock_timeout, int io_timeout)
```
## DeviceLock(int lid, Vxi11.Flag flags, int lock_timeout) Method
```C#
public int DeviceLock(int lid, Vxi11.Flag flags, int lock_timeout)
```
## DeviceUnlock(int lid) Method
```C#
public int DeviceUnlock(int lid)
```
## CreateIntrChan(int hostaddr, int hostport, int prognum, int progvers, int progfamily) Method
```C#
public int CreateIntrChan(int hostaddr, int hostport, int prognum, int progvers, int progfamily)
```
## DestroyIntrChan() Method
```C#
public int DestroyIntrChan()
```
## DeviceEnableSrq(int lid, int enable, string handle) Method
```C#
public int DeviceEnableSrq(int lid, int enable, string handle)
```
## DeviceDocmd(int lid, Vxi11.Flag flags, int lock_timeout, int io_timeout, int cmd, int network_order, int datasize, byte[] data_in, out byte[] data_out) Method
```C#
public void DeviceDocmd(int lid, Vxi11.Flag flags, int lock_timeout, int io_timeout, int cmd, int network_order, int datasize, byte[] data_in, out byte[] data_out)
```
## DestroyLink(int lid) Method
```C#
public int DestroyLink(int lid)
```
## DeviceAbort(int lid, Vxi11.Flag flags, int lock_timeout, int io_timeout) Method
```C#
public int DeviceAbort(int lid, Vxi11.Flag flags, int lock_timeout, int io_timeout)
```
## Create(string host, int port) Method
```C#
public void Create(string host, int port)
```
## CreateAbortChannel(string host, int port) Method
```C#
public void CreateAbortChannel(string host, int port)
```
## Destroy() Method
```C#
public void Destroy()
```
## DestroyAbortChannel() Method
```C#
public void DestroyAbortChannel()
```
## CreateInterruptChannel(string host, int port) Method
```C#
public void CreateInterruptChannel(string host, int port)
```
## DestroyInterruptChannel() Method
```C#
public void DestroyInterruptChannel()
```
