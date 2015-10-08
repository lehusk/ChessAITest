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
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine("  a  b  c  d  e  f  g  h");
            Console.WriteLine();

            for (var row = 8; row >= 1; row--)
            {

                //var line = "";
                
                for (var att = 0; att <= 1; att++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    
                    if (att == 0) Console.Write("  ");
                    else Console.Write(row + " ");

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

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine("  a  b  c  d  e  f  g  h");
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
