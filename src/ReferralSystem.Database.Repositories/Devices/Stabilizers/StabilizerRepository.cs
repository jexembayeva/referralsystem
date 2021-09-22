using ReferralSystem.Database.Repositories.Base;
using ReferralSystem.Models.Domain.Devices;

namespace ReferralSystem.Database.Repositories.Devices.Stabilizers
{
    public class StabilizerRepository : Repository<Stabilizer>, IStabilizerRepository
    {
        public StabilizerRepository(IDatabaseConnectionFactory connection)
            : base(nameof(Stabilizer), connection)
        {
        }
    }
}