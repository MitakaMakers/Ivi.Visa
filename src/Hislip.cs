using System.Runtime.InteropServices;

namespace Vxi11Net
{
    public class Hislip
    {
        public const int PORT = 4880;

        public const int Initialize = 0;
        public const int InitializeResponse = 1;
        public const int FatalError = 2;
        public const int Error = 3;
        public const int AsyncLock = 4;
        public const int AsyncLockResponse = 5;
        public const int Data = 6;
        public const int DataEnd = 7;
        public const int DeviceClearComplete = 8;
        public const int DeviceClearAcknowledge = 9;
        public const int AsyncRemoteLocalControl = 10;
        public const int AsyncRemoteLocalResponse = 11;
        public const int Trigger = 12;
        public const int Interrupted = 13;
        public const int AsyncInterrupted = 14;
        public const int AsyncMaximumMessageSize = 15;
        public const int AsyncMaximumMessageSizeResponse = 16;
        public const int AsyncInitialize = 17;
        public const int AsyncInitializeResponse = 18;
        public const int AsyncDeviceClear = 19;
        public const int AsyncServiceRequest = 20;
        public const int AsyncStatusQuery = 21;
        public const int AsyncStatusResponse = 22;
        public const int AsyncDeviceClearAcknowledge = 23;
        public const int AsyncLockInfo = 24;
        public const int AsyncLockInfoResponse = 25;
        public const int GetDescriptors = 26;
        public const int GetDescriptorsResponse = 27;
        public const int StartTLS = 28;
        public const int AsyncStartTLS = 29;
        public const int AsyncStartTLSResponse = 30;
        public const int EndTLS = 31;
        public const int AsyncEndTLS = 32;
        public const int AsyncEndTLSResponse = 33;
        public const int GetSaslMechanismList = 34;
        public const int GetSaslMechanismListResponse = 35;
        public const int AuthenticationStart = 36;
        public const int AuthenticationExchange = 37;
        public const int AuthenticationResult = 38;

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct MessageHeader
        {
            public char Prologue0;
            public char Prologue1;
            public byte MessageType;
            public byte ControlCode;
            public int MessageParameter;
            public long PayloadLength;
            public byte Data;
        };
    }
}