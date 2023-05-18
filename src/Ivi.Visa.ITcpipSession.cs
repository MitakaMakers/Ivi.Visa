using System;
using System.Runtime.Serialization;
using System.Text;
using Vxi11Net;

#nullable enable
#nullable disable
namespace Ivi.Visa
{
    public interface ITcpipSession : IMessageBasedSession
    {
        String Address { get; }
        String DeviceName { get; }
        String HostName { get; }
        Int16 Port { get; }
        Boolean IsHiSLIP { get; }
        Boolean HiSLIPOverlapEnabled { get; set; }
        Version HiSLIPProtocolVersion { get; }
        Int32 HiSLIPMaximumMessageKBytes { get; set; }
        Boolean SetBufferSize(IOBuffers buffers, Int32 size);
        void SendRemoteLocalCommand(RemoteLocalMode mode);
    }

    public interface ITcpipSession2 : ITcpipSession
    {
        Boolean EncryptionEnabled { get; set; }
        String SaslMechanism { get; }
        String ServerCertificate { get; }
        System.DateTime ServerCertificateExpirationDate { get; }
        Boolean ServerCertificateIsPerpetual { get; }
        String ServerCertificateIssuerName { get; }
        String ServerCertificateSubjectName { get; }
        String TlsCipherSuite { get; }
    }

    public class Vxi11Session : ITcpipSession
    {
        public const int default_timeout_value = 2000;
        public Int32 TimeoutMilliseconds { get; set; }
        public String ResourceName { get; } = string.Empty;
        public String HardwareInterfaceName { get; } = string.Empty;
        public HardwareInterfaceType HardwareInterfaceType { get; }
        public Int16 HardwareInterfaceNumber { get; }
        public String ResourceClass { get; } = string.Empty;
        public String ResourceManufacturerName { get; } = string.Empty;
        public Int16 ResourceManufacturerId { get; }
        public Version ResourceImplementationVersion { get; } = Environment.Version;
        public Version ResourceSpecificationVersion { get; } = Environment.Version;
        public ResourceLockState ResourceLockState { get; }

        public event EventHandler<VisaEventArgs> ServiceRequest;

        public void LockResource() { }
        public void LockResource(TimeSpan timeout) { }
        public void LockResource(Int32 timeoutMilliseconds) { }
        public string LockResource(TimeSpan timeout, String sharedKey) { return ""; }
        public string LockResource(Int32 timeoutMilliseconds, String sharedKey) { return ""; }
        public void UnlockResource() { }
        public Int32 EventQueueCapacity { get; set; }
        public Boolean SynchronizeCallbacks { get; set; }
        public void EnableEvent(EventType eventType) { }
        public void DisableEvent(EventType eventType) { }
        public void DiscardEvent(EventType eventType) { }
        public VisaEventArgs WaitOnEvent(EventType eventType)
        {
            return new VisaEventArgs(EventType.Custom);
        }
        public VisaEventArgs WaitOnEvent(EventType eventType, out EventQueueStatus status)
        {
            status = EventQueueStatus.Empty;
            return new VisaEventArgs(EventType.Custom);
        }
        public VisaEventArgs WaitOnEvent(EventType eventType, Int32 timeoutMilliseconds)
        {
            return new VisaEventArgs(EventType.Custom);
        }
        public VisaEventArgs WaitOnEvent(EventType eventType, TimeSpan timeout)
        {
            return new VisaEventArgs(EventType.Custom);
        }
        public VisaEventArgs WaitOnEvent(EventType eventType, Int32 timeoutMilliseconds, out EventQueueStatus status)
        {
            status = EventQueueStatus.Empty;
            return new VisaEventArgs(EventType.Custom);
        }
        public VisaEventArgs WaitOnEvent(EventType eventType, TimeSpan timeout, out EventQueueStatus status)
        {
            status = EventQueueStatus.Empty;
            return new VisaEventArgs(EventType.Custom);
        }
        public void Dispose()
        {
            client.Destroy();
        }

        public String Address { get; } = string.Empty;
        public String HostName { get; } = string.Empty;
        public Boolean KeepAlive { get; set; }
        public Boolean NoDelay { get; set; }
        public Int16 Port { get; }
        public void Flush(IOBuffers buffers, Boolean discard) { }
        public Boolean SetBufferSize(IOBuffers buffers, Int32 size) { return true; }
        public IOProtocol IOProtocol { get; set; }
        public Boolean SendEndEnabled { get; set; }
        public Byte TerminationCharacter { get; set; }
        public Boolean TerminationCharacterEnabled { get; set; }
        public void AssertTrigger() { }
        public void Clear() { }
        public StatusByteFlags ReadStatusByte()
        {
            throw new NotImplementedException();
        }
        public IMessageBasedFormattedIO FormattedIO { get; }
        public IMessageBasedRawIO RawIO { get; }

        string ITcpipSession.DeviceName => throw new NotImplementedException();

        bool ITcpipSession.IsHiSLIP => throw new NotImplementedException();

        bool ITcpipSession.HiSLIPOverlapEnabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        Version ITcpipSession.HiSLIPProtocolVersion => throw new NotImplementedException();

        int ITcpipSession.HiSLIPMaximumMessageKBytes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private ClientVxi11 client = new ClientVxi11();

        private int lock_timeout = default_timeout_value;
        private int io_timeout = default_timeout_value;
        private int lid;
        private int abortPort;
        private int maxRecvSize;
#nullable enable
        public static void ServiceRequestHandler(object? sender, VisaEventArgs args)
        {
            return;
        }
#nullable disable
        public Vxi11Session(string address, string deviceName)
        {
            ClientPortmapTcp clientPmap = new ClientPortmapTcp();
            clientPmap.Create(address, 111);
            int port = clientPmap.GetPort(Vxi11.DEVICE_CORE_PROG, Vxi11.DEVICE_CORE_VERSION, Portmap.IPPROTO.TCP);
            this.Port = (short)port;
            this.Address = address;
            client.Create(address, port);

            int clientId = 0;
            int lockDevice = 0;
            client.CreateLink(clientId, lockDevice, this.lock_timeout, deviceName, out this.lid, out this.abortPort, out this.maxRecvSize);

            this.FormattedIO = new FormattedIO488(this);
            this.RawIO = new RawIO488(this);
            this.ServiceRequest = ServiceRequestHandler;
        }
        public int Read(string buf, int count, out int retCount)
        {
            Vxi11.Flag flags = Vxi11.Flag.end;
            Vxi11.TermChar term = Vxi11.TermChar.None;
            int reason = 0;
            byte[] data = new byte[count];
            client.DeviceRead(this.lid, count, flags, this.lock_timeout, this.io_timeout, term, out reason, out data);
            retCount = data.Length;
            return 0;
        }
        public int Write(string buf, int count, out int retCount)
        {
            Vxi11.Flag flags = Vxi11.Flag.end;
            client.DeviceWrite(this.lid, flags, this.lock_timeout, this.io_timeout, buf, out retCount);
            return 0;
        }
        public int Terminate()
        {
            client.Create(this.Address, this.abortPort);
            Vxi11.Flag flags = Vxi11.Flag.end;
            client.DeviceAbort(this.lid, flags, this.lock_timeout, this.io_timeout);
            return 0;
        }

        void ITcpipSession.SendRemoteLocalCommand(RemoteLocalMode mode)
        {
            throw new NotImplementedException();
        }
    }
}
