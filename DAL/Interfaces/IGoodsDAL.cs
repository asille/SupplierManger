using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IGoodsDAL
    {
        GoodsDTO GetGoodsById(int id);
        List<GoodsDTO> GetAllGoods();
        GoodsDTO UpdateGoods(GoodsDTO goods);
        GoodsDTO CreateGoods(GoodsDTO goods);
        void DeleteGoods(int id);
    }
}
