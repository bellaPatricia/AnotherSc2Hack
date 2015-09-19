using System;
using System.Collections.Generic;
using System.IO;

namespace IncrementVersionNumber
{
    /// <summary>
    /// Don't put this into Utilities
    /// Dorward declarations would kill it
    /// 
    /// You are incrementing versions with a reference to Utilities which increments the Utilities...
    /// boom
    /// </summary>
    public static class MyClass
    {
        public static string GetFirstItemBetween(this string sourceText, string betweenA, string betweenB)
        {
            var strResult = string.Empty;

            if (sourceText.IndexOf(betweenB, StringComparison.Ordinal) >
                sourceText.IndexOf(betweenA, StringComparison.Ordinal))
            {
                var indexOfA = sourceText.IndexOf(betweenA, StringComparison.Ordinal) + 1;
                var indexOfB = sourceText.IndexOf(betweenB, StringComparison.Ordinal);

                strResult = sourceText.Substring(indexOfA, indexOfB - indexOfA);
            }

            return strResult;
        }
    }

    /// <summary>
    /// Class to handle custom versioning
    /// </summary>
    internal class CustomVersioning
    {
        /** >> AutoIncrementPattern.txt <<
         * 
        #############################################################################
        # This all is in the scope of the $(ProjectDir)                             #
        # Please use one of the following datatypes to define your version:         #
        # [ ! ] => Don't change the previous number                                 #
        # [ # ] => Use the entered number                                           #
        # [ + ] => Autoincrement the previous number                                #
        #                                                                           #
        #############################################################################
        Major		[99]
        Minor		[5]
        Build		[+]
        Revision	[+]
        */

        public VersioningSettings MajorSettings { get; set; }
        public VersioningSettings MinorSettings { get; set; }
        public VersioningSettings BuildSettings { get; set; }
        public VersioningSettings RevisionSettings { get; set; }

        public int Major { get; set; }
        public int Minor { get; set; }
        public int Build { get; set; }
        public int Revision { get; set; }

        public bool Parse(string patternFile)
        {
            if (!File.Exists(patternFile))
            {
                Console.WriteLine(">> Patternfile not found");
                return false;
            }

            using (var sr = new StreamReader(patternFile))
            {
                while (!sr.EndOfStream)
                {
                    var currentLine = sr.ReadLine();

                    if (currentLine == null)
                        continue;

                    currentLine = currentLine.Trim();

                    if (currentLine.StartsWith("#"))
                        continue;

                    if (currentLine.StartsWith("Major"))
                    {
                        MajorSettings = GetDataType(currentLine);

                        Major = GetDataNumber(currentLine);
                    }

                    else if (currentLine.StartsWith("Minor"))
                    {
                        MinorSettings = GetDataType(currentLine);

                        Minor = GetDataNumber(currentLine);
                    }

                    else if (currentLine.StartsWith("Build"))
                    {
                        BuildSettings = GetDataType(currentLine);

                        Build = GetDataNumber(currentLine);
                    }

                    else if (currentLine.StartsWith("Revision"))
                    {
                        RevisionSettings = GetDataType(currentLine);

                        Revision = GetDataNumber(currentLine);
                    }
                }
            }

            return true;
        }

        private VersioningSettings GetDataType(string line)
        {
            var datatype = line.GetFirstItemBetween("[", "]");

            if (datatype == "!")
                return VersioningSettings.DontChange;

            if (datatype == "+")
                return VersioningSettings.Increment;

            return VersioningSettings.Change;
        }

        private int GetDataNumber(string line)
        {
            var data = line.GetFirstItemBetween("[", "]");
            var iOut = 0;

            if (int.TryParse(data, out iOut))
            {
                
            }

            return iOut;

        }

        public enum VersioningSettings
        {
            DontChange,
            Change,
            Increment
        };

        public override string ToString()
        {
            return
                String.Format(
                    "MajorSettings: {0}-MinorSettings: {1}-BuildSettings: {2}-RevisionSettings: {3}", MajorSettings, MinorSettings, BuildSettings, RevisionSettings);
        }
    }

    

    class Program
    {
        static string assemblyVersion = "[assembly: AssemblyVersion(";
        static string assemblyFileVersion = "[assembly: AssemblyFileVersion(";
        static readonly CustomVersioning CustomVersioning = new CustomVersioning();

