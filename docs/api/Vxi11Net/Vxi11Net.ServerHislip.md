# ServerSocket Class

## Definition
Namespace:[Vxi11Net](../Vxi11Net.md)<BR>
Assembly:TmctlAPINet.dll

## Properties

|Property Name|
|---|
|[endPoint](#endPoint-Property)|
|[server](#server-Property)|
|[synchronous](#synchronous-Property)|
|[asynchronous](#asynchronous-Property)|
|[serverScpi](#serverScpi-Property)|
|[tokenSource](#tokenSource-Property)|
|[SessionID](#SessionID-Property)|
|[MessageID](#MessageID-Property)|
|[IsRMTwasDelivered](#IsRMTwasDelivered-Property)|
|[lockCount](#lockCount-Property)|

## Methods

|Method Name|
|---|
|[ReplyInitializeResponse(Socket socket, byte control, short ServerVersion, short SessionID)](#ReplyInitializeResponseSocket-socket-byte-control-short-ServerVersion-short-SessionID-Method)|
|[ReplyAsyncInitializeResponse(Socket socket, byte control, short VendorID)](#ReplyAsyncInitializeResponseSocket-socket-byte-control-short-VendorID-Method)|
|[ReplyFatalError(Socket socket, byte control, string message)](#ReplyFatalErrorSocket-socket-byte-control-string-message-Method)|
|[ReplyError(Socket socket, byte control, string message)](#ReplyErrorSocket-socket-byte-control-string-message-Method)|
|[ReplyAsyncLockResponse(Socket socket, byte control)](#ReplyAsyncLockResponseSocket-socket-byte-control-Method)|
|[DataTransfer(Socket socket, byte control, int messageID, byte[] message)](#DataTransferSocket-socket-byte-control-int-messageID-byte-message-Method)|
|[DataEndTransfer(Socket socket, byte control, int messageID, byte[] message)](#DataEndTransferSocket-socket-byte-control-int-messageID-byte-message-Method)|
|[ReplyAsyncDeviceClearAcknowledge(Socket socket, byte feature)](#ReplyAsyncDeviceClearAcknowledgeSocket-socket-byte-feature-Method)|
|[ReplyDeviceClearAcknowledge(Socket socket, byte feature)](#ReplyDeviceClearAcknowledgeSocket-socket-byte-feature-Method)|
|[Interrupted(Socket socket, int messageID)](#InterruptedSocket-socket-int-messageID-Method)|
|[AsyncInterrupted(Socket socket, int messageID)](#AsyncInterruptedSocket-socket-int-messageID-Method)|
|[ReplyAsyncMaximumMessageSizeResponse(Socket socket, long MaximumMessageSize)](#ReplyAsyncMaximumMessageSizeResponseSocket-socket-long-MaximumMessageSize-Method)|
|[ReplyAsyncRemoteLocalResponse(Socket socket)](#ReplyAsyncRemoteLocalResponseSocket-socket-Method)|
|[ReplyAsyncStatusResponse(Socket socket, byte status)](#ReplyAsyncStatusResponseSocket-socket-byte-status-Method)|
|[ReplyAsyncLockInfoResponse(Socket socket, byte control)](#ReplyAsyncLockInfoResponseSocket-socket-byte-control-Method)|
|[ReceiveMsg(Socket socket)](#ReceiveMsgSocket-socket-Method)|
|[ReceiveString(Socket socket, long size)](#ReceiveStringSocket-socket-long-size-Method)|
|[ReceiveData(Socket socket, long size)](#ReceiveDataSocket-socket-long-size-Method)|
|[Flush(Socket socket)](#FlushSocket-socket-Method)|
|[Create(string ipString, int port)](#Createstring-ipString-int-port-Method)|
|[ChannelThread(Socket server, Socket socket)](#ChannelThreadSocket-server-Socket-socket-Method)|
|[RunThread(string host, int port, int count)](#RunThreadstring-host-int-port-int-count-Method)|
|[Destroy()](#Destroy-Method)|

## endPoint Property
```C#
IPEndPoint endPoint = new IPEndPoint(IPAddress.IPv6Any, 0);
```
## server Property
```C#
private Socket server = new Socket(SocketType.Stream, ProtocolType.Tcp);
```
## synchronous Property
```C#
private Socket synchronous = new Socket(SocketType.Stream, ProtocolType.Tcp);
```
## asynchronous Property
```C#
private Socket asynchronous = new Socket(SocketType.Stream, ProtocolType.Tcp);
```
## serverScpi Property
```C#
private ServerScpi serverScpi = new ServerScpi();
```
## tokenSource Property
```C#
private CancellationTokenSource tokenSource = new CancellationTokenSource();
```
## SessionID Property
```C#
private short SessionID = 123;
```
## MessageID Property
```C#
private int MessageID = 123;
```
## IsRMTwasDelivered Property
```C#
private byte IsRMTwasDelivered = Hislip.RMTwasNotDelivered;
```
## lockCount Property
```C#
private byte lockCount = 0;
```
## ReplyInitializeResponse(Socket socket, byte control, short ServerVersion, short SessionID) Method
```C#
public int ReplyInitializeResponse(Socket socket, byte control, short ServerVersion, short SessionID)
```
## ReplyAsyncInitializeResponse(Socket socket, byte control, short VendorID) Method
```C#
public int ReplyAsyncInitializeResponse(Socket socket, byte control, short VendorID)
```
## ReplyFatalError(Socket socket, byte control, string message) Method
```C#
public int ReplyFatalError(Socket socket, byte control, string message)
```
## ReplyError(Socket socket, byte control, string message) Method
```C#
public int ReplyError(Socket socket, byte control, string message)
```
## ReplyAsyncLockResponse(Socket socket, byte control) Method
```C#
public int ReplyAsyncLockResponse(Socket socket, byte control)
```
## DataTransfer(Socket socket, byte control, int messageID, byte[] message) Method
```C#
public int DataTransfer(Socket socket, byte control, int messageID, byte[] message)
```
## DataEndTransfer(Socket socket, byte control, int messageID, byte[] message) Method
```C#
public int DataEndTransfer(Socket socket, byte control, int messageID, byte[] message)
```
## ReplyAsyncDeviceClearAcknowledge(Socket socket, byte feature) Method
```C#
public int ReplyAsyncDeviceClearAcknowledge(Socket socket, byte feature)
```
## ReplyDeviceClearAcknowledge(Socket socket, byte feature) Method
```C#
public int ReplyDeviceClearAcknowledge(Socket socket, byte feature)
```
## Interrupted(Socket socket, int messageID) Method
```C#
public int Interrupted(Socket socket, int messageID)
```
## AsyncInterrupted(Socket socket, int messageID) Method
```C#
public int AsyncInterrupted(Socket socket, int messageID)
```
## ReplyAsyncMaximumMessageSizeResponse(Socket socket, long MaximumMessageSize) Method
```C#
public int ReplyAsyncMaximumMessageSizeResponse(Socket socket, long MaximumMessageSize)
```
## ReplyAsyncRemoteLocalResponse(Socket socket) Method
```C#
public int ReplyAsyncRemoteLocalResponse(Socket socket)
```
## ReplyAsyncStatusResponse(Socket socket, byte status) Method
```C#
public int ReplyAsyncStatusResponse(Socket socket, byte status)
```
## ReplyAsyncLockInfoResponse(Socket socket, byte control) Method
```C#
public int ReplyAsyncLockInfoResponse(Socket socket, byte control)
```
## ReceiveMsg(Socket socket) Method
```C#
public Hislip.Message ReceiveMsg(Socket socket)
```
## ReceiveString(Socket socket, long size) Method
```C#
public string ReceiveString(Socket socket, long size)
```
## ReceiveData(Socket socket, long size) Method
```C#
public byte[] ReceiveData(Socket socket, long size)
```
## Flush(Socket socket) Method
```C#
internal void Flush(Socket socket)
```
## Create(string ipString, int port) Method
```C#
internal void Create(string ipString, int port)
```
## ChannelThread(Socket server, Socket socket) Method
```C#
private Socket ChannelThread(Socket server, Socket socket)
```
## RunThread(string host, int port, int count) Method
```C#
public void RunThread(string host, int port, int count)
```
## Destroy() Method
```C#
public void Destroy()
```
