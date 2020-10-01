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
    public class Role : IRole
    {
        private readonly IRoleDAL _roleDAL;
        public Role(IRoleDAL roleDAL)
        {
            _roleDAL = roleDAL;
        }

        public RoleDTO AddRole(RoleDTO role)
        {
           Console.WriteLine("Enter Full Name, Mail, Login, Password");
            role = new RoleDTO
            {
                RoleName = Console.ReadLine(),
                Description = Console.ReadLine()
            };



            return _roleDAL.CreateRole(role);
        }

        public RoleDTO ChangeRole(RoleDTO role)
        {
            Console.WriteLine("Change role inf0: \n");
            Console.WriteLine("Role Name, Description");
            role = new RoleDTO
            {
                RoleName = Console.ReadLine(),
                Description = Console.ReadLine(),
            };


            return _roleDAL.UpdateRole(role);
        }

        public RoleDTO GetRole(int ID)
        {
            return _roleDAL.GetRoleById(ID);
        }

        public void RemoveRole(int ID)
        {
            Console.WriteLine("Enter ID to delete:");
            RoleDTO role = new RoleDTO();
            role.ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Deleting user ID: {role.ID}");
            _roleDAL.DeleteRole(role.ID);
        }

        public void ShowRoles()
        {
            Console.WriteLine("All roles:\n");
            Console.WriteLine("Id\tRoleName\tDescription");
            foreach (var role in _roleDAL.GetAllRoles())
            {
                Console.WriteLine($"{role.ID}\t{role.RoleName}\t{role.Description}");

            }
        }


    }
}
