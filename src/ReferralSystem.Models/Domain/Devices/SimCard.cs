using ReferralSystem.Models.Domain.BaseModels;

namespace ReferralSystem.Models.Domain.Devices
{
    public class SimCard : BaseModel
    {
        public string SerialNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string PIN1 { get; set; }

        public string PIN2 { get; set; }

        public string PUK1 { get; set; }

        public string PUK2 { get; set; }

        public string Comment { get; set; }
    }
}