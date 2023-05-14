using System.Text;

namespace Ivi.Visa
{
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
    public class Vxi11FormattedIO488 : IMessageBasedFormattedIO
    {
        private Vxi11Session sesn;
        public IMessage IO = new IMessage();

        public BinaryEncoding BinaryEncoding_ { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int ReadBufferSize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int WriteBufferSize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ITypeFormatter TypeFormatter { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Vxi11FormattedIO488(Vxi11Session sesn)
        {
            this.sesn = sesn;
        }
        public void WriteLine(string msg)
        {
            throw new NotImplementedException();
        }
        public void WriteString(string str) { }

        public string ReadLine()
        {
            throw new NotImplementedException();
        }
        public string ReadString()
        {
            throw new NotImplementedException();
        }

        public void DiscardBuffers()
        {
            throw new NotImplementedException();
        }

        public void FlushWrite(bool sendEnd)
        {
            throw new NotImplementedException();
        }

        public void Printf(string data)
        {
            throw new NotImplementedException();
        }

        public void Printf(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void PrintfAndFlush(string data)
        {
            throw new NotImplementedException();
        }

        public void PrintfAndFlush(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Scanf<T>(string format, out T output)
        {
            throw new NotImplementedException();
        }

        public void Scanf<T1, T2>(string format, out T1 output1, out T2 output2)
        {
            throw new NotImplementedException();
        }

        public void Scanf<T1, T2, T3>(string format, out T1 output1, out T2 output2, out T3 output3)
        {
            throw new NotImplementedException();
        }

        public void Scanf<T1, T2, T3, T4>(string format, out T1 output1, out T2 output2, out T3 output3, out T4 output4)
        {
            throw new NotImplementedException();
        }

        public void Scanf<T1, T2, T3, T4, T5>(string format, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5)
        {
            throw new NotImplementedException();
        }

        public void Scanf<T1, T2, T3, T4, T5, T6>(string format, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5, out T6 output6)
        {
            throw new NotImplementedException();
        }

        public void Scanf<T1, T2, T3, T4, T5, T6, T7>(string format, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5, out T6 output6, out T7 output7)
        {
            throw new NotImplementedException();
        }

        public void Scanf<T>(string format, int[] inputs, out T output)
        {
            throw new NotImplementedException();
        }

        public void Scanf<T1, T2>(string format, int[] inputs, out T1 output1, out T2 output2)
        {
            throw new NotImplementedException();
        }

        public void Scanf<T1, T2, T3>(string format, int[] inputs, out T1 output1, out T2 output2, out T3 output3)
        {
            throw new NotImplementedException();
        }

        public void Scanf<T1, T2, T3, T4>(string format, int[] inputs, out T1 output1, out T2 output2, out T3 output3, out T4 output4)
        {
            throw new NotImplementedException();
        }

        public void Scanf<T1, T2, T3, T4, T5>(string format, int[] inputs, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5)
        {
            throw new NotImplementedException();
        }

        public void Scanf<T1, T2, T3, T4, T5, T6>(string format, int[] inputs, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5, out T6 output6)
        {
            throw new NotImplementedException();
        }

        public void Scanf<T1, T2, T3, T4, T5, T6, T7>(string format, int[] inputs, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5, out T6 output6, out T7 output7)
        {
            throw new NotImplementedException();
        }

        public void Write(char data)
        {
            throw new NotImplementedException();
        }

        public void Write(string data)
        {
            throw new NotImplementedException();
        }

        public void Write(long data)
        {
            throw new NotImplementedException();
        }

        public void Write(ulong data)
        {
            throw new NotImplementedException();
        }

        public void Write(double data)
        {
            throw new NotImplementedException();
        }

        public void WriteLine()
        {
            throw new NotImplementedException();
        }

        public void WriteLine(char data)
        {
            throw new NotImplementedException();
        }

        public void WriteLine(long data)
        {
            throw new NotImplementedException();
        }

        public void WriteLine(ulong data)
        {
            throw new NotImplementedException();
        }

        public void WriteLine(double data)
        {
            throw new NotImplementedException();
        }

        public void WriteList(byte[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteList(byte[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteList(sbyte[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteList(sbyte[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteList(short[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteList(short[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteList(ushort[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteList(ushort[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteList(int[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteList(int[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteList(uint[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteList(uint[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteList(long[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteList(long[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteList(ulong[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteList(ulong[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteList(float[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteList(float[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteList(double[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteList(double[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteLineList(byte[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteLineList(byte[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteLineList(sbyte[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteLineList(sbyte[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteLineList(short[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteLineList(short[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteLineList(ushort[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteLineList(ushort[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteLineList(int[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteLineList(int[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteLineList(uint[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteLineList(uint[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteLineList(long[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteLineList(long[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteLineList(ulong[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteLineList(ulong[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteLineList(float[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteLineList(float[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteLineList(double[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteLineList(double[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(byte[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(byte[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(sbyte[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(sbyte[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(short[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(short[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(ushort[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(ushort[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(int[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(int[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(uint[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(uint[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(long[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(long[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(ulong[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(ulong[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(float[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(float[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(double[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(double[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteBinaryAndFlush(byte[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteBinaryAndFlush(byte[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteBinaryAndFlush(sbyte[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteBinaryAndFlush(sbyte[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteBinaryAndFlush(short[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteBinaryAndFlush(short[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteBinaryAndFlush(ushort[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteBinaryAndFlush(ushort[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteBinaryAndFlush(int[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteBinaryAndFlush(int[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteBinaryAndFlush(uint[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteBinaryAndFlush(uint[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteBinaryAndFlush(long[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteBinaryAndFlush(long[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteBinaryAndFlush(ulong[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteBinaryAndFlush(ulong[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteBinaryAndFlush(float[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteBinaryAndFlush(float[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteBinaryAndFlush(double[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteBinaryAndFlush(double[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public string ReadString(int count)
        {
            throw new NotImplementedException();
        }

        public int ReadString(StringBuilder data)
        {
            throw new NotImplementedException();
        }

        public int ReadString(StringBuilder data, int count)
        {
            throw new NotImplementedException();
        }

        public char ReadChar()
        {
            throw new NotImplementedException();
        }

        public long ReadInt64()
        {
            throw new NotImplementedException();
        }

        public ulong ReadUInt64()
        {
            throw new NotImplementedException();
        }

        public double ReadDouble()
        {
            throw new NotImplementedException();
        }

        public int ReadLine(StringBuilder data)
        {
            throw new NotImplementedException();
        }

        public char ReadLineChar()
        {
            throw new NotImplementedException();
        }

        public long ReadLineInt64()
        {
            throw new NotImplementedException();
        }

        public ulong ReadLineUInt64()
        {
            throw new NotImplementedException();
        }

        public double ReadLineDouble()
        {
            throw new NotImplementedException();
        }

        public byte[] ReadListOfByte(long count)
        {
            throw new NotImplementedException();
        }

        public long ReadListOfByte(byte[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public sbyte[] ReadListOfSByte(long count)
        {
            throw new NotImplementedException();
        }

        public long ReadListOfSByte(sbyte[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public short[] ReadListOfInt16(long count)
        {
            throw new NotImplementedException();
        }

        public long ReadListOfInt16(short[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public ushort[] ReadListOfUInt16(long count)
        {
            throw new NotImplementedException();
        }

        public long ReadListOfUInt16(ushort[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public int[] ReadListOfInt32(long count)
        {
            throw new NotImplementedException();
        }

        public long ReadListOfInt32(int[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public uint[] ReadListOfUInt32(long count)
        {
            throw new NotImplementedException();
        }

        public long ReadListOfUInt32(uint[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public long[] ReadListOfInt64(long count)
        {
            throw new NotImplementedException();
        }

        public long ReadListOfInt64(long[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public ulong[] ReadListOfUInt64(long count)
        {
            throw new NotImplementedException();
        }

        public long ReadListOfUInt64(ulong[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public float[] ReadListOfSingle(long count)
        {
            throw new NotImplementedException();
        }

        public long ReadListOfSingle(float[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public double[] ReadListOfDouble(long count)
        {
            throw new NotImplementedException();
        }

        public long ReadListOfDouble(double[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public byte[] ReadLineListOfByte()
        {
            throw new NotImplementedException();
        }

        public long ReadLineListOfByte(byte[] data, long index)
        {
            throw new NotImplementedException();
        }

        public sbyte[] ReadLineListOfSByte()
        {
            throw new NotImplementedException();
        }

        public long ReadLineListOfSByte(sbyte[] data, long index)
        {
            throw new NotImplementedException();
        }

        public short[] ReadLineListOfInt16()
        {
            throw new NotImplementedException();
        }

        public long ReadLineListOfInt16(short[] data, long index)
        {
            throw new NotImplementedException();
        }

        public ushort[] ReadLineListOfUInt16()
        {
            throw new NotImplementedException();
        }

        public long ReadLineListOfUInt16(ushort[] data, long index)
        {
            throw new NotImplementedException();
        }

        public int[] ReadLineListOfInt32()
        {
            throw new NotImplementedException();
        }

        public long ReadLineListOfInt32(int[] data, long index)
        {
            throw new NotImplementedException();
        }

        public uint[] ReadLineListOfUInt32()
        {
            throw new NotImplementedException();
        }

        public long ReadLineListOfUInt32(uint[] data, long index)
        {
            throw new NotImplementedException();
        }

        public long[] ReadLineListOfInt64()
        {
            throw new NotImplementedException();
        }

        public long ReadLineListOfInt64(long[] data, long index)
        {
            throw new NotImplementedException();
        }

        public ulong[] ReadLineListOfUInt64()
        {
            throw new NotImplementedException();
        }

        public long ReadLineListOfUInt64(ulong[] data, long index)
        {
            throw new NotImplementedException();
        }

        public float[] ReadLineListOfSingle()
        {
            throw new NotImplementedException();
        }

        public long ReadLineListOfSingle(float[] data, long index)
        {
            throw new NotImplementedException();
        }

        public double[] ReadLineListOfDouble()
        {
            throw new NotImplementedException();
        }

        public long ReadLineListOfDouble(double[] data, long index)
        {
            throw new NotImplementedException();
        }

        public byte[] ReadBinaryBlockOfByte()
        {
            throw new NotImplementedException();
        }

        public byte[] ReadBinaryBlockOfByte(bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public long ReadBinaryBlockOfByte(byte[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public long ReadBinaryBlockOfByte(byte[] data, long index, long count, bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public sbyte[] ReadBinaryBlockOfSByte()
        {
            throw new NotImplementedException();
        }

        public sbyte[] ReadBinaryBlockOfSByte(bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public long ReadBinaryBlockOfSByte(sbyte[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public long ReadBinaryBlockOfSByte(sbyte[] data, long index, long count, bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public short[] ReadBinaryBlockOfInt16()
        {
            throw new NotImplementedException();
        }

        public short[] ReadBinaryBlockOfInt16(bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public long ReadBinaryBlockOfInt16(short[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public long ReadBinaryBlockOfInt16(short[] data, long index, long count, bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public ushort[] ReadBinaryBlockOfUInt16()
        {
            throw new NotImplementedException();
        }

        public ushort[] ReadBinaryBlockOfUInt16(bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public long ReadBinaryBlockOfUInt16(ushort[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public long ReadBinaryBlockOfUInt16(ushort[] data, long index, long count, bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public int[] ReadBinaryBlockOfInt32()
        {
            throw new NotImplementedException();
        }

        public int[] ReadBinaryBlockOfInt32(bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public long ReadBinaryBlockOfInt32(int[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public long ReadBinaryBlockOfInt32(int[] data, long index, long count, bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public uint[] ReadBinaryBlockOfUInt32()
        {
            throw new NotImplementedException();
        }

        public uint[] ReadBinaryBlockOfUInt32(bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public long ReadBinaryBlockOfUInt32(uint[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public long ReadBinaryBlockOfUInt32(uint[] data, long index, long count, bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public long[] ReadBinaryBlockOfInt64()
        {
            throw new NotImplementedException();
        }

        public long ReadBinaryBlockOfInt64(long[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public ulong[] ReadBinaryBlockOfUInt64()
        {
            throw new NotImplementedException();
        }

        public long ReadBinaryBlockOfUInt64(ulong[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public float[] ReadBinaryBlockOfSingle()
        {
            throw new NotImplementedException();
        }

        public float[] ReadBinaryBlockOfSingle(bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public long ReadBinaryBlockOfSingle(float[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public long ReadBinaryBlockOfSingle(float[] data, long index, long count, bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public double[] ReadBinaryBlockOfDouble()
        {
            throw new NotImplementedException();
        }

        public double[] ReadBinaryBlockOfDouble(bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public long ReadBinaryBlockOfDouble(double[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public long ReadBinaryBlockOfDouble(double[] data, long index, long count, bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public byte[] ReadLineBinaryBlockOfByte()
        {
            throw new NotImplementedException();
        }

        public byte[] ReadLineBinaryBlockOfByte(bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public long ReadLineBinaryBlockOfByte(byte[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public long ReadLineBinaryBlockOfByte(byte[] data, long index, long count, bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public sbyte[] ReadLineBinaryBlockOfSByte()
        {
            throw new NotImplementedException();
        }

        public sbyte[] ReadLineBinaryBlockOfSByte(bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public long ReadLineBinaryBlockOfSByte(sbyte[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public long ReadLineBinaryBlockOfSByte(sbyte[] data, long index, long count, bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public short[] ReadLineBinaryBlockOfInt16()
        {
            throw new NotImplementedException();
        }

        public short[] ReadLineBinaryBlockOfInt16(bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public long ReadLineBinaryBlockOfInt16(short[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public long ReadLineBinaryBlockOfInt16(short[] data, long index, long count, bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public ushort[] ReadLineBinaryBlockOfUInt16()
        {
            throw new NotImplementedException();
        }

        public ushort[] ReadLineBinaryBlockOfUInt16(bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public long ReadLineBinaryBlockOfUInt16(ushort[] data, long index, long coun)
        {
            throw new NotImplementedException();
        }

        public long ReadLineBinaryBlockOfUInt16(ushort[] data, long index, long count, bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public int[] ReadLineBinaryBlockOfInt32()
        {
            throw new NotImplementedException();
        }

        public int[] ReadLineBinaryBlockOfInt32(bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public long ReadLineBinaryBlockOfInt32(int[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public long ReadLineBinaryBlockOfInt32(int[] data, long index, long count, bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public uint[] ReadLineBinaryBlockOfUInt32()
        {
            throw new NotImplementedException();
        }

        public uint[] ReadLineBinaryBlockOfUInt32(bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public long ReadLineBinaryBlockOfUInt32(uint[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public long ReadLineBinaryBlockOfUInt32(uint[] data, long index, long count, bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public long[] ReadLineBinaryBlockOfInt64()
        {
            throw new NotImplementedException();
        }

        public long ReadLineBinaryBlockOfInt64(long[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public ulong[] ReadLineBinaryBlockOfUInt64()
        {
            throw new NotImplementedException();
        }

        public long ReadLineBinaryBlockOfUInt64(ulong[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public float[] ReadLineBinaryBlockOfSingle()
        {
            throw new NotImplementedException();
        }

        public float[] ReadLineBinaryBlockOfSingle(bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public long ReadLineBinaryBlockOfSingle(float[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public long ReadLineBinaryBlockOfSingle(float[] data, long index, long count, bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public double[] ReadLineBinaryBlockOfDouble()
        {
            throw new NotImplementedException();
        }

        public double[] ReadLineBinaryBlockOfDouble(bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public long ReadLineBinaryBlockOfDouble(double[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public long ReadLineBinaryBlockOfDouble(double[] data, long index, long count, bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public string ReadWhileMatch(string characters)
        {
            throw new NotImplementedException();
        }

        public string ReadUntilMatch(char ch)
        {
            throw new NotImplementedException();
        }

        public string ReadUntilMatch(string characters, bool discardMatch)
        {
            throw new NotImplementedException();
        }

        public string ReadUntilEnd()
        {
            throw new NotImplementedException();
        }

        public void Skip(long count)
        {
            throw new NotImplementedException();
        }

        public void SkipString(string data)
        {
            throw new NotImplementedException();
        }

        public void SkipUntilEnd()
        {
            throw new NotImplementedException();
        }
    }
}