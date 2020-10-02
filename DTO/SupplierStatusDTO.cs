using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SupplierStatusDTO
    {
        public int ID { get; set; }
        public string StatusName { get; set; }
        public bool SupplierStatus   { get; set; }
        public DateTime DateTime { get; set; }

    }
}
