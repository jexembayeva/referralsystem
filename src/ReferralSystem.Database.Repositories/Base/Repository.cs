using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Dapper;
using ReferralSystem.Database.Repositories.Extensions;
using Utils.Exceptions;
using Utils.Helpers;
using Utils.Interfaces;
using Utils.Validators;

namespace ReferralSystem.Database.Repositories.Base
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IBaseModel
    {
        private readonly string _tableName;
        private readonly IDatabaseConnectionFactory _connection;

        protected Repository(string tableName, IDatabaseConnectionFactory connection)
        {
            tableName.ThrowIfNull(nameof(tableName));
            connection.ThrowIfNull(nameof(connection));

            _tableName = tableName;
            _connection = connection;
        }

        private static IEnumerable<PropertyInfo> GetProperties =>
            typeof(TEntity).GetProperties().Where(QueryExtensions.IsWriteable).ToArray();

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _connection.GetConnection().QueryAsync<TEntity>($"SELECT * FROM {_tableName}");
        }

        public virtual async Task<TEntity> GetByIdAsync(long id)
        {
            return await _connection.GetConnection()
                       .QuerySingleOrDefaultAsync<TEntity>($"SELECT * FROM {_tableName} WHERE Id=@Id", new { Id = id })
                   ?? throw ResourceNotFoundException.CreateFromEntity<TEntity>(id);
        }

        public virtual async Task UpdateAsync(TEntity data)
        {
            data.ThrowIfNull(nameof(data));
            data.ThrowIfInvalid();

            var updateQuery = GetProperties.GenerateUpdateQuery(_tableName);
            await _connection.GetConnection().ExecuteAsync(updateQuery, data);
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            entity.ThrowIfNull(nameof(entity));
            entity.ThrowIfInvalid();

            var insertQuery = GetProperties.GenerateInsertQuery(_tableName);
            await _connection.GetConnection().ExecuteAsync(insertQuery, entity);
        }

        public async Task InsertAsync(TEntity entityToInsert, TEntity entityToMakeOutdated)
        {
            await DoWithinTransactionAsync(
                action: async () =>
                {
                    if (entityToMakeOutdated != null)
                    {
                        await UpdateAsync(entityToMakeOutdated);
                    }

                    await InsertAsync(entityToInsert);
                    return true;
                });
        }

        public virtual async Task DeleteAsync(long id)
        {
            await _connection.GetConnection().ExecuteAsync($"DELETE FROM {_tableName} WHERE Id=@Id", new { Id = id });
        }

        public async Task<TResult> DoWithinTransactionAsync<TResult>(
            Func<Task<TResult>> action,
            string errorMessage = null)
        {
            action.ThrowIfNull(nameof(action));
            using (var connection = _connection.GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        TResult result = await action();

                        transaction.Commit();

                        return result;
                    }
                    catch (Exception exception)
                    {
                        transaction.Rollback();
                        const string defaultError = "Cannot execute transaction due to database error";
                        throw new InvalidOperationException(errorMessage ?? defaultError, exception);
                    }
                }
            }
        }
    }
}