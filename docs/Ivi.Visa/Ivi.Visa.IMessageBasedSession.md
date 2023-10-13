English | 日本語

[Ivi.visa](Ivi.Visa.md)

# IMessageBasedSession Interface

## Definition
Namespace:[Ivi.Visa](Ivi.Visa.md)<BR>
Assembly:Ivi.Visa.dll<BR>
Inheritance System.IDisposable -> [Ivi.Visa.IVisaSession](Ivi.Visa.IVisaSession.md) -> [Ivi.Visa.IMessageBasedSession](Ivi.Visa.IMessageBasedSession.md)

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

## ServiceRequest Event
```C#
event EventHandler<VisaEventArgs> ServiceRequest;
```
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