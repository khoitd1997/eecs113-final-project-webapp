using System;
using System.Collections.Generic;

namespace eecs113_final_project_webapp.Models
{
    public class SummaryReport
    {
        private DBContext context;

        public List<WeatherData> WeatherDatas { get; private set; }
        public List<ActionEvent> ActionEvents { get; private set; }

        public SummaryReport(List<WeatherData> weatherDatas, List<ActionEvent> actionEvents)
        {
            WeatherDatas = weatherDatas;
            ActionEvents = actionEvents;
        }
    }
}