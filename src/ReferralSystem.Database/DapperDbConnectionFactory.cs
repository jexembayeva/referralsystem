using System.Data;
using Npgsql;

namespace ReferralSystem.Database
{
    public class DapperDbConnectionFactory : IDatabaseConnectionFactory
    {
        public IDbConnection GetConnection()
        {
            return new NpgsqlConnection("Server=localhost;Port=5433;Database=refferralsystem;User Id=rs;Password=Str0ngPass!");
        }
    }
}
