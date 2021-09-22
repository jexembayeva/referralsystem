using ReferralSystem.Models.Domain.BaseModels;
using Utils.Validators;

namespace ReferralSystem.Models.Domain.Devices
{
    public class SimCard : BaseModel
    {
        protected SimCard()
        {
        }

        public SimCard(string serialNumber, string comment, string phoneNumber)
        {
            SerialNumber = serialNumber;
            Comment = comment;
            PhoneNumber = phoneNumber;
        }

        public string SerialNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string PIN1 { get; set; }

        public string PIN2 { get; set; }

        public string PUK1 { get; set; }

        public string PUK2 { get; set; }

        public string Comment { get; set; }

        public void UpdateOrFail(string serialNumber, string comment, string phoneNumber)
        {
            SerialNumber = serialNumber;
            Comment = comment;
            PhoneNumber = phoneNumber;

            this.ThrowIfInvalid();
        }
    }
}