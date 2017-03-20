using System.Collections.Generic;

namespace Gravitrips.Core
{
    public static class Utils
    {
        public static IEnumerable<T> SliceRow<T>(T[,] array, int col, int row, int lineLength)
        {
            for (var i = 0; i < lineLength; i++)
            {
                yield return array[col + i, row];
            }
        }

        public static IEnumerable<T> SliceColumn<T>(T[,] array, int col, int row, int lineLength)
        {
            for (var i = 0; i < lineLength; i++)
            {
                yield return array[col, row - i];
            }
        }

        public static IEnumerable<T> SliceRightDiaglonal<T>(T[,] array, int col, int row, int lineLength)
        {
            for (var i = 0; i < lineLength; i++)
            {
                yield return array[col + i, row - i];
            }
        }

        public static IEnumerable<T> SliceLeftDiaglonal<T>(T[,] array, int col, int row, int lineLength)
        {
            for (var i = 0; i < lineLength; i++)
            {
                yield return array[col + i, row + i];
            }
        }
    }
}
