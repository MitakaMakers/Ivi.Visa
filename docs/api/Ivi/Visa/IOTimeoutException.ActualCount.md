English | 日本語

[Ivi.Visa](../Visa.md) / [IOTimeoutException](IOTimeoutException.md)

# IOTimeoutException.ActualCount Property

## Definition
Namespace:[Ivi.Visa](../Visa.md)<BR>
Assembly:Ivi.Visa.dll<BR>

The actual number of elements read or written before the timeout occurred. 
```C#
public Int64 ActualCount { get; protected set; }
```

## Property Value
[Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64)<BR>
The actual number of elements read or written before the timeout occurred.  A value of -1 indicates that the actual number could not be determined.
