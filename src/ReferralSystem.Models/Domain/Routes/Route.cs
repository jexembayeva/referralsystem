using System;
using System.Collections.Generic;
using System.Linq;
using Dapper.Contrib.Extensions;
using ReferralSystem.Models.Domain.BaseModels;
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
            DateTimeOffset validFrom,
            DateTimeOffset? validTo)
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
            ValidFrom = validFrom;
            ValidTo = validTo;
        }

        public Route(string nameRu, string nameEn, string nameKk, string fullNameRu, string fullNameEn, string fullNameKk, double distance, string comment, string openReason, string closeReason, IEnumerable<Alternative> alternatives)
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
            Alternatives = alternatives;
        }

        public string NameRu { get; protected set; }

        public string NameEn { get; protected set; }

        public string NameKk { get; protected set; }

        public string FullNameRu { get; protected set; }

        public string FullNameEn { get; protected set; }

        public string FullNameKk { get; protected set; }

        public double Distance { get; protected set; }

        public string Comment { get; protected set; }

        public string OpenReason { get; protected set; }

        public string CloseReason { get; protected set; }

        public DateTimeOffset ValidFrom { get; protected set; }

        public DateTimeOffset? ValidTo { get; protected set; }

        [Write(false)]
        public IEnumerable<Alternative> Alternatives { get; protected set; }

        public Alternative ActiveAlternativeOrNull()
        {
            return Alternatives.FirstOrDefault(x => x.Active);
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