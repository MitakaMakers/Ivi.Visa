English | [日本語](Ivi.Visa.ja.md)

# Ivi.Visa namescape

## In this article

- [Classes](#classes)
- [Interfaces](#interfaces)
- [Enums](#enums)

## Classes
|Name|Description|
|---|---|
|[GlobalResourceManager](Ivi.Visa.GlobalResourceManager.md)|The GlobalResourceManager class provides methods that instantiate a VISA.NET session|
|IOTimeoutException|A VISA.NET I/O timeout has occured.|
|NativeErrorCode|A class that contains the standard error status codes.|
|NativeVisaException|An error related to the underlying VISA native C implementation has occurred.|
|[ParseResult](Ivi.Visa.ParseResult.md)|The ParseResult class provides the parsing information returned by the Parse methods in the IResourceManager interface and the GlobalResourceManager class.|
|TypeFormatterException|A Type Formatter error has occurred.|
|[VisaEventArgs](Ivi.Visa.VisaEventArgs.md)|The VisaEventArgs class communicates information about the event being fired.|
|VisaException|A VISA.NET error has occurred.|

## Interfaces
|Name|Description|
|---|---|
|IGpibSession|The INSTR session type for GPIB devices.|
|IMessageBasedFormattedIO|MessageBasedFormattedIO allows calling programs to use a variety of common data types.|
|IMessageBasedRawIO|IMessageBasedRawIO allows calling programs to send string or byte array data to the instrument without any formatting or parsing.|
|[IMessageBasedSession](Ivi.Visa.IMessageBasedSession.md)|The interface from which every VISA.NET message-based session must derive.|
|IPxiSession|The INSTR session type for PXI devices.|
|IRegisterBasedSession|The base session type for register-based devices.|
|[IResourceManager](Ivi.Visa.IResourceManager.md)|The IResourceManager interface provides methods that instantiate a VISA.NET session for the specified resource.|
|ISerialSession|The INSTR session type for serial (RS-232) devices.|
|[ITcpipSession](Ivi.Visa.ITcpipSession.md)|The INSTR session type for LAN devices.|
|[ITcpipSocketSession](Ivi.Visa.ITcpipSocketSession.md)|The SOCKET session type for TCPIP devices.|
|IUsbSesssion|The INSTR session type for USBTMC devices.|
|[IVisaSession](Ivi.Visa.IVisaSession.md)|The interface from which every VISA.NET session must derive.|
|IVxiSession|The INSTR session type for VXI devices.|

## Enums
|Name|Description|
|---|---|
|[AccessMode](Ivi.visa.AccessMode.md)|An enumeration of the different mechanisms that control access to a resource.|
|[AddressSpace](Ivi.visa.AddressSpace.md)|The AddressSpace enumeration indicates the bus address space used by VXI or PXI devices.|
|ApiType|
|[AtnMode](Ivi.visa.AtnMode.md)|The AtnMode enumeration indicates how to modify the state of the GPIB ATN (ATtentioN) interface line.|
|[BinaryEncoding](Ivi.visa.BinaryEncoding.md)|The BinaryEncoding enumeration indicates, for formatted I/O operations.|
|[ByteOrder](Ivi.visa.ByteOrder.md)|The ByteOrder enumeration indicates the byte order used in various VXI operations.|
|[DataWidth](Ivi.visa.DataWidth.md)|The DataWidth enumeration indicates the data width for register-based data transfer operations.|
|[EventQueueStatus](Ivi.visa.EventQueueStatus.md)|The EventQueueStatus enumeration indicates the current state of the event queue.|
|[EventType](Ivi.visa.EventType.md)|A reference to the result of an asynchronous I/O operation.|
|FlushBehavior|
|[GpibAddressedState](Ivi.visa.GpibAddressedState.md)|The GpibAddressedState enumeration indicates whether the GPIB interface is currently addressed to talk or listen, or is not addressed.|
|[GpibInstrumentRemoteLocalMode](Ivi.visa.GpibInstrumentRemoteLocalMode.md)|The GpibInstrumentRemoteLocalMode enumeration indicates the action to be taken by the SendRemoteLocalCommand of a GPIB INSTR session.|
|[GpibInterfaceRemoteLocalMode](Ivi.visa.GpibInterfaceRemoteLocalMode.md)|The GpibInterfaceRemoteLocalMode enumeration indicates the action to be taken by the SendRemoteLocalCommand of a GPIB INTFC session.|
|HandlerType|
|[HardwareInterfaceType](Ivi.visa.HardwareInterfaceType.md)|The HardwareInterfaceType enumeration indicates the hardware interface type of the current session.|
|[IOBuffers](Ivi.visa.IOBuffers.md)|The IOBuffers enumeration indicates buffer(s) in the low-level I/O interface.|
|[IOProtocol](Ivi.visa.IOProtocol.md)|The IOProtocol enumeration indicates which protocol to use on a particular session.|
|[LineState](Ivi.visa.LineState.md)|The LineState enumeration indicates whether the line is asserted or not, or if the state is unknown.|
|[NativeVisaAttribute](Ivi.visa.NativeVisaAttribute.md)|The NativeVisaAttribute enumeration corresponds to the defined values for the VISA attributes.|
|[PxiMemoryType](Ivi.visa.PxiMemoryType.md)|The PxiMemoryType enumeration indicates the memory type (memory mapped or I/O mapped) used by the device in the specified base address register (BAR).|
|[ReadStatus](Ivi.visa.ReadStatus.md)|The ReadStatus enumeration indicates the success status of a raw I/O read operation.|
|[RemoteLocalMode](Ivi.visa.RemoteLocalMode.md)|The RemoteLocalMode enumeration indicates the action to be taken by the SendRemoteLocalCommand of a GPIB, TCPIP, or USB INSTR session.|
|[ResourceLockState](Ivi.visa.ResourceLockState.md)|The RemoteLocalMode enumeration indicates the state of the VISA lock on the resource associated with this session.|
|[ResourceOpenStatus](Ivi.visa.ResourceOpenStatus.md)|The ResourceOpenStatus enumeration indicates the success status of an open operation.|
|[SerialFlowControlModes](Ivi.visa.SerialFlowControlModes.md)|The SerialFlowControlModes enumeration indicates the type of flow control used by the Serial connection.|
|[SerialParity](Ivi.visa.SerialParity.md)|The SerialParity enumeration indicates whether parity checking is being used by the serial connection.|
|[SerialStopBitsMode](Ivi.visa.SerialStopBitsMode.md)|The SerialStopBitsMode enumeration indicates the number of stop bits used to indicate the end of a Serial frame.|
|[SerialTerminationMethod](Ivi.visa.SerialTerminationMethod.md)|The SerialTermination enumeration indicates the method used to terminate Serial read and write operations.|
|StatusByteFlags|The StatusByteFlags enumeration indicates individual bits of the IEEE 488.2 Status Byte.|
|TriggerLine|The TriggerLine enumeration indicates a VXI or PXI trigger line.|
|TriggerLines|The TriggerLines enumeration indicates one or more VXI trigger lines.|
|VxiAccessPrivilege|The VxiAccessPriviledge enumeration indicates the address modifier to be used in high-level access operations when writing to the destination.|
|VxiCommandMode|The VxiCommandMode enumeration indicates whether to VISA should issue a command and/or retrieve a response.|
|VxiDeviceClass|The VxiDeviceClass enumeration indicates the VXI-defined device class to which a particular resource belongs.|
|VxiTriggerProtocol|The VxiTriggerProtocol enumeration indicates the trigger protocol to be used when a VXI trigger is asserted.|
|VxiUtilitySignal|The VxiUtilitySignal enumeration indicates the utility bus signal to assert.|
