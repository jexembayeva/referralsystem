using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Database.Repositories.Providers.Regions;
using ReferralSystem.Domain.Dtos.Providers;
using ReferralSystem.Models.Domain.Providers;

namespace ReferralSystem.Domain.Services.Providers.Regions
{
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _regionRepository;

        public RegionService(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await _regionRepository.GetAllAsync();
        }

        public async Task DeleteAsync(long id)
        {
            await _regionRepository.DeleteAsync(id);
        }

        public async Task<Region> GetByIdAsync(long id)
        {
            return await _regionRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(RegionDto data)
        {
            var region = await _regionRepository.GetByIdAsync(data.Id);

            region.UpdateOrFail(
                data.NameEn,
                data.NameKk,
                data.NameRu,
                data.Comment);

            await _regionRepository.UpdateAsync(region);
        }

        public async Task InsertAsync(RegionDto data)
        {
            var region = data.NewRegion();
            await _regionRepository.InsertAsync(region);
        }
    }
}