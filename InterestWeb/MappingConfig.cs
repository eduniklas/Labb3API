using InterestWeb.Models;
using InterestWeb.Models.DTO;
using AutoMapper;

namespace InterestWeb
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<InterestDto, InterestCreateDto>().ReverseMap();
            CreateMap<InterestDto, InterestUpdateDto>().ReverseMap();

            CreateMap<InterestListDto, InterestListCreateDto>().ReverseMap();
            CreateMap<InterestListDto, InterestListUpdateDto>().ReverseMap();

            CreateMap<Person, PersonCreateDto>().ReverseMap();
            CreateMap<Person, PersonUpdateDto>().ReverseMap();
        }
    }
}
