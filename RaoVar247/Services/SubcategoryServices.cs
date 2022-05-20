using RaoVar247.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaoVar247.Services
{
    public class SubcategoryServices
    {
        static Db db = new Db();
            
        public static void DeleteSubcategory(int subcategoryId)
        {
            try
            {
                db.SubCategories.Remove(db.SubCategories.FirstOrDefault(x => x.SubCategoryId == subcategoryId));
                db.SaveChanges();

            }
            catch (Exception)
            {

                return;
            }
           
        }
        public static bool IsExists(int subcategoryID)
        {
            if (db.SubCategories.FirstOrDefault(sc => sc.SubCategoryId == subcategoryID) != null)
            {
                return true;
            }
            else return false;
        }
    }
}