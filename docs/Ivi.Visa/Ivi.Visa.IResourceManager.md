[Ivi.visa]()

## IResouceManager Interface

## Definition
Namespace:Ivi.Visa<BR>
Assembly:Ivi.Visa.dll

## Examples

## Properties

|Property Name|
|---|
|[ManufacturerName](#ManufacturerName_Property)|
|[ManufacturerID](#ManufacturerId_Property)|
|[ImplementationVersion](#ImplementationVersion_Property)|
|[SpecificationVersion](#SpecificationVersion_Property)|

## ManufacturerName_Property
```C#
String ManufacturerName { get; }
```
## ManufacturerId_Property
```C#
Int16 ManufacturerId { get; }
```
## ImplementationVersion_Property
```C#
Version ImplementationVersion { get; }
```
## SpecificationVersion Property
```C#
Version SpecificationVersion { get; }
```
## Methods

|Method Name|
|---|
|[Find(String pattern)](#Find(String_pattern)_Method)|
|[Parse(String resourceName)](#Parse(String_resourceName)_Method)|
|[Open(String resourceName)](#Open(String_resourceName)_Method)|
|[Open(String resourceName, AccessModes accessMode, Int32 timeoutMilliseconds)](#Open(String_resourceName,_AccessModes_accessMode,_Int32_timeoutMilliseconds)_Method)|
|[Open(String resourceName, AccessModes accessModes, Int32 timeoutMilliseconds, out ResourceOpenStatus openStatus)](#Open(String_resourceName,_AccessModes_accessModes,_Int32_timeoutMilliseconds,_out_ResourceOpenStatus_openStatus)_Method)|

### Find(String_pattern)_Method
```C#
IEnumerable<String> Find(String pattern);
```
### Parse(String_resourceName)_Method
```C#
ParseResult Parse(String resourceName);
```
### Open(String_resourceName)_Method
```C#
IVisaSession Open(String resourceName);
```
### Open(String_resourceName,_AccessModes_accessMode,_Int32_timeoutMilliseconds)_Method
```C#
IVisaSession Open(String resourceName, AccessModes accessMode, Int32 timeoutMilliseconds);
```
### Open(String_resourceName,_AccessModes_accessModes,_Int32_timeoutMilliseconds,_out_ResourceOpenStatus_openStatus)_Method
```C#
IVisaSession Open(String resourceName, AccessModes accessModes, Int32 timeoutMilliseconds, out ResourceOpenStatus openStatus);
```
