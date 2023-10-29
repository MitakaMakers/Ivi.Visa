using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vxi11Net
{
    internal class Vxi11ListenerRequest
    {
        public Stream InputStream { get; internal set; }
        public int Procedure { get; internal set; }
    }
}
