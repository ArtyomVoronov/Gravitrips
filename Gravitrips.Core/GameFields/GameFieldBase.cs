using System;
using System.Collections.Generic;

namespace Gravitrips.Core.GameFields
{
    public abstract class GameFieldBase
    {
        public abstract int RowsCount { get; }
        public abstract int ColumnsCount { get; }
        public abstract int LineLength { get; }

        public byte[,] Field { get; private set; }

        public List<Position> WinLine { get; private set; }

        public void Initialize()
        {
            Field = new byte[ColumnsCount, RowsCount];
            WinLine = new List<Position>();
        }

        public bool IsTurnPossible(int col, int row)
        {
            if (Field[col, row] != 0)
            {
                return false;
            }

            // Player can't turn if previous row is empty
            if (row < RowsCount - 1 && Field[col, row + 1] == 0)
            {
                return false;
            }

            return true;
        }

        public void Turn(int col, int row, byte playerId)
        {
            Field[col, row] = playerId;
        }

        public void Clear()
        {
            Array.Clear(Field, 0, Field.Length);
            WinLine.Clear();
        }

        public abstract bool CheckGameFinished();
    }
}