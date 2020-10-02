using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ISupplierGoods
    {
        void ShowSupplierGoods();
        void RemoveSupplierGoods(int ID);
        SupplierGoodsDTO GetSupplierGoods(int ID);

    }
}
