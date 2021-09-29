using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Dapper.Contrib.Extensions;
using ReferralSystem.Models.Domain.BaseModels;
using Utils.Attributes;
using Utils.Enums;
using Utils.Interfaces;
using Utils.Validators;

namespace ReferralSystem.Models.Domain.Routes
{
    public class Route : BaseModel, IHasFromToDates
    {
        protected Route()
        {
        }

        public Route(
            string nameRu,
            string nameEn,
            string nameKk,
            string fullNameRu,
            string fullNameEn,
            string fullNameKk,
            double distance,
            string comment,
            string openReason,
            string closeReason,
            WorkSeason workSeason,
            RouteCategory routeCategory,
            RouteType routeType,
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
            Distance = distance;
            Comment = comment;
            OpenReason = openReason;
            CloseReason = closeReason;
            WorkSeason = workSeason;
            RouteCategory = routeCategory;
            RouteType = routeType;
            ValidFrom = validFrom;
            ValidTo = validTo;
            Status = status;
        }

        public Route(
            string nameRu,
            string nameEn,
            string nameKk,
            string fullNameRu,
            string fullNameEn,
            string fullNameKk,
            double distance,
            string comment,
            string openReason,
            string closeReason,
            WorkSeason workSeason,
            RouteCategory routeCategory,
            RouteType routeType,
            DateTimeOffset validFrom,
            DateTimeOffset? validTo,
            IEnumerable<Alternative> alternatives,
            IEnumerable<RoutePlan> routePlans)
        {
            NameRu = nameRu;
            NameEn = nameEn;
            NameKk = nameKk;
            FullNameRu = fullNameRu;
            FullNameEn = fullNameEn;
            FullNameKk = fullNameKk;
            Distance = distance;
            Comment = comment;
            OpenReason = openReason;
            CloseReason = closeReason;
            WorkSeason = workSeason;
            RouteCategory = routeCategory;
            RouteType = routeType;
            ValidFrom = validFrom;
            ValidTo = validTo;
            Alternatives = alternatives;
            RoutePlans = routePlans;
        }

        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string NameRu { get; protected set; }

        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string NameEn { get; protected set; }

        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string NameKk { get; protected set; }

        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string FullNameRu { get; protected set; }

        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string FullNameEn { get; protected set; }

        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string FullNameKk { get; protected set; }

        public double Distance { get; protected set; }

        public string Comment { get; protected set; }

        public string OpenReason { get; protected set; }

        public string CloseReason { get; protected set; }

        [NotDefaultValue]
        public WorkSeason WorkSeason { get; protected set; }

        [NotDefaultValue]
        public RouteCategory RouteCategory { get; protected set; }

        [NotDefaultValue]
        public RouteType RouteType { get; protected set; }

        public DateTimeOffset ValidFrom { get; protected set; }

        public DateTimeOffset? ValidTo { get; protected set; }

        [NotDefaultValue]
        public Status Status { get; protected set; }

        [Write(false)]
        public bool Active => Status == Status.Active;

        [Write(false)]
        public IEnumerable<Alternative> Alternatives { get; protected set; }

        [Write(false)]
        public IEnumerable<RoutePlan> RoutePlans { get; protected set; }

        [Write(false)]
        public IEnumerable<RouteSchedule> RouteSchedules { get; protected set; }

        public Alternative ActiveAlternativeOrNull()
        {
            return Alternatives.FirstOrDefault(x => x.Active);
        }

        public RoutePlan ActiveRoutePlanOrNull()
        {
            return RoutePlans.FirstOrDefault(x => x.Active);
        }

        public RouteSchedule ActiveRouteScheduleOrNull()
        {
            return RouteSchedules.FirstOrDefault(x => x.Active);
        }

        public void UpdateOrFail(string nameEn, string nameKk, string nameRu)
        {
            NameRu = nameRu;
            NameKk = nameKk;
            NameEn = nameEn;

            this.ThrowIfDateRangeIsNotValid(false);
            this.ThrowIfDateRangeIsOutOfAllowedLimits();
            this.ThrowIfInvalid();
        }
    }
}