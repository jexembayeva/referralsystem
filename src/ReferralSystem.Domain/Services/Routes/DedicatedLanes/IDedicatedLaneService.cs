using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Domain.Dtos.Routes;
using ReferralSystem.Models.Domain.Routes;

namespace ReferralSystem.Domain.Services.Routes.DedicatedLanes
{
    public interface IDedicatedLaneService
    {
        Task<IEnumerable<DedicatedLane>> GetAllAsync();

        Task DeleteAsync(long id);

        Task<DedicatedLane> GetByIdAsync(long id);

        Task UpdateAsync(DedicatedLaneDto dedicatedLane);

        Task InsertAsync(DedicatedLaneDto dedicatedLane);
    }
}