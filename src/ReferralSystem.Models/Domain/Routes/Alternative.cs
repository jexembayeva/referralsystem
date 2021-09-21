using System;
using Dapper.Contrib.Extensions;
using ReferralSystem.Models.Domain.BaseModels;
using Utils.Enums;
using Utils.Exceptions;
using Utils.Interfaces;
using Utils.Validators;

namespace ReferralSystem.Models.Domain.Routes
{
    public class Alternative : BaseModel, IHasFromToDates
    {
        protected Alternative()
        {
        }

        public Alternative(
            string nameRu,
            string nameEn,
            string nameKk,
            string fullNameRu,
            string fullNameEn,
            string fullNameKk,
            int vehicleCount,
            int peakInterval,
            int offPeakInterval,
            long routeId,
            long vehicleTypeId,
            DateTimeOffset validFrom,
            DateTimeOffset? validTo,
            Status status)
        {
            NameRu = nameRu;
            NameEn = nameEn;
            NameKk = nameKk;
            FullNameRu = fullNameRu;
            FullNameEn = fullNameEn;
            FullNameKk = fullNameKk;
            VehicleCount = vehicleCount;
            PeakInterval = peakInterval;
            OffPeakInterval = offPeakInterval;
            RouteId = routeId;
            VehicleTypeId = vehicleTypeId;
            ValidFrom = validFrom;
            ValidTo = validTo;
            Status = status;
        }

        public string NameRu { get; protected set; }

        public string NameEn { get; protected set; }

        public string NameKk { get; protected set; }

        public string FullNameRu { get; protected set; }

        public string FullNameEn { get; protected set; }

        public string FullNameKk { get; protected set; }

        public int VehicleCount { get; protected set; }

        public int PeakInterval { get; protected set; }

        public int OffPeakInterval { get; protected set; }

        public long RouteId { get; protected set; }

        public long VehicleTypeId { get; protected set; }

        public DateTimeOffset ValidFrom { get; protected set; }

        public DateTimeOffset? ValidTo { get; protected set; }

        public Status Status { get; protected set; }

        [Write(false)]
        public bool Active => Status == Status.Active;

        public void UpdateOrFail(string nameRu, string nameEn, string nameKk)
        {
            NameRu = nameRu;
            NameEn = nameEn;
            NameKk = nameKk;

            this.ThrowIfInvalid();
        }

        public void UpdateToMakeOutdatedOrFail(DateTimeOffset validTo)
        {
            ValidTo = validTo;
            Status = Status.Outdated;

            if (this.RangeReversed(true))
            {
                throw new BadRequestException("Previous segment becomes invalid due to this operation");
            }

            this.ThrowIfDateRangeIsNotValid(true);
            this.ThrowIfDateRangeIsOutOfAllowedLimits();
            this.ThrowIfInvalid();
        }
    }
}