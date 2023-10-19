English | 日本語

# VxiInterruptEventArgs Class

## Definition
Namespace:[Ivi.Visa](../Visa.md)<BR>
Assembly:Ivi.Visa.dll<BR>
Inheritance:[System.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object) -> [System.EventArgs](https://learn.microsoft.com/en-us/dotnet/api/system.eventargs) -> [Ivi.Visa.VisaEventArgs](VisaEventArgs.md) -> **Ivi.Visa.VxiInterruptEventArgs**

## Constructors

|Method Name|
|---|
|[VxiInterruptEventArgs(Int16 irqLevel, Int32 statusId)](#VxiInterruptEventArgsInt16-irqLevel-Int32-statusId-constructor)|

## Properties

|Property Name|
|---|
|[IrqLevel](#IrqLevel-Property)|
|[StatusId](#StatusId-Property)|

## VxiInterruptEventArgs(Int16 irqLevel, Int32 statusId) Constructor
```C#
public VxiInterruptEventArgs(Int16 irqLevel, Int32 statusId) Constructor
```
## IrqLevel Property
```C#
public Int16 IrqLevel { get; private set; }
```
## StatusId Property
```C#
public Int32 StatusId { get; private set; }
```
