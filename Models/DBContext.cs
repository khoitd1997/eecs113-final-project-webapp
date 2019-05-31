using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;

using Npgsql;


namespace eecs113_final_project_webapp.Models
{
    public class DBContext
    {
        public string ConnectionString { get; set; }

        public DBContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(ConnectionString);
        }

        public void CreateTable()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                StringBuilder sb = new StringBuilder();
                // sb.Append(@"DROP DATABASE IF EXISTS eecs113;
                //         CREATE DATABASE eecs113;
                //         ");
                sb.Append("DROP TABLE IF EXISTS Test;");
                sb.Append(@"CREATE TABLE Test(
                    phlid  	VARCHAR(8),
                    email		VARCHAR(70) NOT NULL,
                    pswd		CHAR(32) NOT NULL,
                    PRIMARY KEY (phlid)
                );");
                sb.Append(@"
                INSERT INTO Test VALUES ('1','tereasa.feest@uci.com','klfsadjlfadjklsjlfkas');
                INSERT INTO Test VALUES ('2','kd.feest@uci.com','fkasldfjlads');
                INSERT INTO Test VALUES('3','delta.feest@uci.com','fkasldfjlads'); ");
                String sql = sb.ToString();

                var command = new NpgsqlCommand(sql, conn);
                command.ExecuteReader();
            }
        }

        public List<PHLogger> GetAllPHLoggers()
        {
            var list = new List<PHLogger>();

            using (var conn = GetConnection())
            {
                conn.Open();

                StringBuilder query = new StringBuilder();
                query.Append("SELECT T.phlid, T.email ");
                query.Append("FROM Test T ");
                String sqlQuery = query.ToString();

                using (var command = new NpgsqlCommand(sqlQuery, conn))
                {
                    using (var reader = command.ExecuteReader())
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