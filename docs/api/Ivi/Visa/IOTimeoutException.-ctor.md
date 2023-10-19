English | 日本語

[Ivi.Visa](../Visa.md) / [IOTimeoutException](IOTimeoutException.md)

# IOTimeoutException Constructors

## Definition
Namespace:[Ivi.Visa](../Visa.md)<BR>
Assembly:Ivi.Visa.dll<BR>

Initializes a new instance of the IOTimeoutException class.

## Overloads

|Method Name|
|---|
|[IOTimeoutException(Int64 actualCount, Byte[] actualData)](#IOTimeoutExceptionInt64-actualCount-Byte-actualData-Constructor)|
|[IOTimeoutException(Int64 actualCount, Byte[] actualData, String message)](#IOTimeoutExceptionInt64-actualCount-Byte-actualData-String-message-Constructor)|
|[IOTimeoutException(Int64 actualCount, Byte[] actualData, String message, System.Exception innerException)](#IOTimeoutExceptionInt64-actualCount-Byte-actualData-String-message-SystemException-innerException-Constructor)|
|[IOTimeoutException(SerializationInfo info, StreamingContext context)](#IOTimeoutExceptionSerializationInfo-info-StreamingContext-context-Constructor)|

## IOTimeoutException(Int64 actualCount, Byte[] actualData) Constructor
```C#
public IOTimeoutException(Int64 actualCount, Byte[] actualData)
```
### Parameters
- [Int64](https://learn.microsoft.com/ja-jp/dotnet/api/system.int64) **actualCount**<BR>The actual number of elements read or written before the timeout occurred.  A value of -1 indicates that the actual number could not be determined.
- [Byte](https://learn.microsoft.com/ja-jp/dotnet/api/system.byte)[] **actualData**<BR>The actual bytes read or written before the timeout occurred.  If the actual number of elements read could not be determined, the array is empty.

## IOTimeoutException(Int64 actualCount, Byte[] actualData, String message) Constructor
```C#
public IOTimeoutException(Int64 actualCount, Byte[] actualData, String message)
```
### Parameters
- [Int64](https://learn.microsoft.com/ja-jp/dotnet/api/system.int64) **actualCount**<BR>The actual number of elements read or written before the timeout occurred.  A value of -1 indicates that the actual number could not be determined.
- [Byte](https://learn.microsoft.com/ja-jp/dotnet/api/system.byte)[] **actualData**<BR>The actual bytes read or written before the timeout occurred.  If the actual number of elements read could not be determined, the array is empty.
- [String](https://learn.microsoft.com/ja-jp/dotnet/api/system.string)[] **message**<BR>A message appropriate to the error being reported.

## IOTimeoutException(Int64 actualCount, Byte[] actualData, String message, System.Exception innerException) Constructor
```C#
public IOTimeoutException(Int64 actualCount, Byte[] actualData, String message, System.Exception innerException)
```
### Parameters
- [Int64](https://learn.microsoft.com/ja-jp/dotnet/api/system.int64) **actualCount**<BR>The actual number of elements read or written before the timeout occurred.  A value of -1 indicates that the actual number could not be determined.
- [Byte](https://learn.microsoft.com/ja-jp/dotnet/api/system.byte)[] **actualData**<BR>The actual bytes read or written before the timeout occurred.  If the actual number of elements read could not be determined, the array is empty.
- [String](https://learn.microsoft.com/ja-jp/dotnet/api/system.string)[] **message**<BR>A message appropriate to the error being reported.
- [String](https://learn.microsoft.com/ja-jp/dotnet/api/system.exception)[] **innerException**<BR>The exception that is the cause of the current exception. If the innerException parameter is not null, the current exception is raised in a catch block that handles the inner exception.

## IOTimeoutException(SerializationInfo info, StreamingContext context) Constructor
```C#
protected IOTimeoutException(SerializationInfo info, StreamingContext context)
```
