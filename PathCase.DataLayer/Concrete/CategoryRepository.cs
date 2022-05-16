using PathCase.DataLayer.Abstract;
using PathCase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathCase.DataLayer.Concrete
{
    public class CategoryRepository : GenericRepository<Category, DatabaseContext>, ICategoryRepository
    {
       
    }
}
