using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using ReferralSystem.Database.Repositories.Base;
using ReferralSystem.Models.Domain.Routes;
using ReferralSystem.Models.Domain.Segments;
using Utils.Exceptions;
using Utils.Helpers;

namespace ReferralSystem.Database.Repositories.Routes
{
    public class RouteRepository : Repository<Route>, IRouteRepository
    {
        private readonly IDatabaseConnectionFactory _connection;

        public RouteRepository(IDatabaseConnectionFactory connection)
            : base(nameof(Route), connection)
        {
            connection.ThrowIfNull(nameof(connection));
            _connection = connection;
        }

        public async Task<Route> GetRouteWithSegmentsAsync(long id)
        {
            var route = await this.GetByIdAsync(id);
            var segments = await _connection.GetConnection().QueryAsync<Segment>($"SELECT * FROM segment");
            return ToRoute(route, segments);
        }

        private Route ToRoute(Route route, IEnumerable<Segment> segments)
        {
            return new Route(
                nameRu: route.NameRu,
                nameEn: route.NameEn,
                nameKk: route.NameKk,
                fullNameRu: route.FullNameRu,
                fullNameEn: route.FullNameEn,
                fullNameKk: route.FullNameKk,
                distance: route.Distance,
                comment: route.Comment,
                openReason: route.OpenReason,
                closeReason: route.CloseReason,
                segments: segments);
        }
    }
}
