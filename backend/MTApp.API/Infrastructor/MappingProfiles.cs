using AutoMapper;
using MTApp.API.Models.DTOs;
using MTApp.API.Models.Entities;
using System.Linq;

namespace MTApp.API.Infrastructor
{
    public class MappingProfiles  :Profile
    {
        public MappingProfiles()
        {
            CreateMap<News, NewsRequest>()
                .ForMember(Request => Request.NewsLanguages, ent => ent.MapFrom(x => x.NewsLanguages.FirstOrDefault())).ReverseMap();

            CreateMap<NewsLanguage, NewsLanguageDto>()
                .ReverseMap(); 
            CreateMap<Language, LanguageDto>()
                .ReverseMap();
        }
    }
}
