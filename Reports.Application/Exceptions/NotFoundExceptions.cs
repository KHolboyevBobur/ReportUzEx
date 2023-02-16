using System;

namespace Reports.Application.Exceptions
{
    public class NotFoundExceptions : Exception
    {
        public NotFoundExceptions(string name, object key)
        : base($"Entity \"{name}\" ({key}) not found") { }
    }
}
