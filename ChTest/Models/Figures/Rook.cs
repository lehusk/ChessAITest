using System;
using System.Collections.Generic;
using System.Linq;

namespace ChTest.Models.Figures
{
    internal class Rook : Figure
    {
        public Rook(GameSide side, int col, int row)
            : base(side, col, row)
        {

        }

        public override List<FieldLocation> GetFieldsICanMoveTo()
        {
            return Board.ValidFieldLocations.Where(x =>
                            (x.Column != Location.Column || x.Row != Location.Row) &&
                            (x.Column == Location.Column || x.Row == Location.Row)
                            ).ToList();
        }

        public override string GetString()
        {
            return "R";
        }
    }
}