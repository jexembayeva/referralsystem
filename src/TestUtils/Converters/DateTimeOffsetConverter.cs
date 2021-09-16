using System;
using System.Data;
using ServiceStack.OrmLite.Converters;

namespace TestUtils.Converters
{
    public class DateTimeOffsetConverter : DateTimeConverter
    {
        public override string ColumnDefinition => "DATETIME";

        public override DbType DbType => DbType.DateTime;

        public override object FromDbValue(Type fieldType, object value)
        {
            var dateTime = DateTimeOffset.FromUnixTimeSeconds((long)value);

            return dateTime;
        }

        public override object ToDbValue(Type fieldType, object value)
        {
            return ((DateTimeOffset)value).UtcDateTime;
        }
    }
}