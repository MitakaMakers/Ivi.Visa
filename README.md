# Ivi.Visa and TmctlAPINet
This is an Open source C# libraries compatible with VISA.NET and Yokogawa's TMCTL. This software is developed for research and classroom training. Currentlly, supports only VXI-11, HiSLIP, RawSocket. 

## Feature of Mmm.Ivi.Visa
- [X] VXI-11 server and client.
- [X] HiSLIP server and client.
- [x] RawSokcet server and client.
- [ ] Usbtmc host
- [ ] Serial
- [ ] GP-IB
- [x] Program run on a basic Windows and Linux.
- [ ] Mmm.Ivi.Visa supports functions of VISA.Net.
- [ ] Mmm.TmctlAPINet supports functions of TMCTL.
- [ ] Server supports SCPI commands.
- [x] support windos C ABI library such as visa32.dll.
- [ ] PXI, PXI-GPIB
- [ ] VXI

## Feature of Mmm.TmctlAPINet
- [X] VXI-11 server and client.
- [X] HiSLIP server and client.
- [x] RawSokcet server and client.
- [x] Program run on a basic Windows and Linux.
- [x] support windows C ABI library (tmctl.dll).

## Derivarables
- .Net library : Ivi.Visa.dll, TmctlAPINet.dll
- VXI-11 server test program : Server.exe
- VXI-11 client test program : Client.exe
- Windows C library : visa32.dll, tmctl.dll, tmctl64.dll
- API Caputure：IOTrace.exe

## Runtime enviroment
- Windows and Linux(WSL2)
- [.NET 6](https://dotnet.microsoft.com/ja-jp/download/dotnet/6.0).
- GPIB Prologic GPIB
- LIBUSBNet

## Build enviroment
- Server.exe, Client.exe, Ivi.Visa.dll, TmctlAPINet.dll
  - .[NET 6 SDK 6.0.408](https://dotnet.microsoft.com/ja-jp/download/dotnet/6.0).
    - C# 10.0
- visa32.dll
  - [.NET Core 3.0 SDK (v3.0.103)](https://dotnet.microsoft.com/ja-jp/download/dotnet/3.0)
    - C# 8.0
  - [DllExport](https://github.com/3F/DllExport)
- tmctl.dll, tmctl64.dll
  - .NET Framework 2.0
    - C# 2.0
  - [DllExport](https://github.com/3F/DllExport)
- [Visual Studio 2022 Community](https://visualstudio.microsoft.com/ja/vs/community/)

## Usage
- Execute the Server.exe.
  - Start VXI-11 server.
- Execute the Client.exe.
  - Input destination IP address.
  - Input a command stirng.
- On the Server.exe.
  - Received messsage will be displayed.
  - Input a response string.
- On the Client.exe.
  - Received messsage will be displayed.
- You can use Wireshark to see real VXI-11 communication.

# Reference
- [TCP/IP Instrument Protocol Specification VXI-11 Revision 1.0](https://www.vxibus.org/files/VXI_Specs/VXI-11.zip)
- [VPP-4.3.6:VISA Implementation Specification for .NET](https://www.ivifoundation.org/docs/vpp436_2016-06-07.pdf)
- [TMCTL](https://tmi.yokogawa.com/library/documents-downloads/software/tmctl/)

# Author
Twitter:[@mitakalab](https://twitter.com/mitakalab)

# License
GPL-2
