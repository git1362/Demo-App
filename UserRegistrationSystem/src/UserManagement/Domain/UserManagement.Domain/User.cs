using Framework.Domain;
using System;
using UserManagement.Domain.Contracts.Events;

namespace UserManagement.Domain
{
    public class User : AggregateRoot<UserId>
    {
        public string Username { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public bool IsActivated { get; private set; }

        protected User()
        {

        }

        public User(Guid id, string userName, string firstName, string lastName)
        {
            Causes(new UserRegistered(id, userName, firstName, lastName));
        }


        public override void Apply(DomainEvent @event)
        {
            When((dynamic)@event);
        }

        public void Activate()
        {
            //TODO: Check Invariant
            Causes(new UserActivated(this.Id.Value));
        }

        public void ChangePersonalInfo(string firstName, string lastName)
        {
            //TODO: Check Invariant
            Causes(new UserPersonalInfoUpdated(this.Id.Value, firstName, lastName));
        }

        private void When(UserRegistered @event)
        {
            this.Id = new UserId(@event.UserId);
            this.Firstname = @event.Firstname;
            this.Lastname = @event.Lastname;
            this.Username = @event.Username;
            this.IsActivated = false;
        }

        private void When(UserActivated @event)
        {
            this.IsActivated = @event.IsActivated;
        }

        private void When(UserPersonalInfoUpdated @event)
        {
            this.Firstname = @event.FirstName;
            this.Lastname = @event.LastName;
        }
    }
}