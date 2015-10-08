using ChTest.Models;

namespace ChTest.BoardLogic
{
    interface IGameHandler
    {
        void StartGame();
    }

    class GameHandler : IGameHandler
    {
        private readonly IGameBuilder _gameBuilder;
        private readonly IMoveHandler _moveHandler;
        private readonly IBoardHandler _boardHandler;
        public Game Game { get; set; }

        public GameHandler(IGameBuilder gameBuilder, IMoveHandler moveHandler, IBoardHandler boardHandler)
        {
            _gameBuilder = gameBuilder;
            _moveHandler = moveHandler;
            _boardHandler = boardHandler;
            Game = null;
        }

        public void StartGame()
        {
            Game = _gameBuilder.CreateNewGame();
            _boardHandler.Draw(Game.Board);

            while (true)
            {
                var move = _moveHandler.GetNextMove(Game);
                _moveHandler.HandleMove(Game);
            }
        }
    }
}