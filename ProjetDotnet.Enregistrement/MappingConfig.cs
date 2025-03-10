using AutoMapper;
using ProjetDotnet.Enregistrement.Mapping;
using System.Net.NetworkInformation;

namespace Recap.Business
{
    public class MappingConfig
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            //Classe de configuration 
            var config = new MapperConfiguration(cfg =>
                cfg.AddProfile<MappingProfile>()
                );
            var mapper = config.CreateMapper();
            return mapper;

        });

        //Permet de faire appel au mappage
        public static IMapper Mapper => Lazy.Value;


    }
}