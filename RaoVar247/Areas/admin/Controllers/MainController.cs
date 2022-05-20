using RaoVar247.Models;
using RaoVar247.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RaoVar247.Areas.admin.Controllers
{
    public class MainController : Controller
    {
        Db db = new Db();

        // GET: admin/Home
        public ActionResult Index()
        {
            return View();
        }
        // GET: admin/Home
   
  
        public ActionResult CategoryManage(int categoryId = 0)
        {
            if(categoryId != 0)
            {
                ViewBag.Level = "subcategory";
                ViewBag.categoryId = categoryId;
                TempData["currentcategoryId"] = categoryId;
            }
            return View();
        }
        public PartialViewResult CategoryList()
        {
            return PartialView(db.Categories.ToList());
        }
        public PartialViewResult SubcategoryList(int categoryId)
        {
            return PartialView(db.SubCategories.Where(sc=>sc.CategoryId == categoryId).ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCategory(Category category)
        {
            if (ModelState.IsValid && CategoryServices.Contains(category))
            {
                var f = Request.Files["imgfile"];
                if (f != null && f.ContentLength > 0)
                {
                    string FileName = Path.GetFileName(f.FileName);
                    string UploadPath = Server.MapPath("~/Content/Images/" + FileName);
                    f.SaveAs(UploadPath);
                    category.Image = FileName;
                }

                db.Categories.Add(category);
                db.SaveChanges();
            }
                return RedirectToAction("CategoryManage");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                var currentCategory = db.Categories.First(c => c.CategoryId == category.CategoryId);
                currentCategory.CategoryName = category.CategoryName;
                var f = Request.Files["imgfile"];
                if (f != null && f.ContentLength > 0 && Path.GetFileName(f.FileName) != currentCategory.Image)
                {
                    string FileName = Path.GetFileName(f.FileName);
                    string UploadPath = Server.MapPath("~/Content/Images/" + FileName);
                    f.SaveAs(UploadPath);
                    currentCategory.Image = FileName;
                }
                db.SaveChanges();
            }
                return RedirectToAction("CategoryManage");
        }

        [HttpPost]
        public ActionResult DeleteCategory(int categoryId)
        {
            try
            {
                CategoryServices.DeleteCategory(categoryId);
                TempData["Nofi"] = "Xóa danh mục thành công! ";
            }
            catch (Exception)
            {
                TempData["Nofi"] = "Bạn cần xóa các danh mục con trước";
            }
            return RedirectToAction("CategoryManage");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSubcategory(SubCategory subCategory, int categoryId)
        {
            if (ModelState.IsValid)
            {
                var f = Request.Files["imgfile"];
                if (f != null && f.ContentLength > 0)
                {
                    string FileName = Path.GetFileName(f.FileName);
                    string UploadPath = Server.MapPath("~/Content/Images/" + FileName);
                    f.SaveAs(UploadPath);
                    subCategory.Image = FileName;
                }
                if (SubcategoryServices.IsExists(subCategory.SubCategoryId))
                {
                    TempData["Msg"] = "Mã danh mục đã tồn tại";
                }
                else
                {
                    subCategory.CategoryId = categoryId;
                    db.SubCategories.Add(subCategory);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("CategoryManage", new { categoryId = categoryId });
        }

        [HttpPost]
        public ActionResult DeleteSubcategory(int subcategoryId,int categoryId)
        {
            try
            {
                SubcategoryServices.DeleteSubcategory(subcategoryId);
                TempData["Nofi"] = "Xóa danh mục con thành công! ";
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("CategoryManage", new {categoryId = categoryId });
        }

        public PartialViewResult SubcategoryModal()
        {
            return PartialView();
        }
    }
}