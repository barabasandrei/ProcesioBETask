using AutoMapper;
using Domain.Entities;
using ProcesioWebApi.DTOs.Customers;
using ProcesioWebApi.DTOs.OrderItems;
using ProcesioWebApi.DTOs.Orders;

namespace ProcesioWebApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, ViewOrderDto>();
            CreateMap<Order, CreateOrderDto>().ReverseMap();
            CreateMap<Order, UpdateOrderDto>().ReverseMap();

            CreateMap<Customer, ViewCustomerDto>();
            CreateMap<Customer, CreateCustomerDto>().ReverseMap();
            CreateMap<Customer, UpdateCustomerDto>().ReverseMap();
            
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
        }
    }
}
