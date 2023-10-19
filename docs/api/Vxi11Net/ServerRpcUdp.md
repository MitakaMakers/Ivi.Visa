# ServerSocket Class

## Definition
Namespace:[Vxi11Net](../Vxi11Net.md)<BR>
Assembly:TmctlAPINet.dll

## Properties

|Property Name|
|---|
|[socket](#socket-Property)|
|[endPoint](#endPoint-Property)|
|[UDPMSGSIZE](#UDPMSGSIZE-Property)|
|[raw_buf](#raw_buf-Property)|
|[recvsize](#recvsize-Property)|
|[readsize](#readsize-Property)|

## Methods

|Method Name|
|---|
|[Send(byte[] buffer, int size, SocketFlags socketFlags)](#Sendbyte-buffer-int-size-SocketFlags-socketFlags-Method)|
|[Receive(byte[] buffer, int offset, int buffsize, bool IsFirst)](#Receivebyte-buffer-int-offset-int-buffsize-bool-IsFirst-Method)|
|[ReceiveMsg()](#ReceiveMsg-Method)|
|[GetArgs(byte[] buffer)](#GetArgsbyte-buffer-Method)|
|[ClearArgs()](#ClearArgs-Method)|
|[Reply(byte[] reply)](#Replybyte-reply-Method)|
|[Flush()](#Flush-Method)|
|[Create(string ipString, int port)](#Createstring-ipString-int-port-Method)|
|[Destroy()](#Destroy-Method)|


## socket Property
```C#
private Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
```
## endPoint Property
```C#
private EndPoint endPoint = (EndPoint)new IPEndPoint(IPAddress.IPv6Any, 0);
```
## int UDPMSGSIZE Property
```C#
private const int UDPMSGSIZE = 2000;
```
## raw_buf Property
```C#
private byte[] raw_buf = new byte[UDPMSGSIZE];
```
## recvsize Property
```C#
private int recvsize = 0;
```
## readsize Property
```C#
private int readsize = 0;
```
## Send(byte[] buffer, int size, SocketFlags socketFlags) Method
```C#
private int Send(byte[] buffer, int size, SocketFlags socketFlags)
```
## Receive(byte[] buffer, int offset, int buffsize, bool IsFirst) Method
```C#
private int Receive(byte[] buffer, int offset, int buffsize, bool IsFirst)
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
## Reply(byte[] reply) Method
```C#
public void Reply(byte[] reply)
```
## Flush() Method
```C#
public void Flush()
```
## Create(string ipString, int port) Method
```C#
public void Create(string ipString, int port)
```
## Destroy() Method
```C#
public void Destroy()
```
