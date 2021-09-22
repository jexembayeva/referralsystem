using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Database.Repositories.Devices.Stabilizers;
using ReferralSystem.Domain.Dtos.Devices;
using ReferralSystem.Domain.Services.SimCards;
using ReferralSystem.Models.Domain.Devices;

namespace ReferralSystem.Domain.Services.Devices.SimCards
{
    public class StabilizerService : IStabilizerService
    {
        private readonly IStabilizerRepository _stabilizerRepository;

        public StabilizerService(IStabilizerRepository stabilizerRepository)
        {
            _stabilizerRepository = stabilizerRepository;
        }

        public async Task<IEnumerable<Stabilizer>> GetAllAsync()
        {
            return await _stabilizerRepository.GetAllAsync();
        }

        public async Task DeleteAsync(long id)
        {
            await _stabilizerRepository.DeleteAsync(id);
        }

        public async Task<Stabilizer> GetByIdAsync(long id)
        {
            return await _stabilizerRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(StabilizerDto data)
        {
            var stabilizer = await _stabilizerRepository.GetByIdAsync(data.Id);

            stabilizer.UpdateOrFail(data.Name, data.Comment);
            await _stabilizerRepository.UpdateAsync(stabilizer);
        }

        public async Task InsertAsync(StabilizerDto data)
        {
            var stabilizer = data.NewStabilizer();
            await _stabilizerRepository.InsertAsync(stabilizer);
        }
    }
}