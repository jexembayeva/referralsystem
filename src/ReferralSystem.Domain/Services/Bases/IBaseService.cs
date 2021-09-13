using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ReferralSystem.Domain.Dtos.Bases;
using ReferralSystem.Models.Domain.Bases;

namespace ReferralSystem.Domain.Services.Bases
{
    public interface IBaseService
    {
        Task<IEnumerable<BasePlatform>> GetAllAsync();

        Task DeleteAsync(long id);

        Task<BasePlatform> GetByIdAsync(long id);

        Task UpdateAsync(BasePlatformDto basePlatform, CancellationToken cancellationToken);

        Task InsertAsync(BasePlatformDto basePlatform, CancellationToken cancellationToken);
    }
}