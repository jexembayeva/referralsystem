using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Domain.Dtos.Routes;
using ReferralSystem.Models.Domain.Routes;

namespace ReferralSystem.Domain.Services.Routes.RoutePlans
{
    public interface IRoutePlanService
    {
        Task<IEnumerable<RoutePlan>> GetAllAsync();

        Task DeleteAsync(long id);

        Task<RoutePlan> GetByIdAsync(long id);

        Task UpdateAsync(RoutePlanDto routePlan);

        Task InsertAsync(RoutePlanDto routePlan);
    }
}