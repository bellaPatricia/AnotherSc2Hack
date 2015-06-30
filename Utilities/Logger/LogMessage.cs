using System;

namespace Utilities.Logger
{
    public class LogMessage
    {
        public Exception Error { get; set; }
        public string ErrorTitle { get; set; }

        public LogMessage(string errorTitle, Exception error)
        {
            Error = error;
            ErrorTitle = errorTitle;
        }
    }
}
