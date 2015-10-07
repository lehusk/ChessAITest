using System.Collections.Generic;

namespace ChTest
{
    internal class Game
    {
        public Game()
        {
            Board = new Board();
            Moves = new List<Move>();
            Players = new List<Player>{new Player(GameSide.White), new Player(GameSide.Black)};
        }

        public Board Board { get; set; }
        public List<Move> Moves { get; set; }
        public GameSide NextToMove { get; set; }
        public List<Player> Players { get; set; } 
    }
}