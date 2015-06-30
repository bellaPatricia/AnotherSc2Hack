using System;
using System.Collections.Generic;
using Utilities.ExtensionMethods;

namespace Utilities.Logger
{
    public class Logger
    {
        public static string LogFile { get; set; }

        private Logger()
        {
            
        }

        public static void Emit(LogMessage message)
        {
            ToConsole(message);
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

            Dictionary<string, string> dContent = new Dictionary<string, string>();
            dContent.Add("Message", message.Error.Message);
            dContent.Add("Source", message.Error.Source);
            dContent.Add("StackTrace", message.Error.StackTrace);
            dContent.Add("Module", message.Error.TargetSite.Module.ToString());
            dContent.Add("Attributes", message.Error.TargetSite.Attributes.ToString());
            dContent.Add("TargetSite", message.Error.TargetSite.ToString());

            foreach (var item in dContent)
            {
                Console.WriteLine("{0}: {1}", item.Key, item.Value);
            }
        }
    }
}
