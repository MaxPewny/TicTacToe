using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe_Solution
{
    public interface IGame
    {
        Winner GetWinner();

        Field GetActPlayer();

        IEnumerable<Move> GetMoves();

        String OutputToString();

        TicTacToe ApplyMove(Move pMove);
    }
}
