using ChTest.AI;
using ChTest.Models;
using ChTest.UI;

namespace ChTest.BoardLogic
{
    internal interface IMoveHandler
    {
        Move GetNextMove(Game game);
        MoveResult HandleMove(Game game, Move move);
    }

    internal enum MoveResult
    {
        NormalMove,
        Check,
        Mate
    }

    class MoveHandler : IMoveHandler
    {
        private readonly IMoveGenerator _moveGenerator;
        private readonly IUserMoveReader _userMoveReader;
        private readonly IMoveValidator _moveValidator;
        private readonly IBoardHandler _boardHandler;

        public MoveHandler(IMoveGenerator moveGenerator, IUserMoveReader userMoveReader, IMoveValidator moveValidator, IBoardHandler boardHandler)
        {
            _moveGenerator = moveGenerator;
            _userMoveReader = userMoveReader;
            _moveValidator = moveValidator;
            _boardHandler = boardHandler;
        }

        public Move GetNextMove(Game game)
        {
            var player = game.GetNextToMove();
            Move move;

            if (player.IsAIPlayer)
            {
                move = _moveGenerator.GenerateMove(game, player.GameSide);
            }
            else
            {
                while (true)
                {
                    move = _userMoveReader.FetchMove(player.GameSide);
                    if (_moveValidator.MoveIsValid(move, game.Board))
                        break;
                }
            }

            game.SwitchNextPlayer();
            return move;
        }

        public MoveResult HandleMove(Game game, Move move)
        {
            var existingFigure = game.Board.GetFigureOnLocation(move.To);
            if (existingFigure != null)
                game.Board.CaptureFigure(existingFigure);

            var figureToMove = game.Board.GetFigureOnLocation(move.From);
            if (figureToMove.ShouldConvert(move))
            {
                game.Board.ConvertFigure(figureToMove, move);
            }
            else
            {
                figureToMove.Move(move);
            }

            return GetMoveResult(game.Board, move.Side);
        }

        private MoveResult GetMoveResult(Board board, GameSide side)
        {
            if (_boardHandler.IsCheck(board, side))
            {
                if (_boardHandler.IsMate(board, side))
                {
                    return MoveResult.Mate;
                }
                return MoveResult.Check;
            }
            return MoveResult.NormalMove;
        }
    }
}