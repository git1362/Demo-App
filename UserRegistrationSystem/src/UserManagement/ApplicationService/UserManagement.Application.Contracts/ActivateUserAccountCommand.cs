using Framework.Application;
using System;

namespace UserManagement.Application.Contracts
{
    public class ActivateUserAccountCommand: ICommand
    {
        public Guid UserId { get; set; }
    }
}
