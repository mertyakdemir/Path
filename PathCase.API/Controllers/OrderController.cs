using PathCase.BusinessLayer.Abstract;
using PathCaseAPI.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using PathCase.Entities;
using System;
using AutoMapper;
using PathCase.API.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace PathCaseAPI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderBusiness orderBusiness;
        private readonly IAppContext apiDbContext;
        private readonly IMapper _mapper;
        private ICategoryBusiness _categoryBusiness;

        public OrderController(IOrderBusiness _orderBusiness, IAppContext _apiDbContext, IMapper mapper, ICategoryBusiness categoryBusiness)
        {
            orderBusiness = _orderBusiness;
            apiDbContext = _apiDbContext;
            _mapper = mapper;
            _categoryBusiness = categoryBusiness;
        }

        [HttpGet]
        [Route("GetOrders")]
        public IActionResult GetOrders()
        {
            return Ok(orderBusiness.GetOrders());
        }


        [HttpGet]
        [Route("GetOrder")]
        public IActionResult GetOrder(int orderId)
        {
            return Ok(orderBusiness.GetOrder(orderId));
        }

        [HttpPost]
        [Route("SaveOrder")]
        public IActionResult CreateOrder(OrderViewModel order)
        {
            Order orderDTO = _mapper.Map<Order>(order);
            orderDTO.OrderNumber = new Random().Next(111111, 999999).ToString();
            orderDTO.OrderState = (PathCase.Entities.EnumOrderState)PathCase.API.Models.ViewModel.EnumOrderState.PendingOrder;
            orderDTO.OrderDate = System.DateTime.Now;

            var categoryId = _categoryBusiness.GetOne(orderDTO.CategoryNumber).CategoryName;
            if(categoryId.ToLower() == "gıda")
            {
                orderDTO.ShipType = 1;
            }
            else if (categoryId.ToLower() == "giyim")
            {
                orderDTO.ShipType = 2;
            }

            orderBusiness.Create(orderDTO);
            return Ok();

        }

        [HttpPost]
        [Route("EditOrder")]
        public IActionResult EditOrder(OrderViewModel order, string token)
        {
            var result = orderBusiness.GetOrder(order.Id);
            Order orderDTO = _mapper.Map<Order>(order);
            orderDTO.OrderNumber = result.OrderNumber;
            orderDTO.OrderDate = result.OrderDate;

            int orderCategory = orderBusiness.GetOrder(orderDTO.CategoryNumber).CategoryNumber;

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
            var currentUser = securityToken.Claims.FirstOrDefault(c => c.Type == "Id")?.Value;

            var userRoles = apiDbContext.UserRoles.Where(x => x.UserId == currentUser).FirstOrDefault();
            var userRole = apiDbContext.Roles.Where(x => x.Id == userRoles.RoleId).FirstOrDefault();


            if(userRole.Name != "Admin" && orderCategory == 1)
            {
                return BadRequest("Gıda kategorisini sadece admin düzenleyebilir.");
            }

            orderBusiness.Update(orderDTO);
            return Ok();

        }

    }
}