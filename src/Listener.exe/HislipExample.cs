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
            int id = 0;
            tmctl.Initialize(TMCTL.TM_CTL_USBTMC2, "TEMP01", ref id);

            HislipServer server = new HislipServer();
            server.Start();
            Console.WriteLine("Listening...");
            HislipListener listener = server.AcceptHislipClient();

            while (true)
            {
                try { 
                    HislipListenerContext context = listener.GetMessage();
                    HislipListenerRequest request = context.Request;
                    HislipListenerResponse response = context.Response;
                    switch (request.ControlCode)
                    {
                        case Hislip.AsyncLock:
                            break;
                        case Hislip.Data:
                        case Hislip.DataEnd:
                            StreamReader reader = new StreamReader(request.InputStream);
                            String text = reader.ReadToEnd();
                            tmctl.Send(id, text);
                            if (text.Contains("?")){
                                StringBuilder buff = new StringBuilder(1000);
                                int rlen = 0;
                                tmctl.Receive(id, buff, 1000, ref rlen);
                                if (rlen > 0)
                                {
                                    Stream output = response.OutputStream;
                                    byte[] data = System.Text.Encoding.ASCII.GetBytes(buff.ToString());
                                    output.Write(data, 0, data.Length);
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
