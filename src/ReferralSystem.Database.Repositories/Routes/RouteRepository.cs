using System.Threading.Tasks;
using Dapper;
using ReferralSystem.Database.Repositories.Base;
using ReferralSystem.Models.Domain.Routes;
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

        public async Task<Route> GetRouteAsync(long id)
        {
            var route = await GetByIdAsync(id);
            var alternatives = await _connection.GetConnection().QueryAsync<Alternative>($"SELECT * FROM {nameof(Alternative)} WHERE RouteId=@RouteId", new { RouteId = id });

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
                workSeason: route.WorkSeason,
                routeCategory: route.RouteCategory,
                routeType: route.RouteType,
                validFrom: route.ValidFrom,
                validTo: route.ValidTo,
                alternatives: alternatives);
        }
    }
}
