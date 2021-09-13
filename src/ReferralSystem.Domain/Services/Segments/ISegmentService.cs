using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ReferralSystem.Domain.Dtos.Segments;
using ReferralSystem.Models.Domain.Segments;

namespace ReferralSystem.Domain.Services.Segments
{
    public interface ISegmentService
    {
        Task<IEnumerable<Segment>> GetAllAsync();

        Task DeleteAsync(long id);

        Task<Segment> GetByIdAsync(long id);

        Task UpdateAsync(SegmentDto stop);

        Task InsertAsync(SegmentDto stop);
    }
}