using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Vxi11Net
{
    public class Vxi11ResponseStream : Stream
    {
        private bool m_Closed;
        private Vxi11ListenerContext m_Vxi11ListenerContext;

        public Vxi11ResponseStream(Vxi11ListenerContext context)
        {
            m_Vxi11ListenerContext = context;
        }
        public override void Close()
        {
            m_Vxi11ListenerContext.SyncClient.Close();
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
                return true;
            }
        }

        public override bool CanRead
        {
            get
            {
                return false;
            }
        }

        internal bool Closed
        {
            get
            {
                return m_Closed;
            }
        }


        internal void SetClosedFlag()
        {
            m_Closed = true;
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
            throw new NotSupportedException();
        }

        public override IAsyncResult BeginRead(byte[] buffer, int offset, int size, AsyncCallback? callback, object? state)
        {
            throw new NotSupportedException();
        }

        public override int EndRead(IAsyncResult asyncResult)
        {
            throw new NotSupportedException();
        }

        public override void Write(byte[] buffer, int offset, int size)
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

            /* TODO */
            m_Vxi11ListenerContext.SyncClient.GetStream().Write(buffer, offset, size);
        }

        public override IAsyncResult BeginWrite(byte[] buffer, int offset, int size, AsyncCallback? callback, object? state)
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

            /* TODO */
            IAsyncResult asyncResult = m_Vxi11ListenerContext.SyncClient.GetStream().BeginWrite(buffer, offset, size, callback, state);
            return asyncResult;
        }

        public override void EndWrite(IAsyncResult asyncResult)
        {
            if (asyncResult == null)
            {
                throw new ArgumentNullException("asyncResult");
            }
            /* TODO */
            m_Vxi11ListenerContext.SyncClient.GetStream().EndWrite(asyncResult);
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    if (m_Closed)
                    {
                        return;
                    }
                    m_Closed = true;
                    m_Vxi11ListenerContext.SyncClient.GetStream().Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }
    }
}
