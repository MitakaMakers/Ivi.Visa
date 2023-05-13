using Xunit;
using TmctlAPINet;
using Vxi11Net;

namespace TmctlAPINet.Tests
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
            serverVxi11.RunCoreChannel("127.0.0.1", port);
            serverVxi11.RunAbortChannel("127.0.0.1", port + 1);

            int id, ret;
            System.Text.StringBuilder buff = new System.Text.StringBuilder();
            int rlen = 0;
            TMCTL tmctl = new TMCTL();
            ret = tmctl.Initialize(TMCTL.TM_CTL_VXI11, "127.0.0.1", out id);
            ret = tmctl.Send(id, "*IDN?");
            ret = tmctl.Receive(id, ref buff, buff.Length, ref rlen);
            ret = tmctl.Finish(id);
        }
    }
}