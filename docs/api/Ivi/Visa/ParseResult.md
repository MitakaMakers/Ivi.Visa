English | 日本語

# ParseResult Class

## Definition
Namespace:[Ivi.Visa](../Visa.md)<BR>
Assembly:Ivi.Visa.dll

## Constructors

|Method Name|
|---|
|[public ParseResult(String originalResourceName, HardwareInterfaceType interfaceType, Int16 interfaceNumber, String resourceClass, String expandedUnaliasedName, String aliasIfExists)](#parseresultstring-originalresourcename-hardwareinterfacetype-interfacetype-int16-interfacenumber-string-resourceclass-string-expandedunaliasedname-string-aliasifexists-constructor)|

## Properties

|Property Name|
|---|
|[AliasIfExists](#AliasIfExists-Property)|
|[ExpandedUnaliasedName](#ExpandedUnaliasedName-Property)|
|[InterfaceNumber](#InterfaceNumber-Property)|
|[InterfaceType](#InterfaceType-Property)|
|[OriginalResourceName](#OriginalResourceName-Property)|
|[ResourceClass](#ResourceClass-Property)|

## ParseResult(String originalResourceName, HardwareInterfaceType interfaceType, Int16 interfaceNumber, String resourceClass, String expandedUnaliasedName, String aliasIfExists) Constructor
```C#
public ParseResult(String originalResourceName, HardwareInterfaceType interfaceType, Int16 interfaceNumber, String resourceClass, String expandedUnaliasedName, String aliasIfExists)
```
## AliasIfExists Property
```C#
public String AliasIfExists { get; private set; }
```
## ExpandedUnaliasedName Property
```C#
public String ExpandedUnaliasedName { get; private set; }
```
## InterfaceNumber Property
```C#
public Int32 InterfaceNumber { get; private set; }
```
## InterfaceType Property
```C#
public HardwareInterfaceType InterfaceType { get; private set; }
```
## OriginalResourceName Property
```C#
public String OriginalResourceName { get; private set; }
```
## ResourceClass Property
```C#
public String ResourceClass { get; private set; }
```
