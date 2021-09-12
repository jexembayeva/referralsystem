using ReferralSystem.Database.Repositories.Base;
using ReferralSystem.Models.Domain.Vehicles;

namespace ReferralSystem.Database.Repositories.Vehicles
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(IDatabaseConnectionFactory connection)
            : base(nameof(Vehicle), connection)
        {
        }
    }
}