using System;
using ChTest.Models;

namespace ChTest.BoardLogic
{
    internal interface IBoardHandler
    {
        void Draw(Board board);
        bool IsCheck(Board board, GameSide side);
        bool IsMate(Board board, GameSide side);
    }

    class BoardHandler : IBoardHandler
    {
        public void Draw(Board board)
        {
            for (var row = 8; row >= 1; row--)
            {
                //var line = "";
                for (var att = 0; att <= 1; att++)
                {
                    for (var col = 1; col <= 8; col++)
                    {
                        var figure = board.GetFigureOnLocation(new FieldLocation(row, col));
                        if (figure == null)
                            Console.Write("  ");
                        else
                        {
                            Console.ForegroundColor = figure.Side == GameSide.White
                                ? ConsoleColor.White
                                : ConsoleColor.DarkRed;
                            Console.Write(figure.GetString());
                            Console.Write(figure.GetString());
                        }
                        Console.Write(" ");
                    }
                    Console.WriteLine("");
                }
                Console.WriteLine();
            }
        }

        public bool IsCheck(Board board, GameSide side)
        {
            // check if any of figures is attacking opponents king
            return false;
        }

        public bool IsMate(Board board, GameSide side)
        {
            // check if opponent can make any move after which his king won't be attacked
            return false;
        }
    }
}
