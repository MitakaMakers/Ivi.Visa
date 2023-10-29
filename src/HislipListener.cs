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
        public static uint NetworkToHostOrderToUInt32(byte[] array, int index)
        {
            uint u = (uint)array[index] << 24;
            u += (uint)array[index + 1] << 16;
            u += (uint)array[index + 2] << 8;
            u += (uint)array[index + 3];
            return u;
        }
        public static ulong NetworkToHostOrderToUInt64(byte[] array, int index)
        {
            ulong u = (ulong)array[index] << 58;
            u += (ulong)array[index + 1] << 48;
            u += (ulong)array[index + 2] << 40;
            u += (ulong)array[index + 3] << 32;
            u += (ulong)array[index + 4] << 24;
            u += (ulong)array[index + 5] << 16;
            u += (ulong)array[index + 6] << 8;
            u += (ulong)array[index + 7];
            return u;
        }

        enum State
        {
            Started,
            Stopped,
            Closed,
        }

        private HislipListenerContext m_Context;
        private volatile State m_State;

        public HislipListener(TcpClient server, ulong maxMessageSize)
        {
            m_Context = new HislipListenerContext(this, server, maxMessageSize);
            m_State = State.Started;
        }
        public void Close()
        {
            m_Context.Close();
            m_State = State.Stopped;
        }
        public bool IsListening
        {
            get
            {
                return m_State == State.Started;
            }
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
            request.MessageParameter = NetworkToHostOrderToUInt32(buffer, 4);
            request.PayloadLength = NetworkToHostOrderToUInt64(buffer, 8);
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
            try
            {
                HislipListenerRequest request = m_Context.Request;
                HislipListenerResponse response = m_Context.Response;
                NetworkStream stream = m_Context.SyncClient.GetStream();
                int size = Marshal.SizeOf(typeof(Hislip.Message));
                byte[] buffer = new byte[size];
                int bytes = stream.Read(buffer, 0, size);
                if (bytes == 0)
                {
                    m_State = State.Closed;
                    request.MessageType = 255;
                }
                else
                {

                    request.Prologue0 = (char)buffer[0];
                    request.Prologue1 = (char)buffer[1];
                    request.MessageType = buffer[2];
                    request.ControlCode = buffer[3];
                    request.MessageParameter = NetworkToHostOrderToUInt32(buffer, 4);
                    request.PayloadLength = NetworkToHostOrderToUInt64(buffer, 8);
                    if (request.PayloadLength > 0)
                    {
                        stream.Read(request.Payload, 0, (int)request.PayloadLength);
                    }

                    response.Prologue0 = 'H';
                    response.Prologue1 = 'S';
                    switch (request.MessageType)
                    {
                        case Hislip.AsyncLock:
                            response.MessageType = Hislip.AsyncLockResponse_;
                            break;
                        case Hislip.Data_:
                            response.MessageType = Hislip.Data_;
                            response.MessageID = request.MessageParameter;
                            break;
                        case Hislip.DataEnd:
                            response.MessageType = Hislip.DataEnd;
                            response.MessageID = request.MessageParameter;
                            break;
                        case Hislip.DeviceClearComplete:
                            response.MessageType = Hislip.DeviceClearAcknowledge;
                            break;
                        case Hislip.AsyncRemoteLocalControl:
                            response.MessageType = Hislip.AsyncRemoteLocalResponse;
                            break;
                        case Hislip.AsyncDeviceClear:
                            response.MessageType = Hislip.AsyncDeviceClearAcknowledge;
                            break;
                        case Hislip.AsyncStatusQuery:
                            response.MessageType = Hislip.AsyncStatusResponse;
                            response.MessageID = request.MessageParameter;
                            break;
                        case Hislip.AsyncLockInfo:
                            response.MessageType = Hislip.AsyncLockInfoResponse;
                            break;
                    }
                    response.ControlCode = 0;
                    response.MessageParameter = 0;
                    response.PayloadLength = 0;
                }
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.ToString());
                m_State = State.Closed;
            }
            return m_Context;
        }

        internal void Stop()
        {
            m_Context.Close();
            m_State = State.Stopped;
        }
    }
}
