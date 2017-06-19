namespace Client
{
    partial class Client
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Connect = new System.Windows.Forms.Button();
            this.label_Status = new System.Windows.Forms.Label();
            this.button_Send = new System.Windows.Forms.Button();
            this.textBox_Send = new System.Windows.Forms.TextBox();
            this.textBox_Receive = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Connect
            // 
            this.btn_Connect.BackColor = System.Drawing.Color.SlateGray;
            this.btn_Connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Connect.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Connect.ForeColor = System.Drawing.Color.White;
            this.btn_Connect.Location = new System.Drawing.Point(180, 108);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(85, 23);
            this.btn_Connect.TabIndex = 1;
            this.btn_Connect.Text = "CONNECT";
            this.btn_Connect.UseVisualStyleBackColor = false;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // label_Status
            // 
            this.label_Status.AutoSize = true;
            this.label_Status.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Status.Location = new System.Drawing.Point(12, 9);
            this.label_Status.Name = "label_Status";
            this.label_Status.Size = new System.Drawing.Size(57, 13);
            this.label_Status.TabIndex = 2;
            this.label_Status.Text = "OFF LINE";
            // 
            // button_Send
            // 
            this.button_Send.BackColor = System.Drawing.Color.SlateGray;
            this.button_Send.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Send.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Send.ForeColor = System.Drawing.Color.White;
            this.button_Send.Location = new System.Drawing.Point(180, 137);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(85, 23);
            this.button_Send.TabIndex = 3;
            this.button_Send.Text = "SEND";
            this.button_Send.UseVisualStyleBackColor = false;
            this.button_Send.Click += new System.EventHandler(this.button_Send_Click);
            // 
            // textBox_Send
            // 
            this.textBox_Send.Location = new System.Drawing.Point(80, 39);
            this.textBox_Send.Name = "textBox_Send";
            this.textBox_Send.Size = new System.Drawing.Size(185, 20);
            this.textBox_Send.TabIndex = 4;
            // 
            // textBox_Receive
            // 
            this.textBox_Receive.Location = new System.Drawing.Point(80, 65);
            this.textBox_Receive.Name = "textBox_Receive";
            this.textBox_Receive.Size = new System.Drawing.Size(185, 20);
            this.textBox_Receive.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Send";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Received";
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(277, 165);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Receive);
            this.Controls.Add(this.textBox_Send);
            this.Controls.Add(this.button_Send);
            this.Controls.Add(this.label_Status);
            this.Controls.Add(this.btn_Connect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Client";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Client_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.Label label_Status;
        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.TextBox textBox_Send;
        private System.Windows.Forms.TextBox textBox_Receive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

