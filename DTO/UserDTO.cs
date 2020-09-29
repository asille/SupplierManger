using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Mail { get; set; }
        public string Login { get; set; }
        public byte Password { get; set; }
        public int RoleID { get; set; }
        public int SupplierStatusID { get; set; }

    }
}
