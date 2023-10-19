# ServerSocket Class

## Definition
Namespace:[Vxi11Net](../Vxi11Net.md)<BR>
Assembly:TmctlAPINet.dll

## Properties

|Property Name|
|---|
|[server](#server-Property)|
|[socket](#socket-Property)|
|[serverScpi](#serverScpi-Property)|
|[tokenSource](#tokenSource-Property)|
|[endPoint](#endPoint-Property)|

## Methods

|Method Name|
|---|
|[SendMsg(byte[] msg)](#SendMsgbyte-msg-Method)|
|[ReceiveMsg(int size)](#ReceiveMsgint-size-Method)|
|[Flush()](#Flush-Method)|
|[CoreThread()](#CoreThread-Method)|
|[RunThread(string host, int port, int count)](#RunThreadstring-host-int-port-int-count-Method)|
|[Create(string ipString, int port)](#Createstring-ipString-int-port-Method)|
|[Close()](#Close-Method)|
|[Destroy()](#Destroy-Method)|

## server Property
```C#
private Socket server = new Socket(SocketType.Stream, ProtocolType.Tcp);
```
## socket Property
```C#
private Socket socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
```
## serverScpi Property
```C#
private ServerScpi serverScpi = new ServerScpi();
```
## tokenSource Property
```C#
private CancellationTokenSource tokenSource = new CancellationTokenSource();
```
## endPoint Property
```C#
IPEndPoint endPoint = new IPEndPoint(IPAddress.IPv6Any, 0);
```
## SendMsg(byte[] msg) Method
```C#
public int SendMsg(byte[] msg)
```
## ReceiveMsg(int size) Method
```C#
public byte[] ReceiveMsg(int size)
```
## Flush() Method
```C#
public void Flush()
```
## CoreThread() Method
```C#
private void CoreThread()
```
## RunThread(string host, int port, int count) Method
```C#
public void RunThread(string host, int port, int count)
```
## Create(string ipString, int port) Method
```C#
public void Create(string ipString, int port)
```
## Close() Method
```C#
public void Close()
```
## Destroy() Method
```C#
public void Destroy()
```
