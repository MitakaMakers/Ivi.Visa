using System.Data.Common;
using System.Drawing;
using System.Security.Cryptography;

namespace Vxi11Net
{
    internal class ServerScpi
    {
        private byte[] InputBuffer = new byte[MaxRecvSize];
        private byte[] OutputQueue = new byte[0];

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
        private const int MaxRecvSize = 1024;
        private int recvsize = 0;
        private bool isEnd = false;
        private string ParseInput = "";

        public ServerScpi() { }
        public int GetMaxRecvSize()
        {
            return MaxRecvSize;
        }
        public byte[] GetResponse()
        {
            byte[] resp = OutputQueue; 
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
                    OutputQueue = System.Text.Encoding.ASCII.GetBytes(pair.Value);
                    isEnd = true;
                    break;
                }
            }
        }
        public void bav(byte[] data)
        {
            isEnd = false;
            System.Array.Copy(data, 0, InputBuffer, recvsize, data.Length);
            recvsize += data.Length;
        }
        public bool IsMav()
        {
            if (0 < OutputQueue.Length)
            {
                return true;
            }
            return false;
        }
        public bool IsEND()
        {
            return isEnd;
        }
        public byte[] GetMessage()
        {
            byte[] reply = OutputQueue;
            InputBuffer = new byte[0];
            ParseInput = "";
            OutputQueue = new byte[0];
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
