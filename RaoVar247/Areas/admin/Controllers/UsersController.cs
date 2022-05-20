using RaoVar247.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RaoVar247.Areas.admin.Controllers
{
    public class UsersController : Controller
    {
        // GET: admin/Users
        public ActionResult Index()
        {
            return View(UserServices.GetUsers());
        }
        [HttpPost]
        public ActionResult DeleteUser(int userId)
        {
            UserServices.Delete(userId);
            return View("Index", UserServices.GetUsers());
        }

        public ActionResult ChangeStatus(int userId)
        {
            UserServices.ChangeStatus(userId);
            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}