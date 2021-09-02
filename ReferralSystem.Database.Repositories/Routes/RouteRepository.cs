using ReferralSystem.Database.Repositories.Base;
using ReferralSystem.Models.Domain.Routes;

namespace ReferralSystem.Database.Repositories.Routes
{
    public class RouteRepository : Repository<Route>, IRouteRepository
    {
        public RouteRepository(IDatabaseConnectionFactory connection)
            : base(" ", connection)
        {
        }
    }
}