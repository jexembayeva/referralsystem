using ReferralSystem.Models.Domain.BaseModels;

namespace ReferralSystem.Models.Domain.Vehicles
{
    public class VehicleType : BaseModel
    {
        protected VehicleType()
        {
        }

        public string Name { get; protected set; }

        public int CostPerKM { get; protected set; }

        public int VehiclePrice { get; protected set; }

        public long VehicleComfortId { get; protected set; }

        public long VehicleSizeId { get; protected set; }
    }
}