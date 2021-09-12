using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ReferralSystem.Database.Repositories.Stops;
using ReferralSystem.Domain.Dtos.Stops;
using ReferralSystem.Models.Domain.Stop;

namespace ReferralSystem.Domain.Services.Stops
{
    public class StopService : IStopService
    {
        private readonly IStopRepository _stopRepository;

        public StopService(IStopRepository stopRepository)
        {
            _stopRepository = stopRepository;
        }

        public async Task<IEnumerable<Stop>> GetAllAsync()
        {
            return await _stopRepository.GetAllAsync();
        }

        public async Task DeleteAsync(long id)
        {
            await _stopRepository.DeleteAsync(id);
        }

        public async Task<Stop> GetByIdAsync(long id)
        {
            return await _stopRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(StopDto data, CancellationToken cancellationToken)
        {
            var stop = await _stopRepository.GetByIdAsync(data.Id);

            stop.UpdateOrFail(data.NameEn, data.NameKk, data.NameRu);
            await _stopRepository.UpdateAsync(stop);
        }

        public async Task InsertAsync(StopDto data, CancellationToken cancellationToken)
        {
            var stop = data.NewStop(cancellationToken);
            await _stopRepository.InsertAsync(stop);
        }
    }
}