using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Domain.Dtos.Providers;
using ReferralSystem.Models.Domain.Providers;

namespace ReferralSystem.Domain.Services.Providers.Regions
{
    public interface IRegionService
    {
        Task<IEnumerable<Region>> GetAllAsync();

        Task DeleteAsync(long id);

        Task<Region> GetByIdAsync(long id);

        Task UpdateAsync(RegionDto region);

        Task InsertAsync(RegionDto region);
    }
}