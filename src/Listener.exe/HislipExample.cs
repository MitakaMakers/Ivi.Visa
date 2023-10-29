using System;
using System.Text;
using System.IO;
using TmctlAPINet;

namespace Vxi11Net
{
    public class HislipListenerExample
    {
        public static void Main(string[] args)
        {
            TMCTL tmctl = new TMCTL();
            //int id = 0;
            //tmctl.Initialize(TMCTL.TM_CTL_USBTMC2, "TEMP01", ref id);

            HislipServer server = new HislipServer();
            server.Port = 4880;
            server.MaximumMessageSize = 1024 * 1024;
            server.Start();
            Console.WriteLine("Listening...");
            HislipListener listener = server.AcceptClient();

            while (true)
            {
                try { 
                    HislipListenerContext context = listener.GetMessage();
                    HislipListenerRequest request = context.Request;
                    HislipListenerResponse response = context.Response;
                    byte[] dest;
                    String text;
                    bool IsQuery = false;
                    switch (request.MessageType)
                    {
                        case Hislip.AsyncLock:
                            break;
                        case Hislip.Data_:
                            text = request.PayloadAsString;
                            //tmctl.Send(id, text);
                            if (text.Contains("?"))
                            {
                                IsQuery = true;
                            }
                            break;
                        case Hislip.DataEnd:
                            text = request.PayloadAsString;
                            //tmctl.Send(id, text);
                            if (text.Contains("?")){
                                IsQuery = true;
                            }
                            if (IsQuery)
                            {

                                StringBuilder buff = new StringBuilder(1000);
                                int rlen = 1;
                                //tmctl.Receive(id, buff, 1000, ref rlen);
                                if (rlen > 0)
                                {
                                    response.ControlCode = Hislip.RMTwasDelivered;
                                    byte[] data = System.Text.Encoding.ASCII.GetBytes("YOKOGAWA,DL950,V1.1,TEMP01\n" /* buff.ToString() */);
                                    response.Payload = data;
                                    byte[] bytes = response.GetBytes();
                                    response.OutputStream.Write(bytes);
                                }
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
                    break;
                }
            }
            server.Stop();
        }
    }
}
