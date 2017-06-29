using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace IgMessager
{

    public partial class frm_configure_SMTP : Form
    {

        private SmtpClient smtp_client;


        public frm_configure_SMTP(ref SmtpClient smtp_client)
        {
            InitializeComponent();
            portTextBox.KeyPress += new KeyPressEventHandler(portTextBox_KeyPress);

            this.smtp_client = smtp_client;

            if (smtp_client.Credentials!=null)
            {
                usernameTextBox.Text = ((System.Net.NetworkCredential)(smtp_client.Credentials)).UserName;
                passwordTextBox.Text = ((System.Net.NetworkCredential)(smtp_client.Credentials)).Password;
            }

            hostTextBox.Text = smtp_client.Host;
            portTextBox.Text = smtp_client.Port.ToString();
            sslCheckBox.Checked = smtp_client.EnableSsl;

        }


        private void portTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void hostTextBox_TextChanged(object sender, EventArgs e)
        {
            SomethingChanged();
        }

        private void SomethingChanged()
        {
            bool up_valid = true;
            up_valid = usernameTextBox.Text.Trim().Length > 0 && passwordTextBox.Text.Length > 0;

            bool valid = hostTextBox.Text.Trim().Length > 0 && portTextBox.Text.Trim().Length > 0 && up_valid;
            okButton.Enabled = valid;
        }

        private void portTextBox_TextChanged(object sender, EventArgs e)
        {
            SomethingChanged();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {

            smtp_client.Host = Hostname;
            smtp_client.Port = Port;
            smtp_client.Credentials = new NetworkCredential(Username, Password);
            smtp_client.EnableSsl = SSL;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
           
        }

        public string Hostname
        {
            get
            {
                return hostTextBox.Text.Trim();
            }
        }

        public int Port
        {
            get
            {
                return int.Parse(portTextBox.Text.Trim());
            }
        }


        public string Username
        {
            get
            {
                string val = usernameTextBox.Text.Trim();
                return string.IsNullOrEmpty(val) ? null : val;
            }
        }

        public string Password
        {
            get
            {
                string val = passwordTextBox.Text.Trim();
                return string.IsNullOrEmpty(val) ? null : val;
            }
        }

        public bool SSL
        {
            get
            {
                return sslCheckBox.Checked;
            }
        }

        private void ConfigureSMTPForm_Load(object sender, EventArgs e)
        {
            hostTextBox.Focus();
            SomethingChanged();
            hostTextBox.Focus();
        }

        private void authNoneRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SomethingChanged();
        }

        private void authMachineRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SomethingChanged();
        }

        private void authUsernameRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SomethingChanged();
        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {
            SomethingChanged();
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            SomethingChanged();
        }





    }
}
