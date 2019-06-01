using System;

namespace eecs113_final_project_webapp.Models
{
    public class WeatherData
    {
        private DBContext context;
        public Int32 ID { get; private set; }
        public double Temperature { get; private set; }
        public double Humidity { get; private set; }
        public double WaterSaved { get; private set; }
        public DateTime Timestamp { get; private set; }

        public WeatherData(Int32 id, double temperature, double humidity, double waterSaved, DateTime timestamp)
        {
            ID = id;
            Temperature = temperature;
            Humidity = humidity;
            WaterSaved = waterSaved;
            Timestamp = timestamp;
        }
    }
}