using AutoMapper;
using OrdersProject.Domain.Entities;
using OrdersProject.Service.DTOs.Order;
using OrdersProject.Service.DTOs.UserOrder;

namespace OrdersProject.Service.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Orders
            CreateMap<Order, OrderForCreateDTOs>().ReverseMap();
            CreateMap<Order, OrderForViewDTOs>().ReverseMap();
            #endregion

            #region UserOrders
            CreateMap<UserOrder, UserOrderForCreateDTOs>().ReverseMap();
            CreateMap<UserOrder, UserOrderForViewDTOs>().ReverseMap();  
            #endregion
        }
    }
}
