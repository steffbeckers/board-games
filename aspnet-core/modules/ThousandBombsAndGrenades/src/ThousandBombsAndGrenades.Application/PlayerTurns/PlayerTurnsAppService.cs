using System;
using System.Threading.Tasks;
using ThousandBombsAndGrenades.Games;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace ThousandBombsAndGrenades.PlayerTurns
{
    [RemoteService(IsEnabled = false)]
    public class PlayerTurnsAppService : ApplicationService, IPlayerTurnsAppService
    {
        private readonly IPlayerTurnRepository _playerTurnRepository;

        public PlayerTurnsAppService(IPlayerTurnRepository playerTurnRepository)
        {
            _playerTurnRepository = playerTurnRepository;
        }

        public async Task<PlayerTurnDto> GetAsync(Guid id)
        {
            PlayerTurn playerTurn = await _playerTurnRepository.GetAsync(id);
            return ObjectMapper.Map<PlayerTurn, PlayerTurnDto>(playerTurn);
        }

        public async Task<PlayerTurnDto> DrawCardAsync(Guid id)
        {
            PlayerTurn playerTurn = await _playerTurnRepository.GetAsync(id);
            playerTurn.DrawCard();
            playerTurn = await _playerTurnRepository.UpdateAsync(playerTurn, autoSave: true);
            return ObjectMapper.Map<PlayerTurn, PlayerTurnDto>(playerTurn);
        }

        public async Task<PlayerTurnDto> RollDiceAsync(Guid id)
        {
            PlayerTurn playerTurn = await _playerTurnRepository.GetAsync(id);
            playerTurn.RollDice();
            playerTurn = await _playerTurnRepository.UpdateAsync(playerTurn, autoSave: true);
            return ObjectMapper.Map<PlayerTurn, PlayerTurnDto>(playerTurn);
        }
    }
}
