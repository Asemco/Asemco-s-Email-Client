namespace EmailClient
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtEmailTo = new System.Windows.Forms.TextBox();
            this.txtEmailFrom = new System.Windows.Forms.TextBox();
            this.txtEmailSubject = new System.Windows.Forms.TextBox();
            this.btnEmailSend = new System.Windows.Forms.Button();
            this.txtEmailMessage = new System.Windows.Forms.RichTextBox();
            this.lblEmailMessage = new System.Windows.Forms.Label();
            this.lblEmailSubject = new System.Windows.Forms.Label();
            this.lblEmailFrom = new System.Windows.Forms.Label();
            this.lblEmailTo = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnEmailAttach = new System.Windows.Forms.Button();
            this.txtEmailAttach = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.emailList = new System.Windows.Forms.ListBox();
            this.txtServerResponse = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblServerResponse = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1616, 963);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtEmailAttach);
            this.tabPage1.Controls.Add(this.btnEmailAttach);
            this.tabPage1.Controls.Add(this.txtEmailTo);
            this.tabPage1.Controls.Add(this.txtEmailFrom);
            this.tabPage1.Controls.Add(this.txtEmailSubject);
            this.tabPage1.Controls.Add(this.btnEmailSend);
            this.tabPage1.Controls.Add(this.txtEmailMessage);
            this.tabPage1.Controls.Add(this.lblEmailMessage);
            this.tabPage1.Controls.Add(this.lblEmailSubject);
            this.tabPage1.Controls.Add(this.lblEmailFrom);
            this.tabPage1.Controls.Add(this.lblEmailTo);
            this.tabPage1.Location = new System.Drawing.Point(8, 39);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1600, 916);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Send Emails";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtEmailTo
            // 
            this.txtEmailTo.Location = new System.Drawing.Point(185, 73);
            this.txtEmailTo.Name = "txtEmailTo";
            this.txtEmailTo.Size = new System.Drawing.Size(717, 31);
            this.txtEmailTo.TabIndex = 8;
            // 
            // txtEmailFrom
            // 
            this.txtEmailFrom.Location = new System.Drawing.Point(185, 184);
            this.txtEmailFrom.Name = "txtEmailFrom";
            this.txtEmailFrom.Size = new System.Drawing.Size(717, 31);
            this.txtEmailFrom.TabIndex = 7;
            // 
            // txtEmailSubject
            // 
            this.txtEmailSubject.Location = new System.Drawing.Point(185, 282);
            this.txtEmailSubject.Name = "txtEmailSubject";
            this.txtEmailSubject.Size = new System.Drawing.Size(717, 31);
            this.txtEmailSubject.TabIndex = 6;
            // 
            // btnEmailSend
            // 
            this.btnEmailSend.Location = new System.Drawing.Point(320, 794);
            this.btnEmailSend.Name = "btnEmailSend";
            this.btnEmailSend.Size = new System.Drawing.Size(312, 79);
            this.btnEmailSend.TabIndex = 5;
            this.btnEmailSend.Text = "Send Email";
            this.btnEmailSend.UseVisualStyleBackColor = true;
            this.btnEmailSend.Click += new System.EventHandler(this.btnEmailSend_Click);
            // 
            // txtEmailMessage
            // 
            this.txtEmailMessage.Location = new System.Drawing.Point(185, 458);
            this.txtEmailMessage.Name = "txtEmailMessage";
            this.txtEmailMessage.Size = new System.Drawing.Size(717, 305);
            this.txtEmailMessage.TabIndex = 4;
            this.txtEmailMessage.Text = "";
            // 
            // lblEmailMessage
            // 
            this.lblEmailMessage.AutoSize = true;
            this.lblEmailMessage.Location = new System.Drawing.Point(49, 458);
            this.lblEmailMessage.Name = "lblEmailMessage";
            this.lblEmailMessage.Size = new System.Drawing.Size(106, 25);
            this.lblEmailMessage.TabIndex = 3;
            this.lblEmailMessage.Text = "Message:";
            // 
            // lblEmailSubject
            // 
            this.lblEmailSubject.AutoSize = true;
            this.lblEmailSubject.Location = new System.Drawing.Point(49, 289);
            this.lblEmailSubject.Name = "lblEmailSubject";
            this.lblEmailSubject.Size = new System.Drawing.Size(90, 25);
            this.lblEmailSubject.TabIndex = 2;
            this.lblEmailSubject.Text = "Subject:";
            // 
            // lblEmailFrom
            // 
            this.lblEmailFrom.AutoSize = true;
            this.lblEmailFrom.Location = new System.Drawing.Point(52, 184);
            this.lblEmailFrom.Name = "lblEmailFrom";
            this.lblEmailFrom.Size = new System.Drawing.Size(67, 25);
            this.lblEmailFrom.TabIndex = 1;
            this.lblEmailFrom.Text = "From:";
            // 
            // lblEmailTo
            // 
            this.lblEmailTo.AutoSize = true;
            this.lblEmailTo.Location = new System.Drawing.Point(52, 73);
            this.lblEmailTo.Name = "lblEmailTo";
            this.lblEmailTo.Size = new System.Drawing.Size(43, 25);
            this.lblEmailTo.TabIndex = 0;
            this.lblEmailTo.Text = "To:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.flowLayoutPanel2);
            this.tabPage2.Controls.Add(this.flowLayoutPanel1);
            this.tabPage2.Controls.Add(this.txtEmail);
            this.tabPage2.Controls.Add(this.emailList);
            this.tabPage2.Location = new System.Drawing.Point(8, 39);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1600, 916);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Receive Emails";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnEmailAttach
            // 
            this.btnEmailAttach.Location = new System.Drawing.Point(30, 364);
            this.btnEmailAttach.Name = "btnEmailAttach";
            this.btnEmailAttach.Size = new System.Drawing.Size(125, 44);
            this.btnEmailAttach.TabIndex = 9;
            this.btnEmailAttach.Text = "Attach";
            this.btnEmailAttach.UseVisualStyleBackColor = true;
            this.btnEmailAttach.Click += new System.EventHandler(this.btnEmailAttach_Click);
            // 
            // txtEmailAttach
            // 
            this.txtEmailAttach.Location = new System.Drawing.Point(185, 371);
            this.txtEmailAttach.Name = "txtEmailAttach";
            this.txtEmailAttach.Size = new System.Drawing.Size(717, 31);
            this.txtEmailAttach.TabIndex = 10;
            // 
            // btnConnect
            // 
            this.btnConnect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConnect.Location = new System.Drawing.Point(3, 3);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(525, 67);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.Location = new System.Drawing.Point(534, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(525, 67);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnQuit
            // 
            this.btnQuit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnQuit.Location = new System.Drawing.Point(1065, 3);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(525, 67);
            this.btnQuit.TabIndex = 2;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // emailList
            // 
            this.emailList.FormattingEnabled = true;
            this.emailList.ItemHeight = 25;
            this.emailList.Location = new System.Drawing.Point(6, 85);
            this.emailList.Name = "emailList";
            this.emailList.Size = new System.Drawing.Size(755, 779);
            this.emailList.TabIndex = 3;
            // 
            // txtServerResponse
            // 
            this.txtServerResponse.Location = new System.Drawing.Point(187, 3);
            this.txtServerResponse.Name = "txtServerResponse";
            this.txtServerResponse.ReadOnly = true;
            this.txtServerResponse.Size = new System.Drawing.Size(1403, 31);
            this.txtServerResponse.TabIndex = 4;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(767, 85);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEmail.Size = new System.Drawing.Size(830, 779);
            this.txtEmail.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.btnConnect);
            this.flowLayoutPanel1.Controls.Add(this.btnDelete);
            this.flowLayoutPanel1.Controls.Add(this.btnQuit);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1594, 73);
            this.flowLayoutPanel1.TabIndex = 7;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.lblServerResponse);
            this.flowLayoutPanel2.Controls.Add(this.txtServerResponse);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 876);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1594, 37);
            this.flowLayoutPanel2.TabIndex = 8;
            this.flowLayoutPanel2.WrapContents = false;
            // 
            // lblServerResponse
            // 
            this.lblServerResponse.AutoSize = true;
            this.lblServerResponse.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblServerResponse.Location = new System.Drawing.Point(3, 0);
            this.lblServerResponse.Name = "lblServerResponse";
            this.lblServerResponse.Size = new System.Drawing.Size(178, 37);
            this.lblServerResponse.TabIndex = 5;
            this.lblServerResponse.Text = "Server Response";
            this.lblServerResponse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1616, 963);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblEmailMessage;
        private System.Windows.Forms.Label lblEmailSubject;
        private System.Windows.Forms.Label lblEmailFrom;
        private System.Windows.Forms.Label lblEmailTo;
        private System.Windows.Forms.RichTextBox txtEmailMessage;
        private System.Windows.Forms.TextBox txtEmailTo;
        private System.Windows.Forms.TextBox txtEmailFrom;
        private System.Windows.Forms.TextBox txtEmailSubject;
        private System.Windows.Forms.Button btnEmailSend;
        private System.Windows.Forms.TextBox txtEmailAttach;
        private System.Windows.Forms.Button btnEmailAttach;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label lblServerResponse;
        private System.Windows.Forms.TextBox txtServerResponse;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.ListBox emailList;
    }
}

