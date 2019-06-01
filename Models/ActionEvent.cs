using System;

namespace eecs113_final_project_webapp.Models
{
    public class ActionEvent
    {
        private DBContext context;
        public Int32 ID { get; private set; }
        public string Type { get; private set; }
        public DateTime StartTime { get; private set; }

        public ActionEvent(Int32 id, string type, DateTime startTime)
        {
            ID = id;
            Type = type;
            StartTime = startTime;
        }
    }
}