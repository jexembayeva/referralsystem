using ReferralSystem.Models.Domain.Providers;

namespace ReferralSystem.Domain.Dtos.Providers
{
    public class RegionDto : BaseModelDto
    {
        protected RegionDto()
        {
        }

        public string NameRu { get; set; }

        public string NameEn { get; set; }

        public string NameKk { get; set; }

        public string Comment { get; set; }

        public Region NewRegion()
        {
            return new Region(
                nameRu: NameRu,
                nameEn: NameEn,
                nameKk: NameKk,
                comment: Comment);
        }
    }
}