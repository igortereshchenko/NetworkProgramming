using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PresentationControls;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace IgMessager
{
    public partial class frm_Mail_sender : Form
    {

        private SmtpClient smtp_client;
        private String user_name;
        private String user_message;

        public frm_Mail_sender()
        {
            InitializeComponent();
        }


        public frm_Mail_sender(SmtpClient smtp_client, String user_name,String user_email,String user_message)
        {
            InitializeComponent();
            this.smtp_client = smtp_client;
            this.user_name = user_name;
            this.user_message = user_message;

            this.cmb_mail_from.Text = user_email;

        }


        private void Mail_by_SMPT_Load(object sender, EventArgs e)
        {
            this.dtPicker.CustomFormat = "dd.MM.yyyy";
            this.dtPicker.Format = DateTimePickerFormat.Custom; ;
            this.dtPicker.Value = DateTime.Now;

            this.txt_mail_subject.Text += " от " + this.user_name;
            this.txt_mail_body.Text = this.user_message;


            DataTable dt_client_mail = new DataTable("CLIENT MAIL");
            dt_client_mail.Columns.AddRange(
                new DataColumn[]
                {
                    new DataColumn("Id", typeof(int)),
                    new DataColumn("mail", typeof(string)),                    
                });

            dt_client_mail.Rows.Add(1, "tereshchenko.igor@gmail.com");
            dt_client_mail.Rows.Add(2, "saler.igor@gmail.com");


            this.chcmb_mail_to.DataSource = new ListSelectionWrapper<DataRow>(dt_client_mail.Rows, "mail");

            this.chcmb_mail_to.DisplayMemberSingleItem = "Name";
            this.chcmb_mail_to.DisplayMember = "NameConcatenated";
            this.chcmb_mail_to.ValueMember = "Selected";
        }

        private void btn_sourse_file_Click(object sender, EventArgs e)
        {
            
            if (this.openFileDlg.ShowDialog() == DialogResult.OK)
                this.txt_attached_file.Text = this.openFileDlg.FileName;
        }

        private void btn_mail_sent_Click(object sender, EventArgs e)
        {

            try
            {

               MailMessage email = new MailMessage();
               email.Body = this.txt_mail_body.Text;
               email.Subject = this.txt_mail_subject.Text;
               email.To.Add(this.chcmb_mail_to.Text);
               email.From = new MailAddress(this.cmb_mail_from.Text);

               if (this.txt_attached_file.Text != "")
                    if (!File.Exists(this.txt_attached_file.Text))
                    {

                        MessageBox.Show("Проверте файл во вложении", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txt_attached_file.Focus();
                        return;
                    }
                    else
                        email.Attachments.Add(new Attachment(this.txt_attached_file.Text));

                smtp_client.Send(email);

                MessageBox.Show("Почта успешно отправлена", "Отправка почты", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                
            }
            catch (Exception exception)
            {
                MessageBox.Show("Почта не отправлена", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_mail_received_Click(object sender, EventArgs e)
        {

        }
    }
}
