using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Domain.Dtos.Providers;
using ReferralSystem.Models.Domain.Providers;

namespace ReferralSystem.Domain.Services.Providers.Segments
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