using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace ProjetDotnet.Enregistrement.Mapping
{
    class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Historique, EnregistrementDto>()
             .ForMember(dest => dest.NumeroCarteBancaire,
                        o => o.MapFrom(src => src.NumeroCarteBancaire.Replace(" ", ""))) 
             .ReverseMap();
        }
    }
}
