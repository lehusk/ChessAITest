using System;
using ChTest.Models;

namespace ChTest.BoardLogic
{
    interface IMoveValidator
    {
        bool MoveIsValid(Move move, Board board);
    }

    class MoveValidator : IMoveValidator
    {
        public bool MoveIsValid(Move move, Board board)
        {
            if (move == null)
            {
                Console.WriteLine("parse failed");
                return false;
            }

            if (!board.IsInBoard(move))
            {
                Console.WriteLine("move not on board");
                return false;
            }
            if (!board.HasFigureForMove(move))
            {
                Console.WriteLine("no figure to move");
                return false;
            }
            if (!MoveIsAllowed(move, board))
            {
                Console.WriteLine("invalid move");
                return false;
            }

            return true;
        }

        private bool MoveIsAllowed(Move move, Board board)
        {
            var figure = board.GetFigureOnLocation(move.From);
            if (!figure.CanMoveToLocation(move.To))
                return false;

            var figureOnLocation = board.GetFigureOnLocation(move.To);
            if (figureOnLocation != null && figureOnLocation.Side == move.Side)
                return false;

            if (MoveWouldCauseCheckOnSelf(move, board))
                return false;

            return true;
        }

        private bool MoveWouldCauseCheckOnSelf(Move move, Board board)
        {
            /// TODO
            return false;
        }
    }
}
