using RaoVar247.Models;
using RaoVar247.Services;
using System;
using System.Collections.Generic;
using System.IO;
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
                        user.Status = true;
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
                if (user != null)
                {
                    if(user.Status == true)
                    {

                        Session["LastName"] = user.LastName;
                        Session["FirstName"] = user.FirstName;
                        Session["UserName"] = user.UserName;
                        Session["UserId"] = user.UserId;
                        Session["Avatar"] = user.Avatar;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["WrongLogin"] = "Tài khoản của bạn đã bị khóa";
                        return View();
                    }
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

        public ActionResult Profile(int userId)
        {
            var user = db.Users.FirstOrDefault(u => u.UserId == userId);
            bool isFollow = UserServices.IsFollow(userId, (int)Session["UserId"]);
            ViewBag.IsFollow = isFollow;
            ViewBag.FollowerCount = UserServices.CountFollower(userId);
            return View(user);
        }
        
        public ActionResult Edit(int userId)
        {
            var user = db.Users.FirstOrDefault(u => u.UserId== userId);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {

            var currentUser = db.Users.First(u => u.UserId == user.UserId);

            var f = Request.Files["avatar-image"];

            if (f != null && f.ContentLength > 0)
            {
                string FileName = Path.GetFileName(f.FileName);
                if(FileName != currentUser.Avatar)
                {
                    string UploadPath = Server.MapPath("~/Content/Images/" + FileName);
                    f.SaveAs(UploadPath);
                    currentUser.Avatar = FileName;
                }
            }
            currentUser.LastName = user.LastName;
            currentUser.FirstName = user.FirstName;
            currentUser.PhoneNumber = user.PhoneNumber;
            currentUser.Address = user.Address;
            db.SaveChanges(); 
            return RedirectToAction("Profile", "User", new {userId = user.UserId});
            }
            else
            {
                return View(user);
            }
           
        }
        public PartialViewResult ProfileColumn(int userId)
        {
            return PartialView(db.Users.FirstOrDefault(u => u.UserId == userId));
        }

        public ActionResult Follow(int userId, int followerUserId)
        {
            UserServices.Follow(userId, followerUserId);
            return Json(null, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UnFollow(int userId, int followerUserId)
        {
            UserServices.UnFollow(userId, followerUserId);
            return Json(null, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Save(int userId,int productId)
        {
            UserServices.Save(userId, productId);
            return Json(null, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UnSave(int userId,int productId)
        {
            UserServices.UnSave(userId, productId);
            return Json(null, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CheckSave(int userId, int productId)
        {
            if (!UserServices.IsSave(userId, productId))
            {
                return Content(@"<img class=""save-img"" src= ""/Content/Images/save-ad.svg"" alt=""unlike""/>", "text/html", System.Text.Encoding.UTF8);
            }
            else
            {
                return Content(@"<img class=""save-img"" src= ""/Content/Images/save-ad-active.svg"" alt ""like""/>", "text/html", System.Text.Encoding.UTF8);
            }
        }

        public ActionResult SaveList(int userId)
        {
            ViewBag.CurrentUserId = userId;
            return View();
        }
        public ActionResult GetListSave(int userId)
        {
            var list = UserServices.GetSavedProducts(userId);
            return PartialView(list);
        }
        public ActionResult Following(int userId)
        {
            var users = UserServices.GetFollowingUsers(userId);
            return View(users);
        }
    }
}