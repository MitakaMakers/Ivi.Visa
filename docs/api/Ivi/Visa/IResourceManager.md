English | [日本語](Ivi.Visa.IResourceManager.ja.md)

# IResouceManager Interface

## Definition
Namespace:[Ivi.Visa](../Visa.md)<BR>
Assembly:Ivi.Visa.dll<BR>
Inheritance:[System.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) -> **Ivi.Visa.IResouceManager**

## Properties

|Property Name|
|---|
|[ManufacturerName](#ManufacturerName-Property)|
|[ManufacturerId](#ManufacturerId-Property)|
|[ImplementationVersion](#ImplementationVersion-Property)|
|[SpecificationVersion](#SpecificationVersion-Property)|

## Methods

|Method Name|
|---|
|[Find(String pattern)](#FindString-pattern-Method)|
|[Parse(String resourceName)](#ParseString-resourceName-Method)|
|[Open(String resourceName)](#OpenString-resourceName-Method)|
|[Open(String resourceName, AccessModes accessMode, Int32 timeoutMilliseconds)](#OpenString-resourceName-AccessModes-accessMode-Int32-timeoutMilliseconds-Method)|
|[Open(String resourceName, AccessModes accessModes, Int32 timeoutMilliseconds, out ResourceOpenStatus openStatus)](#OpenString-resourceName-AccessModes-accessModes-Int32-timeoutMilliseconds-out-ResourceOpenStatus-openStatus-Method)|


## ManufacturerName Property
```C#
String ManufacturerName { get; }
```
## ManufacturerId Property
```C#
Int16 ManufacturerId { get; }
```
## ImplementationVersion Property
```C#
Version ImplementationVersion { get; }
```
## SpecificationVersion Property
```C#
Version SpecificationVersion { get; }
```
## Find(String pattern) Method
```C#
IEnumerable<String> Find(String pattern);
```
## Parse(String resourceName) Method
```C#
ParseResult Parse(String resourceName);
```
## Open(String resourceName) Method
```C#
IVisaSession Open(String resourceName);
```
## Open(String resourceName, AccessModes accessMode, Int32 timeoutMilliseconds) Method
```C#
IVisaSession Open(String resourceName, AccessModes accessMode, Int32 timeoutMilliseconds);
```
## Open(String resourceName, AccessModes accessModes, Int32 timeoutMilliseconds, out ResourceOpenStatus openStatus) Method
```C#
IVisaSession Open(String resourceName, AccessModes accessModes, Int32 timeoutMilliseconds, out ResourceOpenStatus openStatus);
```
