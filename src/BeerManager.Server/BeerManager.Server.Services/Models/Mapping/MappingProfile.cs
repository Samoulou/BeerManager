using AutoMapper;

namespace BeerManager.Server.Services.Models.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Core.Data.Models.Order, Order>();
            CreateMap<Core.Data.Models.Customer, Customer>();
            CreateMap<Core.Data.Models.Contact, Contact>();
        }
    }
}
