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
using System.Net.Mail;
using System.Net.Mime;
using System.IO;

namespace IgMessager
{
    public partial class frm_IgMessanger : Form
    {
        private SmtpClient smtp_client;

        private string workingDirectory = string.Empty;

        private double contracts_signed_percent;
        private double contracts_paid_percent;

        public frm_IgMessanger()
        {
            InitializeComponent();
            this.smtp_client = new SmtpClient();
            
            smtp_client.Host = "smtp.gmail.com";
            smtp_client.Port = 587;
            smtp_client.UseDefaultCredentials = false;
            smtp_client.DeliveryMethod = SmtpDeliveryMethod.Network;
            
            smtp_client.EnableSsl = true;
            smtp_client.Timeout = 10000;

        }


        private void button1_Click(object sender, EventArgs e)
        {
           
            
           
            //string smtp_id = "dbis.pma@gmail.com";
            //string smtp_password = "hamster2015";





              frm_Mail_sender Mail_Form = new frm_Mail_sender(smtp_client,"Test user","test@test.com","Signed");
              Mail_Form.Show();
        }

        private void sMPTSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_configure_SMTP smpt_form = new frm_configure_SMTP(ref this.smtp_client);
            smpt_form.Show();

        }

        private void saveAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            

        }



                
    }
}
