using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Database.Repositories.Devices.FirmWares;
using ReferralSystem.Domain.Dtos.Devices;
using ReferralSystem.Models.Domain.Devices;

namespace ReferralSystem.Domain.Services.Devices
{
    public class FirmWareService : IFirmWareService
    {
        private readonly IFirmWareRepository _firmWareRepository;

        public FirmWareService(IFirmWareRepository firmWareRepository)
        {
            _firmWareRepository = firmWareRepository;
        }

        public async Task<IEnumerable<FirmWare>> GetAllAsync()
        {
            return await _firmWareRepository.GetAllAsync();
        }

        public async Task DeleteAsync(long id)
        {
            await _firmWareRepository.DeleteAsync(id);
        }

        public async Task<FirmWare> GetByIdAsync(long id)
        {
            return await _firmWareRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(FirmWareDto data)
        {
            var firmWare = await _firmWareRepository.GetByIdAsync(data.Id);

            firmWare.UpdateOrFail(data.Name, data.Comment, data.Config);
            await _firmWareRepository.UpdateAsync(firmWare);
        }

        public async Task InsertAsync(FirmWareDto data)
        {
            var firmWare = data.NewFirmWare();
            await _firmWareRepository.InsertAsync(firmWare);
        }
    }
}