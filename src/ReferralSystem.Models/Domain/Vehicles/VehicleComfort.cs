using ReferralSystem.Models.Domain.BaseModels;

namespace ReferralSystem.Models.Domain.Vehicles
{
    public class VehicleComfort : BaseModel
    {
        protected VehicleComfort()
        {
        }

        public string Name { get; protected set; }

        public bool HasAirCon { get; protected set; }

        public bool HasRampant { get; protected set; }

        public int Doors { get; protected set; }
    }
}