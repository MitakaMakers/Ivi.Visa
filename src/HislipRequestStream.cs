using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Vxi11Net
{
    internal class HislipRequestStream : Stream
    {
        private HislipListenerContext m_HislipListenerContext;
        private long m_DataChunkIndex;
        private bool m_Closed;
        internal const int MaxReadSize = 0x20000; //http.sys recommends we limit reads to 128k

        public HislipRequestStream(HislipListenerContext hislipListenerContext)
        {
            m_HislipListenerContext = hislipListenerContext;
        }


        public override bool CanSeek
        {
            get
            {
                return false;
            }
        }

        public override bool CanWrite
        {
            get
            {
                return false;
            }
        }

        public override bool CanRead
        {
            get
            {
                return true;
            }
        }

        internal bool Closed
        {
            get
            {
                return m_Closed;
            }
        }

        internal bool BufferedDataChunksAvailable
        {
            get
            {
                return m_DataChunkIndex > -1;
            }
        }

        // This low level API should only be consumed if the caller can make sure that the state is not corrupted
        // WebSocketHttpListenerDuplexStream (a duplex wrapper around HttpRequestStream/HttpResponseStream)
        // is currenlty the only consumer of this API
        internal HislipListenerContext InternalHislipContext
        {
            get
            {
                return m_HislipListenerContext;
            }
        }

        public override void Flush()
        {
        }

        public override Task FlushAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public override long Length
        {
            get
            {
                throw new NotSupportedException();
            }

        }

        public override long Position
        {
            get
            {
                throw new NotSupportedException();
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override int Read([In, Out] byte[] buffer, int offset, int size)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }
            if (offset < 0 || offset > buffer.Length)
            {
                throw new ArgumentOutOfRangeException("offset");
            }
            if (size < 0 || size > buffer.Length - offset)
            {
                throw new ArgumentOutOfRangeException("size");
            }
            if (size == 0 || m_Closed)
            {
                return 0;
            }

            uint dataRead = 0;
            m_HislipListenerContext.SyncStream.Read(buffer, offset, size);

            return (int)dataRead;
        }

        public override IAsyncResult BeginRead(byte[] buffer, int offset, int size, AsyncCallback? callback, object? state)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }
            if (offset < 0 || offset > buffer.Length)
            {
                throw new ArgumentOutOfRangeException("offset");
            }
            if (size < 0 || size > buffer.Length - offset)
            {
                throw new ArgumentOutOfRangeException("size");
            }
            
            return m_HislipListenerContext.SyncStream.BeginRead(buffer, offset, size, callback, state);
        }

        public override int EndRead(IAsyncResult asyncResult)
        {
            if (asyncResult == null)
            {
                throw new ArgumentNullException("asyncResult");
            }
            int dataRead = m_HislipListenerContext.SyncStream.EndRead(asyncResult);
            return dataRead;
        }

        public override void Write(byte[] buffer, int offset, int size)
        {
            throw new NotSupportedException();
        }

        public override IAsyncResult BeginWrite(byte[] buffer, int offset, int size, AsyncCallback? callback, object? state)
        {
            throw new NotSupportedException();
        }

        public override void EndWrite(IAsyncResult asyncResult)
        {
            throw new NotSupportedException();
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                m_Closed = true;
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

    }
}                                      