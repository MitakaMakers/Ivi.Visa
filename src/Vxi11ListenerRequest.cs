using System;
using System.IO;

namespace Vxi11Net
{
    public class Vxi11ListenerRequest
    {
        private Vxi11ListenerContext m_Vxi11ListenerContext;

        public Vxi11ListenerRequest(Vxi11ListenerContext context)
        {
            m_Vxi11ListenerContext = context;
        }

        public Stream InputStream
        {
            get
            {
                return m_Vxi11ListenerContext.RequestStream;
            }
        }
        public int Procedure { get; internal set; }
    }
}
