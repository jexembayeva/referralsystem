using ReferralSystem.Models.Domain.BaseModels;

namespace ReferralSystem.Models.Domain.Vehicles
{
    public class VehicleSize : BaseModel
    {
        protected VehicleSize()
        {
        }

        public string Name { get; protected set; }

        public int Seats { get; protected set; }

        public int Capacity { get; protected set; }

        public int Square { get; protected set; }
    }
}