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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerateBoard();
            }
        }

        protected void CheckCell(object sender, EventArgs e)
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
                        html += $"<td id='{x}' onClick='CheckCell({x}, {y})'></td>";
                    }
                    html += "</tr>";
                }
            }

            gameLiteral.Text = html;
        }
    }
}