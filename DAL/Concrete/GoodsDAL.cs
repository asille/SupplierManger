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
    class GoodsDAL : IGoodsDAL
    {
        private string _connectionString;
        public GoodsDAL(string connectionString)
        {
            this._connectionString = connectionString;
        }
        public GoodsDTO CreateGoods(GoodsDTO goods)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into User (Name, Price, Description)  values (@FullName, @Mail, @Login, @Password)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@FullName", goods.Name);
                comm.Parameters.AddWithValue("@Mail", goods.Price);
                comm.Parameters.AddWithValue("@Login", goods.Description);

                conn.Open();

                goods.ID = Convert.ToInt32(comm.ExecuteScalar());
                return goods;
            }
        }

        public void DeleteGoods(int id)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from Goods where ID = @ID";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@ID", id);
                conn.Open();

                comm.ExecuteNonQuery();
            }
        }

        public List<GoodsDTO> GetAllGoods()
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from Goods";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<GoodsDTO> goods = new List<GoodsDTO>();
                while (reader.Read())
                {
                    goods.Add(new GoodsDTO
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Name = reader["Name"].ToString(),
                        Description = reader["Description"].ToString()
                    });

                }

                return goods;
            }
        }

        public List<GoodsDTO> GetAllGoodsSorted(int n)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {



                if (n == 1)
                {
                    comm.CommandText = "select * from Goods order by Name";
                }
                if (n == 2)
                {
                    comm.CommandText = "select * from Goods order by Description";

                }
                if (n == 3)
                { comm.CommandText = "select * from Goods order by ID"; }
                if (n == 4)
                {
                    comm.CommandText = "select * from Goods order by Price";
                }
                else
                { comm.CommandText = "select * from Goods"; }



                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<GoodsDTO> goods = new List<GoodsDTO>();
                while (reader.Read())
                {

                    goods.Add(new GoodsDTO
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Name = reader["Name"].ToString(),
                        Description = reader["Description"].ToString()
                    });
                }
                return goods;
            }
        }

        public GoodsDTO GetGoodsById(int id)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                GoodsDTO goods = new GoodsDTO();

                comm.CommandText = $"select * from User where ID={id}";

                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {

                    goods = new GoodsDTO
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Name = reader["Name"].ToString(),
                        Description = reader["Description"].ToString()
                    };
                }

                return goods;
            }
        }

        public GoodsDTO GetGoodsByName(string name)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                GoodsDTO goods = new GoodsDTO();

                comm.CommandText = $"select * from User where Name={name}";

                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {

                    goods = new GoodsDTO
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Name = reader["Name"].ToString(),
                        Description = reader["Description"].ToString()
                    };
                }

                return goods;
            }
        }

        public GoodsDTO UpdateGoods(GoodsDTO goods)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "update Goods set Name= @Name,Price = @Price, Description=@Description where ID = @ID";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@ID", goods.ID);
                comm.Parameters.AddWithValue("@Name", goods.Name);
                comm.Parameters.AddWithValue("@Price", goods.Price);
                comm.Parameters.AddWithValue("@Description", goods.Description);
                conn.Open();

                goods.ID = Convert.ToInt32(comm.ExecuteScalar());


                return goods;
            }
        }
    }
}
