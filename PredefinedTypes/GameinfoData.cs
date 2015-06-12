using System;

namespace PredefinedTypes
{
    [Serializable]
    public class Gameinformation
    {
        public int Timer { get; set; }
        public bool IsIngame { get; set; }
        public int Fps { get; set; }
        public Gametype Type { get; set; }
        public Gamespeed Speed { get; set; }
        public WindowStyle Style { get; set; }
        public string ChatInput { get; set; }
        public bool ChatIsOpen { get; set; }
        public bool IsTeamcolor { get; set; }
        public int ValidPlayerCount { get; set; }
        public bool Pause { get; set; }
    };

    public enum Gamespeed
    {
        Slower = 426,
        Slow = 320,
        Normal = 256,
        Fast = 213,
        Faster = 182,
        Fasterx2 = 91,
        Fasterx4 = 45,
        Fasterx8 = 22
    };

    public enum WindowStyle
    {
        WindowedFullscreen = 262144,
        Windowed = 262400,
        Fullscreen = 262152
    };

    public enum Gametype
    {
        None = 0,
        Replay = 1,
        Challange = 2,
        VersusAi = 3,
        Ladder = 4
    };
}
