using RaoVar247.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaoVar247.Services
{
    public class ProductServices
    {
        static Db db = new Db();
        public static IEnumerable<Product> GetAllProduct()
        {
           return db.Products;
        }
        public static void DeleteById(int productId)
        {
           db.Products.Remove(db.Products.FirstOrDefault(p=>p.ProductId == productId));
            db.SaveChanges();
        }

    }
}