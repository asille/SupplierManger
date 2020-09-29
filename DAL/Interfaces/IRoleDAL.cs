using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRoleDAL
    {
        RoleDTO GetRoleById(int id);
        List<RoleDTO> GetAllRoles();
        RoleDTO UpdateRole(RoleDTO role);
        RoleDTO CreateRole(RoleDTO role);
        void DeleteRole(int id);
    }
}
