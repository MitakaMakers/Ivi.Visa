using System;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Vxi11Net
{
    public class HislipListenerExample
    {
        public static void Main(string[] args)
        {
            HislipServer server = new HislipServer();
            server.Port = 4880;
            server.MaximumMessageSize = 1024 * 1024;
            server.Start();
            Console.WriteLine("Listening...");
            HislipListener listener = server.AcceptClient();

            String text;
            bool IsQuery = false;
            while (listener.IsListening)
            {
                try
                {
                    HislipListenerContext context = listener.GetMessage();
                    HislipListenerRequest request = context.Request;
                    HislipListenerResponse response = context.Response;
                    switch (request.MessageType)
                    {
                        case Hislip.AsyncLock:
                            break;
                        case Hislip.Data_:
                            text = request.PayloadAsString;
                            if (text.Contains("?"))
                            {
                                IsQuery = true;
                            }
                            break;
                        case Hislip.DataEnd:
                            text = request.PayloadAsString;
                            if (text.Contains("?"))
                            {
                                IsQuery = true;
                            }
                            if (IsQuery)
                            {

                                response.ControlCode = Hislip.RMTwasDelivered;
                                byte[] data = System.Text.Encoding.ASCII.GetBytes("XYZCO,246B,S000-0123-02,0");
                                response.Payload = data;
                                byte[] bytes = response.GetBytes();
                                response.OutputStream.Write(bytes);
                            }
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
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}
