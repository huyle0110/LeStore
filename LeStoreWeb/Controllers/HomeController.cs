using LeStoreLibrary;
using LeStoreLibrary.Properties;
using LeStoreLibrary.Request;
using LeStoreService.Service;
using LeStoreWeb.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeStoreWeb.Controllers
{
    public class HomeController : Controller
    {
        AccountService service = new AccountService();

        [Route("/")]
        public ActionResult Index()
        {
            //if (LeStoreSession.IsLogin())
            //{
            //    return RedirectToAction("Login", "Home");
            //}
            return View();
        }

        [Route("admin")]
        public ActionResult Admin()
        {
            return View();
        }


        [HttpPost]
        [Route("Login")]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AccountLoginRequest request)
        {
            if (request.CheckValid() != ReturnCode.Success)
            {
                LeStoreSession.ClearSession();
                this.ViewBag.Message = "Login not success";
                return View();
            }

            var resLogin = service.AccountLogin(request);
            // if login success so save to session
            if (resLogin.Code == ReturnCode.Success)
            {
                this.Session["User"] = new UserSession() {
                    Account = resLogin.Account,
                    permissions = resLogin.PermissionTypes
                };
                return Redirect("/");
            }
            else
            {
                switch(resLogin.Code)
                {
                    case ReturnCode.Account_NotExist:
                        this.ViewBag.MessageInfo = Resources_MSG.MSG_0000;
                        break;
                    case ReturnCode.Fail:
                        this.ViewBag.MessageInfo = Resources_MSG.MSG_0001;
                        break;
                }
            }

            return View();
        }

        [HttpGet]
        [Route("Login")]
        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpGet]
        [Route("Logout")]
        public ActionResult Logout()
        {
            LeStoreSession.ClearSession();
            return Redirect("/");
        }
    }
}