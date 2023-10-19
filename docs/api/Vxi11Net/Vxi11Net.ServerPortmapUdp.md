# ServerPortmapUdp Class

## Definition
Namespace:[Vxi11Net](../Vxi11Net.md)<BR>
Assembly:TmctlAPINet.dll

## Properties

|Property Name|
|---|
|[serverRpcUdp](#serverRpcUdp-Property)|
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
|[Run(string host, int port)](#Runstring-host-int-port-Method)|
|[Shutdown()](#Shutdown-Method)|
|[Create(string host, int port)](#Createstring-host-int-port-Method)|
|[Destroy()](#Destroy-Method)|

## serverRpcUdp Property
```C#
private ServerRpcUdp serverRpcUdp = new ServerRpcUdp();
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
## Run(string host, int port) Method
```C#
public void Run(string host, int port)
```
## Shutdown() Method
```C#
public void Shutdown()
```
## Create(string host, int port) Method
```C#
public void Create(string host, int port)
```
## Destroy() Method
```C#
public void Destroy()
```
