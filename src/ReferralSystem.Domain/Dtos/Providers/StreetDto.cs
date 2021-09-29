using System;
using ReferralSystem.Models.Domain.Providers;

namespace ReferralSystem.Domain.Dtos.Providers
{
    public class StreetDto : BaseModelDto
    {
        public string NameRu { get; set; }

        public string NameEn { get; set; }

        public string NameKk { get; set; }

        public DateTimeOffset ValidFrom { get; set; }

        public DateTimeOffset? ValidTo { get; set; }

        public string Comment { get; set; }

        public Street NewStreet()
        {
            return new Street(
                nameEn: NameEn,
                nameKk: NameKk,
                nameRu: NameRu,
                comment: Comment,
                validFrom: ValidFrom,
                validTo: ValidTo);
        }
    }
}
