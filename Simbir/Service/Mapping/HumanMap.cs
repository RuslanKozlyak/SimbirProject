using AutoMapper;
using Domain.Data;
using Domain.DTO.HumanDtos;

namespace Service.Mapping
{
    public class HumanMap : Profile
    {
        public HumanMap()
        {
            CreateMap<HumanDto, Human>();
            CreateMap<Human, HumanDto>();

            CreateMap<HumanWithoutBooksDto, Human>();
            CreateMap<Human, HumanWithoutBooksDto>();
        }
    }
}
