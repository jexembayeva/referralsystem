using ReferralSystem.Models.Domain.BaseModels;

namespace ReferralSystem.Models.Domain.Devices
{
    public class FirmWare : BaseModel
    {
        protected FirmWare()
        {
        }

        public string Name { get; protected set; }

        public string Config { get; protected set; }

        public string Comment { get; protected set; }
    }
}