using Framework.Application;
using System;

namespace UserManagement.Application.Contracts
{
    public class RegisterUserCommand : ICommand
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}