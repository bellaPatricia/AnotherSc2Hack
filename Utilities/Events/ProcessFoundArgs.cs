using System;
using System.Diagnostics;

namespace Utilities.Events
{
    public delegate void ProcessFoundHandler(object sender, ProcessFoundArgs e);

    public class ProcessFoundArgs : EventArgs
    {
        public Process Process { get; private set; }

        public ProcessFoundArgs(Process process)
        {
            Process = process;
        }
    }
}
