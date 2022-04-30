using RaoVar247.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RaoVar247.Controllers
{
    public class UserController : Controller
    {
        Db db = new Db();

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {   
            try
            {
                if (ModelState.IsValid)
                {
                    if(db.Users.FirstOrDefault(u => u.UserName == user.UserName) == null)
                    {
                        db.Users.Add(user);
                        db.SaveChanges();
                        TempData["Nofi"] = "Đăng ký thành công";
                        return RedirectToAction("Index","Home");
                    }
                    else
                    {
                        TempData["Nofi"] = "Tên tài khoản đã tồn tại";
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }
            catch (Exception e)
            {

                throw;
            }

        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string UserName , string Password)
        {
            if (ModelState.IsValid)
            {
                User user = db.Users.FirstOrDefault(u => u.UserName == UserName & u.Password == Password);
                if (db.Users.FirstOrDefault(u=>u.UserName == UserName & u.Password == Password) != null)
                {
                    Session["LastName"] = user.LastName;
                    Session["FirstName"] = user.FirstName;
                    Session["UserName"] = user.UserName;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["WrongLogin"] = "Tên tài khoản hoặc mật khẩu không chính xác";
                    return View();
                }

            }
            else
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index","Home");
        }

        public ActionResult Profile(string userName)
        {
            return View();
        }
    }
}