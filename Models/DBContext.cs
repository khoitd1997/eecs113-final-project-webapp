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
            NpgsqlConnection.GlobalTypeMapper.MapEnum<ActionEvent.EventType>("event_type");
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
                query.Append(@"SELECT T.phlid, T.email 
                FROM Test T");
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
        public List<ActionEvent> GetMostRecentActionEvents(int maxTotalRow)
        {
            var list = new List<ActionEvent>();

            using (var conn = GetConnection())
            {
                conn.Open();

                StringBuilder query = new StringBuilder();
                query.Append($@"SELECT A.eid, A.etype, A.time_stamp
                FROM action_event A
                ORDER BY A.time_stamp DESC
                LIMIT {maxTotalRow}; ");

                String sqlQuery = query.ToString();

                using (var command = new NpgsqlCommand(sqlQuery, conn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ActionEvent(
                                reader.GetInt32(0),
                                reader.GetFieldValue<ActionEvent.EventType>(1),
                                reader.GetDateTime(2))
                            );
                        }
                    }
                }
            }
            return list;
        }

        public List<WeatherData> GetMostRecentHourlyWeatherData(int maxTotalRow)
        {
            var list = new List<WeatherData>();

            using (var conn = GetConnection())
            {
                conn.Open();

                StringBuilder query = new StringBuilder();
                query.Append($@"SELECT W.wid, W.temperature, W.humidity, W.water_saved, W.time_stamp
                FROM weather_data W
                ORDER BY W.time_stamp DESC
                LIMIT {maxTotalRow};
                ");

                String sqlQuery = query.ToString();

                using (var command = new NpgsqlCommand(sqlQuery, conn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new WeatherData(
                                reader.GetInt32(0),
                                reader.GetDouble(1),
                                reader.GetDouble(2),
                                reader.GetDouble(3),
                                reader.GetDateTime(4)
                            ));
                        }
                    }
                }
            }
            return list;
        }

        public SummaryReport GetSummaryReport()
        {
            var actionEvents = GetMostRecentActionEvents(3);
            var weatherDatas = GetMostRecentHourlyWeatherData(3);

            return new SummaryReport(weatherDatas, actionEvents);
        }
    }
}