using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vxi11Net
{
    internal class Vxi11ListenerContext
    {
        public Vxi11ListenerRequest Request { get; internal set; }
        public Vxi11ListenerResponse Response { get; internal set; }
    }
}
