using ReferralSystem.Database.Repositories.Base;
using ReferralSystem.Models.Domain.Vehicles;

namespace ReferralSystem.Database.Repositories.Vehicles.VehicleTypes
{
    public class VehicleTypeRepository : Repository<VehicleType>, IVehicleTypeRepository
    {
        public VehicleTypeRepository(IDatabaseConnectionFactory connection)
            : base(nameof(VehicleType), connection)
        {
        }
    }
}