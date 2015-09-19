using System;
using System.Diagnostics;
using Interop = Utilities.InteropCalls.InteropCalls;

namespace Utilities.InfoManager
{
    /// <summary>
    /// A class to handle messages and draw them to the console (if one is attached).
    /// This is supposed to be some kind of verbosed boot process in Linux/Unix fashion.
    /// 
    /// Author: bellaPatricia
    /// Date: 10-Sep-2015
    /// </summary>
    public class InfoManager
    {
        /// <summary>
        /// Enumeration to distinct between different states.
        /// None        Nothing will be logged
        /// NotImportant    Logs everything with loglevel NotImportant or higher
        /// Important       Logs everything with loglevel Important or higher
        /// VeryImportant   Logs everything with loglevel VeryImportant
        /// </summary>
        [Flags]
        public enum InfoImportance
        {
            None = 0,
            NotImportant = 1 | Important,
            Important = 2 | VeryImportant,
            VeryImportant = 4
        };

        #region Public Properties

        private static InfoImportance _infoImportance = InfoImportance.None;

        public static InfoImportance InfoLogImportance
        {
            get
            {
                return _infoImportance;
                
            }
            set
            {
                if ((value & InfoImportance.NotImportant) == value)
                {
                    Interop.AllocConsole();
                }

                else if ((value == InfoImportance.None))
                {
                    Interop.FreeConsole();
                }

                _infoImportance = value;
            }
        }

        #endregion

        #region Private Variables

        private static ulong _messageNumber;

        #endregion

        /// <summary>
        /// Method that gets called everytime a message should be printed.
        /// The said message will be printed to the console and is some kind of verbose boot process. 
        /// </summary>
        /// <param name="message">The message you want to send to the console.</param>
        /// <param name="infoImportance">Sets the importance of the informaition to filter it with different filteroptions.</param>
        public static void Info(string message, InfoImportance infoImportance)
        {
            if (infoImportance == InfoImportance.None)
                return;

            if ((infoImportance & InfoLogImportance) != infoImportance)
                return;


            var numberChunk = $"[{_messageNumber.ToString("X8")}]";
            string messageChunk;

            if (message == null ||
                message.Length <= 0)
            {
                var stackframe = new StackFrame(1);
                var callerMethod = stackframe.GetMethod();
                var callerMethodName = callerMethod.Name;

                messageChunk = $"{callerMethodName}";
            }
            else
            {
                messageChunk = $"{message}";
            }


            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(numberChunk);

            if (infoImportance == InfoImportance.VeryImportant)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" - ### - ");
            }

            else if (infoImportance == InfoImportance.Important)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" - ... - ");
            }

            else if (infoImportance == InfoImportance.NotImportant)
            {
                Console.Write(" -     - ");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(messageChunk);

            Console.Write('\n');

            _messageNumber += 1;
        }
    }
}
