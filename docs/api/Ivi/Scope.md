English | 日本語

# IIviScope Interface

## Definition
Namespace:[Ivi.Visa](Ivi.Scope.md)<BR>
Assembly:Ivi.Visa.dll

## Properties

|Property Name|
|---|
|Acquisition.StartTime|
|Measurement.Status;|
|Acquisition.Type|
|Channels.Count|
|Channels[].Enabled|
|Channels[String name]|
|Channels[].Name|
|Acquisition.NumberOfPointsMinimum|
|Acquisition.RecordLength|
|Acquisition.SampleRate|
|Acquisition.TimePerRecord|

## Methods

|Method Name|
|---|

## Property
```C#
Acquisition.StartTime
Measurement.Status;
Acquisition.Type
Channels.Count
Channels[].Enabled
Channels[String name]
Channels[].Name
Acquisition.NumberOfPointsMinimum
Acquisition.RecordLength
Acquisition.SampleRate
Acquisition.TimePerRecord
```
##  Method
```C#
IIviScope Ivi.Scope.Create(String name);
IIviScope Ivi.Scope.Create(String name, Boolean idQuery, Boolean reset);
IIviScope Ivi.Scope.Create(String name, Boolean idQuery, Boolean reset, String options);
IIviScope Ivi.Scope.Create(String resourceName, Boolean idQuery, Boolean reset, LockType lockType, String accessKey, String options);
```
