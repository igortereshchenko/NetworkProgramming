using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Server
{
    public partial class Server : Form
    {
        TcpListener tcp_Server;
        TcpClient tcp_Client;
        Thread thr_Server;
        NetworkStream ns_Stream;
        BinaryReader br_Reader;
        BinaryWriter bw_Writer;
        delegate void del_ConnectManager(String Operation, Object Data);
        Boolean b_Connected = false;
        Boolean b_ServerStarted = false;
        int i_Method = 2;
        public Server()
        {
            InitializeComponent();
        }

        void rv_ServerStartListening(object sender)
        {
            b_ServerStarted = true;
            tcp_Server = new TcpListener(IPAddress.Parse("127.0.0.1"), 3333);
            tcp_Server.Start();
            tcp_Client = tcp_Server.AcceptTcpClient();
            ns_Stream = new NetworkStream(tcp_Client.Client);
            del_ConnectManager ndel_CS = new del_ConnectManager(v_ConnectManager);
            this.Invoke(ndel_CS, new object[] {"Connection", true});
            b_Connected = true;
            while (b_Connected == true)
            {
                if (tcp_Client.Available > 0)
                {
                    if (i_Method == 1)
                    {
                        Byte[] ba_Receive = new Byte[tcp_Client.Available];
                        ns_Stream = tcp_Client.GetStream();
                        ns_Stream.Read(ba_Receive, 0, tcp_Client.Available);
                        String s_Receive = Encoding.Default.GetString(ba_Receive);
                        this.Invoke(ndel_CS, new object[] { "ReceiveData", s_Receive });
                    }
                    if (i_Method == 2)
                    {
                        br_Reader = new BinaryReader(ns_Stream);
                        Byte[] bm_Size = br_Reader.ReadBytes(16);
                        Int32 i_Size = Convert.ToInt32(Encoding.UTF8.GetString(bm_Size).Split(new String[] { ">>" }, StringSplitOptions.RemoveEmptyEntries)[1]);
                        Byte[] bm_Data = br_Reader.ReadBytes(i_Size);
                        textBox_Receive.Text = Encoding.Default.GetString(bm_Data);
                    }
                }
                Thread.Sleep(5);
            }
        }

        private void btn_START_Click(object sender, EventArgs e)
        {
            btn_START.Enabled = false;
            thr_Server = new Thread(new ParameterizedThreadStart(rv_ServerStartListening));
            thr_Server.Start();
        }

        void v_ConnectManager(String s_Operation, Object o_Data)
        {
            switch (s_Operation)
            {
                case "Connection" :label_Status.Text = "CONNECTED"; label_Status.ForeColor = Color.Green;  button_Send.Enabled = true; break;
                case "ReceiveData": textBox_Receive.Text = (String)o_Data; break;
            }
        }

        private void button_Send_Click(object sender, EventArgs e)
        {
            ns_Stream = tcp_Client.GetStream();
            if (i_Method == 1)
            {
                Byte[] ba_Send = Encoding.Default.GetBytes(textBox_Send.Text);
                ns_Stream.Write(ba_Send, 0, ba_Send.Length);
            }
            if (i_Method == 2)
            {
                Byte[] bm_Data = Encoding.Default.GetBytes(textBox_Send.Text);
                Int32 li_I = bm_Data.Length;
                Int32 li_length = 10 - li_I.ToString().Length;
                String ls_Space = String.Empty;
                for (int i = 0; i < li_length; i++)
                {
                    ls_Space += " ";
                }
                String ls_Size = "size>>" + bm_Data.Length + ls_Space;
                Byte[] bm_Size = Encoding.Default.GetBytes(ls_Size);
                bw_Writer = new BinaryWriter(ns_Stream);
                bw_Writer.Write(bm_Size);
                bw_Writer.Write(bm_Data);
            }
        }

        private void Server_Load(object sender, EventArgs e)
        {
            textBox_Receive.Enabled = false;
            button_Send.Enabled = false;
        }

        private void Server_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (b_ServerStarted == true)
            {
                tcp_Server.Stop();
                thr_Server.Abort();
            }
        }
    }
}
