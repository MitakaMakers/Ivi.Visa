using System.Text;

namespace Ivi.Visa
{
    public interface IMessageBasedSession : IVisaSession
    {
        event EventHandler<VisaEventArgs> ServiceRequest;
        IOProtocol IOProtocol { get; set; }
        Boolean SendEndEnabled { get; set; }
        Byte TerminationCharacter { get; set; }
        Boolean TerminationCharacterEnabled { get; set; }
        void AssertTrigger();
        void Clear();
        StatusByteFlags ReadStatusByte();
        IMessageBasedFormattedIO FormattedIO { get; }
        IMessageBasedRawIO RawIO { get; }
    }
    public interface IMessageBasedFormattedIO
    {
        public BinaryEncoding BinaryEncoding_ { get; set; }
        public Int32 ReadBufferSize { get; set; }
        public Int32 WriteBufferSize { get; set; }
        public ITypeFormatter TypeFormatter { get; set; }
        public void DiscardBuffers();
        public void FlushWrite(Boolean sendEnd);
        public void Printf(String data);
        public void Printf(String format, params object[] args);
        public void PrintfAndFlush(String data);
        public void PrintfAndFlush(String format, params object[] args);
        // public unsafe void PrintfArray(String format, Byte* pArray, params Int64[] inputs);
        // public unsafe void PrintfArray(String format, SByte* pArray, params Int64[] inputs);
        // public unsafe void PrintfArray(String format, Int16* pArray, params Int64[] inputs);
        // public unsafe void PrintfArray(String format, UInt16* pArray, params Int64[] inputs);
        // public unsafe void PrintfArray(String format, Int32* pArray, params Int64[] inputs);
        // public unsafe void PrintfArray(String format, UInt32* pArray, params Int64[] inputs);
        // public unsafe void PrintfArray(String format, Int64* pArray, params Int64[] inputs);
        // public unsafe void PrintfArray(String format, UInt64* pArray, params Int64[] inputs);
        // public unsafe void PrintfArray(String format, Single* pArray, params Int64[] inputs);
        // public unsafe void PrintfArray(String format, Double* pArray, params Int64[] inputs);
        // public unsafe void PrintfArrayAndFlush(String format, Byte* pArray, params Int64[] inputs);
        // public unsafe void PrintfArrayAndFlush(String format, SByte* pArray, params Int64[] inputs);
        // public unsafe void PrintfArrayAndFlush(String format, Int16* pArray, params Int64[] inputs);
        // public unsafe void PrintfArrayAndFlush(String format, UInt16* pArray, params Int64[] inputs);
        // public unsafe void PrintfArrayAndFlush(String format, Int32* pArray, params Int64[] inputs);
        // public unsafe void PrintfArrayAndFlush(String format, UInt32* pArray, params Int64[] inputs);
        // public unsafe void PrintfArrayAndFlush(String format, Int64* pArray, params Int64[] inputs);
        // public unsafe void PrintfArrayAndFlush(String format, UInt64* pArray, params Int64[] inputs);
        // public unsafe void PrintfArrayAndFlush(String format, Single* pArray, params Int64[] inputs);
        // public unsafe void PrintfArrayAndFlush(String format, Double* pArray, params Int64[] inputs
        public void Scanf<T>(String format, out T output);
        public void Scanf<T1, T2>(String format, out T1 output1, out T2 output2);
        public void Scanf<T1, T2, T3>(String format, out T1 output1, out T2 output2, out T3 output3);
        public void Scanf<T1, T2, T3, T4>(String format, out T1 output1, out T2 output2, out T3 output3, out T4 output4);
        public void Scanf<T1, T2, T3, T4, T5>(String format, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5);
        public void Scanf<T1, T2, T3, T4, T5, T6>(String format, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5, out T6 output6);
        public void Scanf<T1, T2, T3, T4, T5, T6, T7>(String format, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5, out T6 output6, out T7 output7);
        public void Scanf<T>(String format, Int32[] inputs, out T output);
        public void Scanf<T1, T2>(String format, Int32[] inputs, out T1 output1, out T2 output2);
        public void Scanf<T1, T2, T3>(String format, Int32[] inputs, out T1 output1, out T2 output2, out T3 output3);
        public void Scanf<T1, T2, T3, T4>(String format, Int32[] inputs, out T1 output1, out T2 output2, out T3 output3, out T4 output4);
        public void Scanf<T1, T2, T3, T4, T5>(String format, Int32[] inputs, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5);
        public void Scanf<T1, T2, T3, T4, T5, T6>(String format, Int32[] inputs, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5, out T6 output6);
        public void Scanf<T1, T2, T3, T4, T5, T6, T7>(String format, Int32[] inputs, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5, out T6 output6, out T7 output7);
        // public unsafe Int64 ScanfArray(String format, Byte* pArray, params Int64[] inputs);
        // public unsafe Int64 ScanfArray(String format, SByte* pArray, params Int64[] inputs);
        // public unsafe Int64 ScanfArray(String format, Int16* pArray, params Int64[] inputs);
        // public unsafe Int64 ScanfArray(String format, UInt16* pArray, params Int64[] inputs);
        // public unsafe Int64 ScanfArray(String format, Int32* pArray, params Int64[] inputs);
        // public unsafe Int64 ScanfArray(String format, UInt32* pArray, params Int64[] inputs);
        // public unsafe Int64 ScanfArray(String format, Int64* pArray, params Int64[] inputs);
        // public unsafe Int64 ScanfArray(String format, UInt64* pArray, params Int64[] inputs);
        // public unsafe Int64 ScanfArray(String format, Single* pArray, params Int64[] inputs);
        // public unsafe Int64 ScanfArray(String format, Double* pArray, params Int64[] inputs);
        public void Write(Char data);
        public void Write(String data);
        public void Write(Int64 data);
        public void Write(UInt64 data);
        public void Write(Double data);
        public void WriteLine();
        public void WriteLine(Char data);
        public void WriteLine(String data);
        public void WriteLine(Int64 data);
        public void WriteLine(UInt64 data);
        public void WriteLine(Double data);
        public void WriteList(Byte[] data);
        public void WriteList(Byte[] data, Int64 index, Int64 count);
        public void WriteList(SByte[] data);
        public void WriteList(SByte[] data, Int64 index, Int64 count);
        public void WriteList(Int16[] data);
        public void WriteList(Int16[] data, Int64 index, Int64 count);
        // [CLSCompliant(false)]
        public void WriteList(UInt16[] data);
        // [CLSCompliant(false)]
        public void WriteList(UInt16[] data, Int64 index, Int64 count);
        public void WriteList(Int32[] data);
        public void WriteList(Int32[] data, Int64 index, Int64 count);
        // [CLSCompliant(false)]
        public void WriteList(UInt32[] data);
        // [CLSCompliant(false)]
        public void WriteList(UInt32[] data, Int64 index, Int64 count);
        public void WriteList(Int64[] data);
        public void WriteList(Int64[] data, Int64 index, Int64 count);
        // [CLSCompliant(false)]
        public void WriteList(UInt64[] data);
        // [CLSCompliant(false)]
        public void WriteList(UInt64[] data, Int64 index, Int64 count);
        public void WriteList(Single[] data);

