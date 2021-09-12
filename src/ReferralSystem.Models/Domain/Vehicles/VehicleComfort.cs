using ReferralSystem.Models.Domain.BaseModels;

namespace ReferralSystem.Models.Domain.Vehicles
{
    public class VehicleComfort : BaseModel
    {
        public string Name { get; set; }

        public bool HasAirCon { get; set; }

        public bool HasRampant { get; set; }

        public int Doors { get; set; }
    }
}