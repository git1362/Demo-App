using Framework.Application;
using System.Threading.Tasks;
using UserManagement.Application.Contracts;
using UserManagement.Domain;

namespace UserManagement.Application
{
    public class UserHandlers : ICommandHandler<RegisterUserCommand>,
                    ICommandHandler<UpdateUserPersonalInformationCommand>,
                    ICommandHandler<ActivateUserAccountCommand>
    {
        private readonly IUserRepository _userRepository;

        public UserHandlers(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(UpdateUserPersonalInformationCommand command)
        {
            var user = await _userRepository.Get(new UserId(command.UserId));
            user.ChangePersonalInfo(command.FirstName, command.LastName);
            await _userRepository.Update(user);
        }

        public async Task Handle(ActivateUserAccountCommand command)
        {
            var user = await _userRepository.Get(new UserId(command.UserId));
            user.Activate();
            await _userRepository.Update(user);
        }

        public async Task Handle(RegisterUserCommand command)
        {
            var user = new User(command.UserId, command.Username, command.Firstname, command.Lastname);
            await _userRepository.Add(user);
        }
    }
}
