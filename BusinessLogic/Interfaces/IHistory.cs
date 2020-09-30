using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    interface IHistory
    {
        HistoryDTO AddHistory(HistoryDTO history);
        HistoryDTO ChangeHistory(HistoryDTO history);
        void ShowHistorySorted(int n);
        void ShowHistory();
        void RemoveHistory(int ID);
        HistoryDTO GetHistory(int ID);
    }
}
