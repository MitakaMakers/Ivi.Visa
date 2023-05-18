using System;

namespace Ivi.Visa
{
    public class UsbInterruptEventArgs : VisaEventArgs
    {
        public UsbInterruptEventArgs(EventType eventType) : base(eventType)
        {
            Data = new byte[0];
        }
        //public UsbInterruptEventArgs(Boolean exceededMaximumSize, Byte[] data) { }
        public Boolean ExceededMaximumSize { get; private set; }
        public Byte[] Data { get; private set; }
    }
    public interface IUsbSession : IMessageBasedSession
    {
        event EventHandler<UsbInterruptEventArgs> Interrupt;
        Boolean Is4882Compliant { get; }
        Int16 MaximumInterruptSize { get; set; }
        Int16 ManufacturerId { get; }
        String ManufacturerName { get; }
        Int16 ModelCode { get; }
        String ModelName { get; }
        Int16 UsbInterfaceNumber { get; }
        Int16 UsbProtocol { get; }
        String UsbSerialNumber { get; }
        Byte[] ControlIn(Int16 requestType, Int16 request, Int16 value, Int16 index, Int16 length);
        void ControlOut(Int16 requestType, Int16 request, Int16 value, Int16 index);
        void ControlOut(Int16 requestType, Int16 request, Int16 value, Int16 index, Byte[] data);
        void SendRemoteLocalCommand(RemoteLocalMode mode);
    }
}