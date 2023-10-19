# ServerSocket Class

## Definition
Namespace:[Vxi11Net](../Vxi11Net.md)<BR>
Assembly:TmctlAPINet.dll

## Properties

|Property Name|
|---|
|[server](#server-Property)|
|[socket](#socket-Property)|
|[endPoint](#endPoint-Property)|
|[last_fragment](#last_fragment-Property)|
|[remain](#remain-Property)|

## Methods

|Method Name|
|---|
|[Send(byte[] body, int offset, int size, SocketFlags socketFlags, bool IsFirst, bool IsLast)](#Sendbyte-body-int-offset-int-size-SocketFlags-socketFlags-bool-IsFirst-bool-IsLast-Method)|
|[Receive(byte[] buffer, int offset, int buffsize, SocketFlags socketFlags, bool IsFirst)](#Receivebyte-buffer-int-offset-int-buffsize-SocketFlags-socketFlags-bool-IsFirst-Method)|
|[ReceiveMsg()](#ReceiveMsg-Method)|
|[GetArgs(byte[] buffer)](#GetArgsbyte-buffer-Method)|
|[ClearArgs()](#ClearArgs-Method)|
|[Reply(byte[] reply, bool IsFirst, bool IsLast)](#Replybyte-reply-bool-IsFirst-bool-IsLast-Method)|
|[Flush()](#Flush-Method)|
|[Create(string ipString, int port)](#Createstring-ipString-int-port-Method)|
|[Close()](#Close-Method)|
|[Destroy()](#Destroy-Method)|

## server Property
```C#
private Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
```
## socket Property
```C#
private Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
```
## endPoint Property
```C#
IPEndPoint endPoint = new IPEndPoint(IPAddress.IPv6Any, 0);
```
## last_fragment Property
```C#
private bool last_fragment;
```
## remain Property
```C#
private int remain;
```
## Send(byte[] body, int offset, int size, SocketFlags socketFlags, bool IsFirst, bool IsLast) Method
```C#
private int Send(byte[] body, int offset, int size, SocketFlags socketFlags, bool IsFirst, bool IsLast)
```
## Receive(byte[] buffer, int offset, int buffsize, SocketFlags socketFlags, bool IsFirst) Method
```C#
private int Receive(byte[] buffer, int offset, int buffsize, SocketFlags socketFlags, bool IsFirst)
```
## ReceiveMsg() Method
```C#
public Rpc.RPC_MESSAGE_PARAMS ReceiveMsg()
```
## GetArgs(byte[] buffer) Method
```C#
public int GetArgs(byte[] buffer)
```
## ClearArgs() Method
```C#
public void ClearArgs()
```
## Reply(byte[] reply, bool IsFirst, bool IsLast) Method
```C#
public void Reply(byte[] reply, bool IsFirst, bool IsLast)
```
## Flush() Method
```C#
public void Flush()
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
