using System;
using System.Collections.Generic;
using System.Linq;

namespace Gravitrips.Core.Players.AiStrategies
{
    public class RandomAiStrategy : IAiStrategy
    {
        private readonly Random _random = new Random();

        public Position Turn(byte[,] field)
        {
            for (var row = field.GetLength(1) - 1; row >= 0; row--)
            {
                var emptyCols = GetEmptyCols(field, row).ToList();
                if (!emptyCols.Any())
                {
                    continue;
                }

                var col = emptyCols[_random.Next(0, emptyCols.Count)];
                return new Position(col, row);
            }

            throw new NotImplementedException();
        }

        private IEnumerable<int> GetEmptyCols(byte[,] field, int row)
        {
            for (var col = 0; col < field.GetLength(0); col++)
            {
                if (field[col, row] == 0)
                {
                    yield return col;
                }
            }
        }
    }
}