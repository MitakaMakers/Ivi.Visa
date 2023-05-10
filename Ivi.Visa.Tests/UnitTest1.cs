using Vxi11Net;
using Xunit;

namespace Ivi.Visa
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Vxi11Net.Server.run_demo_server("127.0.0.1", 5024);

            int port = 5024;
            Console.WriteLine("== Run demo server ==");
            ServerPortmap tcp_server = new ServerPortmap();
            ServerPortmap udp_server = new ServerPortmap();
            ServerVxi11 coreServer = new ServerVxi11();
            ServerVxi11 abortServer = new ServerVxi11();
            tcp_server.Run("127.0.0.1", port, Pmap.IPPROTO.TCP);
            udp_server.Run("127.0.0.1", port, Pmap.IPPROTO.UDP);
            coreServer.RunCoreChannel("127.0.0.1", port);
            abortServer.RunAbortChannel("127.0.0.1", port + 1);

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