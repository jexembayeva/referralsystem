using ReferralSystem.Database.Repositories.Base;
using ReferralSystem.Database.Repositories.Vehicles.Manufacturers;
using ReferralSystem.Models.Domain.Vehicles;

namespace ReferralSystem.Database.Repositories.Vehicles.VehicleComforts
{
    public class ManufacturerRepository : Repository<Manufacturer>, IManufacturerRepository
    {
        public ManufacturerRepository(IDatabaseConnectionFactory connection)
            : base(nameof(Manufacturer), connection)
        {
        }
    }
}