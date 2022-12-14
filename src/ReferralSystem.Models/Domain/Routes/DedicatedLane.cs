using System;
using ReferralSystem.Models.Domain.BaseModels;
using Utils.Interfaces;
using Utils.Validators;

namespace ReferralSystem.Models.Domain.Routes
{
    public class DedicatedLane : BaseModel, IHasFromToDates
    {
        protected DedicatedLane()
        {
        }

        public DedicatedLane(
            string name,
            int peakSpeed,
            int offPeakSpeed,
            DateTimeOffset validFrom,
            DateTimeOffset? validTo)
        {
            Name = name;
            PeakSpeed = peakSpeed;
            OffPeakSpeed = offPeakSpeed;
            ValidFrom = validFrom;
            ValidTo = validTo;
        }

        public string Name { get; protected set; }

        public int PeakSpeed { get; protected set; }

        public int OffPeakSpeed { get; protected set; }

        public DateTimeOffset ValidFrom { get; protected set; }

        public DateTimeOffset? ValidTo { get; protected set; }

        public void UpdateOrFail(
            string name,
            int peakSpeed,
            int offPeakSpeed,
            DateTimeOffset validFrom,
            DateTimeOffset? validTo)
        {
            Name = name;
            PeakSpeed = peakSpeed;
            OffPeakSpeed = offPeakSpeed;
            ValidFrom = validFrom;
            ValidTo = validTo;

            this.ThrowIfInvalid();
        }
    }
}
