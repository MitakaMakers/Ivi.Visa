using System;
using System.IO;
using System.Net.Sockets;

namespace Vxi11Net
{
    public class Vxi11ListenerContext
    {
        private Vxi11Listener m_Listener;
        private Vxi11ListenerRequest m_Request;
        private Vxi11ListenerResponse m_Response;
        private TcpClient m_SyncClient;
        private TcpClient m_AsyncClient;
        private Vxi11RequestStream m_RequestStream;
        private Vxi11ResponseStream m_ResponseStream;

        public Vxi11ListenerContext(TcpClient server)
        {
            m_Listener = new Vxi11Listener(server);
            m_Request = new Vxi11ListenerRequest(this);
            m_Response = new Vxi11ListenerResponse(this);
            m_SyncClient = server;
            m_AsyncClient = server;
            m_RequestStream = new Vxi11RequestStream(this);
            m_ResponseStream = new Vxi11ResponseStream(this);
        }
        public Vxi11ListenerContext(Vxi11Listener hislipListener, TcpClient server)
        {
            m_Listener = hislipListener;
            m_Request = new Vxi11ListenerRequest(this);
            m_Response = new Vxi11ListenerResponse(this);
            m_SyncClient = server;
            m_AsyncClient = server;
            m_RequestStream = new Vxi11RequestStream(this);
            m_ResponseStream = new Vxi11ResponseStream(this);
        }

        public Stream RequestStream
        {
            get
            {
                return m_RequestStream;
            }
        }
        public Stream ResponseStream
        {
            get
            {
                return m_ResponseStream;
            }
        }
        public Vxi11ListenerRequest Request
        {
            get
            {
                return m_Request;
            }
        }
        public Vxi11ListenerResponse Response
        {
            get
            {
                return m_Response;
            }
        }
        public TcpClient SyncClient
        {
            get
            {
                return m_SyncClient;
            }
        }
        public TcpClient AsyncClient
        {
            get
            {
                return m_AsyncClient;
            }
            set
            {
                if (value != null)
                {
                    m_AsyncClient = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value");
                }
            }
        }
    }
}
