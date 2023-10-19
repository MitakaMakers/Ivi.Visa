# ClientSocket Class

## Definition
Namespace:[Vxi11Net](../Vxi11Net.md)<BR>
Assembly:TmctlAPINet.dll

## Properties

|Property Name|
|---|
|[socket](#socket-Property)|
|[endPoint](#endPoint-Property)|

## Methods

|Method Name|
|---|
|[Send(byte[] buffer)](#Sendbyte-buffer-Method)|
|[Receive(byte[] buffer)](#Receivebyte-buffer-Method)|
|[Flush()](#Flush-Method)|
|[Create(string ipString, int port)](#Createstring-ipString-int-port-Method)|
|[Destroy()](#Destroy-Method)|

## socket Property
```C#
private Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
```
## endPoint Property
```C#
IPEndPoint endPoint = new IPEndPoint(IPAddress.IPv6Any, 0);
```
## Send(byte[] buffer) Method
```C#
public int Send(byte[] buffer)
```
## Receive(byte[] buffer) Method
```C#
public int Receive(byte[] buffer)
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
