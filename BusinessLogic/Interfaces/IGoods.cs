using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    interface IGoods
    {
        GoodsDTO AddGoods(GoodsDTO goods);
        GoodsDTO ChangeGoods(GoodsDTO goods);
        void ShowGoodsSorted(int n);
        void ShowGoods();
        void RemoveGoods(int ID);
        GoodsDTO GetGoods(int ID);
        GoodsDTO GetGoodsByName(string Name);
    }
}
