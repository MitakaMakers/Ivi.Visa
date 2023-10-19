English | 日本語

# IGpibInterfaceSession Interface

## Definition
Namespace:[Ivi.Visa](../Visa.md)<BR>
Assembly:Ivi.Visa.dll<BR>
Inheritance:[System.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) -> [Ivi.Visa.IVisaSession](IVisaSession.md) -> **Ivi.Visa.IGpibInterfaceSession**

## Events

|Event Name|
|---|
|[Cleared](#Cleared-Event)|
|[ControllerInCharge](#ControllerInCharge-Event)|
|[Listen](#Listen-Event)|
|[ServiceRequest](#ServiceRequest-Event)|
|[Talk](#Talk-Event)|
|[Trigger](#Trigger-Event)|

## Properties

|Property Name|
|---|
|[AddressState](#AddressState-Property)|
|[AllowDma](#AllowDma-Property)|
|[AtnState](#AtnState-Property)|
|[HS488CableLength](#HS488CableLength-Property)|
|[DeviceStatusByte](#DeviceStatusByte-Property)|
|[IOProtocol](#IOProtocol-Property)|
|[IsControllerInCharge](#IsControllerInCharge-Property)|
|[IsSystemController](#IsSystemController-Property)|
|[NdacState](#NdacState-Property)|
|[PrimaryAddress](#PrimaryAddress-Property)|
|[RenState](#RenState-Property)|
|[SecondaryAddress](#SecondaryAddress-Property)|
|[SendEndEnabled](#SendEndEnabled-Property)|
|[SrqState](#SrqState-Property)|
|[TerminationCharacter](#TerminationCharacter-Property)|
|[TerminationCharacterEnabled](#TerminationCharacterEnabled-Property)|
|[IMessageBasedRawIO RawIO](#IMessageBasedRawIO-RawIO-Property)|

## Methods

|Method Name|
|---|
|[AssertTrigger()](#AssertTrigger-Method)|
|[PassControl(Int16 primaryAddress)](#PassControlInt16-primaryAddress-Method)|
|[PassControl(Int16 primaryAddress, Int16 secondaryAddress)](#PassControlInt16-primaryAddress-Int16-secondaryAddress-Method)|
|[ControlAtn(AtnMode command)](#ControlAtnAtnMode-command-Method)|
|[SendCommand(Byte[] data)](#SendCommandByte-data-Method)|
|[SendRemoteLocalCommand(GpibInterfaceRemoteLocalMode mode)](#SendRemoteLocalCommandGpibInterfaceRemoteLocalMode-mode-Method)|
|[SendInterfaceClear()](#SendInterfaceClear-Method)|

## Cleared Event
```C#
event EventHandler<VisaEventArgs> Cleared;
```
## ControllerInCharge Event
```C#
event EventHandler<GpibControllerInChargeEventArgs> ControllerInCharge;
```
## Listen Event
```C#
event EventHandler<VisaEventArgs> Listen;
```
## ServiceRequest Event
```C#
event EventHandler<VisaEventArgs> ServiceRequest;
```
## Talk Event
```C#
event EventHandler<VisaEventArgs> Talk;
```
## Trigger Event
```C#
event EventHandler<VisaEventArgs> Trigger;
```
## AddressState Property
```C#
GpibAddressedState AddressState { get; }
```
## AllowDma Property
```C#
Boolean AllowDma { get; set; }
```
## AtnState Property
```C#
LineState AtnState { get; }
```
## HS488CableLength Property
```C#
Int16 HS488CableLength { get; set; }
```
## DeviceStatusByte Property
```C#
Byte DeviceStatusByte { get; set; }
```
## IOProtocol Property
```C#
IOProtocol IOProtocol { get; set; }
```
## IsControllerInCharge Property
```C#
Boolean IsControllerInCharge { get; }
```
## IsSystemController Property
```C#
Boolean IsSystemController { get; set; }
```
## NdacState Property
```C#
LineState NdacState { get; }
```
## PrimaryAddress Property
```C#
Int16 PrimaryAddress { get; set; }
```
## RenState Property
```C#
LineState RenState { get; }
```
## SecondaryAddress Property
```C#
Int16 SecondaryAddress { get; set; }
```
## SendEndEnabled Property
```C#
public bool SendEndEnabled { get; set; }
```
## SrqState Property
```C#
LineState SrqState { get; }
```
## TerminationCharacter Property
```C#
public byte TerminationCharacter { get; set; }
```
## TerminationCharacterEnabled Property
```C#
public bool TerminationCharacterEnabled { get; set; }
```
## RawIO Property
```C#
IMessageBasedRawIO RawIO { get; }
```
## AssertTrigger() Method
```C#
public void AssertTrigger();
```
## PassControl(Int16 primaryAddress) Method
```C#
void PassControl(Int16 primaryAddress);
```
## PassControl(Int16 primaryAddress, Int16 secondaryAddress) Method
```C#
void PassControl(Int16 primaryAddress, Int16 secondaryAddress);
```
## ControlAtn(AtnMode command) Method
```C#
void ControlAtn(AtnMode command);
```
## SendCommand(Byte[] data) Method
```C#
Int32 SendCommand(Byte[] data);
```
## SendRemoteLocalCommand(GpibInterfaceRemoteLocalMode mode); Method
```C#
void SendRemoteLocalCommand(GpibInterfaceRemoteLocalMode mode); 
```
## SendInterfaceClear() Method
```C#
void SendInterfaceClear();
```
