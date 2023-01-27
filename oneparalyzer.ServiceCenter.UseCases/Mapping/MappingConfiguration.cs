using AutoMapper;
using oneparalyzer.ServiceCenter.Domain.Entities;
using oneparalyzer.ServiceCenter.UseCases.DTOs.Client;
using oneparalyzer.ServiceCenter.UseCases.DTOs.Service;
using oneparalyzer.ServiceCenter.UseCases.DTOs.Spare;


namespace oneparalyzer.ServiceCenter.UseCases.Mapping
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<AddServiceDTO, Service>()
                .ForMember(dst => dst.Orders, opt => opt.Ignore());
            CreateMap<UpdateServiceDTO, Service>()
                .ForMember(dst => dst.Orders, opt => opt.Ignore());
            CreateMap<Service, GetServiceDTO>();

            CreateMap<AddSpareDTO, Spare>()
                .ForMember(dst => dst.SparesOrders, opt => opt.Ignore());
            CreateMap<UpdateSpareDTO, Spare>()
                .ForMember(dst => dst.SparesOrders, opt => opt.Ignore());
            CreateMap<Spare, GetSpareDTO>();

            CreateMap<AddClientDTO, Client>()
                .ForMember(dst => dst.Orders, opt => opt.Ignore());
            CreateMap<UpdateClientDTO, Client>()
                .ForMember(dst => dst.Orders, opt => opt.Ignore());
            CreateMap<Client, GetClientDTO>();

        }
    }
}
