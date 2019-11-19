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
using System.Net.Security;

namespace EmailClient
{
    public partial class Form1 : Form
    {

        bool hasAttachment = false;
        string[] aryAttachments;
        SslStream networkStream;
        StreamReader readStream;
        string username = PrivateVars.Email.Username;
        string password = PrivateVars.Email.Password;

        public Form1()
        {
            InitializeComponent();
        }
        
        private string PopCommand(SslStream networkStream, string serverCommand)
        {
            try
            {
                serverCommand = serverCommand + "\r\n";
                Byte[] serverBytes = Encoding.ASCII.GetBytes(serverCommand);

                StreamReader readStreamBytes;
                string serverResponse;

                networkStream.Write(serverBytes, 0, serverBytes.Length);
                readStreamBytes = new StreamReader(networkStream);
                serverResponse = readStreamBytes.ReadLine();

                return serverResponse;
            } catch (Exception ex)
            {
                return ex.Message;
            }
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
            smtpServer.Host = PrivateVars.Email.SMTPHost;
            smtpServer.Timeout = 15;
            smtpServer.Port = 25;
            smtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;


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

        private void btnConnect_Click(object sender, EventArgs e)
        {
            TcpClient popServer = new TcpClient();
            
            string popHost = PrivateVars.Email.POP3Host;

            try
            {
                popServer.Connect(popHost, 995);

                networkStream = new SslStream(popServer.GetStream());
                networkStream.AuthenticateAsClient(PrivateVars.Email.POP3Host);
                readStream = new StreamReader(networkStream);

                string returnString = readStream.ReadLine() + "\r\n";
                txtServerResponse.Text = returnString;

                txtServerResponse.Text += PopCommand(networkStream, "USER " + username) + "\r\n";
                string result = PopCommand(networkStream, "PASS " + password) + "\r\n";
                if (result.Substring(0, 4) == "-ERR")
                    txtServerResponse.Text = "Invalid Password";
                txtServerResponse.Text += result;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void QuitServer()
        {
            try
            {
                string serverResponse = PopCommand(networkStream, "QUIT") + "\r\n";
                MessageBox.Show(serverResponse);
            } catch (Exception ex)
            {
                MessageBox.Show("Could not quit: " +ex.Message);
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            QuitServer();
        }
    }
}
