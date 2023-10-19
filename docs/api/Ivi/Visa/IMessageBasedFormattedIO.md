English | 日本語

# IMessageBasedFormattedIO Interface

## Definition
Namespace:[Ivi.Visa](../Visa.md)<BR>
Assembly:Ivi.Visa.dll<BR>

## Properties

|Property Name|
|---|
|[BinaryEncoding](#BinaryEncoding-Property)|
|[ReadBufferSize](#ReadBufferSize-Property)|
|[WriteBufferSize](#WriteBufferSize-Property)|
|[TypeFormatter](#TypeFormatter-Property)|

## Methods

|Method Name|
|---|
|[DiscardBuffers()](#DiscardBuffers-Method)|
|[FlushWrite(Boolean sendEnd)](#FlushWriteBoolean-sendEnd-Method)|
|[Printf(String data)](#PrintfString-data-Method)|
|[Printf(String format, params object[] args)](#PrintfString-format-params-object-args-Method)|
|[PrintfAndFlush(String data)](#PrintfAndFlushString-data-Method)|
|[PrintfAndFlush(String format, params object[] args)](#PrintfAndFlushString-format-params-object-args-Method)|
|[PrintfArray(String format, Byte* pArray, params Int64[] inputs)](#PrintfArrayString-format-Byte-pArray-params-Int64-inputs-Method)|
|[PrintfArray(String format, SByte* pArray, params Int64[] inputs)](#PrintfArrayString-format-SByte-pArray-params-Int64-inputs-Method)|
|[PrintfArray(String format, Int16* pArray, params Int64[] inputs)](#PrintfArrayString-format-Int16-pArray-params-Int64-inputs-Method)|
|[PrintfArray(String format, UInt16* pArray, params Int64[] inputs)](#PrintfArrayString-format-UInt16-pArray-params-Int64-inputs-Method)|
|[PrintfArray(String format, Int32* pArray, params Int64[] inputs)](#PrintfArrayString-format-Int32-pArray-params-Int64-inputs-Method)|
|[PrintfArray(String format, UInt32* pArray, params Int64[] inputs)](#PrintfArrayString-format-UInt32-pArray-params-Int64-inputs-Method)|
|[PrintfArray(String format, Int64* pArray, params Int64[] inputs)](#PrintfArrayString-format-Int64-pArray-params-Int64-inputs-Method)|
|[PrintfArray(String format, UInt64* pArray, params Int64[] inputs)](#PrintfArrayString-format-UInt64-pArray-params-Int64-inputs-Method)|
|[PrintfArray(String format, Single* pArray, params Int64[] inputs)](#PrintfArrayString-format-Single-pArray-params-Int64-inputs-Method)|
|[PrintfArray(String format, Double* pArray, params Int64[] inputs)](#PrintfArrayString-format-Double-pArray-params-Int64-inputs-Method)|
|[PrintfArrayAndFlush(String format, Byte* pArray, params Int64[] inputs)](#PrintfArrayAndFlushString-format-Byte-pArray-params-Int64-inputs-Method)|
|[PrintfArrayAndFlush(String format, SByte* pArray, params Int64[] inputs)](#PrintfArrayAndFlushString-format-SByte-pArray-params-Int64-inputs-Method)|
|[PrintfArrayAndFlush(String format, Int16* pArray, params Int64[] inputs)](#PrintfArrayAndFlushString-format-Int16-pArray-params-Int64-inputs-Method)|
|[PrintfArrayAndFlush(String format, UInt16* pArray, params Int64[] inputs)](#PrintfArrayAndFlushString-format-UInt16-pArray-params-Int64-inputs-Method)|
|[PrintfArrayAndFlush(String format, Int32* pArray, params Int64[] inputs)](#PrintfArrayAndFlushString-format-Int32-pArray-params-Int64-inputs-Method)|
|[PrintfArrayAndFlush(String format, UInt32* pArray, params Int64[] inputs)](#PrintfArrayAndFlushString-format-UInt32-pArray-params-Int64-inputs-Method)|
|[PrintfArrayAndFlush(String format, Int64* pArray, params Int64[] inputs)](#PrintfArrayAndFlushString-format-Int64-pArray-params-Int64-inputs-Method)|
|[PrintfArrayAndFlush(String format, UInt64* pArray, params Int64[] inputs)](#PrintfArrayAndFlushString-format-UInt64-pArray-params-Int64-inputs-Method)|
|[PrintfArrayAndFlush(String format, Single* pArray, params Int64[] inputs)](#PrintfArrayAndFlushString-format-Single-pArray-params-Int64-inputs-Method)|
|[PrintfArrayAndFlush(String format, Double* pArray, params Int64[] input](#PrintfArrayAndFlushString-format-Double-pArray-params-Int64-inpu-Method)|
|[Scanf<T>(String format, out T output)](#ScanfTString-format-out-T-output-Method)|
|[Scanf<T1, T2>(String format, out T1 output1, out T2 output2)](#ScanfT1-T2String-format-out-T1-output1-out-T2-output2-Method)|
|[Scanf<T1, T2, T3>(String format, out T1 output1, out T2 output2, out T3 output3)](#ScanfT1-T2-T3String-format-out-T1-output1-out-T2-output2-out-T3-output3-Method)|
|[Scanf<T1, T2, T3, T4>(String format, out T1 output1, out T2 output2, out T3 output3, out T4 output4)](#ScanfT1-T2-T3-T4String-format-out-T1-output1-out-T2-output2-out-T3-output3-out-T4-output4-Method)|
|[Scanf<T1, T2, T3, T4, T5>(String format, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5)](#ScanfT1-T2-T3-T4-T5String-format-out-T1-output1-out-T2-output2-out-T3-output3-out-T4-output4-out-T5-output5-Method)|
|[Scanf<T1, T2, T3, T4, T5, T6>(String format, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5, out T6 output6)](#ScanfT1-T2-T3-T4-T5-T6String-format-out-T1-output1-out-T2-output2-out-T3-output3-out-T4-output4-out-T5-output5-out-T6-output6-Method)|
|[Scanf<T1, T2, T3, T4, T5, T6, T7>(String format, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5, out T6 output6, out T7 output7)](#ScanfT1-T2-T3-T4-T5-T6-T7String-format-out-T1-output1-out-T2-output2-out-T3-output3-out-T4-output4-out-T5-output5-out-T6-output6-out-T7-output7-Method)|
|[Scanf<T>(String format, Int32[] inputs, out T output)](#ScanfTString-format-Int32-inputs-out-T-output-Method)|
|[Scanf<T1, T2>(String format, Int32[] inputs, out T1 output1, out T2 output2)](#ScanfT1-T2String-format-Int32-inputs-out-T1-output1-out-T2-output2-Method)|
|[Scanf<T1, T2, T3>(String format, Int32[] inputs, out T1 output1, out T2 output2, out T3 output3)](#ScanfT1-T2-T3String-format-Int32-inputs-out-T1-output1-out-T2-output2-out-T3-output3-Method)|
|[Scanf<T1, T2, T3, T4>(String format, Int32[] inputs, out T1 output1, out T2 output2, out T3 output3, out T4 output4)](#ScanfT1-T2-T3-T4String-format-Int32-inputs-out-T1-output1-out-T2-output2-out-T3-output3-out-T4-output4-Method)|
|[Scanf<T1, T2, T3, T4, T5>(String format, Int32[] inputs, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5)](#ScanfT1-T2-T3-T4-T5String-format-Int32-inputs-out-T1-output1-out-T2-output2-out-T3-output3-out-T4-output4-out-T5-output5-Method)|
|[Scanf<T1, T2, T3, T4, T5, T6>(String format, Int32[] inputs, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5, out T6 output6)](#ScanfT1-T2-T3-T4-T5-T6String-format-Int32-inputs-out-T1-output1-out-T2-output2-out-T3-output3-out-T4-output4-out-T5-output5-out-T6-output6-Method)|
|[Scanf<T1, T2, T3, T4, T5, T6, T7>(String format, Int32[] inputs, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5, out T6 output6, out T7 output7)](#ScanfT1-T2-T3-T4-T5-T6-T7String-format-Int32-inputs-out-T1-output1-out-T2-output2-out-T3-output3-out-T4-output4-out-T5-output5-out-T6-output6-out-T7-output7-Method)|
|[ScanfArray(String format, Byte* pArray, params Int64[] inputs)](#ScanfArrayString-format-Byte-pArray-params-Int64-inputs-Method)|
|[ScanfArray(String format, SByte* pArray, params Int64[] inputs)](#ScanfArrayString-format-SByte-pArray-params-Int64-inputs-Method)|
|[ScanfArray(String format, Int16* pArray, params Int64[] inputs)](#ScanfArrayString-format-Int16-pArray-params-Int64-inputs-Method)|
|[ScanfArray(String format, UInt16* pArray, params Int64[] inputs)](#ScanfArrayString-format-UInt16-pArray-params-Int64-inputs-Method)|
|[ScanfArray(String format, Int32* pArray, params Int64[] inputs)](#ScanfArrayString-format-Int32-pArray-params-Int64-inputs-Method)|
|[ScanfArray(String format, UInt32* pArray, params Int64[] inputs)](#ScanfArrayString-format-UInt32-pArray-params-Int64-inputs-Method)|
|[ScanfArray(String format, Int64* pArray, params Int64[] inputs)](#ScanfArrayString-format-Int64-pArray-params-Int64-inputs-Method)|
|[ScanfArray(String format, UInt64* pArray, params Int64[] inputs)](#ScanfArrayString-format-UInt64-pArray-params-Int64-inputs-Method)|
|[ScanfArray(String format, Single* pArray, params Int64[] inputs)](#ScanfArrayString-format-Single-pArray-params-Int64-inputs-Method)|
|[ScanfArray(String format, Double* pArray, params Int64[] inputs)](#ScanfArrayString-format-Double-pArray-params-Int64-inputs-Method)|
|[Write(Char data)](#WriteChar-data-Method)|
|[Write(String data)](#WriteString-data-Method)|
|[Write(Int64 data)](#WriteInt64-data-Method)|
|[Write(UInt64 data)](#WriteUInt64-data-Method)|
|[Write(Double data)](#WriteDouble-data-Method)|
|[WriteLine()](#WriteLine-Method)|
|[WriteLine(Char data)](#WriteLineChar-data-Method)|
|[WriteLine(String data)](#WriteLineString-data-Method)|
|[WriteLine(Int64 data)](#WriteLineInt64-data-Method)|
|[WriteLine(UInt64 data)](#WriteLineUInt64-data-Method)|
|[WriteLine(Double data)](#WriteLineDouble-data-Method)|
|[WriteList(Byte[] data)](#WriteListByte-data-Method)|
|[WriteList(Byte[] data, Int64 index, Int64 count)](#WriteListByte-data-Int64-index-Int64-count-Method)|
|[WriteList(SByte[] data)](#WriteListSByte-data-Method)|
|[WriteList(SByte[] data, Int64 index, Int64 count)](#WriteListSByte-data-Int64-index-Int64-count-Method)|
|[WriteList(Int16[] data)](#WriteListInt16-data-Method)|
|[WriteList(Int16[] data, Int64 index, Int64 count)](#WriteListInt16-data-Int64-index-Int64-count-Method)|
|[WriteList(UInt16[] data)](#WriteListUInt16-data-Method)|
|[WriteList(UInt16[] data, Int64 index, Int64 count)](#WriteListUInt16-data-Int64-index-Int64-count-Method)|
|[WriteList(Int32[] data)](#WriteListInt32-data-Method)|
|[WriteList(Int32[] data, Int64 index, Int64 count)](#WriteListInt32-data-Int64-index-Int64-count-Method)|
|[WriteList(UInt32[] data)](#WriteListUInt32-data-Method)|
|[WriteList(UInt32[] data, Int64 index, Int64 count)](#WriteListUInt32-data-Int64-index-Int64-count-Method)|
|[WriteList(Int64[] data)](#WriteListInt64-data-Method)|
|[WriteList(Int64[] data, Int64 index, Int64 count)](#WriteListInt64-data-Int64-index-Int64-count-Method)|
|[WriteList(UInt64[] data)](#WriteListUInt64-data-Method)|
|[WriteList(UInt64[] data, Int64 index, Int64 count)](#WriteListUInt64-data-Int64-index-Int64-count-Method)|
|[WriteList(Single[] data)](#WriteListSingle-data-Method)|
|[WriteList(Single[] data, Int64 index, Int64 count)](#WriteListSingle-data-Int64-index-Int64-count-Method)|
|[WriteList(Double[] data)](#WriteListDouble-data-Method)|
|[WriteList(Double[] data, Int64 index, Int64 count)](#WriteListDouble-data-Int64-index-Int64-count-Method)|
|[WriteLineList(Byte[] data)](#WriteLineListByte-data-Method)|
|[WriteLineList(Byte[] data, Int64 index, Int64 count)](#WriteLineListByte-data-Int64-index-Int64-count-Method)|
|[WriteLineList(SByte[] data)](#WriteLineListSByte-data-Method)|
|[WriteLineList(SByte[] data, Int64 index, Int64 count)](#WriteLineListSByte-data-Int64-index-Int64-count-Method)|
|[WriteLineList(Int16[] data)](#WriteLineListInt16-data-Method)|
|[WriteLineList(Int16[] data, Int64 index, Int64 count)](#WriteLineListInt16-data-Int64-index-Int64-count-Method)|
|[WriteLineList(UInt16[] data)](#WriteLineListUInt16-data-Method)|
|[WriteLineList(UInt16[] data, Int64 index, Int64 count)](#WriteLineListUInt16-data-Int64-index-Int64-count-Method)|
|[WriteLineList(Int32[] data)](#WriteLineListInt32-data-Method)|
|[WriteLineList(Int32[] data, Int64 index, Int64 count)](#WriteLineListInt32-data-Int64-index-Int64-count-Method)|
|[WriteLineList(UInt32[] data)](#WriteLineListUInt32-data-Method)|
|[WriteLineList(UInt32[] data, Int64 index, Int64 count)](#WriteLineListUInt32-data-Int64-index-Int64-count-Method)|
|[WriteLineList(Int64[] data)](#WriteLineListInt64-data-Method)|
|[WriteLineList(Int64[] data, Int64 index, Int64 count)](#WriteLineListInt64-data-Int64-index-Int64-count-Method)|
|[WriteLineList(UInt64[] data)](#WriteLineListUInt64-data-Method)|
|[WriteLineList(UInt64[] data, Int64 index, Int64 count)](#WriteLineListUInt64-data-Int64-index-Int64-count-Method)|
|[WriteLineList(Single[] data)](#WriteLineListSingle-data-Method)|
|[WriteLineList(Single[] data, Int64 index, Int64 count)](#WriteLineListSingle-data-Int64-index-Int64-count-Method)|
|[WriteLineList(Double[] data)](#WriteLineListDouble-data-Method)|
|[WriteLineList(Double[] data, Int64 index, Int64 count)](#WriteLineListDouble-data-Int64-index-Int64-count-Method)|
|[WriteLineList(Byte[] data)](#WriteLineListByte-data-Method)|
|[WriteLineList(Byte[] data, Int64 index, Int64 count)](#WriteLineListByte-data-Int64-index-Int64-count-Method)|
|[WriteLineList(SByte[] data)](#WriteLineListSByte-data-Method)|
|[WriteLineList(SByte[] data, Int64 index, Int64 count)](#WriteLineListSByte-data-Int64-index-Int64-count-Method)|
|[WriteLineList(Int16[] data)](#WriteLineListInt16-data-Method)|
|[WriteLineList(Int16[] data, Int64 index, Int64 count)](#WriteLineListInt16-data-Int64-index-Int64-count-Method)|
|[WriteBinaryAndFlush(Byte[] data)](#WriteBinaryAndFlushByte-data-Method)|
|[WriteBinaryAndFlush(Byte[] data, Int64 index, Int64 count)](#WriteBinaryAndFlushByte-data-Int64-index-Int64-count-Method)|
|[WriteBinaryAndFlush(SByte[] data)](#WriteBinaryAndFlushSByte-data-Method)|
|[WriteBinaryAndFlush(SByte[] data, Int64 index, Int64 count)](#WriteBinaryAndFlushSByte-data-Int64-index-Int64-count-Method)|
|[WriteBinaryAndFlush(Int16[] data)](#WriteBinaryAndFlushInt16-data-Method)|
|[WriteBinaryAndFlush(Int16[] data, Int64 index, Int64 count)](#WriteBinaryAndFlushInt16-data-Int64-index-Int64-count-Method)|
|[WriteBinaryAndFlush(UInt16[] data)](#WriteBinaryAndFlushUInt16-data-Method)|
|[WriteBinaryAndFlush(UInt16[] data, Int64 index, Int64 count)](#WriteBinaryAndFlushUInt16-data-Int64-index-Int64-count-Method)|
|[WriteBinaryAndFlush(Int32[] data)](#WriteBinaryAndFlushInt32-data-Method)|
|[WriteBinaryAndFlush(Int32[] data, Int64 index, Int64 count)](#WriteBinaryAndFlushInt32-data-Int64-index-Int64-count-Method)|
|[WriteBinaryAndFlush(UInt32[] data)](#WriteBinaryAndFlushUInt32-data-Method)|
|[WriteBinaryAndFlush(UInt32[] data, Int64 index, Int64 count)](#WriteBinaryAndFlushUInt32-data-Int64-index-Int64-count-Method)|
|[WriteBinaryAndFlush(Int64[] data)](#WriteBinaryAndFlushInt64-data-Method)|
|[WriteBinaryAndFlush(Int64[] data, Int64 index, Int64 count)](#WriteBinaryAndFlushInt64-data-Int64-index-Int64-count-Method)|
|[WriteBinaryAndFlush(UInt64[] data)](#WriteBinaryAndFlushUInt64-data-Method)|
|[WriteBinaryAndFlush(UInt64[] data, Int64 index, Int64 count)](#WriteBinaryAndFlushUInt64-data-Int64-index-Int64-count-Method)|
|[WriteBinaryAndFlush(Single[] data)](#WriteBinaryAndFlushSingle-data-Method)|
|[WriteBinaryAndFlush(Single[] data, Int64 index, Int64 count)](#WriteBinaryAndFlushSingle-data-Int64-index-Int64-count-Method)|
|[WriteBinaryAndFlush(Double[] data)](#WriteBinaryAndFlushDouble-data-Method)|
|[WriteBinaryAndFlush(Double[] data, Int64 index, Int64 count)](#WriteBinaryAndFlushDouble-data-Int64-index-Int64-count-Method)|
|[ReadString()](#ReadString-Method)|
|[ReadString(Int32 count)](#ReadStringInt32-count-Method)|
|[ReadString(StringBuilder data)](#ReadStringStringBuilder-data-Method)|
|[ReadString(StringBuilder data, Int32 count)](#ReadStringStringBuilder-data-Int32-count-Method)|
|[ReadChar()](#ReadChar-Method)|
|[ReadInt64()](#ReadInt64-Method)|
|[ReadUInt64()](#ReadUInt64-Method)|
|[ReadDouble()](#ReadDouble-Method)|
|[ReadLine()](#ReadLine-Method)|
|[ReadLine(StringBuilder data)](#ReadLineStringBuilder-data-Method)|
|[ReadLineChar()](#ReadLineChar-Method)|
|[ReadLineInt64()](#ReadLineInt64-Method)|
|[ReadLineUInt64()](#ReadLineUInt64-Method)|
|[ReadLineDouble()](#ReadLineDouble-Method)|
|[ReadListOfByte(Int64 count)](#ReadListOfByteInt64-count-Method)|
|[ReadListOfByte(Byte[] data, Int64 index, Int64 count)](#ReadListOfByteByte-data-Int64-index-Int64-count-Method)|
|[ReadListOfSByte(Int64 count)](#ReadListOfSByteInt64-count-Method)|
|[ReadListOfSByte(SByte[] data, Int64 index, Int64 count)](#ReadListOfSByteSByte-data-Int64-index-Int64-count-Method)|
|[ReadListOfInt16(Int64 count)](#ReadListOfInt16Int64-count-Method)|
|[ReadListOfInt16(Int16[] data, Int64 index, Int64 count)](#ReadListOfInt16Int16-data-Int64-index-Int64-count-Method)|
|[ReadListOfUInt16(Int64 count)](#ReadListOfUInt16Int64-count-Method)|
|[ReadListOfUInt16(UInt16[] data, Int64 index, Int64 count)](#ReadListOfUInt16UInt16-data-Int64-index-Int64-count-Method)|
|[ReadListOfInt32(Int64 count)](#ReadListOfInt32Int64-count-Method)|
|[ReadListOfInt32(Int32[] data, Int64 index, Int64 count)](#ReadListOfInt32Int32-data-Int64-index-Int64-count-Method)|
|[ReadListOfUInt32(Int64 count)](#ReadListOfUInt32Int64-count-Method)|
|[ReadListOfUInt32(UInt32[] data, Int64 index, Int64 count)](#ReadListOfUInt32UInt32-data-Int64-index-Int64-count-Method)|
|[ReadListOfInt64(Int64 count)](#ReadListOfInt64Int64-count-Method)|
|[ReadListOfInt64(Int64[] data, Int64 index, Int64 count)](#ReadListOfInt64Int64-data-Int64-index-Int64-count-Method)|
|[ReadListOfUInt64(Int64 count)](#ReadListOfUInt64Int64-count-Method)|
|[ReadListOfUInt64(UInt64[] data, Int64 index, Int64 count)](#ReadListOfUInt64UInt64-data-Int64-index-Int64-count-Method)|
|[ReadListOfSingle(Int64 count)](#ReadListOfSingleInt64-count-Method)|
|[ReadListOfSingle(Single[] data, Int64 index, Int64 count)](#ReadListOfSingleSingle-data-Int64-index-Int64-count-Method)|
|[ReadListOfDouble(Int64 count)](#ReadListOfDoubleInt64-count-Method)|
|[ReadListOfDouble(Double[] data, Int64 index, Int64 count)](#ReadListOfDoubleDouble-data-Int64-index-Int64-count-Method)|
|[ReadListOfByte(Int64 count)](#ReadListOfByteInt64-count-Method)|
|[ReadListOfByte(Byte[] data, Int64 index, Int64 count)](#ReadListOfByteByte-data-Int64-index-Int64-count-Method)|
|[ReadListOfSByte(Int64 count)](#ReadListOfSByteInt64-count-Method)|
|[ReadListOfSByte(SByte[] data, Int64 index, Int64 count)](#ReadListOfSByteSByte-data-Int64-index-Int64-count-Method)|
|[ReadListOfInt16(Int64 count)](#ReadListOfInt16Int64-count-Method)|
|[ReadListOfInt16(Int16[] data, Int64 index, Int64 count)](#ReadListOfInt16Int16-data-Int64-index-Int64-count-Method)|
|[ReadListOfUInt16(Int64 count)](#ReadListOfUInt16Int64-count-Method)|
|[ReadListOfUInt16(UInt16[] data, Int64 index, Int64 count)](#ReadListOfUInt16UInt16-data-Int64-index-Int64-count-Method)|
|[ReadListOfInt32(Int64 count)](#ReadListOfInt32Int64-count-Method)|
|[ReadListOfInt32(Int32[] data, Int64 index, Int64 count)](#ReadListOfInt32Int32-data-Int64-index-Int64-count-Method)|
|[ReadListOfUInt32(Int64 count)](#ReadListOfUInt32Int64-count-Method)|
|[ReadListOfUInt32(UInt32[] data, Int64 index, Int64 count)](#ReadListOfUInt32UInt32-data-Int64-index-Int64-count-Method)|
|[ReadListOfInt64(Int64 count)](#ReadListOfInt64Int64-count-Method)|
|[ReadListOfInt64(Int64[] data, Int64 index, Int64 count)](#ReadListOfInt64Int64-data-Int64-index-Int64-count-Method)|
|[ReadListOfUInt64(Int64 count)](#ReadListOfUInt64Int64-count-Method)|
|[ReadListOfUInt64(UInt64[] data, Int64 index, Int64 count)](#ReadListOfUInt64UInt64-data-Int64-index-Int64-count-Method)|
|[ReadListOfSingle(Int64 count)](#ReadListOfSingleInt64-count-Method)|
|[ReadListOfSingle(Single[] data, Int64 index, Int64 count)](#ReadListOfSingleSingle-data-Int64-index-Int64-count-Method)|
|[ReadListOfDouble(Int64 count)](#ReadListOfDoubleInt64-count-Method)|
|[ReadListOfDouble(Double[] data, Int64 index, Int64 count)](#ReadListOfDoubleDouble-data-Int64-index-Int64-count-Method)|
|[ReadBinaryBlockOfByte()](#ReadBinaryBlockOfByte-Method)|
|[ReadBinaryBlockOfByte(Boolean seekToBlock)](#ReadBinaryBlockOfByteBoolean-seekToBlock-Method)|
|[ReadBinaryBlockOfByte(Byte[] data, Int64 index, Int64 count)](#ReadBinaryBlockOfByteByte-data-Int64-index-Int64-count-Method)|
|[ReadBinaryBlockOfByte(Byte[] data, Int64 index, Int64 count, Boolean seekToBlock)](#ReadBinaryBlockOfByteByte-data-Int64-index-Int64-count-Boolean-seekToBlock-Method)|
|[ReadBinaryBlockOfSByte()](#ReadBinaryBlockOfSByte-Method)|
|[ReadBinaryBlockOfSByte(Boolean seekToBlock)](#ReadBinaryBlockOfSByteBoolean-seekToBlock-Method)|
|[ReadBinaryBlockOfSByte(SByte[] data, Int64 index, Int64 count)](#ReadBinaryBlockOfSByteSByte-data-Int64-index-Int64-count-Method)|
|[ReadBinaryBlockOfSByte(SByte[] data, Int64 index, Int64 count, Boolean seekToBlock)](#ReadBinaryBlockOfSByteSByte-data-Int64-index-Int64-count-Boolean-seekToBlock-Method)|
|[ReadBinaryBlockOfInt16()](#ReadBinaryBlockOfInt16-Method)|
|[ReadBinaryBlockOfInt16(Boolean seekToBlock)](#ReadBinaryBlockOfInt16Boolean-seekToBlock-Method)|
|[ReadBinaryBlockOfInt16(Int16[] data, Int64 index, Int64 count)](#ReadBinaryBlockOfInt16Int16-data-Int64-index-Int64-count-Method)|
|[ReadBinaryBlockOfInt16(Int16[] data, Int64 index, Int64 count, Boolean seekToBlock)](#ReadBinaryBlockOfInt16Int16-data-Int64-index-Int64-count-Boolean-seekToBlock-Method)|
|[ReadBinaryBlockOfUInt16()](#ReadBinaryBlockOfUInt16-Method)|
|[ReadBinaryBlockOfUInt16(Boolean seekToBlock)](#ReadBinaryBlockOfUInt16Boolean-seekToBlock-Method)|
|[ReadBinaryBlockOfUInt16(UInt16[] data, Int64 index, Int64 count)](#ReadBinaryBlockOfUInt16UInt16-data-Int64-index-Int64-count-Method)|
|[ReadBinaryBlockOfUInt16(UInt16[] data, Int64 index, Int64 count, Boolean seekToBlock)](#ReadBinaryBlockOfUInt16UInt16-data-Int64-index-Int64-count-Boolean-seekToBlock-Method)|
|[ReadBinaryBlockOfInt32()](#ReadBinaryBlockOfInt32-Method)|
|[ReadBinaryBlockOfInt32(Boolean seekToBlock)](#ReadBinaryBlockOfInt32Boolean-seekToBlock-Method)|
|[ReadBinaryBlockOfInt32(Int32[] data, Int64 index, Int64 count)](#ReadBinaryBlockOfInt32Int32-data-Int64-index-Int64-count-Method)|
|[ReadBinaryBlockOfInt32(Int32[] data, Int64 index, Int64 count, Boolean seekToBlock)](#ReadBinaryBlockOfInt32Int32-data-Int64-index-Int64-count-Boolean-seekToBlock-Method)|
|[ReadBinaryBlockOfUInt32()](#ReadBinaryBlockOfUInt32-Method)|
|[ReadBinaryBlockOfUInt32(Boolean seekToBlock)](#ReadBinaryBlockOfUInt32Boolean-seekToBlock-Method)|
|[ReadBinaryBlockOfUInt32(UInt32[] data, Int64 index, Int64 count)](#ReadBinaryBlockOfUInt32UInt32-data-Int64-index-Int64-count-Method)|
|[ReadBinaryBlockOfUInt32(UInt32[] data, Int64 index, Int64 count, Boolean seekToBlock)](#ReadBinaryBlockOfUInt32UInt32-data-Int64-index-Int64-count-Boolean-seekToBlock-Method)|
|[ReadBinaryBlockOfInt64()](#ReadBinaryBlockOfInt64-Method)|
|[ReadBinaryBlockOfInt64(Int64[] data, Int64 index, Int64 count)](#ReadBinaryBlockOfInt64Int64-data-Int64-index-Int64-count-Method)|
|[ReadBinaryBlockOfUInt64()](#ReadBinaryBlockOfUInt64-Method)|
|[ReadBinaryBlockOfUInt64(UInt64[] data, Int64 index, Int64 count)](#ReadBinaryBlockOfUInt64UInt64-data-Int64-index-Int64-count-Method)|
|[ReadBinaryBlockOfSingle()](#ReadBinaryBlockOfSingle-Method)|
|[ReadBinaryBlockOfSingle(Boolean seekToBlock)](#ReadBinaryBlockOfSingleBoolean-seekToBlock-Method)|
|[ReadBinaryBlockOfSingle(Single[] data, Int64 index, Int64 count)](#ReadBinaryBlockOfSingleSingle-data-Int64-index-Int64-count-Method)|
|[ReadBinaryBlockOfSingle(Single[] data, Int64 index, Int64 count, Boolean seekToBlock)](#ReadBinaryBlockOfSingleSingle-data-Int64-index-Int64-count-Boolean-seekToBlock-Method)|
|[ReadBinaryBlockOfDouble()](#ReadBinaryBlockOfDouble-Method)|
|[ReadBinaryBlockOfDouble(Boolean seekToBlock)](#ReadBinaryBlockOfDoubleBoolean-seekToBlock-Method)|
|[ReadBinaryBlockOfDouble(Double[] data, Int64 index, Int64 count)](#ReadBinaryBlockOfDoubleDouble-data-Int64-index-Int64-count-Method)|
|[ReadBinaryBlockOfDouble(Double[] data, Int64 index, Int64 count, Boolean seekToBlock)](#ReadBinaryBlockOfDoubleDouble-data-Int64-index-Int64-count-Boolean-seekToBlock-Method)|
|[ReadLineBinaryBlockOfByte()](#ReadLineBinaryBlockOfByte-Method)|
|[ReadLineBinaryBlockOfByte(Boolean seekToBlock)](#ReadLineBinaryBlockOfByteBoolean-seekToBlock-Method)|
|[ReadLineBinaryBlockOfByte(Byte[] data, Int64 index, Int64 count)](#ReadLineBinaryBlockOfByteByte-data-Int64-index-Int64-count-Method)|
|[ReadLineBinaryBlockOfByte(Byte[] data, Int64 index, Int64 count, Boolean seekToBlock)](#ReadLineBinaryBlockOfByteByte-data-Int64-index-Int64-count-Boolean-seekToBlock-Method)|
|[ReadLineBinaryBlockOfSByte()](#ReadLineBinaryBlockOfSByte-Method)|
|[ReadLineBinaryBlockOfSByte(Boolean seekToBlock)](#ReadLineBinaryBlockOfSByteBoolean-seekToBlock-Method)|
|[ReadLineBinaryBlockOfSByte(SByte[] data, Int64 index, Int64 count)](#ReadLineBinaryBlockOfSByteSByte-data-Int64-index-Int64-count-Method)|
|[ReadLineBinaryBlockOfSByte(SByte[] data, Int64 index, Int64 count, Boolean seekToBlock)](#ReadLineBinaryBlockOfSByteSByte-data-Int64-index-Int64-count-Boolean-seekToBlock-Method)|
|[ReadLineBinaryBlockOfInt16()](#ReadLineBinaryBlockOfInt16-Method)|
|[ReadLineBinaryBlockOfInt16(Boolean seekToBlock)](#ReadLineBinaryBlockOfInt16Boolean-seekToBlock-Method)|
|[ReadLineBinaryBlockOfInt16(Int16[] data, Int64 index, Int64 count)](#ReadLineBinaryBlockOfInt16Int16-data-Int64-index-Int64-count-Method)|
|[ReadLineBinaryBlockOfInt16(Int16[] data, Int64 index, Int64 count, Boolean seekToBlock)](#ReadLineBinaryBlockOfInt16Int16-data-Int64-index-Int64-count-Boolean-seekToBlock-Method)|
|[ReadLineBinaryBlockOfUInt16()](#ReadLineBinaryBlockOfUInt16-Method)|
|[ReadLineBinaryBlockOfUInt16(Boolean seekToBlock)](#ReadLineBinaryBlockOfUInt16Boolean-seekToBlock-Method)|
|[ReadLineBinaryBlockOfUInt16(UInt16[] data, Int64 index, Int64 count)](#ReadLineBinaryBlockOfUInt16UInt16-data-Int64-index-Int64-count-Method)|
|[ReadLineBinaryBlockOfUInt16(UInt16[] data, Int64 index, Int64 count, Boolean seekToBlock)](#ReadLineBinaryBlockOfUInt16UInt16-data-Int64-index-Int64-count-Boolean-seekToBlock-Method)|
|[ReadLineBinaryBlockOfInt32()](#ReadLineBinaryBlockOfInt32-Method)|
|[ReadLineBinaryBlockOfInt32(Boolean seekToBlock)](#ReadLineBinaryBlockOfInt32Boolean-seekToBlock-Method)|
|[ReadLineBinaryBlockOfInt32(Int32[] data, Int64 index, Int64 count)](#ReadLineBinaryBlockOfInt32Int32-data-Int64-index-Int64-count-Method)|
|[ReadLineBinaryBlockOfInt32(Int32[] data, Int64 index, Int64 count, Boolean seekToBlock)](#ReadLineBinaryBlockOfInt32Int32-data-Int64-index-Int64-count-Boolean-seekToBlock-Method)|
|[ReadLineBinaryBlockOfUInt32()](#ReadLineBinaryBlockOfUInt32-Method)|
|[ReadLineBinaryBlockOfUInt32(Boolean seekToBlock)](#ReadLineBinaryBlockOfUInt32Boolean-seekToBlock-Method)|
|[ReadLineBinaryBlockOfUInt32(UInt32[] data, Int64 index, Int64 count)](#ReadLineBinaryBlockOfUInt32UInt32-data-Int64-index-Int64-count-Method)|
|[ReadLineBinaryBlockOfUInt32(UInt32[] data, Int64 index, Int64 count, Boolean seekToBlock)](#ReadLineBinaryBlockOfUInt32UInt32-data-Int64-index-Int64-count-Boolean-seekToBlock-Method)|
|[ReadLineBinaryBlockOfInt64()](#ReadLineBinaryBlockOfInt64-Method)|
|[ReadLineBinaryBlockOfInt64(Int64[] data, Int64 index, Int64 count)](#ReadLineBinaryBlockOfInt64Int64-data-Int64-index-Int64-count-Method)|
|[ReadLineBinaryBlockOfUInt64()](#ReadLineBinaryBlockOfUInt64-Method)|
|[ReadLineBinaryBlockOfUInt64(UInt64[] data, Int64 index, Int64 count)](#ReadLineBinaryBlockOfUInt64UInt64-data-Int64-index-Int64-count-Method)|
|[ReadLineBinaryBlockOfSingle()](#ReadLineBinaryBlockOfSingle-Method)|
|[ReadLineBinaryBlockOfSingle(Boolean seekToBlock)](#ReadLineBinaryBlockOfSingleBoolean-seekToBlock-Method)|
|[ReadLineBinaryBlockOfSingle(Single[] data, Int64 index, Int64 count)](#ReadLineBinaryBlockOfSingleSingle-data-Int64-index-Int64-count-Method)|
|[ReadLineBinaryBlockOfSingle(Single[] data, Int64 index, Int64 count, Boolean seekToBlock)](#ReadLineBinaryBlockOfSingleSingle-data-Int64-index-Int64-count-Boolean-seekToBlock-Method)|
|[ReadLineBinaryBlockOfDouble()](#ReadLineBinaryBlockOfDouble-Method)|
|[ReadLineBinaryBlockOfDouble(Boolean seekToBlock)](#ReadLineBinaryBlockOfDoubleBoolean-seekToBlock-Method)|
|[ReadLineBinaryBlockOfDouble(Double[] data, Int64 index, Int64 count)](#ReadLineBinaryBlockOfDoubleDouble-data-Int64-index-Int64-count-Method)|
|[ReadLineBinaryBlockOfDouble(Double[] data, Int64 index, Int64 count, Boolean seekToBlock)](#ReadLineBinaryBlockOfDoubleDouble-data-Int64-index-Int64-count-Boolean-seekToBlock-Method)|
|[ReadWhileMatch(String characters)](#ReadWhileMatchString-characters-Method)|
|[ReadUntilMatch(Char ch)](#ReadUntilMatchChar-ch-Method)|
|[ReadUntilMatch(String characters, Boolean discardMatch)](#ReadUntilMatchString-characters-Boolean-discardMatch-Method)|
|[ReadUntilEnd()](#ReadUntilEnd-Method)|
|[Skip(Int64 count)](#SkipInt64-count-Method)|
|[SkipString(String data)](#SkipString-String-data-Method)|
|[SkipUntilEnd()](#SkipUntilEnd-Method)|

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
