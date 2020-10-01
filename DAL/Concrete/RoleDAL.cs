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
    public class RoleDAL : IRoleDAL
    {
        private string _connectionString;
        public RoleDAL(string connectionString)
        {
            this._connectionString = connectionString;
        }
        public RoleDTO CreateRole(RoleDTO role)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into User (RoleName,Description)  values (@RoleName, @Description)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@FullName", role.RoleName);
                comm.Parameters.AddWithValue("@Mail", role.Description);

                conn.Open();

                role.ID = Convert.ToInt32(comm.ExecuteScalar());
                return role;
            }
        }

        public void DeleteRole(int id)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from Role where ID = @ID";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@ID", id);
                conn.Open();

                comm.ExecuteNonQuery();
            }
        }

        public List<RoleDTO> GetAllRoles()
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from User";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<RoleDTO> role = new List<RoleDTO>();
                while (reader.Read())
                {

                    role.Add(new RoleDTO
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        RoleName = reader["RoleName"].ToString(),
                        Description = reader["Description"].ToString()
                    });
                }
                return role;
            }
        }

        public RoleDTO GetRoleById(int id)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                RoleDTO role = new RoleDTO();

                comm.CommandText = $"select * from Role where ID={id}";

                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {

                    role = new RoleDTO
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        RoleName = reader["RoleName"].ToString(),
                        Description = reader["Descriotion"].ToString()
                    };
                }
                return role;
            }
        }

        public RoleDTO UpdateRole(RoleDTO role)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "update Role set RoleName= @RoleName, Description=@Description where ID = @ID";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@ID", role.ID);
                comm.Parameters.AddWithValue("@RoleName", role.RoleName);
                comm.Parameters.AddWithValue("@Mail", role.Description);
                conn.Open();

                role.ID = Convert.ToInt32(comm.ExecuteScalar());


                return role;
            }
        }
    }
}
