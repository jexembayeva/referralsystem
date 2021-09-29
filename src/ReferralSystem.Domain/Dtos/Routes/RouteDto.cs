using System;
using ReferralSystem.Models.Domain.Routes;
using Utils.Attributes;
using Utils.Dates;
using Utils.Enums;
using Utils.Interfaces;

namespace ReferralSystem.Domain.Dtos.Routes
{
    public class RouteDto : BaseModelDto, IHasFromToDates
    {
        public string NameRu { get; set; }

        public string NameEn { get; set; }

        public string NameKk { get; set; }

        public string FullNameRu { get; set; }

        public string FullNameEn { get; set; }

        public string FullNameKk { get; set; }

        public double Distance { get; set; }

        public string Comment { get; set; }

        public string OpenReason { get; set; }

        public string CloseReason { get; set; }

        [NotDefaultValue]
        public WorkSeason WorkSeason { get;  set; }

        [NotDefaultValue]
        public RouteCategory RouteCategory { get; set; }

        [NotDefaultValue]
        public RouteType RouteType { get; set; }

        public DateTimeOffset ValidFrom { get; set; }

        public DateTimeOffset? ValidTo { get; set; }

        public Route NewRoute()
        {
            return new Route(
                nameRu: NameRu,
                nameEn: NameEn,
                nameKk: NameKk,
                fullNameRu: FullNameRu,
                fullNameEn: FullNameEn,
                fullNameKk: FullNameKk,
                distance: Distance,
                comment: Comment,
                openReason: OpenReason,
                closeReason: CloseReason,
                workSeason: WorkSeason,
                routeCategory: RouteCategory,
                routeType: RouteType,
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