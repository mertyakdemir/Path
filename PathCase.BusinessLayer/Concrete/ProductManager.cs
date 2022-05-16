using PathCase.BusinessLayer.Abstract;
using PathCase.DataLayer.Abstract;
using PathCase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathCase.BusinessLayer.Concrete
{
    public class ProductManager : IProductBusiness
    {
        private IProductRepository productRepository;

        public ProductManager(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }

        public Product GetOne(int id)
        {
            return productRepository.GetOne(id);
        }

        public List<Product> GetAll()
        {
            return productRepository.GetAll();
        }

        public void Create(Product entity)
        {
            productRepository.Create(entity);
        }

        public void Update(Product entity)
        {
            productRepository.Update(entity);
        }

        public void Delete(Product entity)
        {
            productRepository.Delete(entity);
        }

        public void DeleteFromCategory(int productId, int categoryId)
        {
            productRepository.DeleteFromCategory(productId, categoryId);
        }
    }
}
