using RaoVar247.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RaoVar247.Areas.admin.Controllers
{
    public class ProductsController : Controller
    {
        // GET: admin/Products
        public ActionResult Index()
        {
            return View(ProductServices.GetAllProduct());
        }

        // POST: admin/Products/Delete/5
        [HttpPost]
        public ActionResult DeleteProduct(int productId)
        {
            try
            {
                ProductServices.DeleteById(productId);

                return RedirectToAction("Index");
            }
            catch
            {
                throw;
            }
        }
    }
}
