namespace battleships
{
    public class GameObject
    {
        public GameObject()
        {
        }

        public int difficulty { get; set; } = 1;

        public Cell[,] gameBoard;
        public int GameSize { get; set; }

        public int SuccessfulHits { get; set; }
        public int NumberOfAttempts { get; set; }
    }
}