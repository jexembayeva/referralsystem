using ReferralSystem.Models.Domain.BaseModels;
using Utils.Attributes;
using Utils.Enums;

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

        [NotDefaultValue]
        public FloorType FloorType { get; protected set; }

        [NotDefaultValue]
        public SeatType SeatType { get; protected set; }
    }
}