English | [日本語](Ivi.Visa.IVisaSession.ja.md)

# IVisaSession Interface

## Definition
Namespace:[Ivi.Visa](../Visa.md)<BR>
Assembly:Ivi.Visa.dll<BR>
Inheritance:[System.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) -> **Ivi.Visa.IVisaSession**

## Properties

|Property Name|
|---|
|[TimeoutMilliseconds](#TimeoutMilliseconds-Property)|
|[ResourceName](#ResourceName-Property)|
|[HardwareInterfaceName](#HardwareInterfaceName-Property)|
|[HardwareInterfaceType](#HardwareInterfaceType-Property)|
|[HardwareInterfaceNumber](#HardwareInterfaceNumber-Property)|
|[ResourceClass](#ResourceClass-Property)|
|[ResourceManufacturerName](#ResourceManufacturerName-Property)|
|[ResourceManufacturerId](#ResourceManufacturerId-Property)|
|[ResourceImplementationVersion](#ResourceImplementationVersion-Property)|
|[ResourceSpecificationVersion](#ResourceSpecificationVersion-Property)|
|[ResourceLockState](#ResourceLockState-Property)|
|[EventQueueCapacity](#EventQueueCapacity-Property)|
|[SynchronizeCallbacks](#SynchronizeCallbacks-Property)|

## Methods

|Method Name|
|---|
|[void LockResource()](#LockResource-Method)|
|[void LockResource(TimeSpan timeout)](#LockResourceTimeSpan-timeout-Method)|
|[void LockResource(Int32 timeoutMilliseconds)](#LockResourceInt32-timeoutMilliseconds-Method)|
|[string LockResource(TimeSpan timeout, String sharedKey)](#LockResourceTimeSpan-timeout-String-sharedKey-Method)|
|[string LockResource(#timeoutMilliseconds, String sharedKey)](#LockResourceInt32-timeoutMilliseconds-String-sharedKey-Method)|
|[void UnlockResource()](#UnlockResource-Method)|
|[void EnableEvent(EventType eventType)](#EnableEventEventType-eventType-Method)|
|[void DisableEvent(EventType eventType)](#DisableEventEventType-eventType-Method)|
|[void DiscardEvent(EventType eventType)](#DiscardEventEventType-eventType-Method)|
|[VisaEventArgs WaitOnEvent(EventType eventType)](#WaitOnEventEventType-eventType-Method)|
|[VisaEventArgs WaitOnEvent(EventType eventType, out EventQueueStatus status)](#WaitOnEventEventType-eventType-out-EventQueueStatus-status-Method)|
|[VisaEventArgs WaitOnEvent(EventType eventType, Int32 timeoutMilliseconds)](#WaitOnEventEventType-eventType-Int32-timeoutMilliseconds-Method)|
|[VisaEventArgs WaitOnEvent(EventType eventType, TimeSpan timeout)](#WaitOnEventEventType-eventType-TimeSpan-timeout-Method)|
|[VisaEventArgs WaitOnEvent(EventType eventType, Int32 timeoutMilliseconds, out EventQueueStatus status)](#WaitOnEventEventType-eventType-Int32-timeoutMilliseconds-out-EventQueueStatus-status-Method)|
|[VisaEventArgs WaitOnEvent(EventType eventType, TimeSpan timeout, out EventQueueStatus status)](#WaitOnEventEventType-eventType-TimeSpan-timeout-out-EventQueueStatus-status-Method)|

## EventQueueCapacity Property
```C#
Int32 EventQueueCapacity { get; set; }
```
## HardwareInterfaceName Property
```C#
String HardwareInterfaceName { get; }
```
## HardwareInterfaceNumber Property
```C#
Int16 HardwareInterfaceNumber { get; }
```
## HardwareInterfaceType Property
```C#
HardwareInterfaceType HardwareInterfaceType { get; }
```
## ResourceClass Property
```C#
String ResourceClass { get; }
```
## ResourceImplementationVersion Property
```C#
Version ResourceImplementationVersion { get; }
```
## ResourceLockState Property
```C#
ResourceLockState ResourceLockState { get; }
```
## ResourceManufacturerName Property
```C#
String ResourceManufacturerName { get; }
```
## ResourceManufacturerId Property
```C#
Int16 ResourceManufacturerId { get; }
```
## ResourceName Property
```C#
String ResourceName { get; }
```
## ResourceSpecificationVersion Property
```C#
Version ResourceSpecificationVersion { get; }
```
## SynchronizeCallbacks Property
```C#
Boolean SynchronizeCallbacks { get; set; }
```
## TimeoutMilliseconds Property
```C#
Int32 TimeoutMilliseconds { get; set; }
```

## DisableEvent(EventType eventType) Method
```C#
void DisableEvent(EventType eventType);
```
## DiscardEvent(EventType eventType) Method
```C#
void DiscardEvent(EventType eventType);
```
## EnableEvent(EventType eventType) Method
```C#
void EnableEvent(EventType eventType);
```
## LockResource() Method
```C#
void LockResource();
```
## LockResource(TimeSpan timeout) Method
```C#
void LockResource(TimeSpan timeout);
```
## LockResource(Int32 timeoutMilliseconds) Method
```C#
void LockResource(Int32 timeoutMilliseconds);
```
## LockResource(TimeSpan timeout, String sharedKey) Method
```C#
string LockResource(TimeSpan timeout, String sharedKey);
```
## LockResource(Int32 timeoutMilliseconds, String sharedKey) Method
```C#
string LockResource(Int32 timeoutMilliseconds, String sharedKey);
```
## UnlockResource() Method
```C#
void UnlockResource();
```
## WaitOnEvent(EventType eventType) Method
```C#
[VisaEventArgs](VisaEventArgs.md) WaitOnEvent(EventType eventType);
```
## WaitOnEvent(EventType eventType, out EventQueueStatus status) Method
```C#
[VisaEventArgs](VisaEventArgs.md) WaitOnEvent(EventType eventType, out EventQueueStatus status);
```
## WaitOnEvent(EventType eventType, Int32 timeoutMilliseconds) Method
```C#
[VisaEventArgs](VisaEventArgs.md) WaitOnEvent(EventType eventType, Int32 timeoutMilliseconds);
```
## WaitOnEvent(EventType eventType, TimeSpan timeout);
```C#
[VisaEventArgs](VisaEventArgs.md) WaitOnEvent(EventType eventType, TimeSpan timeout) Method
```
## WaitOnEvent(EventType eventType, Int32 timeoutMilliseconds, out EventQueueStatus status) Method
```C#
[VisaEventArgs](VisaEventArgs.md) WaitOnEvent(EventType eventType, Int32 timeoutMilliseconds, out EventQueueStatus status);
```
## WaitOnEvent(EventType eventType, TimeSpan timeout, out EventQueueStatus status) Method
```C#
[VisaEventArgs](VisaEventArgs.md) WaitOnEvent(EventType eventType, TimeSpan timeout, out EventQueueStatus status);
```
