using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe_Solution
{
    public class TicTacToe
    {
        private const int width = 3;
        private const int height = 3;
        private const int size = width * height;

        private Field[] fields = new Field[size];

        private Field actPlayer = Field.CROSS;

        public TicTacToe() 
        {
            for (int i = 0; i < size; i++)
            {
                fields[i] = Field.EMPTY;
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

            int mMoveCount = 0;

            for (int i = 0; i < size; i++)
            {
                if (fields[i] == Field.EMPTY)
                {
                    ++mMoveCount;
                }
            }
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (fields[j*3] == mWinner && fields[j*3+1] == mWinner && fields[j*3+2] == mWinner)
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
                    if (fields[j] == mWinner && fields[j + 3] == mWinner && fields[j + 6] == mWinner)
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

                if (fields[0] == mWinner && fields[4] == mWinner && fields[8] == mWinner)
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

                if (fields[2] == mWinner && fields[4] == mWinner && fields[6] == mWinner)
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

            if (GetMoves().Length > 0)
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

        public int[] GetMoves() 
        {
            int mMoveCount = 0;

            for (int i = 0; i < size; i++)
            {
                if (fields[i] == Field.EMPTY)
                {
                    ++mMoveCount;
                }
            }

            int[] mMove = new int[mMoveCount];

            for (int i = 0; i < size; i++)
            {
                if (fields[i] == Field.EMPTY)
                {
                    --mMoveCount;
                    mMove[mMoveCount] = i;
                    
                }
                if (mMoveCount < 0)
                {
                    break;
                }
            }

            return mMove;

            
        }

        public String OutputToString()
        {
            System.Text.StringBuilder mOutString = new System.Text.StringBuilder();
            for (int i = 0; i < size; i++)
            {
                mOutString.Append(fields[i]);

                if (i == 2 || i == 5 || i == 8)
                {
                    mOutString.Append("\n");
                }
                else
                {
                    mOutString.Append("|");
                }
            }
            return mOutString.ToString();
        }

        public TicTacToe ApplyMove(int pMove) 
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

            for (int i = 0; i < size; i++)
            {
                mTicTacToe.fields[i] = fields[i];
            }

            mTicTacToe.fields[pMove] = actPlayer;

            return mTicTacToe;

        }


    }
}
