# VXI-11.Net
VXI-11.Net is a VXI-11 communication software for classroom training.

## Feature goal
- supports VXI-11 server and client by C#.
- Supports HISLIP server and client.
- Supports RawSokcet server and client.
- Program run on a simple Windows and Linux.
- Client supports some functions of VISA and TMCTL libraries.
- Server supports some SCPI commands.
- support C ABI library : visa32.dll, tmctl.dll

## Derivarables
- VXI-11 server program : Server.exe
- VXI-11 client program : Client.exe
- .Net library : Ivi.Visa.dll, TmctlAPINet.dll
- C ABI library : visa32.dll, tmctl.dll, tmctl64.dll

## Runtime enviroment
- Windows or Linux.
- [.NET 6](https://dotnet.microsoft.com/ja-jp/download/dotnet/6.0).

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
