using System;

namespace eecs113_final_project_webapp.Models
{
    public class ActionEvent
    {
        private DBContext context;
        public int ID { get; set; }
        public string Type { get; set; }
        public DateTime StartTime { get; set; }
    }
}