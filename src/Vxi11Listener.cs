using System;
using System.Net.Sockets;

namespace Vxi11Net
{
    public class Vxi11Listener
    {
        private Vxi11ListenerContext m_Context;

        public Vxi11Listener(TcpClient server)
        {
            m_Context = new Vxi11ListenerContext(this, server);
        }

        public Vxi11ListenerContext GetMessage()
        {
            throw new NotImplementedException();
        }
    }
}
