﻿using System;
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
        public IActionResult Summary()
        {
            // ViewData["Title"] = "Yo Dawg";

            // var createContext = HttpContext.RequestServices.GetService(typeof(eecs113_final_project_webapp.Models.DBContext)) as DBContext;
            // createContext.CreateTable();

            // var queryContext = HttpContext.RequestServices.GetService(typeof(eecs113_final_project_webapp.Models.DBContext)) as DBContext;

            // return View(queryContext.GetAllPHLoggers());

            ViewData["Title"] = "Yo Dawg";

            var queryContext = HttpContext.RequestServices.GetService(typeof(eecs113_final_project_webapp.Models.DBContext)) as DBContext;

            return View(queryContext.GetMostRecentActionEvents(3));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
