using RaoVar247.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaoVar247.Services
{
    public class UserServices
    {
        static Db db = new Db();
        public static bool CheckAccount(string username, string password)
        {
            if(db.Users.FirstOrDefault(u=>u.UserName == username && u.Password == password) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static IEnumerable<Models.User> GetUsers()
        {
            return db.Users.ToList();
        }
        public static void Delete(int userId)
        {
            try
            {
                db.Users.Remove(db.Users.FirstOrDefault(u => u.UserId == userId));
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void ChangeStatus(int userId)
        {
            try
            {
                var user = db.Users.FirstOrDefault(u => u.UserId == userId);
                if (user.Status == true)
                {
                    user.Status = false;
                }
                else
                {
                    user.Status = true;
                }
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool IsFollow(int userId, int followerId)
        {
            if (db.Follows.FirstOrDefault(f => f.UserId == userId && f.FollowerId == followerId) == null)
            {
                return false;
            } 
            else
            {
                return true;
            }
        }
        public static void UnFollow(int userId, int followerId)
        {
            db.Follows.Remove(db.Follows.First(f=>f.UserId == userId && f.FollowerId==followerId));
            db.SaveChanges();
        }
        public static void Follow(int userId, int followerId)
        {
            db.Follows.Add(new Follow { UserId = userId, FollowerId = followerId });
            db.SaveChanges();
        }
        public static int CountFollower(int userId)
        {
            return db.Follows.Where(f => f.UserId == userId).Count();
        }
        public static void Save(int userId , int productId)
        {
            db.Likes.Add(new Like() { UserId = userId, ProductId = productId });
            db.SaveChanges();
        }
        public static void UnSave(int userId , int productId)
        {
            db.Likes.Remove(db.Likes.First(l => l.UserId == userId && l.ProductId == productId));
            db.SaveChanges();
        }
        public static bool IsSave(int userId , int productId)
        {
            if (db.Likes.FirstOrDefault(l => l.UserId == userId && l.ProductId == productId) != null) return true;
            else return false;
        }
        public static IEnumerable<Product> GetSavedProducts(int userId)
        {

            var list = db.Likes.Where(l => l.UserId == userId).Select(l=>l.ProductId);
            return db.Products.Where(p => list.Contains(p.ProductId));

            //db.Products.Where(p => p.User.UserId == userId);

        }
        public static IEnumerable<User> GetFollowingUsers(int userId)
        {
            var list = db.Follows.Where(f=>f.FollowerId == userId).Select(f=>f.UserId);
            return db.Users.Where(p => list.Contains(p.UserId));
        }
    } 
   
}