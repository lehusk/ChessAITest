using ChTest.Models;

namespace ChTest.AI
{
    interface IMoveGenerator
    {
        Move GenerateMove(Game game);
    }

    class MoveGenerator : IMoveGenerator
    {
        public Move GenerateMove(Game game)
        {
            throw new System.NotImplementedException();
        }
    }
}
