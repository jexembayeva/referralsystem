using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Domain.Dtos.Providers;
using ReferralSystem.Models.Domain.Providers;

namespace ReferralSystem.Domain.Services.Providers.Streets
{
    public interface IStreetService
    {
        Task<IEnumerable<Street>> GetAllAsync();

        Task DeleteAsync(long id);

        Task<Street> GetByIdAsync(long id);

        Task UpdateAsync(StreetDto street);

        Task InsertAsync(StreetDto street);
    }
}