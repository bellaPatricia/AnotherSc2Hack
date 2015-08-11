using System;

namespace Utilities.Logger
{
    public class LogMessage
    {
        public Exception Error { get; set; }
        public string ErrorTitle { get; set; }
        public ConsoleColor ConsoleForegroundColor { get; set; }
        public ConsoleColor ConsoleBackgroundColor { get; set; }

        public LogMessage(string errorTitle, Exception error)
        {
            Error = error;
            ErrorTitle = errorTitle;
        }

        public LogMessage(string message, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            Error = null;
            ErrorTitle = message;
            ConsoleForegroundColor = foregroundColor;
            ConsoleBackgroundColor = backgroundColor;
        }
    }
}
