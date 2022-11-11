using Framework.Domain;
using System;

namespace UserManagement.Domain.Contracts.Events
{ 
    
    public class UserRegistered: DomainEvent
    {
        public Guid UserId { get; private set; }
        public string Username { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public bool IsActivated { get; private set; }

         public UserRegistered(Guid userId, string userName, string firstName, string lastName)
        {
           
            UserId = userId;
            Username = userName;
            Firstname = firstName;
            Lastname = lastName;
            IsActivated = false;
        }
    }
}
