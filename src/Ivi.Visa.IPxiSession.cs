using System.Runtime.Serialization;
using System.Text;
using Vxi11Net;

namespace Ivi.Visa
{
    public class PxiInterruptEventArgs : VisaEventArgs
    {
        public PxiInterruptEventArgs(EventType eventType) : base(eventType) { }
        //public PxiInterruptEventArgs(Int16 sequence, Int32 data) { }
        public Int16 Sequence { get; private set; }
        public Int32 Data { get; private set; }
    }
    public interface IPxiSession : IRegisterBasedSession
    {
        event EventHandler<PxiInterruptEventArgs> Interrupt;
        Int16 ActualLinkWidth { get; }
        Boolean AllowWriteCombining { get; set; }
        Int16 BusNumber { get; }
        Int16 ChassisNumber { get; }
        Int16 DeviceNumber { get; }
        Int16 DstarBusNumber { get; }
        Int16 DstarLineSet { get; }
        Int16 FunctionNumber { get; }
        Boolean IsExpress { get; }
        Int16 ManufacturerId { get; }
        String ManufacturerName { get; }
        Int16 MaxLinkWidth { get; }
        PxiMemoryType MemTypeBar0 { get; }
        PxiMemoryType MemTypeBar1 { get; }
        PxiMemoryType MemTypeBar2 { get; }
        PxiMemoryType MemTypeBar3 { get; }
        PxiMemoryType MemTypeBar4 { get; }
        PxiMemoryType MemTypeBar5 { get; }
        Int64 MemBaseBar0 { get; }
        Int64 MemBaseBar1 { get; }
        Int64 MemBaseBar2 { get; }
        Int64 MemBaseBar3 { get; }
        Int64 MemBaseBar4 { get; }
        Int64 MemBaseBar5 { get; }
        Int64 MemSizeBar0 { get; }
        Int64 MemSizeBar1 { get; }
        Int64 MemSizeBar2 { get; }
        Int64 MemSizeBar3 { get; }
        Int64 MemSizeBar4 { get; }
        Int64 MemSizeBar5 { get; }
        Int16 ModelCode { get; }
        String ModelName { get; }
        Int16 Slot { get; }
        Int16 SlotLinkWidth { get; }
        Int16 SlotLocalBusLeft { get; }
        Int16 SlotLocalBusRight { get; }
        String SlotPath { get; }
        Int16 StarTriggerBus { get; }
        Int16 StarTriggerLine { get; }
        Int16 TriggerBus { get; }
        void ReserveTrigger(TriggerLine line);
        void UnreserveTrigger(TriggerLine line);
    }
    public interface IPxiSession2 : IPxiSession
    {
        Int16 SlotWidth { get; }
        Int16 SlotOffset { get; }
    }
    public interface IPxiMemorySession : IRegisterBasedSession
    {
        Int64 MemoryAllocate(Int64 size);
        Int64 MemoryAllocate(Int64 size, Boolean require32BitRegion);
        void MemoryFree(Int64 offset);
    }
    public interface IPxiBackplaneSession : IVisaSession
    {
        Int16 ChassisNumber { get; }
        String ManufacturerName { get; }
        String ModelName { get; }
        void ReserveTrigger(Int16 bus, TriggerLine line);
        void ReserveTriggers(Int16[] buses, TriggerLine[] lines);
        void UnreserveTrigger(Int16 bus, TriggerLine line);
        void MapTrigger(Int16 sourceBus, TriggerLine sourceLine, Int16 destinationBus, TriggerLine destinationLine);
        void MapTrigger(Int16 sourceBus, TriggerLine sourceLine, Int16 destinationBus, TriggerLine destinationLine, out Boolean alreadyMapped);
        void UnmapTrigger(Int16 sourceBus, TriggerLine sourceLine);
        void UnmapTrigger(Int16 sourceBus, TriggerLine sourceLine, Int16 destinationBus, TriggerLine destinationLine);
    }
}