        /// <summary>
        /// The main entry point
        /// </summary>  
        /// <param name="args">
        /// args [0] => $(SolutionDir)
        /// args [1] => $(ProjectDir)
        /// args [2] => AutoIncrementPattern.txt
        /// </param>
        static int Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine(">> No arguments set, existing!");
                Console.WriteLine("Argument:");
                foreach (var arg in args)
                {
                    Console.WriteLine(arg);
                }
                return 1;
            }
            

            var solutionDir = args[0];
            var assembly = args[1] + "Properties\\AssemblyInfo.cs";
            var autoIncrementPattern = solutionDir + args[2];

            if (!CustomVersioning.Parse(autoIncrementPattern))
            {
                Console.WriteLine(">> Couldn't read pattern file, existing!");
                return 1;
            }

            
            IncrementAssemblyVersion(assembly);
            

            return 0;
        }

        static List<string> ReadAssemblies(string assemblyPathFile, string projectDir)
        {
            var assemblies = new List<string>();

            if (!File.Exists(assemblyPathFile))
            {
                Console.WriteLine(">> Couln't read assemblies");
                return assemblies;
            }

            using (var sr = new StreamReader(assemblyPathFile))
            {
                while (!sr.EndOfStream)
                {
                    var strLine = sr.ReadLine();
                    if (strLine == null)
                        continue;

                    if (strLine.StartsWith("#"))
                        continue;

                    assemblies.Add(projectDir + strLine);
                }
            }

            return assemblies;
        }

        static void IncrementAssemblyVersion(string assembly)
        {
            if (!File.Exists(assembly))
            {
                Console.WriteLine(">> Assembly *NOT* found! {0}", assembly);
                return;
            }


            var lines = new List<string>();
            var strNewVersion = String.Empty;

            using (var sr = new StreamReader(assembly))
            {
                while (!sr.EndOfStream)
                {
                    var tempLine = sr.ReadLine();

                    if (tempLine == null)
                        continue;

                    var strNewLine = tempLine;
                    if (tempLine.StartsWith(assemblyVersion) ||
                        tempLine.StartsWith(assemblyFileVersion))
                    {
                        var elements = tempLine.Split('\"');
                        if (elements.Length != 3)
                        {
                            Console.WriteLine(">> Elements length: {0}", elements.Length);
                            continue;
                        }

                        var version = new Version(elements[1]);

                        var major = version.Major;
                        var minor = version.Minor;
                        var build = version.Build;
                        var revision = version.Revision;

                        #region Assign new version information

                        if (CustomVersioning.MajorSettings == CustomVersioning.VersioningSettings.Increment)
                            major += 1;

                        else if (CustomVersioning.MajorSettings == CustomVersioning.VersioningSettings.Change)
                            major = CustomVersioning.Major;


                        if (CustomVersioning.MinorSettings == CustomVersioning.VersioningSettings.Increment)
                            minor += 1;

                        else if (CustomVersioning.MinorSettings == CustomVersioning.VersioningSettings.Change)
                            minor = CustomVersioning.Minor;


                        if (CustomVersioning.BuildSettings == CustomVersioning.VersioningSettings.Increment)
                            build += 1;

                        else if (CustomVersioning.BuildSettings == CustomVersioning.VersioningSettings.Change)
                            build = CustomVersioning.Build;


                        if (CustomVersioning.RevisionSettings == CustomVersioning.VersioningSettings.Increment)
                            revision += 1;

                        else if (CustomVersioning.RevisionSettings == CustomVersioning.VersioningSettings.Change)
                            revision = CustomVersioning.Revision;

                        #endregion

                        var tempNewVersion = major + "." + minor + "." + build + "." + revision;

                        strNewLine = elements[0] + "\"" + tempNewVersion + "\"" + elements[2];
                        strNewVersion = tempNewVersion;
                    }

                    lines.Add(strNewLine);
                }
            }

            using (var sw = new StreamWriter(assembly))
            {
                foreach (var line in lines)
                {
                    sw.WriteLine(line);
                }
            }

            Console.WriteLine("=====> Icrementing of {0} successful! ({1}) <=====", assembly, strNewVersion);
        }
    }
}
