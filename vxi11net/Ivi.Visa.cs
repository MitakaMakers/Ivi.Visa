using System;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text;
using Vxi11Net;

namespace Ivi.Visa
{
    public enum ApiType
    {
        CAndCom = 0,
        DotNet = 1
    }
    public enum FlushBehavior
    {
        OverwriteAlways = 0,
        WriteIfFileOnDiskUnchanged = 1,
        WriteOrReload = 2
    }
    public enum HandlerType
    {
        NotChosen = 0,
        ChosenByResourceManager = 1,
        ChosenByUser = 2
    }
    public sealed class HardwareInterface : IEquatable<HardwareInterface>
    {
        public Int16 Number { get; private set; }
        public String ResourceClass { get; private set; } = String.Empty;
        public Int32 Type { get; private set; }
        public HardwareInterface(Int32 type, Int16 number, String resourceClass) {}
        public static Boolean operator ==(HardwareInterface intf1, HardwareInterface intf2)
        {
            throw new NotImplementedException();
        }
        public static Boolean operator !=(HardwareInterface intf1, HardwareInterface intf2)
        {
            throw new NotImplementedException();
        }
        public override Boolean Equals(object? o)
        {
            throw new NotImplementedException();
        }
        public Boolean Equals(HardwareInterface? other)
        {
            throw new NotImplementedException();
        }
        public override int GetHashCode() { return 0; }
    }
    public sealed class VisaImplementation : IEquatable<VisaImplementation>
    {
        public ApiType ApiType { get; private set; }
        public String Comments { get; private set; } = String.Empty;    
        public Boolean Enabled { get; set; }
        public String FriendlyName { get; private set; } = String.Empty;
        public Guid HandlerId { get; private set; }
        public String Location { get; private set; } = String.Empty;
        public Int32 ResourceManufacturerId { get; private set; }
        public VisaImplementation(Guid handlerId, Int32 resourceManufacturerId, String location, String friendlyName, String comments, ApiType apiType) {}
        public static Boolean operator ==(VisaImplementation visa1, VisaImplementation visa2)
        {
            throw new NotImplementedException();
        }
        public static Boolean operator !=(VisaImplementation visa1, VisaImplementation visa2)
        {
            throw new NotImplementedException();
        }
        public override Boolean Equals(object? o)
        {
            throw new NotImplementedException();
        }
        public Boolean Equals(VisaImplementation? other)
        {
            throw new NotImplementedException();
        }
        public override int GetHashCode() { return 0; }
    }
    public sealed class ConflictManager : IDisposable
    {
        public Boolean StoreConflictsOnly { get; set; }
        public String ConflictFilePath { get; } = String.Empty;
        public Boolean IsDirty { get; }
        public ConflictManager() {}
        ~ConflictManager() {}
        public void Dispose() {}
        public void ClearTable() {}
        public void CreateHandler(HardwareInterface intf, VisaImplementation visa, HandlerType type) {}
        public void CreateHandler(HardwareInterface intf, VisaImplementation visa, HandlerType type, String comments) {}
        public void FlushConflictFile(FlushBehavior behavior) {}
        public void FlushConflictFile(FlushBehavior behavior, out Boolean fileOnDiskWasNewer)
        {
            throw new NotImplementedException();
        }
        public VisaImplementation GetChosenHandler(ApiType apiType, HardwareInterface intf)
        {
            throw new NotImplementedException();
        }
        public VisaImplementation GetChosenHandler(ApiType apiType, HardwareInterface intf, out HandlerType handlerType)
        {
            throw new NotImplementedException();
        }
        public List<VisaImplementation> GetHandlers(ApiType apiType, HardwareInterface intf)
        {
            throw new NotImplementedException();
        }
        public List<VisaImplementation> GetInstalledVisas(ApiType apiType)
        {
            throw new NotImplementedException();
        }
        public List<HardwareInterface> GetInterfaces(ApiType apiType)
        {
            throw new NotImplementedException();
        }
        public VisaImplementation GetPreferredVisa(ApiType apiType)
        {
            throw new NotImplementedException();
        }
        public void ReloadFile() {}
        public void RemoveHandler(HardwareInterface intf, VisaImplementation visa) {}
        public void RemoveHandlers(ApiType apiType) {}
        public void RemoveHandlers(ApiType apiType, HardwareInterface intf) {}
        public void RemoveHandlers(VisaImplementation visa) {}
        public void SetPreferredVisa(VisaImplementation visa) {}
    }
    public enum AccessMode
    {
        None = 0,
        ExclusiveLock = 1,
        LoadConfig = 2
    }
    public enum AddressSpace
    {
        VxiA16 = 0,
        VxiA24 = 1,
        VxiA32 = 2,
        VxiA64 = 3,
        PxiConfiguration = 4,
        PxiBar0 = 5,
        PxiBar1 = 6,
        PxiBar2 = 7,
        PxiBar3 = 8,
        PxiBar4 = 9,
        PxiBar5 = 10,
        PxiAllocation = 11
    }
    public enum AtnMode
    {
        Deassert = 0,
        Assert = 1,
        DeassertHandshake = 2,
        AssertImmediate = 3
    }
    public enum BinaryEncoding
    {
        DefiniteLengthBlockData = 0,
        IndefiniteLengthBlockData = 1,
        RawLittleEndian = 2,
        RawBigEndian = 3
    }
    public enum ByteOrder
    {
        BigEndian = 0,
        LittleEndian = 1
    }
    public enum DataWidth
    {
        Width8 = 0,
        Width16 = 1,
        Width32 = 2,
        Width64 = 3
    }
    public enum EventQueueStatus
    {
        Empty = 0,
        NotEmpty = 1,
        Overflowed = 2
    }
    public enum EventType
    {
        Custom = 0,
        AllEnabled = 1,
        ServiceRequest = 2,
        Clear = 3,
        GpibControllerInCharge = 4,
        GpibTalk = 5,
        GpibListen = 6,
        VxiVmeSystemFailure = 7,
        VxiVmeSystemReset = 8,
        VxiSignalProcessor = 9,
        VxiVmeInterrupt = 10,
        PxiInterrupt = 11,
        UsbInterrupt = 12,
        Trigger = 13
    }
    public enum GpibAddressedState
    {
        Unaddressed = 0,
        Talker = 1,
        Listener = 2
    }
    public enum GpibInstrumentRemoteLocalMode
    {
        DeassertRen = 0,
        AssertRen = 1,
        GoToLocalDeassertRen = 2,
        AddressDeviceAssertRen = 3,
        AddressDeviceSendLocalLockout = 4,
        GoToLocal = 5
    }
    public enum GpibInterfaceRemoteLocalMode
    {
        DeassertRen = 0,
        AssertRen = 1,
        LocalLockoutAssertRen = 2
    }
    public enum HardwareInterfaceType
    {
        Custom = 0,
        Gpib = 1,
        Vxi = 2,
        GpibVxi = 3,
        Serial = 4,
        Pxi = 5,
        Tcp = 6,
        Usb = 7
    };
    public enum IOBuffers
    {
        Read = 1,
        Write = 2,
        ReadWrite = Read | Write
    }
    public enum IOProtocol
    {
        Normal = 0,
        Fdc = 1,
        HS488 = 2,
        Ieee4882 = 3,
        UsbTmcVendor = 4
    }
    public enum LineState
    {
        Unknown = -1,
        Unasserted = 0,
        Asserted = 1,
    }
    public enum NativeVisaAttribute : uint
    {
        AllowDma = 0x3fff001e,
        AllowWriteCombining = 0x3fff0246,
        AsyncReturnCount32 = 0x3fff4026,
        AsyncReturnCount64 = 0x3fff4028,
        CommanderLogicalAddress = 0x3fff006b,
        DestinationAccess = 0x3fff0039,
        DestinationByteOrder = 0x3fff003a,
        DestinationIncrement = 0x3fff0041,
        DeviceStatusByte = 0x3fff0189,
        EventType = 0x3fff4010,
        FastDataChannel = 0x3fff000d,
        FastDataChannelMode = 0x3fff000f,
        FastDataChannelUsePair = 0x3fff0013,
        FileAppendEnabled = 0x3fff0192,
        GpibAddressedState = 0x3fff005c,
        GpibAtnState = 0x3fff0057,
        GpibHS488CableLength = 0x3fff0069,
        GpibIsControllerInCharge = 0x3fff005e,
        GpibIsSystemController = 0x3fff0068,
        GpibNdacState = 0x3fff0062,
        GpibPrimaryAddress = 0x3fff0172,
        GpibRepeatAddressingEnabled = 0x3fff001b,
        GpibReceivedIsControllerInCharge = 0x3fff4193,
        GpibRenState = 0x3fff0181,
        GpibSecondaryAddress = 0x3fff0173,
        GpibSrqState = 0x3fff0067,
        GpibUnaddressEnabled = 0x3fff0184,
        Is4882Compliant = 0x3fff019f,
        ImmediateServant = 0x3fff0100,
        InterfaceName = 0xbfff00e9,
        InterfaceParentNumber = 0x3fff0101,
        InterfaceType = 0x3fff0171,
        InterfaceNumber = 0x3fff0176,
        IOProtocol = 0x3fff001c,
        JobId = 0x3fff4006,
        MainframeLogicalAddress = 0x3fff0070,
        ManufacturerId = 0x3fff00d9,
        ManufacturerName = 0xbfff0072,
        MaximumEventQueueLength = 0x3fff0005,
        MemoryBase32 = 0x3fff00ad,
        MemoryBase64 = 0x3fff00d0,
        MemorySize32 = 0x3fff00dd,
        MemorySize64 = 0x3fff00d1,
        MemorySpace = 0x3fff00de,
        ModelCode = 0x3fff00df,
        ModelName = 0xbfff0077,
        OperationName = 0xbfff4042,
        PxiActualLinkWidth = 0x3fff0243,
        PxiBackplaneDestinationTriggerBus = 0x3fff020e,
        PxiBackplaneSourceTriggerBus = 0x3fff020d,
        PxiBusNumber = 0x3fff0205,
        PxiChassis = 0x3fff0206,
        PxiDeviceNumber = 0x3fff0201,
        PxiDStarBus = 0x3fff0244,
        PxiDStarSet = 0x3fff0245,
        PxiFunctionNumber = 0x3fff0202,
        PxiIsExpress = 0x3fff0240,
        PxiMaximumLinkWidth = 0x3fff0242,
        PxiMemoryBase32Bar0 = 0x3fff0221,
        PxiMemoryBase32Bar1 = 0x3fff0222,
        PxiMemoryBase32Bar2 = 0x3fff0223,
        PxiMemoryBase32Bar3 = 0x3fff0224,
        PxiMemoryBase32Bar4 = 0x3fff0225,
        PxiMemoryBase32Bar5 = 0x3fff0226,
        PxiMemoryBase64Bar0 = 0x3fff0228,
        PxiMemoryBase64Bar1 = 0x3fff0229,
        PxiMemoryBase64Bar2 = 0x3fff022a,
        PxiMemoryBase64Bar3 = 0x3fff022b,
        PxiMemoryBase64Bar4 = 0x3fff022c,
        PxiMemoryBase64Bar5 = 0x3fff022d,
        PxiMemorySize32Bar0 = 0x3fff0231,
        PxiMemorySize32Bar1 = 0x3fff0232,
        PxiMemorySize32Bar2 = 0x3fff0233,
        PxiMemorySize32Bar3 = 0x3fff0234,
        PxiMemorySize32Bar4 = 0x3fff0235,
        PxiMemorySize32Bar5 = 0x3fff0236,
        PxiMemorySize64Bar0 = 0x3fff0238,
        PxiMemorySize64Bar1 = 0x3fff0239,
        PxiMemorySize64Bar2 = 0x3fff023a,
        PxiMemorySize64Bar3 = 0x3fff023b,
        PxiMemorySize64Bar4 = 0x3fff023c,
        PxiMemorySize64Bar5 = 0x3fff023d,
        PxiMemoryTypeBar0 = 0x3fff0211,
        PxiMemoryTypeBar1 = 0x3fff0212,
        PxiMemoryTypeBar2 = 0x3fff0213,
        PxiMemoryTypeBar3 = 0x3fff0214,
        PxiMemoryTypeBar4 = 0x3fff0215,
        PxiMemoryTypeBar5 = 0x3fff0216,
        PxiReceivedInterruptData = 0x3fff4241,
        PxiReceivedInterruptSequence = 0x3fff4240,
        PxiSlotLinkWidth = 0x3fff0241,
        PxiSlotLocalBusLeft = 0x3fff0208,
        PxiSlotLocalBusRight = 0x3fff0209,
        PxiSlotPath = 0xbfff0207,
        PxiStarTriggerBus = 0x3fff020b,
        PxiStarTriggerLine = 0x3fff020c,
        PxiTriggerBus = 0x3fff020a,
        ReadBufferOperationMode = 0x3fff002a,
        ReadBufferSize = 0x3fff002b,
        ReceivedInterruptLevel = 0x3fff4041,
        ReceivedInterruptStatusId = 0x3fff4023,
        ReceivedSignalProcessorStatusId = 0xbfff4011,
        ReceivedTcpAddress = 0xbfff4198,
        ReceivedTriggerId = 0x3fff4012,
        ResourceManagerSession = 0x3fff00c4,
        ResourceClass = 0xbfff0001,
        ResourceImplementationVersion = 0x3fff0003,
        ResourceLockState = 0x3fff0004,
        ResourceManufacturerId = 0x3fff0175,
        ResourceManufacturerName = 0xbfff0174,
        ResourceName = 0xbfff0002,
        ResourceSpecificationVersion = 0x3fff0170,
        SendEndEnabled = 0x3fff0016,
        SerialAvailableByteCount = 0x3fff00ac,
        SerialBaud = 0x3fff0021,
        SerialCtsState = 0x3fff00ae,
        SerialDataBits = 0x3fff0022,
        SerialDcdState = 0x3fff00af,
        SerialDsrState = 0x3FFF00b1,
        SerialDtrState = 0x3fff00b2,
        SerialEndIn = 0x3fff00b3,
        SerialEndOut = 0x3fff00b4,
        SerialFlowControl = 0x3fff0025,
        SerialParity = 0x3fff0023,
        SerialReplaceCharacter = 0x3fff00be,
        SerialRIState = 0x3fff00bf,
        SerialRtsState = 0x3fff00c0,
        SerialStopBits = 0x3fff0024,
        SerialXOffCharacter = 0x3fff00c2,
        SerialXOnCharacter = 0x3fff00c1,
        Slot = 0x3fff00e8,
        SourceAccess = 0x3fff003c,
        SourceByteOrder = 0x3fff003d,
        SourceIncrement = 0x3fff0040,
        Status = 0x3fff4025,
        SuppressEndEnabled = 0x3fff0036,
        TcpAddress = 0xbfff0195,
        TcpDeviceName = 0xbfff0199,
        TcpHiSLIPMaximumMessageSizeKB = 0x3fff0302,
        TcpHiSLIPOverlapEnabled = 0x3fff0300,
        TcpHiSLIPVersion = 0x3fff0301,
        TcpHostName = 0xbfff0196,
        TcpIsHiSLIP = 0x3fff0303,
        TcpKeepAlive = 0x3fff019b,
        TcpNoDelay = 0x3fff019a,
        TcpPort = 0x3fff0197,
        TerminationCharacter = 0x3fff0018,
        TerminationCharacterEnabled = 0x3fff0038,
        TimeoutValue = 0x3fff001a,
        TriggerId = 0x3fff0177,
        UsbInterfaceNumber = 0x3fff01a1,
        UsbMaximumInterruptSize = 0x3fff01af,
        UsbProtocol = 0x3fff01a7,
        UsbReceivedInterruptSize = 0x3fff41b0,
        UsbSerialNumber = 0xbfff01a0,
        UserData32 = 0x3fff0007,
        VxiDeviceClass = 0x3fff006c,
        VxiLogicalAddress = 0x3fff00d5,
        VxiTriggerStatus = 0x3fff008d,
        VxiTriggerSupport = 0x3fff0194,
        VxiVmeInterruptStatus = 0x3fff008b,
        VxiVmeSystemFailureState = 0x3fff0094,
        WindowAccess = 0x3fff00c3,
        WindowAccessPrivilege0x3fff0045,
        WindowBaseAddress32 = 0x3fff0098,
        WindowBaseAddress64 = 0x3fff009b,
        WindowByteOrder = 0x3fff0047,
        WindowSize32 = 0x3fff009a,
        WindowSize64 = 0x3fff009c,
        WriteBufferOperationMode = 0x3fff002d,
        WriteBufferSize = 0x3fff002e,
    }
    public enum PxiMemoryType
    {
        None = 0,
        Memory = 1,
        IO = 2,
    }
    public enum ReadStatus
    {
        Unknown = 0,
        EndReceived = 1,
        TerminationCharacterEncountered = 2,
        MaximumCountReached = 3
    }
    public enum RemoteLocalMode
    {
        LocalWithoutLockout = 0,
        Remote = 1,
        RemoteWithLocalLockout = 2,
        Local = 3
    }
    public enum ResourceLockState
    {
        NoLock = 0,
        ExclusiveLock = 1,
        SharedLock = 2
    }
    public enum ResourceOpenStatus
    {
        Success = 0,
        DeviceNotResponding = 1,
        ConfigurationNotLoaded = 2
    }
    public enum SerialFlowControlModes
    {
        None = 0,
        XOnXOff = 1,
        RtsCts = 2,
        DtrDsr = 4
    }
    public enum SerialParity
    {
        None = 0,
        Odd = 1,
        Even = 2,
        Mark = 3,
        Space = 4
    }
    public enum SerialTerminationMethod
    {
        None = 0,
        HighestBit = 1,
        TerminationCharacter = 2,
        Break = 3
    }
    public enum StatusByteFlags : short
    {
        User0 = 0x01,
        User1 = 0x02,
        User2 = 0x04,
        User3 = 0x08,
        MessageAvailable = 0x10,
        EventStatusRegister = 0x20,
        RequestingService = 0x40,
        User7 = 0x80
    }
    public enum SerialStopBitsMode
    {
        One = 0,
        OneAndOneHalf = 1,
        Two = 2
    }
    public enum TriggerLine
    {
        All = -2,
        Ttl0 = 0,
        Ttl1 = 1,
        Ttl2 = 2,
        Ttl3 = 3,
        Ttl4 = 4,
        Ttl5 = 5,
        Ttl6 = 6,
        Ttl7 = 7,
        Ecl0 = 8,
        Ecl1 = 9,
        Ecl2 = 10,
        Ecl3 = 11,
        Ecl4 = 12,
        Ecl5 = 13,
        StarSlot1 = 14,
        StarSlot2 = 15,
        StarSlot3 = 16,
        StarSlot4 = 17,
        StarSlot5 = 18,
        StarSlot6 = 19,
        StarSlot7 = 20,
        StarSlot8 = 21,
        StarSlot9 = 22,
        StarSlot10 = 23,
        StarSlot11 = 24,
        StarSlot12 = 25,
        StarInstrument = 26,
        PanelIn = 27,
        PanelOut = 28,
        StarVxi0 = 29,
        StarVxi1 = 30,
        StarVxi2 = 31,
        Ttl8 = 32,
        Ttl9 = 33,
        Ttl10 = 34,
        Ttl11 = 35
    }
    [Flags]
    public enum TriggerLines
    {
        Ecl0 = 1 << TriggerLine.Ecl0,
        Ecl1 = 1 << TriggerLine.Ecl1,
        Ecl2 = 1 << TriggerLine.Ecl2,
        Ecl3 = 1 << TriggerLine.Ecl3,
        Ecl4 = 1 << TriggerLine.Ecl4,
        Ecl5 = 1 << TriggerLine.Ecl5,
        PanelIn = 1 << TriggerLine.PanelIn,
        PanelOut = 1 << TriggerLine.PanelOut,
        StarInstr = 1 << TriggerLine.StarInstrument,
        StarSlot1 = 1 << TriggerLine.StarSlot1,
        StarSlot2 = 1 << TriggerLine.StarSlot2,
        StarSlot3 = 1 << TriggerLine.StarSlot3,
        StarSlot4 = 1 << TriggerLine.StarSlot4,
        StarSlot5 = 1 << TriggerLine.StarSlot5,
        StarSlot6 = 1 << TriggerLine.StarSlot6,
        StarSlot7 = 1 << TriggerLine.StarSlot7,
        StarSlot8 = 1 << TriggerLine.StarSlot8,
        StarSlot9 = 1 << TriggerLine.StarSlot9,
        StarSlot10 = 1 << TriggerLine.StarSlot10,
        StarSlot11 = 1 << TriggerLine.StarSlot11,
        StarSlot12 = 1 << TriggerLine.StarSlot12,
        StarVxi0 = 1 << TriggerLine.StarVxi0,
        StarVxi1 = 1 << TriggerLine.StarVxi1,
        StarVxi2 = 1 << TriggerLine.StarVxi2,
        Ttl0 = 1 << TriggerLine.Ttl0,
        Ttl1 = 1 << TriggerLine.Ttl1,
        Ttl2 = 1 << TriggerLine.Ttl2,
        Ttl3 = 1 << TriggerLine.Ttl3,
        Ttl4 = 1 << TriggerLine.Ttl4,
        Ttl5 = 1 << TriggerLine.Ttl5,
        Ttl6 = 1 << TriggerLine.Ttl6,
        Ttl7 = 1 << TriggerLine.Ttl7
    }
    public enum VxiAccessPrivilege
    {
        DataPrivileged = 0,
        DataNonPrivileged = 1,
        ProgramPrivileged = 2,
        ProgramNonPrivileged = 3,
        BlockPrivileged = 4,
        BlockNonPrivileged = 5,
        D64Privileged = 6,
        D64NonPrivileged = 7,
        D64DoubleEdgeVme = 8,
        D64Sst160 = 9,
        D64Sst267 = 10,
        D64Sst320 = 11
    }
    public enum VxiCommandMode
    {
        Command16Bit = 0,
        Command32Bit = 1,
        Command32BitResponse16Bit = 2,
        CommandResponse16Bit = 3,
        CommandResponse32Bit = 4,
        Response16Bit = 5,
        Response32Bit = 6
    }
    public enum VxiDeviceClass
    {
        Memory = 0,
        Extended = 1,
        Message = 2,
        Register = 3,
        Other = 4
    }
    public enum VxiTriggerProtocol
    {
        Software = 0,
        On = 1,
        Off = 2,
        Sync = 5,
    }
    public enum VxiUtilitySignal
    {
        AssertSystemReset = 0,
        AssertSystemFailure = 1,
        DeassertSystemFailure = 2,
    }
    public class VisaException : System.Exception
    {
        public VisaException() { }
        public VisaException(String message) { }
        public VisaException(String message, System.Exception innerException) { }
        protected VisaException(SerializationInfo info, StreamingContext context) { }
    }
    public class IOTimeoutException : VisaException
    {
        public IOTimeoutException(Int64 actualCount, Byte[] actualData)
        {
            ActualData = new byte[0];
        }
    public IOTimeoutException(Int64 actualCount, Byte[] actualData, String message)
        {
            ActualData = new byte[0];
        }
        public IOTimeoutException(Int64 actualCount, Byte[] actualData, String message, System.Exception innerException)
        {
            ActualData = new byte[0];
        }
        protected IOTimeoutException(SerializationInfo info, StreamingContext context)
        {
            ActualData = new byte[0];
        }
        public Int64 ActualCount { get; protected set; }
        public Byte[] ActualData { get; protected set; }
    }
    public class NativeVisaException : VisaException
    {
        public NativeVisaException(int errorCode) { }
        public NativeVisaException(int errorCode, String message) { }
        public NativeVisaException(int errorCode, String message, System.Exception innerException) { }
        protected NativeVisaException(SerializationInfo info, StreamingContext context) { }
        public int ErrorCode { get; protected set; }
    }
    public class TypeFormatterException : System.Exception
    {
        public TypeFormatterException() { }
        public TypeFormatterException(System.Exception innerException) { }
        public TypeFormatterException(Type type) { }
        public TypeFormatterException(Type type, System.Exception innerException) { }
        public TypeFormatterException(Type type, String instrumentResponse) { }
        public TypeFormatterException(Type type, String instrumentResponse, System.Exception innerException) { }
        public TypeFormatterException(Object obj) { }
        public TypeFormatterException(Object obj, System.Exception innerException) { }
        protected TypeFormatterException(SerializationInfo info, StreamingContext context) { }
    }
    public class NativeErrorCode
    {
        public const int SystemError = -1073807360;
        public const int InvalidObject = -1073807346;
        public const int ResourceLocked = -1073807345;
        public const int InvalidExpression = -1073807344;
        public const int ResourceNotFound = -1073807343;
        public const int InvalidResourceName = -1073807342;
        public const int InvalidAccessMode = -1073807341;
        public const int Timeout = -1073807339;
        public const int CloseFailed = -1073807338;
        public const int InvalidDegree = -1073807333;
        public const int InvalidJobId = -1073807332;
        public const int UnsupportedAttribute = -1073807331;
        public const int UnsupportedAttributeValue = -1073807330;
        public const int ReadOnlyAttribute = -1073807329;
        public const int InvalidLockType = -1073807328;
        public const int InvalidAccessKey = -1073807327;
        public const int InvalidEvent = -1073807322;
        public const int InvalidMechanism = -1073807321;
        public const int HandlerNotInstalled = -1073807320;
        public const int InvalidHandlerReference = -1073807319;
        public const int InvalidEventContext = -1073807318;
        public const int QueueOverflow = -1073807315;
        public const int NotEnabled = -1073807313;
        public const int Abort = -1073807312;
        public const int RawWriteProtocolViolation = -1073807308;
        public const int RawReadProtocolViolation = -1073807307;
        public const int OutputProtocolViolation = -1073807306;
        public const int InputProtocolViolation = -1073807305;
        public const int BusError = -1073807304;
        public const int OperationInProgress = -1073807303;
        public const int InvalidSetup = -1073807302;
        public const int QueueError = -1073807301;
        public const int MemoryAllocation = -1073807300;
        public const int InvalidBufferMask = -1073807299;
        public const int IOError = -1073807298;
        public const int InvalidFormatSpecifier = -1073807297;
        public const int UnsupportedFormatSpecifier = -1073807295;
        public const int TriggerLineInUse = -1073807294;
        public const int TriggerLineNotReserved = -1073807293;
        public const int UnsupportedMode = -1073807290;
        public const int ServiceRequestNotReceived = -1073807286;
        public const int InvalidAddressSpace = -1073807282;
        public const int InvalidOffset = -1073807279;
        public const int InvalidDataWidth = -1073807278;
        public const int UnsupportedOffset = -1073807276;
        public const int VariableDataWidthNotSupported = -1073807275;
        public const int WindowNotMapped = -1073807273;
        public const int ResponsePending = -1073807271;
        public const int NoListeners = -1073807265;
        public const int NotControllerInCharge = -1073807264;
        public const int NotSystemController = -1073807263;
        public const int OperationNotSupported = -1073807257;
        public const int InterruptPending = -1073807256;
        public const int ParityError = -1073807254;
        public const int FramingError = -1073807253;
        public const int Overrun = -1073807252;
        public const int TriggerNotMapped = -1073807250;
        public const int OffsetNotAligned = -1073807248;
        public const int UserBufferError = -1073807247;
        public const int ResourceBusy = -1073807246;
        public const int WidthNotSupported = -1073807242;
        public const int InvalidParameter = -1073807240;
        public const int InvalidProtocol = -1073807239;
        public const int InvalidWindowSize = -1073807237;
        public const int WindowAlreadyMapped = -1073807232;
        public const int OperationNotImplemented = -1073807231;
        public const int InvalidLength = -1073807229;
        public const int InvalidMode = -1073807215;
        public const int SessionNotLocked = -1073807204;
        public const int MemoryNotShared = -1073807203;
        public const int LibraryNotFound = -1073807202;
        public const int UnsupportedInterrupt = -1073807201;
        public const int InvalidLine = -1073807200;
        public const int FileAccessError = -1073807199;
        public const int FileIOError = -1073807198;
        public const int TriggerLineNotSupported = -1073807197;
        public const int EventMechanismNotSupported = -1073807196;
        public const int InterfaceNumberNotConfigured = -1073807195;
        public const int ConnectionLost = -1073807194;
        public const int MachineNotAvailable = -1073807193;
        public const int AccessDenied = -1073807192;
        public const int ServerCertificateError = -1073807184;
        public const int ServerCertificateUntrusted = -1073807183;
        public const int ServerCertificateExpired = -1073807182;
        public const int ServerCertificateRevoked = -1073807181;
        public const int ServerCertificateInvalidSubject = -1073807180;
        public static string GetMacroNameFromStatusCode(int status) { return ""; }
    }
    public class VisaEventArgs : EventArgs
    {
        public VisaEventArgs(EventType eventType) { }
        public VisaEventArgs(Int32 customType) { }
        public EventType EventType { get; private set; }
        public Int32 CustomEventType { get; private set; }
    }
    public class GpibControllerInChargeEventArgs : VisaEventArgs
    {
        public GpibControllerInChargeEventArgs(EventType eventType) : base(eventType) { }
        // public GpibControllerInChargeEventArgs(Boolean isControllerInCharge) { }
        public Boolean IsControllerInCharge { get; private set; }
    }
    public class PxiInterruptEventArgs : VisaEventArgs
    {
        public PxiInterruptEventArgs(EventType eventType) : base(eventType) { }
        //public PxiInterruptEventArgs(Int16 sequence, Int32 data) { }
        public Int16 Sequence { get; private set; }
        public Int32 Data { get; private set; }
    }
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
    public interface IMessageBasedFormattedIO
    {
        public BinaryEncoding BinaryEncoding_ { get; set; }
        public Int32 ReadBufferSize { get; set; }
        public Int32 WriteBufferSize { get; set; }
        public ITypeFormatter TypeFormatter { get; set; }
        public void DiscardBuffers();
        public void FlushWrite(Boolean sendEnd);
        public void Printf(String data);
        public void Printf(String format, params object[] args);
        public void PrintfAndFlush(String data);
        public void PrintfAndFlush(String format, params object[] args);
        // public unsafe void PrintfArray(String format, Byte* pArray, params Int64[] inputs);
        // public unsafe void PrintfArray(String format, SByte* pArray, params Int64[] inputs);
        // public unsafe void PrintfArray(String format, Int16* pArray, params Int64[] inputs);
        // public unsafe void PrintfArray(String format, UInt16* pArray, params Int64[] inputs);
        // public unsafe void PrintfArray(String format, Int32* pArray, params Int64[] inputs);
        // public unsafe void PrintfArray(String format, UInt32* pArray, params Int64[] inputs);
        // public unsafe void PrintfArray(String format, Int64* pArray, params Int64[] inputs);
        // public unsafe void PrintfArray(String format, UInt64* pArray, params Int64[] inputs);
        // public unsafe void PrintfArray(String format, Single* pArray, params Int64[] inputs);
        // public unsafe void PrintfArray(String format, Double* pArray, params Int64[] inputs);
        // public unsafe void PrintfArrayAndFlush(String format, Byte* pArray, params Int64[] inputs);
        // public unsafe void PrintfArrayAndFlush(String format, SByte* pArray, params Int64[] inputs);
        // public unsafe void PrintfArrayAndFlush(String format, Int16* pArray, params Int64[] inputs);
        // public unsafe void PrintfArrayAndFlush(String format, UInt16* pArray, params Int64[] inputs);
        // public unsafe void PrintfArrayAndFlush(String format, Int32* pArray, params Int64[] inputs);
        // public unsafe void PrintfArrayAndFlush(String format, UInt32* pArray, params Int64[] inputs);
        // public unsafe void PrintfArrayAndFlush(String format, Int64* pArray, params Int64[] inputs);
        // public unsafe void PrintfArrayAndFlush(String format, UInt64* pArray, params Int64[] inputs);
        // public unsafe void PrintfArrayAndFlush(String format, Single* pArray, params Int64[] inputs);
        // public unsafe void PrintfArrayAndFlush(String format, Double* pArray, params Int64[] inputs
        public void Scanf<T>(String format, out T output);
        public void Scanf<T1, T2>(String format, out T1 output1, out T2 output2);
        public void Scanf<T1, T2, T3>(String format, out T1 output1, out T2 output2, out T3 output3);
        public void Scanf<T1, T2, T3, T4>(String format, out T1 output1, out T2 output2, out T3 output3, out T4 output4);
        public void Scanf<T1, T2, T3, T4, T5>(String format, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5);
        public void Scanf<T1, T2, T3, T4, T5, T6>(String format, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5, out T6 output6);
        public void Scanf<T1, T2, T3, T4, T5, T6, T7>(String format, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5, out T6 output6, out T7 output7);
        public void Scanf<T>(String format, Int32[] inputs, out T output);
        public void Scanf<T1, T2>(String format, Int32[] inputs, out T1 output1, out T2 output2);
        public void Scanf<T1, T2, T3>(String format, Int32[] inputs, out T1 output1, out T2 output2, out T3 output3);
        public void Scanf<T1, T2, T3, T4>(String format, Int32[] inputs, out T1 output1, out T2 output2, out T3 output3, out T4 output4);
        public void Scanf<T1, T2, T3, T4, T5>(String format, Int32[] inputs, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5);
        public void Scanf<T1, T2, T3, T4, T5, T6>(String format, Int32[] inputs, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5, out T6 output6);
        public void Scanf<T1, T2, T3, T4, T5, T6, T7>(String format, Int32[] inputs, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5, out T6 output6, out T7 output7);
        // public unsafe Int64 ScanfArray(String format, Byte* pArray, params Int64[] inputs);
        // public unsafe Int64 ScanfArray(String format, SByte* pArray, params Int64[] inputs);
        // public unsafe Int64 ScanfArray(String format, Int16* pArray, params Int64[] inputs);
        // public unsafe Int64 ScanfArray(String format, UInt16* pArray, params Int64[] inputs);
        // public unsafe Int64 ScanfArray(String format, Int32* pArray, params Int64[] inputs);
        // public unsafe Int64 ScanfArray(String format, UInt32* pArray, params Int64[] inputs);
        // public unsafe Int64 ScanfArray(String format, Int64* pArray, params Int64[] inputs);
        // public unsafe Int64 ScanfArray(String format, UInt64* pArray, params Int64[] inputs);
        // public unsafe Int64 ScanfArray(String format, Single* pArray, params Int64[] inputs);
        // public unsafe Int64 ScanfArray(String format, Double* pArray, params Int64[] inputs);
        public void Write(Char data);
        public void Write(String data);
        public void Write(Int64 data);
        public void Write(UInt64 data);
        public void Write(Double data);
        public void WriteLine();
        public void WriteLine(Char data);
        public void WriteLine(String data);
        public void WriteLine(Int64 data);
        public void WriteLine(UInt64 data);
        public void WriteLine(Double data);
        public void WriteList(Byte[] data);
        public void WriteList(Byte[] data, Int64 index, Int64 count);
        public void WriteList(SByte[] data);
        public void WriteList(SByte[] data, Int64 index, Int64 count);
        public void WriteList(Int16[] data);
        public void WriteList(Int16[] data, Int64 index, Int64 count);
        // [CLSCompliant(false)]
        public void WriteList(UInt16[] data);
        // [CLSCompliant(false)]
        public void WriteList(UInt16[] data, Int64 index, Int64 count);
        public void WriteList(Int32[] data);
        public void WriteList(Int32[] data, Int64 index, Int64 count);
        // [CLSCompliant(false)]
        public void WriteList(UInt32[] data);
        // [CLSCompliant(false)]
        public void WriteList(UInt32[] data, Int64 index, Int64 count);
        public void WriteList(Int64[] data);
        public void WriteList(Int64[] data, Int64 index, Int64 count);
        // [CLSCompliant(false)]
        public void WriteList(UInt64[] data);
        // [CLSCompliant(false)]
        public void WriteList(UInt64[] data, Int64 index, Int64 count);
        public void WriteList(Single[] data);

