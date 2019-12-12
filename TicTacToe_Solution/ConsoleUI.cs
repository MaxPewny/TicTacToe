using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe_Solution
{
    public class ConsoleUI
    {
        private IGame status;

        private IAi ai;

        public ConsoleUI(IGame pStatus, IAi pAi) 
        {
            status = pStatus;
            ai = pAi;
        }

        private bool ApplyTurn(IList<Move> pMoves) 
        {
            if (status.GetActPlayer() == Field.CROSS)
            {
                int mMove = Int32.Parse(Console.ReadLine());
                if (mMove >= 0 && mMove < pMoves.Count)
                {
                    status = status.ApplyMove(pMoves[mMove]);
                    return true;
                }
                else 
                {
                    return false;
                }
            }
            else
            {
                status = status.ApplyMove(ai.SelectMove(status));
                return true;
            }
            
        }

        public void PlayTurn() 
        {
            bool mMatch = false;
            IList<Move> mMoves = status.GetMoves();
            Console.WriteLine(status.OutputToString());
            for (int i = 0; i < mMoves.Count; i++)
            {
                Console.Write( i + ": " + mMoves[i].GetX() + "," + mMoves[i].GetY() + " | ");
                //Console.Write("\n");
            }
            Console.WriteLine(status.GetActPlayer().ToString());
            while (mMatch == false)
            {
                mMatch = ApplyTurn(mMoves);
            }
            Console.WriteLine("______________________________________________________");
        }

        public void Play() 
        {
            while (status.GetWinner() == Winner.NO_WINNER)
            {
                PlayTurn();
            }

            if (status.GetWinner() == Winner.CROSS)
            {
                Console.WriteLine(status.OutputToString());
                Console.WriteLine("Cross won the game");
            }
            if (status.GetWinner() == Winner.CIRCLE)
            {
                Console.WriteLine(status.OutputToString());
                Console.WriteLine("Circle won the game");
            }
            if (status.GetWinner() == Winner.REMIS) 
            {
                Console.WriteLine(status.OutputToString());
                Console.WriteLine("the game ended in a Draw");
            }
        }
    }
}
