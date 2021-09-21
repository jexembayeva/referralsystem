using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Database.Repositories.Providers.Districts;
using ReferralSystem.Domain.Dtos.Providers;
using ReferralSystem.Models.Domain.Providers;

namespace ReferralSystem.Domain.Services.Providers.Districts
{
    public class DistrictService : IDistrictService
    {
        private readonly IDistrictRepository _districtRepository;

        public DistrictService(IDistrictRepository districtRepository)
        {
            _districtRepository = districtRepository;
        }

        public async Task<IEnumerable<District>> GetAllAsync()
        {
            return await _districtRepository.GetAllAsync();
        }

        public async Task DeleteAsync(long id)
        {
            await _districtRepository.DeleteAsync(id);
        }

        public async Task<District> GetByIdAsync(long id)
        {
            return await _districtRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(DistrictDto data)
        {
            var district = await _districtRepository.GetByIdAsync(data.Id);

            district.UpdateOrFail(data.NameEn, data.NameKk, data.NameRu);
            await _districtRepository.UpdateAsync(district);
        }

        public async Task InsertAsync(DistrictDto data)
        {
            var district = data.NewDistrict();
            await _districtRepository.InsertAsync(district);
        }
    }
}