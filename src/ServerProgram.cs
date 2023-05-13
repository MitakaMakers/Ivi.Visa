namespace Vxi11Net
{
    public class ServerProgram
    {
        public static void Main(string[] args)
        {
            bool isLoop = true;
            while (isLoop)
            {
                Console.WriteLine("Select Test target");
                Console.WriteLine("   1:Test VXI-11 server");
                Console.WriteLine("   2:Test Portmap server");
                Console.WriteLine("   3:Run Demo server");
                Console.WriteLine(" E/Q:exit program");
                Console.WriteLine("");
                Console.Write("Input fuction number? : ");
                string a = new String(Console.ReadLine());
                if (a == "1")
                {
                    Vxi11Console();
                }
                else if (a == "2")
                {
                    PortmapConsole();
                }
                else if (a == "3")
                {
                    DemoConsole();
                }
                else if ((a == "Q") || (a == "q") || (a == "E") || (a == "e"))
                {
                    Console.WriteLine("== Exit program ==");
                    Environment.Exit(0);
                }
            }
        }
        public static void Vxi11Console()
        {
            bool isLoop = true;
            ServerVxi11 serverVxi11 = new ServerVxi11();
            Rpc.RPC_MESSAGE_PARAMS msg = new Rpc.RPC_MESSAGE_PARAMS();

            while (isLoop)
            {
                Console.WriteLine("Select VXI-11 server Function");
                Console.WriteLine("   1:create Vxi11 server (core channel)");
                Console.WriteLine("   2:receive message");
                Console.WriteLine("   3:reply to create_link");
                Console.WriteLine("   4:reply to device_write");
                Console.WriteLine("   5:reply to device_read");
                Console.WriteLine("   6:reply to device_readstb");
                Console.WriteLine("   7:reply to device_trigger");
                Console.WriteLine("   8:reply to device_clear");
                Console.WriteLine("   9:reply to device_remote");
                Console.WriteLine("  10:reply to device_local");
                Console.WriteLine("  11:reply to device_lock");
                Console.WriteLine("  12:reply to device_unlock");
                Console.WriteLine("  13:reply to device_enable_srq");
                Console.WriteLine("  14:reply to device_docmd");
                Console.WriteLine("  15:reply to destroy_link");
                Console.WriteLine("  16:reply to create_intr_chan");
                Console.WriteLine("  17:reply to destroy_intr_chan");
                Console.WriteLine("  18:reply to device_abort");
                //Console.WriteLine("  19:send device_intr_srq");
                //Console.WriteLine("  20:receive abort message");
                //Console.WriteLine("  21:create RPC client (interrupt channel)");
                //Console.WriteLine("  22:close RPC client (interrupt channel)");
                //Console.WriteLine("  23:unregister core channel with portmapper");
                Console.WriteLine("  24:close RPC server (core channel)");
                //Console.WriteLine("  25:close RPC server (abort channel)");
                Console.WriteLine("  26:run core server");
                Console.WriteLine("  27:shutdown server");
                Console.WriteLine("   B:back to Main menu");
                Console.WriteLine(" E/Q:Exit program");
                Console.WriteLine("");
                Console.Write("Input fuction number? : ");
                string code = new String(Console.ReadLine());
                if (code == "1")
                {
                    Console.Write("  port number? : ");
                    int port = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("== create RPC server (core channel) ==");
                    serverVxi11.Create("127.0.0.1", port);
                    Console.WriteLine(" Call : create_core_channel : ret=0");
                }
                else if (code == "2")
                {
                    Console.WriteLine("  == Wait RPC ==");
                    msg = serverVxi11.ReceiveMsg();
                    Console.WriteLine("    received MSG.");
                    Console.WriteLine("      xid     = {0}", msg.xid);
                    Console.WriteLine("      type    = {0}", msg.msg_type);
                    Console.WriteLine("      prog    = {0}", msg.prog);
                    Console.WriteLine("      proc    = {0}", msg.proc);
                    Console.WriteLine("      vers    = {0}", msg.vers);
                    if (msg.proc == Vxi11.CREATE_LINK)
                    {
                        string handle;
                        Vxi11.CREATE_LINK_PARAMS cre = serverVxi11.ReceiveCreateLink(out handle);
                        Console.WriteLine("    == CREATE_LINK ==");
                        Console.WriteLine("      lock_timeout = {0}", cre.lock_timeout);
                        Console.WriteLine("      clientId     = {0}", cre.clientId);
                        Console.WriteLine("      lockDevice   = {0}", cre.lockDevice);
                        Console.WriteLine("      handle       = {0}", handle);
                        Console.WriteLine("");
                    }
                    else if (msg.proc == Vxi11.DEVICE_WRITE)
                    {
                        string data;
                        Vxi11.DEVICE_WRITE_PARAMS wrt = serverVxi11.ReceiveDeviceWrite(out data);
                        Console.WriteLine("    == DEVICE_WRITE ==");
                        Console.WriteLine("      lid          = {0}", wrt.lid);
                        Console.WriteLine("      flags        = {0}", wrt.flags);
                        Console.WriteLine("      lock_timeout = {0}", wrt.lock_timeout);
                        Console.WriteLine("      io_timeout   = {0}", wrt.io_timeout);
                        Console.WriteLine("      data         = {0}", data);
                        Console.WriteLine("");
                    }
                    else if (msg.proc == Vxi11.DEVICE_READ)
                    {
                        Vxi11.DEVICE_READ_PARAMS red = serverVxi11.ReceiveDeviceRead();
                        Console.WriteLine("    == DEVICE_READ ==");
                        Console.WriteLine("      lid          = {0}", red.lid);
                        Console.WriteLine("      requestSize  = {0}", red.requestSize);
                        Console.WriteLine("      io_timeout   = {0}", red.io_timeout);
                        Console.WriteLine("      lock_timeout = {0}", red.lock_timeout);
                        Console.WriteLine("      flags        = {0}", red.flags);
                        Console.WriteLine("      termChar     = {0}", red.termChar);
                        Console.WriteLine("");
                    }
                    else if (msg.proc == Vxi11.DEVICE_READSTB)
                    {
                        Vxi11.DEVICE_GENERIC_PARAMS gen = serverVxi11.ReceiveGenericParams();
                        Console.WriteLine("    == DEVICE_READSTB ==");
                        Console.WriteLine("      lid          = {0}", gen.lid);
                        Console.WriteLine("      flags        = {0}", gen.flags);
                        Console.WriteLine("      lock_timeout = {0}", gen.lock_timeout);
                        Console.WriteLine("      io_timeout   = {0}", gen.io_timeout);
                        Console.WriteLine("");
                    }
                    else if (msg.proc == Vxi11.DEVICE_TRIGGER)
                    {
                        Vxi11.DEVICE_GENERIC_PARAMS gen = serverVxi11.ReceiveGenericParams();
                        Console.WriteLine("    == DEVICE_TRIGGER ==");
                        Console.WriteLine("      lid          = {0}", gen.lid);
                        Console.WriteLine("      flags        = {0}", gen.flags);
                        Console.WriteLine("      lock_timeout = {0}", gen.lock_timeout);
                        Console.WriteLine("      io_timeout   = {0}", gen.io_timeout);
                        Console.WriteLine("");
                    }
                    else if (msg.proc == Vxi11.DEVICE_CLEAR)
                    {
                        Vxi11.DEVICE_GENERIC_PARAMS gen = serverVxi11.ReceiveGenericParams();
                        Console.WriteLine("    == DEVICE_CLEAR ==");
                        Console.WriteLine("      lid          = {0}", gen.lid);
                        Console.WriteLine("      flags        = {0}", gen.flags);
                        Console.WriteLine("      lock_timeout = {0}", gen.lock_timeout);
                        Console.WriteLine("      io_timeout   = {0}", gen.io_timeout);
                        Console.WriteLine("");
                    }
                    else if (msg.proc == Vxi11.DEVICE_REMOTE)
                    {
                        Vxi11.DEVICE_GENERIC_PARAMS gen = serverVxi11.ReceiveGenericParams();
                        Console.WriteLine("    == DEVICE_REMOTE ==");
                        Console.WriteLine("      lid          = {0}", gen.lid);
                        Console.WriteLine("      flags        = {0}", gen.flags);
                        Console.WriteLine("      lock_timeout = {0}", gen.lock_timeout);
                        Console.WriteLine("      io_timeout   = {0}", gen.io_timeout);
                        Console.WriteLine("");
                    }
                    else if (msg.proc == Vxi11.DEVICE_LOCAL)
                    {
                        Vxi11.DEVICE_GENERIC_PARAMS gen = serverVxi11.ReceiveGenericParams();
                        Console.WriteLine("    == DEVICE_LOCAL ==");
                        Console.WriteLine("      lid          = {0}", gen.lid);
                        Console.WriteLine("      flags        = {0}", gen.flags);
                        Console.WriteLine("      lock_timeout = {0}", gen.lock_timeout);
                        Console.WriteLine("      io_timeout   = {0}", gen.io_timeout);
                        Console.WriteLine("");
                    }
                    else if (msg.proc == Vxi11.DEVICE_LOCK)
                    {
                        Vxi11.DEVICE_LOCK_PARAMS lck = serverVxi11.ReceiveDeviceLock();
                        Console.WriteLine("    == DEVICE_LOCK ==");
                        Console.WriteLine("      lid          = {0}", lck.lid);
                        Console.WriteLine("      flags        = {0}", lck.flags);
                        Console.WriteLine("      lock_timeout = {0}", lck.lock_timeout);
                        Console.WriteLine("");
                    }
                    else if (msg.proc == Vxi11.DEVICE_UNLOCK)
                    {
                        long lnk = serverVxi11.ReceiveDeviceLink();
                        Console.WriteLine("    == DEVICE_UNLOCK ==");
                        Console.WriteLine("      device_link  = {0}", lnk);
                        Console.WriteLine("");
                    }
                    else if (msg.proc == Vxi11.DEVICE_ENABLE_SRQ)
                    {
                        string handle;
                        Vxi11.DEVICE_ENABLE_SRQ_PARAMS ena = serverVxi11.ReceiveDeviceEnableSrq(out handle);
                        Console.WriteLine("    == DEVICE_ENABLE_SRQ ==");
                        Console.WriteLine("      lid          = {0}", ena.lid);
                        Console.WriteLine("      enable       = {0}", ena.enable);
                        Console.WriteLine("      handle       = {0}", handle);
                        Console.WriteLine("");
                    }
                    else if (msg.proc == Vxi11.DEVICE_DOCMD)
                    {
                        byte[] data_in;
                        Vxi11.DEVICE_DOCMD_PARAMS dcm = serverVxi11.ReceiveDeviceDoCmd(out data_in);
                        Console.WriteLine("    == DEVICE_DOCMD ==");
                        Console.WriteLine("      lid           = {0}", dcm.lid);
                        Console.WriteLine("      flags         = {0}", dcm.flags);
                        Console.WriteLine("      io_timeout    = {0}", dcm.io_timeout);
                        Console.WriteLine("      lock_timeout  = {0}", dcm.lock_timeout);
                        Console.WriteLine("      cmd           = {0}", dcm.cmd);
                        Console.WriteLine("      network_order = {0}", dcm.network_order);
                        Console.WriteLine("      datasize      = {0}", dcm.datasize);
                        Console.WriteLine("");
                    }
                    else if (msg.proc == Vxi11.DESTROY_LINK)
                    {
                        long lnk = serverVxi11.ReceiveDeviceLink();
                        Console.WriteLine("    == DESTROY_LINK ==");
                        Console.WriteLine("      device_link  = {0}", lnk);
                        Console.WriteLine("");
                    }
                    else if (msg.proc == Vxi11.CREATE_INTR_CHAN)
                    {
                        Vxi11.CREATE_INTR_CHAN_PARAMS cic = serverVxi11.ReceiveCreateIntrchan();
                        Console.WriteLine("    == CREATE_INTR_CHAN ==");
                        Console.WriteLine("      hostaddr   = {0}", cic.hostaddr);
                        Console.WriteLine("      hostport   = {0}", cic.hostport);
                        Console.WriteLine("      prognum    = {0}", cic.prognum);
                        Console.WriteLine("      progvers   = {0}", cic.progvers);
                        Console.WriteLine("      progfamily = {0}", cic.progfamily);
                        Console.WriteLine("");
                    }
                    else if (msg.proc == Vxi11.DESTROY_INTR_CHAN)
                    {
                        Console.WriteLine("    == DESTROY_INTR_CHAN ==");
                        Console.WriteLine("");
                    }
                    else if (msg.proc == Vxi11.DEVICE_ABORT)
                    {
                        long lnk = serverVxi11.ReceiveDeviceLink();
                        Console.WriteLine("    == DEVICE_ABORT ==");
                        Console.WriteLine("      device_link  = {0}", lnk);
                        Console.WriteLine("");
                    }
                    else
                    {
                        serverVxi11.Flush();
                        Console.WriteLine("    == clear_buffer ==");
                        Console.WriteLine("");
                    }
                }
                else if (code == "3")
                {
                    serverVxi11.ReplyCreateLink(msg.xid, 123, 456, 789);
                    Console.WriteLine("== reply to create_link ==");
                }
                else if (code == "4")
                {
                    Console.Write("  data_len? : ");
                    int data_len = Convert.ToInt32(Console.ReadLine());
                    serverVxi11.ReplyDeviceWrite(msg.xid, data_len);
                    Console.WriteLine("== reply to device_write ==");
                }
                else if (code == "5")
                {
                    serverVxi11.ReplyDeviceRead(msg.xid, Vxi11.Reason.END, "XYZCO,246B,S000-0123-02,0");
                    Console.WriteLine("== reply to device_read ==");
                }
                else if (code == "6")
                {
                    Console.Write("  stb? : ");
                    byte stb = Convert.ToByte(Console.ReadLine());
                    serverVxi11.ReplyDeviceReadStb(msg.xid, stb);
                    Console.WriteLine("== reply to device_readstb ==");
                }
                else if (code == "7")
                {
                    serverVxi11.ReplyDeviceError(msg.xid, Rpc.SUCCESS);
                    Console.WriteLine("== reply to device_trigger ==");
                }
                else if (code == "8")
                {
                    serverVxi11.ReplyDeviceError(msg.xid, Rpc.SUCCESS);
                    Console.WriteLine("== reply to device_clear ==");
                }
                else if (code == "9")
                {
                    serverVxi11.ReplyDeviceError(msg.xid, Rpc.SUCCESS);
                    Console.WriteLine("== reply to device_remote ==");
                }
                else if (code == "10")
                {
                    serverVxi11.ReplyDeviceError(msg.xid, Rpc.SUCCESS);
                    Console.WriteLine("== reply to device_local ==");
                }
                else if (code == "11")
                {
                    serverVxi11.ReplyDeviceError(msg.xid, Rpc.SUCCESS);
                    Console.WriteLine("== reply to device_lock ==");
                }
                else if (code == "12")
                {
                    serverVxi11.ReplyDeviceError(msg.xid, Rpc.SUCCESS);
                    Console.WriteLine("== reply to device_unlock ==");
                }
                else if (code == "13")
                {
                    serverVxi11.ReplyDeviceError(msg.xid, Rpc.SUCCESS);
                    Console.WriteLine("== reply to device_enable_srq ==");
                }
                else if (code == "14")
                {
                    Console.Write("  data_in_len? : ");
                    int data_in_len = Convert.ToInt32(Console.ReadLine());
                    serverVxi11.ReplyDeviceDoCmd(msg.xid, data_in_len);
                    Console.WriteLine("== reply to device_docmd ==");
                }
                else if (code == "15")
                {
                    serverVxi11.ReplyDeviceError(msg.xid, Rpc.SUCCESS);
                    Console.WriteLine("== :reply to destroy_link ==");
                }
                else if (code == "16")
                {
                    serverVxi11.ReplyDeviceError(msg.xid, Rpc.SUCCESS);
                    Console.WriteLine("== reply to create_intr_chan ==");
                }
                else if (code == "17")
                {
                    serverVxi11.ReplyDeviceError(msg.xid, Rpc.SUCCESS);
                    Console.WriteLine("== reply to destroy_intr_chan ==");
                }
                else if (code == "18")
                {
                    Console.WriteLine("  21:reply to device_abort");
                }
                else if (code == "19")
                {
                    Console.WriteLine("  22:send device_intr_srq");
                }
                else if (code == "20")
                {
                    Console.WriteLine("  23:receive abort message");
                }
                else if (code == "21")
                {
                    Console.WriteLine("== create_interrupt_channel ==");
                }
                else if (code == "22")
                {
                    Console.WriteLine("== close_interrupt_channel ==");
                }
                else if (code == "23")
                {
                    Console.WriteLine("  26:unregister core channel with portmapper");
                }
                else if (code == "24")
                {
                    Console.WriteLine("== close_coret_channel ==");
                }
                else if (code == "25")
                {
                    Console.WriteLine("== close_abort_channel ==");
                }
                else if (code == "26")
                {
                    Console.Write("  port number? : ");
                    int port = Convert.ToInt32(Console.ReadLine());
                    serverVxi11.RunCoreChannel("127.0.0.1", port);
                }
                else if (code == "27")
                {
                    serverVxi11.Shutdown();
                }
                else if ((code == "B") || (code == "b"))
                {
                    isLoop = false;
                }
                else if ((code == "Q") || (code == "q") || (code == "E") || (code == "e"))
                {
                    Console.WriteLine("== Exit program ==");
                    Environment.Exit(0);
                }
            }
        }
        public static void PortmapConsole()
        {
            bool isLoop = true;
            ServerPortmapTcp serverPortmapTcp = new ServerPortmapTcp();
            ServerPortmapUdp serverPortmapUdp = new ServerPortmapUdp();
            Rpc.RPC_MESSAGE_PARAMS msg = new Rpc.RPC_MESSAGE_PARAMS();

            while (isLoop)
            {
                Console.WriteLine("Select Portmap Function");
                Console.WriteLine("   1:create portmap server(TCP)");
                Console.WriteLine("   2:receive message");
                Console.WriteLine("   3:reply to pmap_set");
                Console.WriteLine("   4:reply to pmap_unset");
                Console.WriteLine("   5:reply to pmap_getport");
                Console.WriteLine("   6:close portmap server");
                Console.WriteLine("   7:create portmap server(UDP)");
                Console.WriteLine("   8:receive message");
                Console.WriteLine("   9:reply to pmap_set");
                Console.WriteLine("  10:reply to pmap_unset");
                Console.WriteLine("  11:reply to pmap_getport");
                Console.WriteLine("  12:close portmap server");
                Console.WriteLine("   B:back to Main menu");
                Console.WriteLine(" E/Q:Exit program");
                Console.WriteLine("");
                Console.Write("Input fuction number? : ");
                string code = new String(Console.ReadLine());
                if (code == "1")
                {
                    Console.Write("  port number? : ");
                    int port = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("== create portmap server ==");
                    serverPortmapTcp.Create("127.0.0.1", port);
                    Console.WriteLine(" Call : create_abort_channel : ret=0");
                }
                else if (code == "2")
                {
                    Console.WriteLine("  == Wait RPC ==");
                    msg = serverPortmapTcp.ReceiveMsg();
                    Console.WriteLine("    received Portmap(TCP).");
                    Console.WriteLine("      xid     = {0}", msg.xid);
                    Console.WriteLine("      type    = {0}", msg.msg_type);
                    Console.WriteLine("      prog    = {0}", msg.prog);
                    Console.WriteLine("      proc    = {0}", msg.proc);
                    Console.WriteLine("      vers    = {0}", msg.vers);
                    if (msg.proc == Pmap.PROC_SET)
                    {
                        Console.WriteLine("    == PMAPPROC_SET ==");
                        Pmap.MAPPING map = serverPortmapTcp.ReceiveSet();
                        Console.WriteLine("      prog    = {0}", map.prog);
                        Console.WriteLine("      vers    = {0}", map.vers);
                        Console.WriteLine("      prot    = {0}", map.prot);
                        Console.WriteLine("      port    = {0}", map.port);
                        Console.WriteLine("");
                    }
                    else if (msg.proc == Pmap.PROC_UNSET)
                    {
                        Console.WriteLine("    == PMAPPROC_UNSET ==");
                        Pmap.MAPPING map = serverPortmapTcp.ReceiveUnset();
                        Console.WriteLine("      prog    = {0}", map.prog);
                        Console.WriteLine("      vers    = {0}", map.vers);
                        Console.WriteLine("      prot    = {0}", map.prot);
                        Console.WriteLine("");
                    }
                    else if (msg.proc == Pmap.PROC_GETPORT)
                    {
                        Console.WriteLine("    == PMAPPROC_GETPORT ==");
                        Pmap.MAPPING map = serverPortmapTcp.ReceiveGetPort();
                        Console.WriteLine("      prog    = {0}", map.prog);
                        Console.WriteLine("      vers    = {0}", map.vers);
                        Console.WriteLine("      prot    = {0}", map.prot);
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine("    == clear buffer ==");
                        serverPortmapTcp.ClearArgs();
                    }
                }
                else if (code == "3")
                {
                    serverPortmapTcp.ReplySet(msg.xid, true);
                    Console.WriteLine("== reply to PMAPPROC_SET ==");
                }
                else if (code == "4")
                {
                    serverPortmapTcp.ReplyUnset(msg.xid, true);
                    Console.WriteLine("== reply to PMAPPROC_UNSET ==");
                }
                else if (code == "5")
                {
                    serverPortmapTcp.ReplyGetPort(msg.xid, 1);
                    Console.WriteLine("== reply to PMAPPROC_GETPORT ==");
                }
                else if (code == "6")
                {
                    serverPortmapTcp.Destroy();
                    Console.WriteLine("== close portmap server ==");
                }
                else if (code == "7")
                {
                    Console.Write("  port number? : ");
                    int port = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("== create portmap server ==");
                    serverPortmapUdp.Create("127.0.0.1", port);
                    Console.WriteLine(" Call : create_abort_channel : ret=0");
                }
                else if (code == "8")
                {
                    Console.WriteLine("  == Wait RPC ==");
                    msg = serverPortmapUdp.ReceiveMsg();
                    Console.WriteLine("    received Portmap(UDP).");
                    Console.WriteLine("      xid     = {0}", msg.xid);
                    Console.WriteLine("      proc    = {0}", msg.proc);
                    if (msg.proc == Pmap.PROC_SET)
                    {
                        Pmap.MAPPING map = serverPortmapUdp.ReceiveSet();
                        Console.WriteLine("== PMAPPROC_SET ==");
                    }
                    else if (msg.proc == Pmap.PROC_UNSET)
                    {
                        Pmap.MAPPING map = serverPortmapUdp.ReceiveUnset();
                        Console.WriteLine("== PMAPPROC_UNSET ==");
                    }
                    else if (msg.proc == Pmap.PROC_GETPORT)
                    {
                        Pmap.MAPPING map = serverPortmapUdp.ReceiveGetPort();
                        Console.WriteLine("== PMAPPROC_GETPORT ==");
                    }
                    else
                    {
                        serverPortmapUdp.ClearArgs();
                        Console.WriteLine("== clear_buffer ==");
                    }
                }
                else if (code == "9")
                {
                    serverPortmapUdp.ReplySet(msg.xid, true);
                    Console.WriteLine("== reply to PMAPPROC_SET ==");
                }
                else if (code == "10")
                {
                    serverPortmapUdp.ReplyUnset(msg.xid, true);
                    Console.WriteLine("== reply to PMAPPROC_UNSET ==");
                }
                else if (code == "11")
                {
                    serverPortmapUdp.ReplyGetPort(msg.xid, 1);
                    Console.WriteLine("== reply to PMAPPROC_GETPORT ==");
                }
                else if (code == "12")
                {
                    serverPortmapUdp.Destroy();
                    Console.WriteLine("== close portmap server ==");
                }
                else if ((code == "B") || (code == "b"))
                {
                    isLoop = false;
                }
                else if ((code == "Q") || (code == "q") || (code == "E") || (code == "e"))
                {
                    Console.WriteLine("== Exit program ==");
                    Environment.Exit(0);
                }
            }
        }
        public static void DemoConsole()
        {
            bool isLoop = true;
            ServerPortmapTcp serverPortmapTcp = new ServerPortmapTcp();
            ServerPortmapUdp serverPortmapUdp = new ServerPortmapUdp();
            ServerVxi11 serverVxi11 = new ServerVxi11();

            while (isLoop)
            {
                Console.WriteLine("Select Function");
                Console.WriteLine("   1:run demo server");
                Console.WriteLine("   2:shutdown demo server");
                Console.WriteLine("   B:back to Main menu");
                Console.WriteLine(" E/Q:Exit program");
                Console.WriteLine("");
                Console.Write("Input fuction number? : ");
                string code = new String(Console.ReadLine());
                if (code == "1")
                {
                    Console.WriteLine("== Run demo server ==");
                    serverPortmapTcp.Run("127.0.0.1", Pmap.PMAPPORT);
                    serverPortmapUdp.Run("127.0.0.1", Pmap.PMAPPORT);
                    serverVxi11.RunCoreChannel("127.0.0.1", 50240);
                    serverVxi11.RunAbortChannel("127.0.0.1", 50250);
                }
                else if (code == "2")
                {
                    serverPortmapTcp.Shutdown();
                    serverPortmapUdp.Shutdown();
                    serverVxi11.Shutdown();
                }
                else if ((code == "B") || (code == "b"))
                {
                    isLoop = false;
                }
                else if ((code == "Q") || (code == "q") || (code == "E") || (code == "e"))
                {
                    Console.WriteLine("== Exit program ==");
                    Environment.Exit(0);
                }
            }
        }
    }
}