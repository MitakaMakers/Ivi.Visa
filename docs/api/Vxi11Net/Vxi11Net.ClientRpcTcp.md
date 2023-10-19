# ClientRpcTcp Class

## Definition
Namespace:[Vxi11Net](../Vxi11Net.md)<BR>
Assembly:TmctlAPINet.dll

## Properties

|Property Name|
|---|
|[socket](#socket-Property)|
|[endPoint](#endPoint-Property)|
|[last_fragment](#last_fragment-Property)|
|[remain](#remain-Property)|

## Methods

|Method Name|
|---|
|[Call(byte[] msg, bool IsFirst, bool IsLast)](#Callbyte-msg-bool-IsFirst-bool-IsLast-Method)|
|[ClearReply()](#ClearReply-Method)|
|[Create(string ipString, int port)](#Createstring-ipString-int-port-Method)|
|[Destroy()](#Destroy-Method)|
|[Flush()](#Flush-Method)|
|[GetReply(byte[] buffer, bool IsFirst)](#GetReplybyte-buffer-bool-IsFirst-Method)|
|[Receive(byte[] buffer, int offset, int buffsize, SocketFlags socketFlags, bool IsFirst)](#Receivebyte-buffer-int-offset-int-buffsize-SocketFlags-socketFlags-bool-IsFirst-Method)|
|[Send(byte[] body, int offset, int size, SocketFlags socketFlags, bool IsFirst, bool IsLast)](#Sendbyte-body-int-offset-int-size-SocketFlags-socketFlags-bool-IsFirst-bool-IsLast-Method)|

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
private bool last_fragment = true;
```
## remain Property
```C#
private int remain = 0;
```
## Call(byte[] msg, bool IsFirst, bool IsLast) Method
```C#
public void Call(byte[] msg, bool IsFirst, bool IsLast)
```
## ClearReply() Method
```C#
public void ClearReply()
```
## Create(string ipString, int port) Method
```C#
public void Create(string ipString, int port)
```
## Destroy() Method
```C#
public void Destroy()
```
## Flush() Method
```C#
public void Flush()
```
## GetReply(byte[] buffer, bool IsFirst) Method
```C#
public int GetReply(byte[] buffer, bool IsFirst)
```
## Receive(byte[] buffer, int offset, int buffsize, SocketFlags socketFlags, bool IsFirst) Method
```C#
private int Receive(byte[] buffer, int offset, int buffsize, SocketFlags socketFlags, bool IsFirst)
```
## Send(byte[] body, int offset, int size, SocketFlags socketFlags, bool IsFirst, bool IsLast) Method
```C#
private int Send(byte[] body, int offset, int size, SocketFlags socketFlags, bool IsFirst, bool IsLast)
```
