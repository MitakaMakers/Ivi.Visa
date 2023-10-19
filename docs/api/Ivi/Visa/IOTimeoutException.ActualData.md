English | 日本語

[Ivi.Visa](../Visa.md) / [IOTimeoutException](IOTimeoutException.md)

# IOTimeoutException.ActualData Property

## Definition
Namespace:[Ivi.Visa](../Visa.md)<BR>
Assembly:Ivi.Visa.dll<BR>

The actual bytes read or written before the timeout occurred.
```C#
public Byte[] ActualData { get; protected set; }
```

## Property Value
[Byte](https://learn.microsoft.com/en-us/dotnet/api/system.byte)<BR>
The actual bytes read or written before the timeout occurred.  If the actual number of elements read could not be determined, the array is empty.
