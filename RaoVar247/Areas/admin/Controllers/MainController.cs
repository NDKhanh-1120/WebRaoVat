using RaoVar247.Models;
using System;
using System.Collections.Generic;
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
        public ActionResult CategoryManage()
        {
            return View();
        }
        public PartialViewResult CategoryList()
        {
            return PartialView(db.Categories.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CategoryManage(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();

            }
                return View();
        }
    }
}