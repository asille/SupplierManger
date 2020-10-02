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
    public class SupplierStatusDAL : ISupplierStatusDAL
    {
        private string _connectionString;
        public SupplierStatusDAL(string connectionString)
        {
            this._connectionString = connectionString;
        }
        public SupplierStatusDTO CreateStatus(SupplierStatusDTO supplierStatus)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into SupplierStatus (StatusName, SupplierStatus, Date/Time)  values (@StatusName, @SupplierStatus, @Date/Time)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@FullName", supplierStatus.StatusName);
                comm.Parameters.AddWithValue("@Mail", supplierStatus.SupplierStatus);
                comm.Parameters.AddWithValue("@Login", supplierStatus.DateTime);

                conn.Open();

                supplierStatus.ID = Convert.ToInt32(comm.ExecuteScalar());
                return supplierStatus;
            }
        }

        public void DeleteStatus(int id)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from SupplierStatus where ID = @ID";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@ID", id);
                conn.Open();

                comm.ExecuteNonQuery();
            }
        }


        public SupplierStatusDTO GetStatusById(int id)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                SupplierStatusDTO supplierStatus = new SupplierStatusDTO();

                comm.CommandText = $"select * from User where ID={id}";

                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {

                    supplierStatus = new SupplierStatusDTO
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        StatusName = reader["StatusName"].ToString(),
                        SupplierStatus = Convert.ToBoolean(reader["SupplierStatus"]),
                        DateTime = Convert.ToDateTime(reader["Date/Time"])

                    };
                }

                return supplierStatus;
            }
        }

        public SupplierStatusDTO UpdateStatuse(SupplierStatusDTO supplierStatus)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "update SupplierStatus set StatusName= @StatusName, SupplierStatus=@SupplierStatus where ID = @ID";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@ID", supplierStatus.ID);
                comm.Parameters.AddWithValue("@StatusName", supplierStatus.StatusName);
                comm.Parameters.AddWithValue("@SupplierStatus", supplierStatus.SupplierStatus);
                conn.Open();

                supplierStatus.ID = Convert.ToInt32(comm.ExecuteScalar());


                return supplierStatus;
            }
        }

        public List<SupplierStatusDTO> GetAllStatuses()
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from User";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<SupplierStatusDTO> supplierStatus = new List<SupplierStatusDTO>();
                while (reader.Read())
                {

                    supplierStatus.Add(new SupplierStatusDTO
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        StatusName = reader["StatusName"].ToString(),
                        SupplierStatus = Convert.ToBoolean(reader["SupplierStatus"]),
                        DateTime = Convert.ToDateTime(reader["Date/Time"])
                    });
                }

                return supplierStatus;
            }
        }
    }
}
