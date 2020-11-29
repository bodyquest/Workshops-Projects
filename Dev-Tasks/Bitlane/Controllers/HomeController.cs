using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.RedirectToAction("Index", "Dashboard", new { area = "Administration" });
            }
            else
            {
                return this.RedirectToAction("login", "account", new { area = "identity" });
            }
        }
    }
}