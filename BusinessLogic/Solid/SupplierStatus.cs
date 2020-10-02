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
    public class SupplierStatus : ISupplierStatus
    {
        private readonly ISupplierStatusDAL _supplierStatusDAL;




        public SupplierStatus(ISupplierStatusDAL supplierStatusDAL)
        {
            _supplierStatusDAL = supplierStatusDAL;
        }

        public SupplierStatusDTO AddStatus(SupplierStatusDTO supplierStatus)
        {
            Console.WriteLine("Enter Status Name, Supplier Status, Date and Time");
            supplierStatus = new SupplierStatusDTO
            {
                StatusName = Console.ReadLine(),
                SupplierStatus = Convert.ToBoolean(Console.ReadLine()),
                DateTime = Convert.ToDateTime(Console.ReadLine())
            };



            return _supplierStatusDAL.CreateStatus(supplierStatus);
        }


        public void RemoveStatus(int ItemID)
        {
            Console.WriteLine("Enter ID to delete:");
            SupplierStatusDTO supplierStatus = new SupplierStatusDTO();
            supplierStatus.ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Deleting supplierStatus ID: {supplierStatus.ID}");
            _supplierStatusDAL.DeleteStatus(supplierStatus.ID);
        }

        public SupplierStatusDTO GetStatus(int id)
        {
            return _supplierStatusDAL.GetStatusById(id);
        }

        public void ShowStatuses()
        {
            Console.WriteLine("All Supplier Statuses:\n");
            Console.WriteLine("Id\tName\tStatus");
            foreach (var supplierStatus in _supplierStatusDAL.GetAllStatuses())
            {
                Console.WriteLine($"{supplierStatus.ID}\t{supplierStatus.StatusName}\t{supplierStatus.SupplierStatus}");

            }
        }

        public SupplierStatusDTO ChangeStatus(SupplierStatusDTO supplierStatus)
        {
            Console.WriteLine("Change supplierStatus inf0: \n");
            Console.WriteLine("ItemID, new Price, left OnStock");
            Console.WriteLine("Enter Status Name, Supplier Status, Date and Time");
            supplierStatus = new SupplierStatusDTO
            {
                StatusName = Console.ReadLine(),
                SupplierStatus = Convert.ToBoolean(Console.ReadLine()),
                DateTime = Convert.ToDateTime(Console.ReadLine())
            };


            return _supplierStatusDAL.UpdateStatuse(supplierStatus);
        }

       
    }
}

