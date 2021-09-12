using ReferralSystem.Database.Repositories.Base;
using ReferralSystem.Models.Domain.Devices;

namespace ReferralSystem.Database.Repositories.Devices
{
    public class DeviceRepository : Repository<Device>, IDeviceRepository
    {
        public DeviceRepository(IDatabaseConnectionFactory connection)
            : base(nameof(Device), connection)
        {
        }
    }
}