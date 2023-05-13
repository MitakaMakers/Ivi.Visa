using System.Runtime.Serialization;

namespace Ivi.Visa
{
    public interface INativeVisaEventArgs : IDisposable
    {
        VisaEventArgs EventArgs { get; }
        Byte GetAttributeByte(NativeVisaAttribute attribute);
        Byte GetAttributeByte(Int32 attribute);
        Int16 GetAttributeInt16(NativeVisaAttribute attribute);
        Int16 GetAttributeInt16(Int32 attribute);
        Int32 GetAttributeInt32(NativeVisaAttribute attribute);
        Int32 GetAttributeInt32(Int32 attribute);
        Int64 GetAttributeInt64(NativeVisaAttribute attribute);
        Int64 GetAttributeInt64(Int32 attribute);
        Boolean GetAttributeBoolean(NativeVisaAttribute attribute);
        Boolean GetAttributeBoolean(Int32 attribute);
        String GetAttributeString(NativeVisaAttribute attribute);
        String GetAttributeString(Int32 attribute);
    }
    public interface IVisaSession : IDisposable
    {
        Int32 TimeoutMilliseconds { get; set; }
        String ResourceName { get; }
        String HardwareInterfaceName { get; }
        HardwareInterfaceType HardwareInterfaceType { get; }
        Int16 HardwareInterfaceNumber { get; }
        String ResourceClass { get; }
        String ResourceManufacturerName { get; }
        Int16 ResourceManufacturerId { get; }
        Version ResourceImplementationVersion { get; }
        Version ResourceSpecificationVersion { get; }
        ResourceLockState ResourceLockState { get; }
        void LockResource();
        void LockResource(TimeSpan timeout);
        void LockResource(Int32 timeoutMilliseconds);
        string LockResource(TimeSpan timeout, String sharedKey);
        string LockResource(Int32 timeoutMilliseconds, String sharedKey);
        void UnlockResource();
        Int32 EventQueueCapacity { get; set; }
        Boolean SynchronizeCallbacks { get; set; }
        void EnableEvent(EventType eventType);
        void DisableEvent(EventType eventType);
        void DiscardEvent(EventType eventType);
        VisaEventArgs WaitOnEvent(EventType eventType);
        VisaEventArgs WaitOnEvent(EventType eventType, out EventQueueStatus status);
        VisaEventArgs WaitOnEvent(EventType eventType, Int32 timeoutMilliseconds);
        VisaEventArgs WaitOnEvent(EventType eventType, TimeSpan timeout);
        VisaEventArgs WaitOnEvent(EventType eventType, Int32 timeoutMilliseconds, out EventQueueStatus status);
        VisaEventArgs WaitOnEvent(EventType eventType, TimeSpan timeout, out EventQueueStatus status);
    }
    public interface INativeVisaSession : IVisaSession
    {
        Int32 Handle { get; }
        void EnableEvent(Int32 eventType);
        void DisableEvent(Int32 eventType);
        void DiscardEvents(Int32 eventType);
        INativeVisaEventArgs WaitOnEvent(Int32 eventType);
        INativeVisaEventArgs WaitOnEvent(Int32 eventType, out EventQueueStatus status);
        INativeVisaEventArgs WaitOnEvent(Int32 eventType, Int32 timeoutMilliseconds);
        INativeVisaEventArgs WaitOnEvent(Int32 eventType, TimeSpan timeout);
        INativeVisaEventArgs WaitOnEvent(Int32 eventType, Int32 timeoutMilliseconds, out EventQueueStatus status);
        INativeVisaEventArgs WaitOnEvent(Int32 eventType, TimeSpan timeout, out EventQueueStatus status);
        Byte GetAttributeByte(NativeVisaAttribute attribute);
        Byte GetAttributeByte(Int32 attribute);
        Int16 GetAttributeInt16(NativeVisaAttribute attribute);
        Int16 GetAttributeInt16(Int32 attribute);
        Int32 GetAttributeInt32(NativeVisaAttribute attribute);
        Int32 GetAttributeInt32(Int32 attribute);
        Int64 GetAttributeInt64(NativeVisaAttribute attribute);
        Int64 GetAttributeInt64(Int32 attribute);
        Boolean GetAttributeBoolean(NativeVisaAttribute attribute);
        Boolean GetAttributeBoolean(Int32 attribute);
        String GetAttributeString(NativeVisaAttribute attribute);
        String GetAttributeString(Int32 attribute);
        void SetAttributeByte(NativeVisaAttribute attribute, Byte value);
        void SetAttributeByte(Int32 attribute, Byte value);
        void SetAttributeInt16(NativeVisaAttribute attribute, Int16 value);
        void SetAttributeInt16(Int32 attribute, Int16 value);
        void SetAttributeInt32(NativeVisaAttribute attribute, Int32 value);
        void SetAttributeInt32(Int32 attribute, Int32 value);
        void SetAttributeInt64(NativeVisaAttribute attribute, Int64 value);
        void SetAttributeInt64(Int32 attribute, Int64 value);
        void SetAttributeBoolean(NativeVisaAttribute attribute, Boolean value);
        void SetAttributeBoolean(Int32 attribute, Boolean value);
        void SetAttributeString(NativeVisaAttribute attribute, String value);
        void SetAttributeString(Int32 attribute, String value);
    }
}