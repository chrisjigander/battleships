namespace battleships
{
    public class Cell
    {
        public bool IsBoat { get; set; }
        public bool IsUsed { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}