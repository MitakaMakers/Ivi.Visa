English | 日本語

# IMessageBasedFormattedIO Interface

## Definition
Namespace:[Ivi.Visa](Ivi.Visa.md)<BR>
Assembly:Ivi.Visa.dll<BR>

## Properties

|Property Name|
|---|

## Methods

|Method Name|
|---|

## BinaryEncoding Property
```C#
BinaryEncoding BinaryEncoding { get; set; }
```
## ReadBufferSize Property
```C#
Int32 ReadBufferSize { get; set; }
```
## WriteBufferSize Property
```C#
Int32 WriteBufferSize { get; set; }
```
## TypeFormatter Property
```C#
ITypeFormatter TypeFormatter { get; set; }
```
## DiscardBuffers() Method
```C#
void DiscardBuffers();
```
## FlushWrite(Boolean sendEnd) Method
```C#
void FlushWrite(Boolean sendEnd);
```
## Printf(String data) Method
```C#
void Printf(String data);
```
## Printf(String format, params object[] args) Method
```C#
void Printf(String format, params object[] args);
```
## PrintfAndFlush(String data) Method
```C#
void PrintfAndFlush(String data);
```
## PrintfAndFlush(String format, params object[] args) Method
```C#
void PrintfAndFlush(String format, params object[] args);
```
## PrintfArray(String format, Byte* pArray, params Int64[] inputs) Method
```C#
unsafe void PrintfArray(String format, Byte* pArray, params Int64[] inputs);
```
## PrintfArray(String format, SByte* pArray, params Int64[] inputs) Method
```C#
unsafe void PrintfArray(String format, SByte* pArray, params Int64[] inputs);
```
## PrintfArray(String format, Int16* pArray, params Int64[] inputs) Method
```C#
unsafe void PrintfArray(String format, Int16* pArray, params Int64[] inputs);
```
## PrintfArray(String format, UInt16* pArray, params Int64[] inputs) Method
```C#
unsafe void PrintfArray(String format, UInt16* pArray, params Int64[] inputs);
```
## PrintfArray(String format, Int32* pArray, params Int64[] inputs) Method
```C#
unsafe void PrintfArray(String format, Int32* pArray, params Int64[] inputs);
```
## PrintfArray(String format, UInt32* pArray, params Int64[] inputs) Method
```C#
unsafe void PrintfArray(String format, UInt32* pArray, params Int64[] inputs);
```
## PrintfArray(String format, Int64* pArray, params Int64[] inputs) Method
```C#
unsafe void PrintfArray(String format, Int64* pArray, params Int64[] inputs);
```
## PrintfArray(String format, UInt64* pArray, params Int64[] inputs) Method
```C#
unsafe void PrintfArray(String format, UInt64* pArray, params Int64[] inputs);
```
## PrintfArray(String format, Single* pArray, params Int64[] inputs) Method
```C#
unsafe void PrintfArray(String format, Single* pArray, params Int64[] inputs);
```
## PrintfArray(String format, Double* pArray, params Int64[] inputs) Method
```C#
unsafe void PrintfArray(String format, Double* pArray, params Int64[] inputs);
```
## PrintfArrayAndFlush(String format, Byte* pArray, params Int64[] inputs) Method
```C#
unsafe void PrintfArrayAndFlush(String format, Byte* pArray, params Int64[] inputs);
```
## PrintfArrayAndFlush(String format, SByte* pArray, params Int64[] inputs) Method
```C#
unsafe void PrintfArrayAndFlush(String format, SByte* pArray, params Int64[] inputs);
```
## PrintfArrayAndFlush(String format, Int16* pArray, params Int64[] inputs) Method
```C#
unsafe void PrintfArrayAndFlush(String format, Int16* pArray, params Int64[] inputs);
```
## PrintfArrayAndFlush(String format, UInt16* pArray, params Int64[] inputs) Method
```C#
unsafe void PrintfArrayAndFlush(String format, UInt16* pArray, params Int64[] inputs);
```
## PrintfArrayAndFlush(String format, Int32* pArray, params Int64[] inputs) Method
```C#
unsafe void PrintfArrayAndFlush(String format, Int32* pArray, params Int64[] inputs);
```
## PrintfArrayAndFlush(String format, UInt32* pArray, params Int64[] inputs) Method
```C#
unsafe void PrintfArrayAndFlush(String format, UInt32* pArray, params Int64[] inputs);
```
## PrintfArrayAndFlush(String format, Int64* pArray, params Int64[] inputs) Method
```C#
unsafe void PrintfArrayAndFlush(String format, Int64* pArray, params Int64[] inputs);
```
## PrintfArrayAndFlush(String format, UInt64* pArray, params Int64[] inputs) Method
```C#
unsafe void PrintfArrayAndFlush(String format, UInt64* pArray, params Int64[] inputs);
```
## PrintfArrayAndFlush(String format, Single* pArray, params Int64[] inputs) Method
```C#
unsafe void PrintfArrayAndFlush(String format, Single* pArray, params Int64[] inputs);
```
## PrintfArrayAndFlush(String format, Double* pArray, params Int64[] input Method
```C#
unsafe void PrintfArrayAndFlush(String format, Double* pArray, params Int64[] inputs
```
## Scanf<T>(String format, out T output) Method
```C#
void Scanf<T>(String format, out T output);
```
## Scanf<T1, T2>(String format, out T1 output1, out T2 output2) Method
```C#
void Scanf<T1, T2>(String format, out T1 output1, out T2 output2);
```
## Scanf<T1, T2, T3>(String format, out T1 output1, out T2 output2, out T3 output3) Method
```C#
void Scanf<T1, T2, T3>(String format, out T1 output1, out T2 output2, out T3 output3);
```
## Scanf<T1, T2, T3, T4>(String format, out T1 output1, out T2 output2, out T3 output3, out T4 output4) Method
```C#
void Scanf<T1, T2, T3, T4>(String format, out T1 output1, out T2 output2, out T3 output3, out T4 output4);
```
## Scanf<T1, T2, T3, T4, T5>(String format, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5) Method
```C#
void Scanf<T1, T2, T3, T4, T5>(String format, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5);
```
## Scanf<T1, T2, T3, T4, T5, T6>(String format, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5, out T6 output6) Method
```C#
void Scanf<T1, T2, T3, T4, T5, T6>(String format, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5, out T6 output6);
```
## Scanf<T1, T2, T3, T4, T5, T6, T7>(String format, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5, out T6 output6, out T7 output7) Method
```C#
void Scanf<T1, T2, T3, T4, T5, T6, T7>(String format, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5, out T6 output6, out T7 output7);
```
## Scanf<T>(String format, Int32[] inputs, out T output) Method
```C#
void Scanf<T>(String format, Int32[] inputs, out T output);
```
## Scanf<T1, T2>(String format, Int32[] inputs, out T1 output1, out T2 output2) Method
```C#
void Scanf<T1, T2>(String format, Int32[] inputs, out T1 output1, out T2 output2);
```
## Scanf<T1, T2, T3>(String format, Int32[] inputs, out T1 output1, out T2 output2, out T3 output3) Method
```C#
void Scanf<T1, T2, T3>(String format, Int32[] inputs, out T1 output1, out T2 output2, out T3 output3);
```
## Scanf<T1, T2, T3, T4>(String format, Int32[] inputs, out T1 output1, out T2 output2, out T3 output3, out T4 output4) Method
```C#
void Scanf<T1, T2, T3, T4>(String format, Int32[] inputs, out T1 output1, out T2 output2, out T3 output3, out T4 output4);
```
## Scanf<T1, T2, T3, T4, T5>(String format, Int32[] inputs, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5) Method
```C#
void Scanf<T1, T2, T3, T4, T5>(String format, Int32[] inputs, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5);
```
## Scanf<T1, T2, T3, T4, T5, T6>(String format, Int32[] inputs, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5, out T6 output6) Method
```C#
void Scanf<T1, T2, T3, T4, T5, T6>(String format, Int32[] inputs, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5, out T6 output6);
```
## Scanf<T1, T2, T3, T4, T5, T6, T7>(String format, Int32[] inputs, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5, out T6 output6, out T7 output7) Method
```C#
void Scanf<T1, T2, T3, T4, T5, T6, T7>(String format, Int32[] inputs, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5, out T6 output6, out T7 output7);
```
## ScanfArray(String format, Byte* pArray, params Int64[] inputs) Method
```C#
unsafe Int64 ScanfArray(String format, Byte* pArray, params Int64[] inputs);
```
## ScanfArray(String format, SByte* pArray, params Int64[] inputs) Method
```C#
unsafe Int64 ScanfArray(String format, SByte* pArray, params Int64[] inputs);
```
## ScanfArray(String format, Int16* pArray, params Int64[] inputs) Method
```C#
unsafe Int64 ScanfArray(String format, Int16* pArray, params Int64[] inputs);
```
## ScanfArray(String format, UInt16* pArray, params Int64[] inputs) Method
```C#
unsafe Int64 ScanfArray(String format, UInt16* pArray, params Int64[] inputs);
```
## ScanfArray(String format, Int32* pArray, params Int64[] inputs) Method
```C#
unsafe Int64 ScanfArray(String format, Int32* pArray, params Int64[] inputs);
```
## ScanfArray(String format, UInt32* pArray, params Int64[] inputs) Method
```C#
unsafe Int64 ScanfArray(String format, UInt32* pArray, params Int64[] inputs);
```
## ScanfArray(String format, Int64* pArray, params Int64[] inputs) Method
```C#
unsafe Int64 ScanfArray(String format, Int64* pArray, params Int64[] inputs);
```
## ScanfArray(String format, UInt64* pArray, params Int64[] inputs) Method
```C#
unsafe Int64 ScanfArray(String format, UInt64* pArray, params Int64[] inputs);
```
## ScanfArray(String format, Single* pArray, params Int64[] inputs) Method
```C#
unsafe Int64 ScanfArray(String format, Single* pArray, params Int64[] inputs);
```
## ScanfArray(String format, Double* pArray, params Int64[] inputs) Method
```C#
unsafe Int64 ScanfArray(String format, Double* pArray, params Int64[] inputs);
```
## Write(Char data) Method
```C#
void Write(Char data);
```
## Write(String data) Method
```C#
void Write(String data);
```
## Write(Int64 data) Method
```C#
void Write(Int64 data);
```
## Write(UInt64 data) Method
```C#
void Write(UInt64 data);
```
## Write(Double data) Method
```C#
void Write(Double data);
```
## WriteLine() Method
```C#
void WriteLine();
```
## WriteLine(Char data) Method
```C#
void WriteLine(Char data);
```
## WriteLine(String data) Method
```C#
void WriteLine(String data);
```
## WriteLine(Int64 data) Method
```C#
void WriteLine(Int64 data);
```
## WriteLine(UInt64 data) Method
```C#
void WriteLine(UInt64 data);
```
## WriteLine(Double data) Method
```C#
void WriteLine(Double data);
```
## WriteList(Byte[] data) Method
```C#
void WriteList(Byte[] data);
```
## WriteList(Byte[] data, Int64 index, Int64 count) Method
```C#
void WriteList(Byte[] data, Int64 index, Int64 count);
```
## WriteList(SByte[] data) Method
```C#
void WriteList(SByte[] data);
```
## WriteList(SByte[] data, Int64 index, Int64 count) Method
```C#
void WriteList(SByte[] data, Int64 index, Int64 count);
```
## WriteList(Int16[] data) Method
```C#
void WriteList(Int16[] data);
```
## WriteList(Int16[] data, Int64 index, Int64 count) Method
```C#
void WriteList(Int16[] data, Int64 index, Int64 count);
```
## WriteList(UInt16[] data) Method
```C#
[CLSCompliant(false)]
void WriteList(UInt16[] data);
```
## WriteList(UInt16[] data, Int64 index, Int64 count) Method
```C#
[CLSCompliant(false)]
void WriteList(UInt16[] data, Int64 index, Int64 count);
```
## WriteList(Int32[] data) Method
```C#
void WriteList(Int32[] data);
```
## WriteList(Int32[] data, Int64 index, Int64 count) Method
```C#
void WriteList(Int32[] data, Int64 index, Int64 count);
```
## WriteList(UInt32[] data) Method
```C#
[CLSCompliant(false)]
void WriteList(UInt32[] data);
```
## WriteList(UInt32[] data, Int64 index, Int64 count) Method
```C#
[CLSCompliant(false)]
void WriteList(UInt32[] data, Int64 index, Int64 count);
```
## WriteList(Int64[] data) Method
```C#
void WriteList(Int64[] data);
```
## WriteList(Int64[] data, Int64 index, Int64 count) Method
```C#
void WriteList(Int64[] data, Int64 index, Int64 count);
```
## WriteList(UInt64[] data) Method
```C#
[CLSCompliant(false)]
void WriteList(UInt64[] data);
```
## WriteList(UInt64[] data, Int64 index, Int64 count) Method
```C#
[CLSCompliant(false)]
void WriteList(UInt64[] data, Int64 index, Int64 count);
```
## WriteList(Single[] data) Method
```C#
void WriteList(Single[] data);
```
## WriteList(Single[] data, Int64 index, Int64 count) Method
```C#
void WriteList(Single[] data, Int64 index, Int64 count);
```
## WriteList(Double[] data) Method
```C#
void WriteList(Double[] data);
```
## WriteList(Double[] data, Int64 index, Int64 count) Method
```C#
void WriteList(Double[] data, Int64 index, Int64 count);
```
## WriteLineList(Byte[] data) Method
```C#
void WriteLineList(Byte[] data);
```
## WriteLineList(Byte[] data, Int64 index, Int64 count) Method
```C#
void WriteLineList(Byte[] data, Int64 index, Int64 count);
```
## WriteLineList(SByte[] data) Method
```C#
void WriteLineList(SByte[] data);
```
## WriteLineList(SByte[] data, Int64 index, Int64 count) Method
```C#
void WriteLineList(SByte[] data, Int64 index, Int64 count);
```
## WriteLineList(Int16[] data) Method
```C#
void WriteLineList(Int16[] data);
```
## WriteLineList(Int16[] data, Int64 index, Int64 count) Method
```C#
void WriteLineList(Int16[] data, Int64 index, Int64 count);
```
## WriteLineList(UInt16[] data) Method
```C#
[CLSCompliant(false)]
void WriteLineList(UInt16[] data);
```
## WriteLineList(UInt16[] data, Int64 index, Int64 count) Method
```C#
[CLSCompliant(false)]
void WriteLineList(UInt16[] data, Int64 index, Int64 count);
```
## WriteLineList(Int32[] data) Method
```C#
void WriteLineList(Int32[] data);
```
## WriteLineList(Int32[] data, Int64 index, Int64 count) Method
```C#
void WriteLineList(Int32[] data, Int64 index, Int64 count);
```
## WriteLineList(UInt32[] data) Method
```C#
[CLSCompliant(false)]
void WriteLineList(UInt32[] data);
```
## WriteLineList(UInt32[] data, Int64 index, Int64 count) Method
```C#
[CLSCompliant(false)]
void WriteLineList(UInt32[] data, Int64 index, Int64 count);
```
## WriteLineList(Int64[] data) Method
```C#
void WriteLineList(Int64[] data);
```
## WriteLineList(Int64[] data, Int64 index, Int64 count) Method
```C#
void WriteLineList(Int64[] data, Int64 index, Int64 count);
```
## WriteLineList(UInt64[] data) Method
```C#
[CLSCompliant(false)]
void WriteLineList(UInt64[] data);
```
## WriteLineList(UInt64[] data, Int64 index, Int64 count) Method
```C#
[CLSCompliant(false)]
void WriteLineList(UInt64[] data, Int64 index, Int64 count);
```
## WriteLineList(Single[] data) Method
```C#
void WriteLineList(Single[] data);
```
## WriteLineList(Single[] data, Int64 index, Int64 count) Method
```C#
void WriteLineList(Single[] data, Int64 index, Int64 count);
```
## WriteLineList(Double[] data) Method
```C#
void WriteLineList(Double[] data);
```
## WriteLineList(Double[] data, Int64 index, Int64 count) Method
```C#
void WriteLineList(Double[] data, Int64 index, Int64 count);
```
## WriteLineList(Byte[] data) Method
```C#
void WriteLineList(Byte[] data);
```
## WriteLineList(Byte[] data, Int64 index, Int64 count) Method
```C#
void WriteLineList(Byte[] data, Int64 index, Int64 count);
```
## WriteLineList(SByte[] data) Method
```C#
void WriteLineList(SByte[] data);
```
## WriteLineList(SByte[] data, Int64 index, Int64 count) Method
```C#
void WriteLineList(SByte[] data, Int64 index, Int64 count);
```
## WriteLineList(Int16[] data) Method
```C#
void WriteLineList(Int16[] data);
```
## WriteLineList(Int16[] data, Int64 index, Int64 count) Method
```C#
void WriteLineList(Int16[] data, Int64 index, Int64 count);
```
## WriteBinaryAndFlush(Byte[] data) Method
```C#
void WriteBinaryAndFlush(Byte[] data);
```
## WriteBinaryAndFlush(Byte[] data, Int64 index, Int64 count) Method
```C#
void WriteBinaryAndFlush(Byte[] data, Int64 index, Int64 count);
```
## WriteBinaryAndFlush(SByte[] data) Method
```C#
void WriteBinaryAndFlush(SByte[] data);
```
## WriteBinaryAndFlush(SByte[] data, Int64 index, Int64 count) Method
```C#
void WriteBinaryAndFlush(SByte[] data, Int64 index, Int64 count);
```
## WriteBinaryAndFlush(Int16[] data) Method
```C#
void WriteBinaryAndFlush(Int16[] data);
```
## WriteBinaryAndFlush(Int16[] data, Int64 index, Int64 count) Method
```C#
void WriteBinaryAndFlush(Int16[] data, Int64 index, Int64 count);
```
## WriteBinaryAndFlush(UInt16[] data) Method
```C#
[CLSCompliant(false)]
void WriteBinaryAndFlush(UInt16[] data);
```
## WriteBinaryAndFlush(UInt16[] data, Int64 index, Int64 count) Method
```C#
[CLSCompliant(false)]
void WriteBinaryAndFlush(UInt16[] data, Int64 index, Int64 count);
```
## WriteBinaryAndFlush(Int32[] data) Method
```C#
void WriteBinaryAndFlush(Int32[] data);
```
## WriteBinaryAndFlush(Int32[] data, Int64 index, Int64 count) Method
```C#
void WriteBinaryAndFlush(Int32[] data, Int64 index, Int64 count);
```
## WriteBinaryAndFlush(UInt32[] data) Method
```C#
[CLSCompliant(false)]
void WriteBinaryAndFlush(UInt32[] data);
```
## WriteBinaryAndFlush(UInt32[] data, Int64 index, Int64 count) Method
```C#
[CLSCompliant(false)]
void WriteBinaryAndFlush(UInt32[] data, Int64 index, Int64 count);
```
## WriteBinaryAndFlush(Int64[] data) Method
```C#
void WriteBinaryAndFlush(Int64[] data);
```
## WriteBinaryAndFlush(Int64[] data, Int64 index, Int64 count) Method
```C#
void WriteBinaryAndFlush(Int64[] data, Int64 index, Int64 count);
```
## WriteBinaryAndFlush(UInt64[] data) Method
```C#
[CLSCompliant(false)]
void WriteBinaryAndFlush(UInt64[] data);
```
## WriteBinaryAndFlush(UInt64[] data, Int64 index, Int64 count) Method
```C#
[CLSCompliant(false)]
void WriteBinaryAndFlush(UInt64[] data, Int64 index, Int64 count);
```
## WriteBinaryAndFlush(Single[] data) Method
```C#
void WriteBinaryAndFlush(Single[] data);
```
## WriteBinaryAndFlush(Single[] data, Int64 index, Int64 count) Method
```C#
void WriteBinaryAndFlush(Single[] data, Int64 index, Int64 count);
```
## WriteBinaryAndFlush(Double[] data) Method
```C#
void WriteBinaryAndFlush(Double[] data);
```
## WriteBinaryAndFlush(Double[] data, Int64 index, Int64 count) Method
```C#
void WriteBinaryAndFlush(Double[] data, Int64 index, Int64 count);
```
## ReadString() Method
```C#
String ReadString();
```
## ReadString(Int32 count) Method
```C#
String ReadString(Int32 count);
```
## ReadString(StringBuilder data) Method
```C#
Int32 ReadString(StringBuilder data);
```
## ReadString(StringBuilder data, Int32 count) Method
```C#
Int32 ReadString(StringBuilder data, Int32 count);
```
## ReadChar() Method
```C#
Char ReadChar();
```
## ReadInt64() Method
```C#
Int64 ReadInt64();
```
## ReadUInt64() Method
```C#
UInt64 ReadUInt64();
```
## ReadDouble() Method
```C#
Double ReadDouble();
```
## ReadLine() Method
```C#
String ReadLine();
```
## ReadLine(StringBuilder data) Method
```C#
Int32 ReadLine(StringBuilder data);
```
## ReadLineChar() Method
```C#
Char ReadLineChar();
```
## ReadLineInt64() Method
```C#
Int64 ReadLineInt64();
```
## ReadLineUInt64() Method
```C#
UInt64 ReadLineUInt64();
```
## ReadLineDouble() Method
```C#
Double ReadLineDouble();
```
## ReadListOfByte(Int64 count) Method
```C#
Byte[] ReadListOfByte(Int64 count);
```
## ReadListOfByte(Byte[] data, Int64 index, Int64 count) Method
```C#
Int64 ReadListOfByte(Byte[] data, Int64 index, Int64 count);
```
## ReadListOfSByte(Int64 count) Method
```C#
SByte[] ReadListOfSByte(Int64 count);
```
## ReadListOfSByte(SByte[] data, Int64 index, Int64 count) Method
```C#
Int64 ReadListOfSByte(SByte[] data, Int64 index, Int64 count);
```
## ReadListOfInt16(Int64 count) Method
```C#
Int16[] ReadListOfInt16(Int64 count);
```
## ReadListOfInt16(Int16[] data, Int64 index, Int64 count) Method
```C#
Int64 ReadListOfInt16(Int16[] data, Int64 index, Int64 count);
```
## ReadListOfUInt16(Int64 count) Method
```C#
UInt16[] ReadListOfUInt16(Int64 count);
```
## ReadListOfUInt16(UInt16[] data, Int64 index, Int64 count) Method
```C#
Int64 ReadListOfUInt16(UInt16[] data, Int64 index, Int64 count);
```
## ReadListOfInt32(Int64 count) Method
```C#
Int32[] ReadListOfInt32(Int64 count);
```
## ReadListOfInt32(Int32[] data, Int64 index, Int64 count) Method
```C#
Int64 ReadListOfInt32(Int32[] data, Int64 index, Int64 count);
```
## ReadListOfUInt32(Int64 count) Method
```C#
UInt32[] ReadListOfUInt32(Int64 count);
```
## ReadListOfUInt32(UInt32[] data, Int64 index, Int64 count) Method
```C#
Int64 ReadListOfUInt32(UInt32[] data, Int64 index, Int64 count);
```
## ReadListOfInt64(Int64 count) Method
```C#
Int64[] ReadListOfInt64(Int64 count);
```
## ReadListOfInt64(Int64[] data, Int64 index, Int64 count) Method
```C#
Int64 ReadListOfInt64(Int64[] data, Int64 index, Int64 count);
```
## ReadListOfUInt64(Int64 count) Method
```C#
UInt64[] ReadListOfUInt64(Int64 count);
```
## ReadListOfUInt64(UInt64[] data, Int64 index, Int64 count) Method
```C#
Int64 ReadListOfUInt64(UInt64[] data, Int64 index, Int64 count);
```
## ReadListOfSingle(Int64 count) Method
```C#
Single[] ReadListOfSingle(Int64 count);
```
## ReadListOfSingle(Single[] data, Int64 index, Int64 count) Method
```C#
Int64 ReadListOfSingle(Single[] data, Int64 index, Int64 count);
```
## ReadListOfDouble(Int64 count) Method
```C#
Double[] ReadListOfDouble(Int64 count);
```
## ReadListOfDouble(Double[] data, Int64 index, Int64 count) Method
```C#
Int64 ReadListOfDouble(Double[] data, Int64 index, Int64 count);
```
## ReadListOfByte(Int64 count) Method
```C#
Byte[] ReadListOfByte(Int64 count);
```
## ReadListOfByte(Byte[] data, Int64 index, Int64 count) Method
```C#
Int64 ReadListOfByte(Byte[] data, Int64 index, Int64 count);
```
## ReadListOfSByte(Int64 count) Method
```C#
SByte[] ReadListOfSByte(Int64 count);
```
## ReadListOfSByte(SByte[] data, Int64 index, Int64 count) Method
```C#
Int64 ReadListOfSByte(SByte[] data, Int64 index, Int64 count);
```
## ReadListOfInt16(Int64 count) Method
```C#
Int16[] ReadListOfInt16(Int64 count);
```
## ReadListOfInt16(Int16[] data, Int64 index, Int64 count) Method
```C#
Int64 ReadListOfInt16(Int16[] data, Int64 index, Int64 count);
```
## ReadListOfUInt16(Int64 count) Method
```C#
UInt16[] ReadListOfUInt16(Int64 count);
```
## ReadListOfUInt16(UInt16[] data, Int64 index, Int64 count) Method
```C#
Int64 ReadListOfUInt16(UInt16[] data, Int64 index, Int64 count);
```
## ReadListOfInt32(Int64 count) Method
```C#
Int32[] ReadListOfInt32(Int64 count);
```
## ReadListOfInt32(Int32[] data, Int64 index, Int64 count) Method
```C#
Int64 ReadListOfInt32(Int32[] data, Int64 index, Int64 count);
```
## ReadListOfUInt32(Int64 count) Method
```C#
UInt32[] ReadListOfUInt32(Int64 count);
```
## ReadListOfUInt32(UInt32[] data, Int64 index, Int64 count) Method
```C#
Int64 ReadListOfUInt32(UInt32[] data, Int64 index, Int64 count);
```
## ReadListOfInt64(Int64 count) Method
```C#
Int64[] ReadListOfInt64(Int64 count);
```
## ReadListOfInt64(Int64[] data, Int64 index, Int64 count) Method
```C#
Int64 ReadListOfInt64(Int64[] data, Int64 index, Int64 count);
```
## ReadListOfUInt64(Int64 count) Method
```C#
UInt64[] ReadListOfUInt64(Int64 count);
```
## ReadListOfUInt64(UInt64[] data, Int64 index, Int64 count) Method
```C#
Int64 ReadListOfUInt64(UInt64[] data, Int64 index, Int64 count);
```
## ReadListOfSingle(Int64 count) Method
```C#
Single[] ReadListOfSingle(Int64 count);
```
## ReadListOfSingle(Single[] data, Int64 index, Int64 count) Method
```C#
Int64 ReadListOfSingle(Single[] data, Int64 index, Int64 count);
```
## ReadListOfDouble(Int64 count) Method
```C#
Double[] ReadListOfDouble(Int64 count);
```
## ReadListOfDouble(Double[] data, Int64 index, Int64 count) Method
```C#
Int64 ReadListOfDouble(Double[] data, Int64 index, Int64 count);
```
## ReadBinaryBlockOfByte() Method
```C#
Byte[] ReadBinaryBlockOfByte();
```
## ReadBinaryBlockOfByte(Boolean seekToBlock) Method
```C#
Byte[] ReadBinaryBlockOfByte(Boolean seekToBlock);
```
## ReadBinaryBlockOfByte(Byte[] data, Int64 index, Int64 count) Method
```C#
Int64 ReadBinaryBlockOfByte(Byte[] data, Int64 index, Int64 count);
```
## ReadBinaryBlockOfByte(Byte[] data, Int64 index, Int64 count, Boolean seekToBlock) Method
```C#
Int64 ReadBinaryBlockOfByte(Byte[] data, Int64 index, Int64 count, Boolean seekToBlock);
```
## ReadBinaryBlockOfSByte() Method
```C#
SByte[] ReadBinaryBlockOfSByte();
```
## ReadBinaryBlockOfSByte(Boolean seekToBlock) Method
```C#
SByte[] ReadBinaryBlockOfSByte(Boolean seekToBlock);
```
## ReadBinaryBlockOfSByte(SByte[] data, Int64 index, Int64 count) Method
```C#
Int64 ReadBinaryBlockOfSByte(SByte[] data, Int64 index, Int64 count);
```
## ReadBinaryBlockOfSByte(SByte[] data, Int64 index, Int64 count, Boolean seekToBlock) Method
```C#
Int64 ReadBinaryBlockOfSByte(SByte[] data, Int64 index, Int64 count, Boolean seekToBlock);
```
## ReadBinaryBlockOfInt16() Method
```C#
Int16[] ReadBinaryBlockOfInt16();
```
## ReadBinaryBlockOfInt16(Boolean seekToBlock) Method
```C#
Int16[] ReadBinaryBlockOfInt16(Boolean seekToBlock);
```
## ReadBinaryBlockOfInt16(Int16[] data, Int64 index, Int64 count) Method
```C#
Int64 ReadBinaryBlockOfInt16(Int16[] data, Int64 index, Int64 count);
```
## ReadBinaryBlockOfInt16(Int16[] data, Int64 index, Int64 count, Boolean seekToBlock) Method
```C#
Int64 ReadBinaryBlockOfInt16(Int16[] data, Int64 index, Int64 count, Boolean seekToBlock);
```
## ReadBinaryBlockOfUInt16() Method
```C#
UInt16[] ReadBinaryBlockOfUInt16();
```
## ReadBinaryBlockOfUInt16(Boolean seekToBlock) Method
```C#
UInt16[] ReadBinaryBlockOfUInt16(Boolean seekToBlock);
```
## ReadBinaryBlockOfUInt16(UInt16[] data, Int64 index, Int64 count) Method
```C#
Int64 ReadBinaryBlockOfUInt16(UInt16[] data, Int64 index, Int64 count);
```
## ReadBinaryBlockOfUInt16(UInt16[] data, Int64 index, Int64 count, Boolean seekToBlock) Method
```C#
Int64 ReadBinaryBlockOfUInt16(UInt16[] data, Int64 index, Int64 count, Boolean seekToBlock);
```
## ReadBinaryBlockOfInt32() Method
```C#
Int32[] ReadBinaryBlockOfInt32();
```
## ReadBinaryBlockOfInt32(Boolean seekToBlock) Method
```C#
Int32[] ReadBinaryBlockOfInt32(Boolean seekToBlock);
```
## ReadBinaryBlockOfInt32(Int32[] data, Int64 index, Int64 count) Method
```C#
Int64 ReadBinaryBlockOfInt32(Int32[] data, Int64 index, Int64 count);
```
## ReadBinaryBlockOfInt32(Int32[] data, Int64 index, Int64 count, Boolean seekToBlock) Method
```C#
Int64 ReadBinaryBlockOfInt32(Int32[] data, Int64 index, Int64 count, Boolean seekToBlock);
```
## ReadBinaryBlockOfUInt32() Method
```C#
UInt32[] ReadBinaryBlockOfUInt32();
```
## ReadBinaryBlockOfUInt32(Boolean seekToBlock) Method
```C#
UInt32[] ReadBinaryBlockOfUInt32(Boolean seekToBlock);
```
## ReadBinaryBlockOfUInt32(UInt32[] data, Int64 index, Int64 count) Method
```C#
Int64 ReadBinaryBlockOfUInt32(UInt32[] data, Int64 index, Int64 count);
```
## ReadBinaryBlockOfUInt32(UInt32[] data, Int64 index, Int64 count, Boolean seekToBlock) Method
```C#
Int64 ReadBinaryBlockOfUInt32(UInt32[] data, Int64 index, Int64 count, Boolean seekToBlock);
```
## ReadBinaryBlockOfInt64() Method
```C#
Int64[] ReadBinaryBlockOfInt64();
```
## ReadBinaryBlockOfInt64(Int64[] data, Int64 index, Int64 count) Method
```C#
Int64 ReadBinaryBlockOfInt64(Int64[] data, Int64 index, Int64 count);
```
## ReadBinaryBlockOfUInt64() Method
```C#
UInt64[] ReadBinaryBlockOfUInt64();
```
## ReadBinaryBlockOfUInt64(UInt64[] data, Int64 index, Int64 count) Method
```C#
Int64 ReadBinaryBlockOfUInt64(UInt64[] data, Int64 index, Int64 count);
```
## ReadBinaryBlockOfSingle() Method
```C#
Single[] ReadBinaryBlockOfSingle();
```
## ReadBinaryBlockOfSingle(Boolean seekToBlock) Method
```C#
Single[] ReadBinaryBlockOfSingle(Boolean seekToBlock);
```
## ReadBinaryBlockOfSingle(Single[] data, Int64 index, Int64 count) Method
```C#
Int64 ReadBinaryBlockOfSingle(Single[] data, Int64 index, Int64 count);
```
## ReadBinaryBlockOfSingle(Single[] data, Int64 index, Int64 count, Boolean seekToBlock) Method
```C#
Int64 ReadBinaryBlockOfSingle(Single[] data, Int64 index, Int64 count, Boolean seekToBlock);
```
## ReadBinaryBlockOfDouble() Method
```C#
Double[] ReadBinaryBlockOfDouble();
```
## ReadBinaryBlockOfDouble(Boolean seekToBlock) Method
```C#
Double[] ReadBinaryBlockOfDouble(Boolean seekToBlock);
```
## ReadBinaryBlockOfDouble(Double[] data, Int64 index, Int64 count) Method
```C#
Int64 ReadBinaryBlockOfDouble(Double[] data, Int64 index, Int64 count);
```
## ReadBinaryBlockOfDouble(Double[] data, Int64 index, Int64 count, Boolean seekToBlock) Method
```C#
Int64 ReadBinaryBlockOfDouble(Double[] data, Int64 index, Int64 count, Boolean seekToBlock);
```
## ReadLineBinaryBlockOfByte() Method
```C#
Byte[] ReadLineBinaryBlockOfByte();
```
## ReadLineBinaryBlockOfByte(Boolean seekToBlock) Method
```C#
Byte[] ReadLineBinaryBlockOfByte(Boolean seekToBlock);
```
## ReadLineBinaryBlockOfByte(Byte[] data, Int64 index, Int64 count) Method
```C#
Int64 ReadLineBinaryBlockOfByte(Byte[] data, Int64 index, Int64 count);
```
## ReadLineBinaryBlockOfByte(Byte[] data, Int64 index, Int64 count, Boolean seekToBlock) Method
```C#
Int64 ReadLineBinaryBlockOfByte(Byte[] data, Int64 index, Int64 count, Boolean seekToBlock);
```
## ReadLineBinaryBlockOfSByte() Method
```C#
SByte[] ReadLineBinaryBlockOfSByte();
```
## ReadLineBinaryBlockOfSByte(Boolean seekToBlock) Method
```C#
SByte[] ReadLineBinaryBlockOfSByte(Boolean seekToBlock);
```
## ReadLineBinaryBlockOfSByte(SByte[] data, Int64 index, Int64 count) Method
```C#
Int64 ReadLineBinaryBlockOfSByte(SByte[] data, Int64 index, Int64 count);
```
## ReadLineBinaryBlockOfSByte(SByte[] data, Int64 index, Int64 count, Boolean seekToBlock) Method
```C#
Int64 ReadLineBinaryBlockOfSByte(SByte[] data, Int64 index, Int64 count, Boolean seekToBlock);
```
## ReadLineBinaryBlockOfInt16() Method
```C#
Int16[] ReadLineBinaryBlockOfInt16();
```
## ReadLineBinaryBlockOfInt16(Boolean seekToBlock) Method
```C#
Int16[] ReadLineBinaryBlockOfInt16(Boolean seekToBlock);
```
## ReadLineBinaryBlockOfInt16(Int16[] data, Int64 index, Int64 count) Method
```C#
Int64 ReadLineBinaryBlockOfInt16(Int16[] data, Int64 index, Int64 count);
```
## ReadLineBinaryBlockOfInt16(Int16[] data, Int64 index, Int64 count, Boolean seekToBlock) Method
```C#
Int64 ReadLineBinaryBlockOfInt16(Int16[] data, Int64 index, Int64 count, Boolean seekToBlock);
```
## ReadLineBinaryBlockOfUInt16() Method
```C#
UInt16[] ReadLineBinaryBlockOfUInt16();
```
## ReadLineBinaryBlockOfUInt16(Boolean seekToBlock) Method
```C#
UInt16[] ReadLineBinaryBlockOfUInt16(Boolean seekToBlock);
```
## ReadLineBinaryBlockOfUInt16(UInt16[] data, Int64 index, Int64 count) Method
```C#
Int64 ReadLineBinaryBlockOfUInt16(UInt16[] data, Int64 index, Int64 count);
```
## ReadLineBinaryBlockOfUInt16(UInt16[] data, Int64 index, Int64 count, Boolean seekToBlock) Method
```C#
Int64 ReadLineBinaryBlockOfUInt16(UInt16[] data, Int64 index, Int64 count, Boolean seekToBlock);
```
## ReadLineBinaryBlockOfInt32() Method
```C#
Int32[] ReadLineBinaryBlockOfInt32();
```
## ReadLineBinaryBlockOfInt32(Boolean seekToBlock) Method
```C#
Int32[] ReadLineBinaryBlockOfInt32(Boolean seekToBlock);
```
## ReadLineBinaryBlockOfInt32(Int32[] data, Int64 index, Int64 count) Method
```C#
Int64 ReadLineBinaryBlockOfInt32(Int32[] data, Int64 index, Int64 count);
```
## ReadLineBinaryBlockOfInt32(Int32[] data, Int64 index, Int64 count, Boolean seekToBlock) Method
```C#
Int64 ReadLineBinaryBlockOfInt32(Int32[] data, Int64 index, Int64 count, Boolean seekToBlock);
```
## ReadLineBinaryBlockOfUInt32() Method
```C#
UInt32[] ReadLineBinaryBlockOfUInt32();
```
## ReadLineBinaryBlockOfUInt32(Boolean seekToBlock) Method
```C#
UInt32[] ReadLineBinaryBlockOfUInt32(Boolean seekToBlock);
```
## ReadLineBinaryBlockOfUInt32(UInt32[] data, Int64 index, Int64 count) Method
```C#
Int64 ReadLineBinaryBlockOfUInt32(UInt32[] data, Int64 index, Int64 count);
```
## ReadLineBinaryBlockOfUInt32(UInt32[] data, Int64 index, Int64 count, Boolean seekToBlock) Method
```C#
Int64 ReadLineBinaryBlockOfUInt32(UInt32[] data, Int64 index, Int64 count, Boolean seekToBlock);
```
## ReadLineBinaryBlockOfInt64() Method
```C#
Int64[] ReadLineBinaryBlockOfInt64();
```
## ReadLineBinaryBlockOfInt64(Int64[] data, Int64 index, Int64 count) Method
```C#
Int64 ReadLineBinaryBlockOfInt64(Int64[] data, Int64 index, Int64 count);
```
## ReadLineBinaryBlockOfUInt64() Method
```C#
UInt64[] ReadLineBinaryBlockOfUInt64();
```
## ReadLineBinaryBlockOfUInt64(UInt64[] data, Int64 index, Int64 count) Method
```C#
Int64 ReadLineBinaryBlockOfUInt64(UInt64[] data, Int64 index, Int64 count);
```
## ReadLineBinaryBlockOfSingle() Method
```C#
Single[] ReadLineBinaryBlockOfSingle();
```
## ReadLineBinaryBlockOfSingle(Boolean seekToBlock) Method
```C#
Single[] ReadLineBinaryBlockOfSingle(Boolean seekToBlock);
```
## ReadLineBinaryBlockOfSingle(Single[] data, Int64 index, Int64 count) Method
```C#
Int64 ReadLineBinaryBlockOfSingle(Single[] data, Int64 index, Int64 count);
```
## ReadLineBinaryBlockOfSingle(Single[] data, Int64 index, Int64 count, Boolean seekToBlock) Method
```C#
Int64 ReadLineBinaryBlockOfSingle(Single[] data, Int64 index, Int64 count, Boolean seekToBlock);
```
## ReadLineBinaryBlockOfDouble() Method
```C#
Double[] ReadLineBinaryBlockOfDouble();
```
## ReadLineBinaryBlockOfDouble(Boolean seekToBlock) Method
```C#
Double[] ReadLineBinaryBlockOfDouble(Boolean seekToBlock);
```
## ReadLineBinaryBlockOfDouble(Double[] data, Int64 index, Int64 count) Method
```C#
Int64 ReadLineBinaryBlockOfDouble(Double[] data, Int64 index, Int64 count);
```
## ReadLineBinaryBlockOfDouble(Double[] data, Int64 index, Int64 count, Boolean seekToBlock) Method
```C#
Int64 ReadLineBinaryBlockOfDouble(Double[] data, Int64 index, Int64 count, Boolean seekToBlock);
```
## ReadWhileMatch(String characters) Method
```C#
String ReadWhileMatch(String characters);
```
## ReadUntilMatch(Char ch) Method
```C#
String ReadUntilMatch(Char ch);
```
## ReadUntilMatch(String characters, Boolean discardMatch) Method
```C#
String ReadUntilMatch(String characters, Boolean discardMatch);
```
## ReadUntilEnd() Method
```C#
String ReadUntilEnd();
```
## Skip(Int64 count) Method
```C#
void Skip(Int64 count);
```
## SkipString (String data) Method
```C#
void SkipString (String data);
```
## SkipUntilEnd() Method
```C#
void SkipUntilEnd();
```
