using PathCase.BusinessLayer.Abstract;
using PathCase.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PathCase.API.Models.ViewModel;

namespace PathCaseAPI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductBusiness productBusiness;
        private ICategoryBusiness categoryBusiness;
        private readonly IMapper _mapper;

        public ProductController(IProductBusiness _productBusiness, ICategoryBusiness _categoryBusiness, IMapper mapper)
        {
            productBusiness = _productBusiness;
            categoryBusiness = _categoryBusiness;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            return Ok(productBusiness.GetAll());

        }

        [HttpGet]
        [Route("GetByIdProduct")]
        public IActionResult GetByIdProduct(int id)
        {
            return Ok(productBusiness.GetOne(id));

        }

        [HttpPost]
        [Route("CreateProduct")]
        public IActionResult CreateProduct(ProductViewModel product)
        {
            Product productDTO = _mapper.Map<Product>(product);
            productBusiness.Create(productDTO);
            return Ok();

        }

        [HttpPost]
        [Route("EditProduct")]
        public IActionResult EditProduct(ProductViewModel product)
        {
            Product productDTO = _mapper.Map<Product>(product);
            productBusiness.Update(productDTO);
            return Ok();

        }

        [HttpPost]
        [Route("DeleteProduct")]
        public IActionResult DeleteProduct(int id)
        {
            var result = productBusiness.GetOne(id);
            if(result != null) 
            productBusiness.Delete(result);
            return Ok();

        }

        [HttpPost]
        [Route("DeleteFromCategory")]
        public IActionResult DeleteFromCategory(int productId, int categoryId)
        {
            productBusiness.DeleteFromCategory(productId, categoryId);
            return Ok();

        }
    }
}
