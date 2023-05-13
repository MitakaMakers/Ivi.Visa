using System.Runtime.Serialization;
using System.Text;
using Vxi11Net;

namespace Ivi.Visa
{
    public class Vxi11RawIO488 : IMessageBasedRawIO
    {
        private Vxi11Session sesn;
        public Vxi11RawIO488(Vxi11Session sesn)
        {
            this.sesn = sesn;
        }

        public void AbortAsyncOperation(IVisaAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public IVisaAsyncResult BeginRead(int count)
        {
            throw new NotImplementedException();
        }

        public IVisaAsyncResult BeginRead(int count, object state)
        {
            throw new NotImplementedException();
        }

        public IVisaAsyncResult BeginRead(int count, VisaAsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public IVisaAsyncResult BeginRead(byte[] buffer)
        {
            throw new NotImplementedException();
        }

        public IVisaAsyncResult BeginRead(byte[] buffer, object state)
        {
            throw new NotImplementedException();
        }

        public IVisaAsyncResult BeginRead(byte[] buffer, long index, long count)
        {
            throw new NotImplementedException();
        }

        public IVisaAsyncResult BeginRead(byte[] buffer, long index, long count, object state)
        {
            throw new NotImplementedException();
        }

        public IVisaAsyncResult BeginRead(byte[] buffer, VisaAsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public IVisaAsyncResult BeginRead(byte[] buffer, long index, long count, VisaAsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public IVisaAsyncResult BeginWrite(string buffer)
        {
            throw new NotImplementedException();
        }

        public IVisaAsyncResult BeginWrite(string buffer, object state)
        {
            throw new NotImplementedException();
        }

        public IVisaAsyncResult BeginWrite(string buffer, VisaAsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public IVisaAsyncResult BeginWrite(byte[] buffer)
        {
            throw new NotImplementedException();
        }

        public IVisaAsyncResult BeginWrite(byte[] buffer, object state)
        {
            throw new NotImplementedException();
        }

        public IVisaAsyncResult BeginWrite(byte[] buffer, long index, long count)
        {
            throw new NotImplementedException();
        }

        public IVisaAsyncResult BeginWrite(byte[] buffer, long index, long count, object state)
        {
            throw new NotImplementedException();
        }

        public IVisaAsyncResult BeginWrite(byte[] buffer, VisaAsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public IVisaAsyncResult BeginWrite(byte[] buffer, long index, long count, VisaAsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public long EndRead(IVisaAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public string EndReadString(IVisaAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public void EndWrite(IVisaAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public byte[] Read()
        {
            throw new NotImplementedException();
        }

        public byte[] Read(long count)
        {
            throw new NotImplementedException();
        }

        public byte[] Read(long count, out ReadStatus readStatus)
        {
            throw new NotImplementedException();
        }

        public void Read(byte[] buffer, long index, long count, out long actualCount, out ReadStatus readStatus)
        {
            throw new NotImplementedException();
        }

        public string ReadString()
        {
            throw new NotImplementedException();
        }

        public string ReadString(long count)
        {
            throw new NotImplementedException();
        }

        public string ReadString(long count, out ReadStatus readStatus)
        {
            throw new NotImplementedException();
        }

        public void Write(byte[] buffer)
        {
            throw new NotImplementedException();
        }

        public void Write(byte[] buffer, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void Write(string buffer)
        {
            throw new NotImplementedException();
        }

        public void Write(string buffer, long index, long count)
        {
            throw new NotImplementedException();
        }
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
    public class Vxi11Session : ITcpipSocketSession
    {
        public const int default_timeout_value = 2000;
        public Int32 TimeoutMilliseconds { get; set; }
        public String ResourceName { get; } = string.Empty;
        public String HardwareInterfaceName { get; } = string.Empty;
        public HardwareInterfaceType HardwareInterfaceType { get; }
        public Int16 HardwareInterfaceNumber { get; }
        public String ResourceClass { get; } = string.Empty;
        public String ResourceManufacturerName { get; } = string.Empty;
        public Int16 ResourceManufacturerId { get; }
        public Version ResourceImplementationVersion { get; } = Environment.Version;
        public Version ResourceSpecificationVersion { get; } = Environment.Version;
        public ResourceLockState ResourceLockState { get; }

        public event EventHandler<VisaEventArgs> ServiceRequest;

        public void LockResource() { }
        public void LockResource(TimeSpan timeout) { }
        public void LockResource(Int32 timeoutMilliseconds) { }
        public string LockResource(TimeSpan timeout, String sharedKey) { return ""; }
        public string LockResource(Int32 timeoutMilliseconds, String sharedKey) { return ""; }
        public void UnlockResource() { }
        public Int32 EventQueueCapacity { get; set; }
        public Boolean SynchronizeCallbacks { get; set; }
        public void EnableEvent(EventType eventType) { }
        public void DisableEvent(EventType eventType) { }
        public void DiscardEvent(EventType eventType) { }
        public VisaEventArgs WaitOnEvent(EventType eventType)
        {
            return new VisaEventArgs(EventType.Custom);
        }
        public VisaEventArgs WaitOnEvent(EventType eventType, out EventQueueStatus status)
        {
            status = EventQueueStatus.Empty;
            return new VisaEventArgs(EventType.Custom);
        }
        public VisaEventArgs WaitOnEvent(EventType eventType, Int32 timeoutMilliseconds)
        {
            return new VisaEventArgs(EventType.Custom);
        }
        public VisaEventArgs WaitOnEvent(EventType eventType, TimeSpan timeout)
        {
            return new VisaEventArgs(EventType.Custom);
        }
        public VisaEventArgs WaitOnEvent(EventType eventType, Int32 timeoutMilliseconds, out EventQueueStatus status)
        {
            status = EventQueueStatus.Empty;
            return new VisaEventArgs(EventType.Custom);
        }
        public VisaEventArgs WaitOnEvent(EventType eventType, TimeSpan timeout, out EventQueueStatus status)
        {
            status = EventQueueStatus.Empty;
            return new VisaEventArgs(EventType.Custom);
        }
        public void Dispose() { }

        public String Address { get; } = string.Empty;
        public String HostName { get; } = string.Empty;
        public Boolean KeepAlive { get; set; }
        public Boolean NoDelay { get; set; }
        public Int16 Port { get; }
        public void Flush(IOBuffers buffers, Boolean discard) { }
        public Boolean SetBufferSize(IOBuffers buffers, Int32 size) { return true;  }
        public IOProtocol IOProtocol { get; set; }
        public Boolean SendEndEnabled { get; set; }
        public Byte TerminationCharacter { get; set; }
        public Boolean TerminationCharacterEnabled { get; set; }
        public void AssertTrigger() { }
        public void Clear() { }
        public StatusByteFlags ReadStatusByte()
        {
            throw new NotImplementedException();
        }
        public IMessageBasedFormattedIO FormattedIO { get; }
        public IMessageBasedRawIO RawIO { get; }
        private ClientVxi11 client = new ClientVxi11();

        private int lock_timeout = default_timeout_value;
        private int io_timeout = default_timeout_value;
        private int lid;
        private int abortPort;
        private int maxRecvSize;
        public static void ServiceRequestHandler(object? sender, VisaEventArgs args)
        {
            return;
        }
        public Vxi11Session(string resourceName)
        {
            // TCPIP[board]::host address[::LAN device name][::INSTR]
            this.Address = "127.0.0.1";
            this.Port = 10240;
            string deviceName = "inst0";
            client.Create(this.Address, this.Port);
            int clientId = 0;
            int lockDevice = 0;
            client.CreateLink(clientId, lockDevice, this.lock_timeout, deviceName, out this.lid, out this.abortPort, out this.maxRecvSize);

            this.FormattedIO = new Vxi11FormattedIO488(this);
            this.RawIO = new Vxi11RawIO488(this);
            this.ServiceRequest = ServiceRequestHandler;
        }
        public int Read(string buf, int count, out int retCount)
        {
            Vxi11.Flags flags = Vxi11.Flags.end;
            Vxi11.TermChar term = Vxi11.TermChar.None;
            int reason = 0;
            byte[] data = new byte[count];
            client.DeviceRead(this.lid, count, flags, this.lock_timeout, this.io_timeout, term, out reason, out data);
            retCount = data.Length;
            return 0;
        }
        public int Write(string buf, int count, out int retCount)
        {
            Vxi11.Flags flags = Vxi11.Flags.end;
            client.DeviceWrite(this.lid, flags, this.lock_timeout, this.io_timeout, buf, out retCount);
            return 0;
        }
        public int Terminate()
        {
            client.Create(this.Address, this.abortPort);
            Vxi11.Flags flags = Vxi11.Flags.end;
            client.DeviceAbort(this.lid, flags, this.lock_timeout, this.io_timeout);
            return 0;
        }
    }
}