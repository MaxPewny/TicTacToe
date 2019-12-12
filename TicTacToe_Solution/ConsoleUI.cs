using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe_Solution
{
    public class ConsoleUI
    {
        private TicTacToe status;

        public ConsoleUI(TicTacToe pStatus) 
        {
            status = pStatus;
        }

        private bool ApplyTurn(int[] pMoves) 
        {
            int mMove = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < pMoves.Length; i++)
            {
                if (pMoves[i] == mMove)
                {
                    status = status.ApplyMove(mMove);
                    return true;
                }
            }
            return false;
        }

        public void PlayTurn() 
        {
            bool mMatch = false;
            int[] mMoves = status.GetMoves();
            Console.WriteLine(status.OutputToString());
            for (int i = 0; i < mMoves.Length; i++)
            {
                Console.Write(mMoves[i] + " | ");
                //Console.Write("\n");
            }
            Console.WriteLine(status.GetActPlayer().ToString());
            while (mMatch == false)
            {
                mMatch = ApplyTurn(mMoves);
            }
        }

        public void Play() 
        {
            while (status.GetWinner() == Winner.NO_WINNER)
            {
                PlayTurn();
            }

            if (status.GetWinner() == Winner.CROSS)
            {
                Console.WriteLine("Cross won the game");
            }
            if (status.GetWinner() == Winner.CIRCLE)
            {
                Console.WriteLine("Circle won the game");
            }
            if (status.GetWinner() == Winner.REMIS) 
            {
                Console.WriteLine("the game ended in a Draw");
            }
        }
    }
}
