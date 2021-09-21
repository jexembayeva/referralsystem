using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Domain.Dtos.Providers;
using ReferralSystem.Models.Domain.Providers;

namespace ReferralSystem.Domain.Services.Providers.Cities
{
    public interface ICityService
    {
        Task<IEnumerable<City>> GetAllAsync();

        Task DeleteAsync(long id);

        Task<City> GetByIdAsync(long id);

        Task UpdateAsync(CityDto city);

        Task InsertAsync(CityDto city);
    }
}