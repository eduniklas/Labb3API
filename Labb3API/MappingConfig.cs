using APILabb.Models;
using APILabb.Models.DTO;
using AutoMapper;

namespace APILabb
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Interest, InterestDto>().ReverseMap();
            CreateMap<Interest, InterestCreateDto>().ReverseMap();
            CreateMap<Interest, InterestUpdateDto>().ReverseMap();

            CreateMap<InterestList, InterestListDto>().ReverseMap();
            CreateMap<InterestList, InterestListCreateDto>().ReverseMap();

            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<Person, PersonCreateDto>().ReverseMap();
            CreateMap<Person, PersonUpdateDto>().ReverseMap();
        }
    }
}
