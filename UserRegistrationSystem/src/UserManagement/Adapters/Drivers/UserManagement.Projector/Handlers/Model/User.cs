using System;

namespace LoanManagement.Projections.Sql.Handlers.Model
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public bool IsActivated { get; set; }
    }
}