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
            ServerPortmapTcp serverPortmapTcp = new ServerPortmapTcp();
            ServerVxi11 serverVxi11 = new ServerVxi11();
            serverPortmapTcp.OneShot("127.0.0.1", 111, 1);
            serverVxi11.RunCoreThread("127.0.0.1", 50250, 4);

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