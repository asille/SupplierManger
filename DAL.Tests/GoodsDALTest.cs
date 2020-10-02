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
    class GoodsDALTest
    {
        [Test]
        public void CreateHistoryTest()
        {
            GoodsDAL dal = new GoodsDAL(ConfigurationManager.ConnectionStrings["Goods"].ConnectionString);
            var result = dal.CreateGoods(new GoodsDTO
            {
                ID = 1,
                Name = "Test Item",
                Description = "Test"
            });
            Assert.IsTrue(result.ID >= 0, "returned ID should be more than zero");

        }


        [Test]
        public void GetHistoryByIDTest()
        {
            GoodsDAL dal = new GoodsDAL(ConfigurationManager.ConnectionStrings["Goods"].ConnectionString);
            var result = dal.GetGoodsById(1);
            Assert.IsTrue(result.ID == 1, "returned ID does not match request");

        }

        [Test]
        public void DeleteHistoryTest()
        {
            GoodsDAL dal = new GoodsDAL(ConfigurationManager.ConnectionStrings["Goods"].ConnectionString);
            dal.DeleteGoods(12);

            Assert.IsTrue(dal.GetGoodsById(12).ID != 12, "goods still in db"); ;

        }


        [Test]
        public void GetAllHistoryTest()
        {
            GoodsDAL dal = new GoodsDAL(ConfigurationManager.ConnectionStrings["Goods"].ConnectionString);
            var result = dal.GetAllGoods();

            Assert.IsTrue(result.Count != 0, "no goods shown"); ;

        }

        [Test]
        public void UpdateHistory()
        {
            GoodsDAL dal = new GoodsDAL(ConfigurationManager.ConnectionStrings["Goods"].ConnectionString);

            GoodsDTO upd = dal.UpdateGoods(new GoodsDTO
            {
                ID = 7,
                Name = "Test"
            });



            Assert.IsTrue(upd.Name == "Test", "Goods was not updated");

        }
    }
}
