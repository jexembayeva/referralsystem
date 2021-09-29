using System;
using System.Threading;
using ReferralSystem.Models.Domain.BaseModels;
using Utils.Interfaces;
using Utils.Validators;

namespace ReferralSystem.Models.Domain.VehicleBases
{
    public class VehicleBase : BaseModel, IHasFromToDates
    {
        protected VehicleBase()
        {
        }

        public VehicleBase(
            string nameRu,
            string nameEn,
            string nameKk,
            double polygon,
            long providerId,
            string comment,
            DateTimeOffset validFrom,
            DateTimeOffset? validTo)
        {
            NameRu = nameRu;
            NameEn = nameEn;
            NameKk = nameKk;
            Polygon = polygon;
            ProviderId = providerId;
            Comment = comment;
            ValidFrom = validFrom;
            ValidTo = validTo;
        }

        public string NameRu { get; protected set; }

        public string NameEn { get; protected set; }

        public string NameKk { get; protected set; }

        public double Polygon { get; protected set; }

        public long ProviderId { get; protected set; }

        public string Comment { get; protected set; }

        public DateTimeOffset ValidFrom { get; protected set; }

        public DateTimeOffset? ValidTo { get; protected set; }

        public void UpdateOrFail(
            string nameRu,
            string nameEn,
            string nameKk,
            double polygon,
            long providerId,
            string comment,
            DateTimeOffset? validTo)
        {
            NameRu = nameRu;
            NameEn = nameEn;
            NameKk = nameKk;
            Polygon = polygon;
            ProviderId = providerId;
            Comment = comment;
            ValidTo = validTo;

            this.ThrowIfInvalid();
        }
    }
}