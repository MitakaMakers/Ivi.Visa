namespace Vxi11Net
{
    internal class ServerScpi
    {
        private string command = "";
        private string response = "";
        private string TERMCHAR = "\n";
        private bool TERMCHAR_EN = true;
        private bool SEND_END_EN = true;

        public ServerScpi() { }
        public int GetMaxRecvSize()
        {
            return 1024;
        }
        public int Parse(string s)
        {
            command = s;
            if (TERMCHAR_EN)
            {
                
            }
            response = "XYZCO,246B,S000-0123-02,0";
            return 0;
        }
        public string GetResponse()
        {
            string resp = response; 
            if (SEND_END_EN)
            {
                resp = resp + TERMCHAR;
            }
            return resp;
        }
        public void Abort()
        { }
        public void bav()
        { }
        public void dcas()
        { }
        public void brq()
        { }
        public void get()
        { }
        public void RMT_sent()
        { }
        public byte stb()
        {
            return 0;
        }
    }
}
