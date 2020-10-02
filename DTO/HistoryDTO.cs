using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HistoryDTO
    {
        public int ID { get; set; }
        public int Count { get; set; }
        public DateTime DateTime { get; set; }
        public int GoodID { get; set; }
        public int UserID { get; set; }

    }
}
