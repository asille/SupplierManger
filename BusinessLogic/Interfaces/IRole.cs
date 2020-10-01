using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IRole
    {
        RoleDTO AddRole(RoleDTO role);
        void ShowRoles();
        RoleDTO ChangeRole(RoleDTO role);
        void RemoveRole(int ID);
        RoleDTO GetRole(int ID);
    }
}
