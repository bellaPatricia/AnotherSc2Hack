using System.CodeDom;

namespace AnotherSc2Hack.Classes.DataStructures.Offsets
{
    public class OffsetStructure
    {
        public int Offset { get; private set; }
        public int ByteLength { get; private set; }

        public OffsetStructure(int offset, int byteLength)
        {
            Offset = offset;
            ByteLength = byteLength;
        }

        public static implicit operator OffsetStructure(int offset)
        {
            return new OffsetStructure(offset, 4);
        }

        public static implicit operator int(OffsetStructure offset)
        {
            return offset.Offset;
        }

        public static int operator +(int operant, OffsetStructure offsetStructure)
        {
            return offsetStructure.Offset + operant;
        }

        public static int operator +(OffsetStructure operant, OffsetStructure offsetStructure)
        {
            return offsetStructure.Offset + operant.Offset;
        }

        public static int operator *(int operant, OffsetStructure offsetStructure)
        {
            return offsetStructure.Offset * operant;
        }
    }
}
