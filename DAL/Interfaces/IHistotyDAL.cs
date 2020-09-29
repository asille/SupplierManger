using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IHistotyDAL
    {
        HistoryDTO GetHistoryById(int id);
        List<HistoryDTO> GetAllHistory();
        List<HistoryDTO> GetAllHistorySorted(int n);
        HistoryDTO UpdateHistory(HistoryDTO history);
        HistoryDTO CreateHistory(HistoryDTO history);
        void DeleteHistory(int id);
    }
}
