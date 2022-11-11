using System.Threading.Tasks;

namespace UserManagement.Domain
{
    public interface IUserRepository
    {
        Task<User> Get(UserId id);
        Task Add(User user);
        Task Update(User user);
    }
}
