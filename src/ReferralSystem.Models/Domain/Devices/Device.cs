using System;
using ReferralSystem.Models.Domain.BaseModels;
using Utils.Interfaces;
using Utils.Validators;

namespace ReferralSystem.Models.Domain.Devices
{
    public class Device : BaseModel, IHasFromToDates
    {
        protected Device()
        {
        }

        public Device(
            long firmWareId,
            long stabilizerId,
            long simcardId,
            int imei,
            string serialNumber,
            string comment,
            DateTimeOffset validFrom,
            DateTimeOffset? validTo)
        {
            FirmWareId = firmWareId;
            StabilizerId = stabilizerId;
            SimcardId = simcardId;
            IMEI = imei;
            SerialNumber = serialNumber;
            Comment = comment;
            ValidFrom = validFrom;
            ValidTo = validTo;
        }

        public long FirmWareId { get; protected set; }

        public long StabilizerId { get; protected set; }

        public long SimcardId { get; protected set; }

        public int IMEI { get; protected set; }

        public string SerialNumber { get; protected set; }

        public string Comment { get; protected set; }

        public DateTimeOffset ValidFrom { get; protected set; }

        public DateTimeOffset? ValidTo { get; protected set; }

        public void UpdateOrFail(
            long firmWareId,
            long stabilizerId,
            long simcardId,
            int imei,
            string serialNumber,
            string comment,
            DateTimeOffset? validTo)
        {
            FirmWareId = firmWareId;
            StabilizerId = stabilizerId;
            SimcardId = simcardId;
            IMEI = imei;
            SerialNumber = serialNumber;
            Comment = comment;
            ValidTo = validTo;

            this.ThrowIfDateRangeIsNotValid(false);
            this.ThrowIfDateRangeIsOutOfAllowedLimits();
            this.ThrowIfInvalid();
        }
    }
}