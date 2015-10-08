using ChTest.BoardLogic;
using StructureMap;

namespace ChTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjectFactory.Configure(x => x.AddRegistry<ChTestRegistry>());

            var gameHandler = ObjectFactory.GetInstance<IGameHandler>();

            // get and generate moves + draw board
            gameHandler.StartGame();
        }
    }
}
