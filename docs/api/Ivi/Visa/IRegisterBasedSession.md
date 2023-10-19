English | 日本語

# IRegisterBasedSession Interface

## Definition
Namespace:[Ivi.Visa](../Visa.md)<BR>
Assembly:Ivi.Visa.dll<BR>
Inheritance:[System.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) -> [Ivi.Visa.IVisaSession](IVisaSession.md) -> **Ivi.Visa.IRegisterBasedSession**

## Properties

|Property Name|
|---|
|[AllowDma](#AllowDma-Property)|
|[DestinationIncrement](#DestinationIncrement-Property)|
|[SourceIncrement](#SourceIncrement-Property)|

## Methods

|Method Name|
|---|
|[MapAddress(AddressSpace space, Int64 offset, Int64 size)](#MapAddressAddressSpace-space-Int64-offset-Int64-size-Method)|
|[In8(AddressSpace space, Int64 sourceOffset)](#In8AddressSpace-space-Int64-sourceOffset-Method)|
|[In16(AddressSpace space, Int64 sourceOffset)](#In16AddressSpace-space-Int64-sourceOffset-Method)|
|[In32(AddressSpace space, Int64 sourceOffset)](#In32AddressSpace-space-Int64-sourceOffset-Method)|
|[In64(AddressSpace space, Int64 sourceOffset)](#In64AddressSpace-space-Int64-sourceOffset-Method)|
|[Out8(AddressSpace space, Int64 destinationOffset, Byte value)](#Out8AddressSpace-space-Int64-destinationOffset-Byte-value-Method)|
|[Out16(AddressSpace space, Int64 destinationOffset, Int16 value)](#Out16AddressSpace-space-Int64-destinationOffset-Int16-value-Method)|
|[Out32(AddressSpace space, Int64 destinationOffset, Int32 value)](#Out32AddressSpace-space-Int64-destinationOffset-Int32-value-Method)|
|[Out64(AddressSpace space, Int64 destinationOffset, Int64 value)](#Out64AddressSpace-space-Int64-destinationOffset-Int64-value-Method)|
|[MoveIn8(AddressSpace space, Int64 sourceOffset, Int64 count)](#MoveIn8AddressSpace-space-Int64-sourceOffset-Int64-count-Method)|
|[MoveIn8(AddressSpace space, Int64 sourceOffset, Int64 count, Byte[] destinationBuffer, Int64 destinationIndex)](#MoveIn8AddressSpace-space-Int64-sourceOffset-Int64-count-Byte-destinationBuffer-Int64-destinationIndex-Method)|
|[MoveIn16(AddressSpace space, Int64 sourceOffset, Int64 count)](#MoveIn16AddressSpace-space-Int64-sourceOffset-Int64-count-Method)|
|[MoveIn16(AddressSpace space, Int64 sourceOffset, Int64 count, Int16[] destinationBuffer, Int64 destinationIndex)](#MoveIn16AddressSpace-space-Int64-sourceOffset-Int64-count-Int16-destinationBuffer-Int64-destinationIndex-Method)|
|[MoveIn32(AddressSpace space, Int64 sourceOffset, Int64 count)](#MoveIn32AddressSpace-space-Int64-sourceOffset-Int64-count-Method)|
|[MoveIn32(AddressSpace space, Int64 sourceOffset, Int64 count, Int32[] destinationBuffer, Int64 destinationIndex)](#MoveIn32AddressSpace-space-Int64-sourceOffset-Int64-count-Int32-destinationBuffer-Int64-destinationIndex-Method)|
|[MoveIn64(AddressSpace space, Int64 sourceOffset, Int64 count)](#MoveIn64AddressSpace-space-Int64-sourceOffset-Int64-count-Method)|
|[MoveIn64(AddressSpace space, Int64 sourceOffset, Int64 count, Int64[] destinationBuffer, Int64 destinationIndex)](#MoveIn64AddressSpace-space-Int64-sourceOffset-Int64-count-Int64-destinationBuffer-Int64-destinationIndex-Method)|
|[MoveOut8(AddressSpace space, Int64 destinationOffset, Byte[] sourceBuffer)](#MoveOut8AddressSpace-space-Int64-destinationOffset-Byte-sourceBuffer-Method)|
|[MoveOut8(AddressSpace space, Int64 destinationOffset, Byte[] sourceBuffer, Int64 sourceIndex, Int64 count)](#MoveOut8AddressSpace-space-Int64-destinationOffset-Byte-sourceBuffer-Int64-sourceIndex-Int64-count-Method)|
|[MoveOut16(AddressSpace space, Int64 destinationOffset, Int16[] sourceBuffer)](#MoveOut16AddressSpace-space-Int64-destinationOffset-Int16-sourceBuffer-Method)|
|[MoveOut16(AddressSpace space, Int64 destinationOffset, Int16[] sourceBuffer, Int64 sourceIndex, Int64 count)](#MoveOut16AddressSpace-space-Int64-destinationOffset-Int16-sourceBuffer-Int64-sourceIndex-Int64-count-Method)|
|[MoveOut32(AddressSpace space, Int64 destinationOffset, Int32[] sourceBuffer)](#MoveOut32AddressSpace-space-Int64-destinationOffset-Int32-sourceBuffer-Method)|
|[MoveOut32(AddressSpace space, Int64 destinationOffset, Int32[] sourceBuffer, Int64 sourceIndex, Int64 count)](#MoveOut32AddressSpace-space-Int64-destinationOffset-Int32-sourceBuffer-Int64-sourceIndex-Int64-count-Method)|
|[MoveOut64(AddressSpace space, Int64 destinationOffset, Int64[] sourceBuffer)](#MoveOut64AddressSpace-space-Int64-destinationOffset-Int64-sourceBuffer-Method)|
|[MoveOut64(AddressSpace space, Int64 destinationOffset, Int64[] sourceBuffer, Int64 sourceIndex, Int64 count)](#MoveOut64AddressSpace-space-Int64-destinationOffset-Int64-sourceBuffer-Int64-sourceIndex-Int64-count-Method)|

## AllowDma Property
```C#
Boolean AllowDma { get; set; }
```
## DestinationIncrement Property
```C#
Int32 DestinationIncrement { get; set; }
```
## SourceIncrement Property
```C#
Int32 SourceIncrement { get; set; }
```
## MapAddress(AddressSpace space, Int64 offset, Int64 size) Method
```C#
IMemoryMap MapAddress(AddressSpace space, Int64 offset, Int64 size);
```
## In8(AddressSpace space, Int64 sourceOffset) Method
```C#
Byte In8(AddressSpace space, Int64 sourceOffset);
```
## In16(AddressSpace space, Int64 sourceOffset) Method
```C#
Int16 In16(AddressSpace space, Int64 sourceOffset);
```
## In32(AddressSpace space, Int64 sourceOffset) Method
```C#
Int32 In32(AddressSpace space, Int64 sourceOffset);
```
## In64(AddressSpace space, Int64 sourceOffset) Method
```C#
Int64 In64(AddressSpace space, Int64 sourceOffset);
```
## Out8(AddressSpace space, Int64 destinationOffset, Byte value) Method
```C#
void Out8(AddressSpace space, Int64 destinationOffset, Byte value);
```
## Out16(AddressSpace space, Int64 destinationOffset, Int16 value) Method
```C#
void Out16(AddressSpace space, Int64 destinationOffset, Int16 value);
```
## Out32(AddressSpace space, Int64 destinationOffset, Int32 value) Method
```C#
void Out32(AddressSpace space, Int64 destinationOffset, Int32 value);
```
## Out64(AddressSpace space, Int64 destinationOffset, Int64 value) Method
```C#
void Out64(AddressSpace space, Int64 destinationOffset, Int64 value);
```
## MoveIn8(AddressSpace space, Int64 sourceOffset, Int64 count) Method
```C#
Byte[] MoveIn8(AddressSpace space, Int64 sourceOffset, Int64 count);
```
## MoveIn8(AddressSpace space, Int64 sourceOffset, Int64 count, Byte[] destinationBuffer, Int64 destinationIndex) Method
```C#
void MoveIn8(AddressSpace space, Int64 sourceOffset, Int64 count, Byte[] destinationBuffer, Int64 destinationIndex);
```
## MoveIn16(AddressSpace space, Int64 sourceOffset, Int64 count) Method
```C#
Int16[] MoveIn16(AddressSpace space, Int64 sourceOffset, Int64 count);
```
## MoveIn16(AddressSpace space, Int64 sourceOffset, Int64 count, Int16[] destinationBuffer, Int64 destinationIndex) Method
```C#
void MoveIn16(AddressSpace space, Int64 sourceOffset, Int64 count, Int16[] destinationBuffer, Int64 destinationIndex);
```
## MoveIn32(AddressSpace space, Int64 sourceOffset, Int64 count) Method
```C#
Int32[] MoveIn32(AddressSpace space, Int64 sourceOffset, Int64 count);
```
## MoveIn32(AddressSpace space, Int64 sourceOffset, Int64 count, Int32[] destinationBuffer, Int64 destinationIndex) Method
```C#
void MoveIn32(AddressSpace space, Int64 sourceOffset, Int64 count, Int32[] destinationBuffer, Int64 destinationIndex);
```
## MoveIn64(AddressSpace space, Int64 sourceOffset, Int64 count) Method
```C#
Int64[] MoveIn64(AddressSpace space, Int64 sourceOffset, Int64 count);
```
## MoveIn64(AddressSpace space, Int64 sourceOffset, Int64 count, Int64[] destinationBuffer, Int64 destinationIndex) Method
```C#
void MoveIn64(AddressSpace space, Int64 sourceOffset, Int64 count, Int64[] destinationBuffer, Int64 destinationIndex);
```
## MoveOut8(AddressSpace space, Int64 destinationOffset, Byte[] sourceBuffer) Method
```C#
void MoveOut8(AddressSpace space, Int64 destinationOffset, Byte[] sourceBuffer);
```
## MoveOut8(AddressSpace space, Int64 destinationOffset, Byte[] sourceBuffer, Int64 sourceIndex, Int64 count) Method
```C#
void MoveOut8(AddressSpace space, Int64 destinationOffset, Byte[] sourceBuffer, Int64 sourceIndex, Int64 count);
```
## MoveOut16(AddressSpace space, Int64 destinationOffset, Int16[] sourceBuffer) Method
```C#
void MoveOut16(AddressSpace space, Int64 destinationOffset, Int16[] sourceBuffer);
```
## MoveOut16(AddressSpace space, Int64 destinationOffset, Int16[] sourceBuffer, Int64 sourceIndex, Int64 count) Method
```C#
void MoveOut16(AddressSpace space, Int64 destinationOffset, Int16[] sourceBuffer, Int64 sourceIndex, Int64 count);
```
## MoveOut32(AddressSpace space, Int64 destinationOffset, Int32[] sourceBuffer) Method
```C#
void MoveOut32(AddressSpace space, Int64 destinationOffset, Int32[] sourceBuffer);
```
## MoveOut32(AddressSpace space, Int64 destinationOffset, Int32[] sourceBuffer, Int64 sourceIndex, Int64 count) Method
```C#
void MoveOut32(AddressSpace space, Int64 destinationOffset, Int32[] sourceBuffer, Int64 sourceIndex, Int64 count);
```
## MoveOut64(AddressSpace space, Int64 destinationOffset, Int64[] sourceBuffer) Method
```C#
void MoveOut64(AddressSpace space, Int64 destinationOffset, Int64[] sourceBuffer);
```
## MoveOut64(AddressSpace space, Int64 destinationOffset, Int64[] sourceBuffer, Int64 sourceIndex, Int64 count) Method
```C#
void MoveOut64(AddressSpace space, Int64 destinationOffset, Int64[] sourceBuffer, Int64 sourceIndex, Int64 count);
```
