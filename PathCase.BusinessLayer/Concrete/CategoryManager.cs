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
    public class CategoryManager : ICategoryBusiness
    {
        private ICategoryRepository categoryRepository;

        public CategoryManager(ICategoryRepository _categoryRepository)
        {
            categoryRepository = _categoryRepository;
        }

        public void Create(Category entity)
        {
            categoryRepository.Create(entity);
        }

        public void Delete(Category entity)
        {
            categoryRepository.Delete(entity);
        }

        public List<Category> GetAll()
        {
            return categoryRepository.GetAll();
        }

        public Category GetOne(int id)
        {
            return categoryRepository.GetOne(id);
        }

        public void Update(Category entity)
        {
            categoryRepository.Update(entity);
        }

      
    }
}
