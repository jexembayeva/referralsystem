﻿using System;
using Utils.Exceptions;
using Utils.Interfaces;

namespace Utils.Dates
{
    public static class HasFromToDatesExtensions
    {
        /// <summary>
        /// Returns <see cref="IHasFromToDates.To"/> if it exists.Otherwise, the exception will be thrown.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="instance">The entity.</param>
        /// <returns>Date.</returns>
        /// <exception cref="InvalidDateRangeException">The error.</exception>
        public static DateTimeOffset ToOrFail<T>(this T instance)
            where T : IHasFromToDates, IHasId
        {
            return instance.ValidTo ?? throw InvalidDateRangeException.CreateFromEntity<T>(instance.Id);
        }

        /// <summary>
        /// Returns <see cref="IHasFromToDates.To"/> if it exists.Otherwise, the exception will be thrown.
        /// </summary>
        /// <param name="instance">The entity.</param>
        /// <returns>Date.</returns>
        /// <exception cref="InvalidDateRangeException">The error.</exception>
        public static DateTimeOffset ToOrFail(this IHasFromToDates instance)
        {
            return instance.ValidTo ?? throw new InvalidDateRangeException();
        }

        public static Date Since(this IHasFromToDates instance) => new Date(instance.ValidFrom);

        public static Date Till(this IHasFromToDates instance) => new Date(instance.ToOrFail());

        public static Date ToAsDateOrNull(this IHasFromToDates instance)
        {
            if (instance.ValidTo == null)
            {
                return null;
            }

            return new Date(instance.ToOrFail());
        }
    }
}