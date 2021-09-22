using System.Threading.Tasks;
using Dapper;
using ReferralSystem.Database.Repositories.Base;
using ReferralSystem.Models.Domain.Providers;
using Utils.Helpers;

namespace ReferralSystem.Database.Repositories.Providers.Districts
{
    public class DistrictRepository : Repository<District>, IDistrictRepository
    {
        private readonly IDatabaseConnectionFactory _connection;

        public DistrictRepository(IDatabaseConnectionFactory connection)
            : base(nameof(District), connection)
        {
            connection.ThrowIfNull(nameof(connection));
            _connection = connection;
        }

        public async Task<District> GetRouteAsync(long id)
        {
            var district = await GetByIdAsync(id);
            var segments = await _connection.GetConnection().QueryAsync<Segment>($"SELECT * FROM {nameof(Segment)} WHERE DistrictId=@DistrictId", new { DistrictId = id });

            return new District(
                nameRu: district.NameRu,
                nameEn: district.NameEn,
                nameKk: district.NameKk,
                segments: segments);
        }
    }
}