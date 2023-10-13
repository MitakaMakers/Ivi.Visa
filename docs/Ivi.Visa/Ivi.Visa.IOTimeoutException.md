English | 日本語

[Ivi.visa](Ivi.Visa.md)

# IOTimeoutException Class

## Definition
Namespace:[Ivi.Visa](Ivi.Visa.md)<BR>
Assembly:Ivi.Visa.dll<BR>
Inheritance:[System.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object) -> [System.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception) -> [Ivi.Visa.VisaException](Ivi.Visa.VisaException.md) -> Ivi.Visa.IOTimeoutException

## Constructors

|Method Name|
|---|
|[IOTimeoutException(Int64 actualCount, Byte[] actualData)](#IOTimeoutExceptionInt64-actualCount-Byte-actualData-Constructor)|
|[IOTimeoutException(Int64 actualCount, Byte[] actualData, String message)](#IOTimeoutExceptionInt64-actualCount-Byte-actualData-String-message-Constructor)|
|[IOTimeoutException(Int64 actualCount, Byte[] actualData, String message, System.Exception innerException)](#IOTimeoutExceptionInt64-actualCount-Byte-actualData-String-message-SystemException-innerException-Constructor)|
|[IOTimeoutException(SerializationInfo info, StreamingContext context)](#IOTimeoutExceptionSerializationInfo-info-treamingContext-context-Constructor)|

## Properties

|Property Name|
|---|
|[Int64 ActualCount](#ActualCount-Property)|
|[Byte[] ActualData](#ActualData-Property)|

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
