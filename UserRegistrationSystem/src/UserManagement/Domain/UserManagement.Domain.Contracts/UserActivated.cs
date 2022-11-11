using Framework.Domain;
using System;

namespace UserManagement.Domain.Contracts.Events
{
    public class UserActivated: DomainEvent
    {
        public Guid UserId { get; private set; }
        public bool IsActivated { get; private set; }

        public UserActivated(Guid userId)
        {
            UserId = userId;
            IsActivated = true;
        }
    }
}
