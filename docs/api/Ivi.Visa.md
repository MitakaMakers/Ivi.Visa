English | [日本語](Ivi.Visa.ja.md)

# Ivi.Visa namescape

## In this article

- [Classes](#classes)
- [Interfaces](#interfaces)
- [Events](#events)
- [Enums](#enums)
- [Exceptions](#Exceptions)

## Classes
|Name|Description|
|---|---|
|[GlobalResourceManager](Ivi.Visa\GlobalResourceManager.md)|The GlobalResourceManager class provides methods that instantiate a VISA.NET session|
|[ParseResult](Ivi.Visa\ParseResult.md)|The ParseResult class provides the parsing information returned by the Parse methods in the IResourceManager interface and the GlobalResourceManager class.|

## Interfaces
|Name|Description|
|---|---|
|[IGpibInterfaceSession](Ivi.Visa\IGpibInterfaceSession.md)|The INTFC session type for GPIB buses.|
|[IGpibSession](Ivi.Visa\IGpibSession.md)|The INSTR session type for GPIB devices.|
|[IMemoryMap](Ivi.Visa\IMemoryMap.md)|Provides memory mapping services for register-based devices.|
|[IMessageBasedFormattedIO](Ivi.Visa\IMessageBasedFormattedIO.md)|MessageBasedFormattedIO allows calling programs to use a variety of common data types.|
|[IMessageBasedRawIO](Ivi.Visa\IMessageBasedRawIO.md)|IMessageBasedRawIO allows calling programs to send string or byte array data to the instrument without any formatting or parsing.|
|[IMessageBasedSession](Ivi.Visa\IMessageBasedSession.md)|The interface from which every VISA.NET message-based session must derive.|
|[INativeVisaEventArgs](Ivi.Visa\INativeVisaEventArgs.md)|The VisaEventArgs class communicates the event being fired.|
|[INativeVisaSession](Ivi.Visa\INativeVisaSession.md)|This section summarizes INativeVisaSession, which allows access to vendor specific C attributes and events.|
|[IPxiBackplaneSession](Ivi.Visa\IPxiBackplaneSession.md)|The BACKPLANE session type for PXI backplanes.|
|[IPxiMemorySession](Ivi.Visa\IPxiMemorySession.md)|The MEMACC session type for PXI devices.|
|[IPxiSession](Ivi.Visa\IPxiSession.md)|The INSTR session type for PXI devices.|
|[IRegisterBasedSession](Ivi.Visa\IRegisterBasedSession.md)|The base session type for register-based devices.|
|[IResourceManager](Ivi.Visa\IResourceManager.md)|The IResourceManager interface provides methods that instantiate a VISA.NET session for the specified resource.|
|[ISerialSession](Ivi.Visa\ISerialSession.md)|The INSTR session type for serial (RS-232) devices.|
|[ITcpipSession](Ivi.Visa\ITcpipSession.md)|The INSTR session type for LAN devices.|
|[ITcpipSession2](Ivi.Visa\ITcpipSession2.md)|The INSTR session type for LAN devices.|
|[ITcpipSocketSession](Ivi.Visa\ITcpipSocketSession.md)|The SOCKET session type for TCPIP devices.|
|[ITcpipSocketSession2](Ivi.Visa\ITcpipSocketSession2.md)|The SOCKET session type for TCPIP devices.  This derives from and supercedes ITcpipSocketSession.|
|[ITypeFormatter](Ivi.Visa\ITypeFormatter.md)|The ITypeFormatter interface provides methods that perform custom conversions of supported .NET types to and from a string.|
|[IUsbSession](Ivi.Visa\IUsbSession.md)|The INSTR session type for USBTMC devices.|
|[IVisaAsyncResult](Ivi.Visa\IVisaAsyncResult.md)|A reference to the result of an asynchronous I/O operation.|
|[IVisaSession](Ivi.Visa\IVisaSession.md)|The interface from which every VISA.NET session must derive.|
|[IVxiBackplaneSession](Ivi.Visa\IVxiBackplaneSession.md)|The BACKPLANE session type for VXI backplanes.|
|[IVxiMemorySession](Ivi.Visa\IVxiMemorySession.md)|The MEMACC session type for VXI devices.|
|[IVxiSession](Ivi.Visa\IVxiSession.md)|The INSTR session type for VXI devices.|

## Events
|Name|Description|
|---|---|
|[GpibControllerInChargeEventArgs](Ivi.Visa\GpibControllerInChargeEventArgs.md)|Provides additional data about a GPIB controller in charge (CIC) event.|
|[PxiInterruptEventArgs](Ivi.Visa\PxiInterruptEventArgs.md)|Provides additional data about a VXI interrupt event.|
|[UsbInterruptEventArgs](Ivi.Visa\UsbInterruptEventArgs.md)|Provides additional data about a USB interrupt event.|
|[VisaEventArgs](Ivi.Visa\VisaEventArgs.md)|The VisaEventArgs class communicates information about the event being fired.|
|[VxiSignalProcessorEventArgs](Ivi.Visa\VxiSignalProcessorEventArgs.md)|Provides additional data about a VXIbus signal or VXIbus interrupt event.|
|[VxiTriggerEventArgs](Ivi.Visa\VxiTriggerEventArgs.md)|Provides additional data about a VXI trigger event.|
|[VxiInterruptEventArgs](Ivi.Visa\VxiInterruptEventArgs.md)|Provides additional data about a VXI interrupt event.|

## Enums
|Name|Description|
|---|---|
|[AccessMode](Ivi.Visa\AccessMode.md)|An enumeration of the different mechanisms that control access to a resource.|
|[AddressSpace](Ivi.Visa\AddressSpace.md)|The AddressSpace enumeration indicates the bus address space used by VXI or PXI devices.|
|[AtnMode](Ivi.Visa\AtnMode.md)|The AtnMode enumeration indicates how to modify the state of the GPIB ATN (ATtentioN) interface line.|
|[BinaryEncoding](Ivi.Visa\BinaryEncoding.md)|The BinaryEncoding enumeration indicates, for formatted I/O operations.|
|[ByteOrder](Ivi.Visa\ByteOrder.md)|The ByteOrder enumeration indicates the byte order used in various VXI operations.|
|[DataWidth](Ivi.Visa\DataWidth.md)|The DataWidth enumeration indicates the data width for register-based data transfer operations.|
|[EventQueueStatus](Ivi.Visa\EventQueueStatus.md)|The EventQueueStatus enumeration indicates the current state of the event queue.|
|[EventType](Ivi.Visa\EventType.md)|A reference to the result of an asynchronous I/O operation.|
|[GpibAddressedState](Ivi.Visa\GpibAddressedState.md)|The GpibAddressedState enumeration indicates whether the GPIB interface is currently addressed to talk or listen, or is not addressed.|
|[GpibInstrumentRemoteLocalMode](Ivi.Visa\GpibInstrumentRemoteLocalMode.md)|The GpibInstrumentRemoteLocalMode enumeration indicates the action to be taken by the SendRemoteLocalCommand of a GPIB INSTR session.|
|[GpibInterfaceRemoteLocalMode](Ivi.Visa\GpibInterfaceRemoteLocalMode.md)|The GpibInterfaceRemoteLocalMode enumeration indicates the action to be taken by the SendRemoteLocalCommand of a GPIB INTFC session.|
|[HardwareInterfaceType](Ivi.Visa\HardwareInterfaceType.md)|The HardwareInterfaceType enumeration indicates the hardware interface type of the current session.|
|[IOBuffers](Ivi.Visa\IOBuffers.md)|The IOBuffers enumeration indicates buffer(s) in the low-level I/O interface.|
|[IOProtocol](Ivi.Visa\IOProtocol.md)|The IOProtocol enumeration indicates which protocol to use on a particular session.|
|[LineState](Ivi.Visa\LineState.md)|The LineState enumeration indicates whether the line is asserted or not, or if the state is unknown.|
|[NativeVisaAttribute](Ivi.Visa\NativeVisaAttribute.md)|The NativeVisaAttribute enumeration corresponds to the defined values for the VISA attributes.|
|[PxiMemoryType](Ivi.Visa\PxiMemoryType.md)|The PxiMemoryType enumeration indicates the memory type (memory mapped or I/O mapped) used by the device in the specified base address register (BAR).|
|[ReadStatus](Ivi.Visa\ReadStatus.md)|The ReadStatus enumeration indicates the success status of a raw I/O read operation.|
|[RemoteLocalMode](Ivi.Visa\RemoteLocalMode.md)|The RemoteLocalMode enumeration indicates the action to be taken by the SendRemoteLocalCommand of a GPIB, TCPIP, or USB INSTR session.|
|[ResourceLockState](Ivi.Visa\ResourceLockState.md)|The RemoteLocalMode enumeration indicates the state of the VISA lock on the resource associated with this session.|
|[ResourceOpenStatus](Ivi.Visa\ResourceOpenStatus.md)|The ResourceOpenStatus enumeration indicates the success status of an open operation.|
|[SerialFlowControlModes](Ivi.Visa\SerialFlowControlModes.md)|The SerialFlowControlModes enumeration indicates the type of flow control used by the Serial connection.|
|[SerialParity](Ivi.Visa\SerialParity.md)|The SerialParity enumeration indicates whether parity checking is being used by the serial connection.|
|[SerialStopBitsMode](Ivi.Visa\SerialStopBitsMode.md)|The SerialStopBitsMode enumeration indicates the number of stop bits used to indicate the end of a Serial frame.|
|[SerialTerminationMethod](Ivi.Visa\SerialTerminationMethod.md)|The SerialTermination enumeration indicates the method used to terminate Serial read and write operations.|
|[StatusByteFlags](Ivi.Visa\StatusByteFlags.md)|The StatusByteFlags enumeration indicates individual bits of the IEEE 488.2 Status Byte.|
|[TriggerLine](Ivi.Visa\TriggerLine.md)|The TriggerLine enumeration indicates a VXI or PXI trigger line.|
|[TriggerLines](Ivi.Visa\TriggerLines.md)|The TriggerLines enumeration indicates one or more VXI trigger lines.|
|[VxiAccessPrivilege](Ivi.Visa\VxiAccessPrivilege.md)|The VxiAccessPriviledge enumeration indicates the address modifier to be used in high-level access operations when writing to the destination.|
|[VxiCommandMode](Ivi.Visa\VxiCommandMode.md)|The VxiCommandMode enumeration indicates whether to VISA should issue a command and/or retrieve a response.|
|[VxiDeviceClass](Ivi.Visa\VxiDeviceClass.md)|The VxiDeviceClass enumeration indicates the VXI-defined device class to which a particular resource belongs.|
|[VxiTriggerProtocol](Ivi.Visa\VxiTriggerProtocol.md)|The VxiTriggerProtocol enumeration indicates the trigger protocol to be used when a VXI trigger is asserted.|
|[VxiUtilitySignal](Ivi.Visa\VxiUtilitySignal.md)|The VxiUtilitySignal enumeration indicates the utility bus signal to assert.|

## Exceptions
|Name|Description|
|---|---|
|[IOTimeoutException](Ivi.Visa\IOTimeoutException.md)|A VISA.NET I/O timeout has occured.|
|[NativeErrorCode](Ivi.Visa\NativeErrorCode.md)|A class that contains the standard error status codes.|
|[NativeVisaException](Ivi.Visa\NativeVisaException.md)|An error related to the underlying VISA native C implementation has occurred.|
|[TypeFormatterException](Ivi.Visa\TypeFormatterException.md)|A Type Formatter error has occurred.|
|[VisaException](Ivi.Visa\VisaException.md)|A VISA.NET error has occurred.|
