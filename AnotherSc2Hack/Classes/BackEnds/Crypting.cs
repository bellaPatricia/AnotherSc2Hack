/* Welcome to the "Crypting.cs"- file
 * Here is everything you need to encrypt/ decrypt,
 * create hashes and protect stuff.
 *
 * The idea behind this is to create a settingsfile 
 * that is encrypted and readable.
 * 
 * bellaPatricia
 * 2013 - May - 08
 */

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AnotherSc2Hack.Classes.BackEnds
{
    class Crypting
    {
        public static string CreateXor(string strLine)
        {
            var strResult = String.Empty;

            for (var i = 0; i < strLine.Length; i++)
            {
                int val = strLine[i];

                val ^= 42;

                var c = (char) val;
                strResult += c;
            }

            return strResult;
        }

        public static string CreateXor(string strLine, Int32 iSign)
        {
            var strResult = String.Empty;

            for (var i = 0; i < strLine.Length; i++)
            {
                int val = strLine[i];

                val ^= iSign;

                var c = (char)val;
                strResult += c;
            }

            return strResult;
        }

        public static string CreateSha1(string strLine)
        {
            var strResult = String.Empty;

            SHA1 sha = new SHA1CryptoServiceProvider();

            var buffer = Encoding.ASCII.GetBytes(strLine);

            buffer = sha.ComputeHash(buffer);


            for (var i = 0; i < buffer.Length; i++)
            {
                strResult += (char)buffer[i];
            }

            return strResult;
        }

        public static string CreateMd5(FileStream fsSourcefile)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            var bHash = md5.ComputeHash(fsSourcefile);
            fsSourcefile.Close();

            var sb = new StringBuilder();
            foreach (var t in bHash)
            {
                sb.Append(Convert.ToString(t, 16).ToUpper());
            }

            return sb.ToString();
        }
    }
}
