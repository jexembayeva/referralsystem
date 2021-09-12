using ReferralSystem.Models.Domain.BaseModels;

namespace ReferralSystem.Models.Domain.Vehicles
{
    public class VehicleSize : BaseModel
    {
        public string Name { get; set; }

        public int Seats { get; set; }

        public int Capacity { get; set; }

        public int Square { get; set; }
    }
}