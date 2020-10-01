using BusinessLogic.Interfaces;
using DAL.Concrete;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Solid
{
    public class SupplierGoods : ISupplierGoods
    {
        private readonly ISupplierGoodsDAL _supplierGoodsDAL;



        public SupplierGoods(ISupplierGoodsDAL supplierGoodsDAL)
        {
            _supplierGoodsDAL = supplierGoodsDAL;
        }


        public void RemoveSupplierGoods(int ItemID)
        {
            Console.WriteLine("Enter ID to delete:");
            SupplierGoodsDTO supplierGoods = new SupplierGoodsDTO();
            supplierGoods.ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Deleting user ID: {supplierGoods.ID}");
            _supplierGoodsDAL.DeleteSupplierGood(supplierGoods.ID);
        }

        public SupplierGoodsDTO GetSupplierGoods(int id)
        {
            return _supplierGoodsDAL.GetSupplierGoodById(id);
        }


        public void ShowSupplierGoods()
        {
            Console.WriteLine("All Supplier Goods:\n");
            Console.WriteLine("Id\tGoodsID\tUserID");
            foreach (var supplierStatus in _supplierGoodsDAL.GetAllSupplierGoods())
            {
                Console.WriteLine($"{supplierStatus.ID}\t{supplierStatus.GoodsID}\t{supplierStatus.UserID}");

            }
        }
    }
}
