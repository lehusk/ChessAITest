using ChTest.Models;

namespace ChTest.AI
{
    interface IMoveEvaluator
    {
        int EvaluateMove(Game game, Move move);
    }

    class MoveEvaluator : IMoveEvaluator
    {
        public int EvaluateMove(Game game, Move move)
        {
            throw new System.NotImplementedException();
        }
    }
}
