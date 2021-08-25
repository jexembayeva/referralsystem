using ReferralSystem.Database;
using ReferralSystem.Database.Repositories.Base;
using TestUtils.EntityFactories;

namespace TestUtils
{
    public class FakeRepository: Repository<FakeEntity>
    {
        public FakeRepository(string tableName, IDatabaseConnectionFactory connection) : base(tableName, connection)
        {
        }
    }
}