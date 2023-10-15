English | 日本語

# IVxiBackplaneSession Interface

## Definition
Namespace:[Ivi.Visa](Ivi.Visa.md)<BR>
Assembly:Ivi.Visa.dll<BR>
Inheritance:[System.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) -> [Ivi.Visa.IVisaSession](Ivi.Visa.IVisaSession.md) -> **Ivi.Visa.IVxiBackplaneSession**<BR>

## Events

|Event Name|
|---|
|[Trigger](#Trigger-Event)|
|[SystemFailure](#SystemFailure-Event)|
|[SystemReset](#SystemReset-Event)|

## Properties

|Property Name|
|---|
|[ChassisLogicalAddress](#ChassisLogicalAddress-Property)|
|[TriggerStatus](#TriggerStatus-Property)|
|[TriggerSupport](#TriggerSupport-Property)|
|[InterruptStatus](#InterruptStatus-Property)|
|[SystemFailureStatus](#SystemFailureStatus-Property)|

## Methods

|Method Name|
|---|
|[AssertInterrupt(Int16 irqLevel, Int32 statusId)](#AssertInterruptInt16-irqLevel-Int32-statusId-Method)|
|[AssertTrigger(TriggerLine line, VxiTriggerProtocol protocol)](#AssertTriggerTriggerLine-line-VxiTriggerProtocol-protocol-Method)|
|[AssertUtilitySignal(VxiUtilitySignal signal)](#AssertUtilitySignalVxiUtilitySignal-signal-Method)|
|[MapTrigger(TriggerLine sourceLine, TriggerLine destinationLine)](#MapTriggerTriggerLine-sourceLine-TriggerLine-destinationLine-Method)|
|[MapTrigger(TriggerLine sourceLine, TriggerLine destinationLine, out Boolean alreadyMapped)](#MapTriggerTriggerLine-sourceLine-TriggerLine-destinationLine-out-Boolean-alreadyMapped-Method)|
|[UnmapTrigger(TriggerLine sourceLine)](#UnmapTriggerTriggerLine-sourceLine-Method)|
|[UnmapTrigger(TriggerLine sourceLine, TriggerLine destinationLine)](#UnmapTriggerTriggerLine-sourceLine-TriggerLine-destinationLine-Method)|

## Trigger Event
```C#
event EventHandler<VxiTriggerEventArgs> Trigger;
```
## SystemFailure Event
```C#
event EventHandler<VisaEventArgs> SystemFailure;
```
## SystemReset Event
```C#
event EventHandler<VisaEventArgs> SystemReset;
```
## ChassisLogicalAddress Property
```C#
Int16 ChassisLogicalAddress { get; }
```
## TriggerStatus Property
```C#
TriggerLines TriggerStatus { get; }
```
## TriggerSupport Property
```C#
TriggerLines TriggerSupport { get; }
```
## InterruptStatus Property
```C#
Int16 InterruptStatus { get; }
```
## SystemFailureStatus Property
```C#
LineState SystemFailureStatus { get; }
```
## AssertInterrupt(Int16 irqLevel, Int32 statusId) Method
```C#
void AssertInterrupt(Int16 irqLevel, Int32 statusId);
```
## AssertTrigger(TriggerLine line, VxiTriggerProtocol protocol) Method
```C#
void AssertTrigger(TriggerLine line, VxiTriggerProtocol protocol);
```
## AssertUtilitySignal(VxiUtilitySignal signal) Method
```C#
void AssertUtilitySignal(VxiUtilitySignal signal);
```
## MapTrigger(TriggerLine sourceLine, TriggerLine destinationLine) Method
```C#
void MapTrigger(TriggerLine sourceLine, TriggerLine destinationLine);
```
## MapTrigger(TriggerLine sourceLine, TriggerLine destinationLine, out Boolean alreadyMapped) Method
```C#
void MapTrigger(TriggerLine sourceLine, TriggerLine destinationLine, out Boolean alreadyMapped);
```
## UnmapTrigger(TriggerLine sourceLine) Method
```C#
void UnmapTrigger(TriggerLine sourceLine);
```
## UnmapTrigger(TriggerLine sourceLine, TriggerLine destinationLine) Method
```C#
void UnmapTrigger(TriggerLine sourceLine, TriggerLine destinationLine);
```
