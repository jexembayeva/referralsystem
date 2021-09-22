using ReferralSystem.Database.Repositories.Base;
using ReferralSystem.Database.Repositories.Routes.DedicatedLanes;
using ReferralSystem.Models.Domain.Routes;

namespace ReferralSystem.Database.Repositories.Routes.LadStops
{
    public class DedicatedLaneRepository : Repository<DedicatedLane>, IDedicatedLaneRepository
    {
        public DedicatedLaneRepository(IDatabaseConnectionFactory connection)
            : base(nameof(DedicatedLane), connection)
        {
        }
    }
}