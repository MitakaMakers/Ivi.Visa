English | 日本語

# IUsbSession Interface

## Definition
Namespace:[Ivi.Visa](../Visa.md)<BR>
Assembly:Ivi.Visa.dll<BR>
Inheritance:[System.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) -> [Ivi.Visa.IVisaSession](IVisaSession.md) -> [Ivi.Visa.IMessageBasedSession](IMessageBasedSession.md) -> **Ivi.Visa.IUsbSession**

## Properties

|Property Name|
|---|
|[Is4882Compliant](#Is4882Compliant-Property)|
|[MaximumInterruptSize](#MaximumInterruptSize-Property)|
|[ManufacturerId](#ManufacturerId-Property)|
|[ManufacturerName](#ManufacturerName-Property)|
|[ModelCode](#ModelCode-Property)|
|[ModelName](#ModelName-Property)|
|[UsbInterfaceNumber](#UsbInterfaceNumber-Property)|
|[UsbProtocol](#UsbProtocol-Property)|
|[UsbSerialNumber](#UsbSerialNumber-Property)|

## Events

|Event Name|
|---|
|[Interrupt](#Interrupt-Event)|

## Methods

|Method Name|
|---|
|[ControlIn(Int16 requestType, Int16 request, Int16 value, Int16 index, Int16 length)](#ControlInInt16-requestType-Int16-request-Int16-value-Int16-index-Int16-length-Method)|
|[ControlOut(Int16 requestType, Int16 request, Int16 value, Int16 index)](#ControlOutInt16-requestType-Int16-request-Int16-value-Int16-index-Method)|
|[ControlOut(Int16 requestType, Int16 request, Int16 value, Int16 index, Byte[] data)](#ControlOutInt16-requestType-Int16-request-Int16-value-Int16-index-Byte-data-Method)|
|[SendRemoteLocalCommand(RemoteLocalMode mode)](#SendRemoteLocalCommandRemoteLocalMode-mode-Method)|

## Is4882Compliant Property
```C#
Boolean Is4882Compliant { get; }
```
## MaximumInterruptSize Property
```C#
Int16 MaximumInterruptSize { get; set; }
```
## ManufacturerId Property
```C#
Int16 ManufacturerId { get; }
```
## ManufacturerName Property
```C#
String ManufacturerName { get; }
```
## ModelCode Property
```C#
Int16 ModelCode { get; }
```
## ModelName Property
```C#
String ModelName { get; }
```
## UsbInterfaceNumber Property
```C#
Int16 UsbInterfaceNumber { get; }
```
## UsbProtocol Property
```C#
Int16 UsbProtocol { get; }
```
## UsbSerialNumber Property
```C#
String UsbSerialNumber { get; }
```
## Interrupt Event
```C#
event EventHandler<UsbInterruptEventArgs> Interrupt;
```
## ControlIn(Int16 requestType, Int16 request, Int16 value, Int16 index, Int16 length) Method
```C#
Byte[] ControlIn(Int16 requestType, Int16 request, Int16 value, Int16 index, Int16 length);
```
## ControlOut(Int16 requestType, Int16 request, Int16 value, Int16 index) Method
```C#
void ControlOut(Int16 requestType, Int16 request, Int16 value, Int16 index);
```
## ControlOut(Int16 requestType, Int16 request, Int16 value, Int16 index, Byte[] data) Method
```C#
void ControlOut(Int16 requestType, Int16 request, Int16 value, Int16 index, Byte[] data);
```
## SendRemoteLocalCommand(RemoteLocalMode mode) Method
```C#
void SendRemoteLocalCommand(RemoteLocalMode mode);
```
