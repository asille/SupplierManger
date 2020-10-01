using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IUser
    {
        UserDTO AddUser(UserDTO user);
        UserDTO ChangeUser(UserDTO user);
        void ShowUsersSorted(int n);
        void ShowUsers();
        void RemoveUser(int ID);
        UserDTO GetUser(int ID);
        UserDTO GetUserByName(string Name);
    }
}
