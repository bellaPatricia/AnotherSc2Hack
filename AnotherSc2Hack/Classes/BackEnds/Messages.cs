using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Security;
using System.Text;
using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.BackEnds
{
    public class Messages
    {

        /* Send a mail to me.. */
        public static void SendEmail(string smtp, string authSenderUser, SecureString authSenderPassword,
                                     MailAddress mailSendTo, string msgTitle, string msgBody,
                                     string msgAdditional)
        {
            msgTitle += " - [" + DateTime.Now.ToString(CultureInfo.InvariantCulture) + "]";
            msgBody = "Description:\n" +
                      "############\n" +
                      msgBody;

            msgBody += "\n\n\nAdditional UiInformation:\n" +
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

        public static void Show(string title=null, Exception exc=null)
        {
            var stackTrace = new StackTrace();
            var methodName = stackTrace.GetFrame(1).GetMethod().Name;
            var declaringType = stackTrace.GetFrame(1).GetMethod().DeclaringType;
            if (declaringType != null)
            {
                var className = declaringType.ToString();
                title = title ?? "<EMPTY>";

                var sbMakeString = new StringBuilder();
            

                sbMakeString.AppendLine(DateTime.Now.ToString(CultureInfo.InvariantCulture));
                sbMakeString.AppendLine("Version: " + Assembly.GetExecutingAssembly().GetName().Version);
                sbMakeString.AppendLine("##############################");
                sbMakeString.AppendLine("Class: " + className);
                sbMakeString.AppendLine("Method: " + methodName);
                sbMakeString.AppendLine("Title: " + title);
            
            


                if (exc != null)
                {
                    sbMakeString.AppendLine("Exception:");
                    sbMakeString.AppendLine("          ----------          ");
                    sbMakeString.AppendLine("Data: " + exc.Data);
                    sbMakeString.AppendLine("HelpLink: " + exc.HelpLink);
                    sbMakeString.AppendLine("Inner Exception: " + exc.InnerException);
                    sbMakeString.AppendLine("Message: " + exc.Message);
                    sbMakeString.AppendLine("Source: " + exc.Source);
                    sbMakeString.AppendLine("Stack Trace: " + exc.StackTrace);
                    sbMakeString.AppendLine("Target Site: " + exc.TargetSite);
                    sbMakeString.AppendLine("          ----------          ");
                }

                MessageBox.Show(sbMakeString.ToString(), title);
            }
        }

        /* Just a logfile... */
        public static void LogFile(string title, Exception exc )
        {
            var stackTrace = new StackTrace();
            var methodName = stackTrace.GetFrame(1).GetMethod().Name;
            var declaringType = stackTrace.GetFrame(1).GetMethod().DeclaringType;
            if (declaringType != null)
            {
                var className = declaringType.ToString();

            

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
                sw.WriteLine("Version: " + Assembly.GetExecutingAssembly().GetName().Version);
                sw.WriteLine("##############################");
                sw.WriteLine("Class: " + className);
                sw.WriteLine("Method: " + methodName);
                sw.WriteLine("Title: " + title);
            
            


                if (exc != null)
                {
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
                }
            

                sw.Close();
            }
        }
    }
}
