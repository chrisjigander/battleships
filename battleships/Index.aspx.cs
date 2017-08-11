using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace battleships
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            
            if (!IsPostBack)
            {
                if (Request["highscore"] != null)
                {                    
                    scriptLiteral.Text = $"<script>$(document).ready(() => (displayHighscore({Request["highscore"]})))</script>";
                } else
                {
                    audioLiteral.Text = $"<script>$(document).ready(() => (audio.play()))</script>";
                }
            }
        }

        protected void NewGameBtn_OnClick(object sender, EventArgs e)
        {
            if (IsValid)
            {            
                Server.Transfer("Game.aspx?difficulty=" + difficultyList.SelectedValue + "&player=" + nameInput.Value);
            }
        }

        protected void ShowHighScores_Click(object sender, EventArgs e)
        {
            int lvl = Convert.ToInt32(difficultyList.SelectedValue);
            var scores = SQLManager.GetHighScores(lvl)
                .OrderBy(s => s.HighScore);

            string html = $"<h1>Highscores (lvl {lvl})</h1>" +
                          $"<ul id='score-list'>";

            foreach (var score in scores)
            {
                html += $"<li>Name: {score.Player}       Score: {score.HighScore}</li>";
            }

            html += "</ul>";
            ScoreList.Text = html;
            scriptLiteral.Text = $"<script>$(document).ready(() => (displayModalBox()))</script>";
        }
    }
}