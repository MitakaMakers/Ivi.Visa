# ServerPortmap Class

## Definition
Namespace:[Vxi11Net](../Vxi11Net.md)<BR>
Assembly:TmctlAPINet.dll

## Properties

|Property Name|
|---|
|[pmaplist](#pmaplist-Property)|

## Methods

|Method Name|
|---|
|[AddPort(int prog, int vers, Portmap.IPPROTO prot, int port)](#AddPortint-prog-int-vers-PortmapIPPROTO-prot-int-port-Method)|
|[RemovePort(int prog, int vers, Portmap.IPPROTO prot)](#RemovePortint-prog-int-vers-PortmapIPPROTO-prot-Method)|
|[FindPort(int prog, int vers, Portmap.IPPROTO prot)](#FindPortint-prog-int-vers-PortmapIPPROTO-prot-Method)|

## pmaplist Property
```C#
private static List<Portmap.MAPPING> pmaplist = new List<Portmap.MAPPING>();
```
## AddPort(int prog, int vers, Portmap.IPPROTO prot, int port) Method
```C#
public static bool AddPort(int prog, int vers, Portmap.IPPROTO prot, int port)
```
## RemovePort(int prog, int vers, Portmap.IPPROTO prot) Method
```C#
public static bool RemovePort(int prog, int vers, Portmap.IPPROTO prot)
```
## FindPort(int prog, int vers, Portmap.IPPROTO prot) Method
```C#
public static int FindPort(int prog, int vers, Portmap.IPPROTO prot)
```
