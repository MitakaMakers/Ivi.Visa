English | 日本語

# NativeVisaException Class

## Definition
Namespace:[Ivi.Visa](../Visa.md)<BR>
Assembly:Ivi.Visa.dll<BR>

An error related to the underlying VISA native C implementation has occurred.  The status code indicates the type of error that occurred.

```C#
public class NativeVisaException : Ivi.Visa.VisaException
```

Inheritance: [System.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object) -> [System.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception) -> [Ivi.Visa.VisaException](VisaException.md) -> **Ivi.Visa.NativeVisaException**

## Constructors

|Method Name|
|---|
|[NativeVisaException(int errorCode)](#NativeVisaExceptionint-errorCode-constructor)|
|[NativeVisaException(int errorCode, String message)](#NativeVisaExceptionint-errorCode-String-message-constructor)|
|[NativeVisaException(int errorCode, String message, System.Exception innerException)](#NativeVisaExceptionint-errorCode-String-message-SystemException-innerException-constructor)|
|[NativeVisaException(SerializationInfo info, StreamingContext context)](#NativeVisaExceptionSerializationInfo-info-StreamingContext-context-constructor)|

## Properties

|Property Name|
|---|
|[ErrorCode](#ErrorCode-Property)|

## public NativeVisaException(int errorCode) Constructor
```C#
public NativeVisaException(int errorCode)
```
## public NativeVisaException(int errorCode, String message) Constructor
```C#
public NativeVisaException(int errorCode, String message)
```
## public NativeVisaException(int errorCode, String message, System.Exception innerException) Constructor
```C#
public NativeVisaException(int errorCode, String message, System.Exception innerException)
```
## protected NativeVisaException(SerializationInfo info, StreamingContext context) Constructor
```C#
protected NativeVisaException(SerializationInfo info, StreamingContext context)
```
## ErrorCode Property
```C#
public int ErrorCode { get; protected set; }
```
