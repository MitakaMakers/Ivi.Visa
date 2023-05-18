using System;
using System.Text;

namespace Ivi.Visa
{
    public interface VisaAsyncCallback
    {
        Boolean IsAborted { get; }
    }
    public interface IVisaAsyncResult : IAsyncResult
    {
        Boolean IsAborted { get; }
        Byte[] Buffer { get; }
        Int64 Count { get; }
        Int64 Index { get; }
    }
    public interface ITypeFormatter
    {
        Boolean IsSupported(Type type);
        String ToString(Object obj);
        Object Parse(Type type, String data);
    }
    public interface IMessageBasedSession : IVisaSession
    {
        event EventHandler<VisaEventArgs> ServiceRequest;
        IOProtocol IOProtocol { get; set; }
        Boolean SendEndEnabled { get; set; }
        Byte TerminationCharacter { get; set; }
        Boolean TerminationCharacterEnabled { get; set; }
        void AssertTrigger();
        void Clear();
        StatusByteFlags ReadStatusByte();
        IMessageBasedFormattedIO FormattedIO { get; }
        IMessageBasedRawIO RawIO { get; }
    }
}