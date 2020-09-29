using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplierManger
{
    class Program
    {
        static void Main(string[] args)
        {
            string connStr = ConfigurationManager.ConnectionStrings["SupplierManager"].ConnectionString;
            SqlConnection connection = new SqlConnection(connStr);
            try
            {
                // Открываем подключение
                connection.Open();
                Console.WriteLine("Подключение открыто");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // закрываем подключение
                connection.Close();
                Console.WriteLine("Подключение закрыто...");
            }

            Console.Read();
        }
    }
}
