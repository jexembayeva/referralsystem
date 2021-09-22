using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Domain.Dtos.Routes;
using ReferralSystem.Models.Domain.Routes;

namespace ReferralSystem.Domain.Services.Routes.LadStops
{
    public interface ILadStopService
    {
        Task<IEnumerable<LadStop>> GetAllAsync();

        Task DeleteAsync(long id);

        Task<LadStop> GetByIdAsync(long id);

        Task UpdateAsync(LadStopDto lad);

        Task InsertAsync(LadStopDto lad);
    }
}