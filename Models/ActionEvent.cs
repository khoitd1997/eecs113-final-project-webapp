using System;
using System.Linq;
using NpgsqlTypes;


namespace eecs113_final_project_webapp.Models
{
    public class ActionEvent
    {
        public enum EventType
        {
            [PgName("watering_start")]
            WateringStart,
            [PgName("watering_end")]
            WateringEnd,
            [PgName("watering_continue")]
            WateringContinue,
            [PgName("human_detected")]
            HumanDetected
        }
        private DBContext context;
        public Int32 ID { get; private set; }
        public EventType Type { get; private set; }
        public String TypeString
        {
            get
            {
                var memberInfo = typeof(EventType).GetMember(Type.ToString())
                                                  .FirstOrDefault();

                if (memberInfo != null)
                {
                    var attribute = (PgNameAttribute)
                                 memberInfo.GetCustomAttributes(typeof(PgNameAttribute), false)
                                           .FirstOrDefault();
                    return attribute.PgName;
                }

                throw new System.ArgumentException("Parameter cannot be null", "memberInfo");
                return "";
            }
        }
        public DateTime Timestamp { get; private set; }

        public ActionEvent(Int32 id, EventType type, DateTime timestamp)
        {
            ID = id;
            Type = type;
            Timestamp = timestamp;
        }
    }
}