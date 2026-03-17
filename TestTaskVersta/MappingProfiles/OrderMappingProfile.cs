using AutoMapper;
using TestTaskVersta.Models.Entities;
using TestTaskVersta.Models.ViewModels;

namespace TestTaskVersta.MappingProfiles
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, OrderListViewModel>();
            CreateMap<CreateOrderViewModel, Order>();
        }
    }
}
