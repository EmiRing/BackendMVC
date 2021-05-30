using BackendTaskMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTaskMVC.Controllers
{
    [Route("FeverCheck")]
    public class FeverController : Controller
    {
        
        public IActionResult Evaluate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Evaluate(double temperature, string scale)
        {
            string message = FeverCheck.CalculateTemp(temperature, scale);
            
            ViewBag.FeverMessage = message;
            return View();
        }

    }
}
