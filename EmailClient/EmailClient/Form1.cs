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

        bool hasAttachment = false;
        string[] aryAttachments;

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

            MailMessage message = new MailMessage(emailFrom, emailTo);
            message.BodyEncoding = Encoding.UTF8;
            message.Headers.Add("Reply-To", emailFrom);
            message.Headers.Add("X-Organization", "Asemco's Mail");

            if (hasAttachment)
            {
                for (int i = 0; i < aryAttachments.Length; i++)
                {
                    Attachment fileAttach = new Attachment(aryAttachments[i]);
                    message.Attachments.Add(fileAttach);
                }
            }

            smtpServer.SendCompleted += new SendCompletedEventHandler(DoSendCompleted);
            string userState = " - Asemco's Mail";
            try
            {
                smtpServer.SendAsync(message, userState);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DoSendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            string token = e.UserState.ToString();

            if (e.Cancelled)
                MessageBox.Show("Sending Email Cancelled: " + token);
            if (e.Error != null)
                MessageBox.Show(token + e.Error.ToString());
            else
                MessageBox.Show("You E-mail has been sent successfully!");
        }

        private void btnEmailAttach_Click(object sender, EventArgs e)
        {
            txtEmailAttach.Text = "";

            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.Title = "Attach Files";
            openFileDialog.Filter = "PDFs|*.pdf|Text Files|*.txt|All Files|*.*";

            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.Cancel)
            {
                hasAttachment = false;
                return;
            }

            try
            {
                int numOfFiles = openFileDialog.FileNames.Length;
                int counter = 0;

                aryAttachments = new string[numOfFiles];

                foreach (string singleFile in openFileDialog.FileNames)
                {
                    aryAttachments[counter] = singleFile;
                    txtEmailAttach.Text += singleFile + " ";
                    counter++;
                }

                hasAttachment = true;
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
