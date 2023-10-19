English | 日本語

# UsbInterruptEventArgs Class

## Definition
Namespace:[Ivi.Visa](../Visa.md)<BR>
Assembly:Ivi.Visa.dll<BR>
Inheritance:[System.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object) -> [System.EventArgs](https://learn.microsoft.com/en-us/dotnet/api/system.eventargs) -> [Ivi.Visa.VisaEventArgs](VisaEventArgs.md) -> **Ivi.Visa.UsbInterruptEventArgs**

## Constructors

|Method Name|
|---|
|[UsbInterruptEventArgs(Boolean exceededMaximumSize, Byte[] data)](#UsbInterruptEventArgsBoolean-exceededMaximumSize-Byte-data-constructor)|

## Properties

|Property Name|
|---|
|[ExceededMaximumSize](#ExceededMaximumSize-Property)|
|[Data](#Data-Property)|

## UsbInterruptEventArgs(Boolean exceededMaximumSize, Byte[] data) Constructor
```C#
public UsbInterruptEventArgs(Boolean exceededMaximumSize, Byte[] data)
```
## ExceededMaximumSize Property
```C#
public Boolean ExceededMaximumSize { get; private set; }
```
## Data Property
```C#
public Byte[] Data { get; private set; }
```
