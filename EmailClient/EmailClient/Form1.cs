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

        private void btnEmailSend_Click(object sender, EventArgs e)
        {
            sendEmail();
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

                // User Authentication

                txtServerResponse.Text += PopCommand(networkStream, "USER " + username) + "\r\n";
                string result = PopCommand(networkStream, "PASS " + password) + "\r\n";

                // Quit if error on authentication.
                if (result.Substring(0, 4) == "-ERR")
                {
                    txtServerResponse.Text = "Invalid Password";
                    txtServerResponse.Text += result;
                    return;
                }

                // Get Email Stats (Num of emails, size, list)
                
                string serverStats = GetMailStats();
                txtServerResponse.Text += serverStats + "\r\n";

                string[] aryStats = new string[2];
                aryStats = serverStats.Split(' ');
                txtServerResponse.Text += "Number of Emails: " + aryStats[1] + "\r\n";

                if (int.Parse(aryStats[1]) > 0)
                {
                    GetMailList(int.Parse(aryStats[1]));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            QuitServer();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int i = emailList.SelectedIndex + 1;

            try
            {
                string serverResponse;
                serverResponse = PopCommand(networkStream, "DELE " + i.ToString());
                txtServerResponse.Text += serverResponse + "\r\n";
                emailList.Items[emailList.SelectedIndex] += " | Marked for Deletion";
                

                txtEmail.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while deleting: " + ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            string serverResponse = PopCommand(networkStream, "RSET");
            txtServerResponse.Text += serverResponse + "\r\n";
            emailList.Items[emailList.SelectedIndex] = (emailList.Items[emailList.SelectedIndex] as string).Replace("| Marked for Deletion", "");
        }

        private void emailList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string indexNumber;
            string strRetrieve;

            if ((sender as ListBox).Text == "" || (sender as ListBox).Text.Contains("Marked for Deletion"))
                return;

            try
            {
                indexNumber = (emailList.SelectedIndex + 1).ToString();
                strRetrieve = "RETR " + indexNumber + "\r\n";
                if (indexNumber != "0")
                    GetEmail(strRetrieve);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message);
            }
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
            smtpServer.Port = 587;
            smtpServer.EnableSsl = true;
            smtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;

            smtpServer.Credentials = new NetworkCredential(username, password);

            MailMessage message = new MailMessage(emailFrom, emailTo);
            message.BodyEncoding = Encoding.UTF8;
            message.Headers.Add("Reply-To", emailFrom);
            message.Headers.Add("X-Organization", "Asemco's Mail");

            message.Body = emailMessage;
            message.Subject = emailSubject;

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
            }
            catch (Exception ex)
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
                MessageBox.Show("Your E-mail has been sent successfully!");
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
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private string GetMailStats()
        {
            string statsResponse = PopCommand(networkStream, "STAT");
            return statsResponse;
        }

        private void GetMailList(int numOfEmails)
        {
            emailList.Items.Clear();
            string listResponse;

            for (int i = 1; i <= numOfEmails; i++)
            {
                listResponse = PopCommand(networkStream, "LIST " + i.ToString());
                emailList.Items.Add(listResponse);
            }
            
        }

        private void QuitServer()
        {
            try
            {
                string serverResponse = PopCommand(networkStream, "QUIT") + "\r\n";
                txtEmail.Text = "";
                emailList.Items.Clear();
                MessageBox.Show(serverResponse);
            } catch (Exception ex)
            {
                MessageBox.Show("Could not quit: " +ex.Message);
            }
        }

        private void GetEmail(string serverCommand)
        {
            StreamReader readStream;
            string textLine = "";

            try
            {
                // Prepare the command for the stream
                txtServerResponse.Text += "Outgoing: " + serverCommand;
                Byte[] serverBytes = Encoding.ASCII.GetBytes(serverCommand);

                // Send the command
                networkStream.Write(serverBytes, 0, serverBytes.Length);

                // Open the read strem
                // Also, Knock out the OK reply.
                readStream = new StreamReader(networkStream);
                
                // USE FOR DEBUGGING
                //MessageBox.Show(readStream.ReadLine());

                // The end of the stream is a ".", so we read lines until we reach the "."
                string input;
                while ((input = readStream.ReadLine()) != ".")
                {
                    // If we reach an empty line, we add an extra set of EoL characters to process the email a little easier
                    if (input.Length == 0)
                    {
                        textLine += "\r\n\r\n";
                        continue;
                    }

                    // If we encounter an error attempting to get the email body, we print it and return.
                    if (input.Length >= 4 && input.Substring(0, 4) == "-ERR")
                    {
                        MessageBox.Show("An POP3 related error occurred while retriving the email: " + input);
                        return;
                    }

                    textLine += input + "\r\n";
                }

                // Seperate the Boys from the Men
                int lineFeeds = textLine.IndexOf("\r\n\r\n");

                // Boys
                string emailHeader;
                // Men
                string emailBody;

                // This shouldn't run if there's an error, or for some read reason, we don't properly receive email content.
                if (lineFeeds != 0 && lineFeeds > 0)
                {
                    emailHeader = textLine.Substring(0, lineFeeds - 1);
                    emailBody = textLine.Substring(lineFeeds + 1, textLine.Length - emailHeader.Length - 3);
                    emailBody.Replace("\r\n\r\n", "\r\n");
                    emailBody.Trim();
                    txtEmail.Text = emailBody;
                    
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Failed to get the email: " + ex.Message);
            } 
        }
    }
}
