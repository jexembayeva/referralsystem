using System;
using ReferralSystem.Models.Domain.BaseModels;
using Utils.Validators;

namespace ReferralSystem.Models.Domain.Routes
{
    public class Route : BaseModel
    {
        protected Route()
        {
        }

        public Route(string nameRu, string nameEn, string nameKk, string fullNameRu, string fullNameEn, string fullNameKk, double distance, string comment, string openReason, string closeReason)
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