using ReferralSystem.Models.Domain.BaseModels;

namespace ReferralSystem.Models.Domain.Routes
{
    public class RouteVehicleLink : BaseModel
    {
        protected RouteVehicleLink()
        {
        }

        public long RouteId { get; protected set; }

        public long VehicleId { get; protected set; }
    }
}