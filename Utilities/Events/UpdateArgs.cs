using System;

namespace Utilities.Events
{
    public delegate void UpdateChangeHandler(object sender, UpdateArgs e);
    public class UpdateArgs : EventArgs
    {
        public string UpdateName { get; set; }
        public string OldVersion { get; set; }
        public string NewVersion { get; set; }

        public UpdateArgs(string updateName, string oldVersion, string newVersion)
        {
            UpdateName = updateName;
            OldVersion = oldVersion;
            NewVersion = newVersion;
        }
    }
}
