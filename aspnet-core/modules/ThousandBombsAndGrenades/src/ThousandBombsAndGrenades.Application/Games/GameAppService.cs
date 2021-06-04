using System;
using System.Collections.Generic;
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
        private readonly IPlayerTurnRepository _playerTurnRepository;

        public GameAppService(
            IGameRepository gameRepository,
            IPlayerTurnRepository playerTurnRepository
        )
        {
            _gameRepository = gameRepository;
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

        public async Task<GameDto> CreateAsync()
        {
            Game game = new Game(Guid.NewGuid())
            {
                DeckOfCards = new Deck.DeckOfCards()
            };
            game = await _gameRepository.InsertAsync(game);
            return ObjectMapper.Map<Game, GameDto>(game);
        }

        public async Task<GameDto> AddPlayerAsync(Guid id, PlayerDto playerDto)
        {
            Game game = await _gameRepository.GetAsync(id);
            game.AddPlayer(playerDto.Name);
            game = await _gameRepository.UpdateAsync(game);
            return ObjectMapper.Map<Game, GameDto>(game);
        }

        public async Task<GameDto> RemovePlayerAsync(Guid id, Guid playerId)
        {
            Game game = await _gameRepository.GetAsync(id);
            game.RemovePlayer(playerId);
            game = await _gameRepository.UpdateAsync(game);
            return ObjectMapper.Map<Game, GameDto>(game);
        }

        public async Task<GameDto> StartAsync(Guid id)
        {
            Game game = await _gameRepository.GetAsync(id);
            game.Start();
            game = await _gameRepository.UpdateAsync(game);
            return ObjectMapper.Map<Game, GameDto>(game);
        }

        public async Task<GameDto> DrawCardAsync(Guid id)
        {
            Game game = await _gameRepository.GetAsync(id);
            game.CurrentPlayerTurn.DrawCard();
            game = await _gameRepository.UpdateAsync(game);
            return ObjectMapper.Map<Game, GameDto>(game);
        }

        public async Task<GameDto> RollDiceAsync(Guid id)
        {
            Game game = await _gameRepository.GetAsync(id);
            game.CurrentPlayerTurn.RollDice();
            await _playerTurnRepository.UpdateAsync(game.CurrentPlayerTurn);
            game = await _gameRepository.UpdateAsync(game);
            return ObjectMapper.Map<Game, GameDto>(game);
        }

        public async Task<GameDto> PickDiceAsync(Guid id, int index)
        {
            Game game = await _gameRepository.GetAsync(id);
            game.CurrentPlayerTurn.PickDice(index);
            await _playerTurnRepository.UpdateAsync(game.CurrentPlayerTurn);
            game = await _gameRepository.UpdateAsync(game);
            return ObjectMapper.Map<Game, GameDto>(game);
        }

        public async Task<GameDto> ReturnDiceAsync(Guid id, int index)
        {
            Game game = await _gameRepository.GetAsync(id);
            game.CurrentPlayerTurn.ReturnDice(index);
            await _playerTurnRepository.UpdateAsync(game.CurrentPlayerTurn);
            game = await _gameRepository.UpdateAsync(game);
            return ObjectMapper.Map<Game, GameDto>(game);
        }

        public async Task<GameDto> EndTurnAsync(Guid id)
        {
            Game game = await _gameRepository.GetAsync(id);
            game.CurrentPlayerTurn.End();
            await _playerTurnRepository.UpdateAsync(game.CurrentPlayerTurn);
            game = await _gameRepository.UpdateAsync(game);
            return ObjectMapper.Map<Game, GameDto>(game);
        }

        public async Task<GameDto> EndAsync(Guid id)
        {
            Game game = await _gameRepository.GetAsync(id);
            game.End();
            game = await _gameRepository.UpdateAsync(game);
            return ObjectMapper.Map<Game, GameDto>(game);
        }
    }
}
