[English](Ivi.Visa.GlobalResourceManager.md) | 日本語

[Ivi.visa](Ivi.Visa.md)

# GlobalResourceManager Class

## Definition
Namespace:Ivi.Visa<BR>
Assembly:Ivi.Visa.dll

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
|[Find()](#Find-Method)|
|[Find(String pattern)](#FindString-pattern-Method)|
|[Parse(String resourceName)](#ParseString-resourceName-Method)|
|[TryParse(String resourceName, out ParseResult result)](#TryParseString-resourceName-out-ParseResult-result-Method)|
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
## Find() Method
```C#
IEnumerable<String> Find()
```
## Find(String pattern) Method
```C#
IEnumerable<String> Find(String pattern);
```
## Parse(String resourceName) Method
```C#
ParseResult Parse(String resourceName);
```
## TryParse(String resourceName, out ParseResult result) Method
```C#
Boolean TryParse(String resourceName, out ParseResult result)
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
