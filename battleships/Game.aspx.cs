using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace battleships
{
    public partial class Game : System.Web.UI.Page
    {
        public static int difficulty = 1;

        public static Cell[,] gameBoard;
        private int gameSize;

        public int SuccessfulHits { get; private set; }
        public int NumberOfAttempts { get; private set; }

        // public static List<Ship> ships = new List<Ship>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayBoard();

                if (Request["action"] != null)

                {
                    string request = Request["action"];

                    if (request == "CheckCell")
                    {
                        if (Request["x"] != null && Request["y"] != null)
                        {
                            CheckCell(Convert.ToInt32(Request["x"]), Convert.ToInt32(Request["y"]));
                        }
                    }
                }
            }
        }

        protected void CheckCell(int x, int y)
        {
            for (int coordY = 0; coordY < gameSize; coordY++)
            {
                for (int coordX = 0; coordX < gameSize; coordX++)
                {
                    if (gameBoard[coordX, coordY].IsBoat)
                    {
                        SuccessfulHits++;
                        NumberOfAttempts++;
                    }
                }
            }
        }

        //protected void GenerateShips()
        //{
        //    if (difficulty == 1)
        //    {
                
        //        //int[] Coordinate = new int[2] { 2, 3 };
        //        //ships.Add(
        //        //    new Ship(
        //        //        new int[,] 
        //        //        { 
        //        //            { 2, 3 }
        //        //        }));
        //    }
        //}

        protected void SetupGame()
        {
            switch (difficulty)
            {
                case 1:
                    gameSize = 15;
                    break;
                case 2:
                    gameSize = 20;
                    break;
                case 3:
                    gameSize = 30;
                    break;
                default:
                    gameSize = 15;
                    break;
            }

            for (int y = 0; y < gameSize; y++)
            {
                for (int x = 0; x < gameSize; x++)
                {
                    if (x == 10 && y == 2)
                    {
                        gameBoard[x, y] = new Cell();
                        gameBoard[x, y].IsBoat = true;
                    }
                }
            }

        }

        protected void DisplayBoard()
        {
            

            string html = "";
                for (int y = 0; y < gameSize; y++)
                {
                    
                    html += $"<tr id='{y}'>";
                    for (int x = 0; x < gameSize; x++)
                    {
                        //gameBoard.Add(new Cell());

                        //gameBoard[x, y] = 0;

                        // ships.Find(x => x.Coordinates.Find(c => { c[0] == x && c[1] == y }));

                        // todo check against shiplist
                        //ShipList.foreach()

                        html += $"<td id='{x}' onClick='checkCell({x}, {y})'></td>";
                    }
                    html += "</tr>";
            }

            gameLiteral.Text = html;
        }
    }
}