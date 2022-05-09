using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RaoVar247.Models;
namespace RaoVar247.Controllers
{
    public class HomeController : Controller
    {
        Db db = new Db();
        public ActionResult Index()
        {
            var list = db.Products.ToList();
            return View(list);
        }
        public ActionResult PostNewProduct()
        {
            if(Session["UserName"] != null)
            {
                ViewBag.SubCategoryId = new SelectList(db.SubCategories, "SubCategoryId", "SubCategoryName");
                return View();
            }
            else
            {
                TempData["RequiredLogin"] = "Bạn cần đăng nhập để thực hiện đăng tin";
                return RedirectToAction("Login", "User");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostNewProduct(Product product)
        {
            //ok
            ViewBag.SubCategoryId = new SelectList(db.SubCategories, "SubCategoryId", "SubCategoryName");
            

                if (ModelState.IsValid)
                {
                    // add data
                    //Product product = new Product();
                    //product.ProductName = collection["ProductName"];
                    //product.Price = Convert.ToDecimal(collection["Price"]);
                    //product.Description = collection["Description"];
                    //product.Address = collection["Address"];
                    //product.SubCategoryId = Convert.ToInt32(collection["SubCategoryId"]);
                    product.CreateDate = DateTime.Now;
                    var f = Request.Files["product-img-file"];
                    if (f != null && f.ContentLength > 0)
                    {
                        string FileName = Path.GetFileName(f.FileName);
                        string UploadPath = Server.MapPath("~/Content/Images/" + FileName);
                        f.SaveAs(UploadPath);
                        product.ImagePath = FileName;
                    product.UserId = (int)Session["UserId"];
                    }
                    db.Products.Add(product);
                    db.SaveChanges();
                    TempData["Nofi"] = "Đăng tin thanh công";
                    return RedirectToAction("Index", "Home");
                }
                else
                    return View();
        }
           
        public ActionResult Detail(int productId)
        {
            return View(db.Products.First(p => p.ProductId == productId));
        }
        

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Product(int categoryId = -1,int subcategoryId = -1,string searchstring = null,int priceLevel = -1)
        {
            var list = db.Products.ToList();
            if(searchstring != null)
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

            if(priceLevel != -1)
            {
                switch (priceLevel)
                {
                    case 1: list = list.Where(p => p.Price <= 500000).ToList();break;
                    case 2: list = list.Where(p => p.Price >= 500000 && p.Price <= 1000000).ToList();break;
                    case 3: list = list.Where(p => p.Price >= 1000000).ToList();break;
                    default:
                        break;
                }
            }

            return View(list);
        }

        public PartialViewResult CategoryList()
        {
            return PartialView(db.Categories.ToList());
        }
        public PartialViewResult SubcategoryList(int categoryId)
        {
            return PartialView(db.SubCategories.Where(sc => sc.CategoryId == categoryId).ToList());
        }
        public PartialViewResult GetListProductByUser(int userId)
        {
            return PartialView(db.Products.Where(p=>p.UserId == userId).ToList());
        }
    }
}