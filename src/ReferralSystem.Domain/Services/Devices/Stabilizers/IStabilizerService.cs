using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Domain.Dtos.Devices;
using ReferralSystem.Models.Domain.Devices;

namespace ReferralSystem.Domain.Services.SimCards
{
    public interface IStabilizerService
    {
        Task<IEnumerable<Stabilizer>> GetAllAsync();

        Task DeleteAsync(long id);

        Task<Stabilizer> GetByIdAsync(long id);

        Task UpdateAsync(StabilizerDto simCard);

        Task InsertAsync(StabilizerDto simCard);
    }
}