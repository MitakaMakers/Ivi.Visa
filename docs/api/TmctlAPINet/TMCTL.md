# TMCTL Class

## Definition
Namespace:[TmctlAPINet](../TmctlAPINet.md)<BR>
Assembly:TmctlAPINet.dll

## Properties

|Property Name|Value|
|---|---|
|public const int TM_CTL_GPIB|1|
|public const int TM_CTL_RS232|2|
|public const int TM_CTL_USB|3|
|public const int TM_CTL_ETHER|4|
|public const int TM_CTL_USBTMC|5|
|public const int TM_CTL_ETHERUDP|6|
|public const int TM_CTL_USBTMC2|7|
|public const int TM_CTL_VXI11|8|
|public const int TM_CTL_VISAUSB|10|
|public const int TM_CTL_SOCKET|11|
|public const int TM_CTL_USBTMC3|12|
|public const int TM_CTL_HISLIP|14|
|private TmVxi11 client|-|

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