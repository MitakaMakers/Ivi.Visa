using System;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace Vxi11Net
{
    public class HislipListenerRequest
    {
        private char m_Prologue0;
        private char m_Prologue1;
        private byte m_MessageType;
        private byte m_ControlCode;
        private short m_Version;
        private short m_VendorID;
        private ulong m_PayloadLength;
        private uint m_MessageParameter;
        private byte[] m_Payload;
        private ulong m_MaxMessageSize;
        private HislipListenerContext m_HislipListenerContext;

        internal HislipListenerRequest(HislipListenerContext context, ulong MaximumMessageSize)
        {
            m_HislipListenerContext = context;
            m_MaxMessageSize = MaximumMessageSize;
            m_Payload = new byte[m_MaxMessageSize];
        }
        public byte[] Payload
        {
            get
            {
                return m_Payload;
            }
            set
            {
                if (Payload != null)
                {
                    m_MaxMessageSize = (ulong)Payload.Length;
                    m_Payload = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value");
                }
            }
        }
        public String PayloadAsString
        {
            get
            {
                byte[] dest = new byte[m_PayloadLength];
                Buffer.BlockCopy(m_Payload, 0, dest, 0, (int)m_PayloadLength);
                string text = System.Text.Encoding.UTF8.GetString(dest);
                return text;
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
        public short Version
        {
            get
            {
                return m_Version;
            }
            set
            {
                if (value >= 0)
                {
                    m_Version = value;
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
        public uint MessageParameter
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
        public Stream InputStream
        {
            get
            {
                return m_HislipListenerContext.RequestStream;
            }
        }
    }
}