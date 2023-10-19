[English](Ivi.Visa.IResourceManager.md) | [日本語](Ivi.Visa.IResourceManager.ja.md)

[Ivi.visa](../Visa.md)

# IResouceManager インターフェイス

## 定義
Namespace:[Ivi.Visa](Ivi.Visa.ja.md)<BR>
アセンブリ:Ivi.Visa.dll

## プロパティ

|プロパティ名|
|---|
|[ManufacturerName](#ManufacturerName-プロパティ)|
|[ManufacturerId](#ManufacturerId-プロパティ)|
|[ImplementationVersion](#ImplementationVersion-プロパティ)|
|[SpecificationVersion](#SpecificationVersion-プロパティ)|

## メソッド

|メソッド名|
|---|
|[Find(String pattern)](#FindString-pattern-メソッド)|
|[Parse(String resourceName)](#ParseString-resourceName-メソッド)|
|[Open(String resourceName)](#OpenString-resourceName-メソッド)|
|[Open(String resourceName, AccessModes accessMode, Int32 timeoutMilliseconds)](#OpenString-resourceName-AccessModes-accessMode-Int32-timeoutMilliseconds-メソッド)|
|[Open(String resourceName, AccessModes accessModes, Int32 timeoutMilliseconds, out ResourceOpenStatus openStatus)](#OpenString-resourceName-AccessModes-accessModes-Int32-timeoutMilliseconds-out-ResourceOpenStatus-openStatus-メソッド)|

## ManufacturerName プロパティ
```C#
String ManufacturerName { get; }
```
## ManufacturerId プロパティ
```C#
Int16 ManufacturerId { get; }
```
## ImplementationVersion プロパティ
```C#
Version ImplementationVersion { get; }
```
## SpecificationVersion プロパティ
```C#
Version SpecificationVersion { get; }
```
## Find(String pattern) メソッド
```C#
IEnumerable<String> Find(String pattern);
```
## Parse(String resourceName) メソッド
```C#
ParseResult Parse(String resourceName);
```
## Open(String resourceName) メソッド
```C#
IVisaSession Open(String resourceName);
```
## Open(String resourceName, AccessModes accessMode, Int32 timeoutMilliseconds) メソッド
```C#
IVisaSession Open(String resourceName, AccessModes accessMode, Int32 timeoutMilliseconds);
```
## Open(String resourceName, AccessModes accessModes, Int32 timeoutMilliseconds, out ResourceOpenStatus openStatus) メソッド
```C#
IVisaSession Open(String resourceName, AccessModes accessModes, Int32 timeoutMilliseconds, out ResourceOpenStatus openStatus);
```
