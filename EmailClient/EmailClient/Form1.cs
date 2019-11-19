using System;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEmailSend_Click(object sender, EventArgs e)
        {
            sendEmail();
        }

        private void sendEmail()
        {
            string emailTo = txtEmailTo.Text.Trim();
            string emailFrom = txtEmailFrom.Text.Trim();
            string emailSubject = txtEmailSubject.Text.Trim();
            string emailMessage = txtEmailMessage.Text.Trim();
            SmtpClient smtpServer = new SmtpClient();
            smtpServer.Host = "mail.gmx.com";
            smtpServer.Timeout = 15;
            smtpServer.Port = 25;
            smtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;

            string username = PrivateVars.Email.Username;
            string password = PrivateVars.Email.Password;
            smtpServer.Credentials = new NetworkCredential(username, password);

        }
    }
}
