using System;

namespace TicTacToe_Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToe mTicTacToe = new TicTacToe();
            RandomAI mRandomAI = new RandomAI();
            ConsoleUI mUI = new ConsoleUI(mTicTacToe, mRandomAI);
            mUI.Play();
        }
    }
}
