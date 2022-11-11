using System;
using Framework.Domain;

namespace UserManagement.Domain.Contracts.Events
{
    public class UserPersonalInfoUpdated : DomainEvent
    {
        public Guid UserId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public UserPersonalInfoUpdated(Guid userId, string firstName, string lastName)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
