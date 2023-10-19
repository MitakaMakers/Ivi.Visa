English | 日本語

# ITcpipSession Interface

## Definition
Namespace:[Ivi.Visa](../Visa.md)<BR>
Assembly:Ivi.Visa.dll<BR>
Inheritance:[System.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) -> [Ivi.Visa.IVisaSession](IVisaSession.md) -> [Ivi.Visa.IMessageBasedSession](IMessageBasedSession.md) -> **Ivi.Visa.ITcpipSession**

## Properties

|Property Name|
|---|
|[Address](#Address-Property)|
|[DeviceName](#DeviceName-Property)|
|[HostName](#HostName-Property)|
|[Port](#Port-Property)|
|[IsHiSLIP](#IsHiSLIP-Property)|
|[HiSLIPOverlapEnabled](#HiSLIPOverlapEnabled-Property)|
|[HiSLIPProtocolVersion](#HiSLIPProtocolVersion-Property)|
|[HiSLIPMaximumMessageKBytes](#HiSLIPMaximumMessageKBytes-Property)|

## Methods

|Method Name|
|---|
|[SetBufferSize(IOBuffers buffers, Int32 size)](#SetBufferSizeIOBuffers-buffers-Int32-size-Method)|
|[SendRemoteLocalCommand(RemoteLocalMode mode)](#SendRemoteLocalCommandRemoteLocalMode-mode-Method)|

## Address Property
```C#
String Address { get; }
```
## DeviceName Property
```C#
String DeviceName { get; }
```
## HostName Property
```C#
String HostName { get; }
```
## HiSLIPOverlapEnabled Property
```C#
Boolean HiSLIPOverlapEnabled { get; set; }
```
## HiSLIPProtocolVersion Property
```C#
Version HiSLIPProtocolVersion { get; }
```
## HiSLIPMaximumMessageKBytes Property
```C#
Int32 HiSLIPMaximumMessageKBytes { get; set; }
```
## IsHiSLIP Property
```C#
Boolean IsHiSLIP { get; }
```
## Port Property
```C#
Int16 Port { get; }
```
## SetBufferSize(IOBuffers buffers, Int32 size) Method
```C#
Boolean SetBufferSize(IOBuffers buffers, Int32 size);
```
## SendRemoteLocalCommand(RemoteLocalMode mode) Method
```C#
void SendRemoteLocalCommand(RemoteLocalMode mode);
```