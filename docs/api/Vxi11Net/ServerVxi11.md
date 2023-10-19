# ServerVxi11 Class

## Definition
Namespace:[Vxi11Net](../Vxi11Net.md)<BR>
Assembly:TmctlAPINet.dll

## Properties

|Property Name|
|---|
|[lid](#lid-Property)|
|[abortPort](#abortPort-Property)|
|[serverCore](#serverCore-Property)|
|[serverAbort](#serverAbort-Property)|
|[serverInterrupt](#serverInterrupt-Property)|
|[serverScpi](#serverScpi-Property)|
|[tokenSource](#tokenSource-Property)|

## Methods

|Method Name|
|---|
|[ReceiveCreateLink(out string handle)](#ReceiveCreateLinkout-string-handle-Method)|
|[ReplyCreateLink(int xid, int lid, int abortPort, int maxRecvSize)](#ReplyCreateLinkint-xid-int-lid-int-abortPort-int-maxRecvSize-Method)|
|[ReceiveDeviceWrite(out byte[] data)](#ReceiveDeviceWriteout-byte-data-Method)|
|[ReplyDeviceWrite(int xid, int data_len)](#ReplyDeviceWriteint-xid-int-data_len-Method)|
|[ReceiveDeviceRead()](#ReceiveDeviceRead-Method)|
|[ReplyDeviceRead(int xid, Reason reason, byte[] data)](#ReplyDeviceReadint-xid-Reason-reason-byte-data-Method)|
|[ReceiveGenericParams()](#ReceiveGenericParams-Method)|
|[ReplyDeviceReadStb(int xid, byte stb)](#ReplyDeviceReadStbint-xid-byte-stb-Method)|
|[ReceiveDeviceLock()](#ReceiveDeviceLock-Method)|
|[ReceiveCreateIntrchan()](#ReceiveCreateIntrchan-Method)|
|[ReceiveDeviceEnableSrq(out string handle)](#ReceiveDeviceEnableSrqout-string-handle-Method)|
|[ReceiveDeviceDoCmd(out byte[] data_in)](#ReceiveDeviceDoCmdout-byte-data_in-Method)|
|[ReplyDeviceDoCmd(int xid, int data_out_len)](#ReplyDeviceDoCmdint-xid-int-data_out_len-Method)|
|[ReceiveDeviceLink()](#ReceiveDeviceLink-Method)|
|[ReplyDeviceError(int xid, int error)](#ReplyDeviceErrorint-xid-int-error-Method)|
|[Flush()](#Flush-Method)|
|[CoreThread()](#CoreThread-Method)|
|[AbortThread()](#AbortThread-Method)|
|[RunCoreThread(string host, int port, int count)](#RunCoreThreadstring-host-int-port-int-count-Method)|
|[RunAbortThread(string host, int port, int count)](#RunAbortThreadstring-host-int-port-int-count-Method)|
|[Shutdown()](#Shutdown-Method)|
|[Create(string host, int port)](#Createstring-host-int-port-Method)|
|[CreateAbort(string host, int port)](#CreateAbortstring-host-int-port-Method)|
|[CreateInterrupt(string host, int port)](#CreateInterruptstring-host-int-port-Method)|
|[ReceiveMsg()](#ReceiveMsg-Method)|
|[Destroy()](#Destroy-Method)|

## lid Property
```C#
private int lid = 123;
```
## abortPort Property
```C#
private int abortPort = 456;
```
## serverCore Property
```C#
private ServerRpcTcp serverCore = new ServerRpcTcp();
```
## serverAbort Property
```C#
private ServerRpcTcp serverAbort = new ServerRpcTcp();
```
## cserverInterrupt Property
```C#
private ClientRpcTcp serverInterrupt = new ClientRpcTcp();
```
## serverScpi Property
```C#
private ServerScpi serverScpi = new ServerScpi();
```
## tokenSource Property
```C#
private CancellationTokenSource tokenSource = new CancellationTokenSource();
```
## ReceiveCreateLink(out string handle) Method
```C#
public Vxi11.CREATE_LINK_PARAMS ReceiveCreateLink(out string handle)
```
## ReplyCreateLink(int xid, int lid, int abortPort, int maxRecvSize) Method
```C#
public void ReplyCreateLink(int xid, int lid, int abortPort, int maxRecvSize)
```
## ReceiveDeviceWrite(out byte[] data) Method
```C#
public Vxi11.DEVICE_WRITE_PARAMS ReceiveDeviceWrite(out byte[] data)
```
## ReplyDeviceWrite(int xid, int data_len) Method
```C#
public void ReplyDeviceWrite(int xid, int data_len)
```
## ReceiveDeviceRead() Method
```C#
public Vxi11.DEVICE_READ_PARAMS ReceiveDeviceRead()
```
## ReplyDeviceRead(int xid, Reason reason, byte[] data) Method
```C#
public void ReplyDeviceRead(int xid, Reason reason, byte[] data)
```
## ReceiveGenericParams() Method
```C#
public Vxi11.DEVICE_GENERIC_PARAMS ReceiveGenericParams()
```
## ReplyDeviceReadStb(int xid, byte stb) Method
```C#
public void ReplyDeviceReadStb(int xid, byte stb)
```
## ReceiveDeviceLock() Method
```C#
public Vxi11.DEVICE_LOCK_PARAMS ReceiveDeviceLock()
```
## ReceiveCreateIntrchan() Method
```C#
public Vxi11.CREATE_INTR_CHAN_PARAMS ReceiveCreateIntrchan()
```
## ReceiveDeviceEnableSrq(out string handle) Method
```C#
public Vxi11.DEVICE_ENABLE_SRQ_PARAMS ReceiveDeviceEnableSrq(out string handle)
```
## ReceiveDeviceDoCmd(out byte[] data_in) Method
```C#
public Vxi11.DEVICE_DOCMD_PARAMS ReceiveDeviceDoCmd(out byte[] data_in)
```
## ReplyDeviceDoCmd(int xid, int data_out_len) Method
```C#
public void ReplyDeviceDoCmd(int xid, int data_out_len)
```
## ReceiveDeviceLink() Method
```C#
public long ReceiveDeviceLink()
```
## ReplyDeviceError(int xid, int error) Method
```C#
public void ReplyDeviceError(int xid, int error)
```
## Flush() Method
```C#
public void Flush()
```
## CoreThread() Method
```C#
private void CoreThread()
```
## AbortThread() Method
```C#
private void AbortThread()
```
## RunCoreThread(string host, int port, int count) Method
```C#
public void RunCoreThread(string host, int port, int count)
```
## RunAbortThread(string host, int port, int count) Method
```C#
public void RunAbortThread(string host, int port, int count)
```
## Shutdown() Method
```C#
public void Shutdown()
```
## Create(string host, int port) Method
```C#
public void Create(string host, int port)
```
## CreateAbort(string host, int port) Method
```C#
public void CreateAbort(string host, int port)
```
## CreateInterrupt(string host, int port) Method
```C#
public void CreateInterrupt(string host, int port)
```
## ReceiveMsg() Method
```C#
public Rpc.RPC_MESSAGE_PARAMS ReceiveMsg()
```
## Destroy() Method
```C#
public void Destroy()
```
