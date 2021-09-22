using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Domain.Dtos.Routes;
using ReferralSystem.Models.Domain.Routes;

namespace ReferralSystem.Domain.Services.Routes.RoutePlans
{
    public interface IRouteScheduleService
    {
        Task<IEnumerable<RouteSchedule>> GetAllAsync();

        Task DeleteAsync(long id);

        Task<RouteSchedule> GetByIdAsync(long id);

        Task UpdateAsync(RouteScheduleDto routeSchedule);

        Task InsertAsync(RouteScheduleDto routeSchedule);
    }
}