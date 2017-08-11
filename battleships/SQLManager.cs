using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Sql;

namespace battleships
{
    public class SQLManager
    {
        static public string connectionString = "Data Source=localhost;Initial Catalog=Battleship;Integrated Security=True";
        static public SqlConnection conn = new SqlConnection(connectionString);

        public static void AddHighScore(int score, string player, int level)
        {
            try
            {
                conn.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = $"insert into HighScore(score, player, level)  values({score}, '{player}', {level});";

                int rows = command.ExecuteNonQuery();  
                
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public static List<Score> GetHighScores(int lvl)
        {
            var scores = new List<Score>();

            try
            {
                conn.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "sp_GetHighScoreByLevel";

                SqlParameter paramLvl = new SqlParameter("@Level", lvl);
                paramLvl.DbType = System.Data.DbType.Int32;
                command.Parameters.Add(paramLvl);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Score tempScore = new Score();
                    tempScore.HighScore = Convert.ToInt32(reader["score"].ToString());
                    tempScore.Player = reader["player"].ToString();

                    scores.Add(tempScore);
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return scores;
        }
    }
}