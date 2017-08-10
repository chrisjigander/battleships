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

        public static int[,] gameBoard;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerateBoard();

                if (Request["CheckCell"] != null)
                {
                    if (Request["x"] != null && Request["y"] != null)
                    {
                        CheckCell(Convert.ToInt32(Request["x"]), Convert.ToInt32(Request["y"]));
                    }
                }
            }
        }

        protected void CheckCell(int x, int y)
        {
            
        }

        protected void GenerateBoard()
        {


            string html = "";
            // easy
            if (difficulty == 1)
            {
                for (int y = 0; y < 15; y++)
                {
                    html += $"<tr id='{y}'>";
                    for (int x = 0; x < 15; x++)
                    {
                        html += $"<td id='{x}' onClick='checkCell({x}, {y})'></td>";
                    }
                    html += "</tr>";
                }
            }

            gameLiteral.Text = html;
        }
    }
}