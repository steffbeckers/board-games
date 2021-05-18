using AutoMapper;
using ThousandBombsAndGrenades.Games;

namespace ThousandBombsAndGrenades
{
    public class ThousandBombsAndGrenadesApplicationAutoMapperProfile : Profile
    {
        public ThousandBombsAndGrenadesApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Game, GameDto>();
        }
    }
}