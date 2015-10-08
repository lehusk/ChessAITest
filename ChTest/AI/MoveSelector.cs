using System.Collections.Generic;
using ChTest.Models;

namespace ChTest.AI
{
    interface IMoveSelector
    {
        Move SelectBestMove(Game game, List<Move> availableMoves);
    }

    class MoveSelector : IMoveSelector
    {
        private readonly IMoveEvaluator _moveEvaluator;

        public MoveSelector(IMoveEvaluator moveEvaluator)
        {
            _moveEvaluator = moveEvaluator;
        }

        public Move SelectBestMove(Game game, List<Move> availableMoves)
        {
            var bestValue = -9999;
            Move bestMove = null;

            foreach (var move in availableMoves)
            {
                var moveScore = _moveEvaluator.EvaluateMove(game, move);
                if (bestMove == null || (moveScore > bestValue))
                {
                    bestMove = move;
                    bestValue = moveScore;
                }
            }

            return bestMove;
        }
    }
}
