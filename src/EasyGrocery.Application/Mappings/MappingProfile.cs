using AutoMapper;
using EasyGrocery.Application.Models;
using EasyGrocery.Domain.Entities;

namespace EasyGrocery.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerModel, Customer>().ReverseMap();
            CreateMap<ProductModel, Product>().ReverseMap();
            CreateMap<CartItemModel, CartItem>().ReverseMap();
            CreateMap<OrderModel, Order>().ReverseMap();
        }
    }
}