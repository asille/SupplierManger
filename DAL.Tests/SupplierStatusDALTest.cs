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
    class SupplierStatusDALTest
    {
        [Test]

        public void CreateStatusTest()
        {
            SupplierStatusDAL dal = new SupplierStatusDAL(ConfigurationManager.ConnectionStrings["SupplierStatus"].ConnectionString);
            var result = dal.CreateStatus(new SupplierStatusDTO
            {
                StatusName = "Test ",
                SupplierStatus = true
            });
            Assert.IsTrue(result.ID >= 0, "returned ID should be more than zero");

        }


        [Test]
        public void GetStatusByIDTest()
        {
            SupplierStatusDAL dal = new SupplierStatusDAL(ConfigurationManager.ConnectionStrings["SupplierStatus"].ConnectionString);
            var result = dal.GetStatusById(1);
            Assert.IsTrue(result.ID == 1, "returned ID does not match request");

        }

        [Test]
        public void DeleteStatusTest()
        {
            SupplierStatusDAL dal = new SupplierStatusDAL(ConfigurationManager.ConnectionStrings["SupplierStatus"].ConnectionString);
            dal.DeleteStatus(1);

            Assert.IsTrue(dal.GetStatusById(1).ID != 12, "status still in db"); ;

        }


        [Test]
        public void GetAllStatusesTest()
        {
            SupplierStatusDAL dal = new SupplierStatusDAL(ConfigurationManager.ConnectionStrings["SupplierStatus"].ConnectionString);
            var result = dal.GetAllStatuses();

            Assert.IsTrue(result.Count != 0, "no statuses shown"); ;

        }

        [Test]
        public void UpdateStatusTest()
        {
            SupplierStatusDAL dal = new SupplierStatusDAL(ConfigurationManager.ConnectionStrings["SupplierStatus"].ConnectionString);
            var shupper = dal.GetStatusById(10);
            SupplierStatusDTO upd = new SupplierStatusDTO
            {
                ID = 10,
                StatusName = "Updated"
      
            };

            var result = dal.UpdateStatuse(upd);

            Assert.IsTrue(result.StatusName == "Updated", "Status was not updated");

        }
    }
}
