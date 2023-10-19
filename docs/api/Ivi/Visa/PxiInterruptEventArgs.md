English | 日本語

# PxiInterruptEventArgs Class

## Definition
Namespace:[Ivi.Visa](../Visa.md)<BR>
Assembly:Ivi.Visa.dll<BR>
Inheritance:[System.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object) -> [System.EventArgs](https://learn.microsoft.com/en-us/dotnet/api/system.eventargs) -> [Ivi.Visa.VisaEventArgs](VisaEventArgs.md) -> **Ivi.Visa.PxiInterruptEventArgs**

## Constructors

|Method Name|
|---|
|[PxiInterruptEventArgs(Int16 sequence, Int32 data)](#PxiInterruptEventArgsInt16-sequence-Int32-data-constructor)|

## Properties

|Property Name|
|---|
|[Sequence](#Sequence-Property)|
|[Data](#Data-Property)|

## PxiInterruptEventArgs(Int16 sequence, Int32 data) Constructor
```C#
public PxiInterruptEventArgs(Int16 sequence, Int32 data)
```
## Sequence Property
```C#
public Int16 Sequence { get; private set; }
```
## Data Property
```C#
public Int32 Data { get; private set; }
```
