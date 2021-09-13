using ReferralSystem.Models.Domain.BaseModels;

namespace ReferralSystem.Models.Domain.Vehicles
{
    public class Manufacturer : BaseModel
    {
        protected Manufacturer()
        {
        }

        public string Name { get; protected set; }

        public string Country { get; protected set; }
    }
}