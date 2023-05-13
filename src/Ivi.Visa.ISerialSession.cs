using System.Runtime.Serialization;
using System.Text;
using Vxi11Net;

namespace Ivi.Visa
{
    public interface ISerialSession : IMessageBasedSession
    {
        Int32 BytesAvailable { get; }
        Int32 BaudRate { get; set; }
        LineState ClearToSendState { get; }
        Int16 DataBits { get; set; }
        LineState DataCarrierDetectState { get; }
        LineState DataSetReadyState { get; }
        LineState DataTerminalReadyState { get; set; }
        SerialFlowControlModes FlowControl { get; set; }
        SerialParity Parity { get; set; }
        SerialTerminationMethod ReadTermination { get; set; }
        Byte ReplacementCharacter { get; set; }
        LineState RequestToSendState { get; set; }
        LineState RingIndicatorState { get; }
        SerialStopBitsMode StopBits { get; set; }
        SerialTerminationMethod WriteTermination { get; set; }
        Byte XOffCharacter { get; set; }
        Byte XOnCharacter { get; set; }
        void Flush(IOBuffers buffers, Boolean discard);
        Boolean SetBufferSize(IOBuffers buffers, Int32 size);
    }
}