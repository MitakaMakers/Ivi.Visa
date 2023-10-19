English | 日本語

# IPxiSession Interface

## Definition
Namespace:[Ivi.Visa](../Visa.md)<BR>
Assembly:Ivi.Visa.dll<BR>
Inheritance:[System.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) -> [Ivi.Visa.IVisaSession](IVisaSession.md) -> [Ivi.Visa.IRegisterBasedSession](IRegisterBasedSession.md) -> **Ivi.Visa.IPxiSession**

## Properties

|Property Name|
|---|
|[ActualLinkWidth](#ActualLinkWidth-Property)|
|[AllowWriteCombining](#AllowWriteCombining-Property)|
|[BusNumber](#BusNumber-Property)|
|[ChassisNumber](#ChassisNumber-Property)|
|[DeviceNumber](#DeviceNumber-Property)|
|[DstarBusNumber](#DstarBusNumber-Property)|
|[DstarLineSet](#DstarLineSet-Property)|
|[FunctionNumber](#FunctionNumber-Property)|
|[IsExpress](#IsExpress-Property)|
|[ManufacturerId](#ManufacturerId-Property)|
|[ManufacturerName](#ManufacturerName-Property)|
|[MaxLinkWidth](#MaxLinkWidth-Property)|
|[MemTypeBar0](#MemTypeBar0-Property)|
|[MemTypeBar1](#MemTypeBar1-Property)|
|[MemTypeBar2](#MemTypeBar2-Property)|
|[MemTypeBar3](#MemTypeBar3-Property)|
|[MemTypeBar4](#MemTypeBar4-Property)|
|[MemTypeBar5](#MemTypeBar5-Property)|
|[MemBaseBar0](#MemBaseBar0-Property)|
|[MemBaseBar1](#MemBaseBar1-Property)|
|[MemBaseBar2](#MemBaseBar2-Property)|
|[MemBaseBar3](#MemBaseBar3-Property)|
|[MemBaseBar4](#MemBaseBar4-Property)|
|[MemBaseBar5](#MemBaseBar5-Property)|
|[MemSizeBar0](#MemSizeBar0-Property)|
|[MemSizeBar1](#MemSizeBar1-Property)|
|[MemSizeBar2](#MemSizeBar2-Property)|
|[MemSizeBar3](#MemSizeBar3-Property)|
|[MemSizeBar4](#MemSizeBar4-Property)|
|[MemSizeBar5](#MemSizeBar5-Property)|
|[ModelCode](#ModelCode-Property)|
|[ModelName](#ModelName-Property)|
|[Slot](#Slot-Property)|
|[SlotLinkWidth](#SlotLinkWidth-Property)|
|[SlotLocalBusLeft](#SlotLocalBusLeft-Property)|
|[SlotLocalBusRight](#SlotLocalBusRight-Property)|
|[SlotPath](#SlotPath-Property)|
|[StarTriggerBus](#StarTriggerBus-Property)|
|[StarTriggerLine](#StarTriggerLine-Property)|
|[TriggerBus](#TriggerBus-Property)|

## Events

|Event Name|
|---|
|[Interrupt](#Interrupt-Event)|

## Methods

|Method Name|
|---|
|[ReserveTrigger(TriggerLine line)](#ReserveTriggerTriggerLine-line-Method)|
|[UnreserveTrigger(TriggerLine line)](#UnreserveTriggerTriggerLine-line-Method)|

## ActualLinkWidth Property
```C#
Int16 ActualLinkWidth { get; }
```
## AllowWriteCombining Property
```C#
Boolean AllowWriteCombining { get; set; }
```
## BusNumber Property
```C#
Int16 BusNumber { get; }
```
## ChassisNumber Property
```C#
Int16 ChassisNumber { get; }
```
## DeviceNumber Property
```C#
Int16 DeviceNumber { get; }
```
## DstarBusNumber Property
```C#
Int16 DstarBusNumber { get; }
```
## DstarLineSet Property
```C#
Int16 DstarLineSet { get; }
```
## FunctionNumber Property
```C#
Int16 FunctionNumber { get; }
```
## IsExpress Property
```C#
Boolean IsExpress { get; }
```
## ManufacturerId Property
```C#
Int16 ManufacturerId { get; }
```
## ManufacturerName Property
```C#
String ManufacturerName { get; }
```
## MaxLinkWidth Property
```C#
Int16 MaxLinkWidth { get; }
```
## MemTypeBar0 Property
```C#
PxiMemoryType MemTypeBar0 { get; }
```
## MemTypeBar1 Property
```C#
PxiMemoryType MemTypeBar1 { get; }
```
## MemTypeBar2 Property
```C#
PxiMemoryType MemTypeBar2 { get; }
```
## MemTypeBar3 Property
```C#
PxiMemoryType MemTypeBar3 { get; }
```
## MemTypeBar4 Property
```C#
PxiMemoryType MemTypeBar4 { get; }
```
## MemTypeBar5 Property
```C#
PxiMemoryType MemTypeBar5 { get; }
```
## MemBaseBar0 Property
```C#
Int64 MemBaseBar0 { get; }
```
## MemBaseBar1 Property
```C#
Int64 MemBaseBar1 { get; }
```
## MemBaseBar2 Property
```C#
Int64 MemBaseBar2 { get; }
```
## MemBaseBar3 Property
```C#
Int64 MemBaseBar3 { get; }
```
## MemBaseBar4 Property
```C#
Int64 MemBaseBar4 { get; }
```
## MemBaseBar5 Property
```C#
Int64 MemBaseBar5 { get; }
```
## MemSizeBar0 Property
```C#
Int64 MemSizeBar0 { get; }
```
## MemSizeBar1 Property
```C#
Int64 MemSizeBar1 { get; }
```
## MemSizeBar2 Property
```C#
Int64 MemSizeBar2 { get; }
```
## MemSizeBar3 Property
```C#
Int64 MemSizeBar3 { get; }
```
## MemSizeBar4 Property
```C#
Int64 MemSizeBar4 { get; }
```
## MemSizeBar5 Property
```C#
Int64 MemSizeBar5 { get; }
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
## SlotLinkWidth Property
```C#
Int16 SlotLinkWidth { get; }
```
## SlotLocalBusLeft Property
```C#
Int16 SlotLocalBusLeft { get; }
```
## SlotLocalBusRight Property
```C#
Int16 SlotLocalBusRight { get; }
```
## SlotPath Property
```C#
String SlotPath { get; }
```
## StarTriggerBus Property
```C#
Int16 StarTriggerBus { get; }
```
## StarTriggerLine Property
```C#
Int16 StarTriggerLine { get; }
```
## TriggerBus Property
```C#
Int16 TriggerBus { get; }
```
## Interrupt Event
```C#
event EventHandler<PxiInterruptEventArgs> Interrupt;
```
## ReserveTrigger(TriggerLine line) Method
```C#
void ReserveTrigger(TriggerLine line);
```
## UnreserveTrigger(TriggerLine line) Method
```C#
void UnreserveTrigger(TriggerLine line);
```
