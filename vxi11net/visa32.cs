using System;
using VXI11Net;

namespace Ivi.Visa.Interop{

    public enum AccessMode
    {
        NO_LOCK
    }
    public class IMessage
    {
        public int Timeout { get; set; }
    }
    public class ResourceManager
    {
        public IMessage Open(string str, AccessMode mode, int a, string b) {
            return new IMessage();
        }
    }
    public class FormattedIO488
    {
        public IMessage IO = new IMessage();
        public void WriteString(string str){}
        public string ReadString(){
            return "";
        }
    }
}