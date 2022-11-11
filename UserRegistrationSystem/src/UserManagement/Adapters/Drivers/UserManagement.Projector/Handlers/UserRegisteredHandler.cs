using System.Linq;
using Framework.Core.Events;
using System.Threading.Tasks;
using UserManagement.Domain.Contracts.Events;
using LoanManagement.Projections.Sql.Handlers.Model;

namespace LoanManagement.Projections.Sql.Handlers
{
    public class UserRegisteredHandler : IEventHandler<UserRegistered>
    {
        private readonly UsersContext _context;
        public UserRegisteredHandler(UsersContext context)
        {
            _context = context;
        }
        public async Task Handle(UserRegistered @event)
        {
            if (!_context.Users.Any(user => user.UserId == @event.UserId))
            {
                var user = new User
                {
                    UserId = @event.UserId,
                    Firstname = @event.Firstname,
                    Lastname = @event.Lastname,
                    Username = @event.Username,
                    IsActivated = @event.IsActivated,
                };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}