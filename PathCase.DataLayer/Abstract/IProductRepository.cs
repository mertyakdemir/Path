using PathCase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathCase.DataLayer.Abstract
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        void DeleteFromCategory(int productId, int categoryId);
    }
}
