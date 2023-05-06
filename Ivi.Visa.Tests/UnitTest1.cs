using Xunit;
using Ivi.Visa;
using VXI11Net;
using System.Net.Sockets;
using System.Net;

namespace Ivi.Visa
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //VXI11Net.Server.run_demo_server("127.0.0.1", 5024);

            int port = 5024;
            Console.WriteLine("== Run demo server ==");
            TcpPortmapServer tcp_server = new TcpPortmapServer();
            UdpPortmapServer udp_server = new UdpPortmapServer();
            CoreServer coreServer = new CoreServer();
            AbortServer abortServer = new AbortServer();
            tcp_server.Run("127.0.0.1", port);
            udp_server.Run("127.0.0.1", port);
            coreServer.Run("127.0.0.1", port);
            abortServer.Run("127.0.0.1", port + 1);

            string rsrc = new String(Console.ReadLine());
            // IMessageBasedSession session1 = (IMessageBasedSession)GlobalResourceManager.Open("TCPIP0::1.2.3.4::5025::SOCKET");
            // IMessageBasedSession session2 = (IMessageBasedSession)GlobalResourceManager.Open("TCPIP::1.2.3.4::inst0::INSTR");
            // IMessageBasedSession session3 = (IMessageBasedSession)GlobalResourceManager.Open("TCPIP::[fe80::1]::hislip0::INSTR");
            // IMessageBasedSession session4 = (IMessageBasedSession)GlobalResourceManager.Open("USB::0x1234::0x5678::A22 - 5::INSTR");

            //IMessageBasedSession session = (IMessageBasedSession)GlobalResourceManager.Open("TCPIP:127.0.0.1");
            //session.FormattedIO.WriteLine("IDN?");
            //string msg = session.FormattedIO.ReadLine();

            tcp_server.Shutdown();
            udp_server.Shutdown();
            abortServer.Shutdown();
            coreServer.Shutdown();
        }
    }
}