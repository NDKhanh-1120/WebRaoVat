using RaoVar247.Models;
using RaoVar247.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace RaoVar247.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        Db db = new Db();
        public ActionResult Index(int categoryId = -1, int subcategoryId = -1, int page = 1,string searchstring = null, int priceLevel = -1, int calc_shipping_provinces = -1, string calc_shipping_district = null)
        {
            var list = db.Products.ToList();
            if (searchstring != null)
            {
                list = list.Where(c => c.ProductName.Contains(searchstring)).ToList();
            }
            else
            if (subcategoryId == -1)
            {
                ViewBag.Level = "category";
                ViewBag.CurrentCategoryId = categoryId;
                list = list.Where(c => c.SubCategory.CategoryId == categoryId).ToList();
            }
            else
            {
                ViewBag.Level = "subcategory";
                ViewBag.CurrentSubcategoryId = subcategoryId;
                list = list.Where(c => c.SubCategoryId == subcategoryId).ToList();
            }

            if (priceLevel != -1)
            {
                switch (priceLevel)
                {
                    case 1: list = list.Where(p => p.Price <= 500000).ToList(); break;
                    case 2: list = list.Where(p => p.Price >= 500000 && p.Price <= 1000000).ToList(); break;
                    case 3: list = list.Where(p => p.Price >= 1000000).ToList(); break;
                    default:
                        break;
                }
            }
            if (calc_shipping_provinces != -1)
            {
                list = list.Where(p => p.Province == calc_shipping_provinces.ToString()).ToList();
                if (!string.IsNullOrEmpty(calc_shipping_district))
                {
                    list = list.Where(p => p.District == calc_shipping_district).ToList();
                }
            }

            

            return View(list.ToPagedList(page,12));
        }

        public ActionResult Delete(int productId)
        {
            ProductServices.DeleteById(productId);
            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}