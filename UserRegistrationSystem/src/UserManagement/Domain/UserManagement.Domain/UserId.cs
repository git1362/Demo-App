using Framework.Domain;
using System;

namespace UserManagement.Domain
{
    public class UserId: Id<Guid>
    {
        public UserId(Guid value) : base(value)
    {
    }
}
}
