using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Security;
using System.Net.Mail;
using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.BackEnds
{
    public class Messages
    {

        /* Send a mail to me.. */
        public static void SendEmail(String smtp, String authSenderUser, SecureString authSenderPassword,
                                     MailAddress mailSendTo, String msgTitle, String msgBody,
                                     String msgAdditional)
        {
            msgTitle += " - [" + DateTime.Now.ToString(CultureInfo.InvariantCulture) + "]";
            msgBody = "Description:\n" +
                      "############\n" +
                      msgBody;

            msgBody += "\n\n\nAdditional Information:\n" +
                        "############\n" + 
                        msgAdditional;

            

            var mailmsg = new MailMessage(mailSendTo, mailSendTo);
            mailmsg.Body = msgBody + msgAdditional;
            mailmsg.Subject = msgTitle;
            mailmsg.Attachments.Add(new Attachment(Constants.StrDummyPref));

            var smtpServ = new SmtpClient(smtp);
            smtpServ.Credentials = new NetworkCredential(authSenderUser, authSenderPassword);
            var iCounter = 0;

            SendAgain:
            try
            {
                 smtpServ.Send(mailmsg);
            }

            catch
            {
                if (iCounter < 7)
                {
                    iCounter++;
                    goto SendAgain;
                }
            }
        }
        /* Just a logfile... */
        public static void LogFile(String method, String title, Exception exc )
        {
            Debug.WriteLine("Logfile written/ extended!");

            StreamWriter sw;

            if (File.Exists(Constants.StrLogFile))
                sw = File.AppendText(Constants.StrLogFile);

            else
            {
                sw = new StreamWriter(Constants.StrLogFile);
                MessageBox.Show("Error thrown and logfile created!");
            }


            sw.WriteLine();
            sw.WriteLine();

            sw.WriteLine(DateTime.Now.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine("##############################");
            sw.WriteLine("Method: " + method);
            sw.WriteLine("Title: " + title);
            sw.WriteLine("Exception:");
            sw.WriteLine("          ----------          ");
            sw.WriteLine("Data: " + exc.Data);
            //sw.WriteLine("HResult: " + exc.HResult);
            sw.WriteLine("HelpLink: " + exc.HelpLink);
            sw.WriteLine("Inner Exception: " + exc.InnerException);
            sw.WriteLine("Message: " + exc.Message);
            sw.WriteLine("Source: " + exc.Source);
            sw.WriteLine("Stack Trace: " + exc.StackTrace);
            sw.WriteLine("Target Site: " + exc.TargetSite);
            sw.WriteLine("          ----------          ");

            sw.Close();

            
        }
    }
}
