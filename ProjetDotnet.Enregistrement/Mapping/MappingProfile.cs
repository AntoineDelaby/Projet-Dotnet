using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ProjetDotnet.Server.API;
using ProjetDotnet.Server.Data;

namespace ProjetDotnet.Enregistrement.Mapping
{
    class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Historique, HistoriqueDto>()
             .ForMember(dest => dest.NumeroCarteBancaire,
                        o => o.MapFrom(src => src.NumCarte.Replace(" ", ""))) 
             .ReverseMap();
        }
    }
}
