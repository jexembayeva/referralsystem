using ReferralSystem.Database.Repositories.Base;
using ReferralSystem.Models.Domain.Segments;

namespace ReferralSystem.Database.Repositories.Segments
{
    public class SegmentRepository : Repository<Segment>, ISegmentRepository
    {
        public SegmentRepository(IDatabaseConnectionFactory connection)
            : base(nameof(Segment), connection)
        {
        }
    }
}