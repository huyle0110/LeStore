using LeStoreLibrary;
using LeStoreLibrary.Model;
using LeStoreLibrary.Request.Product;
using LeStoreWeb.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeStoreWeb.Controllers
{
    public class ProductController : Controller
    {
        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [LeStoreAttributes(AccountType.Admin, PermisstionType.CreateProduct)]
        public ActionResult CreateProduct(CreateProductRequest request)
        {
            return View();
        }

        [Route("Update")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [LeStoreAttributes(AccountType.Admin, PermisstionType.UpdateProduct)]
        public ActionResult UpdateProduct(UpdateProductRequest request)
        {
            return View();
        }

        [Route("Search")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [LeStoreAttributes(AccountType.Admin, PermisstionType.SearchProduct)]
        public ActionResult SearchProduct(SearchProductRequest request)
        {
            return View();
        }

        [Route("Delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [LeStoreAttributes(AccountType.Admin, PermisstionType.DeleteProduct)]
        public ActionResult DeleteProduct(DeleteProductRequest request)
        {
            return View();
        }
    }
}