using Vxi11Net;
using Xunit;

namespace Ivi.Visa
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int port = 1111;
            Console.WriteLine("== Run demo server ==");
            ServerPortmapTcp serverPortmapTcp = new ServerPortmapTcp();
            ServerPortmapUdp serverPortmapUdp = new ServerPortmapUdp();
            ServerVxi11 serverVxi11 = new ServerVxi11();
            serverPortmapTcp.Run("127.0.0.1", port);
            serverPortmapUdp.Run("127.0.0.1", port);
            serverVxi11.RunCoreThread("127.0.0.1", port);
            serverVxi11.RunAbortThread("127.0.0.1", port + 1);

            string rsrc = new String(Console.ReadLine());
            // IMessageBasedSession session1 = (IMessageBasedSession)GlobalResourceManager.Open("TCPIP0::1.2.3.4::5025::SOCKET");
            // IMessageBasedSession session2 = (IMessageBasedSession)GlobalResourceManager.Open("TCPIP::1.2.3.4::inst0::INSTR");
            // IMessageBasedSession session3 = (IMessageBasedSession)GlobalResourceManager.Open("TCPIP::[fe80::1]::hislip0::INSTR");
            // IMessageBasedSession session4 = (IMessageBasedSession)GlobalResourceManager.Open("USB::0x1234::0x5678::A22 - 5::INSTR");

            //IMessageBasedSession session = (IMessageBasedSession)GlobalResourceManager.Open("TCPIP:127.0.0.1");
            //session.FormattedIO.WriteLine("IDN?");
            //string msg = session.FormattedIO.ReadLine();

            serverPortmapUdp.Shutdown();
            serverPortmapTcp.Shutdown();
            serverVxi11.Shutdown();
        }
    }
}