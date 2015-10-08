using System.Collections.Generic;
using System.Linq;
using ChTest.Models.Figures;

namespace ChTest.Models
{
    internal class Game
    {
        public Game()
        {
            Moves = new List<Move>();
            NextToMove = GameSide.White;
        }

        public Board Board { get; set; }
        public List<Move> Moves { get; set; }
        public GameSide NextToMove { get; set; }
        public List<Player> Players { get; set; }

        public Player GetNextToMove()
        {
            return Players.FirstOrDefault(x => x.GameSide == NextToMove);
        }

        public void SwitchNextPlayer()
        {
            NextToMove = NextToMove == GameSide.Black ? GameSide.White : GameSide.Black;
        }
    }

    internal class Move
    {
        public Move(int rowFrom, int colFrom, int rowTo, int colTo, GameSide gameSide)
        {
            Side = gameSide;
            From = new FieldLocation(rowFrom, colFrom);
            To = new FieldLocation(rowTo, colTo);
        }

        public FieldLocation From { get; set; }
        public FieldLocation To { get; set; }
        public GameSide Side { get; set; }
    }

    internal class Board
    {
        public List<Figure> Figures { get; set; }
        public List<FieldLocation> ValidFieldLocations { get; set; }

        public Board()
        {
            ValidFieldLocations = GenerateValidFieldLocations();
        }

        private List<FieldLocation> GenerateValidFieldLocations()
        {
            var locations = new List<FieldLocation>();
            for (var row = 1; row <= 8; row++)
            {
                for (var column = 1; column <= 8; column++)
                {
                    locations.Add(new FieldLocation(row,column));
                }
            }
            return locations;
        }

        public Figure GetFigureOnLocation(FieldLocation fieldLocation)
        {
            return Figures.FirstOrDefault(x => x.Location.Row == fieldLocation.Row && x.Location.Column == fieldLocation.Column);
        }

        public bool IsInBoard(Move move)
        {
            return IsInBoard(move.From) && IsInBoard(move.To);
        }

        private bool IsInBoard(FieldLocation location)
        {
            return location.Column >= 1 && location.Row >= 1 && location.Column <= 8 && location.Row <= 8;
        }

        public bool HasFigureForMove(Move move)
        {
            var figureOnFrom = GetFigureOnLocation(move.From);
            return figureOnFrom != null && figureOnFrom.Side == move.Side;
        }
    }

//    internal class Field
//    {
//        public Field(int row, int col)
//        {
//            FieldLocation = new FieldLocation(row, col);
//        }
//
//        public FieldLocation FieldLocation { get; set; }
//        public Figure FigureOnField { get; set; }
//    }
}