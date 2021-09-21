using System;
using UnityEngine;

namespace GameLogic
{
    public class GameLogics 
    {
        public bool MoveBeadRight(int from, int to)
        {
            bool allow = BeadMoveAllowPositon(from, to);
            if (allow==true)
            {
                int[] getposFrom = GetRowAndColum(from);
                int[] getposTo = GetRowAndColum(to);

                int fromRow = getposFrom[0];
                int fromCol = getposFrom[1];

                int toRow = getposTo[0];
                int toCol = getposTo[1];

                int fromValu = PosValu(fromRow, fromCol);
                int toValu = PosValu(toRow, toCol);

                bool x = Active(fromValu);
                bool y = Active(toValu);

                if (x==true)
                {
                    return false;
                }
                else
                {
                    if (y==true)
                    {
                        LogicData.BoardFormet[fromRow, fromCol] = toValu;
                        LogicData.BoardFormet[toRow, toCol] = fromValu;
                        if (LogicData.isBottomPlayerMove == true)
                        {
                            LogicData.isBottomPlayerMove = false;
                        }
                        else
                        {
                            LogicData.isBottomPlayerMove = true;
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                   
                }


            }
            else
            {
                return false;
            }
        }
        //allow RightPositionMove
        private bool BeadMoveAllowPositon(int frompos, int topos)
        {
            if (frompos < 0 || frompos > 8 || topos < 0 || topos > 8)
            {
                return false;
            }
            int[] MyGotoPoss = LogicData.GotoPos[frompos];
            int index = Array.IndexOf(MyGotoPoss, topos);
            return index != -1;
        }
        //cheak game end 
        internal int IsGameOver(int[,] board)
        {
            
            int logic1 = board[0, 0] * board[1, 1] * board[2, 2];
            int logic2 = board[0, 2] * board[1, 1] * board[2, 0];
            int Logic3 = board[1, 0] * board[1, 1] * board[1, 2];
            int Logic4 = board[0, 0] * board[1, 0] * board[2, 0];
            int Logic5 = board[0, 1] * board[1, 1] * board[2, 1];
            int Logic6 = board[0, 2] * board[1, 2] * board[2, 2];

            if (logic1 == 1 || logic2 == 1 || Logic3 == 1 || Logic4 == 1 || Logic5 == 1 || Logic6 == 1)
            {
                return LogicData.TopBead;
            }
            else if (logic1 == 8 || logic2 == 8 || Logic3 == 8 || Logic4 == 8 || Logic5 == 8 || Logic6 == 8)
            {
                return LogicData.DownBead;
            }
            else
            {
                return LogicData.Empty;
            }

        }
        private bool Active(int valu)
        {
            if (valu == LogicData.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private int[] GetRowAndColum(int number)
        {
            int colum = (number % 3);
            int row = (number - colum) / 3;
            int[] array = new int[] { row, colum };
            return array;
        }

        private int PosValu(int row, int colum)
        {
            int positionValu = LogicData.BoardFormet[row, colum];
            return positionValu;
        }

    }
}

