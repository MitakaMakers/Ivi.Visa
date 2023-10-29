using System;
using System.IO;

namespace Vxi11Net
{
    public class Vxi11ListenerResponse
    {
        private Vxi11ListenerContext m_Vxi11ListenerContext;

        public Vxi11ListenerResponse(Vxi11ListenerContext context)
        {
            m_Vxi11ListenerContext = context;
        }

        public Vxi11ListenerContext Vxi11ListenerContext
        {
            get
            {
                return m_Vxi11ListenerContext;
            }
        }
        public Stream OutputStream
        {
            get
            {
                return m_Vxi11ListenerContext.ResponseStream;
            }
        }
    }
}
