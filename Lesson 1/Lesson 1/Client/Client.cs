using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Client
{
    public partial class Client : Form
    {
        TcpClient tcp_Client;
        NetworkStream ns_Stream;
        BinaryReader br_Reader;
        BinaryWriter bw_Writer;
        Boolean b_Connected = false;
        Timer t_CheckData = new Timer();
        Int32 i_Method = 2;
        public Client()
        {
            InitializeComponent();
            button_Send.Enabled = false;
            textBox_Receive.Enabled = false;
            
            t_CheckData.Interval = 100;
            t_CheckData.Tick += T_CheckData_Tick;
        }

        private void T_CheckData_Tick(object sender, EventArgs e)
        {
            if (b_Connected == true)
            {
                if (tcp_Client.Available > 0)
                {
                    if (i_Method == 1)
                    {
                        Byte[] ba_Receive = new Byte[tcp_Client.Available];
                        ns_Stream = tcp_Client.GetStream();
                        ns_Stream.Read(ba_Receive, 0, tcp_Client.Available);
                        String s_Receive = Encoding.Default.GetString(ba_Receive);
                        textBox_Receive.Text = s_Receive;
                        ns_Stream.Flush();
                    }

                    if (i_Method == 2)
                    {
                        br_Reader = new BinaryReader(ns_Stream);
                        Byte[] bm_Size = br_Reader.ReadBytes(16);
                        Int32 i_Size = Convert.ToInt32(Encoding.Default.GetString(bm_Size).Split(new String[] { ">>" }, StringSplitOptions.RemoveEmptyEntries)[1]);
                        Byte[] bm_Data = br_Reader.ReadBytes(i_Size);
                        textBox_Receive.Text = Encoding.Default.GetString(bm_Data);
                    }
                }
            }
        }

       

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            btn_Connect.Enabled = false;
            tcp_Client = new TcpClient();
            tcp_Client.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3333));
            if (tcp_Client.Connected == true)
            {
                label_Status.Text = "CONNECTED"; label_Status.ForeColor = Color.Green;
                button_Send.Enabled = true;
                b_Connected = true;
                t_CheckData.Start();
            }
            else
            {
                label_Status.Text = "NOT CONNECTED"; label_Status.ForeColor = Color.Red;
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

        private void Client_Load(object sender, EventArgs e)
        {

        }
    }
}
