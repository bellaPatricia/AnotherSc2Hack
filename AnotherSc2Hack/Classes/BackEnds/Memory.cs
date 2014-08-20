/* 
 * This class will handle all the memory- calls invoked by the actual tool.
 * The current situation sucks - you have to work within a static context thus: input already known data (handles)
 * 
 * 18 - August - 2014
 * ##################
 * Initial Build
 * */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.BackEnds
{
    public class Memory
    {
        // <summary>
        /// Required to create a thread.
        /// </summary>
        public static Int32 CreateThread = 0x0002,

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
            AllAccess = StandardRightsRequired | Synchronize | 0xFFFF;
        

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Memory()
        {
            
        }

        public Memory(Process process)
        {
            Process = process;
        }

        public Memory(Process process, int desiredAccess)
        {
            Process = process;
            UnlockProcess(desiredAccess);
        }

        /// <summary>
        /// Read an SByte out of memory (byte with -/+)
        /// </summary>
        /// <param name="address">The target address</param>
        /// <returns>The data you want (1 byte)</returns>
        public SByte ReadSByte<T>(T address)
        {
            var adr = CastToIntPtr(address);

            var data = (SByte)InteropCalls.ReadProcessMemoryHelper(Handle, adr, 1)[0];

            return data;
        }

        /// <summary>
        /// Read an Byte out of memory (byte without -/+)
        /// </summary>
        /// <param name="address">The target address</param>
        /// <returns>The data you want (1 byte)</returns>
        public Byte ReadByte<T>(T address)
        {
            var adr = CastToIntPtr(address);

            var data = InteropCalls.ReadProcessMemoryHelper(Handle, adr, 1)[0];

            return data;
        }

        /// <summary>
        /// Read a short (Int16) out of memory (with -/+)
        /// </summary>
        /// <param name="address">The target address</param>
        /// <returns>The data you want (2 bytes)</returns>
        public Int16 ReadInt16<T>(T address)
        {
            var adr = CastToIntPtr(address);

            var data = BitConverter.ToInt16(InteropCalls.ReadProcessMemoryHelper(Handle, adr, 2), 0);

            return data;
        }

        /// <summary>
        /// Read an unsigned short (UInt16) out of memory (without -/+)
        /// </summary>
        /// <param name="address">The target address</param>
        /// <returns>The data you want (2 bytes)</returns>
        public UInt16 ReadUInt16<T>(T address)
        {
            var adr = CastToIntPtr(address);

            var data = BitConverter.ToUInt16(InteropCalls.ReadProcessMemoryHelper(Handle, adr, 2), 0);

            return data;
        }

        /// <summary>
        /// Read an int (Int32) out of memory (with -/+)
        /// </summary>
        /// <param name="address">The target address</param>
        /// <returns>The data you want (4 bytes)</returns>
        public Int32 ReadInt32<T>(T address)
        {
            var adr = CastToIntPtr(address);

            var data = BitConverter.ToInt32(InteropCalls.ReadProcessMemoryHelper(Handle, adr, 4), 0);

            return data;
        }

        /// <summary>
        /// Read an unsigned int (UInt32) out of memory (without -/+)
        /// </summary>
        /// <param name="address">The target address</param>
        /// <returns>The data you want (4 bytes)</returns>
        public UInt32 ReadUInt32<T>(T address)
        {
            var adr = CastToIntPtr(address);

            var data = BitConverter.ToUInt32(InteropCalls.ReadProcessMemoryHelper(Handle, adr, 4), 0);

            return data;
        }

        /// <summary>
        /// Read a long (Int64) out of memory (with -/+)
        /// </summary>
        /// <param name="address">The target address</param>
        /// <returns>The data you want (8 bytes)</returns>
        public Int64 ReadInt64<T>(T address)
        {
            var adr = CastToIntPtr(address);

            var data = BitConverter.ToInt64(InteropCalls.ReadProcessMemoryHelper(Handle, adr, 8), 0);

            return data;
        }

        /// <summary>
        /// Read an unsigned long (UInt64) out of memory (with -/+)
        /// </summary>
        /// <param name="address">The target address</param>
        /// <returns>The data you want (8 bytes)</returns>
        public UInt64 ReadUInt64<T>(T address)
        {
            var adr = CastToIntPtr(address);

            var data = BitConverter.ToUInt64(InteropCalls.ReadProcessMemoryHelper(Handle, adr, 8), 0);

            return data;
        }

        /// <summary>
        /// Reads a chunk out of memory which has to be manipulated afterwards.
        /// </summary>
        /// <param name="address">The target address</param>
        /// <param name="size">The size (length) of data you want to read</param>
        /// <returns>The chunk you want out of memory</returns>
        public Byte[] ReadMemory<T>(T address, int size)
        {
            var adr = CastToIntPtr(address);

            var data = new byte[size];

            data = InteropCalls.ReadProcessMemoryHelper(Handle, adr, size);

            return data;
        }

        /// <summary>
        /// Reads a string out of the memory
        /// </summary>
        /// <typeparam name="T">The datatype for the address (usually Int32)</typeparam>
        /// <param name="address">The address to look at</param>
        /// <param name="length">The amount of bytes to read</param>
        /// <param name="enc">The Encoding (like UTF8 or ASCII)</param>
        /// <returns>Your wanted String</returns>
        public String ReadString<T>(T address, int length, Encoding enc)
        {
            var result = String.Empty;

            result = enc.GetString(ReadMemory(address, length));

            return result;
        }

        /// <summary>
        /// Casts your (unsigned)Int32/Int64 to IntPtr!
        /// </summary>
        /// <typeparam name="T">The Type of the variable you'll use - has to be (unsigned) Int32/ Int64 or an Error will be thrown!</typeparam>
        /// <param name="number">The actual _number_ you want to have converted.</param>
        /// <returns>The converted data of type IntPtr</returns>
        public static IntPtr CastToIntPtr<T>(T number)
        {
            if (number is Int32)
                return (IntPtr)Convert.ToInt32(number);

            if (number is UInt32)
                return (IntPtr)Convert.ToUInt32(number);

            if (number is Int64)
                return (IntPtr)Convert.ToInt64(number);

            if (number is UInt64)
                return (IntPtr) Convert.ToUInt64(number);

            throw new Exception("Hilarious fuck in Memory.cs - \"CastToPtr\"");
        }

        /// <summary>
        /// The Process you want to crack.
        /// </summary>
        public Process Process { get; set; }
        /// <summary>
        /// The !unlocked! handle which gets used to read the memory (At least VM_READ is required!)
        /// </summary>
        public IntPtr Handle { get; set; }

        /// <summary>
        /// Unlocks the process' handle to make it possible to read from that process!
        /// </summary>
        /// <param name="process">The process you want to crack</param>
        /// <param name="desiredAccess">The required Access (like VM_READ)</param>
        public void UnlockProcess(int desiredAccess, Process process = null)
        {
            if (process == null)
                process = Process;

            Handle = InteropCalls.OpenProcess(desiredAccess, true, process.Id);
        }
    }
}
