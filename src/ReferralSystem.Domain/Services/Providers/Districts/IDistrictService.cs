using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Domain.Dtos.Providers;
using ReferralSystem.Models.Domain.Providers;

namespace ReferralSystem.Domain.Services.Providers.Districts
{
    public interface IDistrictService
    {
        Task<IEnumerable<District>> GetAllAsync();

        Task DeleteAsync(long id);

        Task<District> GetByIdAsync(long id);

        Task UpdateAsync(DistrictDto district);

        Task InsertAsync(DistrictDto district);
    }
}