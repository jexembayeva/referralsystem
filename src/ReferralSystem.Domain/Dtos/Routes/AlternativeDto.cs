using System;
using ReferralSystem.Models.Domain.Routes;
using Utils.Dates;
using Utils.Enums;
using Utils.Interfaces;

namespace ReferralSystem.Domain.Dtos.Routes
{
    public class AlternativeDto : BaseModelDto, IHasFromToDates
    {
        public string NameRu { get; set; }

        public string NameEn { get; set; }

        public string NameKk { get; set; }

        public string FullNameRu { get; set; }

        public string FullNameEn { get; set; }

        public string FullNameKk { get; set; }

        public int VehicleCount { get; set; }

        public int PeakInterval { get; set; }

        public int OffPeakInterval { get; set; }

        public long RouteId { get; set; }

        public long VehicleTypeId { get; set; }

        public DateTimeOffset ValidFrom { get; set; }

        public DateTimeOffset? ValidTo { get; set; }

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