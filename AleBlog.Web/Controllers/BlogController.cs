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
    public class BlogController : Controller
    {
        [Route("/Blog/Page")]
        public IActionResult Page()
        {
            return View();
        }
    }
}
