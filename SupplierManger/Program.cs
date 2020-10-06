using BusinessLogic.Solid;
using DAL.Concrete;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleProject;


namespace SupplierManger
{
    class Program
    {
        static void Main(string[] args)
        {

            Menu console = new Menu(ConfigurationManager.ConnectionStrings["SupplierManager"].ConnectionString);
            ConsoleFunctions Login = new ConsoleFunctions(ConfigurationManager.ConnectionStrings["SupplierManager"].ConnectionString);
            int user = Login.Login();
            console.menu(user);
            Console.ReadLine();

        }
    }
}
