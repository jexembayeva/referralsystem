using System;
using ReferralSystem.Models.Domain.BaseModels;
using Utils.Validators;

namespace ReferralSystem.Models.Domain.Devices
{
    public class Device : BaseModel
    {
        protected Device()
        {
        }

        public Device(int imei, string serialNumber, string comment, string token)
        {
            IMEI = imei;
            SerialNumber = serialNumber;
            Comment = comment;
            UpdateToken = token;
        }

        public long FirmWareId { get; set; }

        public long StabilizerId { get; set; }

        public long SimcardId { get; set; }

        public int IMEI { get; set; }

        public string SerialNumber { get; set; }

        public string Comment { get; set; }

        public DateTimeOffset ValidFrom { get; set; }

        public DateTimeOffset ValidTo { get; set; }

        public void UpdateOrFail(string serialNumber, string comment, int imei)
        {
            IMEI = imei;
            SerialNumber = serialNumber;
            Comment = comment;

            this.ThrowIfInvalid();
        }
    }
}