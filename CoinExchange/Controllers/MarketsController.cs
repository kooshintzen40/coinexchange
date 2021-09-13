using CoinExchange.Models.Database.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using CoinExchange.Controllers;

namespace CoinExchange.Controllers
{

    public class MarketsController : Controller
    {

        public async Task<IActionResult> Index()
        {
            var j = new ApiController();
            var p = await j.GetPrices();
            
            ViewBag.id = new SelectList(p, "id", "name");
            return View(p);
        }


        public async Task<IActionResult> JSON(string c)
        {
            var j = new ApiController();
            var p = await j.GetGraph(c);

            return View(p);
        }
    }
}
