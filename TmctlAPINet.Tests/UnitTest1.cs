using Xunit;
using TmctlAPINet;

namespace TmctlAPINet.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
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