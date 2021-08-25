using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Utils.Exceptions;
using Utils.Helpers;
using Utils.Interfaces;
using Utils.Validators;

namespace ReferralSystem.Database.Repositories.Base
{
    public abstract class Repository<T> : IRepository<T> where T : class, IBaseModel
    {
        private readonly string _tableName;
        private readonly IDatabaseConnectionFactory _connection;

        protected Repository(string tableName, IDatabaseConnectionFactory connection)
        {
            _tableName = tableName;
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        private IEnumerable<PropertyInfo> GetProperties => typeof(T).GetProperties();

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _connection.GetConnection().QueryAsync<T>($"SELECT * FROM {_tableName}");
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await _connection.GetConnection()
                       .QuerySingleOrDefaultAsync<T>($"SELECT * FROM {_tableName} WHERE Id=@Id", new {Id = id})
                   ?? throw ResourceNotFoundException.CreateFromEntity<T>(id);
        }

        public async Task UpdateAsync(T t)
        {
            t.ThrowIfNull(nameof(t));
            t.ThrowIfInvalid();
            
            var updateQuery = GenerateUpdateQuery();
            await _connection.GetConnection().ExecuteAsync(updateQuery, t);
        }

        public async Task InsertAsync(T t)
        {
            t.ThrowIfNull(nameof(t));
            t.ThrowIfInvalid();
            
            var insertQuery = GenerateInsertQuery();
            await _connection.GetConnection().ExecuteAsync(insertQuery, t);
        }

        public async Task DeleteAsync(long id)
        {
            await _connection.GetConnection().ExecuteAsync($"DELETE FROM {_tableName} WHERE Id=@Id", new {Id = id});
        }
        
        private string GenerateUpdateQuery()
        {
            var updateQuery = new StringBuilder($"UPDATE {_tableName} SET ");
            var properties = GenerateListOfProperties(GetProperties);

            properties.ForEach(property =>
            {
                if (!property.Equals("Id"))
                {
                    updateQuery.Append($"{property}=@{property},");
                }
            });

            updateQuery.Remove(updateQuery.Length - 1, 1);
            updateQuery.Append(" WHERE Id=@Id");

            return updateQuery.ToString();
        }


        private static List<string> GenerateListOfProperties(IEnumerable<PropertyInfo> listOfProperties)
        {
            return (from prop in listOfProperties
                let attributes = prop.GetCustomAttributes(typeof(DescriptionAttribute), false)
                where attributes.Length <= 0 || (attributes[0] as DescriptionAttribute)?.Description != "ignore"
                select prop.Name).ToList();
        }

        private string GenerateInsertQuery()
        {
            var insertQuery = new StringBuilder($"INSERT INTO {_tableName} ");

            insertQuery.Append('(');

            var properties = GenerateListOfProperties(GetProperties);
            properties.ForEach(prop => { insertQuery.Append($"[{prop}],"); });

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(") VALUES (");

            properties.ForEach(prop => { insertQuery.Append($"@{prop},"); });

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(')');

            return insertQuery.ToString();
        }
    }
}