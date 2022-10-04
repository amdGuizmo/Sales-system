using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Models;
using Microsoft.Data.Sqlite;
using Windows.Storage;

namespace Connection
{
    public static class SQLiteConnections
    {
        //private SQLiteConnection connection;

        //public SQLiteConnections()
        //{
        //    var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path,
        //        "db.sales_system");
        //    connection = new SQLiteConnection(new SQLitePlatformWinRT(), path);
        //    connection.CreateTable<TUsers>();
        //}

        //public SQLiteConnection Connection
        //{
        //    get { return connection; }
        //}

        public async static void InitializeDatabase()
        {
            await ApplicationData.Current.LocalFolder.CreateFileAsync("Sales_system.db", CreationCollisionOption.OpenIfExists);
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "Sales_system.db");
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS TUsers (ID INTEGER PRIMARY KEY, " +
                    "NID NVARCHAR(50) NULL," +
                    "Name NVARCHAR(50) NULL," +
                    "LastName NVARCHAR(50) NULL," +
                    "Email NVARCHAR(50) NULL," +
                    "Password NVARCHAR(50) NULL," +
                    "Telephone NVARCHAR(50) NULL," +
                    "Users NVARCHAR(50) NULL," +
                    "Role NVARCHAR(50) NULL," +
                    "Date NVARCHAR(50) NULL)";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }
        }

        public static void AddData(TUsers oUser)
        {
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "Sales_system.db");
            using (SqliteConnection db =
              new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO TUsers VALUES (NULL, @NID, @Name, @LastName, @Email, @Password, @Telephone, @Users, @Role, @Date);";
                insertCommand.Parameters.AddWithValue("@NID", oUser.NID);
                insertCommand.Parameters.AddWithValue("@Name", oUser.Name);
                insertCommand.Parameters.AddWithValue("@LastName", oUser.LastName);
                insertCommand.Parameters.AddWithValue("@Email", oUser.Email);
                insertCommand.Parameters.AddWithValue("@Password", oUser.Password);
                insertCommand.Parameters.AddWithValue("@Telephone", oUser.Telephone);
                insertCommand.Parameters.AddWithValue("@Users", oUser.Users);
                insertCommand.Parameters.AddWithValue("@Role", oUser.Role);
                insertCommand.Parameters.AddWithValue("@Date", oUser.Date);

                insertCommand.ExecuteReader();
            }
        }

        public static List<TUsers> GetData(string cDate)
        {
            List<TUsers> entries = new List<TUsers>();

            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "Sales_system.db");
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from TUsers where Date = '" + cDate + "'", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    TUsers oUser = new TUsers();
                    oUser.ID = int.Parse(query.GetString(0));
                    oUser.NID = query.GetString(1);
                    oUser.Name = query.GetString(2);
                    oUser.LastName = query.GetString(3);
                    oUser.Email = query.GetString(4);
                    oUser.Password = query.GetString(5);
                    oUser.Telephone = query.GetString(6);
                    oUser.Users = query.GetString(7);
                    oUser.Role = query.GetString(8);
                    oUser.Date = query.GetString(9);
                    entries.Add(oUser);
                }
            }

            return entries;
        }

        public static void DeleteData()
        {
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "Sales_system.db");
            using (SqliteConnection db =
              new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "DELETE FROM TUsers;";
                //insertCommand.Parameters.AddWithValue("@NID", oUser.NID);

                insertCommand.ExecuteReader();
            }
        }
    }
}
