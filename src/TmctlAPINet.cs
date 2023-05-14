using System.Security.Cryptography;
using System.Text;
using Vxi11Net;

namespace TmctlAPINet
{
    public class TMCTL
    {
        public const int TM_CTL_GPIB = 1;
        public const int TM_CTL_RS232 = 2;
        public const int TM_CTL_USB = 3;
        public const int TM_CTL_ETHER = 4;
        public const int TM_CTL_USBTMC = 5;
        public const int TM_CTL_ETHERUDP = 6;
        public const int TM_CTL_USBTMC2 = 7;
        public const int TM_CTL_VXI11 = 8;
        public const int TM_CTL_VISAUSB = 10;
        public const int TM_CTL_SOCKET = 11;
        public const int TM_CTL_USBTMC3 = 12;
        public const int TM_CTL_HISLIP = 14;

        private TmVxi11 client = new TmVxi11();

        public int Initialize(int wire, string adr, out int id)
        {
            id = 0;
            client.Initialize(adr);
            return 0;
        }
        public int Finish(int id)
        {
            client.Finish();
            return 0;
        }
        public int SetTimeout(int id, int tmo)
        {
            client.SetTimeout(tmo);
            return 0;
        }
        public int SetTerm(int id, int eos, int eot)
        {
            client.SetTerm(eos, eot);
            return 0;
        }
        public int Send(int id, string msg)
        {
            client.Send(msg);
            return 0;
        }
        public int Receive(int id, ref StringBuilder buff, int blen, ref int rlen)
        {
            client.Receive(ref buff, blen, ref rlen);
            return 0;
        }
        public int ReceiveSetup(int id)
        {
            client.ReceiveSetup();
            return 0;
        }
        public int ReceiveBlockHeader(int id, ref int length)
        {
            client.ReceiveBlockHeader(ref length);
            return 0;
        }
        public int ReceiveBlockData(int id, ref sbyte buff, int blen, ref int rlen, ref int end)
        {
            client.ReceiveBlockData(ref buff, blen, ref rlen, ref end);
            return 1;
        }
        public int SetRen(int id, int flag)
        {
            if (flag == 0)
            {
                client.SetLocal();
            }
            else
            {
                client.SetRemote();
            }
            return 0;
        }
        public int DeviceClear(int id)
        {
            client.DeviceClear();
            return 0;
        }
        public int DeviceTrigger(int id)
        {
            client.DeviceTrigger();
            return 0;
        }
    }
    internal class TmVxi11
    {
        private ClientVxi11 client = new ClientVxi11();

        private int lid;
        private int corePort;
        private int abortPort;
        private int maxRecvSize;
        private int lock_timeout = 123;
        private int io_timeout = 456;

        internal void Initialize(string address)
        {
            int cliendId = 0;
            int lockDevice = 0;
            string handle = "inst0";
            ClientPortmapTcp clientPmap = new ClientPortmapTcp();
            clientPmap.Create(address, 111);
            corePort = clientPmap.GetPort(Vxi11.DEVICE_CORE_PROG, Vxi11.DEVICE_CORE_VERSION, Portmap.IPPROTO.TCP);
            client.Create(address, corePort);
            client.CreateLink(cliendId, lockDevice, lock_timeout, handle, out lid, out abortPort, out maxRecvSize);
        }
        internal void Finish()
        {
            client.DestroyLink(lid);
            client.Destroy();
        }

        internal int SetTimeout(int tmo)
        {
            io_timeout = tmo * 100;
            lock_timeout = tmo * 100;
            return 0;
        }
        internal int SetTerm(int eos, int eot)
        {
            return 0;
        }
        internal int Send(string msg)
        {
            int data_len;
            client.DeviceWrite(lid, Vxi11.Flags.none, lock_timeout, io_timeout, msg, out data_len);
            return 0;
        }
        internal int Receive(ref StringBuilder buff, int blen, ref int rlen)
        {
            int requestSize = blen;
            Vxi11.Flags flags = Vxi11.Flags.none;
            Vxi11.TermChar termchar = Vxi11.TermChar.LF;
            int reason;
            byte[] data;
            client.DeviceRead(lid, requestSize, flags, lock_timeout, io_timeout, termchar, out reason, out data);
            string str = Encoding.GetEncoding("ASCII").GetString(data);
            buff = new StringBuilder(str);
            rlen = data.Length;
            return 0;
        }
        internal int ReceiveSetup()
        {
            return 0;
        }
        internal int ReceiveBlockHeader(ref int length)
        {
            return 0;
        }
        internal int ReceiveBlockData(ref sbyte buff, int blen, ref int rlen, ref int end)
        {
            return 1;
        }
        internal int SetLocal()
        {
            client.DeviceLocal(lid, Vxi11.Flags.none, lock_timeout, io_timeout);
            return 0;
        }
        internal int SetRemote()
        {
            client.DeviceRemote(lid, Vxi11.Flags.none, lock_timeout, io_timeout);
            return 0;
        }

        internal int DeviceClear()
        {
            client.DeviceClear(lid, Vxi11.Flags.none, lock_timeout, io_timeout);
            return 0;
        }
        internal int DeviceTrigger()
        {
            client.DeviceTrigger(lid, Vxi11.Flags.none, lock_timeout, io_timeout);
            return 0;
        }
    }
}