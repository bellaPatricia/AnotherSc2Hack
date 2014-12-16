using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnotherSc2Hack.Classes.BackEnds
{
    public class ApplicationStartOptions
    {
        public Boolean Logging { get; set; }

        public ApplicationStartOptions()
        {
            Logging = false;
        }

        public ApplicationStartOptions(Boolean logging)
        {
            Logging = logging;
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

                    var b = false;
                    if (Boolean.TryParse(value, out b))
                    { }

                    Logging = b;
                }
            }
        }
    }
}
