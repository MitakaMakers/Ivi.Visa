using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Vxi11Net
{
    public class HislipListenerResponse
    {
        enum ResponseState
        {
            Created,
            ComputedHeaders,
            SentHeaders,
            Closed,
        }

        private ResponseState m_ResponseState;
        private char m_Prologue0;
        private char m_Prologue1;
        private byte m_MessageType;
        private byte m_ControlCode;
        private byte m_Feature;
        private byte m_Status;
        private short m_ServerVersion;
        private short m_VendorID;
        private long m_PayloadLength;
        private short m_ProtocolVersion;
        private short m_SessionID;
        private short m_ServerID;
        private int m_MessageID;
        private int m_MessageParameter;
        private long m_MaximumMessageSize;
        private byte[] m_Payload;
        private string m_Message = "";
        private HislipListenerContext m_HislipListenerContext;

        internal HislipListenerResponse(HislipListenerContext httpContext)
        {
            m_ResponseState = ResponseState.Created;
            m_PayloadLength = 0;
            m_Payload = new byte[0];
            m_HislipListenerContext = httpContext;
        }

        private HislipListenerContext HislipListenerContext
        {
            get
            {
                return m_HislipListenerContext;
            }
        }

        private HislipListenerRequest HislipListenerRequest
        {
            get
            {
                return m_HislipListenerContext.Request;
            }
        }

        public char Prologue0
        {
            get
            {
                return m_Prologue0;
            }
            set
            {
                if (value >= 0)
                {
                    m_Prologue0 = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value");
                }
            }
        }
        public char Prologue1
        {
            get
            {
                return m_Prologue1;
            }
            set
            {
                if (value >= 0)
                {
                    m_Prologue1 = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value");
                }
            }
        }
        public byte MessageType
        {
            get
            {
                return m_MessageType;
            }
            set
            {
                if (value >= 0)
                {
                    m_MessageType = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value");
                }
            }
        }
        public byte ControlCode
        {
            get
            {
                return m_ControlCode;
            }
            set
            {
                if (value >= 0)
                {
                    m_ControlCode = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value");
                }
            }
        }
        public short ServerVersion
        {
            get
            {
                return m_ServerVersion;
            }
            set
            {
                if (value >= 0)
                {
                    m_ServerVersion = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value");
                }
            }
        }
        public short ServerID
        {
            get
            {
                return m_ServerID;
            }
            set
            {
                if (value >= 0)
                {
                    m_ServerID = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value");
                }
            }
        }
        public short VendorID
        {
            get
            {
                return m_VendorID;
            }
            set
            {
                if (value >= 0)
                {
                    m_VendorID = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value");
                }
            }
        }
        public short ProtocolVersion
        {
            get
            {
                return m_ProtocolVersion;
            }
            set
            {
                if (value >= 0)
                {
                    m_ProtocolVersion = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value");
                }
            }
        }
        public short SessionID
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
                    throw new ArgumentOutOfRangeException("value");
                }
            }
        }
        public int MessageID
        {
            get
            {
                return m_MessageID;
            }
            set
            {
                if (value >= 0)
                {
                    m_MessageID = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value");
                }
            }
        }
        public string Message
        {
            get
            {
                return m_Message;
            }
            set
            {
                if (value != null)
                {
                    m_Message = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value");
                }
            }
        }
        public long PayloadLength
        {
            get
            {
                return m_PayloadLength;
            }
            set
            {
                if (value >= 0)
                {
                    m_PayloadLength = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value");
                }
            }
        }
        public byte[] Payload
        {
            get
            {
                return m_Payload;
            }
            set
            {
                if (value != null)
                {
                    m_Payload = value;
                    m_PayloadLength = value.Length;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value");
                }
            }
        }
        public int MessageParameter
        {
            get
            {
                return m_MessageParameter;
            }
            set
            {
                if (value >= 0)
                {
                    m_MessageParameter = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value");
                }
            }
        }
        public long MaximumMessageSize
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
                    throw new ArgumentOutOfRangeException("value");
                }
            }
        }
        private void Dispose(bool disposing)
        {
            if (m_ResponseState >= ResponseState.Closed)
            {
                return;
            }
            m_HislipListenerContext.ResponseStream.Close();
            m_ResponseState = ResponseState.Closed;

            m_HislipListenerContext.Close();
        }
        public Stream OutputStream
        {
            get
            {
                return m_HislipListenerContext.ResponseStream;
            }
        }
        public byte[] GetBytes()
        {
            byte[] packet;
            if (m_MessageType == Hislip.InitializeResponse_)
            {
                Hislip.InitializeResponse reply = new Hislip.InitializeResponse();
                reply.Prologue0 = 'H';
                reply.Prologue1 = 'S';
                reply.MessageType = m_MessageType;
                reply.ControlCode = m_ControlCode;
                reply.Protocol = IPAddress.HostToNetworkOrder(m_ServerVersion);
                reply.SessionID = IPAddress.HostToNetworkOrder(m_SessionID);
                reply.PayloadLength = 0;
                int size = Marshal.SizeOf(typeof(Hislip.InitializeResponse));
                packet = new byte[size];
                GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
                Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
                gchw.Free();
            }
            else if (m_MessageType == Hislip.AsyncInitializeResponse_)
            {
                Hislip.AsyncInitializeResponse reply = new Hislip.AsyncInitializeResponse();
                reply.Prologue0 = 'H';
                reply.Prologue1 = 'S';
                reply.MessageType = m_MessageType;
                reply.ControlCode = m_ControlCode;
                reply.dummy = 0;
                reply.ServerID = IPAddress.HostToNetworkOrder(VendorID);
                reply.PayloadLength = 0;
                int size = Marshal.SizeOf(typeof(Hislip.AsyncInitializeResponse));
                packet = new byte[size];
                GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
                Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
                gchw.Free();
            }
            else if (m_MessageType == Hislip.FatalError)
            {
                byte[] array = System.Text.Encoding.ASCII.GetBytes(m_Message);
                Hislip.Message reply = new Hislip.Message();
                reply.Prologue0 = 'H';
                reply.Prologue1 = 'S';
                reply.MessageType = m_MessageType;
                reply.ControlCode = m_ControlCode;
                reply.MessageParameter = 0;
                reply.PayloadLength = IPAddress.HostToNetworkOrder((long)array.Length);
                int size = Marshal.SizeOf(typeof(Hislip.Message)) + array.Length;
                packet = new byte[size];
                GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
                Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
                Buffer.BlockCopy(array, 0, packet, Marshal.SizeOf(typeof(Hislip.Message)), array.Length);
                gchw.Free();
            }
            else if (m_MessageType == Hislip.Error)
            {
                byte[] array = System.Text.Encoding.ASCII.GetBytes(m_Message);
                Hislip.Message reply = new Hislip.Message();
                reply.Prologue0 = 'H';
                reply.Prologue1 = 'S';
                reply.MessageType = m_MessageType;
                reply.ControlCode = m_ControlCode;
                reply.MessageParameter = 0;
                reply.PayloadLength = IPAddress.HostToNetworkOrder((long)array.Length);
                int size = Marshal.SizeOf(typeof(Hislip.Message)) + array.Length;
                packet = new byte[size];
                GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
                Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
                Buffer.BlockCopy(array, 0, packet, Marshal.SizeOf(typeof(Hislip.Message)), array.Length);
                gchw.Free();
            }
            else if (m_MessageType == Hislip.AsyncLockResponse_)
            {
                Hislip.AsyncLockResponse reply = new Hislip.AsyncLockResponse();
                reply.Prologue0 = 'H';
                reply.Prologue1 = 'S';
                reply.MessageType = m_MessageType;
                reply.ControlCode = m_ControlCode;
                reply.MessageParameter = 0;
                reply.PayloadLength = 0;
                int size = Marshal.SizeOf(typeof(Hislip.AsyncLockResponse));
                packet = new byte[size];
                GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
                Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
                gchw.Free();
            }
            else if (m_MessageType == Hislip.Data)
            {
                Hislip.Message reply = new Hislip.Message();
                reply.Prologue0 = 'H';
                reply.Prologue1 = 'S';
                reply.MessageType = m_MessageType;
                reply.ControlCode = m_ControlCode;
                reply.MessageParameter = IPAddress.HostToNetworkOrder(m_MessageID);
                reply.PayloadLength = IPAddress.HostToNetworkOrder((long)m_Message.Length);
                int size = Marshal.SizeOf(typeof(Hislip.Message)) + m_Message.Length;
                packet = new byte[size];
                GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
                Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
                byte[] array = System.Text.Encoding.ASCII.GetBytes(m_Message);
                Buffer.BlockCopy(array, 0, packet, Marshal.SizeOf(typeof(Hislip.Message)), array.Length);
                gchw.Free();
            }
            else if (m_MessageType == Hislip.DataEnd)
            {
                Hislip.Message reply = new Hislip.Message();
                reply.Prologue0 = 'H';
                reply.Prologue1 = 'S';
                reply.MessageType = m_MessageType;
                reply.ControlCode = m_ControlCode;
                reply.MessageParameter = IPAddress.HostToNetworkOrder(m_MessageParameter);
                reply.PayloadLength = IPAddress.HostToNetworkOrder((long)m_Message.Length);
                int size = Marshal.SizeOf(typeof(Hislip.Message)) + m_Message.Length;
                packet = new byte[size];
                GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
                Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
                byte[] array = System.Text.Encoding.ASCII.GetBytes(m_Message);
                Buffer.BlockCopy(array, 0, packet, Marshal.SizeOf(typeof(Hislip.Message)), array.Length);
                gchw.Free();
            }
            else if (m_MessageType == Hislip.AsyncDeviceClearAcknowledge)
            {
                Hislip.Message reply = new Hislip.Message();
                reply.Prologue0 = 'H';
                reply.Prologue1 = 'S';
                reply.MessageType = Hislip.AsyncDeviceClearAcknowledge;
                reply.ControlCode = m_Feature;
                reply.MessageParameter = 0;
                reply.PayloadLength = 0;
                int size = Marshal.SizeOf(typeof(Hislip.Message));
                packet = new byte[size];
                GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
                Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
                gchw.Free();
            }
            else if (m_MessageType == Hislip.DeviceClearAcknowledge)
            {
                Hislip.Message reply = new Hislip.Message();
                reply.Prologue0 = 'H';
                reply.Prologue1 = 'S';
                reply.MessageType = m_MessageType;
                reply.ControlCode = m_Feature;
                reply.MessageParameter = 0;
                reply.PayloadLength = 0;
                int size = Marshal.SizeOf(typeof(Hislip.Message));
                packet = new byte[size];
                GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
                Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
                gchw.Free();
            }
            else if (m_MessageType == Hislip.Interrupted)
            {
                Hislip.Message reply = new Hislip.Message();
                reply.Prologue0 = 'H';
                reply.Prologue1 = 'S';
                reply.MessageType = m_MessageType;
                reply.ControlCode = 0;
                reply.MessageParameter = IPAddress.HostToNetworkOrder(m_MessageID);
                reply.PayloadLength = 0;
                int size = Marshal.SizeOf(typeof(Hislip.Message));
                packet = new byte[size];
                GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
                Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
                gchw.Free();
            }
            else if (m_MessageType == Hislip.AsyncInterrupted)
            {
                Hislip.Message reply = new Hislip.Message();
                reply.Prologue0 = 'H';
                reply.Prologue1 = 'S';
                reply.MessageType = m_MessageType;
                reply.ControlCode = 0;
                reply.MessageParameter = IPAddress.HostToNetworkOrder(m_MessageID);
                reply.PayloadLength = 0;
                int size = Marshal.SizeOf(typeof(Hislip.Message));
                packet = new byte[size];
                GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
                Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
                gchw.Free();
            }
            else if (m_MessageType == Hislip.AsyncMaximumMessageSizeResponse)
            {
                byte[] array = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(m_MaximumMessageSize));
                Hislip.Message reply = new Hislip.Message();
                reply.Prologue0 = 'H';
                reply.Prologue1 = 'S';
                reply.MessageType = m_MessageType;
                reply.ControlCode = 0;
                reply.MessageParameter = 0;
                reply.PayloadLength = IPAddress.NetworkToHostOrder((long)array.Length);
                int size = Marshal.SizeOf(typeof(Hislip.Message)) + array.Length;
                packet = new byte[size];
                GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
                Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
                Buffer.BlockCopy(array, 0, packet, Marshal.SizeOf(typeof(Hislip.Message)), array.Length);
                gchw.Free();
            }
            else if (m_MessageType == Hislip.AsyncRemoteLocalResponse)
            {
                Hislip.Message reply = new Hislip.Message();
                reply.Prologue0 = 'H';
                reply.Prologue1 = 'S';
                reply.MessageType = m_MessageType;
                reply.ControlCode = 0;
                reply.MessageParameter = 0;
                reply.PayloadLength = 0;
                int size = Marshal.SizeOf(typeof(Hislip.Message));
                packet = new byte[size];
                GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
                Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
                gchw.Free();
            }
            else if (m_MessageType == Hislip.AsyncStatusResponse)
            {
                Hislip.Message reply = new Hislip.Message();
                reply.Prologue0 = 'H';
                reply.Prologue1 = 'S';
                reply.MessageType = m_MessageType;
                reply.ControlCode = m_Status;
                reply.MessageParameter = 0;
                reply.PayloadLength = 0;
                int size = Marshal.SizeOf(typeof(Hislip.Message));
                packet = new byte[size];
                GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
                Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
                gchw.Free();
            }
            else if (m_MessageType == Hislip.AsyncLockInfoResponse)
            {
                Hislip.Message reply = new Hislip.Message();
                reply.Prologue0 = 'H';
                reply.Prologue1 = 'S';
                reply.MessageType = m_MessageType;
                reply.ControlCode = m_ControlCode;
                reply.MessageParameter = 0;
                reply.PayloadLength = 0;
                int size = Marshal.SizeOf(typeof(Hislip.Message));
                packet = new byte[size];
                GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
                Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
                gchw.Free();
            }
            else
            {
                packet = new byte[0];
            }
            return packet;
        }
    };
}
