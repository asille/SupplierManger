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
    public class Goods : IGoodsDAL
    {
        private readonly IGoodsDAL _goodsDAL;




        public Goods(IGoodsDAL goodsDAL)
        {
            _goodsDAL = goodsDAL;
        }

        public GoodsDTO CreateGoods(GoodsDTO goods)
        {
            Console.WriteLine("Enter Name, Price, Description");
            goods = new GoodsDTO
            {
                Name = Console.ReadLine(),
                Price = Console.ReadLine(),
                Description = Console.ReadLine()             
            };



            return _goodsDAL.CreateGoods(goods);
        }

        public void DeleteGoods(int id)
        {
            Console.WriteLine("Enter ID to delete:");
            GoodsDTO goods = new GoodsDTO();
            goods.ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Deleting user ID: {goods.ID}");
            _goodsDAL.DeleteGoods(goods.ID);
        }

        public List<GoodsDTO> GetAllGoods()
        {
            Console.WriteLine("All users:\n");
            Console.WriteLine("Id\tFullName\tLogin");
            foreach (var goods in _goodsDAL.GetAllGoods())
            {
                Console.WriteLine($"{goods.ID}\t{goods.Name}\t{goods.Price}\t{goods.Description}");

            }
            return _goodsDAL.GetAllGoods();
        }

        public List<GoodsDTO> GetAllGoodsSorted(int n)
        {
            Console.WriteLine("Enter number to get items sorted \n 1:Name \n 2:Mail \n 3:Id \n or show all");
            Console.WriteLine("Id\tFullName\tLogin");
            foreach (var goods in _goodsDAL.GetAllGoods())
            {
                Console.WriteLine($"{goods.ID}\t{goods.Name}\t{goods.Price}\t{goods.Description}");

            }
            return _goodsDAL.GetAllGoodsSorted(n);
        }

        public GoodsDTO GetGoodsById(int id)
        {
            return _goodsDAL.GetGoodsById(id);
        }

        public GoodsDTO GetGoodsByName(string name)
        {
            return _goodsDAL.GetGoodsByName(name);
        }

        public GoodsDTO UpdateGoods(GoodsDTO goods)
        {
            Console.WriteLine("Change goods inf0: \n");
            Console.WriteLine("Full name,Mail");
            goods = new GoodsDTO
            {
                Name = Console.ReadLine(),
                Price = Console.ReadLine(),
                Description = Console.ReadLine()
                
            };


            return _goodsDAL.UpdateGoods(goods);
        }
    }
}
