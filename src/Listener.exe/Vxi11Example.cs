using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Vxi11Net
{
    public class Vxi11Example
    {
        public static void Main2(string[] args)
        {
            Vxi11Server server = new Vxi11Server();
            server.Start();
            Console.WriteLine("Listening...");
            Vxi11Listener listener = server.AcceptClient();

            Vxi11ListenerContext context = listener.GetMessage();
            Vxi11ListenerRequest request = context.Request;
            Vxi11ListenerResponse response = context.Response;

            StreamReader reader = new StreamReader(request.InputStream);
            StreamWriter writer = new StreamWriter(response.OutputStream);
            string reqBody = reader.ReadToEnd();
            string resBoby = "";

            switch (request.Procedure)
            {
                case Vxi11.DEVICE_WRITE:
                    break;
                case Vxi11.DEVICE_READ:
                    break;
                case Vxi11.DEVICE_READSTB:
                    break;
                case Vxi11.DEVICE_TRIGGER:
                    break;
                case Vxi11.DEVICE_CLEAR:
                    break;
                case Vxi11.DEVICE_REMOTE:
                    break;
                case Vxi11.DEVICE_LOCAL:
                    break;
                case Vxi11.DEVICE_LOCK:
                    break;
                case Vxi11.DEVICE_UNLOCK:
                    break;
                case Vxi11.DEVICE_ENABLE_SRQ:
                    break;
                case Vxi11.DEVICE_DOCMD:
                    break;
            }

            writer.Flush();

            server.Stop();
        }
    }
}
