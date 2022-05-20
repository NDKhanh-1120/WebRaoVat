using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RaoVar247.Areas.admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: admin/Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (RaoVar247.Services.UserServices.CheckAccount(username, password))
            {
                return RedirectToAction("Index", "Main");
            }
            else
            {
                TempData["Message"] = "Đăng nhập sai";
                return View("Index");
            }
        }
    }
}