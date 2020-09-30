using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    interface IRole
    {
        RoleDTO AddRole(RoleDTO role);
        RoleDTO ChangeRole(RoleDTO role);
        void ShowRolesSorted(int n);
        void ShowRole();
        void RemoveRole(int ID);
        RoleDTO GetRole(int ID);
    }
}
