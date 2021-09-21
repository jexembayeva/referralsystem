using ReferralSystem.Database.Repositories.Base;
using ReferralSystem.Models.Domain.Providers;

namespace ReferralSystem.Database.Repositories.Providers.Regions
{
    public class RegionRepository : Repository<Region>, IRegionRepository
    {
        public RegionRepository(IDatabaseConnectionFactory connection)
            : base(nameof(Region), connection)
        {
        }
    }
}