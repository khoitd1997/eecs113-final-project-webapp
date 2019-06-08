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
            CreateTable();
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

                sb.Append(@"
                    DROP TABLE IF EXISTS action_event;
                    DROP TYPE IF EXISTS event_type;
                    CREATE TYPE event_type AS ENUM ('watering_start', 'watering_end', 'watering_continue',                  'human_detected');
                    CREATE TABLE action_event
                    (
                        eid        SERIAL PRIMARY KEY,
                        etype      event_type               NOT NULL,
                        time_stamp TIMESTAMP WITH TIME ZONE NOT NULL DEFAULT NOW()
                    );

                    DROP TABLE IF EXISTS weather_data;
                    CREATE TABLE weather_data
                    (
                        wid         SERIAL PRIMARY KEY,
                        temperature float                    NOT NULL,
                        humidity    float                    NOT NULL,
                        water_saved float                    NOT NULL,
                        time_stamp TIMESTAMP WITH TIME ZONE NOT NULL DEFAULT NOW()
                    );
                ");

                String sql = sb.ToString();

                var command = new NpgsqlCommand(sql, conn);
                command.ExecuteReader();
            }
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

        private (string, string) formatActionEventArg(string target, string displayColumn)
        {
            switch (displayColumn)
            {
                case "ID":
                    if (int.TryParse(target, out _))
                    {
                        return (target, "eid");
                    }
                    return ("", "eid");

                case "Type":
                    if (ActionEvent.IsValidEvent(target))
                    {
                        return ("'" + target + "'", "etype");
                    }
                    else
                    {
                        return ("", "etype");
                    }
                default:
                    throw new ArgumentException("unsupported display column");
            }
        }
        public List<ActionEvent> SearchActionEvents(string target, string displayColumn)
        {
            var list = new List<ActionEvent>();
            var (sqlTarget, sqlColumn) = formatActionEventArg(target, displayColumn);

            if (String.IsNullOrEmpty(sqlTarget))
            {
                return list;
            }
            using (var conn = GetConnection())
            {
                conn.Open();

                StringBuilder query = new StringBuilder();
                query.Append($@"SELECT A.eid, A.etype, A.time_stamp
                FROM action_event A
                WHERE A.{sqlColumn} = {sqlTarget}
                ORDER BY A.time_stamp DESC;");

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

        public async void AddActionEvent(ActionEvent actionEvent)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                StringBuilder sb = new StringBuilder();

                sb.Append($@"
                    INSERT INTO action_event(etype)
                    VALUES ('{actionEvent.TypeString}');
                ");
                String sql = sb.ToString();

                var command = new NpgsqlCommand(sql, conn);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    await reader.ReadAsync();
                }
            }
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

        public async void AddWeatherData(WeatherData weatherData)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                StringBuilder sb = new StringBuilder();

                if (weatherData.Timestamp == default(DateTime))
                {
                    sb.Append($@"
                    INSERT INTO weather_data(temperature, humidity, water_saved)
                    VALUES ({weatherData.Temperature}, {weatherData.Humidity}, {weatherData.WaterSaved});
                    ");
                }
                else
                {
                    sb.Append($@"
                    INSERT INTO weather_data(temperature, humidity, water_saved, time_stamp)
                    VALUES ({weatherData.Temperature}, {weatherData.Humidity}, {weatherData.WaterSaved},'{weatherData.Timestamp.ToString("MM/dd/yyyy HH:mm:ss")}');");
                }

                String sql = sb.ToString();

                var command = new NpgsqlCommand(sql, conn);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    await reader.ReadAsync();
                }
            }
        }


        public SummaryReport GetSummaryReport()
        {
            var actionEvents = GetMostRecentActionEvents(3);
            var weatherDatas = GetMostRecentHourlyWeatherData(3);

            return new SummaryReport(weatherDatas, actionEvents);
        }
    }
}