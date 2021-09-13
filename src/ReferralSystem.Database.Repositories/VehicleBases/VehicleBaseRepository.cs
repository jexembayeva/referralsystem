using ReferralSystem.Database.Repositories.Base;
using ReferralSystem.Models.Domain.Bases;

namespace ReferralSystem.Database.Repositories.Bases
{
    public class VehicleBaseRepository : Repository<VehicleBase>, IVehicleBaseRepository
    {
        public VehicleBaseRepository(IDatabaseConnectionFactory connection)
            : base(nameof(VehicleBase), connection)
        {
        }
    }
}