using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace ThousandBombsAndGrenades.Samples
{
    public class SampleAppService : ThousandBombsAndGrenadesAppService, ISampleAppService
    {
        public Task<SampleDto> GetAsync()
        {
            return Task.FromResult(
                new SampleDto
                {
                    Value = 42
                }
            );
        }

        [Authorize]
        public Task<SampleDto> GetAuthorizedAsync()
        {
            return Task.FromResult(
                new SampleDto
                {
                    Value = 42
                }
            );
        }
    }
}