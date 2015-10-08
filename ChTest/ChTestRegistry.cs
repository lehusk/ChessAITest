using ChTest.AI;
using ChTest.BoardLogic;
using ChTest.UI;
using StructureMap.Configuration.DSL;

namespace ChTest
{
    public class ChTestRegistry : Registry
    {
        public ChTestRegistry()
        {
            For<IGameBuilder>().Use<GameBuilder>();
            For<IGameHandler>().Use<GameHandler>();
            For<IMoveHandler>().Use<MoveHandler>();
            For<IBoardHandler>().Use<BoardHandler>();
            For<IBoardBuilder>().Use<BoardBuilder>();
            For<IMoveGenerator>().Use<MoveGenerator>();
            For<IUserMoveReader>().Use<UserMoveReader>();
            For<IMoveValidator>().Use<MoveValidator>();
            For<IMoveSelector>().Use<MoveSelector>();
            For<IMoveEvaluator>().Use<MoveEvaluator>();
        }
    }
}