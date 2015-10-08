using System.Collections.Generic;
using ChTest.Models;

namespace ChTest.BoardLogic
{
    interface IGameBuilder
    {
        Game CreateNewGame();
    }

    class GameBuilder : IGameBuilder
    {
        private readonly IBoardBuilder _boardBuilder;

        public GameBuilder(IBoardBuilder boardBuilder)
        {
            _boardBuilder = boardBuilder;
        }

        public Game CreateNewGame()
        {
            var game = new Game();
            
            game.Players = new List<Player> { new Player(GameSide.White), new Player(GameSide.Black) };
            game.Board = _boardBuilder.CreateNewBoard();
            return game;
        }
    }
}
