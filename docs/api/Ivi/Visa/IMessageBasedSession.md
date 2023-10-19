English | 日本語

# IMessageBasedSession Interface

## Definition
Namespace:[Ivi.Visa](../Visa.md)<BR>
Assembly:Ivi.Visa.dll<BR>
Inheritance:[System.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) -> [Ivi.Visa.IVisaSession](IVisaSession.md) -> **Ivi.Visa.IMessageBasedSession**

## Properties

|Property Name|
|---|
|[FormattedIO](#FormattedIO-Property)|
|[IOProtocol](#IOProtocol-Property)|
|[RawIO](#RawIO-Property)|
|[SendEndEnabled](#SendEndEnabled-Property)|
|[TerminationCharacter](#TerminationCharacter-Property)|
|[TerminationCharacterEnabled](#TerminationCharacterEnabled-Property)|

## Events

|Event Name|
|---|
|[ServiceRequest](#ServiceRequest-Event)|

## Methods

|Method Name|
|---|
|[AssertTrigger()](#AssertTrigger-Method)|
|[Clear()](#Clear-Method)|
|[ReadStatusByte()](#ReadStatusByte-Method)|

## FormattedIO Property
```C#
IMessageBasedFormattedIO FormattedIO { get; }
```
## IOProtocol Property
```C#
IOProtocol IOProtocol { get; set; }
```
## RawIO Property
```C#
IMessageBasedRawIO RawIO { get; }
```
## SendEndEnabled Property
```C#
Boolean SendEndEnabled { get; set; }
```
## TerminationCharacter Property
```C#
Byte TerminationCharacter { get; set; }
```
## TerminationCharacterEnabled Property
```C#
Boolean TerminationCharacterEnabled { get; set; }
```
## ServiceRequest Event
```C#
event EventHandler<VisaEventArgs> ServiceRequest;
```
## AssertTrigger() Method
```C#
void AssertTrigger();
```
## Clear() Method
```C#
void Clear();
```
## ReadStatusByte() Method
```C#
StatusByteFlags ReadStatusByte();
```
