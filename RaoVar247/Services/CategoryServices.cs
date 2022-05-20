using RaoVar247.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaoVar247.Services
{
    public class CategoryServices
    {
        static Db db = new Db();
        public static void DeleteCategory(int categoryId)
        {
            using(Db db = new Db())
            {
                var category = db.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
                db.Categories.Remove(category);
                db.SaveChanges();
            }

        }
        public static Category GetCategoryById(int id)
        {
            return db.Categories.First(c=>c.CategoryId == id);
        }
        public static bool Contains(Category category)
        {
            if (db.Categories.FirstOrDefault(c => c.CategoryId == category.CategoryId) == null) return true;
            else return false;
        }
    }
}