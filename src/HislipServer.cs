using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Runtime.InteropServices;
using System.IO;

namespace Vxi11Net
{
    internal class HislipServer
    {
        private IPAddress m_LocalAddr = IPAddress.Parse("127.0.0.1");
        private short m_Port = Hislip.PORT;
        private ushort m_SessionID;
        private ulong m_MaximumMessageSize;
        private bool m_IsListening;
        private TcpListener m_TcpListener;

        public HislipServer()
        {
            m_TcpListener = new TcpListener(m_LocalAddr, m_Port);
        }
        public bool IsListening
        {
            get
            {
                return m_IsListening;
            }
        }
        public short Port
        {
            get
            {
                return m_Port;
            }
            set
            {
                if (value >= 0)
                {
                    m_Port = value;
                    m_TcpListener = new TcpListener(m_LocalAddr, m_Port);
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Port");
                }
            }
        }
        public ushort SessionID
        {
            get
            {
                return m_SessionID;
            }
            set
            {
                if (value >= 0)
                {
                    m_SessionID = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Port");
                }
            }
        }
        public ulong MaximumMessageSize
        {
            get
            {
                return m_MaximumMessageSize;
            }
            set
            {
                if (value >= 0)
                {
                    m_MaximumMessageSize = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("MaximumMessageSize");
                }
            }
        }
        public void Start()
        {
            m_IsListening = true;
            m_TcpListener.Start();
        }
        public HislipListener AcceptClient()
        {
            TcpClient client;
            TcpClient asyncClient;
            while (true)
            {
                HislipListenerContext context;
                HislipListenerRequest request;
                HislipListenerResponse response;
                while (true)
                {
                    client = m_TcpListener.AcceptTcpClient();
                    context = HislipListener.GetMessage(client);
                    request = context.Request;
                    response = context.Response;
                    if (request.MessageType == Hislip.Initialize_)
                    {
                        response.SessionID = m_SessionID;
                        response.ServerVersion = Hislip.ServerVersion;
                        byte[] bytes = response.GetBytes();
                        client.GetStream().Write(bytes);
                        break;
                    }
                    else
                    {
                        client.Close();
                    }
                }
                asyncClient = m_TcpListener.AcceptTcpClient();
                context = HislipListener.GetMessage(asyncClient);
                request = context.Request;
                response = context.Response;
                if (request.MessageType == Hislip.AsyncInitialize)
                {
                    response.VendorID = Hislip.VendorID;
                    byte[] bytes = response.GetBytes();
                    asyncClient.GetStream().Write(bytes);
                }
                else
                {
                    asyncClient.Close();
                }

                context = HislipListener.GetMessage(asyncClient);
                request = context.Request;
                response = context.Response;
                if (request.MessageType == Hislip.AsyncMaximumMessageSize)
                {
                   
                    response.MaximumMessageSize = m_MaximumMessageSize;
                    byte[] bytes = response.GetBytes();
                    asyncClient.GetStream().Write(bytes);
                    break;
                }
                else
                {
                    asyncClient.Close();
                }
            }
            HislipListener listener = new HislipListener(client, m_MaximumMessageSize);
            return listener;
        }
        public void Abort() { }
        public void Close() {
            m_TcpListener.Stop();
        }
        public void Stop()
        {
            m_TcpListener.Stop();
            m_IsListening = false;
        }
    }
}
