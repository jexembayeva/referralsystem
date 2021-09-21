using System.Threading.Tasks;
using System.Transactions;
using Dapper;
using ReferralSystem.Database.Repositories.Base;
using ReferralSystem.Models.Domain.Segments;
using Utils.Exceptions;
using Utils.Helpers;

namespace ReferralSystem.Database.Repositories.Segments
{
    public class SegmentRepository : Repository<Segment>, ISegmentRepository
    {
        private readonly IDatabaseConnectionFactory _connection;

        public SegmentRepository(IDatabaseConnectionFactory connection)
            : base(nameof(Segment), connection)
        {
            connection.ThrowIfNull(nameof(connection));

            _connection = connection;
        }

        public async Task InsertAsync(Segment segmentToInsert, Segment segmentToMakeOutdated)
        {
            await DoWithinTransactionAsync(
                action: async () =>
                {
                    await this.UpdateAsync(segmentToMakeOutdated);
                    await this.InsertAsync(segmentToInsert);
                    return true;
                },
                errorMessage: "Cannot import user due to database error");
        }
    }
}