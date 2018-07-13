using LeStoreLibrary.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeStoreWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("Login")]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AccountLoginRequest request)
        {
            return View();
        }

        [HttpGet]
        [Route("Login")]
        public ActionResult Login()
        {
            return View("Login");
        }
    }
}