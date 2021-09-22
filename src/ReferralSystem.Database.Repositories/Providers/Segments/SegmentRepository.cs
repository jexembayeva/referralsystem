using ReferralSystem.Database.Repositories.Base;
using ReferralSystem.Models.Domain.Providers;

namespace ReferralSystem.Database.Repositories.Providers.Segments
{
    public class SegmentRepository : Repository<Segment>, ISegmentRepository
    {
        public SegmentRepository(IDatabaseConnectionFactory connection)
            : base(nameof(Segment), connection)
        {
        }
    }
}