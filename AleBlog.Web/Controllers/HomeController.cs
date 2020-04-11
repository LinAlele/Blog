using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AleBlog.Web.Models;

namespace AleBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        [Route("/index.html")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
