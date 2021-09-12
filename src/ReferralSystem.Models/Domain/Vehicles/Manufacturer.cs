using ReferralSystem.Models.Domain.BaseModels;

namespace ReferralSystem.Models.Domain.Vehicles
{
    public class Manufacturer : BaseModel
    {
        public string Name { get; set; }

        public string Country { get; set; }
    }
}