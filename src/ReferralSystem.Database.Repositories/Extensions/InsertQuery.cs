using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ReferralSystem.Database.Repositories.Extensions
{
    public static class InsertQuery
    {
        public static string GenerateInsertQuery(string tableName, IEnumerable<PropertyInfo> listOfProperties)
        {
            var insertQuery = new StringBuilder($"INSERT INTO {tableName} ");

            insertQuery.Append('(');

            var properties = ListOfProperties.GenerateListOfProperties(listOfProperties);
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
    }
}