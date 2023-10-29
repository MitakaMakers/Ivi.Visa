using System;
using System.IO;
using System.Text;
using TmctlAPINet;

namespace Vxi11Net
{
    public class Vxi11Example
    {
        public static void Main2(string[] args)
        {
            TMCTL tmctl = new TMCTL();
            int id = 0;
            tmctl.Initialize(TMCTL.TM_CTL_USBTMC2, "TEMP01", ref id);

            Vxi11Server server = new Vxi11Server();
            server.Start();
            Console.WriteLine("Listening...");
            Vxi11Listener listener = server.AcceptClient();

            while (true)
            {
                try
                {
                    Vxi11ListenerContext context = listener.GetMessage();
                    Vxi11ListenerRequest request = context.Request;
                    Vxi11ListenerResponse response = context.Response;

                    switch (request.Procedure)
                    {
                        case Vxi11.DEVICE_WRITE:
                            StreamReader reader = new StreamReader(request.InputStream);
                            String text = reader.ReadToEnd();
                            tmctl.Send(id, text);
                            break;
                        case Vxi11.DEVICE_READ:
                            StringBuilder buff = new StringBuilder(1000);
                            int rlen = 0;
                            tmctl.Receive(id, buff, 1000, ref rlen);
                            if (rlen > 0)
                            {
                                Stream output = response.OutputStream;
                                byte[] data = System.Text.Encoding.ASCII.GetBytes(buff.ToString());
                                output.Write(data, 0, data.Length);
                            }
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
