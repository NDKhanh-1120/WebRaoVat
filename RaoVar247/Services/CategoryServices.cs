using RaoVar247.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaoVar247.Services
{
    public class CategoryServices
    {
        public static void DeleteCategory(int categoryId)
        {
            using(Db db = new Db())
            {
                var category = db.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
                db.Categories.Remove(category);
                db.SaveChanges();
            }

        }
    }
}