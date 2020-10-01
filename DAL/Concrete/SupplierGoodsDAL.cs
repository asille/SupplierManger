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
    public class SupplierGoodsDAL : ISupplierGoodsDAL
    {
        private string _connectionString;
        public SupplierGoodsDAL(string connectionString)
        {
            this._connectionString = connectionString;
        }
        public void DeleteSupplierGood(int id)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from SupplierGoods where ID = @ID";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@ID", id);
                conn.Open();

                comm.ExecuteNonQuery();
            }
        }

        public List<SupplierGoodsDTO> GetAllSupplierGoods()
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from User";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<SupplierGoodsDTO> supplierGoods = new List<SupplierGoodsDTO>();
                while (reader.Read())
                {

                    supplierGoods.Add(new SupplierGoodsDTO
                    {
                        ID = Convert.ToInt32(reader["ID"])
                    });
                }

                return supplierGoods;
            }
        }

        public SupplierGoodsDTO GetSupplierGoodById(int id)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                SupplierGoodsDTO supplierGoods = new SupplierGoodsDTO();

                comm.CommandText = $"select * from User where ID={id}";

                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {

                    supplierGoods = new SupplierGoodsDTO
                    {
                        ID = Convert.ToInt32(reader["ID"]),

                    };
                }

                return supplierGoods;
            }
        }

    }
}
