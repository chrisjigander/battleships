﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace battleships
{
    public partial class Game : System.Web.UI.Page
    {        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GameClass game = new GameClass();


                if (Session["Game"] != null)
                {
                    game = (GameClass)Session["Game"];
                }
                else
                {                                   
                    if (Request["difficulty"] != null)
                    {
                        game.Difficulty = Convert.ToInt32(Request["difficulty"]);
                    }

                    if (Request["player"] != null)
                    {
                        game.Player = Request["player"];
                    }

                    SetupGame(game);
                    Session["Game"] = game;

                    // music
                    
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
                DisplayStats(game);
            }

        }

        protected void CheckCell(int x, int y, GameClass game)
        {
            for (int coordY = 0; coordY < game.GameSize; coordY++)
            {
                for (int coordX = 0; coordX < game.GameSize; coordX++)
                {
                    if (coordX == x && coordY == y)
                    {
                        var cell = game.GameBoard[coordX, coordY];

                        if (cell.IsBoat && !cell.IsUsed)
                        {
                            game.SuccessfulHits++;
                        }

                        cell.IsUsed = true;
                    }
                }
            }
            game.NumberOfAttempts++;
            CheckForWin(game);
        }

        protected void CheckForWin(GameClass game)
        {
            if (game.HitsRequired() == game.SuccessfulHits)
            {
                SQLManager.AddHighScore(game.NumberOfAttempts, game.Player, game.Difficulty);
                SQLManager.AddSaveGame(game);
                Session.Clear();
                Server.Transfer($"Index.aspx?highscore={game.NumberOfAttempts}");
            }
        }

        protected void SetupGame(GameClass game)
        {
            switch (game.Difficulty)
            {
                case 1:
                    game.GameSize = 6;
                    game.SubmarinesCount = 4;
                    break;
                case 2:
                    game.GameSize = 8;
                    game.SubmarinesCount = 4;
                    game.BattleShipsCount = 4;
                    break;
                case 3:
                    game.GameSize = 10;
                    game.SubmarinesCount = 4;
                    game.BattleShipsCount = 4;
                    game.AirCraftCarriersCount = 4;
                    break;
                default:
                    game.GameSize = 10;
                    break;
            }

            game.GameBoard = new Cell[game.GameSize, game.GameSize];        
            List<int[]> boatHolder = GenerateBoatPositions(game);          

            // loop and place boats on coordinates
            for (int y = 0; y < game.GameSize; y++)
            {
                for (int x = 0; x < game.GameSize; x++)
                {
                    game.GameBoard[x, y] = new Cell(x, y);
                    if (BoatAtCoordinate(boatHolder, x, y))
                    {
                        game.GameBoard[x, y].IsBoat = true;
                    }

                }
            }

        }

        protected bool BoatAtCoordinate(List<int[]> listToCheck, int xParam, int yParam)
        {
            foreach (var coords in listToCheck)
            {
                if (coords[0] == xParam && coords[1] == yParam)
                {
                    return true;
                }
            }

            return false;
        }

        protected List<int[]> GenerateBoatPositions(GameClass game)
        {
            List<int[]> tempTotalBoats = new List<int[]>();

            for (int i = 0; i < game.AirCraftCarriersCount; i++)
            {
                tempTotalBoats = GenerateBoat(tempTotalBoats, game.AirCraftCarriersSize, game);
            }

            for (int i = 0; i < game.BattleShipsCount; i++)
            {
                tempTotalBoats = GenerateBoat(tempTotalBoats, game.BattleShipsSize, game);
            }

            for (int i = 0; i < game.SubmarinesCount; i++)
            {
               tempTotalBoats = GenerateBoat(tempTotalBoats, game.SubmarinesSize, game);
            }

            return tempTotalBoats;
        }

        protected List<int[]> GenerateBoat(List<int[]> tempBoatHolder, int boatSize, GameClass game)
        {
            var accX = new int[boatSize];
            var accY = new int[boatSize];

            bool badPosition = true;
            Random random = new Random();

            while (badPosition)
            {
                // Horizontal or vertical?
                var randomHolder = random.Next(0, 2);

                // horizontal
                if (randomHolder == 1)
                {
                    // randomize test boat start coordinates
                    int boatY = random.Next(0, game.GameSize);
                    int boatX = random.Next(0, game.GameSize - 2);

                    // build test boat coordinates
                    for (int v = 0; v < boatSize; v++)
                    {
                        accX[v] = boatX + v;
                        accY[v] = boatY;
                    }

                    bool NoBoats = true;

                    // check if test boat coordinates are ok
                    for (int p = 0; p < boatSize; p++)
                    {
                        if (BoatAtCoordinate(tempBoatHolder, accX[p], accY[p]))
                        {
                            NoBoats = false;
                        }
                    }

                    if (NoBoats)
                        badPosition = false;               
                }
                // vertical
                else
                {
                    int boatY = random.Next(0, game.GameSize - 2);
                    int boatX = random.Next(0, game.GameSize);

                    for (int v = 0; v < boatSize; v++)
                    {
                        accX[v] = boatX;
                        accY[v] = boatY + v;
                    }

                    //if (!BoatAtCoordinate(tempBoatHolder, accX[0], accY[0])
                    //    && !BoatAtCoordinate(tempBoatHolder, accX[1], accY[1])
                    //    && !BoatAtCoordinate(tempBoatHolder, accX[2], accY[2]))
                    //{
                    //    badPosition = false;
                    //}

                    bool NoBoats = true;

                    for (int p = 0; p < boatSize; p++)
                    {
                        if (BoatAtCoordinate(tempBoatHolder, accX[p], accY[p]))
                        {
                            NoBoats = false;
                        }
                    }

                    if (NoBoats)
                        badPosition = false;
                }

            }
            for (int z = 0; z < accX.Length; z++)
            {
                tempBoatHolder.Add(new int[] { accX[z], accY[z] });
            }

            return tempBoatHolder;
        }

        protected void DisplayStats(GameClass game)
        {
            string html = "";
            html += $"<h3>TOTAL ATTEMPTS: {game.NumberOfAttempts}</h3>";
            html += $"<h3>SUCCESSFUL HITS: {game.SuccessfulHits}</h3>";
            html += $"<h3>HITS REQUIRED: {game.HitsRequired()}</h3>";

            statsLiteral.Text = html;
        }

        protected void DisplayBoard(GameClass game)
        {
            string html = "";
            for (int y = 0; y < game.GameSize; y++)
            {
                html += $"<tr id='{y}'>";
                for (int x = 0; x < game.GameSize; x++)
                {
                    var cell = game.GameBoard[x, y];
                    if (cell.IsUsed && cell.IsBoat)
                        html += $"<td id='{x}' onClick='checkCell({x}, {y})'><img id='fireImg' src='Content\\singleFire.png'></td>";
                    else if (cell.IsUsed)
                        html += $"<td id='{x}' onClick='checkCell({x}, {y})'><img id='rippleImg' src='Content\\ripple.png'></td>";
                    else if (cell.IsBoat)
                        html += $"<td id='{x}' onClick='checkCell({x}, {y})'></td>";
                    else
                        html += $"<td id='{x}' onClick='checkCell({x}, {y})'></td>";
                }
                html += "</tr>";
            }
            gameLiteral.Text = html;
        }
    }
}