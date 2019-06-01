using System;

namespace eecs113_final_project_webapp.Models
{
    public class WeatherData
    {
        private DBContext context;
        public Int32 ID { get; set; }
        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public float WaterSaved { get; set; }
        public DateTime RecordTime { get; set; }
    }
}