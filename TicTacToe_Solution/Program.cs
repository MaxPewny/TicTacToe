using System;

namespace TicTacToe_Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToe mTicTacToe = new TicTacToe();
            ConsoleUI mUI = new ConsoleUI(mTicTacToe);
            mUI.Play();
        }
    }
}
