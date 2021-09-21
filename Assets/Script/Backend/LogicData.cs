namespace GameLogic
{
    public static class LogicData
    {
        internal static bool isBottomPlayerMove = true;

        internal static readonly int[,] BoardFormet=
        {
            { 1,1,1},
            { 0,0,0},
            { 2,2,2}
        };

        internal static readonly int[][] GotoPos =
        {
            new int[] { 1, 3, 4 },
            new int[] { 0, 2, 4 },
            new int[] { 1, 5, 4 },

            new int[] { 0, 6, 4 },
            new int[] { 0, 1, 2, 3, 5, 6, 7, 8 },
            new int[] { 2, 8, 4 },

            new int[] { 3, 7, 4 },
            new int[] { 6, 8, 4 },
            new int[] { 7, 5, 4 }
        };

        internal const int Empty = 0, TopBead = 1, DownBead=2;

        internal const float MoveTime = 0.4f;
    }
}