        public void WriteList(Single[] data, Int64 index, Int64 count);
        public void WriteList(Double[] data);
        public void WriteList(Double[] data, Int64 index, Int64 count);
        public void WriteLineList(Byte[] data);
        public void WriteLineList(Byte[] data, Int64 index, Int64 count);
        public void WriteLineList(SByte[] data);
        public void WriteLineList(SByte[] data, Int64 index, Int64 count);
        public void WriteLineList(Int16[] data);
        public void WriteLineList(Int16[] data, Int64 index, Int64 count);
        // [CLSCompliant(false)]
        public void WriteLineList(UInt16[] data);
        // [CLSCompliant(false)]
        public void WriteLineList(UInt16[] data, Int64 index, Int64 count);
        public void WriteLineList(Int32[] data);
        public void WriteLineList(Int32[] data, Int64 index, Int64 count);
        // [CLSCompliant(false)]
        public void WriteLineList(UInt32[] data);
        // [CLSCompliant(false)]
        public void WriteLineList(UInt32[] data, Int64 index, Int64 count);
        public void WriteLineList(Int64[] data);
        public void WriteLineList(Int64[] data, Int64 index, Int64 count);
        // [CLSCompliant(false)]
        public void WriteLineList(UInt64[] data);
        // [CLSCompliant(false)]
        public void WriteLineList(UInt64[] data, Int64 index, Int64 count);
        public void WriteLineList(Single[] data);
        public void WriteLineList(Single[] data, Int64 index, Int64 count);
        public void WriteLineList(Double[] data);
        public void WriteLineList(Double[] data, Int64 index, Int64 count);
        public void WriteBinary(Byte[] data);
        public void WriteBinary(Byte[] data, Int64 index, Int64 count);
        public void WriteBinary(SByte[] data);
        public void WriteBinary(SByte[] data, Int64 index, Int64 count);
        public void WriteBinary(Int16[] data);
        public void WriteBinary(Int16[] data, Int64 index, Int64 count);
        // [CLSCompliant(false)]
        public void WriteBinary(UInt16[] data);
        // [CLSCompliant(false)]
        public void WriteBinary(UInt16[] data, Int64 index, Int64 count);
        public void WriteBinary(Int32[] data);
        public void WriteBinary(Int32[] data, Int64 index, Int64 count);
        // [CLSCompliant(false)]
        public void WriteBinary(UInt32[] data);
        // [CLSCompliant(false)]
        public void WriteBinary(UInt32[] data, Int64 index, Int64 count);
        public void WriteBinary(Int64[] data);
        public void WriteBinary(Int64[] data, Int64 index, Int64 count);
        // [CLSCompliant(false)]
        public void WriteBinary(UInt64[] data);
        // [CLSCompliant(false)]
        public void WriteBinary(UInt64[] data, Int64 index, Int64 count);
        public void WriteBinary(Single[] data);
        public void WriteBinary(Single[] data, Int64 index, Int64 count);
        public void WriteBinary(Double[] data);
        public void WriteBinary(Double[] data, Int64 index, Int64 count);
        public void WriteBinaryAndFlush(Byte[] data);
        public void WriteBinaryAndFlush(Byte[] data, Int64 index, Int64 count);
        public void WriteBinaryAndFlush(SByte[] data);
        public void WriteBinaryAndFlush(SByte[] data, Int64 index, Int64 count);
        public void WriteBinaryAndFlush(Int16[] data);
        public void WriteBinaryAndFlush(Int16[] data, Int64 index, Int64 count);
        // [CLSCompliant(false)]
        public void WriteBinaryAndFlush(UInt16[] data);
        // [CLSCompliant(false)]
        public void WriteBinaryAndFlush(UInt16[] data, Int64 index, Int64 count);
        public void WriteBinaryAndFlush(Int32[] data);
        public void WriteBinaryAndFlush(Int32[] data, Int64 index, Int64 count);
        // [CLSCompliant(false)]
        public void WriteBinaryAndFlush(UInt32[] data);
        // [CLSCompliant(false)]
        public void WriteBinaryAndFlush(UInt32[] data, Int64 index, Int64 count);
        public void WriteBinaryAndFlush(Int64[] data);
        public void WriteBinaryAndFlush(Int64[] data, Int64 index, Int64 count);
        // [CLSCompliant(false)]
        public void WriteBinaryAndFlush(UInt64[] data);
        // [CLSCompliant(false)]
        public void WriteBinaryAndFlush(UInt64[] data, Int64 index, Int64 count);
        public void WriteBinaryAndFlush(Single[] data);
        public void WriteBinaryAndFlush(Single[] data, Int64 index, Int64 count);
        public void WriteBinaryAndFlush(Double[] data);
        public void WriteBinaryAndFlush(Double[] data, Int64 index, Int64 count);
        public String ReadString();
        public String ReadString(Int32 count);
        public Int32 ReadString(StringBuilder data);
        public Int32 ReadString(StringBuilder data, Int32 count);
        public Char ReadChar();
        public Int64 ReadInt64();
        public UInt64 ReadUInt64();
        public Double ReadDouble();
        public String ReadLine();
        public Int32 ReadLine(StringBuilder data);
        public Char ReadLineChar();
        public Int64 ReadLineInt64();
        public UInt64 ReadLineUInt64();
        public Double ReadLineDouble();
        public Byte[] ReadListOfByte(Int64 count);
        public Int64 ReadListOfByte(Byte[] data, Int64 index, Int64 count);
        public SByte[] ReadListOfSByte(Int64 count);
        public Int64 ReadListOfSByte(SByte[] data, Int64 index, Int64 count);
        public Int16[] ReadListOfInt16(Int64 count);
        public Int64 ReadListOfInt16(Int16[] data, Int64 index, Int64 count);
        public UInt16[] ReadListOfUInt16(Int64 count);
        public Int64 ReadListOfUInt16(UInt16[] data, Int64 index, Int64 count);
        public Int32[] ReadListOfInt32(Int64 count);
        public Int64 ReadListOfInt32(Int32[] data, Int64 index, Int64 count);
        public UInt32[] ReadListOfUInt32(Int64 count);
        public Int64 ReadListOfUInt32(UInt32[] data, Int64 index, Int64 count);
        public Int64[] ReadListOfInt64(Int64 count);
        public Int64 ReadListOfInt64(Int64[] data, Int64 index, Int64 count);
        public UInt64[] ReadListOfUInt64(Int64 count);
        public Int64 ReadListOfUInt64(UInt64[] data, Int64 index, Int64 count);
        public Single[] ReadListOfSingle(Int64 count);
        public Int64 ReadListOfSingle(Single[] data, Int64 index, Int64 count);
        public Double[] ReadListOfDouble(Int64 count);
        public Int64 ReadListOfDouble(Double[] data, Int64 index, Int64 count);
        public Byte[] ReadLineListOfByte();
        public Int64 ReadLineListOfByte(Byte[] data, Int64 index);
        public SByte[] ReadLineListOfSByte();
        public Int64 ReadLineListOfSByte(SByte[] data, Int64 index);
        public Int16[] ReadLineListOfInt16();
        public Int64 ReadLineListOfInt16(Int16[] data, Int64 index);
        public UInt16[] ReadLineListOfUInt16();
        public Int64 ReadLineListOfUInt16(UInt16[] data, Int64 index);
        public Int32[] ReadLineListOfInt32();
        public Int64 ReadLineListOfInt32(Int32[] data, Int64 index);
        public UInt32[] ReadLineListOfUInt32();
        public Int64 ReadLineListOfUInt32(UInt32[] data, Int64 index);
        public Int64[] ReadLineListOfInt64();
        public Int64 ReadLineListOfInt64(Int64[] data, Int64 index);
        public UInt64[] ReadLineListOfUInt64();
        public Int64 ReadLineListOfUInt64(UInt64[] data, Int64 index);
        public Single[] ReadLineListOfSingle();
        public Int64 ReadLineListOfSingle(Single[] data, Int64 index);
        public Double[] ReadLineListOfDouble();
        public Int64 ReadLineListOfDouble(Double[] data, Int64 index);
        public Byte[] ReadBinaryBlockOfByte();
        public Byte[] ReadBinaryBlockOfByte(Boolean seekToBlock);
        public Int64 ReadBinaryBlockOfByte(Byte[] data, Int64 index, Int64 count);
        public Int64 ReadBinaryBlockOfByte(Byte[] data, Int64 index, Int64 count, Boolean seekToBlock);
        public SByte[] ReadBinaryBlockOfSByte();
        public SByte[] ReadBinaryBlockOfSByte(Boolean seekToBlock);
        public Int64 ReadBinaryBlockOfSByte(SByte[] data, Int64 index, Int64 count);
        public Int64 ReadBinaryBlockOfSByte(SByte[] data, Int64 index, Int64 count, Boolean seekToBlock);
        public Int16[] ReadBinaryBlockOfInt16();
        public Int16[] ReadBinaryBlockOfInt16(Boolean seekToBlock);
        public Int64 ReadBinaryBlockOfInt16(Int16[] data, Int64 index, Int64 count);
        public Int64 ReadBinaryBlockOfInt16(Int16[] data, Int64 index, Int64 count, Boolean seekToBlock);
        public UInt16[] ReadBinaryBlockOfUInt16();
        public UInt16[] ReadBinaryBlockOfUInt16(Boolean seekToBlock);
        public Int64 ReadBinaryBlockOfUInt16(UInt16[] data, Int64 index, Int64 count);
        public Int64 ReadBinaryBlockOfUInt16(UInt16[] data, Int64 index, Int64 count, Boolean seekToBlock);
        public Int32[] ReadBinaryBlockOfInt32();
        public Int32[] ReadBinaryBlockOfInt32(Boolean seekToBlock);
        public Int64 ReadBinaryBlockOfInt32(Int32[] data, Int64 index, Int64 count);
        public Int64 ReadBinaryBlockOfInt32(Int32[] data, Int64 index, Int64 count, Boolean seekToBlock);
        public UInt32[] ReadBinaryBlockOfUInt32();
        public UInt32[] ReadBinaryBlockOfUInt32(Boolean seekToBlock);
        public Int64 ReadBinaryBlockOfUInt32(UInt32[] data, Int64 index, Int64 count);
        public Int64 ReadBinaryBlockOfUInt32(UInt32[] data, Int64 index, Int64 count, Boolean seekToBlock);
        public Int64[] ReadBinaryBlockOfInt64();
        public Int64 ReadBinaryBlockOfInt64(Int64[] data, Int64 index, Int64 count);
        public UInt64[] ReadBinaryBlockOfUInt64();
        public Int64 ReadBinaryBlockOfUInt64(UInt64[] data, Int64 index, Int64 count);
        public Single[] ReadBinaryBlockOfSingle();
        public Single[] ReadBinaryBlockOfSingle(Boolean seekToBlock);
        public Int64 ReadBinaryBlockOfSingle(Single[] data, Int64 index, Int64 count);
        public Int64 ReadBinaryBlockOfSingle(Single[] data, Int64 index, Int64 count, Boolean seekToBlock);
        public Double[] ReadBinaryBlockOfDouble();
        public Double[] ReadBinaryBlockOfDouble(Boolean seekToBlock);
        public Int64 ReadBinaryBlockOfDouble(Double[] data, Int64 index, Int64 count);
        public Int64 ReadBinaryBlockOfDouble(Double[] data, Int64 index, Int64 count, Boolean seekToBlock);
        public Byte[] ReadLineBinaryBlockOfByte();
        public Byte[] ReadLineBinaryBlockOfByte(Boolean seekToBlock);
        public Int64 ReadLineBinaryBlockOfByte(Byte[] data, Int64 index, Int64 count);
        public Int64 ReadLineBinaryBlockOfByte(Byte[] data, Int64 index, Int64 count, Boolean seekToBlock);
        public SByte[] ReadLineBinaryBlockOfSByte();
        public SByte[] ReadLineBinaryBlockOfSByte(Boolean seekToBlock);
        public Int64 ReadLineBinaryBlockOfSByte(SByte[] data, Int64 index, Int64 count);
        public Int64 ReadLineBinaryBlockOfSByte(SByte[] data, Int64 index, Int64 count, Boolean seekToBlock);
        public Int16[] ReadLineBinaryBlockOfInt16();
        public Int16[] ReadLineBinaryBlockOfInt16(Boolean seekToBlock);
        public Int64 ReadLineBinaryBlockOfInt16(Int16[] data, Int64 index, Int64 count);
        public Int64 ReadLineBinaryBlockOfInt16(Int16[] data, Int64 index, Int64 count, Boolean seekToBlock);
        public UInt16[] ReadLineBinaryBlockOfUInt16();
        public UInt16[] ReadLineBinaryBlockOfUInt16(Boolean seekToBlock);
        public Int64 ReadLineBinaryBlockOfUInt16(UInt16[] data, Int64 index, Int64 coun);
        public Int64 ReadLineBinaryBlockOfUInt16(UInt16[] data, Int64 index, Int64 count, Boolean seekToBlock);
        public Int32[] ReadLineBinaryBlockOfInt32();
        public Int32[] ReadLineBinaryBlockOfInt32(Boolean seekToBlock);
        public Int64 ReadLineBinaryBlockOfInt32(Int32[] data, Int64 index, Int64 count);
        public Int64 ReadLineBinaryBlockOfInt32(Int32[] data, Int64 index, Int64 count, Boolean seekToBlock);
        public UInt32[] ReadLineBinaryBlockOfUInt32();
        public UInt32[] ReadLineBinaryBlockOfUInt32(Boolean seekToBlock);
        public Int64 ReadLineBinaryBlockOfUInt32(UInt32[] data, Int64 index, Int64 count);
        public Int64 ReadLineBinaryBlockOfUInt32(UInt32[] data, Int64 index, Int64 count, Boolean seekToBlock);
        public Int64[] ReadLineBinaryBlockOfInt64();
        public Int64 ReadLineBinaryBlockOfInt64(Int64[] data, Int64 index, Int64 count);
        public UInt64[] ReadLineBinaryBlockOfUInt64();
        public Int64 ReadLineBinaryBlockOfUInt64(UInt64[] data, Int64 index, Int64 count);
        public Single[] ReadLineBinaryBlockOfSingle();
        public Single[] ReadLineBinaryBlockOfSingle(Boolean seekToBlock);
        public Int64 ReadLineBinaryBlockOfSingle(Single[] data, Int64 index, Int64 count);
        public Int64 ReadLineBinaryBlockOfSingle(Single[] data, Int64 index, Int64 count, Boolean seekToBlock);
        public Double[] ReadLineBinaryBlockOfDouble();
        public Double[] ReadLineBinaryBlockOfDouble(Boolean seekToBlock);
        public Int64 ReadLineBinaryBlockOfDouble(Double[] data, Int64 index, Int64 count);
        public Int64 ReadLineBinaryBlockOfDouble(Double[] data, Int64 index, Int64 count, Boolean seekToBlock);
        public String ReadWhileMatch(String characters);
        public String ReadUntilMatch(Char ch);
        public String ReadUntilMatch(String characters, Boolean discardMatch);
        public String ReadUntilEnd();
        public void Skip(Int64 count);
        public void SkipString(String data);
        public void SkipUntilEnd();
    }
    public interface IMessageBasedRawIO
    {
        Byte[] Read();
        Byte[] Read(Int64 count);
        Byte[] Read(Int64 count, out ReadStatus readStatus);
        void Read(Byte[] buffer, Int64 index, Int64 count, out Int64 actualCount, out ReadStatus readStatus);
        // unsafe void Read(Byte* buffer, Int64 index, Int64 count, out Int64 actualCount, out ReadStatus readStatus);
        String ReadString();
        String ReadString(Int64 count);
        String ReadString(Int64 count, out ReadStatus readStatus);
        void Write(Byte[] buffer);
        void Write(Byte[] buffer, Int64 index, Int64 count);
        void Write(String buffer);
        void Write(String buffer, Int64 index, Int64 count);
        // unsafe void Write(Byte* buffer, Int64 index, Int64 count);
        void AbortAsyncOperation(IVisaAsyncResult result);
        IVisaAsyncResult BeginRead(Int32 count);
        IVisaAsyncResult BeginRead(Int32 count, Object state);
        IVisaAsyncResult BeginRead(Int32 count, VisaAsyncCallback callback, Object state);
        IVisaAsyncResult BeginRead(Byte[] buffer);
        IVisaAsyncResult BeginRead(Byte[] buffer, Object state);
        IVisaAsyncResult BeginRead(Byte[] buffer, Int64 index, Int64 count);
        IVisaAsyncResult BeginRead(Byte[] buffer, Int64 index, Int64 count, Object state);
        IVisaAsyncResult BeginRead(Byte[] buffer, VisaAsyncCallback callback, Object state);
        IVisaAsyncResult BeginRead(Byte[] buffer, Int64 index, Int64 count, VisaAsyncCallback callback, Object state);
        IVisaAsyncResult BeginWrite(String buffer);
        IVisaAsyncResult BeginWrite(String buffer, Object state);
        IVisaAsyncResult BeginWrite(String buffer, VisaAsyncCallback callback, Object state);
        IVisaAsyncResult BeginWrite(Byte[] buffer);
        IVisaAsyncResult BeginWrite(Byte[] buffer, Object state);
        IVisaAsyncResult BeginWrite(Byte[] buffer, Int64 index, Int64 count);
        IVisaAsyncResult BeginWrite(Byte[] buffer, Int64 index, Int64 count, Object state);
        IVisaAsyncResult BeginWrite(Byte[] buffer, VisaAsyncCallback callback, Object state);
        IVisaAsyncResult BeginWrite(Byte[] buffer, Int64 index, Int64 count, VisaAsyncCallback callback, Object state);
        Int64 EndRead(IVisaAsyncResult result);
        String EndReadString(IVisaAsyncResult result);
        void EndWrite(IVisaAsyncResult result);
    }
    public interface IRegisterBasedSession : IVisaSession
    {
        Boolean AllowDma { get; set; }
        Int32 DestinationIncrement { get; set; }
        Int32 SourceIncrement { get; set; }
        IMemoryMap MapAddress(AddressSpace space, Int64 offset, Int64 size);
        Byte In8(AddressSpace space, Int64 sourceOffset);
        Int16 In16(AddressSpace space, Int64 sourceOffset);
        Int32 In32(AddressSpace space, Int64 sourceOffset);
        Int64 In64(AddressSpace space, Int64 sourceOffset);
        void Out8(AddressSpace space, Int64 destinationOffset, Byte value);
        void Out16(AddressSpace space, Int64 destinationOffset, Int16 value);
        void Out32(AddressSpace space, Int64 destinationOffset, Int32 value);
        void Out64(AddressSpace space, Int64 destinationOffset, Int64 value);
        Byte[] MoveIn8(AddressSpace space, Int64 sourceOffset, Int64 count);
        void MoveIn8(AddressSpace space, Int64 sourceOffset, Int64 count, Byte[] destinationBuffer, Int64 destinationIndex);
        Int16[] MoveIn16(AddressSpace space, Int64 sourceOffset, Int64 count);
        void MoveIn16(AddressSpace space, Int64 sourceOffset, Int64 count, Int16[] destinationBuffer, Int64 destinationIndex);
        Int32[] MoveIn32(AddressSpace space, Int64 sourceOffset, Int64 count);
        void MoveIn32(AddressSpace space, Int64 sourceOffset, Int64 count, Int32[] destinationBuffer, Int64 destinationIndex);
        Int64[] MoveIn64(AddressSpace space, Int64 sourceOffset, Int64 count);
        void MoveIn64(AddressSpace space, Int64 sourceOffset, Int64 count, Int64[] destinationBuffer, Int64 destinationIndex);
        void MoveOut8(AddressSpace space, Int64 destinationOffset, Byte[] sourceBuffer);
        void MoveOut8(AddressSpace space, Int64 destinationOffset, Byte[] sourceBuffer, Int64 sourceIndex, Int64 count);
        void MoveOut16(AddressSpace space, Int64 destinationOffset, Int16[] sourceBuffer);
        void MoveOut16(AddressSpace space, Int64 destinationOffset, Int16[] sourceBuffer, Int64 sourceIndex, Int64 count);
        void MoveOut32(AddressSpace space, Int64 destinationOffset, Int32[] sourceBuffer);
        void MoveOut32(AddressSpace space, Int64 destinationOffset, Int32[] sourceBuffer, Int64 sourceIndex, Int64 count);
        void MoveOut64(AddressSpace space, Int64 destinationOffset, Int64[] sourceBuffer);
        void MoveOut64(AddressSpace space, Int64 destinationOffset, Int64[] sourceBuffer, Int64 sourceIndex, Int64 count);
    }
    public interface IMemoryMap : IDisposable
    {
        AddressSpace AddressSpace { get; }
        Int64 BaseAddress { get; }
        Int64 Size { get; }
        IntPtr VirtualAddress { get; }
        Byte Peek8(Int64 offset);
        Int16 Peek16(Int64 offset);
        Int32 Peek32(Int64 offset);
        Int64 Peek64(Int64 offset);
        void Poke8(Int64 offset, Byte value);
        void Poke16(Int64 offset, Int16 value);
        void Poke32(Int64 offset, Int32 value);
        void Poke64(Int64 offset, Int64 value);
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
    public interface IPxiMemorySession : IRegisterBasedSession
    {
        Int64 MemoryAllocate(Int64 size);
        Int64 MemoryAllocate(Int64 size, Boolean require32BitRegion);
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
    public interface IResourceManager : IDisposable
    {
        IEnumerable<String> Find(String pattern);
        ParseResult Parse(String resourceName);
        IVisaSession Open(String resourceName);
        IVisaSession Open(String resourceName, AccessMode accessMode, Int32 timeoutMilliseconds);
        IVisaSession Open(String resourceName, AccessMode accessModes, Int32 timeoutMilliseconds, out ResourceOpenStatus openStatus);
        String ManufacturerName { get; }
        Int16 ManufacturerId { get; }
        Version ImplementationVersion { get; }
        Version SpecificationVersion { get; }
    }

