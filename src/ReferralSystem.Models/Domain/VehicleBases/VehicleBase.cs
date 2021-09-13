using System;
using System.Threading;
using ReferralSystem.Models.Domain.BaseModels;
using Utils.Validators;

namespace ReferralSystem.Models.Domain.Bases
{
    public class VehicleBase : BaseModel
    {
        protected VehicleBase()
        {
        }

        public VehicleBase(string nameRu, string nameEn, string nameKk, double polygon, string comment, string token)
        {
            NameRu = nameRu;
            NameEn = nameEn;
            NameKk = nameKk;
            Polygon = polygon;
            Comment = comment;
            UpdateToken = token;
            ValidFrom = DateTimeOffset.Now;
            ValidTo = DateTimeOffset.Now;
        }

        public string NameRu { get; protected set; }

        public string NameEn { get; protected set; }

        public string NameKk { get; protected set; }

        public double Polygon { get; protected set; }

        public long ProviderId { get; protected set; }

        public string Comment { get; protected set; }

        public DateTimeOffset ValidFrom { get; protected set; }

        public DateTimeOffset ValidTo { get; protected set; }

        public void UpdateOrFail(string nameEn, string nameKk, string nameRu)
        {
            NameRu = nameRu;
            NameKk = nameKk;
            NameEn = nameEn;

            this.ThrowIfInvalid();
        }
    }
}