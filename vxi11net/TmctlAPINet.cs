using System.Net;
using System.Net.Sockets;
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

        public Socket? socket;
        public int lid;
        public int abortPort;
        public int maxRecvSize;
        public int flags;
        public int lock_timeout = 123;
        public int io_timeout = 456;
        public int xid = 789;

        public int Initialize(int wire, string adr, out int id)
        {
            id = 0;
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 10240);

            this.socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            this.socket.Connect(remoteEP);
            this.socket.NoDelay = true;

            int cliendId  = 0;
            int lockDevice = 0;
            string handle = "inst0";
            Vxi11Net.ClientVxi11.create_link(this.socket, this.xid++, cliendId, lockDevice, this.lock_timeout, handle, out this.lid, out this.abortPort, out this.maxRecvSize);
            return 0;
        }
        public int Finish(int id)
        {
            if (this.socket != null)
            {
                ClientVxi11.destroy_link(this.socket, this.xid++, this.lid);
                this.socket.Close();
            }
            return 0;
        }
        public int SetTimeout(int id, int tmo)
        {
            if (this.socket != null)
            {
                socket.SendTimeout = tmo * 100;
                socket.SendTimeout = tmo * 100;
            }
            return 0;
        }
        public int SetTerm(int id, int eos, int eot)
        {
            return 0;
        }
        public int Send(int id, string msg)
        {
            ClientVxi11.Flags flags = ClientVxi11.Flags.none;
            int data_len;
            if (this.socket != null)
            {
                Vxi11Net.ClientVxi11.device_write(this.socket, this.xid++, this.lid, flags, this.lock_timeout, this.io_timeout, msg, out data_len);
            }
            return 0;
        }
        public int Receive(int id, ref StringBuilder buff, int blen, ref int rlen)
        {
            int requestSize = blen;
            ClientVxi11.Flags flags = ClientVxi11.Flags.none;
            ClientVxi11.TermChar termchar = ClientVxi11.TermChar.LF;
            int reason;
            byte[] data ;
            if (this.socket == null)
            {
                return 0;
            }
            Vxi11Net.ClientVxi11.device_read(this.socket, this.xid++, this.lid,  requestSize, flags, this.lock_timeout, this.io_timeout, termchar, out reason, out data);
            string str = Encoding.GetEncoding("ASCII").GetString(data);
            buff = new StringBuilder(str);
            rlen = data.Length;
            return 0;
        }
        public int ReceiveSetup(int id)
        {
            return 0;
        }
        public int ReceiveBlockHeader(int id, ref int length)
        {
            return 0;
        }
        public int ReceiveBlockData(int id, ref sbyte buff, int blen, ref int rlen, ref int end)
        {
            return 1;
        }
        public int SetRen(int id, int flag)
        {
            ClientVxi11.Flags flags = ClientVxi11.Flags.none;
            if (this.socket == null)
            {
                return 0;
            }
            if (flag == 0)
            {
                Vxi11Net.ClientVxi11.device_local(this.socket, this.xid++, this.lid, flags, this.lock_timeout, this.io_timeout);
            }
            else
            {
                Vxi11Net.ClientVxi11.device_remote(this.socket, this.xid++, this.lid, flags, this.lock_timeout, this.io_timeout);
            }
            return 0;
        }
        public int DeviceClear(int id)
        {
            ClientVxi11.Flags flags = ClientVxi11.Flags.none;
            if (this.socket != null)
            {
                Vxi11Net.ClientVxi11.device_clear(this.socket, this.xid++, this.lid, flags, this.lock_timeout, this.io_timeout);
            }
            return 0;
        }
        public int DeviceTrigger(int id)
        {
            ClientVxi11.Flags flags = ClientVxi11.Flags.none;
            if (this.socket != null)
            {
                Vxi11Net.ClientVxi11.device_trigger(this.socket, this.xid++, this.lid, flags, this.lock_timeout, this.io_timeout);
            }
            return 0;
        }
    }
}