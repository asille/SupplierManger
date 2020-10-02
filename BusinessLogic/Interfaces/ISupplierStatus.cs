using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ISupplierStatus
    {
        SupplierStatusDTO AddStatus(SupplierStatusDTO supplierStatus);
        SupplierStatusDTO ChangeStatus(SupplierStatusDTO supplierStatus);
        void ShowStatuses();
        void RemoveStatus(int ID);
        SupplierStatusDTO GetStatus(int ID);

    }
}
