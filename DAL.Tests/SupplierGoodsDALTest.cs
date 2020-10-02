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
    class SupplierGoodsDALTest
    {
        [Test]
        public void GetItemByIDTest()
        {
            SupplierGoodsDAL dal = new SupplierGoodsDAL(ConfigurationManager.ConnectionStrings["SupplierGoods"].ConnectionString);
            var result = dal.GetSupplierGoodById(1);
            Assert.IsTrue(result.ID == 1, "returned ID does not match request");

        }

        [Test]
        public void DeleteItemTest()
        {
            SupplierGoodsDAL dal = new SupplierGoodsDAL(ConfigurationManager.ConnectionStrings["SupplierGoods"].ConnectionString);
            dal.DeleteSupplierGood(12);

            Assert.IsTrue(dal.GetSupplierGoodById(12).ID != 12, "item still in db"); ;

        }


        [Test]
        public void GetAllItemsTest()
        {
            SupplierGoodsDAL dal = new SupplierGoodsDAL(ConfigurationManager.ConnectionStrings["SupplierGoods"].ConnectionString);
            var result = dal.GetAllSupplierGoods();

            Assert.IsTrue(result.Count != 0, "no supplier goods shown"); ;

        }
   
    }
}
