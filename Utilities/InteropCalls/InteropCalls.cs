/* InteropCalls.cs
 * Written: 31 August 2014
 * by BellaPatricia
 * 
 * The purpose of this file is to build a Wrapper for the Windows API
 * Some calls a critical and might be declared as virus or "bad"- files by some AVs.
 * 
 * However, those declarations are so know "false positives" and can be ignored.
 * 
 * 
 * This file also provides some Methods that help to using the naked API.
 * 
 * 
 * 
 */


using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Proc = Utilities.Processing.Processing;

namespace Utilities.InteropCalls
{
    public class InteropCalls
    {
        #region kernel32-dll

        /* ReadProcessMemory */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ReadProcessMemory(
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            [Out] byte[] lpBuffer,
            int dwSize,
            out IntPtr lpNumberOfBytesRead
            );

        /* WriteProcessMemory */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteProcessMemory(
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            byte[] lpBuffer,
            int nSize,
            out IntPtr lpNumberOfBytesWritten);

        /* OpenProcess */
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        /* CloseHandle */
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle(IntPtr hObject);

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

        [DllImport("kernel32.dll")]
        public static extern uint GetLastError();

        #endregion

        #region user32.dll

        /* GetWindowInfo */
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowInfo(IntPtr hwnd, ref WINDOWINFO pwi);

        /* Get Client Rect */
        [DllImport("user32.dll")]
        public static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);

        /* GetWindowRect */
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(HandleRef hwnd, out RECT lpRect);

        /* GetAsyncKeyState */
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(Keys vKey);

