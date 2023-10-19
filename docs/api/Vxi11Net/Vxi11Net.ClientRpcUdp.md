# ClientRpcUdp Class

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
|[Call(byte[] msg, bool IsFirst, bool IsLast)](#Callbyte-msg-bool-IsFirst-bool-IsLast-Method)|
|[ClearReply()](#ClearReply-Method)|
|[Create(string ipString, int port)](#Createstring-ipString-int-port-Method)|
|[Destroy()](#Destroy-Method)|
|[Flush()](#Flush-Method)|
|[GetReply(byte[] buffer, bool IsFirst)](#GetReplybyte-buffer-bool-IsFirst-Method)|
|[Receive(byte[] buffer, int offset, int buffsize, bool IsFirst)](#Receivebyte-buffer-int-offset-int-buffsize-bool-IsFirst-Method)|
|[Send(byte[] body, int size, SocketFlags socketFlags)](#Sendbyte-body-int-offset-SocketFlags-socketFlags-Method)|

## socket Property
```C#
private Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
```
## endPoint Property
```C#
IPEndPoint endPoint = new IPEndPoint(IPAddress.IPv6Any, 0);
```
## UDPMSGSIZE Property
```C#
private const int UDPMSGSIZE = 2000;
```
## raw_buf Property
```C#
private byte[] raw_buf = new byte[UDPMSGSIZE];
```
## recvsize Property
```C#
private int recvsize;
```
## readsize Property
```C#
private int readsize;
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
## Receive(byte[] buffer, int offset, int buffsize, bool IsFirst) Method
```C#
private int Receive(byte[] buffer, int offset, int buffsize, bool IsFirst)
```
## Send(byte[] body, int size, SocketFlags socketFlags) Method
```C#
private int Send(byte[] body, int size, SocketFlags socketFlags)
```
