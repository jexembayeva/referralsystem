using ReferralSystem.Database.Repositories.Base;
using ReferralSystem.Models.Domain.VehicleBases;

namespace ReferralSystem.Database.Repositories.VehicleBases
{
    public class VehicleBaseRepository : Repository<VehicleBase>, IVehicleBaseRepository
    {
        public VehicleBaseRepository(IDatabaseConnectionFactory connection)
            : base(nameof(VehicleBase), connection)
        {
        }
    }
}