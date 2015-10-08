using System;

namespace ChTest.Models
{
    internal class FieldLocation : IEquatable<FieldLocation>
    {
        public FieldLocation(int row, int col)
        {
            Row = row;
            Column = col;
        }

        public int Row { get; set; }
        public int Column { get; set; }
        public bool Equals(FieldLocation other)
        {
            return other.Column == this.Column && other.Row == this.Row;
        }
    }
}