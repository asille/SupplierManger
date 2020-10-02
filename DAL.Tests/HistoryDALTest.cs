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
    class HistoryDALTest
    {
        public void CreateHistoryTest()
        {
            HistoryDAL dal = new HistoryDAL(ConfigurationManager.ConnectionStrings["History"].ConnectionString);
            var result = dal.CreateHistory(new HistoryDTO
            {
                ID = 1,
                Count = 1
            });
            Assert.IsTrue(result.ID >= 0, "returned ID should be more than zero");

        }



        [Test]
        public void GetHistoryByIDTest()
        {
            HistoryDAL dal = new HistoryDAL(ConfigurationManager.ConnectionStrings["History"].ConnectionString);
            var result = dal.GetHistoryById(1);
            Assert.IsTrue(result.ID == 1, "returned ID does not match request");

        }

        [Test]
        public void DeleteHistoryTest()
        {
            HistoryDAL dal = new HistoryDAL(ConfigurationManager.ConnectionStrings["History"].ConnectionString);
            dal.DeleteHistory(12);

            Assert.IsTrue(dal.GetHistoryById(12).ID != 12, "history still in db"); ;

        }


        [Test]
        public void GetAllHistiryTest()
        {
            HistoryDAL dal = new HistoryDAL(ConfigurationManager.ConnectionStrings["History"].ConnectionString);
            var result = dal.GetAllHistory();

            Assert.IsTrue(result.Count != 0, "no history shown"); ;

        }

        public void GetAllHistorySortedTest()
        {
            HistoryDAL dal = new HistoryDAL(ConfigurationManager.ConnectionStrings["History"].ConnectionString);
            var result = dal.GetAllHistorySorted(1);

            Assert.IsTrue(result.Count != 0, "no history shown"); ;

        }

        [Test]
        public void UpdateHistoryTest()
        {
            HistoryDAL dal = new HistoryDAL(ConfigurationManager.ConnectionStrings["History"].ConnectionString);
            var shupper = dal.GetHistoryById(10);
            HistoryDTO upd = new HistoryDTO
            {
                ID = 10,
                Count = 1
            };

            var result = dal.UpdateHistory(upd);

            Assert.IsTrue(result.Count == 1, "History was not updated");

        }

    }
}
