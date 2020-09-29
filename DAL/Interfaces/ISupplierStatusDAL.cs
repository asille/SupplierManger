using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ISupplierStatusDAL
    {
        SupplierStatusDTO GetStatusById(int id);
        List<SupplierStatusDTO> GetAllStatuses();
        SupplierStatusDTO UpdateStatuse(SupplierStatusDTO supplierStatus);
        SupplierStatusDTO CreateStatus(SupplierStatusDTO supplierStatus);
        void DeleteStatus(int id);
    }
}
