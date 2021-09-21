using System;
using ReferralSystem.Models.Domain.Routes;
using Utils.Dates;
using Utils.Enums;
using Utils.Interfaces;

namespace ReferralSystem.Domain.Dtos.Routes
{
    public class AlternativeDto : BaseModelDto, IHasFromToDates
    {
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

        public Alternative NewAlternative()
        {
            return new Alternative(
                nameEn: NameEn,
                nameKk: NameKk,
                nameRu: NameRu,
                fullNameRu: FullNameRu,
                fullNameEn: FullNameEn,
                fullNameKk: FullNameKk,
                vehicleCount: VehicleCount,
                peakInterval: PeakInterval,
                offPeakInterval: OffPeakInterval,
                routeId: RouteId,
                vehicleTypeId: VehicleTypeId,
                validFrom: ValidFrom,
                validTo: ValidTo,
                status: Status.Active);
        }

        public void CorrectDates()
        {
            ValidFrom = this.Since().StartOfTheDay();
            ValidTo = this.ToAsDateOrNull()?.EndOfTheDay();
        }
    }
}