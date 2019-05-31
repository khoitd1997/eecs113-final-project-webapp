using System;

namespace eecs113_final_project_webapp.Models
{
    public class WeatherData
    {
        private DBContext context;
        public int ID { get; set; }
        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public float WaterSaved { get; set; }
        public DateTime RecordTime { get; set; }
    }
}