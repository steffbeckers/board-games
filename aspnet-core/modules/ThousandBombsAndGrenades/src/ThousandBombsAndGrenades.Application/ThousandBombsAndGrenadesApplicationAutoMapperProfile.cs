using AutoMapper;
using ThousandBombsAndGrenades.Games;
using ThousandBombsAndGrenades.Players;
using ThousandBombsAndGrenades.PlayerTurns;

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
            CreateMap<Player, PlayerDto>();
            CreateMap<PlayerTurn, PlayerTurnDto>()
                .ForMember(
                    x => x.CardName,
                    x => x.MapFrom(y => y.Card.Name)
                )
                .ForMember(
                    x => x.CardDescription,
                    x => x.MapFrom(y => y.Card.Description)
                )
                .ForMember(
                    x => x.CardPoints,
                    x => x.MapFrom(y => y.Card.Points)
                );
        }
    }
}