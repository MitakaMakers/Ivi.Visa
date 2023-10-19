# TmVXI11 Class

## Definition
Namespace:[TmctlAPINet](../TmctlAPINet.md)<BR>
Assembly:TmctlAPINet.dll

## Properties

|Property Name|
|---|
|[client](#client-Property)|
|[lid](#lid-Property)|
|[corePort](#corePort-Property)|
|[abortPort](#abortPort-Property)|
|[maxRecvSize](#maxRecvSize-Property)|
|[lock_timeout](#lock_timeout-Property)|
|[io_timeout](#io_timeout-Property)|

## Methods

|Method Name|
|---|
|[Initialize(int wire, string adr, out int id)](#Initializeint-wire-string-adr-out-int-id-Method)|
|[Finish(int id)](#Finishint-id-Method)|
|[SetTimeout(int id, int tmo)](#SetTimeoutint-id-int-tmo-Method)|
|[SetTerm(int id, int eos, int eot)](#SetTermint-id-int-eos-int-eot-Method)|
|[Send(int id, string msg)](#Sendint-id-string-msg-Method)|
|[Receive(int id, ref StringBuilder buff, int blen, ref int rlen)](#Receiveint-id-ref-StringBuilder-buff-int-blen-ref-int-rlen-Method)|
|[ReceiveSetup(int id)](#ReceiveSetupint-id-Method)|
|[ReceiveBlockHeader(int id, ref int length)](#ReceiveBlockHeaderint-id-ref-int-length-Method)|
|[ReceiveBlockData(int id, ref sbyte buff, int blen, ref int rlen, ref int end)](#ReceiveBlockDataint-id-ref-sbyte-buff-int-blen-ref-int-rlen-ref-int-end-Method)|
|[SetRen(int id, int flag)](#SetRenint-id-int-flag-Method)|
|[DeviceClear(int id)](#DeviceClearint-id-Method)|
|[DeviceTrigger(int id)](#DeviceTriggerint-id-Method)|


## client Property
```C#
private ClientVxi11 client = new ClientVxi11();
```
## lid Property
```C#
private int lid;
```
## corePort Property
```C#
private int corePort;
```
## abortPort Property
```C#
private int abortPort;
```
## maxRecvSize Property
```C#
private int maxRecvSize;
```
## lock_timeout Property
```C#
private int lock_timeout = 123;
```
## io_timeout Property
```C#
private int io_timeout = 456;
```
## Initialize(int wire, string adr, out int id) Method
```C#
public int Initialize(int wire, string adr, out int id)
```
## Finish(int id) Method
```C#
public int Finish(int id)
```
## SetTimeout(int id, int tmo) Method
```C#
public int SetTimeout(int id, int tmo)
```
## SetTerm(int id, int eos, int eot) Method
```C#
public int SetTerm(int id, int eos, int eot)
```
## Send(int id, string msg) Method
```C#
public int Send(int id, string msg)
```
## Receive(int id, ref StringBuilder buff, int blen, ref int rlen) Method
```C#
public int Receive(int id, ref StringBuilder buff, int blen, ref int rlen)
```
## ReceiveSetup(int id) Method
```C#
public int ReceiveSetup(int id)
```
## ReceiveBlockHeader(int id, ref int length) Method
```C#
public int ReceiveBlockHeader(int id, ref int length)
```
## ReceiveBlockData(int id, ref sbyte buff, int blen, ref int rlen, ref int end) Method
```C#
public int ReceiveBlockData(int id, ref sbyte buff, int blen, ref int rlen, ref int end)
```
## SetRen(int id, int flag) Method
```C#
public int SetRen(int id, int flag)
```
## DeviceClear(int id) Method
```C#
public int DeviceClear(int id)
```
## DeviceTrigger(int id) Method
```C#
public int DeviceTrigger(int id)
```