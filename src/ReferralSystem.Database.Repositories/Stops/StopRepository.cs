using ReferralSystem.Database.Repositories.Base;
using ReferralSystem.Database.Repositories.Routes;
using ReferralSystem.Models.Domain.Stop;

namespace ReferralSystem.Database.Repositories.Stops
{
    public class StopRepository : Repository<Stop>, IStopRepository
    {
        public StopRepository(IDatabaseConnectionFactory connection)
            : base(nameof(Stop), connection)
        {
        }
    }
}