using System;
using ReferralSystem.Models.Domain.BaseModels;
using Utils.Interfaces;
using Utils.Validators;

namespace ReferralSystem.Models.Domain.Providers
{
    public class Street : BaseModel, IHasFromToDates
    {
        protected Street()
        {
        }

        public Street(
            string nameRu,
            string nameKk,
            string nameEn,
            string comment,
            DateTimeOffset validFrom,
            DateTimeOffset? validTo)
        {
            NameRu = nameRu;
            NameKk = nameKk;
            NameEn = nameEn;
            Comment = comment;
            ValidFrom = validFrom;
            ValidTo = validTo;
        }

        public string NameRu { get; protected set; }

        public string NameEn { get; protected set; }

        public string NameKk { get; protected set; }

        public DateTimeOffset ValidFrom { get; protected set; }

        public DateTimeOffset? ValidTo { get; protected set; }

        public string Comment { get; protected set; }

        public void UpdateOrFail(
            string nameRu,
            string nameKk,
            string nameEn,
            string comment,
            DateTimeOffset validFrom,
            DateTimeOffset? validTo)
        {
            NameRu = nameRu;
            NameKk = nameKk;
            NameEn = nameEn;
            Comment = comment;
            ValidFrom = validFrom;
            ValidTo = validTo;

            this.ThrowIfInvalid();
        }
    }
}