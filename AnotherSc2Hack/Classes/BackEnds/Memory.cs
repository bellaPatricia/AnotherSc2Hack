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
            UnlockProcess(process, desiredAccess);
        }

        /// <summary>
        /// Read an SByte out of memory (byte with -/+)
        /// </summary>
        /// <param name="address">The target address</param>
        /// <returns>The data you want (1 byte)</returns>
        public SByte ReadSByte<T>(T address)
        {
            var adr = CastToIntPtr(address);

            var data = (SByte)InteropCalls.Help_ReadProcessMemory(Handle, adr, 1)[0];

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

            var data = InteropCalls.Help_ReadProcessMemory(Handle, adr, 1)[0];

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

            var data = BitConverter.ToInt16(InteropCalls.Help_ReadProcessMemory(Handle, adr, 2), 0);

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

            var data = BitConverter.ToUInt16(InteropCalls.Help_ReadProcessMemory(Handle, adr, 2), 0);

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

            var data = BitConverter.ToInt32(InteropCalls.Help_ReadProcessMemory(Handle, adr, 4), 0);

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

            var data = BitConverter.ToUInt32(InteropCalls.Help_ReadProcessMemory(Handle, adr, 4), 0);

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

            var data = BitConverter.ToInt64(InteropCalls.Help_ReadProcessMemory(Handle, adr, 8), 0);

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

            var data = BitConverter.ToUInt64(InteropCalls.Help_ReadProcessMemory(Handle, adr, 8), 0);

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

            data = InteropCalls.Help_ReadProcessMemory(Handle, adr, size);

            return data;
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
        public void UnlockProcess(Process process, int desiredAccess)
        {
            Handle = InteropCalls.OpenProcess(desiredAccess, false, process.Id);
        }
    }
}
