namespace Ivi.Visa
{
    public class VxiSignalProcessorEventArgs : VisaEventArgs
    {
        public VxiSignalProcessorEventArgs(EventType eventType) : base(eventType) { }
        //public VxiSignalProcessorEventArgs(Int32 statusId) { }
        public Int32 StatusId { get; private set; }
    }
    public class VxiTriggerEventArgs : VisaEventArgs
    {
        public VxiTriggerEventArgs(EventType eventType) : base(eventType) { }
        //public VxiTriggerEventArgs(TriggerLine triggerLine) { }
        public TriggerLine TriggerLine { get; private set; }
    }
    public class VxiInterruptEventArgs : VisaEventArgs
    {
        public VxiInterruptEventArgs(EventType eventType) : base(eventType) { }
        //public VxiInterruptEventArgs(Int16 irqLevel, Int32 statusId) { }
        public Int16 IrqLevel { get; private set; }
        public Int32 StatusId { get; private set; }
    }
    public interface IVxiSession : IMessageBasedSession, IRegisterBasedSession
    {
        event EventHandler<VxiInterruptEventArgs> Interrupt;
        event EventHandler<VxiSignalProcessorEventArgs> SignalProcessor;
        event EventHandler<VxiTriggerEventArgs> Trigger;
        Int16 CommanderLogicalAddress { get; }
        VxiAccessPrivilege DestinationAccessPrivilege { get; set; }
        ByteOrder DestinationByteOrder { get; set; }
        VxiDeviceClass DeviceClass { get; }
        Int16 FastDataChannelNumber { get; set; }
        Boolean FastDataChannelUseStreaming { get; set; }
        Boolean FastDataChannelUsePair { get; set; }
        Boolean Is4882Compliant { get; }
        Boolean IsImmediateServant { get; }
        Int16 LogicalAddress { get; }
        Int16 ChassisLogicalAddress { get; }
        Int16 ManufacturerId { get; }
        String ManufacturerName { get; }
        VxiAccessPrivilege MemoryMapAccessPrivilege { get; set; }
        ByteOrder MemoryMapByteOrder { get; set; }
        Int64 MemoryBase { get; }
        Int64 MemorySize { get; }
        AddressSpace MemorySpace { get; }
        ByteOrder SourceByteOrder { get; set; }
        Int16 ModelCode { get; }
        String ModelName { get; }
        Int16 Slot { get; }
        VxiAccessPrivilege SourceAccessPrivilege { get; set; }
        TriggerLine TriggerLine { get; set; }
        TriggerLines TriggerSupport { get; }
        void AssertTrigger(VxiTriggerProtocol protocol);
        Int32 CommandQuery(VxiCommandMode mode, Int32 command);
        Int64 MemoryAllocate(Int64 size);
        void MemoryFree(Int64 offset);
    }
    public interface IVxiMemorySession : IRegisterBasedSession
    {
        Int16 LogicalAddress { get; }
        void Move(AddressSpace sourceSpace,
        Int64 sourceOffset,
        DataWidth sourceWidth,
        AddressSpace destinationSpace,
        Int64 destinationOffset,
        DataWidth destinationWidth,
        Int64 sourceCount);
    }
    public interface IVxiBackplaneSession : IVisaSession
    {
        event EventHandler<VxiTriggerEventArgs> Trigger;
        event EventHandler<VisaEventArgs> SystemFailure;
        event EventHandler<VisaEventArgs> SystemReset;
        Int16 ChassisLogicalAddress { get; }
        TriggerLines TriggerStatus { get; }
        TriggerLines TriggerSupport { get; }
        Int16 InterruptStatus { get; }
        LineState SystemFailureStatus { get; }
        void AssertInterrupt(Int16 irqLevel, Int32 statusId);
        void AssertTrigger(TriggerLine line, VxiTriggerProtocol protocol);
        void AssertUtilitySignal(VxiUtilitySignal signal);
        void MapTrigger(TriggerLine sourceLine, TriggerLine destinationLine);
        void MapTrigger(TriggerLine sourceLine, TriggerLine destinationLine, out Boolean alreadyMapped);
        void UnmapTrigger(TriggerLine sourceLine);
        void UnmapTrigger(TriggerLine sourceLine, TriggerLine destinationLine);
    }
}