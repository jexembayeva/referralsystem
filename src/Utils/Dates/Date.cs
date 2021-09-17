using System;
using Utils.Helpers;

namespace Utils.Dates
{
    public class Date : IEquatable<Date>
    {
        /// <summary>
        /// Gets now.
        /// </summary>
        public static Date Now => new Date(DateTimeOffset.Now);

        /// <summary>
        /// Gets tomorrow.
        /// </summary>
        public static Date Tomorrow => new Date(new DateTimeOffset(DateTime.Today.AddDays(1)));

        /// <summary>
        /// Gets today.
        /// </summary>
        public static Date Today => new Date(new DateTimeOffset(DateTime.Today));

        /// <summary>
        /// Gets yesterday.
        /// </summary>
        public static Date Yesterday => new Date(new DateTimeOffset(DateTime.Today.AddDays(-1)));

        /// <summary>
        /// Gets month as int.
        /// </summary>
        public int Month => Source.Month;

        /// <summary>
        /// Gets year as int.
        /// </summary>
        public int Year => Source.Year;

        /// <summary>
        /// Gets day as int.
        /// </summary>
        public int Day => Source.Day;

        public DateTimeOffset Source { get; }

        public Date(DateTimeOffset source)
        {
            Source = source;
        }

        public Date(int year, int month, int day)
            : this(new DateTimeOffset(new DateTime(year, month, day)))
        {
        }

        public Date(int year, int month, int day, int hour, int minute, int seconds)
            : this(
                new DateTimeOffset(
                    new DateTime(
                        year: year,
                        month: month,
                        day: day,
                        hour: hour,
                        minute: minute,
                        second: seconds)))
        {
        }

        public Date AddDays(int days)
        {
            return new Date(Source.AddDays(days));
        }

        public Date SubtractDays(int days)
        {
            return new Date(Source.AddDays(-1 * days));
        }

        public DateTimeOffset StartOfTheDay()
        {
            return new DateTimeOffset(
                year: Source.Year,
                month: Source.Month,
                day: Source.Day,
                hour: 0,
                minute: 0,
                second: 0,
                offset: Source.Offset);
        }

        public DateTimeOffset EndOfTheDay()
        {
            return new DateTimeOffset(
                year: Source.Year,
                month: Source.Month,
                day: Source.Day,
                hour: 23,
                minute: 59,
                second: 59,
                offset: Source.Offset);
        }

        public override string ToString() => ToString("yyyy-MM-dd");

        public string ToString(string format)
        {
            format.ThrowIfNullOrEmpty(nameof(format));

            return Source.ToString(format);
        }

        public bool Equals(Date other)
        {
            if (other == null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Source.Equal(other.Source);
        }

        public override bool Equals(object other)
        {
            if (other == null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (!(other is Date))
            {
                return false;
            }

            return Equals((Date)other);
        }

        public override int GetHashCode()
        {
            return Source.GetHashCode();
        }
    }
}