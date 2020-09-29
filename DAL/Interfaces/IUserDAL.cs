using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserDAL
    {
        UserDTO GetUserById(int id);
        UserDTO GetUserByName(string name);
        List<UserDTO> GetAllUsers();
        List<UserDTO> GetAllUsersSorted(int n);
        UserDTO UpdateUser(UserDTO user);
        UserDTO CreateUser(UserDTO user);
        void DeleteUser(int id);
    }
}
