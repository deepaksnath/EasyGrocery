using AutoMapper;
using EasyGrocery.Application.Handlers.CustomerHandler.Commands;
using EasyGrocery.Application.Handlers.ProductHandler.Commands;
using EasyGrocery.Application.Models;
using EasyGrocery.Domain.Entities;

namespace EasyGrocery.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerModel, Customer>().ReverseMap();
            CreateMap<AddCustomerCommand, CustomerModel>().ReverseMap();
            CreateMap<CustomerModel, Customer>().ReverseMap();
            CreateMap<UpdateCustomerCommand, CustomerModel>().ReverseMap();

            CreateMap<ProductModel, Product>().ReverseMap();
            CreateMap<AddProductCommand, ProductModel>().ReverseMap();
            CreateMap<ProductModel, Product>().ReverseMap();
            CreateMap<UpdateProductCommand, ProductModel>().ReverseMap();
        }
    }
}