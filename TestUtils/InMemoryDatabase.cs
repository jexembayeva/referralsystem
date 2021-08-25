using System.Data;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Sqlite;

namespace TestUtils
{
    public class InMemoryDatabase
    {
        private readonly OrmLiteConnectionFactory _dbFactory =
            new(":memory:", SqliteOrmLiteDialectProvider.Instance);

        public IDbConnection OpenConnection() => _dbFactory.OpenDbConnection();

        public void Insert<T>(T item)
        {
            using var db = OpenConnection();

            db.CreateTableIfNotExists<T>();

            db.Insert(item);
        }
    }
}