    public class ParseResult
    {
        public String OriginalResourceName { get; private set; } = String.Empty;
        public HardwareInterfaceType InterfaceType { get; private set; }
        public Int32 InterfaceNumber { get; private set; }
        public String ResourceClass { get; private set; } = String.Empty;
        public String ExpandedUnaliasedName { get; private set; } = String.Empty;
        public String AliasIfExists { get; private set; } = String.Empty;
        public ParseResult(String originalResourceName, HardwareInterfaceType interfaceType, Int16 interfaceNumber, String resourceClass, String expandedUnaliasedName, String aliasIfExists) { }
        public static Boolean operator ==(ParseResult parse1, ParseResult parse2) { return true; }
        public static Boolean operator !=(ParseResult parse1, ParseResult parse2) { return true; }
        public override bool Equals(object? o) { return true; }
        public override int GetHashCode() { return 0; }
    }
    public class IMessage
    {
        public int Timeout { get; set; }
    }
    public static class GlobalResourceManager
    {
        public static IEnumerable<String> Find()
        {
            throw new NotImplementedException();
        }
        public static IEnumerable<String> Find(String pattern)
        {
            throw new NotImplementedException();
        }
        public static ParseResult Parse(String resourceName)
        {
            throw new NotImplementedException();
        }
        public static Boolean TryParse(String resourceName, out ParseResult result)
        {
            throw new NotImplementedException();
        }
        public static IVisaSession Open(String resourceName)
        {
            return Open(resourceName, AccessMode.None, 10 * 1000);
        }
        public static IVisaSession Open(String resourceName, AccessMode accessMode, Int32 timeoutMilliseconds)
        {
            ResourceOpenStatus openStatus;
            return Open(resourceName, accessMode, timeoutMilliseconds, out openStatus);
        }
        public static IVisaSession Open(String resourceName, AccessMode accessModes, Int32 timeoutMilliseconds, out ResourceOpenStatus openStatus)
        {
            IVisaSession sesn = new Vxi11Session(resourceName);
            openStatus = ResourceOpenStatus.Success;
            return sesn;
        }
        public static String ManufacturerName { get; } = String.Empty;
        public static Int16 ManufacturerId { get; }
        public static Version ImplementationVersion { get; } = Environment.Version;
        public static Version SpecificationVersion { get; } = Environment.Version;
    }
    public class ResourceManager : IResourceManager
    {
        private bool disposedValue;

