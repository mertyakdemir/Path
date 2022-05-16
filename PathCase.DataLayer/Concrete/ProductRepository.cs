using PathCase.DataLayer.Abstract;
using PathCase.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathCase.DataLayer.Concrete
{
    public class ProductRepository : GenericRepository<Product, DatabaseContext>, IProductRepository
    {
        public Product GetProductDetails(int id)
        {
            using var dbContext = new DatabaseContext();
            return dbContext.Products.Where(i => i.Id == id)
                                     .Include(i => i.ProductCategory)
                                     .ThenInclude(i => i.Category)
                                     .FirstOrDefault();
        }

        public void DeleteFromCategory(int productId, int categoryId)
        {
            using var dbContext = new DatabaseContext();
            var cmd = @"DELETE FROM public.""ProductCategories"" WHERE ""ProductId""=@p0 And ""CategoryId""=@p1";
            dbContext.Database.ExecuteSqlRaw(cmd, productId, categoryId);
            var product = dbContext.Products.Where(i => i.Id == productId).FirstOrDefault();
            if(product!=null)
            {
                product.ProductCategoryId = null;
            }
        }


        public override async void Update(Product model)
        {
            using var dbContext = new DatabaseContext();
            var product = dbContext.Products.Include(i => i.ProductCategory).FirstOrDefault(i => i.Id == model.Id);
            if (product != null)
            {
                product.Id = model.Id;
                product.ProductName = model.ProductName;
                product.ProductCategoryId = model.ProductCategoryId;
                product.ProductPrice = model.ProductPrice;
                product.ProductCategory = product.ProductCategoryId == null ? null : new ProductCategory()
                {
                    CategoryId = product.ProductCategoryId,
                    ProductId = product.Id
                };

                dbContext.SaveChanges();

               
            }
        }

        public override void Create(Product model)
        {
            using var dbContext = new DatabaseContext();
            var product = new Product();
            {
                product.ProductName = model.ProductName;
                product.ProductCategoryId = model.ProductCategoryId;
                product.ProductPrice = model.ProductPrice;
                product.ProductCategory = product.ProductCategoryId == null ? null : new ProductCategory()
                {
                    CategoryId = product.ProductCategoryId
                };
            }
            dbContext.Set<Product>().Add(product);
            dbContext.SaveChanges();

           
        }
    }
}
