using System;
using System.Collections.Generic;

namespace Utilities.ArgumentManager
{
    public class Arguments
    {
        public string Command { get; set; }
        public string CommandAttribute { get; set; }
        public bool HasCommandAttribute { get; set; }
        public string Help { get; set; }
        public Action Function { get; set; }
        public List<string> Alias { get; set; } = new List<string>();
        
        public Arguments(string command, bool hasCommandAttribute, string help, Action function, params string[] alias)
        {
            Command = command;
            HasCommandAttribute = hasCommandAttribute;
            Help = help;
            Function = function;
            Alias.AddRange(alias);
        }
    }
}
