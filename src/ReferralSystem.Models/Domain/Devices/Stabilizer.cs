using ReferralSystem.Models.Domain.BaseModels;

namespace ReferralSystem.Models.Domain.Devices
{
    public class Stabilizer : BaseModel
    {
        protected Stabilizer()
        {
        }

        public string Name { get; protected set; }

        public string Comment { get; protected set; }
    }
}
