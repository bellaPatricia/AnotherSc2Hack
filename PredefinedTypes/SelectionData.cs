using System;

namespace PredefinedTypes
{
    [Serializable]
    public class Selection
    {
        public static short HighlightedType { get; set; }
        public int AmountSelectedUnits { get; set; }
        public int AmountSelectedTypes { get; set; }
        public int UnitType { get; set; }
        public int UnitIndex { get; set; }
        public Unit Unit { get; set; }
    };
}
