using System.Linq;
using System.Threading.Tasks;
using Framework.Core.Events;
using LoanManagement.Projections.Sql.Handlers.Model;
using UserManagement.Domain.Contracts.Events;

namespace LoanManagement.Projections.Sql.Handlers
{
    public class UserPersonalInfoUpdatedHandler : IEventHandler<UserPersonalInfoUpdated>
    {
        private readonly UsersContext _context;
        public UserPersonalInfoUpdatedHandler(UsersContext context)
        {
            _context = context;
        }
        public async Task Handle(UserPersonalInfoUpdated @event)
        {
            if (_context.Users.Any(user => user.UserId == @event.UserId))
            {
                var user = _context.Users.SingleOrDefault(u => u.UserId == @event.UserId);
                user.Firstname = @event.FirstName;
                user.Lastname = @event.LastName;
                _context.Update(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}