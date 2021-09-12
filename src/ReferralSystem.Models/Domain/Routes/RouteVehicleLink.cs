using ReferralSystem.Models.Domain.BaseModels;

namespace ReferralSystem.Models.Domain.Routes
{
    public class RouteVehicleLink : BaseModel
    {
        public long RouteId { get; set; }

        public long VehicleId { get; set; }
    }
}