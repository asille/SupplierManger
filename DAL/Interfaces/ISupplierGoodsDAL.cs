using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ISupplierGoodsDAL
    {
        SupplierGoodsDTO GetSupplierGoodById(int id);
        List<SupplierGoodsDTO> GetAllSupplierGoods();
        List<SupplierGoodsDTO> GetAllSupplierGoodsSorted(int n);
        void DeleteSupplierGood(int id);
        List<SupplierGoodsDTO> GetAllSupplierGoodsSorted(int n);
        List<SupplierGoodsDTO> GetAllSupplierGoodsSorted(int n);
    }
}
