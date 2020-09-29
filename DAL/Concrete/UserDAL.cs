using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    class UserDAL : IUserDAL
    {
        private string _connectionString;
        public UserDAL(string connectionString)
        {
            this._connectionString = connectionString;
        }
        public UserDTO CreateUser(UserDTO user)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into User (FullName, Mail, Login,Password)  values (@fullname, @mail, @login, @password)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@title", user.FullName);
                comm.Parameters.AddWithValue("@title", user.Mail);
                comm.Parameters.AddWithValue("@title", user.Login);
                comm.Parameters.AddWithValue("@title", user.Password);

                conn.Open();

                user.ID = Convert.ToInt32(comm.ExecuteScalar());
                return user;
            }
        }

        public void DeleteUser(int id)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from User where ID = @ID";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@ID", id);
                conn.Open();

                comm.ExecuteNonQuery();
            }
        }

        public List<UserDTO> GetAllUsers()
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from User";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<UserDTO> items = new List<UserDTO>();
                while (reader.Read())
                {

                    items.Add(new UserDTO
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        FullName = reader["FullName"].ToString(),
                        Mail = reader["Mail"].ToString(),
                        Login = reader["Login"].ToString(),
                        Password = Convert.ToByte(reader["Password"])
                    });
                }

                return items;
            }
        }
        public List<UserDTO> GetAllUsersSorted()
        {
            throw new NotImplementedException();
        }

        public List<UserDTO> GetAllUsersSorted(int n)
        {
            throw new NotImplementedException();
        }

        public UserDTO GetUserById(int id)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                UserDTO items = new UserDTO();

                comm.CommandText = $"select * from User where ID={id}";

                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {

                    items = new UserDTO
                    {
                        ID = Convert.ToInt32(reader["UserID"]),
                        FullName = reader["Name"].ToString(),
                        Mail = reader["Mail"].ToString(),
                        Login = reader["Login"].ToString(),
                    };
                }

                return items;
            }
        }

        public UserDTO GetUserByName(string name)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                UserDTO items = new UserDTO();

                comm.CommandText = $"select * from User where FullName={name}";

                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {

                    items = new UserDTO
                    {
                        ID = Convert.ToInt32(reader["UserID"]),
                        FullName = reader["Name"].ToString(),
                        Mail = reader["Mail"].ToString(),
                        Login = reader["Login"].ToString(),
                    };
                }

                return items;
            }
        }

        public UserDTO UpdateUser(UserDTO user)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "update User set FullName= @FullName, Mail=@Mail where ID = @ID";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@ItemID", user.ID);
                //comm.Parameters.AddWithValue("@Name", item.Name);
                comm.Parameters.AddWithValue("@FullName", user.FullName);
                comm.Parameters.AddWithValue("@Mail", user.Mail);
                conn.Open();

                user.ID = Convert.ToInt32(comm.ExecuteScalar());


                return user;
            }
        }
    }
}
