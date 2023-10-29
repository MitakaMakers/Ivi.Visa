using System;
using System.IO;
using System.Net;
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
        private ushort m_ServerVersion;
        private ushort m_VendorID;
        private ulong m_PayloadLength;
        private ushort m_ProtocolVersion;
        private ushort m_SessionID;
        private ushort m_ServerID;
        private uint m_MessageID;
        private int m_MessageParameter;
        private ulong m_MaximumMessageSize;
        private byte[] m_Payload;
        private HislipListenerContext m_HislipListenerContext;

        internal HislipListenerResponse(HislipListenerContext context)
        {
            m_ResponseState = ResponseState.Created;
            m_PayloadLength = 0;
            m_Payload = new byte[0];
            m_HislipListenerContext = context;
        }
        public static ushort HostToNetworkOrderUInt16(ushort v)
        {
            ushort u = 0;
            u += (ushort)((v & 0x00FF) << 8);
            u += (ushort)((v & 0xFF00) >> 8);
            return u;
        }
        public static uint HostToNetworkOrderUInt32(uint v)
        {
            uint u = 0;
            u += ((v & 0x000000FF) << 24);
            u += ((v & 0x0000FF00) << 8);
            u += ((v & 0x00FF0000) >> 8);
            u += ((v & 0xFF000000) >> 24);
            return u;
        }
        public static ulong HostToNetworkOrderUInt64(ulong v)
        {
            ulong u = 0;
            u += ((v & 0x00000000000000FF) << 56);
            u += ((v & 0x000000000000FF00) << 40);
            u += ((v & 0x0000000000FF0000) << 24);
            u += ((v & 0x00000000FF000000) << 8);
            u += ((v & 0x000000FF00000000) >> 8);
            u += ((v & 0x0000FF0000000000) >> 24);
            u += ((v & 0x00FF000000000000) >> 40);
            u += ((v & 0xFF00000000000000) >> 56);
            return u;
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
        public ushort ServerVersion
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
        public ushort ServerID
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
        public ushort VendorID
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
        public ushort ProtocolVersion
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
                    throw new ArgumentOutOfRangeException("value");
                }
            }
        }
        public uint MessageID
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
        public ulong PayloadLength
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
                    m_PayloadLength = (ulong)value.Length;
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
                reply.Protocol = HostToNetworkOrderUInt16(m_ServerVersion);
                reply.SessionID = HostToNetworkOrderUInt16(m_SessionID);
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
                reply.ServerID = HostToNetworkOrderUInt16(VendorID);
                reply.PayloadLength = 0;
                int size = Marshal.SizeOf(typeof(Hislip.AsyncInitializeResponse));
                packet = new byte[size];
                GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
                Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
                gchw.Free();
            }
            else if (m_MessageType == Hislip.FatalError)
            {
                Hislip.Data reply = new Hislip.Data();
                reply.Prologue0 = 'H';
                reply.Prologue1 = 'S';
                reply.MessageType = m_MessageType;
                reply.ControlCode = m_ControlCode;
                reply.MessageID = 0;
                reply.PayloadLength = HostToNetworkOrderUInt64(m_PayloadLength);
                int size = Marshal.SizeOf(typeof(Hislip.Message)) + (int)m_PayloadLength;
                packet = new byte[size];
                GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
                Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
                Buffer.BlockCopy(m_Payload, 0, packet, Marshal.SizeOf(typeof(Hislip.Message)), (int)m_PayloadLength);
                gchw.Free();
            }
            else if (m_MessageType == Hislip.Error)
            {
                Hislip.Data reply = new Hislip.Data();
                reply.Prologue0 = 'H';
                reply.Prologue1 = 'S';
                reply.MessageType = m_MessageType;
                reply.ControlCode = m_ControlCode;
                reply.MessageID = 0;
                reply.PayloadLength = HostToNetworkOrderUInt64(m_PayloadLength);
                int size = Marshal.SizeOf(typeof(Hislip.Message)) + (int)m_PayloadLength;
                packet = new byte[size];
                GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
                Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
                Buffer.BlockCopy(m_Payload, 0, packet, Marshal.SizeOf(typeof(Hislip.Message)), (int)m_PayloadLength);
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
            else if (m_MessageType == Hislip.Data_)
            {
                Hislip.Data reply = new Hislip.Data();
                reply.Prologue0 = 'H';
                reply.Prologue1 = 'S';
                reply.MessageType = m_MessageType;
                reply.ControlCode = m_ControlCode;
                reply.MessageID = HostToNetworkOrderUInt32(m_MessageID);
                reply.PayloadLength = HostToNetworkOrderUInt64(m_PayloadLength);
                int size = Marshal.SizeOf(typeof(Hislip.Message)) + (int)m_PayloadLength;
                packet = new byte[size];
                GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
                Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
                Buffer.BlockCopy(m_Payload, 0, packet, Marshal.SizeOf(typeof(Hislip.Message)), (int)m_PayloadLength);
                gchw.Free();
            }
            else if (m_MessageType == Hislip.DataEnd)
            {
                Hislip.Data reply = new Hislip.Data();
                reply.Prologue0 = 'H';
                reply.Prologue1 = 'S';
                reply.MessageType = m_MessageType;
                reply.ControlCode = m_ControlCode;
                reply.MessageID = HostToNetworkOrderUInt32(m_MessageID);
                reply.PayloadLength = HostToNetworkOrderUInt64(m_PayloadLength);
                int size = Marshal.SizeOf(typeof(Hislip.Message)) + (int)m_PayloadLength;
                packet = new byte[size];
                GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
                Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
                Buffer.BlockCopy(m_Payload, 0, packet, Marshal.SizeOf(typeof(Hislip.Message)), (int)m_PayloadLength);
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
                Hislip.Data reply = new Hislip.Data();
                reply.Prologue0 = 'H';
                reply.Prologue1 = 'S';
                reply.MessageType = m_MessageType;
                reply.ControlCode = 0;
                reply.MessageID = HostToNetworkOrderUInt32(m_MessageID);
                reply.PayloadLength = 0;
                int size = Marshal.SizeOf(typeof(Hislip.Message));
                packet = new byte[size];
                GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
                Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
                gchw.Free();
            }
            else if (m_MessageType == Hislip.AsyncInterrupted)
            {
                Hislip.Data reply = new Hislip.Data();
                reply.Prologue0 = 'H';
                reply.Prologue1 = 'S';
                reply.MessageType = m_MessageType;
                reply.ControlCode = 0;
                reply.MessageID = HostToNetworkOrderUInt32(m_MessageID);
                reply.PayloadLength = 0;
                int size = Marshal.SizeOf(typeof(Hislip.Message));
                packet = new byte[size];
                GCHandle gchw = GCHandle.Alloc(packet, GCHandleType.Pinned);
                Marshal.StructureToPtr(reply, gchw.AddrOfPinnedObject(), false);
                gchw.Free();
            }
            else if (m_MessageType == Hislip.AsyncMaximumMessageSizeResponse)
            {
                byte[] array = BitConverter.GetBytes(HostToNetworkOrderUInt64(m_MaximumMessageSize));
                Hislip.Data reply = new Hislip.Data();
                reply.Prologue0 = 'H';
                reply.Prologue1 = 'S';
                reply.MessageType = m_MessageType;
                reply.ControlCode = 0;
                reply.MessageID = 0;
                reply.PayloadLength = HostToNetworkOrderUInt64((ulong)array.Length);
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
