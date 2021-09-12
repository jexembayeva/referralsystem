using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace ReferralSystem.Database.Repositories.Extensions
{
    public static class ListOfProperties
    {
        public static List<string> GenerateListOfProperties(IEnumerable<PropertyInfo> listOfProperties)
        {
            return (from prop in listOfProperties
                    let attributes = prop.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    where (attributes.Length <= 0 || (attributes[0] as DescriptionAttribute)?.Description != "ignore") && (!prop.Name.Equals("Id") && !prop.Name
                        .Equals("CreatedAt") && !prop.Name.Equals("UpdatedAt"))
                    select prop.Name).ToList();
        }
    }
}