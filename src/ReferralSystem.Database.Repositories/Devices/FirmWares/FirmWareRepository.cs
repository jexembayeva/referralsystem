using ReferralSystem.Database.Repositories.Base;
using ReferralSystem.Database.Repositories.Devices.FirmWares;
using ReferralSystem.Models.Domain.Devices;

namespace ReferralSystem.Database.Repositories.Devices
{
    public class FirmWareRepository : Repository<FirmWare>, IFirmWareRepository
    {
        public FirmWareRepository(IDatabaseConnectionFactory connection)
            : base(nameof(FirmWare), connection)
        {
        }
    }
}