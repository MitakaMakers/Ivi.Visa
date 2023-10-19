English | 日本語

# ITcpipSocketSession Interface

## Definition
Namespace:[Ivi.Visa](../Visa.md)<BR>
Assembly:Ivi.Visa.dll<BR>
Inheritance:[System.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) -> [Ivi.Visa.IVisaSession](IVisaSession.md) -> [Ivi.Visa.IMessageBasedSession](IMessageBasedSession.md) -> **Ivi.Visa.ITcpipSocketSession**

## Properties

|Property Name|
|---|
|[Address](#Address-Property)|
|[HostName](#HostName-Property)|
|[KeepAlive](#KeepAlive-Property)|
|[NoDelay](#NoDelay-Property)|
|[Port](#Port-Property)|

## Methods

|Method Name|
|---|
|[Flush(IOBuffers buffers, Boolean discard)](#FlushIOBuffers-buffers-Boolean-discard-Method)|
|[SetBufferSize(IOBuffers buffers, Int32 size)](#SetBufferSizeIOBuffers-buffers-Int32-size-Method)|

## Address Property
```C#
String Address { get; }
```
## HostName Property
```C#
String HostName { get; }
```
## KeepAlive Property
```C#
Boolean KeepAlive { get; set; }
```
## NoDelay Property
```C#
Boolean NoDelay { get; set; }
```
## Port Property
```C#
Int16 Port { get; }
```

## Flush(IOBuffers buffers, Boolean discard) Method
```C#
void Flush(IOBuffers buffers, Boolean discard);
```
## SetBufferSize(IOBuffers buffers, Int32 size) Method
```C#
Boolean SetBufferSize(IOBuffers buffers, Int32 size);
```
