# Mm.Ivi.Visa
## About
- Mm.Ivi.Visa is open source C# library to communicate test and measurement instruments.
- Mm.Ivi.Visa supports several communication protocols: VXI-11, HiSLIP and RawSokcet.
- Mm.Ivi.Visa runs on .Net 6
- Mm.Ivi.Visa supports Ivi.Visa API

## Package files
- Ivi.Visa.dll (Any CPU)

## API
### Functions

|Class|Functions|TCPIP::VXI-11|TCPIP::HiSLIP|TCPIP::SOCKET|
|----|----|----|----|----|
|GlobalResourceManager|public static IVisaSession Open(String resourceName) {…}|Y|Y|Y|
|IVisaSession|Int32 TimeoutMilliseconds { get set }|Y|Y|Y|
||String ResourceName { get }|Y|Y|Y|
||String ResourceClass { get }|Y|Y|Y|
||String ResourceManufacturerName { get }|Y|Y|Y|
||Int16 ResourceManufacturerId { get }|Y|Y|Y|
||ResourceLockState ResourceLockState { get }|Y|Y|Y|
||void LockResource()|Y|Y|Y|
||void UnlockResource()|Y|Y|Y|
||void EnableEvent(EventType eventType)|Y|Y|N|
||void DisableEvent(EventType eventType)|Y|Y|N|
||VisaEventArgs WaitOnEvent(EventType eventType)|Y|Y|N|
|IMessageBasedSession|Boolean SendEndEnabled { get set }|Y|Y|Y|
||Byte TerminationCharacter { get set }|Y|Y|Y|
||Boolean TerminationCharacterEnabled { get set }|Y|Y|Y|
||void AssertTrigger()|Y|Y|N|
||void Clear()|Y|Y|N|
||StatusByteFlags ReadStatusByte()|Y|Y|N|
||Byte[] Read()|Y|Y|Y|
||void Write(String buffer)|Y|Y|Y|
