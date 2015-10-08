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
        public Move SelectBestMove(Game game, List<Move> availableMoves)
        {
            throw new System.NotImplementedException();
        }
    }
}
