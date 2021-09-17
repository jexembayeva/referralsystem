using System;
using ReferralSystem.Models.Domain.BaseModels;
using Utils.Interfaces;

namespace ReferralSystem.Models.Domain.Providers
{
    public class Street : BaseModel, IHasFromToDates
    {
        protected Street()
        {
        }

        public string NameRu { get; protected set; }

        public string NameEn { get; protected set; }

        public string NameKk { get; protected set; }

        public DateTimeOffset ValidFrom { get; protected set; }

        public DateTimeOffset? ValidTo { get; protected set; }

        public string Comment { get; protected set; }
    }
}