using Vxi11Net;
using Xunit;

namespace Ivi.Visa
{
    public class UnitTest1
    {
        [Fact]
        public void TestVxi11()
        {
            ServerPortmapTcp serverPortmapTcp = new ServerPortmapTcp();
            ServerVxi11 serverVxi11 = new ServerVxi11();
            serverPortmapTcp.OneShot("127.0.0.1", 111, 1);
            serverVxi11.OneShot("127.0.0.1", 50250, 4);
            IMessageBasedSession session1 = (IMessageBasedSession)GlobalResourceManager.Open("TCPIP::127.0.0.1::inst0::INSTR");
            session1.Dispose();
            serverVxi11.Destroy();
            serverPortmapTcp.Destroy();

            serverPortmapTcp.OneShot("127.0.0.1", 111, 1);
            serverVxi11.OneShot("127.0.0.1", 50250, 4);
            IMessageBasedSession session2 = (IMessageBasedSession)GlobalResourceManager.Open("TCPIP::127.0.0.1::INSTR");
            session2.Dispose();
            serverVxi11.Destroy();
            serverPortmapTcp.Destroy();

            serverPortmapTcp.OneShot("127.0.0.1", 111, 1);
            serverVxi11.OneShot("127.0.0.1", 50250, 4);
            IMessageBasedSession session3 = (IMessageBasedSession)GlobalResourceManager.Open("TCPIP::127.0.0.1::inst0");
            session3.Dispose();
            serverVxi11.Destroy();
            serverPortmapTcp.Destroy();

            serverPortmapTcp.OneShot("127.0.0.1", 111, 1);
            serverVxi11.OneShot("127.0.0.1", 50250, 4);
            IMessageBasedSession session4 = (IMessageBasedSession)GlobalResourceManager.Open("TCPIP::127.0.0.1");
            session4.Dispose();
            serverVxi11.Destroy();
            serverPortmapTcp.Destroy();
        }
        [Fact]
        public void TestSocket()
        {
            //IMessageBasedSession session1 = (IMessageBasedSession)GlobalResourceManager.Open("TCPIP0::127.0.0.1::5025::SOCKET");
        }
        [Fact]
        public void TestHislip()
        {
            //IMessageBasedSession session1 = (IMessageBasedSession)GlobalResourceManager.Open("TCPIP::127.0.0.1::hislip0::INSTR");
            //IMessageBasedSession session3 = (IMessageBasedSession)GlobalResourceManager.Open("TCPIP::127.0.0.1::hislip0");
        }
    }
}