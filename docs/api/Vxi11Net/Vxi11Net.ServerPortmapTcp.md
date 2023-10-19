# ServerPortmapTcp Class

## Definition
Namespace:[Vxi11Net](../Vxi11Net.md)<BR>
Assembly:TmctlAPINet.dll

## Properties

|Property Name|
|---|
|[serverRpcTcp](#serverRpcTcp-Property)|
|[tokenSource](#tokenSource-Property)|

## Methods

|Method Name|
|---|
|[ReceiveSet()](#ReceiveSet-Method)|
|[ReplySet(int xid, bool status)](#ReplySetint-xid-bool-status-Method)|
|[ReceiveUnset()](#ReceiveUnset-Method)|
|[ReplyUnset(int xid, bool status)](#ReplyUnsetint-xid-bool-status-Method)|
|[ReceiveGetPort()](#ReceiveGetPort-Method)|
|[ReplyGetPort(int xid, int port)](#ReplyGetPortint-xid-int-port-Method)|
|[ClearArgs()](#ClearArgs-Method)|
|[ReceiveMsg()](#ReceiveMsg-Method)|
|[TcpThread()](#TcpThread-Method)|
|[Create(string host, int port)](#Createstring-host-int-port-Method)|
|[Destroy()](#Destroy-Method)|
|[Run(string host, int port)](#Runstring-host-int-port-Method)|
|[OneShot(string host, int port, int count)](#OneShotstring-host-int-port-int-count-Method)|
|[Shutdown()](#Shutdown-Method)|

## serverRpcTcp Property
```C#
private ServerRpcTcp serverRpcTcp = new ServerRpcTcp();
```
## tokenSource Property
```C#
private CancellationTokenSource tokenSource = new CancellationTokenSource();
```
## ReceiveSet() Method
```C#
public Portmap.MAPPING ReceiveSet()
```
## ReplySet(int xid, bool status) Method
```C#
public void ReplySet(int xid, bool status)
```
## ReceiveUnset() Method
```C#
public Portmap.MAPPING ReceiveUnset()
```
## ReplyUnset(int xid, bool status) Method
```C#
public void ReplyUnset(int xid, bool status)
```
## ReceiveGetPort() Method
```C#
public Portmap.MAPPING ReceiveGetPort()
```
## ReplyGetPort(int xid, int port) Method
```C#
public void ReplyGetPort(int xid, int port)
```
## ClearArgs() Method
```C#
public void ClearArgs()
```
## ReceiveMsg() Method
```C#
public Rpc.RPC_MESSAGE_PARAMS ReceiveMsg()
```
## TcpThread() Method
```C#
public void TcpThread()
```
## Create(string host, int port) Method
```C#
public void Create(string host, int port)
```
## Destroy() Method
```C#
public void Destroy()
```
## Run(string host, int port) Method
```C#
public void Run(string host, int port)
```
## OneShot(string host, int port, int count) Method
```C#
public void OneShot(string host, int port, int count)
```
## Shutdown() Method
```C#
public void Shutdown()
```