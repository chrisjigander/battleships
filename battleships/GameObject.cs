namespace battleships
{
    public class GameClass
    {
        public GameClass()
        {
        }

        public int Difficulty { get; set; } = 3;

        public string Player { get; set; }

        public Cell[,] GameBoard;
        public int GameSize { get; set; }

        public int SuccessfulHits { get; set; }
        public int NumberOfAttempts { get; set; }

        public int HitsRequired()
        {
            return SubmarinesCount * SubmarinesSize +
                   BattleShipsCount * BattleShipsSize +
                   AirCraftCarriersCount * AirCraftCarriersSize;
        }

        public int SubmarinesCount { get; set; } = 0;
        public int BattleShipsCount { get; set; } = 0;
        public int AirCraftCarriersCount { get; set; } = 0;

        public int SubmarinesSize { get; } = 1;
        public int BattleShipsSize { get; } = 2;
        public int AirCraftCarriersSize { get; } = 3;
    }
}