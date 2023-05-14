using System.Text;

namespace Ivi.Visa
{
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
}