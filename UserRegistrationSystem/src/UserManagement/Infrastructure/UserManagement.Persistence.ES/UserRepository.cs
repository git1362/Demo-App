using Framework.Domain;
using UserManagement.Domain;

namespace UserManagement.Persistence.ES
{
    public class UserRepository : IUserRepository
    {
        private readonly IEventSourceRepository<User, UserId> _repository;
        public UserRepository(IEventSourceRepository<User, UserId> repository)
        {
            _repository = repository;
        }
        public Task<User> Get(UserId id)
        {
            return _repository.GetById(id);
        }
        public Task Add(User application)
        {
            return _repository.AppendEvents(application);
        }
        public Task Update(User application)
        {
            return _repository.AppendEvents(application);
        }
    }
}