using System;
using System.Runtime.Serialization;

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
}