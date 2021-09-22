using ReferralSystem.Database.Repositories.Base;
using ReferralSystem.Models.Domain.Routes;

namespace ReferralSystem.Database.Repositories.Routes.LadStops
{
    public class LadStopRepository : Repository<LadStop>, ILadStopRepository
    {
        public LadStopRepository(IDatabaseConnectionFactory connection)
            : base(nameof(LadStop), connection)
        {
        }
    }
}