using ReferralSystem.Models.Domain.Providers;

namespace ReferralSystem.Domain.Dtos.Providers
{
    public class RegionDto : BaseModelDto
    {
        protected RegionDto()
        {
        }

        public string NameRu { get; protected set; }

        public string NameEn { get; protected set; }

        public string NameKk { get; protected set; }

        public string Comment { get; protected set; }

        public Region NewRegion()
        {
            return new Region(
                nameRu: NameRu,
                nameEn: NameEn,
                nameKk: NameKk);
        }
    }
}