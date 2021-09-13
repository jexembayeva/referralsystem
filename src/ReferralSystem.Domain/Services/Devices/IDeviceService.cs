using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ReferralSystem.Domain.Dtos.Devices;
using ReferralSystem.Models.Domain.Devices;

namespace ReferralSystem.Domain.Services.Devices
{
    public interface IDeviceService
    {
        Task<IEnumerable<Device>> GetAllAsync();

        Task DeleteAsync(long id);

        Task<Device> GetByIdAsync(long id);

        Task UpdateAsync(DeviceDto device, CancellationToken cancellationToken);

        Task InsertAsync(DeviceDto device, CancellationToken cancellationToken);
    }
}