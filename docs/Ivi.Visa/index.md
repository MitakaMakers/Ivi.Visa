# Mm.Ivi.Visa implemented functions

|No.|Class|Functions|VXI|GPIB-VXI|GPIB|ASRL|TCPIP::SERVANT|TCPIP::VXI-11|TCPIP::HiSLIP|TCPIP::SOCKET|USB|PXI|
|----|----|----|----|----|----|----|----|----|----|----|----|----|
|1|IResourceManager|IEnumerable<String> Find(String pattern)|N|N|N|N|N|N|N|N|N|N|
|2||ParseResult Parse(String resourceName)|N|N|N|N|N|N|N|N|N|N|
|3||IVisaSession Open(String resourceName)|N|N|N|N|N|N|N|N|N|N|
|4||IVisaSession Open(String resourceName, AccessModes accessMode, Int32 timeoutMilliseconds)|N|N|N|N|N|N|N|N|N|N|
|5||IVisaSession Open(String resourceName, AccessModes accessModes, Int32 timeoutMilliseconds, out ResourceOpenStatus openStatus)|N|N|N|N|N|N|N|N|N|N|
|6||String ManufacturerName { get; }|N|N|N|N|N|N|N|N|N|N|
|7||Int16 ManufacturerId { get; }|N|N|N|N|N|N|N|N|N|N|
|8||Version ImplementationVersion { get; }|N|N|N|N|N|N|N|N|N|N|
|9||Version SpecificationVersion { get; }|N|N|N|N|N|N|N|N|N|N|
|10|GlobalResourceManager|public static IEnumerable<String> Find() {…}|N|N|N|N|N|N|N|N|N|N|
|11||public static IEnumerable<String> Find(String pattern) {…}|N|N|N|N|N|N|N|N|N|N|
|12||public static ParseResult Parse(String resourceName) {…}|N|N|N|N|N|N|N|N|N|N|
|13||public static Boolean TryParse(String resourceName, out ParseResult result) {…}|N|N|N|N|N|N|N|N|N|N|
|14||public static IVisaSession Open(String resourceName) {…}|N|N|N|N|N|N|N|N|N|N|
|15||public static IVisaSession Open(String resourceName, AccessModes accessMode, Int32 timeoutMilliseconds) {…}|N|N|N|N|N|N|N|N|N|N|
|16||public static IVisaSession Open(String resourceName, AccessModes accessModes, Int32 timeoutMilliseconds, out ResourceOpenStatus openStatus) {…}|N|N|N|N|N|N|N|N|N|N|
|17||public static String ManufacturerName { get; }|N|N|N|N|N|N|N|N|N|N|
|18||public static Int16 ManufacturerId { get; }|N|N|N|N|N|N|N|N|N|N|
|19||public static Version ImplementationVersion { get; }|N|N|N|N|N|N|N|N|N|N|
|20||public static Version SpecificationVersion { get; }|N|N|N|N|N|N|N|N|N|N|
|21|ParseResult|public String OriginalResourceName { get; private set; }|N|N|N|N|N|N|N|N|N|N|
|22||public HardwareInterfaceType InterfaceType { get; private set; }|N|N|N|N|N|N|N|N|N|N|
|23||public Int32 InterfaceNumber { get; private set; }|N|N|N|N|N|N|N|N|N|N|
|24||public String ResourceClass { get; private set; }|N|N|N|N|N|N|N|N|N|N|
|25||public String ExpandedUnaliasedName { get; private set; }|N|N|N|N|N|N|N|N|N|N|
|26||public String AliasIfExists { get; private set; }|N|N|N|N|N|N|N|N|N|N|
|27||public ParseResult(String originalResourceName, HardwareInterfaceType interfaceType, Int16 interfaceNumber, String resourceClass, String expandedUnaliasedName, String aliasIfExists) {…}|N|N|N|N|N|N|N|N|N|N|
|28||public static Boolean operator ==(ParseResult parse1, ParseResult parse2)|N|N|N|N|N|N|N|N|N|N|
|29||public static Boolean operator !=(ParseResult parse1, ParseResult parse2)|N|N|N|N|N|N|N|N|N|N|
|30|IVisaSession|Int32 TimeoutMilliseconds { get set }|N|N|N|N|N|N|N|N|N|N|
|31||String ResourceName { get }|N|N|N|N|N|N|N|N|N|N|
|32||String HardwareInterfaceName { get }|N|N|N|N|N|N|N|N|N|N|
|33||HardwareInterfaceType HardwareInterfaceType { get }|N|N|N|N|N|N|N|N|N|N|
|34||Int16 HardwareInterfaceNumber { get }|N|N|N|N|N|N|N|N|N|N|
|35||String ResourceClass { get }|N|N|N|N|N|N|N|N|N|N|
|36||String ResourceManufacturerName { get }|N|N|N|N|N|N|N|N|N|N|
|37||Int16 ResourceManufacturerId { get }|N|N|N|N|N|N|N|N|N|N|
|38||Version ResourceImplementationVersion { get }|N|N|N|N|N|N|N|N|N|N|
|39||Version ResourceSpecificationVersion { get }|N|N|N|N|N|N|N|N|N|N|
|40||ResourceLockState ResourceLockState { get }|N|N|N|N|N|N|N|N|N|N|
|41||void LockResource()|N|N|N|N|N|N|N|N|N|N|
|42||void LockResource(TimeSpan timeout)|N|N|N|N|N|N|N|N|N|N|
|43||void LockResource(Int32 timeoutMilliseconds)|N|N|N|N|N|N|N|N|N|N|
|44||string LockResource(TimeSpan timeout, String sharedKey)|N|N|N|N|N|N|N|N|N|N|
|45||string LockResource(Int32 timeoutMilliseconds, String sharedKey)|N|N|N|N|N|N|N|N|N|N|
|46||void UnlockResource()|N|N|N|N|N|N|N|N|N|N|
|47||Int32 EventQueueCapacity { get set }|N|N|N|N|N|N|N|N|N|N|
|48||Boolean SynchronizeCallbacks { get set }|N|N|N|N|N|N|N|N|N|N|
|49||void EnableEvent(EventType eventType)|N|N|N|N|N|N|N|N|N|N|
|50||void DisableEvent(EventType eventType)|N|N|N|N|N|N|N|N|N|N|
|51||void DiscardEvent(EventType eventType)|N|N|N|N|N|N|N|N|N|N|
|52||VisaEventArgs WaitOnEvent(EventType eventType)|N|N|N|N|N|N|N|N|N|N|
|53||VisaEventArgs WaitOnEvent(EventType eventType, out EventQueueStatus status)|N|N|N|N|N|N|N|N|N|N|
|54||VisaEventArgs WaitOnEvent(EventType eventType, Int32 timeoutMilliseconds)|N|N|N|N|N|N|N|N|N|N|
|55||VisaEventArgs WaitOnEvent(EventType eventType, TimeSpan timeout)|N|N|N|N|N|N|N|N|N|N|
|56||VisaEventArgs WaitOnEvent(EventType eventType, Int32 timeoutMilliseconds,　out EventQueueStatus status)|N|N|N|N|N|N|N|N|N|N|
|57||VisaEventArgs WaitOnEvent(EventType eventType, TimeSpan timeout,　out EventQueueStatus status)|N|N|N|N|N|N|N|N|N|N|
|58|IMessageBasedSession|event EventHandler<VisaEventArgs> ServiceRequest|N|N|N|N|N|N|N|N|N|N|
|59||IOProtocol IOProtocol { get set }|N|N|N|N|N|N|N|N|N|N|
|60||Boolean SendEndEnabled { get set }|N|N|N|N|N|N|N|Y|N|N|
|61||Byte TerminationCharacter { get set }|N|N|N|N|N|N|N|Y|N|N|
|62||Boolean TerminationCharacterEnabled { get set }|N|N|N|N|N|N|N|Y|N|N|
|63||void AssertTrigger()|N|N|N|N|N|Y|Y|N|N|N|
|64||void Clear()|N|N|N|N|N|Y|Y|N|N|N|
|65||StatusByteFlags ReadStatusByte()|N|N|N|N|N|Y|Y|N|N|N|
|66||IMessageBasedFormattedIO FormattedIO { get }|N|N|N|N|N|N|N|N|N|N|
|67||IMessageBasedRawIO RawIO { get }|N|N|N|N|N|N|N|N|N|N|
|68||Byte[] Read()|N|N|N|N|N|Y|Y|Y|N|N|
|69||Byte[] Read(Int64 count)|N|N|N|N|N|Y|Y|Y|N|N|
|70||Byte[] Read(Int64 count, out ReadStatus readStatus)|N|N|N|N|N|Y|Y|Y|N|N|
|71||void Read(Byte[] buffer, Int64 index, Int64 count, out Int64 actualCount, out ReadStatus readStatus)|N|N|N|N|N|Y|Y|Y|N|N|
|72||unsafe void Read(Byte* buffer, Int64 index, Int64 count, out Int64 actualCount, out ReadStatus readStatus)|N|N|N|N|N|Y|Y|Y|N|N|
|73||String ReadString()|N|N|N|N|N|Y|Y|Y|N|N|
|74||String ReadString(Int64 count)|N|N|N|N|N|Y|Y|Y|N|N|
|75||String ReadString(Int64 count, out ReadStatus readStatus)|N|N|N|N|N|Y|Y|Y|N|N|
|76||void Write(Byte[] buffer)|N|N|N|N|N|Y|Y|Y|N|N|
|77||void Write(Byte[] buffer, Int64 index, Int64 count)|N|N|N|N|N|Y|Y|Y|N|N|
|78||void Write(String buffer)|N|N|N|N|N|Y|Y|Y|N|N|
|79||void Write(String buffer, Int64 index, Int64 count)|N|N|N|N|N|Y|Y|Y|N|N|
|80||unsafe void Write(Byte* buffer, Int64 index, Int64 count)|N|N|N|N|N|Y|Y|Y|N|N|
|81|INativeVisaSession|Int32 Handle { get }|N|N|N|N|N|N|N|N|N|N|
|82||void EnableEvent(Int32 eventType)|N|N|N|N|N|N|N|N|N|N|
|83||void DisableEvent(Int32 eventType)|N|N|N|N|N|N|N|N|N|N|
|84||void DiscardEvents(Int32 eventType)|N|N|N|N|N|N|N|N|N|N|
|85||INativeVisaEventArgs WaitOnEvent(Int32 eventType)|N|N|N|N|N|N|N|N|N|N|
|86||INativeVisaEventArgs WaitOnEvent(Int32 eventType, out EventQueueStatus status)|N|N|N|N|N|N|N|N|N|N|
|87||INativeVisaEventArgs WaitOnEvent(Int32 eventType, Int32 timeoutMilliseconds)|N|N|N|N|N|N|N|N|N|N|
|88||INativeVisaEventArgs WaitOnEvent(Int32 eventType, TimeSpan timeout)|N|N|N|N|N|N|N|N|N|N|
|89||INativeVisaEventArgs WaitOnEvent(Int32 eventType, Int32 timeoutMilliseconds, out EventQueueStatus status)|N|N|N|N|N|N|N|N|N|N|
|90||INativeVisaEventArgs WaitOnEvent(Int32 eventType, TimeSpan timeout, out EventQueueStatus status)|N|N|N|N|N|N|N|N|N|N|
|91||Byte GetAttributeByte(NativeVisaAttribute attribute)|N|N|N|N|N|N|N|N|N|N|
|92||Byte GetAttributeByte(Int32 attribute)|N|N|N|N|N|N|N|N|N|N|
|93||Int16 GetAttributeInt16(NativeVisaAttribute attribute)|N|N|N|N|N|N|N|N|N|N|
|94||Int16 GetAttributeInt16(Int32 attribute)|N|N|N|N|N|N|N|N|N|N|
|95||Int32 GetAttributeInt32(NativeVisaAttribute attribute)|N|N|N|N|N|N|N|N|N|N|
|96||Int32 GetAttributeInt32(Int32 attribute)|N|N|N|N|N|N|N|N|N|N|
|97||Int64 GetAttributeInt64(NativeVisaAttribute attribute)|N|N|N|N|N|N|N|N|N|N|
|98||Int64 GetAttributeInt64(Int32 attribute)|N|N|N|N|N|N|N|N|N|N|
|99||Boolean GetAttributeBoolean(NativeVisaAttribute attribute)|N|N|N|N|N|N|N|N|N|N|
|100||Boolean GetAttributeBoolean(Int32 attribute)|N|N|N|N|N|N|N|N|N|N|
|101||String GetAttributeString(NativeVisaAttribute attribute)|N|N|N|N|N|N|N|N|N|N|
|102||String GetAttributeString(Int32 attribute)|N|N|N|N|N|N|N|N|N|N|
|103||void SetAttributeByte(NativeVisaAttribute attribute, Byte value)|N|N|N|N|N|N|N|N|N|N|
|104||void SetAttributeByte(Int32 attribute, Byte value)|N|N|N|N|N|N|N|N|N|N|
|105||void SetAttributeInt16(NativeVisaAttribute attribute, Int16 value)|N|N|N|N|N|N|N|N|N|N|
|106||void SetAttributeInt16(Int32 attribute, Int16 value)|N|N|N|N|N|N|N|N|N|N|
|107||void SetAttributeInt32(NativeVisaAttribute attribute, Int32 value)|N|N|N|N|N|N|N|N|N|N|
|108||void SetAttributeInt32(Int32 attribute, Int32 value)|N|N|N|N|N|N|N|N|N|N|
|109||void SetAttributeInt64(NativeVisaAttribute attribute, Int64 value)|N|N|N|N|N|N|N|N|N|N|
|110||void SetAttributeInt64(Int32 attribute, Int64 value)|N|N|N|N|N|N|N|N|N|N|
|111||void SetAttributeBoolean(NativeVisaAttribute attribute, Boolean value)|N|N|N|N|N|N|N|N|N|N|
|112||void SetAttributeBoolean(Int32 attribute, Boolean value)|N|N|N|N|N|N|N|N|N|N|
|113||void SetAttributeString(NativeVisaAttribute attribute, String value)|N|N|N|N|N|N|N|N|N|N|
|114||void SetAttributeString(Int32 attribute, String value)|N|N|N|N|N|N|N|N|N|N|
