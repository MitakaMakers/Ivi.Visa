using System.Runtime.Serialization;
using System.Text;
using Vxi11Net;

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
}