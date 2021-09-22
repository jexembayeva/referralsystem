using ReferralSystem.Database.Repositories.Base;
using ReferralSystem.Models.Domain.Vehicles;

namespace ReferralSystem.Database.Repositories.Vehicles.VehicleTypes
{
    public class VehicleSizeRepository : Repository<VehicleType>, IVehicleTypeRepository
    {
        public VehicleSizeRepository(IDatabaseConnectionFactory connection)
            : base(nameof(VehicleType), connection)
        {
        }
    }
}