using AutoMapper;
using ThousandBombsAndGrenades.Games;

namespace ThousandBombsAndGrenades
{
    public class ThousandBombsAndGrenadesDomainAutoMapperProfile : Profile
    {
        public ThousandBombsAndGrenadesDomainAutoMapperProfile()
        {
            CreateMap<Game, GameEto>();
        }
    }
}
