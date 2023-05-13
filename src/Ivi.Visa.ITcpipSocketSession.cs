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
}