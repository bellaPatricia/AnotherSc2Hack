using System;

namespace Utilities.ApplicationStartOptions
{
    public class ApplicationStartOptions
    {
        public static bool Logging { get; private set; }

        public static void ParseStartupArguments(string[] args)
        {
            foreach (var s in args)
            {
                if (s == null)
                    continue;

                if (s.ToLower().StartsWith("logging="))
                {
                    var value = s.Substring("logging=".Length);

                    bool b;
                    if (bool.TryParse(value, out b))
                    { }

                    Logging = b;
                }
            }
        }

        internal ApplicationStartOptions(string[] args)
        {
            
        }
    }
}
