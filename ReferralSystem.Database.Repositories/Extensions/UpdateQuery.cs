using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ReferralSystem.Database.Repositories.Extensions
{
    public static class UpdateQuery
    {
        public static string GenerateUpdateQuery(string tableName, IEnumerable<PropertyInfo> listOfProperties)
        {
            var updateQuery = new StringBuilder($"UPDATE {tableName} SET ");
            var properties = ListOfProperties.GenerateListOfProperties(listOfProperties);

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
    }
}