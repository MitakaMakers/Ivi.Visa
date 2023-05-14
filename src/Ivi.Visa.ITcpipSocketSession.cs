using System.Drawing;
using System.Runtime.Serialization;
using System.Text;
using Vxi11Net;

namespace Ivi.Visa
{
    public interface ITcpipSocketSession : IMessageBasedSession
    {
        String Address { get; }
        String HostName { get; }
        Boolean KeepAlive { get; set; }
        Boolean NoDelay { get; set; }
        Int16 Port { get; }
        void Flush(IOBuffers buffers, Boolean discard);
        Boolean SetBufferSize(IOBuffers buffers, Int32 size);
    }
    public interface ITcpipSocketSession2 : ITcpipSocketSession
    {
        String ServerCertificate { get; }
        System.DateTime ServerCertificateExpirationDate { get; }
        Boolean ServerCertificateIsPerpetual { get; }
        String ServerCertificateIssuerName { get; }
        String ServerCertificateSubjectName { get; }
        String TlsCipherSuite { get; }
    }
    public class TcpipSocketSession : ITcpipSocketSession
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
        private ClientSocket client = new ClientSocket();
        public static void ServiceRequestHandler(object? sender, VisaEventArgs args)
        {
            return;
        }
        public TcpipSocketSession(string address, string port)
        {
            Address = address;
            HostName = address;
            Port = Int16.Parse(port);
            client.Create(Address, Port);
            this.FormattedIO = new FormattedIO488(this);
            this.RawIO = new RawIO488(this);
            this.ServiceRequest = ServiceRequestHandler;
        }
        public int Read(string buf, int count, out int retCount)
        {
            byte[] data = new byte[count];
            client.Receive(data);
            buf = System.Text.Encoding.ASCII.GetString(data);
            retCount = buf.Length;
            return 0;
        }
        public int Write(string buf, int count, out int retCount)
        {
            byte[] buff = System.Text.Encoding.ASCII.GetBytes(buf);
            retCount = client.Send(buff);
            return 0;
        }
        public int Terminate()
        {
            return 0;
        }
    }
}