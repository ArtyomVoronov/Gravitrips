namespace Gravitrips.Core
{
    public class Position
    {
        public Position() {}

        public Position(int col, int row)
        {
            Column = col;
            Row = row;
        }

        public int Column { get; set; }

        public int Row { get; set; }
    }
}