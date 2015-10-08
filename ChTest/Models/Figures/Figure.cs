using System.Collections.Generic;

namespace ChTest.Models.Figures
{
    internal abstract class Figure : ICanMove
    {
        protected Figure(GameSide side, int row, int col)
        {
            Side = side;
            Location = new FieldLocation(row, col);
        }

        public GameSide Side { get; set; }
        public FieldLocation Location { get; set; }
        public Board Board { get; set; }
        public abstract List<FieldLocation> GetFieldsICanMoveTo();
        public abstract string GetString();

        public bool CanMoveToLocation(FieldLocation to)
        {
            return GetFieldsICanMoveTo().Contains(to);
        }

        public bool ShouldConvert(Move move)
        {
            return false;
        }

        public void Move(Move move)
        {
            Location = move.To;
        }
    }

    internal interface ICanMove
    {
        List<FieldLocation> GetFieldsICanMoveTo();
    }
}