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
    public class History : IHistory
    {
        private readonly IHistotyDAL _historyDAL;




        public History(IHistotyDAL histotyDAL)
        {
            _historyDAL = histotyDAL;
        }
        public HistoryDTO AddHistory(HistoryDTO history)
        {
            Console.WriteLine("Enter Count, DateTime");
            history = new HistoryDTO
            {
                Count = Convert.ToInt32(Console.ReadLine()),
                DateTime = Convert.ToDateTime(Console.ReadLine())
            };



            return _historyDAL.CreateHistory(history);
        }

        public HistoryDTO ChangeHistory(HistoryDTO history)
        {
            Console.WriteLine("Change histotu inf0: \n");
            Console.WriteLine("Count, DateTime");
            history = new HistoryDTO
            {
                Count = Convert.ToInt32(Console.ReadLine()),
                DateTime = Convert.ToDateTime(Console.ReadLine())
            };


            return _historyDAL.CreateHistory(history);
        }

        public HistoryDTO GetHistory(int ID)
        {
            return _historyDAL.GetHistoryById(ID);
        }

        public void RemoveHistory(int ID)
        {
            Console.WriteLine("Enter ID to delete:");
            HistoryDTO history = new HistoryDTO();
            history.ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Deleting histoty ID: {history.ID}");
            _historyDAL.DeleteHistory(history.ID);
        }

        public void ShowHistory()
        {
            Console.WriteLine("All users:\n");
            Console.WriteLine("Id\tCount\tDateTime\tGoodID\tUserID");
            foreach (var history in _historyDAL.GetAllHistory())
            {
                Console.WriteLine($"{history.ID}\t{history.DateTime}\t{history.GoodID}\t{history.UserID}");

            }
        }

        public void ShowHistorySorted(int n)
        {
            Console.WriteLine("Enter number to get history sorted \n 1:Count \n 2:DateTime  \n or show all");
            Console.WriteLine("Id\tFullName\tLogin");
            foreach (var history in _historyDAL.GetAllHistory())
            {
                Console.WriteLine($"{history.ID}\t{history.DateTime}\t{history.GoodID}\t{history.UserID}");

            }
        }
    }
}
