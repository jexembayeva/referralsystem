using System;
using System.Data;
using ServiceStack.OrmLite;
using TestUtils.Converters;

namespace TestUtils
{
    public class InMemoryDatabase
    {
        private readonly OrmLiteConnectionFactory _dbFactory;

        public InMemoryDatabase()
        {
            var dialectProvider = SqliteDialect.Provider;
            dialectProvider.RegisterConverter<DateTimeOffset>(new DateTimeOffsetConverter());
            _dbFactory = new OrmLiteConnectionFactory(":memory:", dialectProvider);
        }

        public IDbConnection OpenConnection() => _dbFactory.OpenDbConnection();

        public void Insert<T>(T item)
        {
            using var db = OpenConnection();

            db.CreateTableIfNotExists<T>();

            db.Insert(item);
        }
    }
}