using System.Collections.Generic;

namespace battleships
{
    public class Ship
    {
        public List<int[]> Coordinates { get; set; }

        public Ship(int[,] coordinates)
        {
            //Coordinates.Add(coordinate);
            for (int i = 0; i < coordinates.Length; i++)
            {
                Coordinates.Add(Coordinates[i]);
            }
        }
    }
}