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
    class HistoryDAL : IHistotyDAL
    {
        private string _connectionString;
        public HistoryDAL(string connectionString)
        {
            this._connectionString = connectionString;
        }
        public HistoryDTO CreateHistory(HistoryDTO history)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into User (Count, Date/Time)  values (@Count, @Date/Time)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@FullName", history.Count);
                comm.Parameters.AddWithValue("@Mail", history.DateTime);

                conn.Open();

                history.ID = Convert.ToInt32(comm.ExecuteScalar());
                return history;
            }
        }

        public void DeleteHistory(int id)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from History where ID = @ID";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@ID", id);
                conn.Open();

                comm.ExecuteNonQuery();
            }
        }

        public List<HistoryDTO> GetAllHistory()
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from User";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<HistoryDTO> history = new List<HistoryDTO>();
                while (reader.Read())
                {

                    history.Add(new HistoryDTO
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Count = Convert.ToInt32(reader["Count"]),
                        DateTime = Convert.ToDateTime(reader["Date/Time"])
                    });
                }

                return history;
            }
        }

        public List<HistoryDTO> GetAllHistorySorted(int n)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {



                if (n == 1)
                {
                    comm.CommandText = "select * from History order by Count";
                }
                if (n == 2)
                {
                    comm.CommandText = "select * from History order by Date/Time";

                }

                else
                { comm.CommandText = "select * from History"; }



                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<HistoryDTO> history = new List<HistoryDTO>();
                while (reader.Read())
                {

                    history.Add(new HistoryDTO
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Count = Convert.ToInt32(reader["Count"]),
                        DateTime = Convert.ToDateTime(reader["Date/Time"])
                    });
                }
                return history;
            }
        }

        public HistoryDTO GetHistoryById(int id)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                HistoryDTO history = new HistoryDTO();

                comm.CommandText = $"select * from User where ID={id}";

                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {

                    history = new HistoryDTO
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Count = Convert.ToInt32(reader["Count"]),
                        DateTime = Convert.ToDateTime(reader["Date/Time"])
                    };
                }

                return history;
            }
        }

        public HistoryDTO UpdateHistory(HistoryDTO history)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "update History set Count= @Count, Date/Time=@Date/Time where ID = @ID";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@ID", history.ID);
                comm.Parameters.AddWithValue("@Count", history.Count);
                comm.Parameters.AddWithValue("@Date/Time", history.DateTime);
                conn.Open();

                history.ID = Convert.ToInt32(comm.ExecuteScalar());


                return history;
            }
        }
    }
}
