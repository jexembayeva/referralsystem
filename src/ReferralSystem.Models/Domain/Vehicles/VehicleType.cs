using ReferralSystem.Models.Domain.BaseModels;

namespace ReferralSystem.Models.Domain.Vehicles
{
    public class VehicleType : BaseModel
    {
        public string Name { get; set; }

        public int CostPerKM { get; set; }

        public int VehiclePrice { get; set; }

        public long VehicleComfortId { get; set; }

        public long VehicleSizeId { get; set; }
    }
}