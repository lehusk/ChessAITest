using System.Collections.Generic;

namespace ChTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
        }
    }

    internal class Player
    {
        public GameSide GameSide { get; set; }

        public Player(GameSide gameSide)
        {
            GameSide = gameSide;
        }
    }

    internal class Move
    {
        public FieldLocation From { get; set; }
        public FieldLocation To { get; set; }
    }

    internal class FieldLocation
    {
        public int Row { get; set; }
        public int Column { get; set; }
    }

    internal enum GameSide
    {
        White,
        Black
    }

    internal class Board
    {
        public List<Field> Fields { get; set; } 
    }
}
