using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Utilities.Processing
{
    public static class Processing
    {
        /// <summary>
        /// Checks if the given Process(name) is available
        /// </summary>
        /// <param name="processName">The actual processname</param>
        /// <returns>True/ False if it's available or not</returns>
        public static bool GetProcess(string processName)
        {
            var bResult = false;

            var procs = Process.GetProcessesByName(processName);

            if (procs.Length > 0)
                bResult = true;

            return bResult;
        }

        /// <summary>
        /// Checks if the given Process(name) is available
        /// </summary>
        /// <param name="processName">The actual processname</param>
        /// <param name="proc">The first found process will be assigned</param>
        /// <returns>True/ False if it's available or not</returns>
        public static bool GetProcess(string processName, out Process proc)
        {
            var bResult = false;
            proc = null;

            var procs = Process.GetProcessesByName(processName);

            if (procs.Length > 0)
            {
                bResult = true;
                proc = procs[0];
            }

            return bResult;
        }

        /// <summary>
        /// Checks if the given Process(name) is available
        /// </summary>
        /// <param name="processName">The actual processname</param>
        /// <param name="index">Assigns the x process to proc</param>
        /// <param name="proc">The X process will be assigned</param>
        /// <returns>True/ False if it's available or not</returns>
        public static bool GetProcess(string processName, int index, out Process proc)
        {
            var bResult = false;
            proc = null;

            var procs = Process.GetProcessesByName(processName);

            if (procs.Length > 0)
            {
                bResult = true;
                proc = procs[0];
            }

            if (index <= procs.Length)
                proc = procs[index];

            return bResult;
        }

        /// <summary>
        /// Checks if the given Process(name) is available
        /// </summary>
        /// <param name="processName">The actual processname</param>
        /// <param name="processes">The list of processes found</param>
        /// <returns>True/ False if it's available or not</returns>
        public static bool GetProcess(string processName, out List<Process> processes)
        {
            var bResult = false;
            processes = null;

            var procs = Process.GetProcessesByName(processName);

            if (procs.Length > 0)
            {
                processes = new List<Process>(procs);
                bResult = true;
            }

            return bResult;
        }
    }
}
