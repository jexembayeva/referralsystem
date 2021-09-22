using ReferralSystem.Database.Repositories.Base;
using ReferralSystem.Models.Domain.Devices;

namespace ReferralSystem.Database.Repositories.Devices.SimCards
{
    public class SimCardRepository : Repository<SimCard>, ISimCardRepository
    {
        public SimCardRepository(IDatabaseConnectionFactory connection)
            : base(nameof(SimCard), connection)
        {
        }
    }
}