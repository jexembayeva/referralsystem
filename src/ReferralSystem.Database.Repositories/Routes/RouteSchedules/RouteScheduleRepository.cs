using ReferralSystem.Database.Repositories.Base;
using ReferralSystem.Models.Domain.Routes;

namespace ReferralSystem.Database.Repositories.Routes.RouteSchedules
{
    public class RouteScheduleRepository : Repository<RouteSchedule>, IRouteScheduleRepository
    {
        public RouteScheduleRepository(IDatabaseConnectionFactory connection)
            : base(nameof(RouteSchedule), connection)
        {
        }
    }
}