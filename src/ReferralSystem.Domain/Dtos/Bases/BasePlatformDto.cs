using System.Threading;
using ReferralSystem.Models.Domain.Bases;

namespace ReferralSystem.Domain.Dtos.Bases
{
    public class BasePlatformDto : BaseModelDto
    {
        public string NameRu { get; set; }

        public string NameEn { get; set; }

        public string NameKk { get; set; }

        public double Polygon { get; set; }

        public long ProviderId { get; set; }

        public string Comment { get; set; }

        public BasePlatform NewBasePlatform(CancellationToken cancellationToken)
        {
            return new BasePlatform(
                nameEn: NameEn,
                nameRu: NameRu,
                nameKk: NameKk,
                polygon: Polygon,
                comment: Comment,
                token: cancellationToken.ToString());
        }
    }
}