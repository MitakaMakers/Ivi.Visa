using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.IO;
using System.Reflection.PortableExecutable;

namespace Vxi11Net
{
    public class HislipListenerExample
    {
        public static void Main(string[] args)
        {
            HislipServer server = new HislipServer();
            server.Start();
            Console.WriteLine("Listening...");
            HislipListener listener = server.AcceptHislipClient();

            while (true)
            {
                HislipListenerContext context = listener.GetMessage();
                HislipListenerRequest request = context.Request;
                HislipListenerResponse response = context.Response;
                switch (request.ControlCode)
                {
                    case Hislip.AsyncLock:
                        break;
                    case Hislip.Data:
                        Stream reader = request.InputStream;
                        Stream output = response.OutputStream;
                        string resBoby = "";
                        byte[] data = System.Text.Encoding.ASCII.GetBytes(resBoby);
                        output.Write(data, 0, data.Length);
                        break;
                    case Hislip.DataEnd:
                        break;
                    case Hislip.DeviceClearComplete:
                        break;
                    case Hislip.AsyncRemoteLocalControl:
                        break;
                    case Hislip.Trigger:
                        break;
                    case Hislip.AsyncDeviceClear:
                        break;
                    case Hislip.AsyncServiceRequest:
                        break;
                    case Hislip.AsyncStatusQuery:
                        break;
                    case Hislip.AsyncLockInfo:
                        break;
                }
            }
            listener.Stop();
        }
    }
}
