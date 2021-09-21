using System.Threading.Tasks;
using ReferralSystem.Database.Repositories.Base;
using ReferralSystem.Models.Domain.Segments;

namespace ReferralSystem.Database.Repositories.Segments
{
    public interface ISegmentRepository : IRepository<Segment>
    {
        Task InsertAsync(Segment segmentToInsert, Segment segmentToMakeOutdated);
    }
}