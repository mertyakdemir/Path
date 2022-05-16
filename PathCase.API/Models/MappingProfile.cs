using AutoMapper;
using PathCase.API.Models.ViewModel;
using PathCase.Entities;

namespace PathCase.API.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<CategoryViewModel, Category>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductViewModel, Product>();
            CreateMap<Order, OrderViewModel>();
            CreateMap<OrderViewModel, Order>();

        }
    }
}
