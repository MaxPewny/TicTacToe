using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe_Solution
{
    public interface IAi
    {
        Move SelectMove(IGame game);
    }
}
