English | 日本語

# IVxiSession Interface

## Definition
Namespace:[Ivi.Visa](../Visa.md)<BR>
Assembly:Ivi.Visa.dll<BR>
Inheritance:[System.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) -> [Ivi.Visa.IVisaSession](IVisaSession.md) -> [Ivi.Visa.IRegisterBasedSession](IRegisterBasedSession.md) -> **Ivi.Visa.IVxiSession**<BR>
Inheritance:[System.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) -> [Ivi.Visa.IVisaSession](IVisaSession.md) -> [Ivi.Visa.IMessageBasedSession](IMessageBasedSession.md) -> **Ivi.Visa.IVxiSession**

## Properties

|Property Name|
|---|
|[CommanderLogicalAddress](#CommanderLogicalAddress-Property)|
|[DestinationAccessPrivilege](#DestinationAccessPrivilege-Property)|
|[DestinationByteOrder](#DestinationByteOrder-Property)|
|[DeviceClass](#DeviceClass-Property)|
|[FastDataChannelNumber](#FastDataChannelNumber-Property)|
|[FastDataChannelUseStreaming](#FastDataChannelUseStreaming-Property)|
|[FastDataChannelUsePair](#FastDataChannelUsePair-Property)|
|[Is4882Compliant](#Is4882Compliant-Property)|
|[IsImmediateServant](#IsImmediateServant-Property)|
|[LogicalAddress](#LogicalAddress-Property)|
|[ChassisLogicalAddress](#ChassisLogicalAddress-Property)|
|[ManufacturerId](#ManufacturerId-Property)|
|[ManufacturerName](#ManufacturerName-Property)|
|[MemoryMapAccessPrivilege](#MemoryMapAccessPrivilege-Property)|
|[MemoryMapByteOrder](#MemoryMapByteOrder-Property)|
|[MemoryBase](#MemoryBase-Property)|
|[MemorySize](#MemorySize-Property)|
|[MemorySpace](#MemorySpace-Property)|
|[SourceByteOrder](#SourceByteOrder-Property)|
|[ModelCode](#ModelCode-Property)|
|[ModelName](#ModelName-Property)|
|[Slot](#Slot-Property)|
|[SourceAccessPrivilege](#SourceAccessPrivilege-Property)|
|[TriggerLine](#TriggerLine-Property)|
|[TriggerSupport](#TriggerSupport-Property)|

## Events

|Event Name|
|---|
|[Interrupt](#Interrupt-Event)|
|[SignalProcessor](#SignalProcessor-Event)|
|[Trigger](#Trigger-Event)|

## Methods

|Method Name|
|---|
|[AssertTrigger(VxiTriggerProtocol protocol)](#AssertTriggerVxiTriggerProtocol-protocol-Method)|
|[CommandQuery(VxiCommandMode mode, Int32 command)](#CommandQueryVxiCommandMode-mode-Int32-command-Method)|
|[MemoryAllocate(Int64 size)](#MemoryAllocateInt64-size-Method)|
|[MemoryFree(Int64 offset)](#MemoryFreeInt64-offset-Method)|

## CommanderLogicalAddress Property
```C#
Int16 CommanderLogicalAddress { get; }
```
## DestinationAccessPrivilege Property
```C#
VxiAccessPrivilege DestinationAccessPrivilege { get; set; }
```
## DestinationByteOrder Property
```C#
ByteOrder DestinationByteOrder { get; set; }
```
## DeviceClass Property
```C#
VxiDeviceClass DeviceClass { get; }
```
## FastDataChannelNumber Property
```C#
Int16 FastDataChannelNumber { get; set; }
```
## FastDataChannelUseStreaming Property
```C#
Boolean FastDataChannelUseStreaming { get; set; }
```
## FastDataChannelUsePair Property
```C#
Boolean FastDataChannelUsePair { get; set; }
```
## Is4882Compliant Property
```C#
Boolean Is4882Compliant { get; }
```
## IsImmediateServant Property
```C#
Boolean IsImmediateServant { get; }
```
## LogicalAddress Property
```C#
Int16 LogicalAddress { get; }
```
## ChassisLogicalAddress Property
```C#
Int16 ChassisLogicalAddress { get; }
```
## ManufacturerId Property
```C#
Int16 ManufacturerId { get; }
```
## ManufacturerName Property
```C#
String ManufacturerName { get; }
```
## MemoryMapAccessPrivilege Property
```C#
VxiAccessPrivilege MemoryMapAccessPrivilege { get; set; }
```
## MemoryMapByteOrder Property
```C#
ByteOrder MemoryMapByteOrder { get; set; }
```
## MemoryBase Property
```C#
Int64 MemoryBase { get; }
```
## MemorySize Property
```C#
Int64 MemorySize { get; }
```
## MemorySpace Property
```C#
AddressSpace MemorySpace { get; }
```
## SourceByteOrder Property
```C#
ByteOrder SourceByteOrder { get; set; }
```
## ModelCode Property
```C#
Int16 ModelCode { get; }
```
## ModelName Property
```C#
String ModelName { get; }
```
## Slot Property
```C#
Int16 Slot { get; }
```
## SourceAccessPrivilege Property
```C#
VxiAccessPrivilege SourceAccessPrivilege { get; set; }
```
## TriggerLine Property
```C#
TriggerLine TriggerLine { get; set; }
```
## TriggerSupport Property
```C#
TriggerLines TriggerSupport { get; }
```
## Interrupt Event
```C#
event EventHandler<VxiInterruptEventArgs> Interrupt;
```
## SignalProcessor Event
```C#
event EventHandler<VxiSignalProcessorEventArgs> SignalProcessor;
```
## Trigger Event
```C#
event EventHandler<VxiTriggerEventArgs> Trigger;
```
## AssertTrigger(VxiTriggerProtocol protocol) Method
```C#
void AssertTrigger(VxiTriggerProtocol protocol);
```
## CommandQuery(VxiCommandMode mode, Int32 command) Method
```C#
Int32 CommandQuery(VxiCommandMode mode, Int32 command);
```
## MemoryAllocate(Int64 size) Method
```C#
Int64 MemoryAllocate(Int64 size);
```
## MemoryFree(Int64 offset) Method
```C#
void MemoryFree(Int64 offset);
```
