using ReferralSystem.Database.Repositories.Base;
using ReferralSystem.Models.Domain.Routes;

namespace ReferralSystem.Database.Repositories.Routes.RoutePlans
{
    public class RoutePlanRepository : Repository<RoutePlan>, IRoutePlanRepository
    {
        public RoutePlanRepository(IDatabaseConnectionFactory connection)
            : base(nameof(RoutePlan), connection)
        {
        }
    }
}