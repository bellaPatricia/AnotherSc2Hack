using System;
using System.Collections.Generic;
using System.IO;
using _ = Utilities.InfoManager.InfoManager;

namespace Utilities.ArgumentManager
{
    public class ArgumentManager
    {
        public static _.InfoImportance VerboseMode { get; private set; }

        private delegate void SecondArgument(string second);
        private static readonly Dictionary<string, SecondArgument> Arguments = new Dictionary<string, SecondArgument>();  

        public static void ParseArguments(params string[] args)
        {
            SetDefaultArguments();

            for (var i = 0; i < args.Length; i++)
            {
                try
                {
                    var value = Arguments[args[i]];

                    if (i + 1 < args.Length)
                        value(args[i + 1]);
                    else 
                        value(string.Empty);
                }

                catch (KeyNotFoundException)
                {
                    //Swallow this - didn't find the key is okay
                }
            }
        }

        private static void SetDefaultArguments()
        {
            Arguments.Add("--log", SetLoglevel);
            Arguments.Add("-l", SetLoglevel);
        }

        private static void SetLoglevel(string loglevel)
        {
            if (loglevel == "3")
                _.InfoLogImportance = _.InfoImportance.VeryImportant;
            else if (loglevel == "2")
                _.InfoLogImportance = _.InfoImportance.Important;
            else if (loglevel == "1")
                _.InfoLogImportance = _.InfoImportance.NotImportant;
            else 
                _.InfoLogImportance = _.InfoImportance.None;
        }
    }
}
