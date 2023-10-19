English | [日本語](Ivi.Visa.IResourceManager.ja.md)

# IMessageBasedRawIO Interface

## Definition
Namespace:[Ivi.Visa](../Visa.md)<BR>
Assembly:Ivi.Visa.dll<BR>

## Methods

|Method Name|
|---|
|[Read()](#Read-Method)|
|[Read(Int64 count)](#ReadInt64-count-Method)|
|[Read(Int64 count, out ReadStatus readStatus)](#ReadInt64-count-out-ReadStatus-readStatus-Method)|
|[Read(Byte[] buffer, Int64 index, Int64 count, out Int64 actualCount, out ReadStatus readStatus)](#ReadByte-buffer-Int64-index-Int64-count-out-Int64-actualCount-out-ReadStatus-readStatus-Method)|
|[Read(Byte* buffer, Int64 index, Int64 count, out Int64 actualCount, out ReadStatus readStatus)](#ReadByte-buffer-Int64-index-Int64-count-out-Int64-actualCount-out-ReadStatus-readStatus-Method)|
|[ReadString()](#ReadString-Method)|
|[ReadString(Int64 count)](#ReadStringInt64-count-Method)|
|[ReadString(Int64 count, out ReadStatus readStatus)](#ReadStringInt64-count-out-ReadStatus-readStatus-Method)|
|[Write(Byte[] buffer)](#WriteByte-buffer-Method)|
|[Write(Byte[] buffer, Int64 index, Int64 count)](#WriteByte-buffer-Int64-index-Int64-count-Method)|
|[Write(String buffer)](#WriteString-buffer-Method)|
|[Write(String buffer, Int64 index, Int64 count)](#WriteString-buffer-Int64-index-Int64-count-Method)|
|[Write(Byte* buffer, Int64 index, Int64 count)](#WriteByte-buffer-Int64-index-Int64-count-Method)|
|[AbortAsyncOperation(IVisaAsyncResult result)](#AbortAsyncOperationIVisaAsyncResult-result-Method)|
|[BeginRead(Int32 count)](#BeginReadInt32-count-Method)|
|[BeginRead(Int32 count, Object state)](#BeginReadInt32-count-Object-state-Method)|
|[BeginRead(Int32 count, VisaAsyncCallback callback, Object state)](#BeginReadInt32-count-VisaAsyncCallback-callback-Object-state-Method)|
|[BeginRead(Byte[] buffer)](#BeginReadByte-buffer-Method)|
|[BeginRead(Byte[] buffer, Object state)](#BeginReadByte-buffer-Object-state-Method)|
|[BeginRead(Byte[] buffer, Int64 index, Int64 count)](#BeginReadByte-buffer-Int64-index-Int64-count-Method)|
|[BeginRead(Byte[] buffer, Int64 index, Int64 count, Object state)](#BeginReadByte-buffer-Int64-index-Int64-count-Object-state-Method)|
|[BeginRead(Byte[] buffer, VisaAsyncCallback callback, Object state)](#BeginReadByte-buffer-VisaAsyncCallback-callback-Object-state-Method)|
|[BeginRead(Byte[] buffer, Int64 index, Int64 count, VisaAsyncCallback callback, Object state)](#BeginReadByte-buffer-Int64-index-Int64-count-VisaAsyncCallback-callback-Object-state-Method)|
|[BeginWrite(String buffer)](#BeginWriteString-buffer-Method)|
|[BeginWrite(String buffer, Object state)](#BeginWriteString-buffer-Object-state-Method)|
|[BeginWrite(String buffer, VisaAsyncCallback callback, Object state)](#BeginWriteString-buffer-VisaAsyncCallback-callback-Object-state-Method)|
|[BeginWrite(Byte[] buffer)](#BeginWriteByte-buffer-Method)|
|[BeginWrite(Byte[] buffer, Object state)](#BeginWriteByte-buffer-Object-state-Method)|
|[BeginWrite(Byte[] buffer, Int64 index, Int64 count)](#BeginWriteByte-buffer-Int64-index-Int64-count-Method)|
|[BeginWrite(Byte[] buffer, Int64 index, Int64 count, Object state)](#BeginWriteByte-buffer-Int64-index-Int64-count-Object-state-Method)|
|[BeginWrite(Byte[] buffer, VisaAsyncCallback callback, Object state)](#BeginWriteByte-buffer-VisaAsyncCallback-callback-Object-state-Method)|
|[BeginWrite(Byte[] buffer, Int64 index, Int64 count, VisaAsyncCallback callback, Object state)](#BeginWriteByte-buffer-Int64-index-Int64-count-VisaAsyncCallback-callback-Object-state-Method)|
|[EndRead(IVisaAsyncResult result)](#EndReadIVisaAsyncResult-result-Method)|
|[EndReadString(IVisaAsyncResult result)](#EndReadStringIVisaAsyncResult-result-Method)|
|[EndWrite(IVisaAsyncResult result)](#EndWriteIVisaAsyncResult-result-Method)|

## Read() Method
```C#
Byte[] Read();
```
## Read(Int64 count) Method
```C#
Byte[] Read(Int64 count);
```
## Read(Int64 count, out ReadStatus readStatus) Method
```C#
Byte[] Read(Int64 count, out ReadStatus readStatus);
```
## Read(Byte[] buffer, Int64 index, Int64 count, out Int64 actualCount, out ReadStatus readStatus) Method
```C#
void Read(Byte[] buffer, Int64 index, Int64 count, out Int64 actualCount, out ReadStatus readStatus);
```
## Read(Byte* buffer, Int64 index, Int64 count, out Int64 actualCount, out ReadStatus readStatus) Method
```C#
unsafe void Read(Byte* buffer, Int64 index, Int64 count, out Int64 actualCount, out ReadStatus readStatus);
```
## ReadString() Method
```C#
String ReadString();
```
## ReadString(Int64 count) Method
```C#
String ReadString(Int64 count);
```
## ReadString(Int64 count, out ReadStatus readStatus) Method
```C#
String ReadString(Int64 count, out ReadStatus readStatus);
```
## Write(Byte[] buffer) Method
```C#
void Write(Byte[] buffer);
```
## Write(Byte[] buffer, Int64 index, Int64 count) Method
```C#
void Write(Byte[] buffer, Int64 index, Int64 count);
```
## Write(String buffer) Method
```C#
void Write(String buffer);
```
## Write(String buffer, Int64 index, Int64 count) Method
```C#
void Write(String buffer, Int64 index, Int64 count);
```
## Write(Byte* buffer, Int64 index, Int64 count) Method
```C#
unsafe void Write(Byte* buffer, Int64 index, Int64 count);
```
## AbortAsyncOperation(IVisaAsyncResult result) Method
```C#
void AbortAsyncOperation(IVisaAsyncResult result);
```
## BeginRead(Int32 count) Method
```C#
IVisaAsyncResult BeginRead(Int32 count);
```
## BeginRead(Int32 count, Object state) Method
```C#
IVisaAsyncResult BeginRead(Int32 count, Object state);
```
## BeginRead(Int32 count, VisaAsyncCallback callback, Object state) Method
```C#
IVisaAsyncResult BeginRead(Int32 count, VisaAsyncCallback callback, Object state);
```
## BeginRead(Byte[] buffer) Method
```C#
IVisaAsyncResult BeginRead(Byte[] buffer);
```
## BeginRead(Byte[] buffer, Object state) Method
```C#
IVisaAsyncResult BeginRead(Byte[] buffer, Object state);
```
## BeginRead(Byte[] buffer, Int64 index, Int64 count) Method
```C#
IVisaAsyncResult BeginRead(Byte[] buffer, Int64 index, Int64 count);
```
## BeginRead(Byte[] buffer, Int64 index, Int64 count, Object state) Method
```C#
IVisaAsyncResult BeginRead(Byte[] buffer, Int64 index, Int64 count, Object state);
```
## BeginRead(Byte[] buffer, VisaAsyncCallback callback, Object state) Method
```C#
IVisaAsyncResult BeginRead(Byte[] buffer, VisaAsyncCallback callback, Object state);
```
## BeginRead(Byte[] buffer, Int64 index, Int64 count, VisaAsyncCallback callback, Object state) Method
```C#
IVisaAsyncResult BeginRead(Byte[] buffer, Int64 index, Int64 count, VisaAsyncCallback callback, Object state);
```
## BeginWrite(String buffer) Method
```C#
IVisaAsyncResult BeginWrite(String buffer);
```
## BeginWrite(String buffer, Object state) Method
```C#
IVisaAsyncResult BeginWrite(String buffer, Object state);
```
## BeginWrite(String buffer, VisaAsyncCallback callback, Object state) Method
```C#
IVisaAsyncResult BeginWrite(String buffer, VisaAsyncCallback callback, Object state);
```
## BeginWrite(Byte[] buffer) Method
```C#
IVisaAsyncResult BeginWrite(Byte[] buffer);
```
## BeginWrite(Byte[] buffer, Object state) Method
```C#
IVisaAsyncResult BeginWrite(Byte[] buffer, Object state);
```
## BeginWrite(Byte[] buffer, Int64 index, Int64 count) Method
```C#
IVisaAsyncResult BeginWrite(Byte[] buffer, Int64 index, Int64 count);
```
## BeginWrite(Byte[] buffer, Int64 index, Int64 count, Object state) Method
```C#
IVisaAsyncResult BeginWrite(Byte[] buffer, Int64 index, Int64 count, Object state);
```
## BeginWrite(Byte[] buffer, VisaAsyncCallback callback, Object state) Method
```C#
IVisaAsyncResult BeginWrite(Byte[] buffer, VisaAsyncCallback callback, Object state);
```
## BeginWrite(Byte[] buffer, Int64 index, Int64 count, VisaAsyncCallback callback, Object state) Method
```C#
IVisaAsyncResult BeginWrite(Byte[] buffer, Int64 index, Int64 count, VisaAsyncCallback callback, Object state);
```
## EndRead(IVisaAsyncResult result) Method
```C#
Int64 EndRead(IVisaAsyncResult result);
```
## EndReadString(IVisaAsyncResult result) Method
```C#
String EndReadString(IVisaAsyncResult result);
```
## EndWrite(IVisaAsyncResult result) Method
```C#
void EndWrite(IVisaAsyncResult result);
```
