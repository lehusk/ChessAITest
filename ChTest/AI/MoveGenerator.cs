using System.Collections.Generic;
using System.Linq;
using ChTest.BoardLogic;
using ChTest.Models;

namespace ChTest.AI
{
    interface IMoveGenerator
    {
        Move GenerateMove(Game game, GameSide gameSide);
    }

    class MoveGenerator : IMoveGenerator
    {
        private readonly IMoveValidator _moveValidator;
        private readonly IMoveSelector _moveSelector;

        public MoveGenerator(IMoveValidator moveValidator, IMoveSelector moveSelector)
        {
            _moveValidator = moveValidator;
            _moveSelector = moveSelector;
        }

        public Move GenerateMove(Game game, GameSide gameSide)
        {
            var availableMoves = GetAllAvailableMove(game, gameSide);
            return _moveSelector.SelectBestMove(game, availableMoves);
        }

        private List<Move> GetAllAvailableMove(Game game, GameSide gameSide)
        {
            var availableMoves = new List<Move>();

            foreach (var figure in game.Board.Figures.Where(x => x.Side == gameSide))
            {
                var allMovesForFigure = figure.GetFieldsICanMoveTo();
                foreach (var locationToMoveTo in allMovesForFigure)
                {
                    var move = new Move(figure.Location, locationToMoveTo, gameSide);
                     if (_moveValidator.MoveIsValid(move,game.Board))
                         availableMoves.Add(move);
                }
            }

            return availableMoves;
        }
    }
}
