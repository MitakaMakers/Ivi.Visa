English | 日本語

# IPxiMemorySession Interface

## Definition
Namespace:[Ivi.Visa](../Visa.md)<BR>
Assembly:Ivi.Visa.dll<BR>
Inheritance:[System.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) -> [Ivi.Visa.IVisaSession](IVisaSession.md) -> [Ivi.Visa.IRegisterBasedSession](IRegisterBasedSession.md) -> **Ivi.Visa.IPxiMemorySession**

## Methods

|Method Name|
|---|
|[MemoryAllocate(Int64 size)](#MemoryAllocateInt64-size-Method)|
|[MemoryAllocate(Int64 size, Boolean require32BitRegion)](#MemoryAllocateInt64-size-Boolean-require32BitRegion-Method)|
|[MemoryFree(Int64 offset)](#MemoryFreeInt64-offset-Method)|

## MemoryAllocate(Int64 size) Method
```C#
Int64 MemoryAllocate(Int64 size);
```
## MemoryAllocate(Int64 size, Boolean require32BitRegion) Method
```C#
Int64 MemoryAllocate(Int64 size, Boolean require32BitRegion);
```
## MemoryFree(Int64 offset) Method
```C#
void MemoryFree(Int64 offset);
```
