English | 日本語

# IGpibSession Interface

## Definition
Namespace:[Ivi.Visa](../Visa.md)<BR>
Assembly:Ivi.Visa.dll<BR>
Inheritance:[System.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) -> [Ivi.Visa.IVisaSession](IVisaSession.md) -> [Ivi.Visa.IMessageBasedSession](IMessageBasedSession.md) -> **Ivi.Visa.IGpibSession**

## Properties

|Property Name|
|---|
|[AllowDma](#AllowDma-Property)|
|[PrimaryAddress](#PrimaryAddress-Property)|
|[ReaddressingEnabled](#ReaddressingEnabled-Property)|
|[RenState](#RenState-Property)|
|[SecondaryAddress](#SecondaryAddress-Property)|
|[UnaddressingEnabled](#UnaddressingEnabled-Property)|

## Methods

|Method Name|
|---|
|[SendRemoteLocalCommand(GpibInstrumentRemoteLocalMode mode)](#SendRemoteLocalCommandGpibInstrumentRemoteLocalMode-mode-Method)|
|[SendRemoteLocalCommand(RemoteLocalMode mode)](#SendRemoteLocalCommandRemoteLocalMode-mode-Method)|

## AllowDma Property
```C#
Boolean AllowDma { get; set; }
```
## PrimaryAddress Property
```C#
Int16 PrimaryAddress { get; }
```
## ReaddressingEnabled Property
```C#
Boolean ReaddressingEnabled { get; set; }
```
## RenState Property
```C#
LineState RenState { get; }
```
## SecondaryAddress Property
```C#
Int16 SecondaryAddress { get; }
```
## UnaddressingEnabled Property
```C#
Boolean UnaddressingEnabled { get; set; }
```
## SendRemoteLocalCommand(GpibInstrumentRemoteLocalMode mode) Method
```C#
void SendRemoteLocalCommand(GpibInstrumentRemoteLocalMode mode);
```
## SendRemoteLocalCommand(RemoteLocalMode mode) Method
```C#
void SendRemoteLocalCommand(RemoteLocalMode mode);
```
