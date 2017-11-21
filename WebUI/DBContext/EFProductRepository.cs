using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Abstract;
using Domain.Entities;

namespace WebUI.DBContext
{
    public class EFProductRepository : IProductRepository
    {
        private ProductsEntities context = new ProductsEntities();
        public EFProductRepository()
        {
            //  initDB();
        }

        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }

        public Product DeleteProduct(int productId)
        {
            Product p = context.Products.Find(productId);
            if (p != null)
            {
                context.Products.Remove(p);
                context.SaveChanges();
            }
            return p;
        }

        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product p = context.Products.Find(product.ProductID);
                if (p != null)
                {
                    p.Name = product.Name;
                    p.Description = product.Description;
                    p.Price = product.Price;
                    p.Category = product.Category;
                    p.ImageData = product.ImageData;
                    p.ImageMimeType = product.ImageMimeType;
                }
            }
            context.SaveChanges();
        }

        void initDB()
        {
            Product p;
            p = new Product() { Name = "Lifejacket", Description = "Protective and fashion", Category = "watrsports", Price = 48.95m };
            context.Products.Add(p);
            p = new Product() { Name = "Soccer ball", Description = "FIFA size", Category = "soccer", Price = 19.5m };
            context.Products.Add(p);
            p = new Product() { Name = "Corner flags", Description = "Give your playing field a pro touch", Category = "soccer", Price = 34.95m };
            context.Products.Add(p);
            p = new Product() { Name = "Stadium", Description = "Flat-packed, 35,000-seat", Category = "soccer", Price = 79500m };
            context.Products.Add(p);
            p = new Product() { Name = "Tninking Cap", Description = "Improve your brain", Category = "Chess", Price = 16m };
            context.Products.Add(p);
            p = new Product() { Name = "Unsteady Chair", Description = "Secretly give your oppenent a disadvantage", Category = "Chess", Price = 29.95m };
            context.Products.Add(p);
            p = new Product() { Name = "Human chess board", Description = "A fun game for the family", Category = "Chess", Price = 75m };
            context.Products.Add(p);
            p = new Product() { Name = "Bling-bling king", Description = "Gold plated", Category = "Chess", Price = 1200m };
            context.Products.Add(p);
            context.SaveChanges();
        }
    }
}