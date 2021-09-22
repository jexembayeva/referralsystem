using ReferralSystem.Database.Repositories.Base;
using ReferralSystem.Models.Domain.Vehicles;

namespace ReferralSystem.Database.Repositories.Vehicles.VehicleSizes
{
    public class VehicleSizeRepository : Repository<VehicleSize>, IVehicleSizeRepository
    {
        public VehicleSizeRepository(IDatabaseConnectionFactory connection)
            : base(nameof(VehicleSize), connection)
        {
        }
    }
}