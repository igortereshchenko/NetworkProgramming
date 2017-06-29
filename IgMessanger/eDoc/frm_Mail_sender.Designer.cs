namespace IgMessager
{
    partial class frm_Mail_sender
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Mail_sender));
            PresentationControls.CheckBoxProperties checkBoxProperties1 = new PresentationControls.CheckBoxProperties();
            this.lbl_from = new System.Windows.Forms.Label();
            this.lbl_to = new System.Windows.Forms.Label();
            this.cmb_mail_from = new System.Windows.Forms.ComboBox();
            this.dtPicker = new System.Windows.Forms.DateTimePicker();
            this.btn_mail_received = new System.Windows.Forms.Button();
            this.lbl_topic = new System.Windows.Forms.Label();
            this.txt_mail_subject = new System.Windows.Forms.TextBox();
            this.txt_mail_body = new System.Windows.Forms.TextBox();
            this.openFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.txt_attached_file = new System.Windows.Forms.TextBox();
            this.btn_attached_file = new System.Windows.Forms.Button();
            this.btn_mail_sent = new System.Windows.Forms.Button();
            this.lbl_source_file = new System.Windows.Forms.Label();
            this.chcmb_mail_to = new PresentationControls.CheckBoxComboBox();
            this.SuspendLayout();
            // 
            // lbl_from
            // 
            this.lbl_from.AutoSize = true;
            this.lbl_from.Location = new System.Drawing.Point(12, 27);
            this.lbl_from.Name = "lbl_from";
            this.lbl_from.Size = new System.Drawing.Size(20, 13);
            this.lbl_from.TabIndex = 1;
            this.lbl_from.Text = "От";
            // 
            // lbl_to
            // 
            this.lbl_to.AutoSize = true;
            this.lbl_to.Location = new System.Drawing.Point(12, 54);
            this.lbl_to.Name = "lbl_to";
            this.lbl_to.Size = new System.Drawing.Size(33, 13);
            this.lbl_to.TabIndex = 2;
            this.lbl_to.Text = "Кому";
            // 
            // cmb_mail_from
            // 
            this.cmb_mail_from.Enabled = false;
            this.cmb_mail_from.FormattingEnabled = true;
            this.cmb_mail_from.Location = new System.Drawing.Point(53, 24);
            this.cmb_mail_from.Name = "cmb_mail_from";
            this.cmb_mail_from.Size = new System.Drawing.Size(321, 21);
            this.cmb_mail_from.TabIndex = 3;
            // 
            // dtPicker
            // 
            this.dtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPicker.Location = new System.Drawing.Point(380, 24);
            this.dtPicker.Name = "dtPicker";
            this.dtPicker.Size = new System.Drawing.Size(88, 20);
            this.dtPicker.TabIndex = 5;
            // 
            // btn_mail_received
            // 
            this.btn_mail_received.Location = new System.Drawing.Point(380, 49);
            this.btn_mail_received.Name = "btn_mail_received";
            this.btn_mail_received.Size = new System.Drawing.Size(88, 23);
            this.btn_mail_received.TabIndex = 6;
            this.btn_mail_received.Text = "Получено";
            this.btn_mail_received.UseVisualStyleBackColor = true;
            this.btn_mail_received.Click += new System.EventHandler(this.btn_mail_received_Click);
            // 
            // lbl_topic
            // 
            this.lbl_topic.AutoSize = true;
            this.lbl_topic.Location = new System.Drawing.Point(12, 81);
            this.lbl_topic.Name = "lbl_topic";
            this.lbl_topic.Size = new System.Drawing.Size(34, 13);
            this.lbl_topic.TabIndex = 7;
            this.lbl_topic.Text = "Тема";
            // 
            // txt_mail_subject
            // 
            this.txt_mail_subject.Location = new System.Drawing.Point(53, 78);
            this.txt_mail_subject.Name = "txt_mail_subject";
            this.txt_mail_subject.Size = new System.Drawing.Size(415, 20);
            this.txt_mail_subject.TabIndex = 8;
            // 
            // txt_mail_body
            // 
            this.txt_mail_body.Location = new System.Drawing.Point(15, 104);
            this.txt_mail_body.Multiline = true;
            this.txt_mail_body.Name = "txt_mail_body";
            this.txt_mail_body.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_mail_body.Size = new System.Drawing.Size(453, 221);
            this.txt_mail_body.TabIndex = 10;
            // 
            // openFileDlg
            // 
            this.openFileDlg.Filter = "PDF files (*.pdf)|*.pdf";
            // 
            // txt_attached_file
            // 
            this.txt_attached_file.Location = new System.Drawing.Point(53, 334);
            this.txt_attached_file.Name = "txt_attached_file";
            this.txt_attached_file.Size = new System.Drawing.Size(236, 20);
            this.txt_attached_file.TabIndex = 11;
            // 
            // btn_attached_file
            // 
            this.btn_attached_file.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_attached_file.BackgroundImage")));
            this.btn_attached_file.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_attached_file.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_attached_file.FlatAppearance.BorderSize = 0;
            this.btn_attached_file.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_attached_file.Location = new System.Drawing.Point(286, 331);
            this.btn_attached_file.Name = "btn_attached_file";
            this.btn_attached_file.Size = new System.Drawing.Size(30, 24);
            this.btn_attached_file.TabIndex = 12;
            this.btn_attached_file.UseVisualStyleBackColor = true;
            this.btn_attached_file.Click += new System.EventHandler(this.btn_sourse_file_Click);
            // 
            // btn_mail_sent
            // 
            this.btn_mail_sent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_mail_sent.Location = new System.Drawing.Point(380, 332);
            this.btn_mail_sent.Name = "btn_mail_sent";
            this.btn_mail_sent.Size = new System.Drawing.Size(88, 23);
            this.btn_mail_sent.TabIndex = 13;
            this.btn_mail_sent.Text = "Отправить";
            this.btn_mail_sent.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_mail_sent.UseVisualStyleBackColor = true;
            this.btn_mail_sent.Click += new System.EventHandler(this.btn_mail_sent_Click);
            // 
            // lbl_source_file
            // 
            this.lbl_source_file.AutoSize = true;
            this.lbl_source_file.Location = new System.Drawing.Point(12, 337);
            this.lbl_source_file.Name = "lbl_source_file";
            this.lbl_source_file.Size = new System.Drawing.Size(36, 13);
            this.lbl_source_file.TabIndex = 14;
            this.lbl_source_file.Text = "Файл";
            // 
            // chcmb_mail_to
            // 
            checkBoxProperties1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chcmb_mail_to.CheckBoxProperties = checkBoxProperties1;
            this.chcmb_mail_to.DisplayMemberSingleItem = "";
            this.chcmb_mail_to.FormattingEnabled = true;
            this.chcmb_mail_to.Location = new System.Drawing.Point(53, 51);
            this.chcmb_mail_to.Name = "chcmb_mail_to";
            this.chcmb_mail_to.Size = new System.Drawing.Size(321, 21);
            this.chcmb_mail_to.TabIndex = 9;
            // 
            // frm_Mail_sender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 366);
            this.Controls.Add(this.lbl_source_file);
            this.Controls.Add(this.btn_mail_sent);
            this.Controls.Add(this.btn_attached_file);
            this.Controls.Add(this.txt_attached_file);
            this.Controls.Add(this.txt_mail_body);
            this.Controls.Add(this.chcmb_mail_to);
            this.Controls.Add(this.txt_mail_subject);
            this.Controls.Add(this.lbl_topic);
            this.Controls.Add(this.btn_mail_received);
            this.Controls.Add(this.dtPicker);
            this.Controls.Add(this.cmb_mail_from);
            this.Controls.Add(this.lbl_to);
            this.Controls.Add(this.lbl_from);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Mail_sender";
            this.Text = " Отправка почты";
            this.Load += new System.EventHandler(this.Mail_by_SMPT_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_from;
        private System.Windows.Forms.Label lbl_to;
        private System.Windows.Forms.ComboBox cmb_mail_from;
        private System.Windows.Forms.DateTimePicker dtPicker;
        private System.Windows.Forms.Button btn_mail_received;
        private System.Windows.Forms.Label lbl_topic;
        private System.Windows.Forms.TextBox txt_mail_subject;
        private PresentationControls.CheckBoxComboBox chcmb_mail_to;
        private System.Windows.Forms.TextBox txt_mail_body;
        private System.Windows.Forms.OpenFileDialog openFileDlg;
        private System.Windows.Forms.TextBox txt_attached_file;
        private System.Windows.Forms.Button btn_attached_file;
        private System.Windows.Forms.Button btn_mail_sent;
        private System.Windows.Forms.Label lbl_source_file;
    }
}