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

        /// <summary>
        /// Read an SByte out of memory (byte with -/+)
        /// </summary>
        /// <param name="address">The target address</param>
        /// <returns>The data you want (1 byte)</returns>
        public SByte ReadSByte(UInt32 address)
        {
            SByte data = 0;

            return data;
        }

        /// <summary>
        /// Read an Byte out of memory (byte without -/+)
        /// </summary>
        /// <param name="address">The target address</param>
        /// <returns>The data you want (1 byte)</returns>
        public Byte ReadByte(UInt32 address)
        {
            Byte data = 0;

            return data;
        }

        /// <summary>
        /// Read a short (Int16) out of memory (with -/+)
        /// </summary>
        /// <param name="address">The target address</param>
        /// <returns>The data you want (2 bytes)</returns>
        public Int16 ReadInt16(UInt32 address)
        {
            Int16 data = 0;

            return data;
        }

        /// <summary>
        /// Read an unsigned short (UInt16) out of memory (without -/+)
        /// </summary>
        /// <param name="address">The target address</param>
        /// <returns>The data you want (2 bytes)</returns>
        public UInt16 ReadUInt16(UInt32 address)
        {
            UInt16 data = 0;

            return data;
        }

        /// <summary>
        /// Read an int (Int32) out of memory (with -/+)
        /// </summary>
        /// <param name="address">The target address</param>
        /// <returns>The data you want (4 bytes)</returns>
        public Int32 ReadInt32(UInt32 address)
        {
            Int32 data = 0;

            return data;
        }

        /// <summary>
        /// Read an unsigned int (UInt32) out of memory (without -/+)
        /// </summary>
        /// <param name="address">The target address</param>
        /// <returns>The data you want (4 bytes)</returns>
        public UInt32 ReadUInt32(UInt32 address)
        {
            UInt32 data = 0;

            return data;
        }

        /// <summary>
        /// Read a long (Int64) out of memory (with -/+)
        /// </summary>
        /// <param name="address">The target address</param>
        /// <returns>The data you want (8 bytes)</returns>
        public Int64 ReadInt64(UInt32 address)
        {
            Int64 data = 0;

            return data;
        }

        /// <summary>
        /// Read an unsigned long (UInt64) out of memory (with -/+)
        /// </summary>
        /// <param name="address">The target address</param>
        /// <returns>The data you want (8 bytes)</returns>
        public UInt64 ReadUInt64(UInt32 address)
        {
            UInt64 data = 0;

            return data;
        }

        /// <summary>
        /// Reads a chunk out of memory which has to be manipulated afterwards.
        /// </summary>
        /// <param name="address">The target address</param>
        /// <param name="size">The size (length) of data you want to read</param>
        /// <returns>The chunk you want out of memory</returns>
        public Byte[] ReadMemory(UInt32 address, UInt32 size)
        {
            Byte[] data = new byte[size];

            

            return data;
        }

        /// <summary>
        /// The Process you can't to crack.
        /// </summary>
        public Process Process { get; set; }
        /// <summary>
        /// The !unlocked! handle which gets used to read the memory (At least VM_READ is required!)
        /// </summary>
        public IntPtr Handle { get; set; }
    }
}
