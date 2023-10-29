using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

namespace Vxi11Net
{
    public class HislipListener
    {
        private HislipListenerContext m_Context;

        public HislipListener(TcpClient server, long maxMessageSize) {
            m_Context = new HislipListenerContext(this, server, maxMessageSize);
        }
        public void Close()
        {
            m_Context.Close();
        }
        public static HislipListenerContext GetMessage(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] buffer = new byte[size];
            int bytes = stream.Read(buffer, 0, size);

            HislipListenerContext context = new HislipListenerContext(client);
            HislipListenerRequest request = context.Request;
            request.Prologue0 = (char)buffer[0];
            request.Prologue1 = (char)buffer[1];
            request.MessageType = buffer[2];
            request.ControlCode = buffer[3];
            request.MessageParameter = (uint)IPAddress.NetworkToHostOrder(BitConverter.ToUInt32(buffer, 4));
            request.PayloadLength = IPAddress.NetworkToHostOrder(BitConverter.ToInt64(buffer, 8));
            if (request.PayloadLength > 0)
            {
                stream.Read(request.Payload, 0, (int)request.PayloadLength);
            }

            HislipListenerResponse response = context.Response;
            response.Prologue0 = 'H';
            response.Prologue1 = 'S';
            switch (request.MessageType)
            {
                case Hislip.Initialize_:
                    response.MessageType = Hislip.InitializeResponse_;
                    break;
                case Hislip.AsyncInitialize:
                    response.MessageType = Hislip.AsyncInitializeResponse_;
                    break;
                case Hislip.AsyncMaximumMessageSize:
                    response.MessageType = Hislip.AsyncMaximumMessageSizeResponse;
                    break;
            }
            response.ControlCode = 0;
            response.MessageParameter = 0;
            response.PayloadLength = 0;

            return context;
        }
        public HislipListenerContext GetMessage()
        {
            NetworkStream stream = m_Context.SyncClient.GetStream();
            int size = Marshal.SizeOf(typeof(Hislip.Message));
            byte[] buffer = new byte[size];
            int bytes = stream.Read(buffer, 0, size);

            HislipListenerRequest request = m_Context.Request;
            request.Prologue0 = (char)buffer[0];
            request.Prologue1 = (char)buffer[1];
            request.MessageType = buffer[2];
            request.ControlCode = buffer[3];
            request.MessageParameter = (uint)IPAddress.NetworkToHostOrder(BitConverter.ToUInt32(buffer, 4));
            request.PayloadLength = IPAddress.NetworkToHostOrder(BitConverter.ToInt64(buffer, 8));
            if (request.PayloadLength > 0)
            {
                stream.Read(request.Payload, 0, (int)request.PayloadLength);
            }

            HislipListenerResponse response = m_Context.Response;
            response.Prologue0 = 'H';
            response.Prologue1 = 'S';
            switch (request.MessageType)
            {
                case Hislip.Data:
                    response.MessageType = Hislip.Data;
                    response.MessageID = request.MessageParameter;
                    break;
                case Hislip.DataEnd:
                    response.MessageType = Hislip.DataEnd;
                    break;
                case Hislip.AsyncLock:
                    break;
                case Hislip.DeviceClearComplete:
                    break;
                case Hislip.AsyncRemoteLocalControl:
                    break;
                case Hislip.Trigger:
                    break;
                case Hislip.AsyncDeviceClear:
                    break;
                case Hislip.AsyncServiceRequest:
                    break;
                case Hislip.AsyncStatusQuery:
                    break;
                case Hislip.AsyncLockInfo:
                    break;
            }
            response.ControlCode = 0;
            response.MessageParameter = 0;
            response.PayloadLength = 0;
            return m_Context;
        }

        internal void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
