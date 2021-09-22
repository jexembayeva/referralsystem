using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Domain.Dtos.Devices;
using ReferralSystem.Models.Domain.Devices;

namespace ReferralSystem.Domain.Services.Devices.SimCards
{
    public interface ISimCardService
    {
        Task<IEnumerable<SimCard>> GetAllAsync();

        Task DeleteAsync(long id);

        Task<SimCard> GetByIdAsync(long id);

        Task UpdateAsync(SimCardDto simCard);

        Task InsertAsync(SimCardDto simCard);
    }
}