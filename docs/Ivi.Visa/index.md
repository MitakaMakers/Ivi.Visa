# Mm.Ivi.Visa implemented functions

|No.|Class|Functions|TCPIP::VXI-11|TCPIP::HiSLIP|TCPIP::SOCKET|
|----|----|----|----|----|----|
|1|IResourceManager|IEnumerable<String> Find(String pattern)|N|N|N|
|2||ParseResult Parse(String resourceName)|N|N|N|
|3||IVisaSession Open(String resourceName)|N|N|N|
|4||IVisaSession Open(String resourceName, AccessModes accessMode, Int32 timeoutMilliseconds)|N|N|N|
|5||IVisaSession Open(String resourceName, AccessModes accessModes, Int32 timeoutMilliseconds, out ResourceOpenStatus openStatus)|N|N|N|
|6||String ManufacturerName { get; }|N|N|N|
|7||Int16 ManufacturerId { get; }|N|N|N|
|8||Version ImplementationVersion { get; }|N|N|N|
|9||Version SpecificationVersion { get; }|N|N|N|
|10|GlobalResourceManager|public static IEnumerable<String> Find() {…}|N|N|N|
|11||public static IEnumerable<String> Find(String pattern) {…}|N|N|N|
|12||public static ParseResult Parse(String resourceName) {…}|N|N|N|
|13||public static Boolean TryParse(String resourceName, out ParseResult result) {…}|N|N|N|
|14||public static IVisaSession Open(String resourceName) {…}|N|N|N|
|15||public static IVisaSession Open(String resourceName, AccessModes accessMode, Int32 timeoutMilliseconds) {…}|N|N|N|
|16||public static IVisaSession Open(String resourceName, AccessModes accessModes, Int32 timeoutMilliseconds, out ResourceOpenStatus openStatus) {…}|N|N|N|
|17||public static String ManufacturerName { get; }|N|N|N|
|18||public static Int16 ManufacturerId { get; }|N|N|N|
|19||public static Version ImplementationVersion { get; }|N|N|N|
|20||public static Version SpecificationVersion { get; }|N|N|N|
|21|ParseResult|public String OriginalResourceName { get; private set; }|N|N|N|
|22||public HardwareInterfaceType InterfaceType { get; private set; }|N|N|N|
|23||public Int32 InterfaceNumber { get; private set; }|N|N|N|
|24||public String ResourceClass { get; private set; }|N|N|N|
|25||public String ExpandedUnaliasedName { get; private set; }|N|N|N|
|26||public String AliasIfExists { get; private set; }|N|N|N|
|27||public ParseResult(String originalResourceName, HardwareInterfaceType interfaceType, Int16 interfaceNumber, String resourceClass, String expandedUnaliasedName, String aliasIfExists) {…}|N|N|N|
|28||public static Boolean operator ==(ParseResult parse1, ParseResult parse2)|N|N|N|
|29||public static Boolean operator !=(ParseResult parse1, ParseResult parse2)|N|N|N|
|30|IVisaSession|Int32 TimeoutMilliseconds { get set }|N|N|N|
|31||String ResourceName { get }|N|N|N|
|32||String HardwareInterfaceName { get }|N|N|N|
|33||HardwareInterfaceType HardwareInterfaceType { get }|N|N|N|
|34||Int16 HardwareInterfaceNumber { get }|N|N|N|
|35||String ResourceClass { get }|N|N|N|
|36||String ResourceManufacturerName { get }|N|N|N|
|37||Int16 ResourceManufacturerId { get }|N|N|N|
|38||Version ResourceImplementationVersion { get }|N|N|N|
|39||Version ResourceSpecificationVersion { get }|N|N|N|
|40||ResourceLockState ResourceLockState { get }|N|N|N|
|41||void LockResource()|N|N|N|
|42||void LockResource(TimeSpan timeout)|N|N|N|
|43||void LockResource(Int32 timeoutMilliseconds)|N|N|N|
|44||string LockResource(TimeSpan timeout, String sharedKey)|N|N|N|
|45||string LockResource(Int32 timeoutMilliseconds, String sharedKey)|N|N|N|
|46||void UnlockResource()|N|N|N|
|47||Int32 EventQueueCapacity { get set }|N|N|N|
|48||Boolean SynchronizeCallbacks { get set }|N|N|N|
|49||void EnableEvent(EventType eventType)|N|N|N|
|50||void DisableEvent(EventType eventType)|N|N|N|
|51||void DiscardEvent(EventType eventType)|N|N|N|
|52||VisaEventArgs WaitOnEvent(EventType eventType)|N|N|N|
|53||VisaEventArgs WaitOnEvent(EventType eventType, out EventQueueStatus status)|N|N|N|
|54||VisaEventArgs WaitOnEvent(EventType eventType, Int32 timeoutMilliseconds)|N|N|N|
|55||VisaEventArgs WaitOnEvent(EventType eventType, TimeSpan timeout)|N|N|N|
|56||VisaEventArgs WaitOnEvent(EventType eventType, Int32 timeoutMilliseconds,　out EventQueueStatus status)|N|N|N|
|57||VisaEventArgs WaitOnEvent(EventType eventType, TimeSpan timeout,　out EventQueueStatus status)|N|N|N|
|58|IMessageBasedSession|event EventHandler<VisaEventArgs> ServiceRequest|N|N|N|
|59||IOProtocol IOProtocol { get set }|N|N|N|
|60||Boolean SendEndEnabled { get set }|N|N|Y|
|61||Byte TerminationCharacter { get set }|N|N|Y|
|62||Boolean TerminationCharacterEnabled { get set }|N|N|Y|
|63||void AssertTrigger()|Y|Y|N|
|64||void Clear()|Y|Y|N|
|65||StatusByteFlags ReadStatusByte()|Y|Y|N|
|66||IMessageBasedFormattedIO FormattedIO { get }|N|N|N|
|67||IMessageBasedRawIO RawIO { get }|N|N|N|
|68||Byte[] Read()|Y|Y|Y|
|69||Byte[] Read(Int64 count)|Y|Y|Y|
|70||Byte[] Read(Int64 count, out ReadStatus readStatus)|Y|Y|Y|
|71||void Read(Byte[] buffer, Int64 index, Int64 count, out Int64 actualCount, out ReadStatus readStatus)|Y|Y|Y|
|72||unsafe void Read(Byte* buffer, Int64 index, Int64 count, out Int64 actualCount, out ReadStatus readStatus)|Y|Y|Y|
|73||String ReadString()|Y|Y|Y|
|74||String ReadString(Int64 count)|Y|Y|Y|
|75||String ReadString(Int64 count, out ReadStatus readStatus)|Y|Y|Y|
|76||void Write(Byte[] buffer)|Y|Y|Y|
|77||void Write(Byte[] buffer, Int64 index, Int64 count)|Y|Y|Y|
|78||void Write(String buffer)|Y|Y|Y|
|79||void Write(String buffer, Int64 index, Int64 count)|Y|Y|Y|
|80||unsafe void Write(Byte* buffer, Int64 index, Int64 count)|Y|Y|Y|
