using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ThousandBombsAndGrenades.Games
{
    public class GameAppService_Tests : ThousandBombsAndGrenadesApplicationTestBase
    {
        private readonly IGameAppService _gameAppService;

        public GameAppService_Tests()
        {
            _gameAppService = GetRequiredService<IGameAppService>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            var result = await _gameAppService.GetListAsync();
            result.TotalCount.ShouldBe(2);
        }

        [Fact]
        public async Task GetAsync()
        {
            var result = await _gameAppService.GetAsync(Guid.Parse("313dd332-dcf6-4b84-a17f-e4663515a71a"));
            result.Players.Count.ShouldBe(2);
        }
    }
}
