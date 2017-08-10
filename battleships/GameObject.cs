namespace battleships
{
    public class GameObject
    {
        public GameObject()
        {
        }

        public int difficulty { get; set; } = 3;

        public Cell[,] gameBoard;
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

        public int SubmarinesSize { get; private set; } = 1;
        public int BattleShipsSize { get; private set; } = 2;
        public int AirCraftCarriersSize { get; private set; } = 3;
    }
}