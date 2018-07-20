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
using LeStoreLibrary.Model;

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


        [Route("Update")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [LeStoreAttributes(AccountType.Admin, PermisstionType.UpdateAccount)]
        public ActionResult UpdateAccount(UpdateAccountRequest request)
        {
            return View();
        }

        [Route("Search")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [LeStoreAttributes(AccountType.Admin, PermisstionType.SearchAccount)]
        public ActionResult SearchAccount(SearchAccountRequest request)
        {
            return View();
        }

        [Route("Delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [LeStoreAttributes(AccountType.Admin, PermisstionType.DeleteAccount)]
        public ActionResult DeleteAccount(DeleteAccountRequest request)
        {
            return View();
        }
    }
}