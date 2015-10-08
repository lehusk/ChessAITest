using System.Collections.Generic;
using ChTest.Models;
using ChTest.Models.Figures;

namespace ChTest.BoardLogic
{
    internal interface IBoardBuilder
    {
        Board CreateNewBoard();
    }

    class BoardBuilder : IBoardBuilder
    {
        public Board CreateNewBoard()
        {
            var board = new Board();
            board.Figures = new List<Figure>();
            for (var row = 1; row <= 8; row++)
            {
                for (var col = 1; col <= 8; col++)
                {
                    var figureToGive = GetFigureToGive(row, col);
                    if (figureToGive != null)
                    {
                        figureToGive.Board = board;
                        board.Figures.Add(figureToGive);
                    }
                }
            }

            return board;
        }

        private Figure GetFigureToGive(int row, int col)
        {
            if (row == 2)
                return new Pawn(GameSide.White, row, col);
            if (row == 7)
                return new Pawn(GameSide.Black, row, col);
            if (row == 1 || row == 8)
            {
                var side = row == 1 ? GameSide.White : GameSide.Black;
                if (col == 1 || col == 8) return new Rook(side, row, col);
                if (col == 2 || col == 7) return new Knight(side, row, col);
                if (col == 3 || col == 6) return new Bishop(side, row, col);
                if (col == 4) return new Queen(side, row, col);
                if (col == 5) return new King(side, row, col);
            }
            return null;
        }
    }
}