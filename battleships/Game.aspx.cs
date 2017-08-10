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

        // public static List<Ship> ships = new List<Ship>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GameObject game = new GameObject();


                if (Session["Game"] != null)
                {
                    game = (GameObject)Session["Game"];
                } else
                {
                    //setup game
                    SetupGame(game);
                    Session["Game"] = game;
                }

                if (Request["action"] != null)

                {
                    string request = Request["action"];

                    if (request == "CheckCell")
                    {
                        if (Request["x"] != null && Request["y"] != null)
                        {
                            CheckCell(Convert.ToInt32(Request["x"]), Convert.ToInt32(Request["y"]), game);
                        }
                    }
                }

                DisplayBoard(game);
            }

        }

        protected void CheckCell(int x, int y, GameObject game)
        {
            for (int coordY = 0; coordY < game.gameSize; coordY++)
            {
                for (int coordX = 0; coordX < game.gameSize; coordX++)
                {
                    if (coordX == x && coordY == y)
                    {
                        var cell = game.gameBoard[coordX, coordY];

                        if (cell.IsBoat && !cell.IsUsed)
                        {
                            game.SuccessfulHits++;
                        }

                        cell.IsUsed = true;
                    }
                }
            }
            game.NumberOfAttempts++;
        }

        protected void SetupGame(GameObject game)
        {
            switch (game.difficulty)
            {
                case 1:
                    game.gameSize = 15;
                    break;
                case 2:
                    game.gameSize = 20;
                    break;
                case 3:
                    game.gameSize = 30;
                    break;
                default:
                    game.gameSize = 15;
                    break;
            }

            game.gameBoard = new Cell[game.gameSize, game.gameSize];

            for (int y = 0; y < game.gameSize; y++)
            {
                for (int x = 0; x < game.gameSize; x++)
                {
                    game.gameBoard[x, y] = new Cell();

                    // todo: randomize boat loactions instead
                    if (x == 10 && y == 2)
                    {
                        game.gameBoard[x, y].IsBoat = true;
                    } else if (x == 2 && y == 2)
                    {
                        game.gameBoard[x, y].IsBoat = true;
                    }
                }
            }

        }

        protected void DisplayBoard(GameObject game)
        {
            string html = "";
            for (int y = 0; y < game.gameSize; y++)
            {        
                html += $"<tr id='{y}'>";
                for (int x = 0; x < game.gameSize; x++)
                {
                    var cell = game.gameBoard[x, y];
                    if (cell.IsUsed && cell.IsBoat) 
                        html += $"<td id='{x}' onClick='checkCell({x}, {y})'>X</td>";
                    else if (cell.IsUsed)
                        html += $"<td id='{x}' onClick='checkCell({x}, {y})'>O</td>";
                    else
                        html += $"<td id='{x}' onClick='checkCell({x}, {y})'></td>";
                }
                html += "</tr>";
            }
            gameLiteral.Text = html;
        }
    }
}