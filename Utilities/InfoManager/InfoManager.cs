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
            NotImportant = 1 | Important,
            Important = 2 | VeryImportant,
            VeryImportant = 4
        };

        internal InfoManager()
        {
        }

        public static InfoImportance InfoLogImportance { get; set; } = InfoImportance.Important;
        private static ulong _messageNumber = 0;

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
