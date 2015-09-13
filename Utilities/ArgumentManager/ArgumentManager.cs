using System;
using System.Collections.Generic;
using _ = Utilities.InfoManager.InfoManager;

namespace Utilities.ArgumentManager
{
    public class ArgumentManager
    {
        public static _.InfoImportance VerboseMode { get; private set; }  

        private static Dictionary<string, Arguments> Arguments { get; } = new Dictionary<string, Arguments>();

        public static void ParseArguments(params string[] args)
        {
            SetDefaultArguments();

            
        }

        private static void SetDefaultArguments()
        {
            var argumentHelp =
                new Arguments("help", false, "Draws this helpful message", DrawHelptext, "-h", "--help");
            var argumentVerbose = new Arguments("verbose", true, "Sets the verbosemode of the application",
                SetVerboseMode, "-v", "--verbose");

            Arguments.Add(argumentHelp.Command, argumentHelp);
            Arguments.Add(argumentVerbose.Command, argumentVerbose);
        }

        private static void DrawHelptext()
        {
            
        }

        private static void SetVerboseMode()
        {
            try
            {
                var verboseMode = Arguments["verbose"].CommandAttribute;


            }
            catch (Exception)
            {
                //Key not found
                VerboseMode = _.InfoImportance.None;
            }
        }
    }
}
