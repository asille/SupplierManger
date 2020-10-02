using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Solid;
using ConsoleProject;
using DAL.Concrete;
using DAL.Interfaces;
using DTO;
using BusinessLogic;
using System.Threading;

namespace SupplierManger
{
    public class Menu
    {
        private string _connectionString;

        public Menu(string connectionString)
        {
            this._connectionString = connectionString;
        }


        public void menu(int user)
        {
            string conn = ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString;
            ConsoleFunctions Login = new ConsoleFunctions(_connectionString);
            UserDAL userD = new UserDAL(conn);
            SupplierStatusDAL statusD = new SupplierStatusDAL(conn);
            SupplierGoodsDAL supplierGoodsD = new SupplierGoodsDAL(conn);
            RoleDAL roleD = new RoleDAL(conn);
            HistoryDAL historyD = new HistoryDAL(conn);
            GoodsDAL goodsD = new GoodsDAL(conn);

            User user1 = new User(userD);
            SupplierStatus supplierStatus = new SupplierStatus(statusD);
            SupplierGoods supplierGoods = new SupplierGoods(supplierGoodsD);
            Role role = new Role(roleD);
            History history = new History(historyD);
            Goods goods = new Goods(goodsD);


            Console.Clear();

            if (user > 0)
            {
                Console.WriteLine($"Hello  {user1.GetUser(user).Login}");
                Console.WriteLine("\n 1:work with suppliers\n2:Work with goods\n3:log out\nor press any other key to quit\nyour choose:");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (n == 1)
                {
                    Console.WriteLine("\n 1:show all\n2:show by name\n3:show by id\n4:show all sorted\n5:delete\n6:add\n7:update\nor press anything else to go back to menu\nyour choose:");
                    int m = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    if(m == 1)
                    {
                        user1.ShowUsers();
                        Console.WriteLine("Press any key to go back to previous menu");
                        Console.ReadLine();
                        menu(user);
                    }
                    if (m == 2)
                    {
                        Console.WriteLine("Enter Name");
                        string name = Console.ReadLine();
                        user1.GetUserByName(name);
                        Console.WriteLine("Press any key to go back to previous menu");
                        Console.ReadLine();
                        menu(user);
                    }
                    if (m == 3)
                    {
                        Console.WriteLine("Enter ID");
                        int id = Convert.ToInt32(Console.ReadLine());
                        user1.GetUser(id);
                        Console.WriteLine("Press any key to go back to previous menu");
                        Console.ReadLine();
                        menu(user);
                    }
                    if (m == 4)
                    {
                        Console.WriteLine("Sort:\n1:by name\n2:by mail \n3: by id \nor show all\nyour choose:");
                        int x = Convert.ToInt32(Console.ReadLine());
                        if(x == 1)
                        { user1.ShowUsersSorted(1); }
                        if (x == 2)
                        { user1.ShowUsersSorted(2); }
                        if (x == 3)
                        { user1.ShowUsersSorted(3); }
                        else { user1.ShowUsersSorted(x); }
                        Console.WriteLine("Press any key to go back to previous menu");
                        Console.ReadLine();
                        menu(user);
                    }
                    if (m == 5)
                    {
                        Console.WriteLine("Enter ID");
                        int id = Convert.ToInt32(Console.ReadLine());
                        user1.RemoveUser(id);
                        Console.WriteLine("Press any key to go back to previous menu");
                        Console.ReadLine();
                        menu(user);
                    }
                    if (m == 6)
                    {
                        UserDTO user2 = new UserDTO();
                        user1.AddUser(user2);
                        Console.WriteLine("Press any key to go back to previous menu");
                        Console.ReadLine();
                        menu(user);
                    }
                    if (m == 7)
                    {
                        UserDTO user2 = new UserDTO();
                        user1.ChangeUser(user2);
                        Console.WriteLine("Press any key to go back to previous menu");
                        Console.ReadLine();
                        menu(user);
                    }
                    else
                    {
                        menu(user);
                    }
                } 
                if(n == 2)
                {
                    Console.WriteLine("\n 1:show all\n2:show by name\n3:show by id\n4:show all sorted\n5:delete\n6:add\n7:update\nor press anything else to go back to menu\nyour choose:");
                    int m = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    if (m == 1)
                    {
                        goods.GetAllGoods();
                        Console.WriteLine("Press any key to go back to previous menu");
                        Console.ReadLine();
                        menu(user);
                    }
                    if (m == 2)
                    {
                        Console.WriteLine("Enter Name");
                        string name = Console.ReadLine();
                        goods.GetGoodsByName(name);
                        Console.WriteLine("Press any key to go back to previous menu");
                        Console.ReadLine();
                        menu(user);
                    }
                    if (m == 3)
                    {
                        Console.WriteLine("Enter ID");
                        int id = Convert.ToInt32(Console.ReadLine());
                        goods.GetGoodsById(id);
                        Console.WriteLine("Press any key to go back to previous menu");
                        Console.ReadLine();
                        menu(user);
                    }
                    if (m == 4)
                    {
                        Console.WriteLine("Sort:\n1:by name\n2:by description \n3: by id\n4:price \nor show all\nyour choose:");
                        int x = Convert.ToInt32(Console.ReadLine());
                        if (x == 1)
                        { goods.GetAllGoodsSorted(1); }
                        if (x == 2)
                        { goods.GetAllGoodsSorted(2); }
                        if (x == 3)
                        { goods.GetAllGoodsSorted(3); }
                        if(x == 4)
                        { goods.GetAllGoodsSorted(4); }
                        else { goods.GetAllGoodsSorted(x); }
                        Console.WriteLine("Press any key to go back to previous menu");
                        Console.ReadLine();
                        menu(user);
                    }
                    if (m == 5)
                    {
                        Console.WriteLine("Enter ID");
                        int id = Convert.ToInt32(Console.ReadLine());
                        goods.DeleteGoods(id);
                        Console.WriteLine("Press any key to go back to previous menu");
                        Console.ReadLine();
                        menu(user);
                    }
                    if (m == 6)
                    {
                        GoodsDTO goods1 = new GoodsDTO();
                        goods.CreateGoods(goods1);
                        Console.WriteLine("Press any key to go back to previous menu");
                        Console.ReadLine();
                        menu(user);
                    }
                    if (m == 7)
                    {
                        GoodsDTO goods1 = new GoodsDTO();
                        goods.UpdateGoods(goods1);
                        Console.WriteLine("Press any key to go back to previous menu");
                        Console.ReadLine();
                        menu(user);
                    }
                    else
                    { menu(user); }

                }
                if(n == 3)
                { Login.Login();}
                else
                {
                    Thread.Sleep(2000);
                    Console.Clear();
                }

            }

        }
    }
}
