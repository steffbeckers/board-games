using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThousandBombsAndGrenades.Players;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ThousandBombsAndGrenades.Games
{
    [RemoteService(IsEnabled = false)]
    public class GamesAppService : ApplicationService, IGamesAppService
    {
        private readonly IGameRepository _gameRepository;
        private readonly GameManager _gameManager;

        public GamesAppService(
            IGameRepository gameRepository,
            GameManager gameManager
        )
        {
            _gameRepository = gameRepository;
            _gameManager = gameManager;
        }

        public async Task<PagedResultDto<GameDto>> GetListAsync()
        {
            var totalCount = await _gameRepository.GetCountAsync();
            var games = await _gameRepository.GetListAsync();

            return new PagedResultDto<GameDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Game>, List<GameDto>>(games)
            };
        }

        public async Task<GameDto> GetAsync(Guid id)
        {
            Game game = await _gameRepository.GetAsync(id);
            return ObjectMapper.Map<Game, GameDto>(game);
        }

        public async Task<GameDto> CreateAsync()
        {
            Game game = await _gameManager.CreateAsync();
            return ObjectMapper.Map<Game, GameDto>(game);
        }

        public async Task<GameDto> AddPlayerAsync(Guid id, PlayerDto playerDto)
        {
            Game game = await _gameRepository.GetAsync(id);
            game.AddPlayer(playerDto.Name);
            await _gameRepository.UpdateAsync(game, autoSave: true);
            return ObjectMapper.Map<Game, GameDto>(game);
        }

        public async Task<GameDto> RemovePlayerAsync(Guid id, Guid playerId)
        {
            Game game = await _gameRepository.GetAsync(id);
            game.RemovePlayer(playerId);
            await _gameRepository.UpdateAsync(game, autoSave: true);
            return ObjectMapper.Map<Game, GameDto>(game);
        }
    }
}
