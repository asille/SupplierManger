using BusinessLogic.Interfaces;
using DAL.Concrete;
using DAL.Interfaces;
using DTO;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using ConsoleProject;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Solid
{
    public class User : IUser
    {
        private readonly IUserDAL _userDAL;




        public User(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        public UserDTO AddUser(UserDTO user)
        {
            ConsoleProject.PasswordActions password = new ConsoleProject.PasswordActions();
            Console.WriteLine("Enter Full Name, Mail, Login, Password");
            user = new UserDTO
            {
                FullName = Console.ReadLine(),
                Mail = Console.ReadLine(),
                Login = Console.ReadLine(),
                Password = password.PasswordEncryption(Console.ReadLine())
            };



            return _userDAL.CreateUser(user);
        }


        public void RemoveUser(int ItemID)
        {
            Console.WriteLine("Enter ID to delete:");
            UserDTO user = new UserDTO();
            user.ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Deleting user ID: {user.ID}");
            _userDAL.DeleteUser(user.ID);
        }

        public UserDTO GetUser(int id)
        {
            return _userDAL.GetUserById(id);
        }

        public void ShowUsers()
        {
            Console.WriteLine("All users:\n");
            Console.WriteLine("Id\tFullName\tLogin");
            foreach (var user in _userDAL.GetAllUsers())
            {
                Console.WriteLine($"{user.ID}\t{user.FullName}\t{user.Login}");

            }
        }

        public void ShowUsersSorted(int n)
        {
            Console.WriteLine("Enter number to get items sorted \n 1:Name \n 2:Mail \n 3:Id \n or show all");
            Console.WriteLine("Id\tFullName\tLogin");
            foreach (var user in _userDAL.GetAllUsers())
            {
                Console.WriteLine($"{user.ID}\t{user.FullName}\t{user.Login}");

            }
        }

        public UserDTO ChangeUser(UserDTO user)
        {
            Console.WriteLine("Change user inf0: \n");
            Console.WriteLine("Full name,Mail");
            user = new UserDTO
            {
                FullName = Console.ReadLine(),
                Mail = Console.ReadLine(),
              
            };


            return _userDAL.UpdateUser(user);
        }

        public UserDTO GetUserByName(string Name)
        {
            return _userDAL.GetUserByName(Name);
        }
    }

}

