using System.Data;

namespace ReferralSystem.Database
{
    public interface IDatabaseConnectionFactory
    {
        IDbConnection GetConnection();
    }
}