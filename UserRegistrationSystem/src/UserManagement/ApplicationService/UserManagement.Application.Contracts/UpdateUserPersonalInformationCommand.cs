using Framework.Application;
using System;

namespace UserManagement.Application.Contracts
{
    public class UpdateUserPersonalInformationCommand: ICommand
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
