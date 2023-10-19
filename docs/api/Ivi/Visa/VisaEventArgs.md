English | 日本語

# VisaEventArgs Class

## Definition
Namespace:[Ivi.Visa](../Visa.md)<BR>
Assembly:Ivi.Visa.dll<BR>
Inheritance:[System.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object) -> [System.EventArgs](https://learn.microsoft.com/en-us/dotnet/api/system.eventargs) -> **Ivi.Visa.VisaEventArgs**

## Constructors

|Method Name|
|---|
|[VisaEventArgs(EventType eventType)](#visaeventargseventtype-eventtype-constructor)|
|[VisaEventArgs(Int32 customType)](#visaeventargsint32-customtype-constructor)|

## Properties

|Property Name|
|---|
|[EventType](#EventType-Property)|
|[CustomEventType](#CustomEventType-Property)|

## VisaEventArgs(EventType eventType) Constructor
```C#
public VisaEventArgs(EventType eventType)
```
## VisaEventArgs(Int32 customType) Constructor
```C#
public VisaEventArgs(Int32 customType)
```

## EventType Property
```C#
public EventType EventType { get; private set; }
```
## CustomEventType Property
```C#
public Int32 CustomEventType { get; private set; }
```
