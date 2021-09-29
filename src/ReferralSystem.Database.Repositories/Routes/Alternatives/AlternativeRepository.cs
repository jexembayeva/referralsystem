using System.Threading.Tasks;
using Dapper;
using ReferralSystem.Database.Repositories.Base;
using ReferralSystem.Models.Domain.Routes;
using Utils.Enums;
using Utils.Helpers;

namespace ReferralSystem.Database.Repositories.Routes.Alternatives
{
    public class AlternativeRepository : Repository<Alternative>, IAlternativeRepository
    {
        private readonly IDatabaseConnectionFactory _connection;

        public AlternativeRepository(IDatabaseConnectionFactory connection)
            : base(nameof(Alternative), connection)
        {
            connection.ThrowIfNull(nameof(connection));
            _connection = connection;
        }

        public async Task<Alternative> GetAlternativeAsync(long id)
        {
            var alternative = await GetByIdAsync(id);
            var lads = await _connection.GetConnection().QueryAsync<Lad>($"SELECT * FROM {nameof(Lad)} WHERE AlternativeId=@AlternativeId", new { AlternativeId = id });

            return new Alternative(
                               nameEn: alternative.NameEn,
                               nameKk: alternative.NameKk,
                               nameRu: alternative.NameRu,
                               fullNameRu: alternative.FullNameRu,
                               fullNameEn: alternative.FullNameEn,
                               fullNameKk: alternative.FullNameKk,
                               vehicleCount: alternative.VehicleCount,
                               peakInterval: alternative.PeakInterval,
                               offPeakInterval: alternative.OffPeakInterval,
                               routeId: alternative.RouteId,
                               alternativeType: alternative.AlternativeType,
                               vehicleTypeId: alternative.VehicleTypeId,
                               validFrom: alternative.ValidFrom,
                               validTo: alternative.ValidTo,
                               status: Status.Active,
                               lads: lads);
        }
    }
}