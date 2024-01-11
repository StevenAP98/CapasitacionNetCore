using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductosUI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ProductosUI.General;
using ProductosEnt;

namespace ProductosUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
