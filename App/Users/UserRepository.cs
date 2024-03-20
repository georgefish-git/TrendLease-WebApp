using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TrendLease_WebApp.App.Users
{
    public class UserRepository
    {
        public string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;


        public void CreateUser(User user)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                // Users Table
                command.CommandText =
                    $"INSERT INTO Users(username) " +
                    $"VALUES (@username) ";
                command.Parameters.AddWithValue("@username", user.Username);
                command.ExecuteNonQuery();

                // AuthUsers Table
                command.CommandText =
                    $"INSERT INTO AuthUsers(username, userPass) " +
                    $"VALUES (@username, @userPass) ";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@username", user.Username);
                command.Parameters.AddWithValue("@userPass", user.UserPass);
                command.ExecuteNonQuery();

                // InfoUsers
                command.CommandText =
                    $"INSERT INTO InfoUsers(username, fname, lname, userAddress, phoneNum, emailAdd) " +
                    $"VALUES (@username, @fname, @lname, @userAddress, @phoneNum, @emailAdd)";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@username", user.Username);
                command.Parameters.AddWithValue("@fname", user.FirstName);
                command.Parameters.AddWithValue("@lname", user.LastName);
                command.Parameters.AddWithValue("@userAddress", user.Address);
                command.Parameters.AddWithValue("@phoneNum", user.PhoneNumber);
                command.Parameters.AddWithValue("@emailAdd", user.Email);
                command.ExecuteNonQuery();

            }

        }

        // get all users
        public IEnumerable<User> GetAllUser()
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = $"SELECT * FROM InfoUsers";

                return command
                    .ExecuteReader()
                    .Cast<IDataRecord>()
                    .Select(row => new User()
                    {
                        Username = (string)row["username"]
                    })
                    .ToList();
            }
        }

        public IEnumerable<User> LogInUser(string user)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = $"SELECT * FROM AuthUsers WHERE username = @user";
                command.Parameters.AddWithValue("user", user);

                return command
                    .ExecuteReader()
                    .Cast<IDataRecord>()
                    .Select(row => new User()
                    {
                        Username = (string)row["username"],
                        UserPass = (string)row["userPass"]
                    })
                    .ToList();
            }
        }
    }
}