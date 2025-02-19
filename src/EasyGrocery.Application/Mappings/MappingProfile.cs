using AutoMapper;
using EasyGrocery.Application.Handlers.CustomerHandler.Commands;
using EasyGrocery.Application.Models;
using EasyGrocery.Domain.Entities;

namespace EasyGrocery.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddCustomerCommand, Customer>().ReverseMap();
            CreateMap<AddCustomerCommand, CustomerModel>().ReverseMap();
            CreateMap<UpdateCustomerCommand, Customer>().ReverseMap();
            CreateMap<UpdateCustomerCommand, CustomerModel>().ReverseMap();
        }
    }
}