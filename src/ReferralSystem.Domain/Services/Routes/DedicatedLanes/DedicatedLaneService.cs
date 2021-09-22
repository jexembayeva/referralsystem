using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Database.Repositories.Routes.DedicatedLanes;
using ReferralSystem.Domain.Dtos.Routes;
using ReferralSystem.Models.Domain.Routes;

namespace ReferralSystem.Domain.Services.Routes.DedicatedLanes
{
    public class DedicatedLaneService : IDedicatedLaneService
    {
        private readonly IDedicatedLaneRepository _dedicatedLaneRepository;

        public DedicatedLaneService(IDedicatedLaneRepository dedicatedLaneRepository)
        {
            _dedicatedLaneRepository = dedicatedLaneRepository;
        }

        public async Task<IEnumerable<DedicatedLane>> GetAllAsync()
        {
            return await _dedicatedLaneRepository.GetAllAsync();
        }

        public async Task DeleteAsync(long id)
        {
            await _dedicatedLaneRepository.DeleteAsync(id);
        }

        public async Task<DedicatedLane> GetByIdAsync(long id)
        {
            return await _dedicatedLaneRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(DedicatedLaneDto data)
        {
            var dedicatedLane = await _dedicatedLaneRepository.GetByIdAsync(data.Id);

            dedicatedLane.UpdateOrFail(data.Name, data.OffPeakSpeed, data.PeakSpeed);
            await _dedicatedLaneRepository.UpdateAsync(dedicatedLane);
        }

        public async Task InsertAsync(DedicatedLaneDto data)
        {
            var dedicatedLane = data.NewDedicatedLane();
            await _dedicatedLaneRepository.InsertAsync(dedicatedLane);
        }
    }
}