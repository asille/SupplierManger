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
    class RoleDALTest
    {

        [Test]
        public void CreateRoleTest()
        {
            RoleDAL dal = new RoleDAL(ConfigurationManager.ConnectionStrings["Role"].ConnectionString);
            PasswordActions password = new PasswordActions();



            var result = new RoleDTO
            {
                RoleName = "Test User",
                Description = "Test",

            };

            result = dal.CreateRole(result);
            Assert.IsTrue(result.ID >= 0, "returned ID should be more than zero");

        }



        [Test]
        public void GetRoleByIDTest()
        {
            RoleDAL dal = new RoleDAL(ConfigurationManager.ConnectionStrings["Role"].ConnectionString);
            var result = dal.GetRoleById(1);
            Assert.IsTrue(result.ID == 1, "returned ID does not match request");

        }

        [Test]
        public void DeleteRoleTest()
        {
            RoleDAL dal = new RoleDAL(ConfigurationManager.ConnectionStrings["Role"].ConnectionString);
            dal.DeleteRole(12);

            Assert.IsTrue(dal.GetRoleById(12).ID != 12, "role still in db"); ;

        }


        [Test]
        public void GetAllRolesTest()
        {
            RoleDAL dal = new RoleDAL(ConfigurationManager.ConnectionStrings["Role"].ConnectionString);
            var result = dal.GetAllRoles();

            Assert.IsTrue(result.Count != 0, "no roles shown"); ;

        }


        [Test]
        public void UpdateRoleTest()
        {
            RoleDAL dal = new RoleDAL(ConfigurationManager.ConnectionStrings["Role"].ConnectionString);
            var shupper = dal.GetRoleById(10);
            RoleDTO upd = new RoleDTO
            {
                ID = 10,
                RoleName = "Updated"
            };

            var result = dal.UpdateRole(upd);

            Assert.IsTrue(result.RoleName == "Updated", "Role was not updated");

        }

    }
}
