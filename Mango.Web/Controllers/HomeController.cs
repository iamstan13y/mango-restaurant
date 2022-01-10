using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Login()
        { 
            return RedirectToAction(nameof(Index));
        }
        
        public IActionResult Logout()
        { 
            return SignOut("Cookies", "iodc");
        }

    }
}
