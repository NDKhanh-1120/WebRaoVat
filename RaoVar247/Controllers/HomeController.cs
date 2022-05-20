using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RaoVar247.Models;
using PagedList;
namespace RaoVar247.Controllers
{
    public class HomeController : Controller
    {
        Db db = new Db();
        public ActionResult Index()
        {
            var list = db.Products.ToList().Take(20);
            return View(list);
        }
        public ActionResult PostNewProduct()
        {
            if(Session["UserName"] != null)
            {
                ViewBag.SubCategoryId = new SelectList(db.SubCategories.OrderBy(s=>s.SubCategoryId), "SubCategoryId", "SubCategoryName");
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
        public ActionResult PostNewProduct(Product product,FormCollection fc)
        {
            //ok
            ViewBag.SubCategoryId = new SelectList(db.SubCategories, "SubCategoryId", "SubCategoryName");
            

                if (ModelState.IsValid)
                {
                  
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
                    else
                {
                    ViewBag.Nofi = "Bạn chưa chọn ảnh";
                    return View();
                }
                    product.Province = fc["calc_shipping_provinces"];
                    product.District = fc["calc_shipping_district"];
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
        

     
      

        public PartialViewResult CategoryList()
        {
            return PartialView(db.Categories.ToList());
        }
        public PartialViewResult SubcategoryList(int categoryId)
        {
            return PartialView(db.SubCategories.Where(sc => sc.CategoryId == categoryId).ToList());
        }
        public PartialViewResult GetListProductByUser(int userId, int page = 1)
        {
            var list = db.Products.Where(p => p.UserId == userId).ToList();
            return PartialView(list.ToPagedList(page,10));
        }
    }
}