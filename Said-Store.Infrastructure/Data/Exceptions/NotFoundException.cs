using Said_Store.Shared.Abstractions.Common;

namespace Said_Store.Infrastructure.Data.Exceptions
{
    public class NotFoundException : MyStoreException
    {
        public NotFoundException(string typeName, int id) : base("No " + typeName + " with Id " + id + " was found.") { }
        public NotFoundException(string typeName, string email): base($"No {typeName} with email {email} was found.") { }

        public NotFoundException(string message): base(message) { }
    }
}