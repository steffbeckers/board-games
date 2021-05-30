using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace ThousandBombsAndGrenades.PlayerTurns
{
    [RemoteService(IsEnabled = false)]
    public class PlayerTurnAppService : ApplicationService, IPlayerTurnAppService
    {
        private readonly IPlayerTurnRepository _playerTurnRepository;

        public PlayerTurnAppService(IPlayerTurnRepository playerTurnRepository)
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

        public async Task<PlayerTurnDto> PickDiceAsync(Guid id, int index)
        {
            PlayerTurn playerTurn = await _playerTurnRepository.GetAsync(id);
            playerTurn.PickDice(index);
            playerTurn = await _playerTurnRepository.UpdateAsync(playerTurn, autoSave: true);
            return ObjectMapper.Map<PlayerTurn, PlayerTurnDto>(playerTurn);
        }

        public async Task<PlayerTurnDto> ReturnDiceAsync(Guid id, int index)
        {
            PlayerTurn playerTurn = await _playerTurnRepository.GetAsync(id);
            playerTurn.ReturnDice(index);
            playerTurn = await _playerTurnRepository.UpdateAsync(playerTurn, autoSave: true);
            return ObjectMapper.Map<PlayerTurn, PlayerTurnDto>(playerTurn);
        }

        public async Task<PlayerTurnDto> EndAsync(Guid id)
        {
            PlayerTurn playerTurn = await _playerTurnRepository.GetAsync(id);
            playerTurn.End();
            playerTurn = await _playerTurnRepository.UpdateAsync(playerTurn, autoSave: true);
            return ObjectMapper.Map<PlayerTurn, PlayerTurnDto>(playerTurn);
        }
    }
}
