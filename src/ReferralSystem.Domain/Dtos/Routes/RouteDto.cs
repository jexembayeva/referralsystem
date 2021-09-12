using System.Threading;
using ReferralSystem.Models.Domain.Routes;

namespace ReferralSystem.Domain.Dtos.Routes
{
    public class RouteDto : BaseModelDto
    {
        public string NameRu { get; set; }

        public string NameEn { get; set; }

        public string NameKk { get; set; }

        public string FullNameRu { get; set; }

        public string FullNameEn { get; set; }

        public string FullNameKk { get; set; }

        public double Distance { get; set; }

        public string Comment { get; set; }

        public string OpenReason { get; set; }

        public string CloseReason { get; set; }

        public Route NewRoute(CancellationToken cancellationToken)
        {
            return new Route(
                nameRu: NameRu,
                nameEn: NameEn,
                nameKk: NameKk,
                fullNameRu: FullNameRu,
                fullNameEn: FullNameEn,
                fullNameKk: FullNameKk,
                distance: Distance,
                comment: Comment,
                openReason: OpenReason,
                closeReason: CloseReason,
                token: cancellationToken.ToString());
        }
    }
}