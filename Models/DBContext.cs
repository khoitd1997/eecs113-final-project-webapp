using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace eecs113_final_project_webapp.Models
{
    public class DBContext
    {
        public string ConnectionString { get; set; }

        public DBContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public List<PHLogger> GetAllPHLoggers()
        {
            var list = new List<PHLogger>();
            using (var conn = GetConnection())
            {
                conn.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT T.phlid, T.email ");
                sb.Append("FROM Test T ");
                String sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new PHLogger()
                            {
                                PHlid = reader.GetString(0),
                                Email = reader.GetString(1)
                            });
                        }
                    }
                }
            }
            return list;
        }
    }
}