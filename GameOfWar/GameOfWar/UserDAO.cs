using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace GameOfWar
{
    public class UserDAO
    {
        string connectionString = "datasource=localhost;port=3306;username=root;password=root;database=gameofwar;";

        public User getUserFromUsername(string name)
        {
            User user = new User();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE @username = username", connection);
            command.Parameters.AddWithValue("@username", name);


            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    user = new User
                    {
                        Id = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        Password = reader.GetString(2),
                        winsGame = reader.GetInt32(3),
                        losesGame = reader.GetInt32(4)
                    };

                }
            }
            connection.Close();

            return user;

        }

        public User login(string name, string password)
        {
            User user = new User();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE @username = username", connection);
            command.Parameters.AddWithValue("@username", name);


            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    user = new User
                    {
                        Id = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        Password = reader.GetString(2),
                        winsGame = reader.GetInt32(3),
                        losesGame = reader.GetInt32(4)
                    };

                }
            }
            connection.Close();

            if(name == user.Username && password == user.Password)
            {
                return user;
            }
            else
            {
                return null;
            }


        }
        public int signUp(User user)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("INSERT INTO `users`(`username`, `password`, `winsGame`, `losesGame`) VALUES ('@username','@password','@winsGame','@losesGame')", connection);
            command.Parameters.AddWithValue("@username", user.Username);
            command.Parameters.AddWithValue("@password", user.Password);
            command.Parameters.AddWithValue("@winsGame", user.winsGame);
            command.Parameters.AddWithValue("@losesGame",user.losesGame);
            int newRows = command.ExecuteNonQuery();
            connection.Close();

            return newRows;
        }
        public int setWins(int newWins, string username)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("UPDATE `users` SET `winsGame`='@winsGame' WHERE '@username' = username;", connection);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@winsGame", newWins);
            int newRows = command.ExecuteNonQuery();
            connection.Close();

            return newRows;
        }

        public int setLoses(int newLoses, string username)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("UPDATE `users` SET `losesGame`='@losesGame' WHERE '@username' = username;", connection);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@losesGame", newLoses);
            int newRows = command.ExecuteNonQuery();
            connection.Close();

            return newRows;
        }
    }
}
