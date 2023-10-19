English | 日本語

# IMemoryMap Interface

## Definition
Namespace:[Ivi.Visa](../Visa.md)<BR>
Assembly:Ivi.Visa.dll<BR>
Inheritance:[System.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) -> **Ivi.Visa.IMemoryMap**

## Properties

|Property Name|
|---|
|[AddressSpace](#AddressSpace-Property)|
|[BaseAddress](#BaseAddress-Property)|
|[Size](#Size-Property)|
|[VirtualAddress](#VirtualAddress-Property)|

## Methods

|Method Name|
|---|
|[Peek8(Int64 offset)](#Peek8Int64-offset-Method)|
|[Peek16(Int64 offset)](#Peek16Int64-offset-Method)|
|[Peek32(Int64 offset)](#Peek32Int64-offset-Method)|
|[Peek64(Int64 offset)](#Peek64Int64-offset-Method)|
|[Poke8(Int64 offset, Byte value)](#Poke8Int64-offset-Byte-value-Method)|
|[Poke16(Int64 offset, Int16 value)](#Poke16Int64-offset-Int16-value-Method)|
|[Poke32(Int64 offset, Int32 value)](#Poke32Int64-offset-Int32-value-Method)|
|[Poke64(Int64 offset, Int64 value)](#Poke64Int64-offset-Int64-value-Method)|

## AddressSpace Property
```C#
AddressSpace AddressSpace { get; }
```
## BaseAddress Property
```C#
Int64 BaseAddress { get; }
```
## Size Property
```C#
Int64 Size { get; }
```
## VirtualAddress Property
```C#
IntPtr VirtualAddress { get; }
```
## Peek8(Int64 offset) Method
```C#
Byte Peek8(Int64 offset);
```
## Peek16(Int64 offset) Method
```C#
Int16 Peek16(Int64 offset);
```
## Peek32(Int64 offset) Method
```C#
Int32 Peek32(Int64 offset);
```
## Peek64(Int64 offset) Method
```C#
Int64 Peek64(Int64 offset);
```
## Poke8(Int64 offset, Byte value) Method
```C#
void Poke8(Int64 offset, Byte value);
```
## Poke16(Int64 offset, Int16 value) Method
```C#
void Poke16(Int64 offset, Int16 value);
```
## Poke32(Int64 offset, Int32 value) Method
```C#
void Poke32(Int64 offset, Int32 value);
```
## Poke64(Int64 offset, Int64 value) Method
```C#
void Poke64(Int64 offset, Int64 value);
```
