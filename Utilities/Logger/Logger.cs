using System;
using System.Collections.Generic;
using Utilities.ExtensionMethods;
using System.IO;
using System.Runtime.InteropServices;
using System.Text; 

namespace Utilities.Logger
{
    public class Logger
    {
        ~Logger()
        {
            if (LogToConsole)
            {
                FreeConsole();
            }    
        }

        public static string LogFile { get; set; }

        private static bool _logToConsole;

        public static bool LogToConsole
        {
            get { return _logToConsole; }
            set
            {
                _logToConsole = value;

                if (value)
                {
                    AllocConsole();
                }
            }
        }

        private static bool _logToFile = true;

        public static bool LogToFile
        {
            get { return _logToFile; }
            set { _logToFile = value; }
        }

        private Logger()
        {
            
        }

        public static void RawEmit(string message)
        {
            Console.WriteLine("{0} ({1})", message, DateTime.Now);
        }

        public static void Emit(string errorTitle, string error)
        {
            Emit(new LogMessage(errorTitle, new Exception(error)));
        }

        public static void Emit(string error, ConsoleColor foregroundColor = ConsoleColor.Gray, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Emit(new LogMessage(error, foregroundColor, backgroundColor));
        }

        public static void Emit(LogMessage message)
        {
            if (message.Error == null)
            {
                if (ApplicationStartOptions.ApplicationStartOptions.Logging)
                ToConsoleSimple(message);
            }

            else
            {

                if (LogToConsole)
                    ToConsole(message);

                if (LogToFile)
                    ToFile(message);
            }
        }

        public static void Emit(string errorTitle, Exception error)
        {
            Emit(new LogMessage(errorTitle, error));
        }

        public static void Emit(Exception error)
        {
            Emit(new LogMessage(String.Empty, error));
        }

        private static void ToConsoleSimple(LogMessage message)
        {
            Console.ForegroundColor = message.ConsoleForegroundColor;
            Console.BackgroundColor = message.ConsoleBackgroundColor;
            Console.WriteLine(message.ErrorTitle);
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

        /// <summary>
        /// Allocates a new console for the calling process.
        /// </summary>
        /// <returns>nonzero if the function succeeds; otherwise, zero.</returns>
        /// <remarks>
        /// A process can be associated with only one console,
        /// so the function fails if the calling process already has a console.
        /// </remarks>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int AllocConsole();

        // http://msdn.microsoft.com/en-us/library/ms683150(VS.85).aspx
        /// <summary>
        /// Detaches the calling process from its console.
        /// </summary>
        /// <returns>nonzero if the function succeeds; otherwise, zero.</returns>
        /// <remarks>
        /// If the calling process is not already attached to a console,
        /// the error code returned is ERROR_INVALID_PARAMETER (87).
        /// </remarks>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int FreeConsole();
    }


}
