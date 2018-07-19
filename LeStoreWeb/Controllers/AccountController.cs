using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using LeStoreLibrary.Request.Account;
using LeStoreWeb.Utils;
using LeStoreLibrary;

namespace LeStoreWeb.Controllers
{
    public class AccountController : Controller
    {
       [Route("Create")]
       [HttpPost]
       [ValidateAntiForgeryToken]
       [LeStoreAttributes(PermisstionType.CreateAccount)]
       public ActionResult CreateAccount(CreateAccountRequest request)
       {
            return View();
       }
    }
}