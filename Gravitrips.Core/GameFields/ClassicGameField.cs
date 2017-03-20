using System.Linq;

namespace Gravitrips.Core.GameFields
{
    public class ClassicGameField : GameFieldBase
    {
        public override int RowsCount => 6;
        public override int ColumnsCount => 7;
        public override int LineLength => 4;

        public override bool CheckGameFinished()
        {
            for (var col = 0; col < ColumnsCount; col++)
            {
                // Skip blank columns
                if (Field[col, RowsCount - 1] == 0)
                {
                    continue;
                }

                // Check vertical axis
                for (var row = RowsCount - 1; row >= LineLength - 1; row--)
                {
                    if (Field[col, row] == 0)
                    {
                        break;
                    }

                    var vertical = Utils.SliceColumn(Field, col, row, LineLength).ToArray();
                    if (IsWin(vertical))
                    {
                        for (var i = 0; i < LineLength; i++)
                        {
                            WinLine.Add(new Position(col, row - i));
                        }
                        return true;
                    }

                    if (col <= ColumnsCount - LineLength)
                    {
                        var diagonal = Utils.SliceRightDiaglonal(Field, col, row, LineLength).ToArray();
                        if (IsWin(diagonal))
                        {
                            for (var i = 0; i < LineLength; i++)
                            {
                                WinLine.Add(new Position(col + i, row - i));
                            }
                            return true;
                        }
                    }
                }

                // Check horizontal axis
                if (col <= ColumnsCount - LineLength)
                {
                    for (var row = RowsCount - 1; row >= 0; row--)
                    {
                        if (Field[col, row] == 0)
                        {
                            break;
                        }

                        var horizonal = Utils.SliceRow(Field, col, row, LineLength).ToArray();
                        if (IsWin(horizonal))
                        {
                            for (var i = 0; i < LineLength; i++)
                            {
                                WinLine.Add(new Position(col + i, row));
                            }
                            return true;
                        }

                        if (row <= RowsCount - LineLength)
                        {
                            var diagonal = Utils.SliceLeftDiaglonal(Field, col, row, LineLength).ToArray();
                            if (IsWin(diagonal))
                            {
                                for (var i = 0; i < LineLength; i++)
                                {
                                    WinLine.Add(new Position(col + i, row + i));
                                }

                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        private bool IsWin(byte[] line)
        {
            if (!line.Any())
            {
                return false;
            }
            var first = line.First();
            return line.Skip(1).All(e => e.Equals(first));
        }
    }
}
