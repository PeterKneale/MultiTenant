using System;

namespace Demo.Service.Common.Exceptions
{
    public class NotUniqueException : ApplicationException
    {
        public NotUniqueException(string entity, string property, string value)
            : base($"A {entity} with {property} equal to {value} already exists")
        {

        }
    }
}