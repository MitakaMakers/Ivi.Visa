# ClientHislip Class

## Definition
Namespace:[Vxi11Net](../Vxi11Net.md)<BR>
Assembly:TmctlAPINet.dll

## Properties

|Property Name|
|---|
|[synchronous](#synchronous-Property)|
|[asynchronous](#asynchronous-Property)|
|[MessageID](#MessageID-Property)|

## Methods

|Method Name|
|---|
|[Initialize(Socket socket, short clientVersion, short vendorID, string sub_address)](#InitializeSocket-socket-short-clientVersion-short-vendorID-string-sub_address-Method)|
|[AsyncInitialization(Socket socket, short sessionID)](#AsyncInitializationSocket-socket-short-sessionID-Method)|
|[FatalErrorNotification(Socket socket, string message)](#FatalErrorNotificationSocket-socket-string-message-Method)|
|[ErrorNotification(Socket socket, string message)](#ErrorNotificationSocket-socket-string-message-Method)|
|[DataTransfer(Socket socket, byte controlcode, int messageID, byte[] data)](#DataTransferSocket-socket-byte-controlcode-int-messageID-byte-data-Method)|
|[DataEndTransfer(Socket socket, byte controlcode, int messageID, byte[] data)](#DataEndTransferSocket-socket-byte-controlcode-int-messageID-byte-data-Method)|
|[Lock(Socket socket, byte controlcode, int timeout, string lockstring)](#LockSocket-socket-byte-controlcode-int-timeout-string-lockstring-Method)|
|[ReleaseLock(Socket socket, byte controlcode, int messageID)](#ReleaseLockSocket-socket-byte-controlcode-int-messageID-Method)|
|[LockInfo(Socket socket)](#LockInfoSocket-socket-Method)|
|[Remote(Socket socket, byte controlcode, int messageID)](#RemoteSocket-socket-byte-controlcode-int-messageID-Method)|
|[Local(Socket socket, byte controlcode, int messageID)](#LocalSocket-socket-byte-controlcode-int-messageID-Method)|
|[DeviceClear(Socket socket, byte feature)](#DeviceClearSocket-socket-byte-feature-Method)|
|[DeviceClearComplete(Socket socket, byte feature)](#DeviceClearCompleteSocket-socket-byte-feature-Method)|
|[Trigger(Socket socket, byte controlcode, int messageID)](#TriggerSocket-socket-byte-controlcode-int-messageID-Method)|
|[MaximumMessageSize(Socket socket, long maxmsgsize)](#MaximumMessageSizeSocket-socket-long-maxmsgsize-Method)|
|[StatusQuery(Socket socket, byte controlcode, int messageID)](#StatusQuerySocket-socket-byte-controlcode-int-messageID-Method)|
|[Create(string ipString, int port)](#Createstring-ipString-int-port-Method)|
|[Destroy()](#Destroy-Method)|
|[Send(Socket socket, byte[] buffer)](#SendSocket-socket-byte-buffer-Method)|
|[Receive(Socket socket, byte[] buffer)](#ReceiveSocket-socket-byte-buffer-Method)|
|[Flush(Socket socket)](#FlushSocket-socket-Method)|

## synchronous Property
```C#
private Socket synchronous = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
```
## asynchronous Property
```C#
private Socket asynchronous = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
```
## MessageID Property
```C#
private uint MessageID;
```
## Initialize(Socket socket, short clientVersion, short vendorID, string sub_address) Method
```C#
internal static int Initialize(Socket socket, short clientVersion, short vendorID, string sub_address)
```
## AsyncInitialization(Socket socket, short sessionID) Method
```C#
internal static int AsyncInitialization(Socket socket, short sessionID)
```
## FatalErrorNotification(Socket socket, string message) Method
```C#
internal static int FatalErrorNotification(Socket socket, string message)
```
## ErrorNotification(Socket socket, string message) Method
```C#
internal static int ErrorNotification(Socket socket, string message)
```
## DataTransfer(Socket socket, byte controlcode, int messageID, byte[] data) Method
```C#
internal static int DataTransfer(Socket socket, byte controlcode, int messageID, byte[] data)
```
## DataEndTransfer(Socket socket, byte controlcode, int messageID, byte[] data) Method
```C#
internal static int DataEndTransfer(Socket socket, byte controlcode, int messageID, byte[] data)
```
## Lock(Socket socket, byte controlcode, int timeout, string lockstring) Method
```C#
internal static int Lock(Socket socket, byte controlcode, int timeout, string lockstring)
```
## ReleaseLock(Socket socket, byte controlcode, int messageID) Method
```C#
internal static int ReleaseLock(Socket socket, byte controlcode, int messageID)
```
## LockInfo(Socket socket) Method
```C#
internal static int LockInfo(Socket socket)
```
## Remote(Socket socket, byte controlcode, int messageID) Method
```C#
internal static int Remote(Socket socket, byte controlcode, int messageID)
```
## Local(Socket socket, byte controlcode, int messageID) Method
```C#
internal static int Local(Socket socket, byte controlcode, int messageID)
```
## DeviceClear(Socket socket, byte feature) Method
```C#
internal static int DeviceClear(Socket socket, byte feature)
```
## DeviceClearComplete(Socket socket, byte feature) Method
```C#
internal static int DeviceClearComplete(Socket socket, byte feature)
```
## Trigger(Socket socket, byte controlcode, int messageID) Method
```C#
internal static int Trigger(Socket socket, byte controlcode, int messageID)
```
## MaximumMessageSize(Socket socket, long maxmsgsize) Method
```C#
internal static int MaximumMessageSize(Socket socket, long maxmsgsize)
```
## StatusQuery(Socket socket, byte controlcode, int messageID) Method
```C#
internal static int StatusQuery(Socket socket, byte controlcode, int messageID)
```
## Create(string ipString, int port) Method
```C#
internal void Create(string ipString, int port)
```
## Destroy() Method
```C#
public void Destroy()
```
## Send(Socket socket, byte[] buffer) Method
```C#
internal int Send(Socket socket, byte[] buffer)
```
## Receive(Socket socket, byte[] buffer) Method
```C#
internal int Receive(Socket socket, byte[] buffer)
```
## Flush(Socket socket) Method
```C#
internal void Flush(Socket socket)
```
