using ReferralSystem.Models.Domain.BaseModels;
using Utils.Validators;

namespace ReferralSystem.Models.Domain.Devices
{
    public class SimCard : BaseModel
    {
        protected SimCard()
        {
        }

        public SimCard(
            string serialNumber,
            string phoneNumber,
            string pin1,
            string pin2,
            string puk1,
            string puk2,
            string comment)
        {
            SerialNumber = serialNumber;
            PhoneNumber = phoneNumber;
            PIN1 = pin1;
            PIN2 = pin2;
            PUK1 = puk1;
            PUK2 = puk2;
            Comment = comment;
        }

        public string SerialNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string PIN1 { get; set; }

        public string PIN2 { get; set; }

        public string PUK1 { get; set; }

        public string PUK2 { get; set; }

        public string Comment { get; set; }

        public void UpdateOrFail(
            string serialNumber,
            string phoneNumber,
            string pin1,
            string pin2,
            string puk1,
            string puk2,
            string comment)
        {
            SerialNumber = serialNumber;
            PhoneNumber = phoneNumber;
            PIN1 = pin1;
            PIN2 = pin2;
            PUK1 = puk1;
            PUK2 = puk2;
            Comment = comment;

            this.ThrowIfInvalid();
        }
    }
}