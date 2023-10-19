English | 日本語

# ISerialSession Interface

## Definition
Namespace:[Ivi.Visa](../Visa.md)<BR>
Assembly:Ivi.Visa.dll<BR>
Inheritance:[System.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) -> [Ivi.Visa.IVisaSession](IVisaSession.md) -> [Ivi.Visa.IMessageBasedSession](IMessageBasedSession.md) -> **Ivi.Visa.ISerialSession**

## Properties

|Property Name|
|---|
|[BytesAvailable](#BytesAvailable-Property)|
|[BaudRate](#BaudRate-Property)|
|[ClearToSendState](#ClearToSendState-Property)|
|[DataBits](#DataBits-Property)|
|[DataCarrierDetectState](#DataCarrierDetectState-Property)|
|[DataSetReadyState](#DataSetReadyState-Property)|
|[DataTerminalReadyState](#DataTerminalReadyState-Property)|
|[FlowControl](#FlowControl-Property)|
|[Parity](#Parity-Property)|
|[ReadTermination](#ReadTermination-Property)|
|[ReplacementCharacter](#ReplacementCharacter-Property)|
|[RequestToSendState](#RequestToSendState-Property)|
|[RingIndicatorState](#RingIndicatorState-Property)|
|[StopBits](#StopBits-Property)|
|[WriteTermination](#WriteTermination-Property)|
|[XOffCharacter](#XOffCharacter-Property)|
|[XOnCharacter](#XOnCharacter-Property)|

## Methods

|Method Name|
|---|
|[Flush(IOBuffers buffers, Boolean discard)](#FlushIOBuffers-buffers-Boolean-discard-Method)|
|[SetBufferSize(IOBuffers buffers, Int32 size)](#SetBufferSizeIOBuffers-buffers-Int32-size-Method)|

## BytesAvailable Property
```C#
Int32 BytesAvailable { get; }
```
## BaudRate Property
```C#
Int32 BaudRate { get; set; }
```
## ClearToSendState Property
```C#
LineState ClearToSendState { get; }
```
## DataBits Property
```C#
Int16 DataBits { get; set; }
```
## DataCarrierDetectState Property
```C#
LineState DataCarrierDetectState { get; }
```
## DataSetReadyState Property
```C#
LineState DataSetReadyState { get; }
```
## DataTerminalReadyState Property
```C#
LineState DataTerminalReadyState { get; set; }
```
## FlowControl Property
```C#
SerialFlowControlModes FlowControl { get; set; }
```
## Parity Property
```C#
SerialParity Parity { get; set; }
```
## ReadTermination Property
```C#
SerialTerminationMethod ReadTermination { get; set; }
```
## ReplacementCharacter Property
```C#
Byte ReplacementCharacter { get; set; }
```
## RequestToSendState Property
```C#
LineState RequestToSendState { get; set; }
```
## RingIndicatorState Property
```C#
LineState RingIndicatorState { get; }
```
## StopBits Property
```C#
SerialStopBitsMode StopBits { get; set; }
```
## WriteTermination Property
```C#
SerialTerminationMethod WriteTermination { get; set; }
```
## XOffCharacter Property
```C#
Byte XOffCharacter { get; set; }
```
## XOnCharacter Property
```C#
Byte XOnCharacter { get; set; }
```
## Flush(IOBuffers buffers, Boolean discard) Method
```C#
void Flush(IOBuffers buffers, Boolean discard);
```
## SetBufferSize(IOBuffers buffers, Int32 size) Method
```C#
Boolean SetBufferSize(IOBuffers buffers, Int32 size);
```
