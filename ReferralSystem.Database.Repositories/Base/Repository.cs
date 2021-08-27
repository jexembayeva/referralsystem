﻿using System;
using System.Collections.Generic;
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
            _tableName = tableName;
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        private static IEnumerable<PropertyInfo> GetProperties => typeof(TEntity).GetProperties();

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _connection.GetConnection().QueryAsync<TEntity>($"SELECT * FROM {_tableName}");
        }

        public async Task<TEntity> GetByIdAsync(long id)
        {
            return await _connection.GetConnection()
                       .QuerySingleOrDefaultAsync<TEntity>($"SELECT * FROM {_tableName} WHERE Id=@Id", new { Id = id })
                   ?? throw ResourceNotFoundException.CreateFromEntity<TEntity>(id);
        }

        public async Task UpdateAsync(TEntity data)
        {
            data.ThrowIfNull(nameof(data));
            data.ThrowIfInvalid();

            var updateQuery = UpdateQuery.GenerateUpdateQuery(_tableName, GetProperties);
            await _connection.GetConnection().ExecuteAsync(updateQuery, data);
        }

        public async Task InsertAsync(TEntity entity)
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