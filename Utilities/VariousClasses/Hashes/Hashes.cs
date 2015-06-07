/* Hashes.cs
 * Written: 07-Feb-2014
 * by bellaPatricia
 * 
 * The purpose of this class is to provide easy accessable methods to create basic hashes to calculate a checksum for a file
 * That would make soiftware stealing a bit more complicated.
 * 
 * As this software isn't obfuscated, it doesn't make sense to add a feature that eats resources and only give
 * basic protection. 
 * 
 * This is file is (for this very moment) unused and totally useless but might be used in the future.
 * 
 */


using System;
using System.IO;
using System.Security.Cryptography;

namespace Utilities.VariousClasses.Hashes
{
    public class Hashes
    {
        public enum HashAlgorithm
        {
            Md5,
            Sha1,
            Sha256,
        };

        public static string HashFromFile(string file, HashAlgorithm algorithm)
        {
            switch (algorithm)
            {
                case HashAlgorithm.Md5:
                    return Md5FromFile(file);

                case HashAlgorithm.Sha1:
                    return Sha1FromFile(file);

                case HashAlgorithm.Sha256:
                    return Sha256FromFile(file);
                   

                default:
                    return Md5FromFile(file);

            }
        }

        private static string Md5FromFile(string file)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            FileStream fs = File.OpenRead(file);


            byte[] buffer = md5.ComputeHash(fs);
            fs.Close();

            return BitConverter.ToString(buffer).Replace("-", "").ToUpper();
        }

        private static string Sha1FromFile(string file)
        {
            SHA1 md5 = new SHA1CryptoServiceProvider();
            FileStream fs = File.OpenRead(file);


            byte[] buffer = md5.ComputeHash(fs);
            fs.Close();

            return BitConverter.ToString(buffer).Replace("-", "").ToUpper();
        }

        private static string Sha256FromFile(string file)
        {
            SHA256 md5 = new SHA256CryptoServiceProvider();
            FileStream fs = File.OpenRead(file);


            byte[] buffer = md5.ComputeHash(fs);
            fs.Close();

            return BitConverter.ToString(buffer).Replace("-", "").ToUpper();
        }
    }
}
