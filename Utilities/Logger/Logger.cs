using System;
using System.Collections.Generic;
using Utilities.ExtensionMethods;
using System.IO;
using System.Text;

namespace Utilities.Logger
{
    public class Logger
    {
        public static string LogFile { get; set; }
        public static bool LogToConsole { get; set; }
        public static bool LogToFile { get; set; }

        private Logger()
        {
            
        }

        public static void Emit(LogMessage message)
        {
            if (LogToConsole)
                ToConsole(message);

            if (LogToFile)
                ToFile(message);
        }

        public static void Emit(string errorTitle, Exception error)
        {
            Emit(new LogMessage(errorTitle, error));
        }

        public static void Emit(Exception error)
        {
            Emit(new LogMessage(String.Empty, error));
        }

        private static void ToConsole(LogMessage message)
        {
            var strErrorTitle = message.ErrorTitle;
            var strClock = "Time of incident: " + DateTime.Now;

            if (strErrorTitle.Length <= 0)
                strErrorTitle = "No error title provided!";

            var iMaxLength = strClock.Length > strErrorTitle.Length ? strClock.Length : strErrorTitle.Length;
            iMaxLength += 2;

            //Write Error Title
            Console.WriteLine(String.Empty.Fill("-", iMaxLength + 2));
            Console.WriteLine("|{0}|", String.Empty.Fill(" ", iMaxLength));
            Console.WriteLine("|{0}|", strErrorTitle.Center(" ", iMaxLength));
            Console.WriteLine("|{0}|", String.Empty.Fill(" ", iMaxLength));
            Console.WriteLine(String.Empty.Fill("-", iMaxLength + 2));

            //Clock
            Console.WriteLine("|{0}|", strClock.Center(" ", iMaxLength));
            Console.WriteLine(String.Empty.Fill("-", iMaxLength + 2));

            var dContent = new Dictionary<string, string>();

            dContent.Add("Message", message.Error.Message);

            if (message.Error.Source != null)
            dContent.Add("Source", message.Error.Source);

            if (message.Error.StackTrace != null)
            dContent.Add("StackTrace", message.Error.StackTrace);

            if (message.Error.TargetSite != null)
            {
                dContent.Add("Module", message.Error.TargetSite.Module.ToString());
                dContent.Add("Attributes", message.Error.TargetSite.Attributes.ToString());
                dContent.Add("TargetSite", message.Error.TargetSite.ToString());
            }

            foreach (var item in dContent)
            {
                Console.WriteLine("{0}: {1}", item.Key, item.Value);
            }
        }

        private static void ToFile(LogMessage message)
        {
            if (LogFile.Length <= 0)
                return;



            var strDataChunk = new List<String>();
            var strErrorTitle = message.ErrorTitle;
            var strClock = "Time of incident: " + DateTime.Now;

            if (strErrorTitle.Length <= 0)
                strErrorTitle = "No error title provided!";

            var iMaxLength = strClock.Length > strErrorTitle.Length ? strClock.Length : strErrorTitle.Length;
            iMaxLength += 2;

            //Write Error Title
            strDataChunk.Add(String.Format(String.Empty.Fill("-", iMaxLength + 2)));
            strDataChunk.Add(String.Format("|{0}|", String.Empty.Fill(" ", iMaxLength)));
            strDataChunk.Add(String.Format("|{0}|", strErrorTitle.Center(" ", iMaxLength)));
            strDataChunk.Add(String.Format("|{0}|", String.Empty.Fill(" ", iMaxLength)));
            strDataChunk.Add(String.Format(String.Empty.Fill("-", iMaxLength + 2)));

            //Clock
            strDataChunk.Add(String.Format("|{0}|", strClock.Center(" ", iMaxLength)));
            strDataChunk.Add(String.Format(String.Empty.Fill("-", iMaxLength + 2)));

            var dContent = new Dictionary<string, string>();

            dContent.Add("Message", message.Error.Message);

            if (message.Error.Source != null)
                dContent.Add("Source", message.Error.Source);

            if (message.Error.StackTrace != null)
                dContent.Add("StackTrace", message.Error.StackTrace);

            if (message.Error.TargetSite != null)
            {
                dContent.Add("Module", message.Error.TargetSite.Module.ToString());
                dContent.Add("Attributes", message.Error.TargetSite.Attributes.ToString());
                dContent.Add("TargetSite", message.Error.TargetSite.ToString());
            }

            foreach (var item in dContent)
            {
                strDataChunk.Add(String.Format("{0}: {1}", item.Key, item.Value));
            }

            //Write information to file
            using (var sw = new StreamWriter(LogFile, true))
            {
                foreach (var data in strDataChunk)
                {
                    sw.WriteLine(data);
                }
            }
        }
    }
}
