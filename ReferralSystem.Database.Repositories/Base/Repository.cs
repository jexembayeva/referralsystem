using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ReferralSystem.Database.Repositories.Extensions;
using Utils.Exceptions;
using Utils.Helpers;
using Utils.Interfaces;
using Utils.Validators;

namespace ReferralSystem.Database.Repositories.Base
{
    public abstract class Repository<T> : IRepository<T>
        where T : class, IBaseModel
    {
        private readonly string _tableName;
        private readonly IDatabaseConnectionFactory _connection;

        protected Repository(string tableName, IDatabaseConnectionFactory connection)
        {
            _tableName = tableName;
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        private static IEnumerable<PropertyInfo> GetProperties => typeof(T).GetProperties();

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _connection.GetConnection().QueryAsync<T>($"SELECT * FROM {_tableName}");
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await _connection.GetConnection()
                       .QuerySingleOrDefaultAsync<T>($"SELECT * FROM {_tableName} WHERE Id=@Id", new { Id = id })
                   ?? throw ResourceNotFoundException.CreateFromEntity<T>(id);
        }

        public async Task UpdateAsync(T data)
        {
            data.ThrowIfNull(nameof(data));
            data.ThrowIfInvalid();

            var updateQuery = UpdateQuery.GenerateUpdateQuery(_tableName, GetProperties);
            await _connection.GetConnection().ExecuteAsync(updateQuery, data);
        }

        public async Task InsertAsync(T entity)
        {
            entity.ThrowIfNull(nameof(entity));
            entity.ThrowIfInvalid();

            var insertQuery = InsertQuery.GenerateInsertQuery(_tableName, GetProperties);
            await _connection.GetConnection().ExecuteAsync(insertQuery, entity);
        }

        public async Task DeleteAsync(long id)
        {
            await _connection.GetConnection().ExecuteAsync($"DELETE FROM {_tableName} WHERE Id=@Id", new { Id = id });
        }
    }
}