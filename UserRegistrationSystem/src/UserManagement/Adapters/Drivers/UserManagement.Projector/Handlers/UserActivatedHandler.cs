using System.Linq;
using System.Threading.Tasks;
using Framework.Core.Events;
using LoanManagement.Projections.Sql.Handlers.Model;
using UserManagement.Domain.Contracts.Events;

namespace LoanManagement.Projections.Sql.Handlers
{
    public class UserActivatedHandler : IEventHandler<UserActivated>
    {
        private readonly UsersContext _context;
        public UserActivatedHandler(UsersContext context)
        {
            _context = context;
        }
        public async Task Handle(UserActivated @event)
        {
            if (_context.Users.Any(user => user.UserId == @event.UserId))
            {
                var user = _context.Users.SingleOrDefault(u => u.UserId == @event.UserId);
                user.IsActivated = @event.IsActivated;
                _context.Update(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}