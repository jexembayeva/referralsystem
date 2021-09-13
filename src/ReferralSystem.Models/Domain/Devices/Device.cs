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

        public Device(int imei, string serialNumber, string comment)
        {
            IMEI = imei;
            SerialNumber = serialNumber;
            Comment = comment;
        }

        public long FirmWareId { get; protected set; }

        public long StabilizerId { get; protected set; }

        public long SimcardId { get; protected set; }

        public int IMEI { get; protected set; }

        public string SerialNumber { get; protected set; }

        public string Comment { get; protected set; }

        public DateTimeOffset ValidFrom { get; protected set; }

        public DateTimeOffset ValidTo { get; protected set; }

        public void UpdateOrFail(string serialNumber, string comment, int imei)
        {
            IMEI = imei;
            SerialNumber = serialNumber;
            Comment = comment;

            this.ThrowIfInvalid();
        }
    }
}