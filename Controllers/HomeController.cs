using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using eecs113_final_project_webapp.Models;

namespace eecs113_final_project_webapp.Controllers
{
    public class HomeController : Controller
    {
        private int MaxEventLogRow_ = 15;
        public IActionResult Summary()
        {
            var summaryReportCtx = HttpContext.RequestServices.GetService(typeof(eecs113_final_project_webapp.Models.DBContext)) as DBContext;

            return View(summaryReportCtx.GetSummaryReport());
        }

        public IActionResult EventLog()
        {
            var searchTarget = HttpContext.Request.Query["target"].ToList();
            var displayColumn = HttpContext.Request.Query["category"].ToList();

            var eventCtx = HttpContext.RequestServices.GetService(typeof(eecs113_final_project_webapp.Models.DBContext)) as DBContext;

            if (searchTarget.Count() == 0)
            {
                return View(eventCtx.GetMostRecentActionEvents(MaxEventLogRow_));
            }
            else
            {
                if (String.IsNullOrEmpty(displayColumn[0]))
                {
                    return View(eventCtx.GetMostRecentActionEvents(MaxEventLogRow_));
                }
                return View(eventCtx.SearchActionEvents(searchTarget[0], displayColumn[0]));
            }
        }

        public IActionResult DataGraph()
        {
            var graphCtx = HttpContext.RequestServices.GetService(typeof(eecs113_final_project_webapp.Models.DBContext)) as DBContext;

            return View(graphCtx.GetMostRecentHourlyWeatherData(10));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
