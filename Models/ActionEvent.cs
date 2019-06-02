using System;
using System.Linq;
using System.Runtime.Serialization;
using NpgsqlTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace eecs113_final_project_webapp.Models
{
    public class ActionEvent
    {
        [JsonConverter(typeof(StringEnumConverter))]

        public enum EventType
        {
            [PgName("watering_start")]
            [EnumMember(Value = "watering_start")]
            WateringStart,

            [PgName("watering_end")]
            [EnumMember(Value = "watering_end")]
            WateringEnd,

            [PgName("watering_continue")]
            [EnumMember(Value = "watering_continue")]
            WateringContinue,

            [PgName("human_detected")]
            [EnumMember(Value = "human_detected")]
            HumanDetected
        }
        public static bool IsValidEvent(string actionEvent)
        {
            var possibleEvents = Enum.GetValues(typeof(EventType)).Cast<EventType>().ToList();
            foreach (var possibleEvent in possibleEvents)
            {
                if (getEnumStr(possibleEvent) == actionEvent)
                {
                    return true;
                }
            }
            return false;
        }
        private static string getEnumStr(EventType actionEvent)
        {
            var memberInfo = typeof(EventType).GetMember(actionEvent.ToString())
                                                  .FirstOrDefault();

            if (memberInfo != null)
            {
                var attribute = (PgNameAttribute)
                             memberInfo.GetCustomAttributes(typeof(PgNameAttribute), false)
                                       .FirstOrDefault();
                return attribute.PgName;
            }
            throw new System.ArgumentException("Parameter cannot be null", "memberInfo");
        }
        private DBContext context;
        public Int32 ID { get; private set; }

        [JsonProperty("etype")]
        public EventType Type { get; private set; }
        public String TypeString
        {
            get
            {
                return getEnumStr(Type);
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