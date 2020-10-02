using ConsoleProject;
using DAL.Concrete;
using DTO;
using NUnit.Framework;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.EnterpriseServices;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;



namespace DAL.Tests
{
    [TestFixture]
    [Transaction(TransactionOption.RequiresNew), ComVisible(true)]
    public class UserDALTest

    {



        [Test]
        public void CreateUserTest()
        {
            UserDAL dal = new UserDAL(ConfigurationManager.ConnectionStrings["User"].ConnectionString);
            PasswordActions password = new PasswordActions();



            var result = new UserDTO
            {
                FullName = "Test User",
                Mail = "Test",
                Login = "Test",
                Password = password.PasswordEncryption("1111"),
               
            };

            result = dal.CreateUser(result);
            Assert.IsTrue(result.ID >= 0, "returned ID should be more than zero");

        }



        [Test]
        public void GetUserByIDTest()
        {
            UserDAL dal = new UserDAL(ConfigurationManager.ConnectionStrings["User"].ConnectionString);
            var result = dal.GetUserById(1);
            Assert.IsTrue(result.ID == 1, "returned ID does not match request");

        }

        [Test]
        public void DeleteUserTest()
        {
            UserDAL dal = new UserDAL(ConfigurationManager.ConnectionStrings["User"].ConnectionString);
            dal.DeleteUser(12);

            Assert.IsTrue(dal.GetUserById(12).ID != 12, "item still in db"); ;

        }


        [Test]
        public void GetAllUsersTest()
        {
            UserDAL dal = new UserDAL(ConfigurationManager.ConnectionStrings["User"].ConnectionString);
            var result = dal.GetAllUsers();

            Assert.IsTrue(result.Count != 0, "no users shown"); ;

        }

        public void GetAllUsersSortedTest()
        {
            UserDAL dal = new UserDAL(ConfigurationManager.ConnectionStrings["User"].ConnectionString);
            var result = dal.GetAllUsersSorted(1);

            Assert.IsTrue(result.Count != 0, "no users shown"); ;

        }

        [Test]
        public void UpdateUserTest()
        {
            UserDAL dal = new UserDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            var shupper = dal.GetUserById(10);
            UserDTO upd = new UserDTO
            {
                ID = 10,
                FullName = "Updated",
                Mail = "Updated",
                Login = "Updated"
            };

            var result = dal.UpdateUser(upd);

            Assert.IsTrue(result.FullName == "Updated", "User was not updated");

        }



    }
}