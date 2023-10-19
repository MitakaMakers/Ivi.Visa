# ClientPortmapUdp Class

## Definition
Namespace:[Vxi11Net](../Vxi11Net.md)<BR>
Assembly:TmctlAPINet.dll

## Properties

|Property Name|
|---|
|[clientRpcUdp](#clientRpcUdp-Property)|
|[xid](#xid-Property)|

## Methods

|Method Name|
|---|
|[Create(string host, int port)](#Createstring-host-int-port-Method)|
|[Destroy()](#Destroy-Method)|
|[GetPort(int program, int version, Portmap.IPPROTO protocol)](#GetPortint-program-int-version-PortmapIPPROTO-protocol-Method)|
|[Set(int program, int version, int protocol, int port)](#Setint-program-int-version-int-protocol-int-port-Method)|
|[Unset(int program, int version, int protocol)](#Unsetint-program-int-version-int-protocol-Method)|

## clientRpcTcp Property
```C#
private ClientRpcUdp clientRpcUdp = new ClientRpcUdp();
```
## xid Property
```C#
private int xid = 1;
```
## Create(string host, int port) Method
```C#
public void Create(string host, int port)
```
## Destroy() Method
```C#
public void Destroy()
```
## GetPort(int program, int version, Portmap.IPPROTO protocol) Method
```C#
public int GetPort(int program, int version, Portmap.IPPROTO protocol)
```
## Set(int program, int version, int protocol, int port) Method
```C#
public int Set(int program, int version, int protocol, int port)
```
## Unset(int program, int version, int protocol) Method
```C#
public int Unset(int program, int version, int protocol)
```
