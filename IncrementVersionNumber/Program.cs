using System;
using System.Collections.Generic;
using System.IO;

namespace IncrementVersionNumber
{
    class Program
    {
        static string assemblyVersion = "[assembly: AssemblyVersion(";
        static string assemblyFileVersion = "[assembly: AssemblyFileVersion(";

        static void Main(string[] args)
        {


            if (args.Length <= 0)
            {
                Console.WriteLine(">> No arguments set, existing!");
                return;
            }

            var assemblies = new[]
            {
                args[0] + "AnotherSc2Hack\\Properties\\AssemblyInfo.cs"
            };

            foreach (var assembly in assemblies)
            {
                IncrementAssemblyVersion(assembly);
            }
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
                        var revision = version.Revision;
                        revision += 1;

                        var tempNewVersion = version.Major + "." + version.Minor + "." + version.Build + "." + revision;

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

            Console.WriteLine("=====> Icrementing of version successful! ({0}) <=====", strNewVersion);
        }
    }
}
