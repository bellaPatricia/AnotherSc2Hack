using System;

namespace PredefinedTypes
{
    [Serializable]
    public struct Map
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
        public int PlayableWidth;
        public int PlayableHeight;
    };
}
