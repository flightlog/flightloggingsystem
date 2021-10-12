﻿using FLS.Common.Exceptions;
using System;

namespace FLS.Common.Validators
{
    public static class Guard
    {
        public static T ArgumentNotNull<T>(this T argument, string argumentName)
        {
            if (ReferenceEquals(argument, null))
            {
                throw new ArgumentNullException(argumentName);
            }

            return argument;
        }

        public static void NotNull(this object value)
        {
            if (value == null)
            {
                throw new NullReferenceException();
            }
        }

        public static void NotNull(this object value, string objectType)
        {
            if (value == null)
            {
                throw new NullReferenceException($"The object '{objectType}' is null");
            }
        }

        public static string NotNullOrEmpty(this string argument, string argumentName)
        {
            if (string.IsNullOrEmpty(argument))
            {
                throw new ArgumentNullException(argumentName);
            }

            return argument;
        }

        public static Guid NotNullOrEmptyGuid(this Guid argument, string argumentName)
        {
            if (argument == Guid.Empty)
            {
                throw new ArgumentNullException(argumentName);
            }

            return argument;
        }

        public static T EntityNotNull<T>(this T entity, string entityName)
        {
            if (ReferenceEquals(entity, null))
            {
                throw new EntityNotFoundException(entityName);
            }

            return entity;
        }

        public static T EntityNotNull<T>(this T entity, string entityName, Guid id)
        {
            if (ReferenceEquals(entity, null))
            {
                throw new EntityNotFoundException(entityName, id);
            }

            return entity;
        }

        public static T EntityNotNull<T>(this T entity, string entityName, string key)
        {
            if (ReferenceEquals(entity, null))
            {
                throw new EntityNotFoundException(entityName, key);
            }

            return entity;
        }
    }
}
