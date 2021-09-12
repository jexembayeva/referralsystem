using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ReferralSystem.Database.Repositories.Devices;
using ReferralSystem.Domain.Dtos.Devices;
using ReferralSystem.Models.Domain.Devices;

namespace ReferralSystem.Domain.Services.Devices
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _deviceRepository;

        public DeviceService(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task<IEnumerable<Device>> GetAllAsync()
        {
            return await _deviceRepository.GetAllAsync();
        }

        public async Task DeleteAsync(long id)
        {
            await _deviceRepository.DeleteAsync(id);
        }

        public async Task<Device> GetByIdAsync(long id)
        {
            return await _deviceRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(DeviceDto data, CancellationToken cancellationToken)
        {
            var device = await _deviceRepository.GetByIdAsync(data.Id);

            device.UpdateOrFail(data.SerialNumber, data.Comment, data.IMEI);
            await _deviceRepository.UpdateAsync(device);
        }

        public async Task InsertAsync(DeviceDto data, CancellationToken cancellationToken)
        {
            var device = data.NewDevice(cancellationToken);
            await _deviceRepository.InsertAsync(device);
        }
    }
}