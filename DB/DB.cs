using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DB
{
    public class DbHelper

    {

        public List<Sushi> GetSushi()
        {
            SQLiteConnection dbCon = new SQLiteConnection("Data Source=C:/Users/Лена/source/repos/WebApplication1/SushiWorld.db;Version=3;");
            dbCon.Open();
            var test = dbCon.Database;
            List<Sushi> sushies = new List<Sushi>();

            SQLiteCommand cmd = dbCon.CreateCommand();
            cmd.CommandText = "SELECT * FROM Sushi;";
            SQLiteDataAdapter ad = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);

            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var name = reader.GetString(1);
                var price = reader.GetInt32(2);
                var weight = reader.GetInt32(3);
                var isHot = reader.GetBoolean(4);
                var id = reader.GetInt32(0);

                var sushi = new Sushi
                {
                    Id = id,
                    Name = name,
                    Price = price,
                    Weight = weight,
                    IsHot = isHot
                };

                sushies.Add(sushi);
            }

            dbCon.Close();

            return sushies;
        }

        public Sushi GetSushi(int requestId)
        {
            SQLiteConnection dbCon = new SQLiteConnection("Data Source=C:/Users/Лена/source/repos/WebApplication1/SushiWorld.db;Version=3;");
            dbCon.Open();
            var test = dbCon.Database;
            Sushi sushi = new Sushi();

            SQLiteCommand cmd = dbCon.CreateCommand();
            cmd.CommandText = string.Format ("SELECT * FROM Sushi WHERE id = {0}", requestId);
            SQLiteDataAdapter ad = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);

            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var name = reader.GetString(1);
                var price = reader.GetInt32(2);
                var weight = reader.GetInt32(3);
                var isHot = reader.GetBoolean(4);
                var id = reader.GetInt32(0);

                sushi = new Sushi
                {
                    Id = id,
                    Name = name,
                    Price = price,
                    Weight = weight,
                    IsHot = isHot
                };

               
            }

            dbCon.Close();

            return sushi;
        }



        public void AddSushi(Sushi sushi)
        {
            SQLiteConnection dbCon = new SQLiteConnection("Data Source=C:/Users/Лена/source/repos/WebApplication1/SushiWorld.db;Version=3;");
            dbCon.Open();


            SQLiteCommand cmd = dbCon.CreateCommand();
            cmd.CommandText =
              String.Format("INSERT INTO Sushi (id, name, price, weight, ishot) values ({0}, \"{1}\", {2}, {3}, {4})",
              sushi.Id.ToString(),
              sushi.Name,
              sushi.Price.ToString(),
              sushi.Weight.ToString(),
              sushi.IsHot.ToString()
              );

            cmd.ExecuteNonQuery();

          

           
            dbCon.Close();


        }

        public void UpdateSushi(int id, Sushi sushi)
        {

            SQLiteConnection dbCon = new SQLiteConnection("Data Source=C:/Users/Лена/source/repos/WebApplication1/SushiWorld.db;Version=3;");
        dbCon.Open();


            SQLiteCommand cmd = dbCon.CreateCommand();
        cmd.CommandText =
              String.Format("UPDATE Sushi SET name =\"{1}\", price={2}, weight={3}, ishot={4} WHERE id ={0}",
              sushi.Id.ToString(),
              sushi.Name,
              sushi.Price.ToString(),
              sushi.Weight.ToString(),
              sushi.IsHot.ToString()
              );

            cmd.ExecuteNonQuery();

          

           
            dbCon.Close();
        }

        public void DeleteSushi(int id)
        {
            SQLiteConnection dbCon = new SQLiteConnection("Data Source=C:/Users/Лена/source/repos/WebApplication1/SushiWorld.db;Version=3;");
            dbCon.Open();


            SQLiteCommand cmd = dbCon.CreateCommand();
            cmd.CommandText =
                  String.Format("DELETE FROM Sushi WHERE id ={0}", id);

            cmd.ExecuteNonQuery();




            dbCon.Close();
        }
    }
    }
