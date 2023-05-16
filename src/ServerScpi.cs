namespace Vxi11Net
{
    internal class ServerScpi
    {
        private const int MaxRecvSize = 1024;
        private byte[] InputBuffer = new byte[MaxRecvSize];
        private int recvsize = 0;
        private string OutputQue = "";
        private string ParseInput = "";

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
            var match = System.Text.RegularExpressions.Regex.Match(ParseInput, "\\*IDN\\?");
            if (match.Success )
            {
                OutputQue = "XYZCO,246B,S000-0123-02,0";
                OutputQue = "YOKOGAWA, WT500,000,0";
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
