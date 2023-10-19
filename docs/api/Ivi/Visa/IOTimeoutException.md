English | 日本語

# IOTimeoutException Class

## Definition
Namespace:[Ivi.Visa](../Visa.md)<BR>
Assembly:Ivi.Visa.dll<BR>

A VISA.NET I/O timeout has occured.

```C#
public class Ivi.Visa.IOTimeoutException : Ivi.Visa.VisaException
```

Inheritance:[System.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object) -> [System.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception) -> [Ivi.Visa.VisaException](VisaException.md) -> **Ivi.Visa.IOTimeoutException**

## Constructors

|Method Name|
|---|
|[IOTimeoutException(Int64 actualCount, Byte[] actualData)](IOTimeoutException.-ctor.md#IOTimeoutExceptionInt64-actualCount-Byte-actualData-Constructor)|
|[IOTimeoutException(Int64 actualCount, Byte[] actualData, String message)](IOTimeoutException.-ctor.md#IOTimeoutExceptionInt64-actualCount-Byte-actualData-String-message-Constructor)|
|[IOTimeoutException(Int64 actualCount, Byte[] actualData, String message, System.Exception innerException)](IOTimeoutException.-ctor.md#IOTimeoutExceptionInt64-actualCount-Byte-actualData-String-message-SystemException-innerException-Constructor)|
|[IOTimeoutException(SerializationInfo info, StreamingContext context)](IOTimeoutException.-ctor.md#IOTimeoutExceptionSerializationInfo-info-StreamingContext-context-Constructor)|

## Properties

|Property Name|
|---|
|[Int64 ActualCount](IOTimeoutException.ActualCount.md#ActualCount-Property)|
|[Byte[] ActualData](IOTimeoutException.ActualData.md#ActualData-Property)|

<!--
## IOTimeoutException(Int64 actualCount, Byte[] actualData) Constructor
```C#
public IOTimeoutException(Int64 actualCount, Byte[] actualData)
```
## IOTimeoutException(Int64 actualCount, Byte[] actualData, String message) Constructor
```C#
public IOTimeoutException(Int64 actualCount, Byte[] actualData, String message)
```
## IOTimeoutException(Int64 actualCount, Byte[] actualData, String message, System.Exception innerException) Constructor
```C#
public IOTimeoutException(Int64 actualCount, Byte[] actualData, String message, System.Exception innerException)
```
## IOTimeoutException(SerializationInfo info, StreamingContext context) Constructor
```C#
protected IOTimeoutException(SerializationInfo info, StreamingContext context)
```
## ActualCount Property
```C#
public Int64 ActualCount { get; protected set; }
```
## ActualData Property
```C#
public Byte[] ActualData { get; protected set; }
```
-->