English | 日本語

# IVxiMemorySession Interface

## Definition
Namespace:[Ivi.Visa](../Visa.md)<BR>
Assembly:Ivi.Visa.dll<BR>
Inheritance:[System.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) -> [Ivi.Visa.IVisaSession](IVisaSession.md) -> [Ivi.Visa.IRegisterBasedSession](IRegisterBasedSession.md) -> **Ivi.Visa.IVxiMemorySession**

## Properties

|Property Name|
|---|
|[LogicalAddress](#LogicalAddress-Property)|

## Methods

|Method Name|
|---|
|[Move(AddressSpace sourceSpace, Int64 sourceOffset, DataWidth sourceWidth, AddressSpace destinationSpace, Int64 destinationOffset, DataWidth destinationWidth, Int64 sourceCount)](#MoveAddressSpace-sourceSpace-Int64-sourceOffset-DataWidth-sourceWidth-AddressSpace-destinationSpace-Int64-destinationOffset-DataWidth-destinationWidth-Int64-sourceCount-Method)|

## LogicalAddress Property
```C#
Int16 LogicalAddress { get; }
```
## Move(AddressSpace sourceSpace, Int64 sourceOffset, DataWidth sourceWidth, AddressSpace destinationSpace, Int64 destinationOffset, DataWidth destinationWidth, Int64 sourceCount) Method
```C#
void Move(AddressSpace sourceSpace, Int64 sourceOffset, DataWidth sourceWidth, AddressSpace destinationSpace, Int64 destinationOffset, DataWidth destinationWidth, Int64 sourceCount);
```
