English | [日本語](Visa.ja.md)

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
|[GlobalResourceManager](Visa/GlobalResourceManager.md)|The GlobalResourceManager class provides methods that instantiate a VISA.NET session|
|[ParseResult](Visa/ParseResult.md)|The ParseResult class provides the parsing information returned by the Parse methods in the IResourceManager interface and the GlobalResourceManager class.|

## Interfaces
|Name|Description|
|---|---|
|[IGpibInterfaceSession](Visa/IGpibInterfaceSession.md)|The INTFC session type for GPIB buses.|
|[IGpibSession](Visa/IGpibSession.md)|The INSTR session type for GPIB devices.|
|[IMemoryMap](Visa/IMemoryMap.md)|Provides memory mapping services for register-based devices.|
|[IMessageBasedFormattedIO](Visa/IMessageBasedFormattedIO.md)|MessageBasedFormattedIO allows calling programs to use a variety of common data types.|
|[IMessageBasedRawIO](Visa/IMessageBasedRawIO.md)|IMessageBasedRawIO allows calling programs to send string or byte array data to the instrument without any formatting or parsing.|
|[IMessageBasedSession](Visa/IMessageBasedSession.md)|The interface from which every VISA.NET message-based session must derive.|
|[INativeVisaEventArgs](Visa/INativeVisaEventArgs.md)|The VisaEventArgs class communicates the event being fired.|
|[INativeVisaSession](Visa/INativeVisaSession.md)|This section summarizes INativeVisaSession, which allows access to vendor specific C attributes and events.|
|[IPxiBackplaneSession](Visa/IPxiBackplaneSession.md)|The BACKPLANE session type for PXI backplanes.|
|[IPxiMemorySession](Visa/IPxiMemorySession.md)|The MEMACC session type for PXI devices.|
|[IPxiSession](Visa/IPxiSession.md)|The INSTR session type for PXI devices.|
|[IRegisterBasedSession](Visa/IRegisterBasedSession.md)|The base session type for register-based devices.|
|[IResourceManager](Visa/IResourceManager.md)|The IResourceManager interface provides methods that instantiate a VISA.NET session for the specified resource.|
|[ISerialSession](Visa/ISerialSession.md)|The INSTR session type for serial (RS-232) devices.|
|[ITcpipSession](Visa/ITcpipSession.md)|The INSTR session type for LAN devices.|
|[ITcpipSession2](Visa/ITcpipSession2.md)|The INSTR session type for LAN devices.|
|[ITcpipSocketSession](Visa/ITcpipSocketSession.md)|The SOCKET session type for TCPIP devices.|
|[ITcpipSocketSession2](Visa/ITcpipSocketSession2.md)|The SOCKET session type for TCPIP devices.  This derives from and supercedes ITcpipSocketSession.|
|[ITypeFormatter](Visa/ITypeFormatter.md)|The ITypeFormatter interface provides methods that perform custom conversions of supported .NET types to and from a string.|
|[IUsbSession](Visa/IUsbSession.md)|The INSTR session type for USBTMC devices.|
|[IVisaAsyncResult](Visa/IVisaAsyncResult.md)|A reference to the result of an asynchronous I/O operation.|
|[IVisaSession](Visa/IVisaSession.md)|The interface from which every VISA.NET session must derive.|
|[IVxiBackplaneSession](Visa/IVxiBackplaneSession.md)|The BACKPLANE session type for VXI backplanes.|
|[IVxiMemorySession](Visa/IVxiMemorySession.md)|The MEMACC session type for VXI devices.|
|[IVxiSession](Visa/IVxiSession.md)|The INSTR session type for VXI devices.|

## Events
|Name|Description|
|---|---|
|[GpibControllerInChargeEventArgs](Visa/GpibControllerInChargeEventArgs.md)|Provides additional data about a GPIB controller in charge (CIC) event.|
|[PxiInterruptEventArgs](Visa/PxiInterruptEventArgs.md)|Provides additional data about a VXI interrupt event.|
|[UsbInterruptEventArgs](Visa/UsbInterruptEventArgs.md)|Provides additional data about a USB interrupt event.|
|[VisaEventArgs](Visa/VisaEventArgs.md)|The VisaEventArgs class communicates information about the event being fired.|
|[VxiSignalProcessorEventArgs](Visa/VxiSignalProcessorEventArgs.md)|Provides additional data about a VXIbus signal or VXIbus interrupt event.|
|[VxiTriggerEventArgs](Visa/VxiTriggerEventArgs.md)|Provides additional data about a VXI trigger event.|
|[VxiInterruptEventArgs](Visa/VxiInterruptEventArgs.md)|Provides additional data about a VXI interrupt event.|

