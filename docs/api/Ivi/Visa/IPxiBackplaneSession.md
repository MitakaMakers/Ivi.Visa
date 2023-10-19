English | 日本語

# IPxiBackplaneSession Interface

## Definition
Namespace:[Ivi.Visa](../Visa.md)<BR>
Assembly:Ivi.Visa.dll<BR>
Inheritance:[System.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) -> [Ivi.Visa.IVisaSession](IVisaSession.md) -> **Ivi.Visa.IPxiBackplaneSession**<BR>

## Properties

|Property Name|
|---|
|[ChassisNumber](#ChassisNumber-Property)|
|[ManufacturerName](#ManufacturerName-Property)|
|[ModelName](#ModelName-Property)|

## Methods

|Method Name|
|---|
|[ReserveTrigger(Int16 bus, TriggerLine line)](#ReserveTriggerInt16-bus-TriggerLine-line-Method)|
|[ReserveTriggers(Int16[] buses, TriggerLine[] lines)](#ReserveTriggersInt16-buses-TriggerLine-lines-Method)|
|[UnreserveTrigger(Int16 bus, TriggerLine line)](#UnreserveTriggerInt16-bus-TriggerLine-line-Method)|
|[MapTrigger(Int16 sourceBus, TriggerLine sourceLine, Int16 destinationBus, TriggerLine destinationLine)](#MapTriggerInt16-sourceBus-TriggerLine-sourceLine-Int16-destinationBus-TriggerLine-destinationLine-Method)|
|[MapTrigger(Int16 sourceBus, TriggerLine sourceLine, Int16 destinationBus, TriggerLine destinationLine, out Boolean alreadyMapped)](#MapTriggerInt16-sourceBus-TriggerLine-sourceLine-Int16-destinationBus-TriggerLine-destinationLine-out-Boolean-alreadyMapped-Method)|
|[UnmapTrigger(Int16 sourceBus, TriggerLine sourceLine)](#UnmapTriggerInt16-sourceBus-TriggerLine-sourceLine-Method)|
|[UnmapTrigger(Int16 sourceBus, TriggerLine sourceLine,Int16 destinationBus, TriggerLine destinationLine)](#UnmapTriggerInt16-sourceBus-TriggerLine-sourceLine,Int16-destinationBus-TriggerLine-destinationLine-Method)|

## ChassisNumber Property
```C#
Int16 ChassisNumber { get; }
```
## ManufacturerName Property
```C#
String ManufacturerName { get; }
```
## ModelName Property
```C#
String ModelName { get; }
```
## ReserveTrigger(Int16 bus, TriggerLine line) Method
```C#
void ReserveTrigger(Int16 bus, TriggerLine line);
```
## ReserveTriggers(Int16[] buses, TriggerLine[] lines) Method
```C#
void ReserveTriggers(Int16[] buses, TriggerLine[] lines);
```
## UnreserveTrigger(Int16 bus, TriggerLine line) Method
```C#
void UnreserveTrigger(Int16 bus, TriggerLine line);
```
## MapTrigger(Int16 sourceBus, TriggerLine sourceLine, Int16 destinationBus, TriggerLine destinationLine) Method
```C#
void MapTrigger(Int16 sourceBus, TriggerLine sourceLine, Int16 destinationBus, TriggerLine destinationLine);
```
## MapTrigger(Int16 sourceBus, TriggerLine sourceLine, Int16 destinationBus, TriggerLine destinationLine, out Boolean alreadyMapped) Method
```C#
void MapTrigger(Int16 sourceBus, TriggerLine sourceLine, Int16 destinationBus, TriggerLine destinationLine, out Boolean alreadyMapped);
```
## UnmapTrigger(Int16 sourceBus, TriggerLine sourceLine) Method
```C#
void UnmapTrigger(Int16 sourceBus, TriggerLine sourceLine);
```
## UnmapTrigger(Int16 sourceBus, TriggerLine sourceLine,Int16 destinationBus, TriggerLine destinationLine) Method
```C#
void UnmapTrigger(Int16 sourceBus, TriggerLine sourceLine,Int16 destinationBus, TriggerLine destinationLine);
```
