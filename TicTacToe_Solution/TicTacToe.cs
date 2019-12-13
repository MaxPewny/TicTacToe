using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe_Solution
{
    public class TicTacToe : IGame
    {
        private const int width = 3;
        private const int height = 3;

        private Field[,] fields = new Field[width, height];

        private Field actPlayer = Field.CROSS;

        public Field this[Move indexer] 
        {
            get { return fields[indexer.x, indexer.y]; }
            set { fields[indexer.x, indexer.y] = value; }
        }

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

 
        private IEnumerable<IEnumerable<Move>> GetRows()
        {
            for (int i = 0; i < height; i++)
            {
                yield return GetLine(new Move(0,i), new Move(1, i), new Move(2, i));
            }
        }
        private IEnumerable<IEnumerable<Move>> GetColumns()
        {
            for (int i = 0; i < width; i++)
            {
                yield return GetLine(new Move(i, 0), new Move(i, 1), new Move(i, 2));
            }
        }
        private IEnumerable<IEnumerable<Move>> GetDiagonals() 
        {
            yield return GetLine(new Move(0, 0), new Move(1, 1), new Move(2, 2));
            yield return GetLine(new Move(0, 2), new Move(1, 1), new Move(2, 0));
        }

        private IEnumerable<Move> GetLine(Move pMove1, Move pMove2, Move pMove3) 
        {
            yield return pMove1;
            yield return pMove2;
            yield return pMove3;
        }

        public Winner GetWinner()
        {
            Field mWinner = Field.CROSS;

            for (int i = 0; i < 2; i++)
            {
                if (GetRows()
                    .Concat(GetColumns())
                    .Concat(GetDiagonals())
                    .Any(line => line.All(field => this[field] == mWinner))
                    )
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

            if (GetMoves().Count() > 0)
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

        public IEnumerable<Move> GetMoves() 
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (fields[i,j] == Field.EMPTY)
                    {
                        yield return new Move(i,j);
                    
                    }
                }
            }            
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

            mTicTacToe[pMove] = actPlayer;

            return mTicTacToe;

        }


    }
}