        /* GetWindowLongPtr */
        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        public static extern IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex);

        /* SetForegroundWindow */
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        /* GetForegroundWindow */
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        /* GetWindowLong */
        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowLong(IntPtr hWnd, int nIndex);

        /* SetWindowLong */
        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        /* SendMessage */
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        /* SendMessage */
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr PostMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        /* SetActiveWindow */
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetActiveWindow(IntPtr hWnd);

        /* Get Window */
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetWindow(IntPtr hWnd, GetWindowCmd uCmd);

        /* SetCursorPos */
        [DllImport("user32.dll")]
        public static extern long SetCursorPos(int x, int y);

        /* ClientToScreen */
        [DllImport("user32.dll")]
        public static extern bool ClientToScreen(IntPtr hWnd, ref POINT point);

        #endregion

        #region dwmapi.dll

        [DllImport("dwmapi.dll", PreserveSig = false)]
        public static extern bool DwmIsCompositionEnabled();

        [DllImport("dwmapi.dll", EntryPoint = "DwmEnableComposition")]
        public static extern uint Win32DwmEnableComposition(uint uCompositionAction);

        #endregion

        #region winmm.dll

        /* MM_BeginPeriod */
        [DllImport("winmm.dll", EntryPoint = "timeBeginPeriod")]
        public static extern uint MM_BeginPeriod(uint uMilliseconds);

        /* MM_GetTime */
        [DllImport("winmm.dll", EntryPoint = "timeGetTime")]
        public static extern uint MM_GetTime();

        /* MM_EndPeriod */
        [DllImport("winmm.dll", EntryPoint = "timeEndPeriod")]
        public static extern uint MM_EndPeriod(uint uMilliseconds);

        #endregion

        public enum GetWindowCmd : uint
        {
            GwHwndfirst = 0,
            GwHwndlast = 1,
            GwHwndnext = 2,
            GwHwndprev = 3,
            GwOwner = 4,
            GwChild = 5,
            GwEnabledpopup = 6
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;
        }

        [Flags]
        public enum ProcessAccess
        {
            /// <summary>
            /// Required to create a thread.
            /// </summary>
            CreateThread = 0x0002,

            /// <summary>
            ///
            /// </summary>
            SetSessionId = 0x0004,

            /// <summary>
            /// Required to perform an operation on the address space of a process
            /// </summary>
            VmOperation = 0x0008,

            /// <summary>
            /// Required to read memory in a process using ReadProcessMemory.
            /// </summary>
            VmRead = 0x0010,

            /// <summary>
            /// Required to write to memory in a process using WriteProcessMemory.
            /// </summary>
            VmWrite = 0x0020,

            /// <summary>
            /// Required to duplicate a handle using DuplicateHandle.
            /// </summary>
            DupHandle = 0x0040,

            /// <summary>
            /// Required to create a process.
            /// </summary>
            CreateProcess = 0x0080,

            /// <summary>
            /// Required to set memory limits using SetProcessWorkingSetSize.
            /// </summary>
            SetQuota = 0x0100,

            /// <summary>
            /// Required to set certain information about a process, such as its priority class (see SetPriorityClass).
            /// </summary>
            SetInformation = 0x0200,

            /// <summary>
            /// Required to retrieve certain information about a process, such as its token, exit code, and priority class (see OpenProcessToken).
            /// </summary>
            QueryInformation = 0x0400,

            /// <summary>
            /// Required to suspend or resume a process.
            /// </summary>
            SuspendResume = 0x0800,

            /// <summary>
            /// Required to retrieve certain information about a process (see GetExitCodeProcess, GetPriorityClass, IsProcessInJob, QueryFullProcessImageName).
            /// A handle that has the PROCESS_QUERY_INFORMATION access right is automatically granted PROCESS_QUERY_LIMITED_INFORMATION.
            /// </summary>
            QueryLimitedInformation = 0x1000,

            /// <summary>
            /// Required to wait for the process to terminate using the wait functions.
            /// </summary>
            Synchronize = 0x100000,

            /// <summary>
            /// Required to delete the object.
            /// </summary>
            Delete = 0x00010000,

            /// <summary>
            /// Required to read information in the security descriptor for the object, not including the information in the SACL.
            /// To read or write the SACL, you must request the ACCESS_SYSTEM_SECURITY access right. For more information, see SACL Access Right.
            /// </summary>
            ReadControl = 0x00020000,

            /// <summary>
            /// Required to modify the DACL in the security descriptor for the object.
            /// </summary>
            WriteDac = 0x00040000,

            /// <summary>
            /// Required to change the owner in the security descriptor for the object.
            /// </summary>
            WriteOwner = 0x00080000,

            StandardRightsRequired = 0x000F0000,

            /// <summary>
            /// All possible access rights for a process object.
            /// </summary>
            AllAccess = StandardRightsRequired | Synchronize | 0xFFFF
        }

        [Flags]
        public enum Protection
        {
            PageNoaccess = 0x01,
            PageReadonly = 0x02,
            PageReadwrite = 0x04,
            PageWritecopy = 0x08,
            PageExecute = 0x10,
            PageExecuteRead = 0x20,
            PageExecuteReadwrite = 0x40,
            PageExecuteWritecopy = 0x80,
            PageGuard = 0x100,
            PageNocache = 0x200,
            PageWritecombine = 0x400
        }

        [Flags]
        public enum Gwl
        {
            ExStyle = -20
        }

        [Flags]
        public enum Ws
        {
            Caption = 0x00C00000,
            Border = 0x00800000,
            ExLayered = 0x80000,
            Sysmenu = 0x00080000,
            Minimizebox = 0x00020000,
            ExTransparent = 0x20

        }

        [Flags]
        public enum WMessages
        {

            Keyfirst = 0x100,
            Keydown = 0x100,
            Keyup = 0x101,
            Char = 0x102,
            Deadchar = 0x103,
            Syskeydown = 0x104,
            Syskeyup = 0x105,
            Syschar = 0x106,
            Sysdeadchar = 0x107,
            Keylast = 0x108,


            Mousefirst = 0x200,
            Mousemove = 0x200,
            Lbuttondown = 0x201,
            Lbuttonup = 0x202,
            Lbuttondblclk = 0x203,
            Rbuttondown = 0x204,
            Rbuttonup = 0x205,
            Rbuttondblclk = 0x206,
            Mbuttondown = 0x207,
            Mbuttonup = 0x208,
            Mbuttondblclk = 0x209,
            Mousewheel = 0x20A,
            Mousehwheel = 0x20E,
        }

        [Flags]
        public enum DwmEc : uint
        {
            DisableComposition = 0,
            EnableComposition = 1,
        }

        public static byte[] ReadProcessMemoryHelper(IntPtr handle, IntPtr address, int size)
        {
            if (size < 0)
                return new byte[0];

            IntPtr bytesRead;
            var buffer = new byte[size];

            ReadProcessMemory(handle, address, buffer, size, out bytesRead);

            return buffer;
        }

        public static bool WriteProcessMemoryHelper(IntPtr handle, IntPtr baseAddress, byte[] newVal)
        {
            IntPtr bytesWritten;

            return WriteProcessMemory(handle, baseAddress, newVal, newVal.Length, out bytesWritten);
        }

        public static IntPtr Help_OpenProcess(int dwDesiredAccess, bool bInheritHandle, string strProcessName)
        {
            Process proc;
            if (Proc.GetProcess(strProcessName, out proc))
                return OpenProcess(dwDesiredAccess, bInheritHandle, proc.Id);

            return IntPtr.Zero;
            
        }

        public static IntPtr Help_OpenProcess(int dwDesiredAccess, bool bInheritHandle, Process proc)
        {
            return OpenProcess(dwDesiredAccess, bInheritHandle, proc.Id);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left, Top, Right, Bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct WINDOWINFO
        {
            public uint cbSize;
            public RECT rcWindow;
            public RECT rcClient;
            public uint dwStyle;
            public uint dwExStyle;
            public uint dwWindowStatus;
            public uint cxWindowBorders;
            public uint cyWindowBorders;
            public ushort atomWindowType;
            public ushort wCreatorVersion;

            public WINDOWINFO(bool? filler)
                : this()   // Allows automatic initialization of "cbSize" with "new WINDOWINFO(null/true/false)".
            {
                cbSize = (uint)(Marshal.SizeOf(typeof(WINDOWINFO)));
            }

        }
    }
}
