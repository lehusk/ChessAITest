using System;
using ChTest.Models;

namespace ChTest.BoardLogic
{
    internal interface IBoardHandler
    {
        void Draw(Board board);
    }

    class BoardHandler : IBoardHandler
    {
        public void Draw(Board board)
        {
            for (var row = 1; row <= 8; row++)
            {
                var line = "";
                for (var col = 1; col <= 8; col++)
                {
                    var figure = board.GetFigureOnLocation(new FieldLocation(row, col));
                    if (figure == null)
                        line += " ";
                    else
                        line += figure.GetString();
                }

                Console.WriteLine(line);
            }
        }
    }
}