## Enums
|Name|Description|
|---|---|
|[AccessMode](Visa/AccessMode.md)|An enumeration of the different mechanisms that control access to a resource.|
|[AddressSpace](Visa/AddressSpace.md)|The AddressSpace enumeration indicates the bus address space used by VXI or PXI devices.|
|[AtnMode](Visa/AtnMode.md)|The AtnMode enumeration indicates how to modify the state of the GPIB ATN (ATtentioN) interface line.|
|[BinaryEncoding](Visa/BinaryEncoding.md)|The BinaryEncoding enumeration indicates, for formatted I/O operations.|
|[ByteOrder](Visa/ByteOrder.md)|The ByteOrder enumeration indicates the byte order used in various VXI operations.|
|[DataWidth](Visa/DataWidth.md)|The DataWidth enumeration indicates the data width for register-based data transfer operations.|
|[EventQueueStatus](Visa/EventQueueStatus.md)|The EventQueueStatus enumeration indicates the current state of the event queue.|
|[EventType](Visa/EventType.md)|A reference to the result of an asynchronous I/O operation.|
|[GpibAddressedState](Visa/GpibAddressedState.md)|The GpibAddressedState enumeration indicates whether the GPIB interface is currently addressed to talk or listen, or is not addressed.|
|[GpibInstrumentRemoteLocalMode](Visa/GpibInstrumentRemoteLocalMode.md)|The GpibInstrumentRemoteLocalMode enumeration indicates the action to be taken by the SendRemoteLocalCommand of a GPIB INSTR session.|
|[GpibInterfaceRemoteLocalMode](Visa/GpibInterfaceRemoteLocalMode.md)|The GpibInterfaceRemoteLocalMode enumeration indicates the action to be taken by the SendRemoteLocalCommand of a GPIB INTFC session.|
|[HardwareInterfaceType](Visa/HardwareInterfaceType.md)|The HardwareInterfaceType enumeration indicates the hardware interface type of the current session.|
|[IOBuffers](Visa/IOBuffers.md)|The IOBuffers enumeration indicates buffer(s) in the low-level I/O interface.|
|[IOProtocol](Visa/IOProtocol.md)|The IOProtocol enumeration indicates which protocol to use on a particular session.|
|[LineState](Visa/LineState.md)|The LineState enumeration indicates whether the line is asserted or not, or if the state is unknown.|
|[NativeVisaAttribute](Visa/NativeVisaAttribute.md)|The NativeVisaAttribute enumeration corresponds to the defined values for the VISA attributes.|
|[PxiMemoryType](Visa/PxiMemoryType.md)|The PxiMemoryType enumeration indicates the memory type (memory mapped or I/O mapped) used by the device in the specified base address register (BAR).|
|[ReadStatus](Visa/ReadStatus.md)|The ReadStatus enumeration indicates the success status of a raw I/O read operation.|
|[RemoteLocalMode](Visa/RemoteLocalMode.md)|The RemoteLocalMode enumeration indicates the action to be taken by the SendRemoteLocalCommand of a GPIB, TCPIP, or USB INSTR session.|
|[ResourceLockState](Visa/ResourceLockState.md)|The RemoteLocalMode enumeration indicates the state of the VISA lock on the resource associated with this session.|
|[ResourceOpenStatus](Visa/ResourceOpenStatus.md)|The ResourceOpenStatus enumeration indicates the success status of an open operation.|
|[SerialFlowControlModes](Visa/SerialFlowControlModes.md)|The SerialFlowControlModes enumeration indicates the type of flow control used by the Serial connection.|
|[SerialParity](Visa/SerialParity.md)|The SerialParity enumeration indicates whether parity checking is being used by the serial connection.|
|[SerialStopBitsMode](Visa/SerialStopBitsMode.md)|The SerialStopBitsMode enumeration indicates the number of stop bits used to indicate the end of a Serial frame.|
|[SerialTerminationMethod](Visa/SerialTerminationMethod.md)|The SerialTermination enumeration indicates the method used to terminate Serial read and write operations.|
|[StatusByteFlags](Visa/StatusByteFlags.md)|The StatusByteFlags enumeration indicates individual bits of the IEEE 488.2 Status Byte.|
|[TriggerLine](Visa/TriggerLine.md)|The TriggerLine enumeration indicates a VXI or PXI trigger line.|
|[TriggerLines](Visa/TriggerLines.md)|The TriggerLines enumeration indicates one or more VXI trigger lines.|
|[VxiAccessPrivilege](Visa/VxiAccessPrivilege.md)|The VxiAccessPriviledge enumeration indicates the address modifier to be used in high-level access operations when writing to the destination.|
|[VxiCommandMode](Visa/VxiCommandMode.md)|The VxiCommandMode enumeration indicates whether to VISA should issue a command and/or retrieve a response.|
|[VxiDeviceClass](Visa/VxiDeviceClass.md)|The VxiDeviceClass enumeration indicates the VXI-defined device class to which a particular resource belongs.|
|[VxiTriggerProtocol](Visa/VxiTriggerProtocol.md)|The VxiTriggerProtocol enumeration indicates the trigger protocol to be used when a VXI trigger is asserted.|
|[VxiUtilitySignal](Visa/VxiUtilitySignal.md)|The VxiUtilitySignal enumeration indicates the utility bus signal to assert.|

## Exceptions
|Name|Description|
|---|---|
|[IOTimeoutException](Visa/IOTimeoutException.md)|A VISA.NET I/O timeout has occured.|
|[NativeErrorCode](Visa/NativeErrorCode.md)|A class that contains the standard error status codes.|
|[NativeVisaException](Visa/NativeVisaException.md)|An error related to the underlying VISA native C implementation has occurred.|
|[TypeFormatterException](Visa/TypeFormatterException.md)|A Type Formatter error has occurred.|
|[VisaException](Visa/VisaException.md)|A VISA.NET error has occurred.|
