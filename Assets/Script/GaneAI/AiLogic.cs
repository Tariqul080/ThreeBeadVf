using UnityEngine;
using System;
using GameLogic;
using ThreeBeads;


namespace GameAI
{
    public class AiLogic
    {
      //  internal readonly static Bead b1 = new Bead();
       internal static int  MoveBeadNO()
       {
            int position1 = -1, position2 = -1, position3 = -1;
            int counter = -1;
            for (int i = 0; i <3; i++)
            {
                for (int j = 0; j <3; j++)
                {
                    counter++;
                    int positionValu = LogicData.BoardFormet[i, j];
                    if (positionValu==0 || positionValu==1)
                    {
                        continue;
                    }
                    else
                    {
                        if (position1==-1)
                        {
                            position1 = counter;
                        }
                        else if (position2==-1)
                        {
                            position2 = counter;

                        }
                        else if (position3==-1)
                        {
                            position3 = counter;
                        }
                    }
                    
                }
            }
            if (position3==8)
            {
              /*  b1.bead = 1;
                b1.currentPos = 1;*/
               
            }

            return 4;
       }
    }

}
