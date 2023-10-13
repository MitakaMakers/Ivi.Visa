[Ivi.visa]()

# IResouceManager Interface

## Definition
Namespace:Ivi.Visa<BR>
Assembly:Ivi.Visa.dll

## Examples

## Properties

|Property Name|
|---|
|[ManufacturerName](#ManufacturerName-Property)|
|[ManufacturerID](#ManufacturerId-Property)|
|[ImplementationVersion](#ImplementationVersion-Property)|
|[SpecificationVersion](#SpecificationVersion-Property)|

## Methods

|Method Name|
|---|
|[Find(String pattern)](#FindString-pattern-Method)|
|[Parse(String resourceName)](#ParseString_resourceName_Method)|
|[Open(String resourceName)](#OpenString_resourceName_Method)|
|[Open(String resourceName, AccessModes accessMode, Int32 timeoutMilliseconds)](#OpenString_resourceName,_AccessModes_accessMode,_Int32_timeoutMilliseconds_Method)|
|[Open(String resourceName, AccessModes accessModes, Int32 timeoutMilliseconds, out ResourceOpenStatus openStatus)](#OpenString_resourceName,_AccessModes_accessModes,_Int32_timeoutMilliseconds,_out_ResourceOpenStatus_openStatus_Method)|

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
### Find(String pattern) Method
```C#
IEnumerable<String> Find(String pattern);
```
### Parse(String resourceName) Method
```C#
ParseResult Parse(String resourceName);
```
### Open(String resourceName) Method
```C#
IVisaSession Open(String resourceName);
```
### Open(String resourceName, AccessModes accessMode, Int32 timeoutMilliseconds) Method
```C#
IVisaSession Open(String resourceName, AccessModes accessMode, Int32 timeoutMilliseconds);
```
### Open(String resourceName, AccessModes accessModes, Int32 timeoutMilliseconds, out ResourceOpenStatus openStatus) Method
```C#
IVisaSession Open(String resourceName, AccessModes accessModes, Int32 timeoutMilliseconds, out ResourceOpenStatus openStatus);
```
