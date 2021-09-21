using ReferralSystem.Models.Domain.Providers;

namespace ReferralSystem.Domain.Dtos.Providers
{
    public class CityDto : BaseModelDto
    {
        public string NameRu { get; protected set; }

        public string NameEn { get; protected set; }

        public string NameKk { get; protected set; }

        public long RegionId { get; protected set; }

        public string Comment { get; protected set; }

        public City NewCity()
        {
            return new City(
                nameRu: NameRu,
                nameEn: NameEn,
                nameKk: NameKk);
        }
    }
}