        public void WriteList(Single[] data, Int64 index, Int64 count);
        public void WriteList(Double[] data);
        public void WriteList(Double[] data, Int64 index, Int64 count);
        public void WriteLineList(Byte[] data);
        public void WriteLineList(Byte[] data, Int64 index, Int64 count);
        public void WriteLineList(SByte[] data);
        public void WriteLineList(SByte[] data, Int64 index, Int64 count);
        public void WriteLineList(Int16[] data);
        public void WriteLineList(Int16[] data, Int64 index, Int64 count);
        // [CLSCompliant(false)]
        public void WriteLineList(UInt16[] data);
        // [CLSCompliant(false)]
        public void WriteLineList(UInt16[] data, Int64 index, Int64 count);
        public void WriteLineList(Int32[] data);
        public void WriteLineList(Int32[] data, Int64 index, Int64 count);
        // [CLSCompliant(false)]
        public void WriteLineList(UInt32[] data);
        // [CLSCompliant(false)]
        public void WriteLineList(UInt32[] data, Int64 index, Int64 count);
        public void WriteLineList(Int64[] data);
        public void WriteLineList(Int64[] data, Int64 index, Int64 count);
        // [CLSCompliant(false)]
        public void WriteLineList(UInt64[] data);
        // [CLSCompliant(false)]
        public void WriteLineList(UInt64[] data, Int64 index, Int64 count);
        public void WriteLineList(Single[] data);
        public void WriteLineList(Single[] data, Int64 index, Int64 count);
        public void WriteLineList(Double[] data);
        public void WriteLineList(Double[] data, Int64 index, Int64 count);
        public void WriteBinary(Byte[] data);
        public void WriteBinary(Byte[] data, Int64 index, Int64 count);
        public void WriteBinary(SByte[] data);
        public void WriteBinary(SByte[] data, Int64 index, Int64 count);
        public void WriteBinary(Int16[] data);
        public void WriteBinary(Int16[] data, Int64 index, Int64 count);
        // [CLSCompliant(false)]
        public void WriteBinary(UInt16[] data);
        // [CLSCompliant(false)]
        public void WriteBinary(UInt16[] data, Int64 index, Int64 count);
        public void WriteBinary(Int32[] data);
        public void WriteBinary(Int32[] data, Int64 index, Int64 count);
        // [CLSCompliant(false)]
        public void WriteBinary(UInt32[] data);
        // [CLSCompliant(false)]
        public void WriteBinary(UInt32[] data, Int64 index, Int64 count);
        public void WriteBinary(Int64[] data);
        public void WriteBinary(Int64[] data, Int64 index, Int64 count);
        // [CLSCompliant(false)]
        public void WriteBinary(UInt64[] data);
        // [CLSCompliant(false)]
        public void WriteBinary(UInt64[] data, Int64 index, Int64 count);
        public void WriteBinary(Single[] data);
        public void WriteBinary(Single[] data, Int64 index, Int64 count);
        public void WriteBinary(Double[] data);
        public void WriteBinary(Double[] data, Int64 index, Int64 count);
        public void WriteBinaryAndFlush(Byte[] data);
        public void WriteBinaryAndFlush(Byte[] data, Int64 index, Int64 count);
        public void WriteBinaryAndFlush(SByte[] data);
        public void WriteBinaryAndFlush(SByte[] data, Int64 index, Int64 count);
        public void WriteBinaryAndFlush(Int16[] data);
        public void WriteBinaryAndFlush(Int16[] data, Int64 index, Int64 count);
        // [CLSCompliant(false)]
        public void WriteBinaryAndFlush(UInt16[] data);
        // [CLSCompliant(false)]
        public void WriteBinaryAndFlush(UInt16[] data, Int64 index, Int64 count);
        public void WriteBinaryAndFlush(Int32[] data);
        public void WriteBinaryAndFlush(Int32[] data, Int64 index, Int64 count);
        // [CLSCompliant(false)]
        public void WriteBinaryAndFlush(UInt32[] data);
        // [CLSCompliant(false)]
        public void WriteBinaryAndFlush(UInt32[] data, Int64 index, Int64 count);
        public void WriteBinaryAndFlush(Int64[] data);
        public void WriteBinaryAndFlush(Int64[] data, Int64 index, Int64 count);
        // [CLSCompliant(false)]
        public void WriteBinaryAndFlush(UInt64[] data);
        // [CLSCompliant(false)]
        public void WriteBinaryAndFlush(UInt64[] data, Int64 index, Int64 count);
        public void WriteBinaryAndFlush(Single[] data);
        public void WriteBinaryAndFlush(Single[] data, Int64 index, Int64 count);
        public void WriteBinaryAndFlush(Double[] data);
        public void WriteBinaryAndFlush(Double[] data, Int64 index, Int64 count);
        public String ReadString();
        public String ReadString(Int32 count);
        public Int32 ReadString(StringBuilder data);
        public Int32 ReadString(StringBuilder data, Int32 count);
        public Char ReadChar();
        public Int64 ReadInt64();
        public UInt64 ReadUInt64();
        public Double ReadDouble();
        public String ReadLine();
        public Int32 ReadLine(StringBuilder data);
        public Char ReadLineChar();
        public Int64 ReadLineInt64();
        public UInt64 ReadLineUInt64();
        public Double ReadLineDouble();
        public Byte[] ReadListOfByte(Int64 count);
        public Int64 ReadListOfByte(Byte[] data, Int64 index, Int64 count);
        public SByte[] ReadListOfSByte(Int64 count);
        public Int64 ReadListOfSByte(SByte[] data, Int64 index, Int64 count);
        public Int16[] ReadListOfInt16(Int64 count);
        public Int64 ReadListOfInt16(Int16[] data, Int64 index, Int64 count);
        public UInt16[] ReadListOfUInt16(Int64 count);
        public Int64 ReadListOfUInt16(UInt16[] data, Int64 index, Int64 count);
        public Int32[] ReadListOfInt32(Int64 count);
        public Int64 ReadListOfInt32(Int32[] data, Int64 index, Int64 count);
        public UInt32[] ReadListOfUInt32(Int64 count);
        public Int64 ReadListOfUInt32(UInt32[] data, Int64 index, Int64 count);
        public Int64[] ReadListOfInt64(Int64 count);
        public Int64 ReadListOfInt64(Int64[] data, Int64 index, Int64 count);
        public UInt64[] ReadListOfUInt64(Int64 count);
        public Int64 ReadListOfUInt64(UInt64[] data, Int64 index, Int64 count);
        public Single[] ReadListOfSingle(Int64 count);
        public Int64 ReadListOfSingle(Single[] data, Int64 index, Int64 count);
        public Double[] ReadListOfDouble(Int64 count);
        public Int64 ReadListOfDouble(Double[] data, Int64 index, Int64 count);
        public Byte[] ReadLineListOfByte();
        public Int64 ReadLineListOfByte(Byte[] data, Int64 index);
        public SByte[] ReadLineListOfSByte();
        public Int64 ReadLineListOfSByte(SByte[] data, Int64 index);
        public Int16[] ReadLineListOfInt16();
        public Int64 ReadLineListOfInt16(Int16[] data, Int64 index);
        public UInt16[] ReadLineListOfUInt16();
        public Int64 ReadLineListOfUInt16(UInt16[] data, Int64 index);
        public Int32[] ReadLineListOfInt32();
        public Int64 ReadLineListOfInt32(Int32[] data, Int64 index);
        public UInt32[] ReadLineListOfUInt32();
        public Int64 ReadLineListOfUInt32(UInt32[] data, Int64 index);
        public Int64[] ReadLineListOfInt64();
        public Int64 ReadLineListOfInt64(Int64[] data, Int64 index);
        public UInt64[] ReadLineListOfUInt64();
        public Int64 ReadLineListOfUInt64(UInt64[] data, Int64 index);
        public Single[] ReadLineListOfSingle();
        public Int64 ReadLineListOfSingle(Single[] data, Int64 index);
        public Double[] ReadLineListOfDouble();
        public Int64 ReadLineListOfDouble(Double[] data, Int64 index);
        public Byte[] ReadBinaryBlockOfByte();
        public Byte[] ReadBinaryBlockOfByte(Boolean seekToBlock);
        public Int64 ReadBinaryBlockOfByte(Byte[] data, Int64 index, Int64 count);
        public Int64 ReadBinaryBlockOfByte(Byte[] data, Int64 index, Int64 count, Boolean seekToBlock);
        public SByte[] ReadBinaryBlockOfSByte();
        public SByte[] ReadBinaryBlockOfSByte(Boolean seekToBlock);
        public Int64 ReadBinaryBlockOfSByte(SByte[] data, Int64 index, Int64 count);
        public Int64 ReadBinaryBlockOfSByte(SByte[] data, Int64 index, Int64 count, Boolean seekToBlock);
        public Int16[] ReadBinaryBlockOfInt16();
        public Int16[] ReadBinaryBlockOfInt16(Boolean seekToBlock);
        public Int64 ReadBinaryBlockOfInt16(Int16[] data, Int64 index, Int64 count);
        public Int64 ReadBinaryBlockOfInt16(Int16[] data, Int64 index, Int64 count, Boolean seekToBlock);
        public UInt16[] ReadBinaryBlockOfUInt16();
        public UInt16[] ReadBinaryBlockOfUInt16(Boolean seekToBlock);
        public Int64 ReadBinaryBlockOfUInt16(UInt16[] data, Int64 index, Int64 count);
        public Int64 ReadBinaryBlockOfUInt16(UInt16[] data, Int64 index, Int64 count, Boolean seekToBlock);
        public Int32[] ReadBinaryBlockOfInt32();
        public Int32[] ReadBinaryBlockOfInt32(Boolean seekToBlock);
        public Int64 ReadBinaryBlockOfInt32(Int32[] data, Int64 index, Int64 count);
        public Int64 ReadBinaryBlockOfInt32(Int32[] data, Int64 index, Int64 count, Boolean seekToBlock);
        public UInt32[] ReadBinaryBlockOfUInt32();
        public UInt32[] ReadBinaryBlockOfUInt32(Boolean seekToBlock);
        public Int64 ReadBinaryBlockOfUInt32(UInt32[] data, Int64 index, Int64 count);
        public Int64 ReadBinaryBlockOfUInt32(UInt32[] data, Int64 index, Int64 count, Boolean seekToBlock);
        public Int64[] ReadBinaryBlockOfInt64();
        public Int64 ReadBinaryBlockOfInt64(Int64[] data, Int64 index, Int64 count);
        public UInt64[] ReadBinaryBlockOfUInt64();
        public Int64 ReadBinaryBlockOfUInt64(UInt64[] data, Int64 index, Int64 count);
        public Single[] ReadBinaryBlockOfSingle();
        public Single[] ReadBinaryBlockOfSingle(Boolean seekToBlock);
        public Int64 ReadBinaryBlockOfSingle(Single[] data, Int64 index, Int64 count);
        public Int64 ReadBinaryBlockOfSingle(Single[] data, Int64 index, Int64 count, Boolean seekToBlock);
        public Double[] ReadBinaryBlockOfDouble();
        public Double[] ReadBinaryBlockOfDouble(Boolean seekToBlock);
        public Int64 ReadBinaryBlockOfDouble(Double[] data, Int64 index, Int64 count);
        public Int64 ReadBinaryBlockOfDouble(Double[] data, Int64 index, Int64 count, Boolean seekToBlock);
        public Byte[] ReadLineBinaryBlockOfByte();
        public Byte[] ReadLineBinaryBlockOfByte(Boolean seekToBlock);
        public Int64 ReadLineBinaryBlockOfByte(Byte[] data, Int64 index, Int64 count);
        public Int64 ReadLineBinaryBlockOfByte(Byte[] data, Int64 index, Int64 count, Boolean seekToBlock);
        public SByte[] ReadLineBinaryBlockOfSByte();
        public SByte[] ReadLineBinaryBlockOfSByte(Boolean seekToBlock);
        public Int64 ReadLineBinaryBlockOfSByte(SByte[] data, Int64 index, Int64 count);
        public Int64 ReadLineBinaryBlockOfSByte(SByte[] data, Int64 index, Int64 count, Boolean seekToBlock);
        public Int16[] ReadLineBinaryBlockOfInt16();
        public Int16[] ReadLineBinaryBlockOfInt16(Boolean seekToBlock);
        public Int64 ReadLineBinaryBlockOfInt16(Int16[] data, Int64 index, Int64 count);
        public Int64 ReadLineBinaryBlockOfInt16(Int16[] data, Int64 index, Int64 count, Boolean seekToBlock);
        public UInt16[] ReadLineBinaryBlockOfUInt16();
        public UInt16[] ReadLineBinaryBlockOfUInt16(Boolean seekToBlock);
        public Int64 ReadLineBinaryBlockOfUInt16(UInt16[] data, Int64 index, Int64 coun);
        public Int64 ReadLineBinaryBlockOfUInt16(UInt16[] data, Int64 index, Int64 count, Boolean seekToBlock);
        public Int32[] ReadLineBinaryBlockOfInt32();
        public Int32[] ReadLineBinaryBlockOfInt32(Boolean seekToBlock);
        public Int64 ReadLineBinaryBlockOfInt32(Int32[] data, Int64 index, Int64 count);
        public Int64 ReadLineBinaryBlockOfInt32(Int32[] data, Int64 index, Int64 count, Boolean seekToBlock);
        public UInt32[] ReadLineBinaryBlockOfUInt32();
        public UInt32[] ReadLineBinaryBlockOfUInt32(Boolean seekToBlock);
        public Int64 ReadLineBinaryBlockOfUInt32(UInt32[] data, Int64 index, Int64 count);
        public Int64 ReadLineBinaryBlockOfUInt32(UInt32[] data, Int64 index, Int64 count, Boolean seekToBlock);
        public Int64[] ReadLineBinaryBlockOfInt64();
        public Int64 ReadLineBinaryBlockOfInt64(Int64[] data, Int64 index, Int64 count);
        public UInt64[] ReadLineBinaryBlockOfUInt64();
        public Int64 ReadLineBinaryBlockOfUInt64(UInt64[] data, Int64 index, Int64 count);
        public Single[] ReadLineBinaryBlockOfSingle();
        public Single[] ReadLineBinaryBlockOfSingle(Boolean seekToBlock);
        public Int64 ReadLineBinaryBlockOfSingle(Single[] data, Int64 index, Int64 count);
        public Int64 ReadLineBinaryBlockOfSingle(Single[] data, Int64 index, Int64 count, Boolean seekToBlock);
        public Double[] ReadLineBinaryBlockOfDouble();
        public Double[] ReadLineBinaryBlockOfDouble(Boolean seekToBlock);
        public Int64 ReadLineBinaryBlockOfDouble(Double[] data, Int64 index, Int64 count);
        public Int64 ReadLineBinaryBlockOfDouble(Double[] data, Int64 index, Int64 count, Boolean seekToBlock);
        public String ReadWhileMatch(String characters);
        public String ReadUntilMatch(Char ch);
        public String ReadUntilMatch(String characters, Boolean discardMatch);
        public String ReadUntilEnd();
        public void Skip(Int64 count);
        public void SkipString(String data);
        public void SkipUntilEnd();
    }
    public interface IMessageBasedRawIO
    {
        Byte[] Read();
        Byte[] Read(Int64 count);
        Byte[] Read(Int64 count, out ReadStatus readStatus);
        void Read(Byte[] buffer, Int64 index, Int64 count, out Int64 actualCount, out ReadStatus readStatus);
        // unsafe void Read(Byte* buffer, Int64 index, Int64 count, out Int64 actualCount, out ReadStatus readStatus);
        String ReadString();
        String ReadString(Int64 count);
        String ReadString(Int64 count, out ReadStatus readStatus);
        void Write(Byte[] buffer);
        void Write(Byte[] buffer, Int64 index, Int64 count);
        void Write(String buffer);
        void Write(String buffer, Int64 index, Int64 count);
        // unsafe void Write(Byte* buffer, Int64 index, Int64 count);
        void AbortAsyncOperation(IVisaAsyncResult result);
        IVisaAsyncResult BeginRead(Int32 count);
        IVisaAsyncResult BeginRead(Int32 count, Object state);
        IVisaAsyncResult BeginRead(Int32 count, VisaAsyncCallback callback, Object state);
        IVisaAsyncResult BeginRead(Byte[] buffer);
        IVisaAsyncResult BeginRead(Byte[] buffer, Object state);
        IVisaAsyncResult BeginRead(Byte[] buffer, Int64 index, Int64 count);
        IVisaAsyncResult BeginRead(Byte[] buffer, Int64 index, Int64 count, Object state);
        IVisaAsyncResult BeginRead(Byte[] buffer, VisaAsyncCallback callback, Object state);
        IVisaAsyncResult BeginRead(Byte[] buffer, Int64 index, Int64 count, VisaAsyncCallback callback, Object state);
        IVisaAsyncResult BeginWrite(String buffer);
        IVisaAsyncResult BeginWrite(String buffer, Object state);
        IVisaAsyncResult BeginWrite(String buffer, VisaAsyncCallback callback, Object state);
        IVisaAsyncResult BeginWrite(Byte[] buffer);
        IVisaAsyncResult BeginWrite(Byte[] buffer, Object state);
        IVisaAsyncResult BeginWrite(Byte[] buffer, Int64 index, Int64 count);
        IVisaAsyncResult BeginWrite(Byte[] buffer, Int64 index, Int64 count, Object state);
        IVisaAsyncResult BeginWrite(Byte[] buffer, VisaAsyncCallback callback, Object state);
        IVisaAsyncResult BeginWrite(Byte[] buffer, Int64 index, Int64 count, VisaAsyncCallback callback, Object state);
        Int64 EndRead(IVisaAsyncResult result);
        String EndReadString(IVisaAsyncResult result);
        void EndWrite(IVisaAsyncResult result);
    }
}