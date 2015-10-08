using System;
using ChTest.Models;

namespace ChTest.UI
{
    interface IUserMoveReader
    {
        Move FetchMove(GameSide gameSide);
    }

    class UserMoveReader : IUserMoveReader
    {
        public Move FetchMove(GameSide gameSide)
        {
            var input = Console.ReadLine();

            return ParseMove(input, gameSide);
        }

        private Move ParseMove(string input, GameSide gameSide)
        {
            if (input.Length != 5)
                return null;
            var colFrom = input[0] - 'a' + 1;
            var rowFrom = input[1] - '1' + 1;
            var colTo = input[3] - 'a' + 1;
            var rowTo = input[4] - '1' + 1;

            return new Move(rowFrom, colFrom, rowTo, colTo, gameSide);
        }
    }
}
