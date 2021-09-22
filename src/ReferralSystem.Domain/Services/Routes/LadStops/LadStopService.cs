using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Database.Repositories.Routes.LadStops;
using ReferralSystem.Domain.Dtos.Routes;
using ReferralSystem.Models.Domain.Routes;

namespace ReferralSystem.Domain.Services.Routes.LadStops
{
    public class LadStopService : ILadStopService
    {
        private readonly ILadStopRepository _ladStopRepository;

        public LadStopService(ILadStopRepository ladStopRepository)
        {
            _ladStopRepository = ladStopRepository;
        }

        public async Task<IEnumerable<LadStop>> GetAllAsync()
        {
            return await _ladStopRepository.GetAllAsync();
        }

        public async Task DeleteAsync(long id)
        {
            await _ladStopRepository.DeleteAsync(id);
        }

        public async Task<LadStop> GetByIdAsync(long id)
        {
            return await _ladStopRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(LadStopDto data)
        {
            var ladStop = await _ladStopRepository.GetByIdAsync(data.Id);

            ladStop.UpdateOrFail(data.StopOrder, data.Distance, data.PassCount);
            await _ladStopRepository.UpdateAsync(ladStop);
        }

        public async Task InsertAsync(LadStopDto data)
        {
            var ladStop = data.NewLadStop();
            await _ladStopRepository.InsertAsync(ladStop);
        }
    }
}