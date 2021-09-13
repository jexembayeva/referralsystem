using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Domain.Dtos.Stops;
using ReferralSystem.Models.Domain.Stop;

namespace ReferralSystem.Domain.Services.Stops
{
    public interface IStopService
    {
        Task<IEnumerable<Stop>> GetAllAsync();

        Task DeleteAsync(long id);

        Task<Stop> GetByIdAsync(long id);

        Task UpdateAsync(StopDto stop);

        Task InsertAsync(StopDto stop);
    }
}