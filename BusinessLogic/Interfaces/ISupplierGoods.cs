using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    interface ISupplierGoods
    {
        void ShowupplierGoodsSorted(int n);
        void ShowupplierGoods();
        void RemoveupplierGoods(int ID);
        SupplierGoodsDTO GetupplierGoods(int ID);
    }
}
