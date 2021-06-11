using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThousandBombsAndGrenades.Players;
using ThousandBombsAndGrenades.PlayerTurns;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ThousandBombsAndGrenades.Games
{
    [RemoteService(IsEnabled = false)]
    public class GameAppService : ApplicationService, IGameAppService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly IPlayerTurnRepository _playerTurnRepository;

        public GameAppService(
            IGameRepository gameRepository,
            IPlayerRepository playerRepository,
            IPlayerTurnRepository playerTurnRepository
        )
        {
            _gameRepository = gameRepository;
            _playerRepository = playerRepository;
            _playerTurnRepository = playerTurnRepository;
        }

        public async Task<PagedResultDto<GameDto>> GetListAsync()
        {
            List<Game> games = await _gameRepository.GetListAsync();
            return new PagedResultDto<GameDto>
            {
                TotalCount = games.Count,
                Items = ObjectMapper.Map<List<Game>, List<GameDto>>(games)
            };
        }

        public async Task<GameDto> GetAsync(Guid id)
        {
            Game game = await _gameRepository.GetAsync(id);
            return ObjectMapper.Map<Game, GameDto>(game);
        }

        [Authorize]
        public async Task<GameDto> CreateAsync()
        {
            Game game = new Game(Guid.NewGuid());
            // Add the current user to the game automatically
            game.AddPlayer(new Player(Guid.NewGuid(), CurrentUser.UserName)
            {
                UserId = CurrentUser.Id
            });
            game = await _gameRepository.InsertAsync(game);
            return ObjectMapper.Map<Game, GameDto>(game);
        }

        [Authorize]
        public async Task<GameDto> JoinAsync(Guid id)
        {
            Game game = await _gameRepository.GetAsync(id);
            // TODO: Check if game is joinable?
            game.AddPlayer(new Player(Guid.NewGuid(), CurrentUser.UserName)
            {
                UserId = CurrentUser.Id
            });
            game = await _gameRepository.UpdateAsync(game);
            return ObjectMapper.Map<Game, GameDto>(game);
        }

        [Authorize]
        public async Task<GameDto> LeaveAsync(Guid id)
        {
            Game game = await _gameRepository.GetAsync(id);
            Player player = game.Players.FirstOrDefault(x => x.UserId == CurrentUser.Id);
            game.RemovePlayer(player);
            game = await _gameRepository.UpdateAsync(game);
            return ObjectMapper.Map<Game, GameDto>(game);
        }

        [Authorize]
        public async Task<GameDto> KickPlayerAsync(Guid id, Guid playerId)
        {
            Game game = await _gameRepository.GetAsync(id);
            Player player = game.Players.FirstOrDefault(x => x.Id == playerId);
            game.RemovePlayer(player);
            game = await _gameRepository.UpdateAsync(game);
            return ObjectMapper.Map<Game, GameDto>(game);
        }

        [Authorize]
        public async Task<GameDto> StartAsync(Guid id)
        {
            Game game = await _gameRepository.GetAsync(id);
            game.Start();
            game = await _gameRepository.UpdateAsync(game);
            return ObjectMapper.Map<Game, GameDto>(game);
        }

        [Authorize]
        public async Task<GameDto> DrawCardAsync(Guid id)
        {
            Game game = await _gameRepository.GetAsync(id);
            game.CurrentPlayerTurn.DrawCard();
            game = await _gameRepository.UpdateAsync(game);
            return ObjectMapper.Map<Game, GameDto>(game);
        }

        [Authorize]
        public async Task<GameDto> RollDiceAsync(Guid id)
        {
            Game game = await _gameRepository.GetAsync(id);
            game.CurrentPlayerTurn.RollDice();
            await _playerTurnRepository.UpdateAsync(game.CurrentPlayerTurn);
            game = await _gameRepository.UpdateAsync(game);
            return ObjectMapper.Map<Game, GameDto>(game);
        }

        [Authorize]
        public async Task<GameDto> PickDiceAsync(Guid id, int index)
        {
            Game game = await _gameRepository.GetAsync(id);
            game.CurrentPlayerTurn.PickDice(index);
            await _playerTurnRepository.UpdateAsync(game.CurrentPlayerTurn);
            game = await _gameRepository.UpdateAsync(game);
            return ObjectMapper.Map<Game, GameDto>(game);
        }

        [Authorize]
        public async Task<GameDto> ReturnDiceAsync(Guid id, int index)
        {
            Game game = await _gameRepository.GetAsync(id);
            game.CurrentPlayerTurn.ReturnDice(index);
            await _playerTurnRepository.UpdateAsync(game.CurrentPlayerTurn);
            game = await _gameRepository.UpdateAsync(game);
            return ObjectMapper.Map<Game, GameDto>(game);
        }

        [Authorize]
        public async Task<GameDto> EndTurnAsync(Guid id)
        {
            Game game = await _gameRepository.GetAsync(id);
            game.CurrentPlayerTurn.End();
            await _playerRepository.UpdateManyAsync(game.Players);
            await _playerTurnRepository.UpdateAsync(game.CurrentPlayerTurn);
            game = await _gameRepository.UpdateAsync(game);
            return ObjectMapper.Map<Game, GameDto>(game);
        }

        [Authorize]
        public async Task<GameDto> EndAsync(Guid id)
        {
            Game game = await _gameRepository.GetAsync(id);
            game.End();
            game = await _gameRepository.UpdateAsync(game);
            return ObjectMapper.Map<Game, GameDto>(game);
        }
    }
}
