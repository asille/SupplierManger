using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    public class ConsoleFunctions
    {
        private string connectionString;

        public ConsoleFunctions(string connectionString)
        {
            this.connectionString = connectionString;
        }



        public int Login()
        {

            Console.WriteLine("Login to continue:\n");
            Console.WriteLine("Login: ");
            string login = Console.ReadLine();
            Console.WriteLine("Password: ");
            string password = Console.ReadLine();
            UserDTO user = new UserDTO();

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();


                comm.CommandText = $"select * from User where Login= '{login}'";


                PasswordActions decrypt = new PasswordActions();

                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    user.ID = Convert.ToInt32(reader["UserID"]);
                    user.Login = reader["Login"].ToString();
                    user.Password = (byte[])reader["Password"];
                    if (user.Login != login || decrypt.PasswordDecryption(user.Password) != password)
                    {

                        throw new NotImplementedException("Incorrect Login or Password");
                    }
                }
                return user.ID;

            }



        }
    }
}
