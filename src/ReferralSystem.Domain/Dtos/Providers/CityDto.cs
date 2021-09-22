using ReferralSystem.Models.Domain.Providers;

namespace ReferralSystem.Domain.Dtos.Providers
{
    public class CityDto : BaseModelDto
    {
        public string NameRu { get; set; }

        public string NameEn { get; set; }

        public string NameKk { get; set; }

        public long RegionId { get; set; }

        public string Comment { get; set; }

        public City NewCity()
        {
            return new City(
                nameRu: NameRu,
                nameEn: NameEn,
                nameKk: NameKk);
        }
    }
}