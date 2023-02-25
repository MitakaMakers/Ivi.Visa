# VXI-11.Net
VXI-11.Net is a VXI-11 communication software for classroom training.

## Feature goal
- VXI-11 server and client by C#.
- Supports Windows and Linux.
- Supports all message types of VXI-11.
- Supports some functions of VISA and TMCTL libraries.
- Error handling is not implemented for easy understandings.
 
## Derivarables
- VXI-11 server ：server.exe
- VXI-11 client ：client.exe, visa32.dll, tmctl.dll

## Requirement
- Windows 10 or Linux.
- [.NET 6](https://dotnet.microsoft.com/ja-jp/download/dotnet/6.0).

## Usage
- Execute the server.exe.
  - Start VXI-11 server.
- Execute the client.exe.
  - Input destination IP address.
  - Input a command stirng.
- On the server.exe.
  - Received messsage will be displayed.
  - Input a response string.
- On the client.exe.
  - Received messsage will be displayed.
- You can check TCP stream by Wireshark.

# Reference
- [TCP/IP Instrument Protocol Specification VXI-11 Revision 1.0](https://www.vxibus.org/files/VXI_Specs/VXI-11.zip)
- [VPP-4.3.6:VISA Implementation Specification for .NET](https://www.ivifoundation.org/docs/vpp436_2016-06-07.pdf)
- [TMCTL](https://tmi.yokogawa.com/library/documents-downloads/software/tmctl/)

# Author
Twitter:@mitakalab

# License
GPL-2