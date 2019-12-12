using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe_Solution
{
    class RandomAI : IAi
    {
        Random rand = new Random();

        public Move SelectMove(IGame game)
        {
            IList<Move> mMoves = game.GetMoves();
            int mSelect = rand.Next(0, mMoves.Count);
            return mMoves[mSelect];
        }
    }
}
