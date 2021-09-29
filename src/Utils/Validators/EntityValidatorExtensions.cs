using System;
using Utils.Dates;
using Utils.Exceptions;
using Utils.Helpers;
using Utils.Interfaces;

namespace Utils.Validators
{
    public static class EntityValidatorExtensions
    {
        /// <summary>
        /// Asserts that a model entity is valid by it's annotation validation attributes.
        /// </summary>
        /// <typeparam name="T">Generic.</typeparam>
        /// <param name="entity">Entity instance.</param>
        /// <returns>The entity.</returns>
        /// <exception cref="EntityInvalidException">If the entity is not valid.</exception>
        public static T ThrowIfInvalid<T>(this T entity)
        {
            new EntityValidator<T>(entity).ThrowIfInvalid();
            return entity;
        }

        /// <summary>
        /// Throws if date range is out of allowed limits.
        /// </summary>
        /// <typeparam name="T">Entity type.</typeparam>
        /// <param name="instance">The instance to check.</param>
        /// <returns>The entity itself.</returns>
        /// <exception cref="InvalidDateRangeException">If dates are not valid.</exception>
        public static T ThrowIfDateRangeIsOutOfAllowedLimits<T>(this T instance)
            where T : IHasFromToDates
        {
            instance.ThrowIfNull(nameof(instance));

            if (instance.ValidFrom.Earlier(TimeRange.Min) || instance.ValidFrom.Later(TimeRange.Max))
            {
                throw new InvalidDateRangeException(
                    $"{nameof(TimeRange.From)} is not within allowed range");
            }

            if (instance.ValidTo.Earlier(TimeRange.Min) || instance.ValidTo.Later(TimeRange.Max))
            {
                throw new InvalidDateRangeException(
                    $"{nameof(TimeRange.To)} is not within allowed range");
            }

            return instance;
        }

        public static TChild ThrowIfDateRangeIsNotIntersect<TChild, TParent>(this TChild instance, TParent parent)
        where TChild : IHasFromToDates
        where TParent : IHasFromToDates
        {
            instance.ThrowIfNull(nameof(instance));

            if (parent.ValidFrom.Later((DateTimeOffset)instance.ValidTo) || parent.ValidTo.Earlier(instance.ValidFrom))
            {
                throw new InvalidDateRangeException(
                      $"{nameof(TimeRange.From)} is not intersect");
            }

            if (Date.Today.StartOfTheDay().Later(instance.ValidFrom))
            {
                throw new InvalidDateRangeException($"You can't create {nameof(instance)} in past");
            }

            return instance;
        }

        public static T ThrowIfDateRangeIsNotValid<T>(this T instance, bool toIsRequired)
        where T : IHasFromToDates
        {
            if (instance.ValidFrom.Earlier(TimeRange.Min))
            {
                throw new InvalidDateRangeException(
                    $"A From Date of the {typeof(T).Name} should not be earlier than MinValue");
            }

            if (toIsRequired && !instance.ValidTo.HasValue)
            {
                throw new ArgumentNullException(nameof(instance.ValidTo), $"A To Date of the {typeof(T).Name} should not be null");
            }

            if (instance.RangeReversed(toIsRequired))
            {
                throw new InvalidDateRangeException("To date cannot be greater than From date");
            }

            if (instance.ValidTo.HasValue && instance.ValidTo.Value.Later(TimeRange.Max))
            {
                throw new InvalidDateRangeException(
                    $"A To Date of the {typeof(T).Name} should not be later than MaxValue");
            }

            return instance;
        }

        public static bool RangeReversed<T>(this T instance, bool toIsRequired)
            where T : IHasFromToDates
        {
            return (toIsRequired || instance.ValidTo.HasValue) && instance.ValidFrom.Later(instance.ToOrFail());
        }
    }
}