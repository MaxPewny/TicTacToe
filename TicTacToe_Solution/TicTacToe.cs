using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe_Solution
{
    public class TicTacToe : IGame
    {
        private const int width = 3;
        private const int height = 3;

        private Field[,] fields = new Field[width, height];

        private Field actPlayer = Field.CROSS;

        public TicTacToe() 
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    fields[i,j] = Field.EMPTY;

                }
            }
        }

        /*private int CheckMoves() 
        {
        }
        private Winner CheckHorizontal()
        {
        }
        private Winner CheckVertical()
        {
        }
        private Winner CheckDiagonal() 
        {
        }*/

        public Winner GetWinner() 
        {
            Field mWinner = Field.CROSS;

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (fields[j,0] == mWinner && fields[j,1] == mWinner && fields[j,2] == mWinner)
                    {
                        if (mWinner == Field.CROSS)
                        {
                            return Winner.CROSS;
                        }
                        else
                        {
                            return Winner.CIRCLE;
                        }
                    }
                }

                for (int j = 0; j < width; j++)
                {
                    if (fields[0,j] == mWinner && fields[1,j] == mWinner && fields[2,j] == mWinner)
                    {
                        if (mWinner == Field.CROSS)
                        {
                            return Winner.CROSS;
                        }
                        else
                        {
                            return Winner.CIRCLE;
                        }
                    }
                }

                if (fields[0,0] == mWinner && fields[1,1] == mWinner && fields[2,2] == mWinner)
                {
                    if (mWinner == Field.CROSS)
                    {
                        return Winner.CROSS;
                    }
                    else
                    {
                        return Winner.CIRCLE;
                    }
                }

                if (fields[2,0] == mWinner && fields[1,1] == mWinner && fields[0,2] == mWinner)
                {
                    if (mWinner == Field.CROSS)
                    {
                        return Winner.CROSS;
                    }
                    else
                    {
                        return Winner.CIRCLE;
                    }
                }

                mWinner = Field.CROSS;
            }

            if (GetMoves().Count > 0)
            {
                return Winner.NO_WINNER;
            }
            else
            {
                return Winner.REMIS;
            }
        }

        public Field GetActPlayer()
        {
            return actPlayer;
        }

        public IList<Move> GetMoves() 
        {
            IList<Move> mMove = new List<Move>();

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (fields[i,j] == Field.EMPTY)
                    {
                        mMove.Add(new Move(i,j));
                    
                    }

                }
            }

            return mMove;

            
        }

        public String OutputToString()
        {
            System.Text.StringBuilder mOutString = new System.Text.StringBuilder();
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    mOutString.Append(fields[i,j]);
                    if (j < 2)
                    {
                        mOutString.Append("|");
                    }
                }

                mOutString.Append("\n");

               
                
                   
                
            }
            return mOutString.ToString();
        }

        public TicTacToe ApplyMove(Move pMove) 
        {
            TicTacToe mTicTacToe = new TicTacToe();
            if (actPlayer == Field.CROSS)
            {
                mTicTacToe.actPlayer = Field.CIRCLE;
            }
            else
            {
                mTicTacToe.actPlayer = Field.CROSS;
            }

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    mTicTacToe.fields[i,j] = fields[i,j];
                }
                
            }

            mTicTacToe.fields[pMove.GetX(), pMove.GetY()] = actPlayer;

            return mTicTacToe;

        }


    }
}
