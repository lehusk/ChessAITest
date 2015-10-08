using ChTest.AI;
using ChTest.Models;
using ChTest.UI;

namespace ChTest.BoardLogic
{
    internal interface IMoveHandler
    {
        Move GetNextMove(Game game);
        MoveResult HandleMove(Game game);
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

        public MoveHandler(IMoveGenerator moveGenerator, IUserMoveReader userMoveReader, IMoveValidator moveValidator)
        {
            _moveGenerator = moveGenerator;
            _userMoveReader = userMoveReader;
            _moveValidator = moveValidator;
        }

        public Move GetNextMove(Game game)
        {
            var player = game.GetNextToMove();
            Move move;

            if (player.IsAIPlayer)
            {
                move = _moveGenerator.GenerateMove(game);
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

        public MoveResult HandleMove(Game game)
        {
            throw new System.NotImplementedException();
        }
    }
}