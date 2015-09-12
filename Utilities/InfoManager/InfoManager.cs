using System;
using System.Diagnostics;

namespace Utilities.InfoManager
{
    public class InfoManager
    {
        [Flags]
        public enum InfoImportance
        {
            None = 0,
            NotImportant = 1,
            Important = 2,
            VeryImportant = 4,

            Everything = NotImportant |
                         Important |
                         VeryImportant
        };

        internal InfoManager()
        {
        }

        public static InfoImportance InfoLogImportance { get; set; } = InfoImportance.Everything;
        private static ulong _messageNumber = 0;

        public static void Info(string message = null, InfoImportance infoImportance = InfoImportance.None, bool increment = true)
        {
            if (infoImportance == InfoImportance.None)
                return;

            Console.WriteLine(infoImportance & InfoLogImportance);

            var numberChunk = $"[{_messageNumber.ToString("X8")}]";
            string messageChunk;

            if (message == null ||
                message.Length <= 0)
            {
                var stackframe = new StackFrame(1);
                var callerMethod = stackframe.GetMethod();
                var callerMethodName = callerMethod.Name;

                messageChunk = $" - {callerMethodName}";
            }
            else
            {
                messageChunk = $" - {message}";
            }

            
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(numberChunk);

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(messageChunk);

            Console.Write('\n');

            if (increment)
                _messageNumber += 1;
        }
    }
}
