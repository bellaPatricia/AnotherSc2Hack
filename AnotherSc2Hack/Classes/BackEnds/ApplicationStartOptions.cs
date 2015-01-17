using System;

namespace AnotherSc2Hack.Classes.BackEnds
{
    public class ApplicationStartOptions
    {
        public Boolean Logging { get; set; }
        public Boolean Benchmark { get; set; }

        public ApplicationStartOptions()
        {

        }

        public ApplicationStartOptions(string[] args)
        {
            foreach (var s in args)
            {
                if (s == null)
                    continue;

                if (s.ToLower().StartsWith("logging="))
                {
                    var value = s.Substring("logging=".Length);

                    bool b;
                    if (Boolean.TryParse(value, out b))
                    { }

                    Logging = b;
                }

                if (s.ToLower().StartsWith("benchmark="))
                {
                    var value = s.Substring("benchmark=".Length);

                    bool b;
                    if (Boolean.TryParse(value, out b))
                    { }

                    Benchmark = b;
                }
            }
        }
    }
}
