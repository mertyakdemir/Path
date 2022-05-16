﻿using PathCase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathCase.BusinessLayer.Abstract
{
    public interface IProductBusiness
    {
        Product GetOne(int id);

        List<Product> GetAll();

        void Create(Product entity);

        void Update(Product entity);

        void Delete(Product entity);

        void DeleteFromCategory(int productId, int categoryId);

    }
}
