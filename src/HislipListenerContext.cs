using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Vxi11Net
{
    public class HislipListenerContext
    {
        private HislipListener m_Listener;
        private HislipListenerRequest m_Request;
        private HislipListenerResponse m_Response;
        private TcpClient m_SyncClient;
        private TcpClient m_AsyncClient;
        private HislipRequestStream m_RequestStream;
        private HislipResponseStream m_ResponseStream;


        internal HislipListenerContext(TcpClient server)
        {
            m_Listener = new HislipListener(server);
            m_Request = new HislipListenerRequest(this);
            m_Response = new HislipListenerResponse(this);
            m_SyncClient = server;
            m_AsyncClient = server;
            m_RequestStream = new HislipRequestStream(this);
            m_ResponseStream = new HislipResponseStream(this);
        }
    internal HislipListenerContext(HislipListener hislipListener, TcpClient server)
        {
            m_Listener = hislipListener;
            m_Request = new HislipListenerRequest(this);
            m_Response = new HislipListenerResponse(this);
            m_SyncClient = server;
            m_AsyncClient = server;
            m_RequestStream = new HislipRequestStream(this);
            m_ResponseStream = new HislipResponseStream(this);
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
        public HislipListenerRequest Request
        {
            get
            {
                return m_Request;
            }
        }
        public HislipListenerResponse Response
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
        public Stream SyncStream
        {
            get
            {
                return m_SyncClient.GetStream();
            }
        }

        public Stream AsyncStream
        {
            get
            {
                return m_AsyncClient.GetStream();
            }
        }
        public void Close()
        {
            m_SyncClient.Close();
            m_AsyncClient.Close();
        }
    }
}
