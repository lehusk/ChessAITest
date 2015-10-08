using System.Collections.Generic;
using System.Linq;

namespace ChTest.Models.Figures
{
    internal class Pawn : Figure
    {
        public Pawn(GameSide side, int col, int row) : base(side, col, row)
        {
            
        }

        public override List<FieldLocation> GetFieldsICanMoveTo()
        {
            var attackingFields = new List<FieldLocation>();
            
            var rowMod = Side == GameSide.White ? 1 : -1;

            attackingFields.Add(new FieldLocation(Location.Row + rowMod, Location.Column - 1));
            attackingFields.Add(new FieldLocation(Location.Row + rowMod, Location.Column + 1));

            var moveField = new FieldLocation(Location.Row + rowMod, Location.Column);
            
            var validFields = new List<FieldLocation>();
            if (Board.GetFigureOnLocation(moveField) == null)
            {
                validFields.Add(moveField);
                if ((Location.Row == 2 && Side == GameSide.White) || (Location.Row == 7 && Side == GameSide.Black))
                {
                    var moveTwoField = new FieldLocation(Location.Row + 2*rowMod, Location.Column);
                    if (Board.GetFigureOnLocation(moveTwoField) == null)
                        validFields.Add(moveTwoField);
                }
            }

            validFields.AddRange(attackingFields.Where(x =>
            {
                var figure = Board.GetFigureOnLocation(x);
                return figure != null && figure.Side != Side;
            }));
            return validFields;
        }

        public override string GetString()
        {
            return "P";
        }
    }
}