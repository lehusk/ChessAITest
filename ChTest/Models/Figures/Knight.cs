using System;
using System.Collections.Generic;
using System.Linq;

namespace ChTest.Models.Figures
{
    internal class Knight : Figure
    {
        public Knight(GameSide side, int col, int row)
            : base(side, col, row)
        {

        }

        public override List<FieldLocation> GetFieldsICanMoveTo()
        {
            return Board.ValidFieldLocations.Where(x =>
                            (x.Column != Location.Column || x.Row != Location.Row) &&
                            (
                              (Math.Abs(x.Column - Location.Column) == 1 && Math.Abs(x.Row - Location.Row) == 2) ||
                              (Math.Abs(x.Column - Location.Column) == 2 && Math.Abs(x.Row - Location.Row) == 1)
                            )
                            ).ToList();
        }

        public override string GetString()
        {
            return "N";
        }
    }
}