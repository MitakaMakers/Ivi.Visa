English | 日本語

# INativeVisaSession Interface

## Definition
Namespace:[Ivi.Visa](../Visa.md)<BR>
Assembly:Ivi.Visa.dll<BR>
Inheritance:[System.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) -> [Ivi.Visa.IVisaSession](IVisaSession.md) -> **Ivi.Visa.INativeVisaSession**

## Properties

|Property Name|
|---|
|[Handle](#Handle-Property)|

## Methods

|Method Name|
|---|
|[EnableEvent(Int32 eventType)](#EnableEventInt32-eventType-Method)|
|[DisableEvent(Int32 eventType)](#DisableEventInt32-eventType-Method)|
|[DiscardEvents(Int32 eventType)](#DiscardEventsInt32-eventType-Method)|
|[INativeVisaEventArgs WaitOnEvent(Int32 eventType)](#INativeVisaEventArgs-WaitOnEventInt32-eventType-Method)|
|[INativeVisaEventArgs WaitOnEvent(Int32 eventType, out EventQueueStatus status)](#INativeVisaEventArgs-WaitOnEventInt32-eventType-out-EventQueueStatus-status-Method)|
|[INativeVisaEventArgs WaitOnEvent(Int32 eventType, Int32 timeoutMilliseconds)](#INativeVisaEventArgs-WaitOnEventInt32-eventType-Int32-timeoutMilliseconds-Method)|
|[INativeVisaEventArgs WaitOnEvent(Int32 eventType, TimeSpan timeout)](#INativeVisaEventArgs-WaitOnEventInt32-eventType-TimeSpan-timeout-Method)|
|[INativeVisaEventArgs WaitOnEvent(Int32 eventType, Int32 timeoutMilliseconds, out EventQueueStatus status)](#INativeVisaEventArgs-WaitOnEventInt32-eventType-Int32-timeoutMilliseconds-out-EventQueueStatus-status-Method)|
|[INativeVisaEventArgs WaitOnEvent(Int32 eventType, TimeSpan timeout, out EventQueueStatus status)](#INativeVisaEventArgs-WaitOnEventInt32-eventType-TimeSpan-timeout-out-EventQueueStatus-status-Method)|
|[GetAttributeByte(NativeVisaAttribute attribute)](#GetAttributeByteNativeVisaAttribute-attribute-Method)|
|[GetAttributeByte(Int32 attribute)](#GetAttributeByteInt32-attribute-Method)|
|[GetAttributeInt16(NativeVisaAttribute attribute)](#GetAttributeInt16NativeVisaAttribute-attribute-Method)|
|[GetAttributeInt16(Int32 attribute)](#GetAttributeInt16Int32-attribute-Method)|
|[GetAttributeInt32(NativeVisaAttribute attribute)](#GetAttributeInt32NativeVisaAttribute-attribute-Method)|
|[GetAttributeInt32(Int32 attribute)](#GetAttributeInt32Int32-attribute-Method)|
|[GetAttributeInt64(NativeVisaAttribute attribute)](#GetAttributeInt64NativeVisaAttribute-attribute-Method)|
|[GetAttributeInt64(Int32 attribute)](#GetAttributeInt64Int32-attribute-Method)|
|[GetAttributeBoolean(NativeVisaAttribute attribute)](#GetAttributeBooleanNativeVisaAttribute-attribute-Method)|
|[GetAttributeBoolean(Int32 attribute)](#GetAttributeBooleanInt32-attribute-Method)|
|[GetAttributeString(NativeVisaAttribute attribute)](#GetAttributeStringNativeVisaAttribute-attribute-Method)|
|[GetAttributeString(Int32 attribute)](#GetAttributeStringInt32-attribute-Method)|
|[SetAttributeByte(NativeVisaAttribute attribute, Byte value)](#SetAttributeByteNativeVisaAttribute-attribute-Byte-value-Method)|
|[SetAttributeByte(Int32 attribute, Byte value)](#SetAttributeByteInt32-attribute-Byte-value-Method)|
|[SetAttributeInt16(NativeVisaAttribute attribute, Int16 value)](#SetAttributeInt16NativeVisaAttribute-attribute-Int16-value-Method)|
|[SetAttributeInt16(Int32 attribute, Int16 value)](#SetAttributeInt16Int32-attribute-Int16-value-Method)|
|[SetAttributeInt32(NativeVisaAttribute attribute, Int32 value)](#SetAttributeInt32NativeVisaAttribute-attribute-Int32-value-Method)|
|[SetAttributeInt32(Int32 attribute, Int32 value)](#SetAttributeInt32Int32-attribute-Int32-value-Method)|
|[SetAttributeInt64(NativeVisaAttribute attribute, Int64 value)](#SetAttributeInt64NativeVisaAttribute-attribute-Int64-value-Method)|
|[SetAttributeInt64(Int32 attribute, Int64 value)](#SetAttributeInt64Int32-attribute-Int64-value-Method)|
|[SetAttributeBoolean(NativeVisaAttribute attribute, Boolean value)](#SetAttributeBooleanNativeVisaAttribute-attribute-Boolean-value-Method)|
|[SetAttributeBoolean(Int32 attribute, Boolean value)](#SetAttributeBooleanInt32-attribute-Boolean-value-Method)|
|[SetAttributeString(NativeVisaAttribute attribute, String value)](#SetAttributeStringNativeVisaAttribute-attribute-String-value-Method)|
|[SetAttributeString(Int32 attribute, String value)](#SetAttributeStringInt32-attribute-String-value-Method)|

## Handle Property
```C#
Int32 Handle { get; }
```
## EnableEvent(Int32 eventType) Method
```C#
void EnableEvent(Int32 eventType);
```
## DisableEvent(Int32 eventType) Method
```C#
void DisableEvent(Int32 eventType);
```
## DiscardEvents(Int32 eventType) Method
```C#
void DiscardEvents(Int32 eventType);
```
## WaitOnEvent(Int32 eventType) Method
```C#
INativeVisaEventArgs WaitOnEvent(Int32 eventType);
```
## WaitOnEvent(Int32 eventType, out EventQueueStatus status) Method
```C#
INativeVisaEventArgs WaitOnEvent(Int32 eventType, out EventQueueStatus status);
```
## WaitOnEvent(Int32 eventType, Int32 timeoutMilliseconds) Method
```C#
INativeVisaEventArgs WaitOnEvent(Int32 eventType, Int32 timeoutMilliseconds);
```
## WaitOnEvent(Int32 eventType, TimeSpan timeout) Method
```C#
INativeVisaEventArgs WaitOnEvent(Int32 eventType, TimeSpan timeout);
```
## WaitOnEvent(Int32 eventType, Int32 timeoutMilliseconds, out EventQueueStatus status) Method
```C#
INativeVisaEventArgs WaitOnEvent(Int32 eventType, Int32 timeoutMilliseconds, out EventQueueStatus status);
```
## WaitOnEvent(Int32 eventType, TimeSpan timeout, out EventQueueStatus status) Method
```C#
INativeVisaEventArgs WaitOnEvent(Int32 eventType, TimeSpan timeout, out EventQueueStatus status);
```
## GetAttributeByte(NativeVisaAttribute attribute) Method
```C#
Byte GetAttributeByte(NativeVisaAttribute attribute);
```
## GetAttributeByte(Int32 attribute) Method
```C#
Byte GetAttributeByte(Int32 attribute);
```
## GetAttributeInt16(NativeVisaAttribute attribute) Method
```C#
Int16 GetAttributeInt16(NativeVisaAttribute attribute);
```
## GetAttributeInt16(Int32 attribute) Method
```C#
Int16 GetAttributeInt16(Int32 attribute);
```
## GetAttributeInt32(NativeVisaAttribute attribute) Method
```C#
Int32 GetAttributeInt32(NativeVisaAttribute attribute);
```
## GetAttributeInt32(Int32 attribute) Method
```C#
Int32 GetAttributeInt32(Int32 attribute);
```
## GetAttributeInt64(NativeVisaAttribute attribute) Method
```C#
Int64 GetAttributeInt64(NativeVisaAttribute attribute);
```
## GetAttributeInt64(Int32 attribute) Method
```C#
Int64 GetAttributeInt64(Int32 attribute);
```
## GetAttributeBoolean(NativeVisaAttribute attribute) Method
```C#
Boolean GetAttributeBoolean(NativeVisaAttribute attribute);
```
## GetAttributeBoolean(Int32 attribute) Method
```C#
Boolean GetAttributeBoolean(Int32 attribute);
```
## GetAttributeString(NativeVisaAttribute attribute) Method
```C#
String GetAttributeString(NativeVisaAttribute attribute);
```
## GetAttributeString(Int32 attribute) Method
```C#
String GetAttributeString(Int32 attribute);
```
## SetAttributeByte(NativeVisaAttribute attribute, Byte value) Method
```C#
void SetAttributeByte(NativeVisaAttribute attribute, Byte value);
```
## SetAttributeByte(Int32 attribute, Byte value) Method
```C#
void SetAttributeByte(Int32 attribute, Byte value);
```
## SetAttributeInt16(NativeVisaAttribute attribute, Int16 value) Method
```C#
void SetAttributeInt16(NativeVisaAttribute attribute, Int16 value);
```
## SetAttributeInt16(Int32 attribute, Int16 value) Method
```C#
void SetAttributeInt16(Int32 attribute, Int16 value);
```
## SetAttributeInt32(NativeVisaAttribute attribute, Int32 value) Method
```C#
void SetAttributeInt32(NativeVisaAttribute attribute, Int32 value);
```
## SetAttributeInt32(Int32 attribute, Int32 value) Method
```C#
void SetAttributeInt32(Int32 attribute, Int32 value);
```
## SetAttributeInt64(NativeVisaAttribute attribute, Int64 value) Method
```C#
void SetAttributeInt64(NativeVisaAttribute attribute, Int64 value);
```
## SetAttributeInt64(Int32 attribute, Int64 value) Method
```C#
void SetAttributeInt64(Int32 attribute, Int64 value);
```
## SetAttributeBoolean(NativeVisaAttribute attribute, Boolean value) Method
```C#
void SetAttributeBoolean(NativeVisaAttribute attribute, Boolean value);
```
## SetAttributeBoolean(Int32 attribute, Boolean value) Method
```C#
void SetAttributeBoolean(Int32 attribute, Boolean value);
```
## SetAttributeString(NativeVisaAttribute attribute, String value) Method
```C#
void SetAttributeString(NativeVisaAttribute attribute, String value);
```
## SetAttributeString(Int32 attribute, String value) Method
```C#
void SetAttributeString(Int32 attribute, String value);
```
