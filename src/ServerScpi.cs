using System.Data.Common;
using System.Drawing;
using System.Security.Cryptography;

namespace Vxi11Net
{
    internal class ServerScpi
    {
        private const int MaxRecvSize = 1024;
        private byte[] InputBuffer = new byte[MaxRecvSize];
        private int recvsize = 0;
        private string OutputQue = "";
        private string ParseInput = "";
        private Dictionary<string, string> command = new Dictionary<string, string>()
        {
            { "\\*AAD", "" },
            { "\\*CAL\\?", "0" },
            { "\\*CLS", "" },
            { "\\*DDT", "" },
            { "\\*DDT\\?", "0"} ,
            { "\\*DLF", "" },
            { "\\*DMC", "" },
            { "\\*EMC", "" },
            { "\\*EMC\\?", "0" },
            { "\\*ESE", "" },
            { "\\*ESE\\?", "0" },
            { "\\*ESR\\?", "0" },
            { "\\*GMC\\?", "0" },
            { "\\*IDN\\?", "XYZCO,246B,S000-0123-02,0" },
            { "\\*IST\\?", "0" },
            { "\\*LMC\\?", "0" },
            { "\\*LRN\\?", "0" },
            { "\\*OPC", "" },
            { "\\*OPC\\?", "0" },
            { "\\*OPT\\?", "0" },
            { "\\*PCB", "" },
            { "\\*PMC", "" },
            { "\\*PRE", "" },
            { "\\*PRE\\?", "0" },
            { "\\*PSC", "" },
            { "\\*PSC\\?", "0" },
            { "\\*PUD", "" },
            { "\\*PUD\\?", "0" },
            { "\\*RCL", "" },
            { "\\*RDT", "" },
            { "\\*RDT\\?", "0" },
            { "\\*RMC", "" },
            { "\\*RST", "" },
            { "\\*SAV", "" },
            { "\\*SDS", "" },
            { "\\*SRE", "" },
            { "\\*SRE\\?", "0" },
            { "\\*STB\\?", "0" },
            { "\\*TRG", "" },
            { "\\*TST\\?", "0" },
            { "\\*WAI", "" },
        };
        public ServerScpi() { }
        public int GetMaxRecvSize()
        {
            return MaxRecvSize;
        }
        public string GetResponse()
        {
            string resp = OutputQue; 
            return resp;
        }
        public void Abort()
        { }
        public void Parse()
        {
            ParseInput = System.Text.Encoding.ASCII.GetString(InputBuffer);
            foreach (KeyValuePair<string, string> pair in command)
            {
                var match = System.Text.RegularExpressions.Regex.Match(ParseInput, pair.Key);
                if (match.Success)
                {
                    OutputQue = pair.Value;
                    break;
                }
            }
        }
        public void bav(byte[] data)
        {
            System.Array.Copy(data, 0, InputBuffer, recvsize, data.Length);
            recvsize += data.Length;
        }
        public bool IsMav()
        {
            if (OutputQue != "")
            {
                return true;
            }
            return false;
        }
        public bool IsEND()
        {
            if (OutputQue != "")
            {
                return false;
            }
            return true;
        }
        public string GetMessage()
        {
            string reply = OutputQue;
            InputBuffer = new byte[0];
            ParseInput = "";
            OutputQue = "";
            return reply;
        }
        public void dcas()
        { }
        public void brq()
        { }
        public void get()
        { }
        public void RMT_sent()
        {
            Parse();
        }
        public byte stb()
        {
            return 0;
        }
    }
}
