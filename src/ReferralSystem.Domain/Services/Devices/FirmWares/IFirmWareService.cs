using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Domain.Dtos.Devices;
using ReferralSystem.Models.Domain.Devices;

namespace ReferralSystem.Domain.Services.Devices
{
    public interface IFirmWareService
    {
        Task<IEnumerable<FirmWare>> GetAllAsync();

        Task DeleteAsync(long id);

        Task<FirmWare> GetByIdAsync(long id);

        Task UpdateAsync(FirmWareDto firmWare);

        Task InsertAsync(FirmWareDto firmWare);
    }
}