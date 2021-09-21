using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using Dapper;
using Dapper.Contrib.Extensions;

namespace ReferralSystem.Database.Repositories.Extensions
{
    public static class QueryExtensions
    {
        public static string GenerateInsertQuery(this IEnumerable<PropertyInfo> listOfProperties, string tableName)
        {
            var insertQuery = new StringBuilder($"INSERT INTO {tableName} ");

            insertQuery.Append('(');

            var properties = listOfProperties.GenerateListOfProperties();
            properties.ForEach(prop => { insertQuery.Append($"{prop},"); });

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(") VALUES (");

            properties.ForEach(property =>
            {
                insertQuery.Append($"@{property},");
            });

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(')');

            return insertQuery.ToString();
        }

        public static string GenerateUpdateQuery(this IEnumerable<PropertyInfo> listOfProperties, string tableName)
        {
            var updateQuery = new StringBuilder($"UPDATE {tableName} SET ");
            var properties = listOfProperties.GenerateListOfProperties();

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

        public static bool IsWriteable(this PropertyInfo propertyInfo)
        {
            var attributes = propertyInfo.GetCustomAttributes(typeof(WriteAttribute), false).AsList();
            if (attributes.Count != 1)
            {
                return true;
            }

            var writeAttribute = (WriteAttribute)attributes[0];
            return writeAttribute.Write;
        }

        private static List<string> GenerateListOfProperties(this IEnumerable<PropertyInfo> listOfProperties)
        {
            return (from prop in listOfProperties
                let attributes = prop.GetCustomAttributes(typeof(DescriptionAttribute), false)
                where (attributes.Length <= 0 || (attributes[0] as DescriptionAttribute)?.Description != "ignore") && !prop.Name.Equals("Id") && !prop.Name
                    .Equals("CreatedAt") && !prop.Name.Equals("UpdatedAt")
                select prop.Name).ToList();
        }
    }
}