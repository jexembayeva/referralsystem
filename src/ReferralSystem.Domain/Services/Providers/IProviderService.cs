using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ReferralSystem.Domain.Dtos.Providers;
using ReferralSystem.Models.Domain.Providers;

namespace ReferralSystem.Domain.Services.Providers
{
    public interface IProviderService
    {
        Task<IEnumerable<Provider>> GetAllAsync();

        Task DeleteAsync(long id);

        Task<Provider> GetByIdAsync(long id);

        Task UpdateAsync(ProviderDto provider);

        Task InsertAsync(ProviderDto provider);
    }
}