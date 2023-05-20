using System;

namespace Ivi.Visa
{
    public class GpibControllerInChargeEventArgs : VisaEventArgs
    {
        public GpibControllerInChargeEventArgs(EventType eventType) : base(eventType) { }
        // public GpibControllerInChargeEventArgs(Boolean isControllerInCharge) { }
        public Boolean IsControllerInCharge { get; private set; }
    }
    public interface IGpibSession : IMessageBasedSession
    {
        Boolean AllowDma { get; set; }
        Int16 PrimaryAddress { get; }
        Boolean ReaddressingEnabled { get; set; }
        LineState RenState { get; }
        Int16 SecondaryAddress { get; }
        Boolean UnaddressingEnabled { get; set; }
        void SendRemoteLocalCommand(RemoteLocalMode mode);
        void SendRemoteLocalCommand(GpibInstrumentRemoteLocalMode mode);
    }
    public interface IGpibInterfaceSession : IVisaSession
    {
        event EventHandler<VisaEventArgs> Cleared;
        event EventHandler<GpibControllerInChargeEventArgs> ControllerInCharge;
        event EventHandler<VisaEventArgs> Listen;
        event EventHandler<VisaEventArgs> ServiceRequest;
        event EventHandler<VisaEventArgs> Talk;
        event EventHandler<VisaEventArgs> Trigger;
        GpibAddressedState AddressState { get; }
        Boolean AllowDma { get; set; }
        LineState AtnState { get; }
        Int16 HS488CableLength { get; set; }
        Byte DeviceStatusByte { get; set; }
        IOProtocol IOProtocol { get; set; }
        Boolean IsControllerInCharge { get; }
        Boolean IsSystemController { get; set; }
        LineState NdacState { get; }
        Int16 PrimaryAddress { get; set; }
        LineState RenState { get; }
        Int16 SecondaryAddress { get; set; }
        public bool SendEndEnabled { get; set; }
        LineState SrqState { get; }
        public byte TerminationCharacter { get; set; }
        public bool TerminationCharacterEnabled { get; set; }
        public void AssertTrigger();
        void PassControl(Int16 primaryAddress);
        void PassControl(Int16 primaryAddress, Int16 secondaryAddress);
        void ControlAtn(AtnMode command);
        Int32 SendCommand(Byte[] data);
        void SendRemoteLocalCommand(GpibInterfaceRemoteLocalMode mode);
        void SendInterfaceClear();
        IMessageBasedRawIO RawIO { get; }
    }
}