        public string ManufacturerName => throw new NotImplementedException();

        public short ManufacturerId => throw new NotImplementedException();

        public Version ImplementationVersion => throw new NotImplementedException();

        public Version SpecificationVersion => throw new NotImplementedException();

        public IEnumerable<string> Find(string pattern)
        {
            throw new NotImplementedException();
        }

        public IMessage Open(string str, AccessMode mode, int a, string b)
        {
            return new IMessage();
        }

        public IVisaSession Open(string resourceName)
        {
            return Open(resourceName, AccessMode.None, 10 * 1000);
        }

        public IVisaSession Open(string resourceName, AccessMode accessMode, int timeoutMilliseconds)
        {
            ResourceOpenStatus openStatus;
            return Open(resourceName, accessMode, timeoutMilliseconds, out openStatus);
        }

        public IVisaSession Open(string resourceName, AccessMode accessModes, int timeoutMilliseconds, out ResourceOpenStatus openStatus)
        {
            IVisaSession sesn = new Vxi11Session(resourceName);
            openStatus = ResourceOpenStatus.Success;
            return sesn;
        }

        public ParseResult Parse(string resourceName)
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: マネージド状態を破棄します (マネージド オブジェクト)
                }

                // TODO: アンマネージド リソース (アンマネージド オブジェクト) を解放し、ファイナライザーをオーバーライドします
                // TODO: 大きなフィールドを null に設定します
                disposedValue = true;
            }
        }

 
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
    public class Vxi11RawIO488 : IMessageBasedRawIO
    {
        private Vxi11Session sesn;
        public Vxi11RawIO488(Vxi11Session sesn)
        {
            this.sesn = sesn;
        }

