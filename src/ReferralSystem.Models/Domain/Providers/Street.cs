using System;
using ReferralSystem.Models.Domain.BaseModels;

namespace ReferralSystem.Models.Domain.Providers
{
    public class Street : BaseModel
    {
        public string NameRu { get; set; }

        public string NameEn { get; set; }

        public string NameKk { get; set; }

        public DateTimeOffset ValidFrom { get; set; }

        public DateTimeOffset ValidTo { get; set; }

        public string Comment { get; set; }
    }
}