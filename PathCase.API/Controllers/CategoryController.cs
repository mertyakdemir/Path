using PathCase.BusinessLayer.Abstract;
using PathCase.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using AutoMapper;

namespace PathCaseAPI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryBusiness categoryBusiness;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryBusiness _categoryBusiness, IMapper mapper)
        {
            categoryBusiness = _categoryBusiness;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllCategory")]
        public IActionResult GetAllCategory()
        {
            return Ok(categoryBusiness.GetAll());

        }

        [HttpGet]
        [Route("GetByIdCategory")]
        public IActionResult GetByIdCategory(int id)
        {
            return Ok(categoryBusiness.GetOne(id));

        }

        [HttpPost]
        [Route("CreateCategory")]
        public IActionResult CreateCategory(Category category)
        {
            Category categoryDTO = _mapper.Map<Category>(category);
            categoryBusiness.Create(categoryDTO);
            return Ok();

        }

        [HttpPost]
        [Route("EditCategory")]
        public IActionResult EditCategory(Category category)
        {
            Category categoryDTO = _mapper.Map<Category>(category);
            categoryBusiness.Update(categoryDTO);
            return Ok();

        }

        [HttpPost]
        [Route("DeleteCategory")]
        public IActionResult DeleteCategory(int id)
        {
            var result = categoryBusiness.GetOne(id);
            if (result != null)
            categoryBusiness.Delete(result);
            return Ok();
        }

    }
}