        public void AbortAsyncOperation(IVisaAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public IVisaAsyncResult BeginRead(int count)
        {
            throw new NotImplementedException();
        }

        public IVisaAsyncResult BeginRead(int count, object state)
        {
            throw new NotImplementedException();
        }

        public IVisaAsyncResult BeginRead(int count, VisaAsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public IVisaAsyncResult BeginRead(byte[] buffer)
        {
            throw new NotImplementedException();
        }

        public IVisaAsyncResult BeginRead(byte[] buffer, object state)
        {
            throw new NotImplementedException();
        }

        public IVisaAsyncResult BeginRead(byte[] buffer, long index, long count)
        {
            throw new NotImplementedException();
        }

        public IVisaAsyncResult BeginRead(byte[] buffer, long index, long count, object state)
        {
            throw new NotImplementedException();
        }

        public IVisaAsyncResult BeginRead(byte[] buffer, VisaAsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public IVisaAsyncResult BeginRead(byte[] buffer, long index, long count, VisaAsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public IVisaAsyncResult BeginWrite(string buffer)
        {
            throw new NotImplementedException();
        }

        public IVisaAsyncResult BeginWrite(string buffer, object state)
        {
            throw new NotImplementedException();
        }

        public IVisaAsyncResult BeginWrite(string buffer, VisaAsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public IVisaAsyncResult BeginWrite(byte[] buffer)
        {
            throw new NotImplementedException();
        }

        public IVisaAsyncResult BeginWrite(byte[] buffer, object state)
        {
            throw new NotImplementedException();
        }

        public IVisaAsyncResult BeginWrite(byte[] buffer, long index, long count)
        {
            throw new NotImplementedException();
        }

        public IVisaAsyncResult BeginWrite(byte[] buffer, long index, long count, object state)
        {
            throw new NotImplementedException();
        }

        public IVisaAsyncResult BeginWrite(byte[] buffer, VisaAsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public IVisaAsyncResult BeginWrite(byte[] buffer, long index, long count, VisaAsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public long EndRead(IVisaAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public string EndReadString(IVisaAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public void EndWrite(IVisaAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public byte[] Read()
        {
            throw new NotImplementedException();
        }

        public byte[] Read(long count)
        {
            throw new NotImplementedException();
        }

        public byte[] Read(long count, out ReadStatus readStatus)
        {
            throw new NotImplementedException();
        }

        public void Read(byte[] buffer, long index, long count, out long actualCount, out ReadStatus readStatus)
        {
            throw new NotImplementedException();
        }

        public string ReadString()
        {
            throw new NotImplementedException();
        }

        public string ReadString(long count)
        {
            throw new NotImplementedException();
        }

        public string ReadString(long count, out ReadStatus readStatus)
        {
            throw new NotImplementedException();
        }

        public void Write(byte[] buffer)
        {
            throw new NotImplementedException();
        }

        public void Write(byte[] buffer, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void Write(string buffer)
        {
            throw new NotImplementedException();
        }

        public void Write(string buffer, long index, long count)
        {
            throw new NotImplementedException();
        }
    }
    public class Vxi11FormattedIO488 : IMessageBasedFormattedIO
    {
        private Vxi11Session sesn;
        public IMessage IO = new IMessage();

        public BinaryEncoding BinaryEncoding_ { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int ReadBufferSize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int WriteBufferSize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ITypeFormatter TypeFormatter { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Vxi11FormattedIO488(Vxi11Session sesn)
        {
            this.sesn = sesn;
        }
        public void WriteLine(string msg)
        {
            throw new NotImplementedException();
        }
        public void WriteString(string str) { }

        public string ReadLine()
        {
            throw new NotImplementedException();
        }
        public string ReadString()
        {
            throw new NotImplementedException();
        }

        public void DiscardBuffers()
        {
            throw new NotImplementedException();
        }

        public void FlushWrite(bool sendEnd)
        {
            throw new NotImplementedException();
        }

        public void Printf(string data)
        {
            throw new NotImplementedException();
        }

        public void Printf(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void PrintfAndFlush(string data)
        {
            throw new NotImplementedException();
        }

        public void PrintfAndFlush(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Scanf<T>(string format, out T output)
        {
            throw new NotImplementedException();
        }

        public void Scanf<T1, T2>(string format, out T1 output1, out T2 output2)
        {
            throw new NotImplementedException();
        }

        public void Scanf<T1, T2, T3>(string format, out T1 output1, out T2 output2, out T3 output3)
        {
            throw new NotImplementedException();
        }

        public void Scanf<T1, T2, T3, T4>(string format, out T1 output1, out T2 output2, out T3 output3, out T4 output4)
        {
            throw new NotImplementedException();
        }

        public void Scanf<T1, T2, T3, T4, T5>(string format, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5)
        {
            throw new NotImplementedException();
        }

        public void Scanf<T1, T2, T3, T4, T5, T6>(string format, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5, out T6 output6)
        {
            throw new NotImplementedException();
        }

        public void Scanf<T1, T2, T3, T4, T5, T6, T7>(string format, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5, out T6 output6, out T7 output7)
        {
            throw new NotImplementedException();
        }

        public void Scanf<T>(string format, int[] inputs, out T output)
        {
            throw new NotImplementedException();
        }

        public void Scanf<T1, T2>(string format, int[] inputs, out T1 output1, out T2 output2)
        {
            throw new NotImplementedException();
        }

        public void Scanf<T1, T2, T3>(string format, int[] inputs, out T1 output1, out T2 output2, out T3 output3)
        {
            throw new NotImplementedException();
        }

        public void Scanf<T1, T2, T3, T4>(string format, int[] inputs, out T1 output1, out T2 output2, out T3 output3, out T4 output4)
        {
            throw new NotImplementedException();
        }

        public void Scanf<T1, T2, T3, T4, T5>(string format, int[] inputs, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5)
        {
            throw new NotImplementedException();
        }

        public void Scanf<T1, T2, T3, T4, T5, T6>(string format, int[] inputs, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5, out T6 output6)
        {
            throw new NotImplementedException();
        }

        public void Scanf<T1, T2, T3, T4, T5, T6, T7>(string format, int[] inputs, out T1 output1, out T2 output2, out T3 output3, out T4 output4, out T5 output5, out T6 output6, out T7 output7)
        {
            throw new NotImplementedException();
        }

        public void Write(char data)
        {
            throw new NotImplementedException();
        }

        public void Write(string data)
        {
            throw new NotImplementedException();
        }

        public void Write(long data)
        {
            throw new NotImplementedException();
        }

        public void Write(ulong data)
        {
            throw new NotImplementedException();
        }

        public void Write(double data)
        {
            throw new NotImplementedException();
        }

        public void WriteLine()
        {
            throw new NotImplementedException();
        }

        public void WriteLine(char data)
        {
            throw new NotImplementedException();
        }

        public void WriteLine(long data)
        {
            throw new NotImplementedException();
        }

        public void WriteLine(ulong data)
        {
            throw new NotImplementedException();
        }

        public void WriteLine(double data)
        {
            throw new NotImplementedException();
        }

        public void WriteList(byte[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteList(byte[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteList(sbyte[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteList(sbyte[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteList(short[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteList(short[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteList(ushort[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteList(ushort[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteList(int[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteList(int[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteList(uint[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteList(uint[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteList(long[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteList(long[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteList(ulong[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteList(ulong[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteList(float[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteList(float[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteList(double[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteList(double[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteLineList(byte[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteLineList(byte[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteLineList(sbyte[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteLineList(sbyte[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteLineList(short[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteLineList(short[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteLineList(ushort[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteLineList(ushort[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteLineList(int[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteLineList(int[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteLineList(uint[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteLineList(uint[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteLineList(long[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteLineList(long[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteLineList(ulong[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteLineList(ulong[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteLineList(float[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteLineList(float[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteLineList(double[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteLineList(double[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(byte[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(byte[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(sbyte[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(sbyte[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(short[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(short[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(ushort[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(ushort[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(int[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(int[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(uint[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(uint[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(long[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(long[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(ulong[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(ulong[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(float[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(float[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(double[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(double[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteBinaryAndFlush(byte[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteBinaryAndFlush(byte[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteBinaryAndFlush(sbyte[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteBinaryAndFlush(sbyte[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteBinaryAndFlush(short[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteBinaryAndFlush(short[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteBinaryAndFlush(ushort[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteBinaryAndFlush(ushort[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteBinaryAndFlush(int[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteBinaryAndFlush(int[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteBinaryAndFlush(uint[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteBinaryAndFlush(uint[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteBinaryAndFlush(long[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteBinaryAndFlush(long[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteBinaryAndFlush(ulong[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteBinaryAndFlush(ulong[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteBinaryAndFlush(float[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteBinaryAndFlush(float[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public void WriteBinaryAndFlush(double[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteBinaryAndFlush(double[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public string ReadString(int count)
        {
            throw new NotImplementedException();
        }

        public int ReadString(StringBuilder data)
        {
            throw new NotImplementedException();
        }

        public int ReadString(StringBuilder data, int count)
        {
            throw new NotImplementedException();
        }

        public char ReadChar()
        {
            throw new NotImplementedException();
        }

        public long ReadInt64()
        {
            throw new NotImplementedException();
        }

        public ulong ReadUInt64()
        {
            throw new NotImplementedException();
        }

        public double ReadDouble()
        {
            throw new NotImplementedException();
        }

        public int ReadLine(StringBuilder data)
        {
            throw new NotImplementedException();
        }

        public char ReadLineChar()
        {
            throw new NotImplementedException();
        }

        public long ReadLineInt64()
        {
            throw new NotImplementedException();
        }

        public ulong ReadLineUInt64()
        {
            throw new NotImplementedException();
        }

        public double ReadLineDouble()
        {
            throw new NotImplementedException();
        }

        public byte[] ReadListOfByte(long count)
        {
            throw new NotImplementedException();
        }

        public long ReadListOfByte(byte[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public sbyte[] ReadListOfSByte(long count)
        {
            throw new NotImplementedException();
        }

        public long ReadListOfSByte(sbyte[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public short[] ReadListOfInt16(long count)
        {
            throw new NotImplementedException();
        }

        public long ReadListOfInt16(short[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public ushort[] ReadListOfUInt16(long count)
        {
            throw new NotImplementedException();
        }

        public long ReadListOfUInt16(ushort[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public int[] ReadListOfInt32(long count)
        {
            throw new NotImplementedException();
        }

        public long ReadListOfInt32(int[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public uint[] ReadListOfUInt32(long count)
        {
            throw new NotImplementedException();
        }

        public long ReadListOfUInt32(uint[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public long[] ReadListOfInt64(long count)
        {
            throw new NotImplementedException();
        }

        public long ReadListOfInt64(long[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public ulong[] ReadListOfUInt64(long count)
        {
            throw new NotImplementedException();
        }

        public long ReadListOfUInt64(ulong[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public float[] ReadListOfSingle(long count)
        {
            throw new NotImplementedException();
        }

        public long ReadListOfSingle(float[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public double[] ReadListOfDouble(long count)
        {
            throw new NotImplementedException();
        }

        public long ReadListOfDouble(double[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public byte[] ReadLineListOfByte()
        {
            throw new NotImplementedException();
        }

        public long ReadLineListOfByte(byte[] data, long index)
        {
            throw new NotImplementedException();
        }

        public sbyte[] ReadLineListOfSByte()
        {
            throw new NotImplementedException();
        }

        public long ReadLineListOfSByte(sbyte[] data, long index)
        {
            throw new NotImplementedException();
        }

        public short[] ReadLineListOfInt16()
        {
            throw new NotImplementedException();
        }

        public long ReadLineListOfInt16(short[] data, long index)
        {
            throw new NotImplementedException();
        }

        public ushort[] ReadLineListOfUInt16()
        {
            throw new NotImplementedException();
        }

        public long ReadLineListOfUInt16(ushort[] data, long index)
        {
            throw new NotImplementedException();
        }

        public int[] ReadLineListOfInt32()
        {
            throw new NotImplementedException();
        }

        public long ReadLineListOfInt32(int[] data, long index)
        {
            throw new NotImplementedException();
        }

        public uint[] ReadLineListOfUInt32()
        {
            throw new NotImplementedException();
        }

        public long ReadLineListOfUInt32(uint[] data, long index)
        {
            throw new NotImplementedException();
        }

        public long[] ReadLineListOfInt64()
        {
            throw new NotImplementedException();
        }

        public long ReadLineListOfInt64(long[] data, long index)
        {
            throw new NotImplementedException();
        }

        public ulong[] ReadLineListOfUInt64()
        {
            throw new NotImplementedException();
        }

        public long ReadLineListOfUInt64(ulong[] data, long index)
        {
            throw new NotImplementedException();
        }

        public float[] ReadLineListOfSingle()
        {
            throw new NotImplementedException();
        }

        public long ReadLineListOfSingle(float[] data, long index)
        {
            throw new NotImplementedException();
        }

        public double[] ReadLineListOfDouble()
        {
            throw new NotImplementedException();
        }

        public long ReadLineListOfDouble(double[] data, long index)
        {
            throw new NotImplementedException();
        }

        public byte[] ReadBinaryBlockOfByte()
        {
            throw new NotImplementedException();
        }

        public byte[] ReadBinaryBlockOfByte(bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public long ReadBinaryBlockOfByte(byte[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public long ReadBinaryBlockOfByte(byte[] data, long index, long count, bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public sbyte[] ReadBinaryBlockOfSByte()
        {
            throw new NotImplementedException();
        }

        public sbyte[] ReadBinaryBlockOfSByte(bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public long ReadBinaryBlockOfSByte(sbyte[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public long ReadBinaryBlockOfSByte(sbyte[] data, long index, long count, bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public short[] ReadBinaryBlockOfInt16()
        {
            throw new NotImplementedException();
        }

        public short[] ReadBinaryBlockOfInt16(bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public long ReadBinaryBlockOfInt16(short[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public long ReadBinaryBlockOfInt16(short[] data, long index, long count, bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public ushort[] ReadBinaryBlockOfUInt16()
        {
            throw new NotImplementedException();
        }

        public ushort[] ReadBinaryBlockOfUInt16(bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public long ReadBinaryBlockOfUInt16(ushort[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public long ReadBinaryBlockOfUInt16(ushort[] data, long index, long count, bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public int[] ReadBinaryBlockOfInt32()
        {
            throw new NotImplementedException();
        }

        public int[] ReadBinaryBlockOfInt32(bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public long ReadBinaryBlockOfInt32(int[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public long ReadBinaryBlockOfInt32(int[] data, long index, long count, bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public uint[] ReadBinaryBlockOfUInt32()
        {
            throw new NotImplementedException();
        }

        public uint[] ReadBinaryBlockOfUInt32(bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public long ReadBinaryBlockOfUInt32(uint[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public long ReadBinaryBlockOfUInt32(uint[] data, long index, long count, bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public long[] ReadBinaryBlockOfInt64()
        {
            throw new NotImplementedException();
        }

        public long ReadBinaryBlockOfInt64(long[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public ulong[] ReadBinaryBlockOfUInt64()
        {
            throw new NotImplementedException();
        }

        public long ReadBinaryBlockOfUInt64(ulong[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public float[] ReadBinaryBlockOfSingle()
        {
            throw new NotImplementedException();
        }

        public float[] ReadBinaryBlockOfSingle(bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public long ReadBinaryBlockOfSingle(float[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public long ReadBinaryBlockOfSingle(float[] data, long index, long count, bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public double[] ReadBinaryBlockOfDouble()
        {
            throw new NotImplementedException();
        }

        public double[] ReadBinaryBlockOfDouble(bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public long ReadBinaryBlockOfDouble(double[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public long ReadBinaryBlockOfDouble(double[] data, long index, long count, bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public byte[] ReadLineBinaryBlockOfByte()
        {
            throw new NotImplementedException();
        }

        public byte[] ReadLineBinaryBlockOfByte(bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public long ReadLineBinaryBlockOfByte(byte[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public long ReadLineBinaryBlockOfByte(byte[] data, long index, long count, bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public sbyte[] ReadLineBinaryBlockOfSByte()
        {
            throw new NotImplementedException();
        }

        public sbyte[] ReadLineBinaryBlockOfSByte(bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public long ReadLineBinaryBlockOfSByte(sbyte[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public long ReadLineBinaryBlockOfSByte(sbyte[] data, long index, long count, bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public short[] ReadLineBinaryBlockOfInt16()
        {
            throw new NotImplementedException();
        }

        public short[] ReadLineBinaryBlockOfInt16(bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public long ReadLineBinaryBlockOfInt16(short[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public long ReadLineBinaryBlockOfInt16(short[] data, long index, long count, bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public ushort[] ReadLineBinaryBlockOfUInt16()
        {
            throw new NotImplementedException();
        }

        public ushort[] ReadLineBinaryBlockOfUInt16(bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public long ReadLineBinaryBlockOfUInt16(ushort[] data, long index, long coun)
        {
            throw new NotImplementedException();
        }

        public long ReadLineBinaryBlockOfUInt16(ushort[] data, long index, long count, bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public int[] ReadLineBinaryBlockOfInt32()
        {
            throw new NotImplementedException();
        }

        public int[] ReadLineBinaryBlockOfInt32(bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public long ReadLineBinaryBlockOfInt32(int[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public long ReadLineBinaryBlockOfInt32(int[] data, long index, long count, bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public uint[] ReadLineBinaryBlockOfUInt32()
        {
            throw new NotImplementedException();
        }

        public uint[] ReadLineBinaryBlockOfUInt32(bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public long ReadLineBinaryBlockOfUInt32(uint[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public long ReadLineBinaryBlockOfUInt32(uint[] data, long index, long count, bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public long[] ReadLineBinaryBlockOfInt64()
        {
            throw new NotImplementedException();
        }

        public long ReadLineBinaryBlockOfInt64(long[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public ulong[] ReadLineBinaryBlockOfUInt64()
        {
            throw new NotImplementedException();
        }

        public long ReadLineBinaryBlockOfUInt64(ulong[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public float[] ReadLineBinaryBlockOfSingle()
        {
            throw new NotImplementedException();
        }

        public float[] ReadLineBinaryBlockOfSingle(bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public long ReadLineBinaryBlockOfSingle(float[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public long ReadLineBinaryBlockOfSingle(float[] data, long index, long count, bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public double[] ReadLineBinaryBlockOfDouble()
        {
            throw new NotImplementedException();
        }

        public double[] ReadLineBinaryBlockOfDouble(bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public long ReadLineBinaryBlockOfDouble(double[] data, long index, long count)
        {
            throw new NotImplementedException();
        }

        public long ReadLineBinaryBlockOfDouble(double[] data, long index, long count, bool seekToBlock)
        {
            throw new NotImplementedException();
        }

        public string ReadWhileMatch(string characters)
        {
            throw new NotImplementedException();
        }

        public string ReadUntilMatch(char ch)
        {
            throw new NotImplementedException();
        }

        public string ReadUntilMatch(string characters, bool discardMatch)
        {
            throw new NotImplementedException();
        }

        public string ReadUntilEnd()
        {
            throw new NotImplementedException();
        }

        public void Skip(long count)
        {
            throw new NotImplementedException();
        }

        public void SkipString(string data)
        {
            throw new NotImplementedException();
        }

        public void SkipUntilEnd()
        {
            throw new NotImplementedException();
        }
    }
    public class Vxi11Session : ITcpipSocketSession
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
        public void Dispose() { }

        public String Address { get; } = string.Empty;
        public String HostName { get; } = string.Empty;
        public Boolean KeepAlive { get; set; }
        public Boolean NoDelay { get; set; }
        public Int16 Port { get; }
        public void Flush(IOBuffers buffers, Boolean discard) { }
        public Boolean SetBufferSize(IOBuffers buffers, Int32 size) { return true;  }
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
        private ClientVxi11 client = new ClientVxi11();

        private int lock_timeout = default_timeout_value;
        private int io_timeout = default_timeout_value;
        private int lid;
        private int abortPort;
        private int maxRecvSize;
        public static void ServiceRequestHandler(object? sender, VisaEventArgs args)
        {
            return;
        }
        public Vxi11Session(string resourceName)
        {
            // TCPIP[board]::host address[::LAN device name][::INSTR]
            this.Address = "127.0.0.1";
            this.Port = 10240;
            string deviceName = "inst0";
            client.Create(this.Address, this.Port);
            int clientId = 0;
            int lockDevice = 0;
            client.CreateLink(clientId, lockDevice, this.lock_timeout, deviceName, out this.lid, out this.abortPort, out this.maxRecvSize);

            this.FormattedIO = new Vxi11FormattedIO488(this);
            this.RawIO = new Vxi11RawIO488(this);
            this.ServiceRequest = ServiceRequestHandler;
        }
        public int Read(string buf, int count, out int retCount)
        {
            Vxi11.Flags flags = Vxi11.Flags.end;
            Vxi11.TermChar term = Vxi11.TermChar.None;
            int reason = 0;
            byte[] data = new byte[count];
            client.DeviceRead(this.lid, count, flags, this.lock_timeout, this.io_timeout, term, out reason, out data);
            retCount = data.Length;
            return 0;
        }
        public int Write(string buf, int count, out int retCount)
        {
            Vxi11.Flags flags = Vxi11.Flags.end;
            client.DeviceWrite(this.lid, flags, this.lock_timeout, this.io_timeout, buf, out retCount);
            return 0;
        }
        public int Terminate()
        {
            client.Create(this.Address, this.abortPort);
            Vxi11.Flags flags = Vxi11.Flags.end;
            client.DeviceAbort(this.lid, flags, this.lock_timeout, this.io_timeout);
            return 0;
        }
    }
}