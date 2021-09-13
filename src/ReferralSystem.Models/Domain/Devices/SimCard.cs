using ReferralSystem.Models.Domain.BaseModels;

namespace ReferralSystem.Models.Domain.Devices
{
    public class SimCard : BaseModel
    {
        protected SimCard()
        {
        }

        public string SerialNumber { get; protected set; }

        public string PhoneNumber { get; protected set; }

        public string PIN1 { get; protected set; }

        public string PIN2 { get; protected set; }

        public string PUK1 { get; protected set; }

        public string PUK2 { get; protected set; }

        public string Comment { get; protected set; }
    }
}