using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    class UserDAL : IUserDAL
    {
        public RoleDal(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public UserDTO CreateUser(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserDTO> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public UserDTO GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public UserDTO UpdateUser(UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
